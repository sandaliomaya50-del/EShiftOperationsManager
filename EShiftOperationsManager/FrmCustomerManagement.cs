
using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace EShiftOperationsManager
{
    public partial class FrmCustomerManagement : Form
    {
        private readonly string connectionString =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=EShiftOperationsDB;Integrated Security=True;TrustServerCertificate=True;";

        private int selectedCustomerId = 0;

        public FrmCustomerManagement()
        {
            InitializeComponent();

            Load -= FrmCustomerManagement_Load;
            Load += FrmCustomerManagement_Load;

            btnSearchCustomer.Click -= btnSearchCustomer_Click;
            btnSearchCustomer.Click += btnSearchCustomer_Click;

            btnClearSearch.Click -= btnClearSearch_Click;
            btnClearSearch.Click += btnClearSearch_Click;

            btnAddCustomer.Click -= btnAddCustomer_Click;
            btnAddCustomer.Click += btnAddCustomer_Click;

            btnUpdateCustomer.Click -= btnUpdateCustomer_Click;
            btnUpdateCustomer.Click += btnUpdateCustomer_Click;

            btnDeleteCustomer.Click -= btnDeleteCustomer_Click;
            btnDeleteCustomer.Click += btnDeleteCustomer_Click;

            btnClearCustomer.Click -= btnClearCustomer_Click;
            btnClearCustomer.Click += btnClearCustomer_Click;

            dgvCustomers.CellClick -= dgvCustomers_CellClick;
            dgvCustomers.CellClick += dgvCustomers_CellClick;

            btnDashboard.Click -= btnDashboard_Click;
            btnDashboard.Click += btnDashboard_Click;

            btnCustomers.Click -= btnCustomers_Click;
            btnCustomers.Click += btnCustomers_Click;

            btnAdmins.Click -= btnAdmins_Click;
            btnAdmins.Click += btnAdmins_Click;

            btnJobs.Click -= btnJobs_Click;
            btnJobs.Click += btnJobs_Click;

            btnProducts.Click -= btnProducts_Click;
            btnProducts.Click += btnProducts_Click;

            btnTransportUnits.Click -= btnTransportUnits_Click;
            btnTransportUnits.Click += btnTransportUnits_Click;

            btnManageJobAssignments.Click -= btnManageJobAssignments_Click;
            btnManageJobAssignments.Click += btnManageJobAssignments_Click;

            btnReports.Click -= btnReports_Click;
            btnReports.Click += btnReports_Click;

            btnLogout.Click -= btnLogout_Click;
            btnLogout.Click += btnLogout_Click;
        }

        // FORM LOAD
        private void FrmCustomerManagement_Load(object sender, EventArgs e)
        {
            txtCustomerNumber.ReadOnly = true;

            dgvCustomers.ReadOnly = true;
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.AllowUserToDeleteRows = false;
            dgvCustomers.MultiSelect = false;

            dgvCustomers.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvCustomers.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            LoadCustomers();
        }

        // LOAD CUSTOMERS FROM DATABASE
        private void LoadCustomers(string searchText = "")
        {
            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    string sql = @"
SELECT
    CustomerID,
    CustomerNo,
    FullName,
    Address,
    Telephone,
    Email,
    Username,
    IsActive
FROM dbo.Customers
WHERE
    @Search = ''
    OR CustomerNo LIKE @Pattern
    OR FullName LIKE @Pattern
    OR Address LIKE @Pattern
    OR Telephone LIKE @Pattern
    OR Email LIKE @Pattern
    OR Username LIKE @Pattern
ORDER BY CustomerID DESC;";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.Add("@Search",
                            SqlDbType.NVarChar, 200).Value = searchText;

                        cmd.Parameters.Add("@Pattern",
                            SqlDbType.NVarChar, 202).Value =
                            "%" + searchText + "%";

                        using (SqlDataAdapter adapter =
                            new SqlDataAdapter(cmd))
                        {
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            dgvCustomers.DataSource = table;
                        }
                    }
                }

                if (dgvCustomers.Columns.Contains("CustomerID"))
                    dgvCustomers.Columns["CustomerID"].Visible = false;

                if (dgvCustomers.Columns.Contains("CustomerNo"))
                    dgvCustomers.Columns["CustomerNo"].HeaderText =
                        "Customer Number";

                if (dgvCustomers.Columns.Contains("IsActive"))
                    dgvCustomers.Columns["IsActive"].HeaderText = "Active";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load customer records.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // SEARCH CUSTOMER
        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            LoadCustomers(txtSearchJobNo.Text.Trim());

            MessageBox.Show(
                dgvCustomers.Rows.Count +
                " matching customer record(s) found.",
                "Search Results",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // CLEAR SEARCH
        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearchJobNo.Clear();
            LoadCustomers();

            MessageBox.Show(
                "Search cleared successfully.",
                "Search",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // GENERATE TEMPORARY PASSWORD
        private string GenerateTemporaryPassword()
        {
            byte[] bytes = new byte[12];

            using (RandomNumberGenerator rng =
                RandomNumberGenerator.Create())
            {
                rng.GetBytes(bytes);
            }

            return "Temp@" + Convert.ToBase64String(bytes)
                .Replace("+", "A")
                .Replace("/", "B")
                .Replace("=", "C");
        }

        // HASH PASSWORD
        private string HashPassword(string password)
        {
            byte[] salt = new byte[16];

            using (RandomNumberGenerator rng =
                RandomNumberGenerator.Create())
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

        // GENERATE CUSTOMER NUMBER
        private string GenerateCustomerNumber(
            SqlConnection con, SqlTransaction transaction)
        {
            string sql = @"
SELECT
    'CUS' +
    RIGHT(
        '000000' +
        CAST(
            ISNULL(
                MAX(TRY_CONVERT(INT, SUBSTRING(CustomerNo, 4, 20))),
                0
            ) + 1 AS VARCHAR(20)
        ),
        6
    )
FROM dbo.Customers WITH (UPDLOCK, HOLDLOCK)
WHERE CustomerNo LIKE 'CUS%';";

            using (SqlCommand cmd =
                new SqlCommand(sql, con, transaction))
            {
                return Convert.ToString(cmd.ExecuteScalar());
            }
        }

        // VALIDATE CUSTOMER DETAILS
        private bool ValidateCustomerDetails()
        {
            if (string.IsNullOrWhiteSpace(txtCustomerFullName.Text) ||
                string.IsNullOrWhiteSpace(txtCustomerAddress.Text) ||
                string.IsNullOrWhiteSpace(txtCustomerTelephone.Text) ||
                string.IsNullOrWhiteSpace(txtCustomerEmail.Text) ||
                string.IsNullOrWhiteSpace(txtCustomerUsername.Text))
            {
                MessageBox.Show(
                    "Please complete all customer details.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        // ADD CUSTOMER
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            if (!ValidateCustomerDetails())
                return;

            string temporaryPassword = GenerateTemporaryPassword();

            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    con.Open();

                    using (SqlTransaction transaction =
                        con.BeginTransaction(IsolationLevel.Serializable))
                    {
                        try
                        {
                            string customerNo =
                                GenerateCustomerNumber(con, transaction);

                            string sql = @"
INSERT INTO dbo.Customers
(
    CustomerNo,
    FullName,
    Address,
    Telephone,
    Email,
    Username,
    PasswordHash,
    IsActive
)
VALUES
(
    @CustomerNo,
    @FullName,
    @Address,
    @Telephone,
    @Email,
    @Username,
    @PasswordHash,
    1
);";

                            using (SqlCommand cmd =
                                new SqlCommand(sql, con, transaction))
                            {
                                cmd.Parameters.Add("@CustomerNo",
                                    SqlDbType.VarChar, 20).Value =
                                    customerNo;

                                AddCustomerParameters(cmd);

                                cmd.Parameters.Add("@PasswordHash",
                                    SqlDbType.NVarChar, 255).Value =
                                    HashPassword(temporaryPassword);

                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();

                            MessageBox.Show(
                                "Customer added successfully!\n\n" +
                                "Customer Number: " + customerNo +
                                "\nTemporary Password: " +
                                temporaryPassword +
                                "\n\nPlease save this password.",
                                "Customer Added",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }

                ClearCustomerFields();
                LoadCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to add customer.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // CUSTOMER PARAMETERS
        private void AddCustomerParameters(SqlCommand cmd)
        {
            cmd.Parameters.Add("@FullName",
                SqlDbType.NVarChar, 100).Value =
                txtCustomerFullName.Text.Trim();

            cmd.Parameters.Add("@Address",
                SqlDbType.NVarChar, 300).Value =
                txtCustomerAddress.Text.Trim();

            cmd.Parameters.Add("@Telephone",
                SqlDbType.NVarChar, 20).Value =
                txtCustomerTelephone.Text.Trim();

            cmd.Parameters.Add("@Email",
                SqlDbType.NVarChar, 150).Value =
                txtCustomerEmail.Text.Trim();

            cmd.Parameters.Add("@Username",
                SqlDbType.NVarChar, 50).Value =
                txtCustomerUsername.Text.Trim();
        }

        // UPDATE CUSTOMER
        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            if (selectedCustomerId == 0)
            {
                MessageBox.Show(
                    "Select a customer from the table first.",
                    "Select Customer",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (!ValidateCustomerDetails())
                return;

            DialogResult answer = MessageBox.Show(
                "Update the selected customer?",
                "Confirm Update",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (answer != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    con.Open();

                    string sql = @"
UPDATE dbo.Customers
SET
    FullName = @FullName,
    Address = @Address,
    Telephone = @Telephone,
    Email = @Email,
    Username = @Username
WHERE CustomerID = @CustomerID;";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        AddCustomerParameters(cmd);

                        cmd.Parameters.Add("@CustomerID",
                            SqlDbType.Int).Value = selectedCustomerId;

                        int affected = cmd.ExecuteNonQuery();

                        if (affected == 0)
                        {
                            MessageBox.Show(
                                "Selected customer was not found.",
                                "Update",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }
                    }
                }

                MessageBox.Show(
                    "Customer updated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearCustomerFields();
                LoadCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to update customer.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // DELETE CUSTOMER
        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (selectedCustomerId == 0)
            {
                MessageBox.Show(
                    "Select a customer from the table first.",
                    "Select Customer",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult answer = MessageBox.Show(
                "Permanently delete this customer?\n\n" +
                "Existing transport jobs may prevent deletion.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (answer != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    con.Open();

                    string sql = @"
DELETE FROM dbo.Customers
WHERE CustomerID = @CustomerID;";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.Add("@CustomerID",
                            SqlDbType.Int).Value = selectedCustomerId;

                        int affected = cmd.ExecuteNonQuery();

                        if (affected == 0)
                        {
                            MessageBox.Show(
                                "Customer was not found.",
                                "Delete",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }
                    }
                }

                MessageBox.Show(
                    "Customer deleted successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearCustomerFields();
                LoadCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to delete customer. Existing transport jobs " +
                    "may reference this customer.\n\n" + ex.Message,
                    "Delete Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // SELECT CUSTOMER FROM TABLE
        private void dgvCustomers_CellClick(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];

            if (row.Cells["CustomerID"].Value == null)
                return;

            selectedCustomerId =
                Convert.ToInt32(row.Cells["CustomerID"].Value);

            txtCustomerNumber.Text =
                GetCellText(row, "CustomerNo");

            txtCustomerFullName.Text =
                GetCellText(row, "FullName");

            txtCustomerAddress.Text =
                GetCellText(row, "Address");

            txtCustomerTelephone.Text =
                GetCellText(row, "Telephone");

            txtCustomerEmail.Text =
                GetCellText(row, "Email");

            txtCustomerUsername.Text =
                GetCellText(row, "Username");
        }

        private string GetCellText(
            DataGridViewRow row, string columnName)
        {
            object value = row.Cells[columnName].Value;

            return value == null || value == DBNull.Value
                ? string.Empty
                : value.ToString();
        }

        // CLEAR CUSTOMER DETAILS
        private void btnClearCustomer_Click(object sender, EventArgs e)
        {
            ClearCustomerFields();

            MessageBox.Show(
                "Customer details cleared.",
                "Clear",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void ClearCustomerFields()
        {
            selectedCustomerId = 0;

            txtCustomerNumber.Clear();
            txtCustomerFullName.Clear();
            txtCustomerAddress.Clear();
            txtCustomerTelephone.Clear();
            txtCustomerEmail.Clear();
            txtCustomerUsername.Clear();

            dgvCustomers.ClearSelection();

            txtCustomerFullName.Focus();
        }

        // OPEN OTHER MANAGEMENT PAGES
        private void OpenPage(Form child)
        {
            Hide();

            try
            {
                using (child)
                {
                    child.StartPosition = FormStartPosition.CenterScreen;
                    child.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to open selected page.\n\n" + ex.Message,
                    "Navigation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                if (!IsDisposed)
                {
                    Show();
                    Activate();
                    LoadCustomers(txtSearchJobNo.Text.Trim());
                }
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            LoadCustomers();

            MessageBox.Show(
                "Customer list refreshed.",
                "Customers",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnAdmins_Click(object sender, EventArgs e)
        {
            OpenPage(new FrmAdminManagement());
        }

        private void btnJobs_Click(object sender, EventArgs e)
        {
            OpenPage(new FrmJobManagement());
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            OpenPage(new FrmProductManagement());
        }

        private void btnTransportUnits_Click(object sender, EventArgs e)
        {
            OpenPage(new FrmTransportUnitManagement());
        }

        private void btnManageJobAssignments_Click(
            object sender, EventArgs e)
        {
            MessageBox.Show(
                "Job Assignments page has not been connected yet.",
                "Job Assignments",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            OpenPage(new FrmReports());
        }

        // LOGOUT
        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show(
                "Are you sure you want to logout?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (answer != DialogResult.Yes)
                return;

            FrmLogin login = new FrmLogin();
            login.StartPosition = FormStartPosition.CenterScreen;
            login.Show();

            FrmAdminDashboard dashboard = null;

            foreach (Form form in Application.OpenForms)
            {
                if (form is FrmAdminDashboard && !form.IsDisposed)
                {
                    dashboard = (FrmAdminDashboard)form;
                    break;
                }
            }

            if (dashboard != null)
                dashboard.Close();

            Close();
        }

        // EXISTING DESIGNER EVENTS
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void lblWelcomeDescription_Click(
            object sender, EventArgs e)
        {
        }

        private void pnlCustomerDetails_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
