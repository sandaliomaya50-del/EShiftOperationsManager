
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace EShiftOperationsManager
{
    public partial class RequestTransportForm : Form
    {
        private readonly string connectionString =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=EShiftOperationsDB;Integrated Security=True;TrustServerCertificate=True;";

        private int customerID;

        private List<PendingLoad> pendingLoads =
            new List<PendingLoad>();

        public int CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }

        private class PendingLoad
        {
            public string ProductID { get; set; }
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public decimal? EstimatedWeightKg { get; set; }
            public string EstimatedSize { get; set; }
        }

        public RequestTransportForm() : this(0)
        {
        }

        public RequestTransportForm(int customerID)
        {
            InitializeComponent();

            this.customerID = customerID;

            // Navigation buttons
            btnDashboard.Click += btnDashboard_Click;
            btnCreateRequest.Click += btnCreateRequest_Click;
            btnMyJobs.Click += btnMyJobs_Click;
            btnMyRequests.Click += btnMyRequests_Click;
            btnMyPayments.Click += btnMyPayments_Click;
            btnProfile.Click += btnProfile_Click;
            btnLogout.Click += btnLogout_Click;

            // Request buttons
            btnAddLoad.Click += btnAddLoad_Click;
            btnSubmitRequest.Click += btnSubmitRequest_Click;
            btnClearRequest.Click += btnClearRequest_Click;

            // Load grid
            dgvAddedLoads.CellContentClick +=
                dgvAddedLoads_CellContentClick;

            this.Load += RequestTransportForm_Load;
        }

        // ==========================================
        // FORM LOAD
        // ==========================================

        private void RequestTransportForm_Load(
            object sender, EventArgs e)
        {
            try
            {
                LoadCustomers();
                LoadPreferredTimes();
                GenerateJobNumber();

                dgvAddedLoads.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load the transport request form.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // LOAD CUSTOMERS
        // ==========================================

        private void LoadCustomers()
        {
            using (SqlConnection con =
                new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT
                        CustomerID,
                        CustomerNo + ' - ' + FullName AS CustomerDisplay
                    FROM dbo.Customers
                    WHERE IsActive = 1
                    AND (@CustomerID = 0 OR CustomerID = @CustomerID)
                    ORDER BY FullName";

                using (SqlCommand cmd =
                    new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@CustomerID",
                        SqlDbType.Int).Value = customerID;

                    DataTable dt = new DataTable();

                    con.Open();

                    using (SqlDataAdapter adapter =
                        new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }

                    cmbCustomerNumber.DataSource = null;
                    cmbCustomerNumber.DisplayMember =
                        "CustomerDisplay";
                    cmbCustomerNumber.ValueMember =
                        "CustomerID";
                    cmbCustomerNumber.DataSource = dt;

                    if (dt.Rows.Count > 0)
                    {
                        cmbCustomerNumber.SelectedIndex = 0;

                        if (customerID > 0)
                        {
                            cmbCustomerNumber.SelectedValue =
                                customerID;
                        }
                    }
                    else
                    {
                        cmbCustomerNumber.SelectedIndex = -1;

                        MessageBox.Show(
                            "No active customer account was found.",
                            "Customer Information",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                }
            }
        }

        // ==========================================
        // PREFERRED TIME
        // ==========================================

        private void LoadPreferredTimes()
        {
            cmbPreferredTime.Items.Clear();

            cmbPreferredTime.Items.Add("8:00 AM - 10:00 AM");
            cmbPreferredTime.Items.Add("10:00 AM - 12:00 PM");
            cmbPreferredTime.Items.Add("12:00 PM - 2:00 PM");
            cmbPreferredTime.Items.Add("2:00 PM - 4:00 PM");
            cmbPreferredTime.Items.Add("4:00 PM - 6:00 PM");

            cmbPreferredTime.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cmbPreferredTime.SelectedIndex = 0;
        }

        // ==========================================
        // GENERATE JOB NUMBER PREVIEW
        // ==========================================

        private void GenerateJobNumber()
        {
            using (SqlConnection con =
                new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT ISNULL(
                        MAX(TRY_CONVERT(INT, SUBSTRING(JobNo, 3, 20))),
                        0
                    ) + 1
                    FROM dbo.TransportJobs
                    WHERE JobNo LIKE 'J-%'";

                using (SqlCommand cmd =
                    new SqlCommand(query, con))
                {
                    con.Open();

                    int nextNumber =
                        Convert.ToInt32(cmd.ExecuteScalar());

                    txtJobNumber.Text =
                        "J-" + nextNumber.ToString("D4");
                }
            }
        }

        // ==========================================
        // ADD LOAD
        // ==========================================

        private void btnAddLoad_Click(object sender, EventArgs e)
        {
            try
            {
                string productName =
                    txtCustomerNumber.Text.Trim();

                if (string.IsNullOrWhiteSpace(productName))
                {
                    MessageBox.Show(
                        "Please enter a Product / Load Name.",
                        "Required Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtCustomerNumber.Focus();
                    return;
                }

                int quantity;

                if (!int.TryParse(
                    txtQuantity.Text.Trim(), out quantity) ||
                    quantity <= 0)
                {
                    MessageBox.Show(
                        "Please enter a valid quantity.",
                        "Invalid Quantity",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtQuantity.Focus();
                    return;
                }

                string productID;
                string actualProductName;

                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT TOP 1 ProductID, ProductName
                        FROM dbo.Products
                        WHERE ProductName = @ProductName
                        AND Status = 'Active'";

                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        cmd.Parameters.Add(
                            "@ProductName",
                            SqlDbType.NVarChar,
                            100).Value = productName;

                        con.Open();

                        using (SqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                MessageBox.Show(
                                    "Product not found or inactive.\n\n" +
                                    "Please enter an existing active product name.",
                                    "Product Not Found",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                                txtCustomerNumber.Focus();
                                return;
                            }

                            productID =
                                reader["ProductID"].ToString();

                            actualProductName =
                                reader["ProductName"].ToString();
                        }
                    }
                }

                string weightSize =
                    txtEstimatedWeightSize.Text.Trim();

                decimal parsedWeight;
                decimal? estimatedWeight = null;
                string estimatedSize = null;

                if (!string.IsNullOrWhiteSpace(weightSize))
                {
                    if (decimal.TryParse(
                        weightSize,
                        NumberStyles.Any,
                        CultureInfo.CurrentCulture,
                        out parsedWeight) ||
                        decimal.TryParse(
                        weightSize,
                        NumberStyles.Any,
                        CultureInfo.InvariantCulture,
                        out parsedWeight))
                    {
                        if (parsedWeight < 0)
                        {
                            MessageBox.Show(
                                "Weight cannot be negative.",
                                "Invalid Weight",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }

                        estimatedWeight = parsedWeight;
                    }
                    else
                    {
                        estimatedSize = weightSize;
                    }
                }

                PendingLoad newLoad = new PendingLoad
                {
                    ProductID = productID,
                    ProductName = actualProductName,
                    Quantity = quantity,
                    EstimatedWeightKg = estimatedWeight,
                    EstimatedSize = estimatedSize
                };

                pendingLoads.Add(newLoad);

                dgvAddedLoads.Rows.Add(
                    actualProductName,
                    quantity,
                    weightSize,
                    "Remove");

                txtCustomerNumber.Clear();
                txtQuantity.Clear();
                txtEstimatedWeightSize.Clear();

                MessageBox.Show(
                    "Load added successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                txtCustomerNumber.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to add load.\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // REMOVE LOAD FROM GRID
        // ==========================================

        private void dgvAddedLoads_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (e.ColumnIndex == 3 &&
                e.RowIndex < pendingLoads.Count)
            {
                pendingLoads.RemoveAt(e.RowIndex);

                dgvAddedLoads.Rows.RemoveAt(e.RowIndex);

                MessageBox.Show(
                    "Load removed successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        // ==========================================
        // SUBMIT TRANSPORT REQUEST
        // ==========================================

        private void btnSubmitRequest_Click(
            object sender, EventArgs e)
        {
            if (cmbCustomerNumber.SelectedValue == null)
            {
                MessageBox.Show(
                    "Please select a customer.",
                    "Required Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPickupLocation.Text))
            {
                MessageBox.Show(
                    "Please enter the Pickup Location.",
                    "Required Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPickupLocation.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDestinationLocation.Text))
            {
                MessageBox.Show(
                    "Please enter the Destination Location.",
                    "Required Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtDestinationLocation.Focus();
                return;
            }

            if (dtpRequestedDate.Value.Date < DateTime.Today)
            {
                MessageBox.Show(
                    "Please select today or a future transport date.",
                    "Invalid Date",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (pendingLoads.Count == 0)
            {
                MessageBox.Show(
                    "Please add at least one load before submitting.",
                    "No Loads Added",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int selectedCustomerID =
                Convert.ToInt32(cmbCustomerNumber.SelectedValue);

            string pickup = txtPickupLocation.Text.Trim();
            string destination = txtDestinationLocation.Text.Trim();

            string preferredTime =
                cmbPreferredTime.SelectedItem == null
                ? ""
                : cmbPreferredTime.SelectedItem.ToString();

            string specialInstructions =
                txtSpecialInstructions.Text.Trim();

            if (string.IsNullOrWhiteSpace(preferredTime))
            {
                MessageBox.Show(
                    "Please select a preferred transport time.",
                    "Required Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (specialInstructions.Length > 1000)
            {
                MessageBox.Show(
                    "Special Instructions must not exceed 1000 characters.",
                    "Information Too Long",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Extract the starting time from the selected time range.
            DateTime parsedPreferredTime;

            string startTime =
                preferredTime.Split('-')[0].Trim();

            if (!DateTime.TryParse(
                startTime,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out parsedPreferredTime))
            {
                MessageBox.Show(
                    "Invalid preferred transport time.",
                    "Time Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

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
                            // Generate Job Number

                            string jobNumberQuery = @"
                                SELECT ISNULL(
                                    MAX(TRY_CONVERT(INT, SUBSTRING(JobNo, 3, 20))),
                                    0
                                ) + 1
                                FROM dbo.TransportJobs WITH (UPDLOCK, HOLDLOCK)
                                WHERE JobNo LIKE 'J-%'";

                            int nextJobNumber;

                            using (SqlCommand cmd =
                                new SqlCommand(
                                    jobNumberQuery,
                                    con,
                                    transaction))
                            {
                                nextJobNumber =
                                    Convert.ToInt32(cmd.ExecuteScalar());
                            }

                            string jobNumber =
                                "J-" + nextJobNumber.ToString("D4");

                            // INSERT TRANSPORT JOB
                            // Correct database column: PreferredTime

                            string insertJobQuery = @"
                                INSERT INTO dbo.TransportJobs
                                (
                                    JobNo,
                                    CustomerID,
                                    RequestDate,
                                    RequestedTransportDate,
                                    PreferredTime,
                                    PickupLocation,
                                    DestinationLocation,
                                    SpecialInstructions,
                                    Status
                                )
                                VALUES
                                (
                                    @JobNo,
                                    @CustomerID,
                                    GETDATE(),
                                    @RequestedTransportDate,
                                    @PreferredTime,
                                    @PickupLocation,
                                    @DestinationLocation,
                                    @SpecialInstructions,
                                    'Pending'
                                );

                                SELECT CAST(SCOPE_IDENTITY() AS INT);";

                            int jobID;

                            using (SqlCommand cmd =
                                new SqlCommand(
                                    insertJobQuery,
                                    con,
                                    transaction))
                            {
                                cmd.Parameters.Add(
                                    "@JobNo",
                                    SqlDbType.VarChar,
                                    20).Value = jobNumber;

                                cmd.Parameters.Add(
                                    "@CustomerID",
                                    SqlDbType.Int).Value =
                                    selectedCustomerID;

                                cmd.Parameters.Add(
                                    "@RequestedTransportDate",
                                    SqlDbType.Date).Value =
                                    dtpRequestedDate.Value.Date;

                                // SQL Server time data type
                                cmd.Parameters.Add(
                                    "@PreferredTime",
                                    SqlDbType.Time).Value =
                                    parsedPreferredTime.TimeOfDay;

                                cmd.Parameters.Add(
                                    "@PickupLocation",
                                    SqlDbType.NVarChar,
                                    250).Value = pickup;

                                cmd.Parameters.Add(
                                    "@DestinationLocation",
                                    SqlDbType.NVarChar,
                                    250).Value = destination;

                                cmd.Parameters.Add(
                                    "@SpecialInstructions",
                                    SqlDbType.NVarChar,
                                    1000).Value =
                                    string.IsNullOrWhiteSpace(specialInstructions)
                                    ? (object)DBNull.Value
                                    : specialInstructions;

                                jobID =
                                    Convert.ToInt32(cmd.ExecuteScalar());
                            }

                            // Generate Load Number

                            string loadNumberQuery = @"
                                SELECT ISNULL(
                                    MAX(TRY_CONVERT(INT, SUBSTRING(LoadNo, 3, 20))),
                                    0
                                ) + 1
                                FROM dbo.Loads WITH (UPDLOCK, HOLDLOCK)
                                WHERE LoadNo LIKE 'L-%'";

                            int nextLoadNumber;

                            using (SqlCommand cmd =
                                new SqlCommand(
                                    loadNumberQuery,
                                    con,
                                    transaction))
                            {
                                nextLoadNumber =
                                    Convert.ToInt32(cmd.ExecuteScalar());
                            }

                            // INSERT LOAD DETAILS

                            string insertLoadQuery = @"
                                INSERT INTO dbo.Loads
                                (
                                    LoadNo,
                                    JobID,
                                    ProductID,
                                    LoadName,
                                    Quantity,
                                    EstimatedWeightKg,
                                    EstimatedSize,
                                    Remarks
                                )
                                VALUES
                                (
                                    @LoadNo,
                                    @JobID,
                                    @ProductID,
                                    @LoadName,
                                    @Quantity,
                                    @EstimatedWeightKg,
                                    @EstimatedSize,
                                    @Remarks
                                )";

                            foreach (PendingLoad load in pendingLoads)
                            {
                                string loadNumber =
                                    "L-" + nextLoadNumber.ToString("D4");

                                using (SqlCommand cmd =
                                    new SqlCommand(
                                        insertLoadQuery,
                                        con,
                                        transaction))
                                {
                                    cmd.Parameters.Add(
                                        "@LoadNo",
                                        SqlDbType.VarChar,
                                        20).Value = loadNumber;

                                    cmd.Parameters.Add(
                                        "@JobID",
                                        SqlDbType.Int).Value = jobID;

                                    cmd.Parameters.Add(
                                        "@ProductID",
                                        SqlDbType.VarChar,
                                        20).Value = load.ProductID;

                                    cmd.Parameters.Add(
                                        "@LoadName",
                                        SqlDbType.NVarChar,
                                        100).Value = load.ProductName;

                                    cmd.Parameters.Add(
                                        "@Quantity",
                                        SqlDbType.Int).Value =
                                        load.Quantity;

                                    SqlParameter weightParameter =
                                        cmd.Parameters.Add(
                                            "@EstimatedWeightKg",
                                            SqlDbType.Decimal);

                                    weightParameter.Precision = 18;
                                    weightParameter.Scale = 2;

                                    weightParameter.Value =
                                        load.EstimatedWeightKg.HasValue
                                        ? (object)load.EstimatedWeightKg.Value
                                        : DBNull.Value;

                                    cmd.Parameters.Add(
                                        "@EstimatedSize",
                                        SqlDbType.NVarChar,
                                        100).Value =
                                        string.IsNullOrWhiteSpace(load.EstimatedSize)
                                        ? (object)DBNull.Value
                                        : load.EstimatedSize;

                                    cmd.Parameters.Add(
                                        "@Remarks",
                                        SqlDbType.NVarChar,
                                        500).Value = DBNull.Value;

                                    cmd.ExecuteNonQuery();
                                }

                                nextLoadNumber++;
                            }

                            // SAVE TRANSACTION

                            transaction.Commit();

                            int totalLoads = pendingLoads.Count;

                            MessageBox.Show(
                                "Transport request submitted successfully!\n\n" +
                                "Job Number: " + jobNumber +
                                "\nTotal Loads: " + totalLoads +
                                "\nStatus: Pending",
                                "Request Submitted",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            ClearRequestFields();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to submit transport request.\n\n" +
                    ex.Message,
                    "Submission Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // CLEAR BUTTON
        // ==========================================

        private void btnClearRequest_Click(
            object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to clear all entered information?",
                "Clear Request",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ClearRequestFields();

                MessageBox.Show(
                    "All entered information has been cleared.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void ClearRequestFields()
        {
            txtPickupLocation.Clear();
            txtDestinationLocation.Clear();
            txtSpecialInstructions.Clear();

            txtCustomerNumber.Clear();
            txtQuantity.Clear();
            txtEstimatedWeightSize.Clear();

            pendingLoads.Clear();
            dgvAddedLoads.Rows.Clear();

            dtpRequestedDate.Value = DateTime.Today;

            if (cmbPreferredTime.Items.Count > 0)
                cmbPreferredTime.SelectedIndex = 0;

            if (cmbCustomerNumber.Items.Count > 0)
            {
                if (customerID > 0)
                    cmbCustomerNumber.SelectedValue = customerID;
                else
                    cmbCustomerNumber.SelectedIndex = 0;
            }

            GenerateJobNumber();
        }

        // ==========================================
        // NAVIGATION HELPER
        // ==========================================

        private void NavigateToForm(string[] formNames)
        {
            try
            {
                Assembly assembly =
                    Assembly.GetExecutingAssembly();

                Type targetType = assembly.GetTypes()
                    .FirstOrDefault(t => formNames.Contains(t.Name));

                if (targetType == null)
                {
                    MessageBox.Show(
                        "The selected page could not be found.\n\n" +
                        "Expected page: " +
                        string.Join(" / ", formNames),
                        "Page Not Found",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                Form targetForm = null;

                ConstructorInfo customerConstructor =
                    targetType.GetConstructor(
                        new Type[] { typeof(int) });

                if (customerConstructor != null)
                {
                    targetForm = (Form)customerConstructor.Invoke(
                        new object[] { customerID });
                }
                else
                {
                    ConstructorInfo defaultConstructor =
                        targetType.GetConstructor(Type.EmptyTypes);

                    if (defaultConstructor != null)
                    {
                        targetForm = (Form)defaultConstructor.Invoke(null);
                    }
                }

                if (targetForm == null)
                {
                    MessageBox.Show(
                        "Unable to open the selected page.",
                        "Navigation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                PropertyInfo customerProperty =
                    targetType.GetProperty("CustomerID") ??
                    targetType.GetProperty("CurrentCustomerID");

                if (customerProperty != null &&
                    customerProperty.CanWrite &&
                    customerProperty.PropertyType == typeof(int))
                {
                    customerProperty.SetValue(
                        targetForm, customerID);
                }

                targetForm.StartPosition =
                    FormStartPosition.CenterScreen;

                targetForm.FormClosed += (s, args) =>
                {
                    if (!IsDisposed)
                        Show();
                };

                Hide();
                targetForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to open the selected page.\n\n" +
                    ex.Message,
                    "Navigation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // DASHBOARD
        // ==========================================

        private void btnDashboard_Click(
            object sender, EventArgs e)
        {
            NavigateToForm(new string[]
            {
                "FrmCustomerDashboard",
                "CustomerDashboardForm"
            });
        }

        // ==========================================
        // CREATE REQUEST
        // ==========================================

        private void btnCreateRequest_Click(
            object sender, EventArgs e)
        {
            MessageBox.Show(
                "You are already on the Create Transport Request page.",
                "Create Request",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // ==========================================
        // MY JOBS
        // ==========================================

        private void btnMyJobs_Click(
            object sender, EventArgs e)
        {
            NavigateToForm(new string[]
            {
                "FrmMyTransportJobs"
            });
        }

        // ==========================================
        // MY REQUESTS
        // ==========================================

        private void btnMyRequests_Click(
            object sender, EventArgs e)
        {
            NavigateToForm(new string[]
            {
                "FrmMyRequests",
                "FrmCustomerRequests"
            });
        }

        // ==========================================
        // MY PAYMENTS
        // ==========================================

        private void btnMyPayments_Click(
            object sender, EventArgs e)
        {
            NavigateToForm(new string[]
            {
                "FrmMyPayments",
                "FrmCustomerPayments"
            });
        }

        // ==========================================
        // PROFILE
        // ==========================================

        private void btnProfile_Click(
            object sender, EventArgs e)
        {
            NavigateToForm(new string[]
            {
                "FrmCustomerProfile",
                "FrmProfile"
            });
        }

        // ==========================================
        // LOGOUT
        // ==========================================

        private void btnLogout_Click(
            object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    Form loginForm = null;

                    foreach (Form form in Application.OpenForms)
                    {
                        if (form != this &&
                            (form.GetType().Name == "LoginForm" ||
                             form.GetType().Name == "FrmLogin"))
                        {
                            loginForm = form;
                            break;
                        }
                    }

                    if (loginForm == null)
                    {
                        Assembly assembly =
                            Assembly.GetExecutingAssembly();

                        Type loginType = assembly.GetTypes()
                            .FirstOrDefault(t =>
                                t.Name == "LoginForm" ||
                                t.Name == "FrmLogin");

                        if (loginType != null)
                        {
                            loginForm = (Form)Activator.CreateInstance(
                                loginType);
                        }
                    }

                    if (loginForm == null)
                    {
                        MessageBox.Show(
                            "Login form could not be found. Please check its class name.",
                            "Logout Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    loginForm.StartPosition =
                        FormStartPosition.CenterScreen;

                    loginForm.Show();
                    loginForm.BringToFront();

                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Logout failed.\n\n" + ex.Message,
                        "Logout Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        // ==========================================
        // EXISTING DESIGNER EVENTS
        // ==========================================

        private void lblBetterTomorrow_Click(
            object sender, EventArgs e)
        {
        }

        private void pnlMain_Paint(
            object sender, PaintEventArgs e)
        {
        }
    }
}
