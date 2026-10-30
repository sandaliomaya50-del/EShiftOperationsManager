
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace EShiftOperationsManager
{
    public partial class FrmCustomerRegistration : Form
    {
        private readonly string connectionString =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=EShiftOperationsDB;Integrated Security=True;TrustServerCertificate=True;";

        public FrmCustomerRegistration()
        {
            InitializeComponent();

            btnRegister.Click -= btnRegister_Click;
            btnRegister.Click += btnRegister_Click;

            btnClear.Click -= btnClear_Click;
            btnClear.Click += btnClear_Click;

            btnBackToLogin.Click -= btnBackToLogin_Click;
            btnBackToLogin.Click += btnBackToLogin_Click;

            Load -= FrmCustomerRegistration_Load;
            Load += FrmCustomerRegistration_Load;

            txtPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;

            txtCustomerNumber.ReadOnly = true;
        }

        // FORM LOAD
        private void FrmCustomerRegistration_Load(
            object sender, EventArgs e)
        {
            txtCustomerNumber.Clear();
            txtCustomerNumber.ReadOnly = true;

            txtPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;
        }

        // PASSWORD HASHING
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

        // GET ACTUAL DATABASE COLUMNS
        private HashSet<string> GetCustomerColumns(
            SqlConnection con)
        {
            HashSet<string> columns =
                new HashSet<string>(
                    StringComparer.OrdinalIgnoreCase);

            string query = @"
SELECT COLUMN_NAME
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_SCHEMA = 'dbo'
AND TABLE_NAME = 'Customers';";

            using (SqlCommand cmd =
                new SqlCommand(query, con))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    columns.Add(
                        reader["COLUMN_NAME"].ToString());
                }
            }

            return columns;
        }

        // GET IDENTITY COLUMN
        private string GetIdentityColumn(SqlConnection con)
        {
            string query = @"
SELECT c.name
FROM sys.identity_columns ic
INNER JOIN sys.columns c
    ON ic.object_id = c.object_id
    AND ic.column_id = c.column_id
WHERE ic.object_id = OBJECT_ID('dbo.Customers');";

            using (SqlCommand cmd =
                new SqlCommand(query, con))
            {
                object result = cmd.ExecuteScalar();

                if (result == null || result == DBNull.Value)
                    return null;

                return result.ToString();
            }
        }

        // REGISTER CUSTOMER
        private void btnRegister_Click(
            object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string address = txtAddress.Text.Trim();
            string telephone = txtTelephone.Text.Trim();
            string email = txtEmail.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // REQUIRED FIELD VALIDATION
            if (string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(address) ||
                string.IsNullOrWhiteSpace(telephone) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show(
                    "Please fill in all required fields.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // NAME VALIDATION
            if (fullName.Length < 3)
            {
                MessageBox.Show(
                    "Please enter a valid full name.",
                    "Invalid Name",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtFullName.Focus();
                return;
            }

            // TELEPHONE VALIDATION
            if (telephone.Length < 7)
            {
                MessageBox.Show(
                    "Please enter a valid telephone number.",
                    "Invalid Telephone",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTelephone.Focus();
                return;
            }

            // EMAIL VALIDATION
            try
            {
                var emailAddress =
                    new System.Net.Mail.MailAddress(email);

                if (emailAddress.Address != email)
                    throw new FormatException();
            }
            catch
            {
                MessageBox.Show(
                    "Please enter a valid email address.",
                    "Invalid Email",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtEmail.Focus();
                return;
            }

            // USERNAME VALIDATION
            if (username.Length < 4)
            {
                MessageBox.Show(
                    "Username must contain at least 4 characters.",
                    "Invalid Username",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtUsername.Focus();
                return;
            }

            // PASSWORD VALIDATION
            if (password.Length < 8)
            {
                MessageBox.Show(
                    "Password must contain at least 8 characters.",
                    "Invalid Password",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPassword.Focus();
                return;
            }

            // CONFIRM PASSWORD
            if (password != confirmPassword)
            {
                MessageBox.Show(
                    "Password and Confirm Password do not match.",
                    "Password Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtConfirmPassword.Focus();
                return;
            }

            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    con.Open();

                    HashSet<string> columns =
                        GetCustomerColumns(con);

                    // CHECK REQUIRED DATABASE COLUMNS
                    string[] requiredColumns =
                    {
                        "CustomerNo",
                        "FullName",
                        "Address",
                        "Telephone",
                        "Email",
                        "Username",
                        "PasswordHash"
                    };

                    foreach (string column in requiredColumns)
                    {
                        if (!columns.Contains(column))
                        {
                            throw new Exception(
                                "The Customers table is missing " +
                                "the required column: " + column);
                        }
                    }

                    // CHECK DUPLICATE USERNAME
                    string checkQuery = @"
SELECT COUNT(*)
FROM dbo.Customers
WHERE Username = @Username;";

                    using (SqlCommand check =
                        new SqlCommand(checkQuery, con))
                    {
                        check.Parameters.Add(
                            "@Username",
                            SqlDbType.NVarChar,
                            50).Value = username;

                        int count =
                            Convert.ToInt32(check.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show(
                                "This username already exists. " +
                                "Please choose another username.",
                                "Duplicate Username",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            txtUsername.Focus();
                            return;
                        }
                    }

                    // GET IDENTITY COLUMN
                    string identityColumn =
                        GetIdentityColumn(con);

                    if (string.IsNullOrEmpty(identityColumn))
                    {
                        throw new Exception(
                            "The Customers table does not have " +
                            "an identity column.");
                    }

                    // GENERATE UNIQUE CUSTOMER NUMBER
                    string customerNo =
                        "CUS" +
                        Guid.NewGuid().ToString("N").Substring(0, 17);

                    // PREPARE INSERT
                    List<string> insertColumns =
                        new List<string>();

                    List<string> parameterNames =
                        new List<string>();

                    insertColumns.Add("[CustomerNo]");
                    parameterNames.Add("@CustomerNo");

                    insertColumns.Add("[FullName]");
                    parameterNames.Add("@FullName");

                    insertColumns.Add("[Address]");
                    parameterNames.Add("@Address");

                    insertColumns.Add("[Telephone]");
                    parameterNames.Add("@Telephone");

                    insertColumns.Add("[Email]");
                    parameterNames.Add("@Email");

                    insertColumns.Add("[Username]");
                    parameterNames.Add("@Username");

                    insertColumns.Add("[PasswordHash]");
                    parameterNames.Add("@PasswordHash");

                    // CREATED DATE
                    if (columns.Contains("CreatedAt"))
                    {
                        insertColumns.Add("[CreatedAt]");
                        parameterNames.Add("SYSDATETIME()");
                    }

                    // REGISTRATION DATE
                    if (columns.Contains("DateRegistered"))
                    {
                        insertColumns.Add("[DateRegistered]");
                        parameterNames.Add("SYSDATETIME()");
                    }

                    // CUSTOMER STATUS
                    if (columns.Contains("Status"))
                    {
                        insertColumns.Add("[Status]");
                        parameterNames.Add("'Active'");
                    }

                    // ACTIVE STATUS
                    if (columns.Contains("IsActive"))
                    {
                        insertColumns.Add("[IsActive]");
                        parameterNames.Add("1");
                    }

                    string insertQuery =
                        "INSERT INTO dbo.Customers (" +
                        string.Join(", ", insertColumns) +
                        ") OUTPUT INSERTED.[" +
                        identityColumn +
                        "] VALUES (" +
                        string.Join(", ", parameterNames) +
                        ");";

                    using (SqlCommand cmd =
                        new SqlCommand(insertQuery, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@CustomerNo", customerNo);

                        cmd.Parameters.AddWithValue(
                            "@FullName", fullName);

                        cmd.Parameters.AddWithValue(
                            "@Address", address);

                        cmd.Parameters.AddWithValue(
                            "@Telephone", telephone);

                        cmd.Parameters.AddWithValue(
                            "@Email", email);

                        cmd.Parameters.AddWithValue(
                            "@Username", username);

                        cmd.Parameters.AddWithValue(
                            "@PasswordHash",
                            HashPassword(password));

                        object generatedID =
                            cmd.ExecuteScalar();

                        if (generatedID == null ||
                            generatedID == DBNull.Value)
                        {
                            throw new Exception(
                                "Customer registration failed. " +
                                "Customer ID was not generated.");
                        }

                        // DISPLAY GENERATED CUSTOMER NUMBER
                        txtCustomerNumber.Text = customerNo;
                    }
                }

                // REGISTRATION SUCCESSFUL
                MessageBox.Show(
                    "Customer registered successfully!\n\n" +
                    "Customer Number: " +
                    txtCustomerNumber.Text +
                    "\n\nYou can now log in using your username " +
                    "and password.",
                    "Registration Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // RETURN TO LOGIN
                ShowLoginForm();

                Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Database registration failed:\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Registration failed:\n\n" +
                    ex.Message,
                    "Registration Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // CLEAR BUTTON
        private void btnClear_Click(
            object sender, EventArgs e)
        {
            ClearRegistrationFields();

            MessageBox.Show(
                "Registration fields cleared successfully.",
                "Cleared",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // CLEAR ALL FIELDS
        private void ClearRegistrationFields()
        {
            txtCustomerNumber.Clear();
            txtFullName.Clear();
            txtAddress.Clear();
            txtTelephone.Clear();
            txtEmail.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();

            txtFullName.Focus();
        }

        // BACK TO LOGIN BUTTON
        private void btnBackToLogin_Click(
            object sender, EventArgs e)
        {
            ShowLoginForm();

            Close();
        }

        // SHOW LOGIN FORM
        private void ShowLoginForm()
        {
            FrmLogin login = null;

            foreach (Form form in Application.OpenForms)
            {
                if (form is FrmLogin && !form.IsDisposed)
                {
                    login = (FrmLogin)form;
                    break;
                }
            }

            if (login == null)
            {
                login = new FrmLogin();
            }

            login.StartPosition =
                FormStartPosition.CenterScreen;

            login.WindowState =
                FormWindowState.Normal;

            login.Show();
            login.BringToFront();
            login.Activate();
        }
    }
}
