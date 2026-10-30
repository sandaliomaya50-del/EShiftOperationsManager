
using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace EShiftOperationsManager
{
    public partial class FrmLogin : Form
    {
        private readonly string connectionString =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=EShiftOperationsDB;Integrated Security=True;TrustServerCertificate=True;";

        public FrmLogin()
        {
            InitializeComponent();

            btnLogin.Click -= btnLogin_Click;
            btnLogin.Click += btnLogin_Click;

            btnRegister.Click -= btnRegister_Click;
            btnRegister.Click += btnRegister_Click;

            Load -= FrmLogin_Load;
            Load += FrmLogin_Load;

            txtPassword.UseSystemPasswordChar = true;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                CreateDefaultAccountsIfMissing();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Database initialization failed:\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // PASSWORD HASHING
        // ==========================================

        private string HashPassword(string password)
        {
            byte[] salt = new byte[16];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            const int iterations = 100000;

            using (var pbkdf2 =
                new Rfc2898DeriveBytes(password, salt, iterations))
            {
                byte[] hash = pbkdf2.GetBytes(32);

                return "PBKDF2$" + iterations + "$" +
                    Convert.ToBase64String(salt) + "$" +
                    Convert.ToBase64String(hash);
            }
        }

        // ==========================================
        // VERIFY PASSWORD
        // ==========================================

        private bool VerifyPassword(string password, string storedHash)
        {
            try
            {
                string[] parts = storedHash.Split('$');

                if (parts.Length != 4 || parts[0] != "PBKDF2")
                    return false;

                int iterations = int.Parse(parts[1]);

                byte[] salt =
                    Convert.FromBase64String(parts[2]);

                byte[] expectedHash =
                    Convert.FromBase64String(parts[3]);

                using (var pbkdf2 =
                    new Rfc2898DeriveBytes(password, salt, iterations))
                {
                    byte[] actualHash =
                        pbkdf2.GetBytes(expectedHash.Length);

                    return AreBytesEqual(actualHash, expectedHash);
                }
            }
            catch
            {
                return false;
            }
        }

        // Compatible with older .NET versions.
        private bool AreBytesEqual(byte[] first, byte[] second)
        {
            if (first.Length != second.Length)
                return false;

            int difference = 0;

            for (int i = 0; i < first.Length; i++)
                difference |= first[i] ^ second[i];

            return difference == 0;
        }

        // ==========================================
        // CREATE DEFAULT ACCOUNTS
        // ==========================================

        private void CreateDefaultAccountsIfMissing()
        {
            using (SqlConnection con =
                new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(@"

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.Admins
    WHERE Username = @AdminUsername
)
BEGIN
    INSERT INTO dbo.Admins
    (
        AdminID,
        FullName,
        Username,
        PasswordHash,
        ContactNumber,
        Email,
        Role,
        CreatedAt,
        IsActive
    )
    VALUES
    (
        @AdminID,
        @AdminName,
        @AdminUsername,
        @AdminHash,
        '',
        '',
        'Admin',
        SYSDATETIME(),
        1
    );
END;

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.Customers
    WHERE Username = @CustomerUsername
)
BEGIN
    INSERT INTO dbo.Customers
    (
        CustomerNo,
        FullName,
        Address,
        Telephone,
        Email,
        Username,
        PasswordHash,
        CreatedAt,
        IsActive
    )
    VALUES
    (
        @CustomerNo,
        @CustomerName,
        '',
        '',
        '',
        @CustomerUsername,
        @CustomerHash,
        SYSDATETIME(),
        1
    );
END;

", con))
                {
                    cmd.Parameters.AddWithValue(
                        "@AdminID",
                        "ADM" + Guid.NewGuid().ToString("N").Substring(0, 17));

                    cmd.Parameters.AddWithValue(
                        "@AdminUsername", "admin");

                    cmd.Parameters.AddWithValue(
                        "@AdminName", "System Administrator");

                    cmd.Parameters.AddWithValue(
                        "@AdminHash",
                        HashPassword("Admin@2026!Shift"));

                    cmd.Parameters.AddWithValue(
                        "@CustomerNo",
                        "CUS" + Guid.NewGuid().ToString("N").Substring(0, 17));

                    cmd.Parameters.AddWithValue(
                        "@CustomerUsername", "customer1");

                    cmd.Parameters.AddWithValue(
                        "@CustomerName", "Test Customer");

                    cmd.Parameters.AddWithValue(
                        "@CustomerHash",
                        HashPassword("Customer@2026!Shift"));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ==========================================
        // LOGIN BUTTON
        // ==========================================

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(
                    "Please enter both username and password.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (!rdoAdmin.Checked && !rdoCustomer.Checked)
            {
                MessageBox.Show(
                    "Please select Admin or Customer.",
                    "User Type Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            bool isAdmin = rdoAdmin.Checked;

            string tableName = isAdmin
                ? "dbo.Admins"
                : "dbo.Customers";

            try
            {
                bool authenticated = false;

                // This will store the logged-in customer's ID.
                int loggedInCustomerID = 0;

                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    con.Open();

                    // IMPORTANT:
                    // Retrieve CustomerID together with PasswordHash.
                    string query = isAdmin
                        ? @"
                            SELECT PasswordHash
                            FROM dbo.Admins
                            WHERE Username = @Username
                            AND IsActive = 1;"
                        : @"
                            SELECT CustomerID, PasswordHash
                            FROM dbo.Customers
                            WHERE Username = @Username
                            AND IsActive = 1;";

                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@Username", username);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string storedHash =
                                    reader["PasswordHash"].ToString();

                                authenticated =
                                    VerifyPassword(password, storedHash);

                                // Retrieve CustomerID only after successful
                                // password verification.
                                if (authenticated && !isAdmin)
                                {
                                    loggedInCustomerID =
                                        Convert.ToInt32(
                                            reader["CustomerID"]);
                                }
                            }
                        }
                    }
                }

                if (!authenticated)
                {
                    MessageBox.Show(
                        "Incorrect username or password.",
                        "Login Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                MessageBox.Show(
                    "Login successful!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Form dashboard;

                if (isAdmin)
                {
                    dashboard = new FrmAdminDashboard();
                }
                else
                {
                    // PASS THE LOGGED-IN CUSTOMER ID.
                    dashboard =
                        new FrmCustomerDashboard(loggedInCustomerID);
                }

                OpenChildForm(dashboard);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to log in:\n" + ex.Message,
                    "Login Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // CUSTOMER REGISTRATION
        // ==========================================

        private void btnRegister_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmCustomerRegistration());
        }

        // ==========================================
        // OPEN CHILD FORM
        // ==========================================

        private void OpenChildForm(Form childForm)
        {
            childForm.StartPosition =
                FormStartPosition.CenterScreen;

            childForm.FormClosed += (s, args) =>
            {
                txtUsername.Clear();
                txtPassword.Clear();

                rdoAdmin.Checked = false;
                rdoCustomer.Checked = false;

                Show();
                Activate();

                txtUsername.Focus();
            };

            Hide();
            childForm.Show();
        }
    }
}


