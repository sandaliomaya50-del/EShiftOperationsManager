
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace EShiftOperationsManager
{
    public partial class FrmCustomerDashboard : Form
    {
        // Database connection
        private readonly string connectionString =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=EShiftOperationsDB;Integrated Security=True;TrustServerCertificate=True;";

        private int loggedInCustomerID;

        // Default constructor for Designer
        public FrmCustomerDashboard() : this(0)
        {
        }

        // Constructor for logged-in customer
        public FrmCustomerDashboard(int customerID)
        {
            InitializeComponent();

            loggedInCustomerID = customerID;

            // Sidebar buttons
            btnDashboard.Click += btnDashboard_Click;
            btnCreateRequest.Click += btnCreateRequest_Click;
            btnMyJobs.Click += btnMyJobs_Click;
            btnProfile.Click += btnProfile_Click;
            btnMyPayments.Click += btnMyPayments_Click;
            btnMyRequests.Click += btnMyRequests_Click;
            btnLogout.Click += btnLogout_Click;

            // Quick action panels
            pnlCreateRequest.Click += btnCreateRequest_Click;
            pnlMyTransportJobs.Click += btnMyJobs_Click;
            pnlProfile.Click += btnProfile_Click;
            pnlCustomerLogout.Click += btnLogout_Click;

            // View all requests
            lnkViewAllRequests.Click += lnkViewAllRequests_Click;

            // Dashboard load
            this.Load += FrmCustomerDashboard_Load;
        }

        // ==========================================
        // FORM LOAD
        // ==========================================

        private void FrmCustomerDashboard_Load(object sender, EventArgs e)
        {
            lblTotalJobs.Text = "0";
            lblPendingRequests.Text = "0";
            lblApprovedJobs.Text = "0";
            lblCompletedJobs.Text = "0";

            if (loggedInCustomerID <= 0)
            {
                lblWelcomeAdmin.Text = "Welcome, Customer";
                return;
            }

            LoadCustomerDetails();
            LoadCustomerDashboard();
        }

        // ==========================================
        // LOAD CUSTOMER DETAILS
        // ==========================================

        private void LoadCustomerDetails()
        {
            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT FullName
                        FROM dbo.Customers
                        WHERE CustomerID = @CustomerID";

                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@CustomerID", loggedInCustomerID);

                        con.Open();

                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            lblWelcomeAdmin.Text =
                                "Welcome, " + result.ToString();
                        }
                        else
                        {
                            lblWelcomeAdmin.Text = "Welcome, Customer";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load customer details.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // LOAD CUSTOMER DASHBOARD
        // ==========================================

        private void LoadCustomerDashboard()
        {
            LoadCustomerSummary();
            LoadRecentTransportJobs();
        }

        // ==========================================
        // LOAD SUMMARY CARDS
        // ==========================================

        private void LoadCustomerSummary()
        {
            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT
                            COUNT(*) AS TotalJobs,

                            COALESCE(SUM(
                                CASE
                                    WHEN Status = 'Pending'
                                    THEN 1 ELSE 0
                                END), 0) AS PendingRequests,

                            COALESCE(SUM(
                                CASE
                                    WHEN Status IN ('Accepted', 'Approved')
                                    THEN 1 ELSE 0
                                END), 0) AS ApprovedJobs,

                            COALESCE(SUM(
                                CASE
                                    WHEN Status = 'Completed'
                                    THEN 1 ELSE 0
                                END), 0) AS CompletedJobs

                        FROM dbo.TransportJobs
                        WHERE CustomerID = @CustomerID";

                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@CustomerID", loggedInCustomerID);

                        con.Open();

                        using (SqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblTotalJobs.Text =
                                    reader["TotalJobs"].ToString();

                                lblPendingRequests.Text =
                                    reader["PendingRequests"].ToString();

                                lblApprovedJobs.Text =
                                    reader["ApprovedJobs"].ToString();

                                lblCompletedJobs.Text =
                                    reader["CompletedJobs"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load customer summary.\n\n" + ex.Message,
                    "Dashboard Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // LOAD RECENT TRANSPORT JOBS
        // ==========================================

        private void LoadRecentTransportJobs()
        {
            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT TOP 10
                            JobNo,
                            PickupLocation,
                            DestinationLocation,
                            RequestDate,
                            Status
                        FROM dbo.TransportJobs
                        WHERE CustomerID = @CustomerID
                        ORDER BY RequestDate DESC, JobID DESC";

                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@CustomerID", loggedInCustomerID);

                        con.Open();

                        using (SqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            dgvRecentTransportJobs.Rows.Clear();

                            while (reader.Read())
                            {
                                string jobNo =
                                    Convert.ToString(reader["JobNo"]);

                                string pickup =
                                    Convert.ToString(reader["PickupLocation"]);

                                string destination =
                                    Convert.ToString(reader["DestinationLocation"]);

                                string requestDate = "";

                                if (reader["RequestDate"] != DBNull.Value)
                                {
                                    requestDate =
                                        Convert.ToDateTime(
                                            reader["RequestDate"])
                                        .ToString("dd MMM yyyy");
                                }

                                string status =
                                    Convert.ToString(reader["Status"]);

                                dgvRecentTransportJobs.Rows.Add(
                                    jobNo,
                                    pickup,
                                    destination,
                                    requestDate,
                                    status);
                            }
                        }
                    }
                }

                FormatTransportJobsGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load recent transport jobs.\n\n" +
                    ex.Message,
                    "Dashboard Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // FORMAT TRANSPORT JOBS GRID
        // ==========================================

        private void FormatTransportJobsGrid()
        {
            dgvRecentTransportJobs.ReadOnly = true;

            dgvRecentTransportJobs.AllowUserToAddRows = false;

            dgvRecentTransportJobs.AllowUserToDeleteRows = false;

            dgvRecentTransportJobs.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvRecentTransportJobs.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvRecentTransportJobs.MultiSelect = false;

            dgvRecentTransportJobs.RowHeadersVisible = false;

            dgvRecentTransportJobs.BackgroundColor = Color.White;

            dgvRecentTransportJobs.ClearSelection();
        }

        // ==========================================
        // FIND OTHER FORMS
        // ==========================================

        private Type FindForm(string[] possibleNames)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type[] formTypes = assembly.GetTypes()
                .Where(t =>
                    t.IsClass &&
                    !t.IsAbstract &&
                    typeof(Form).IsAssignableFrom(t))
                .ToArray();

            foreach (string name in possibleNames)
            {
                Type found = formTypes.FirstOrDefault(t =>
                    t.Name.Equals(
                        name,
                        StringComparison.OrdinalIgnoreCase));

                if (found != null)
                    return found;
            }

            return null;
        }

        // ==========================================
        // OPEN CUSTOMER PAGE
        // ==========================================

        private void OpenCustomerPage(string[] possibleNames)
        {
            Type formType = FindForm(possibleNames);

            if (formType == null)
            {
                MessageBox.Show(
                    "The requested page has not been created yet.",
                    "Page Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            try
            {
                Form child = null;

                ConstructorInfo customerConstructor =
                    formType.GetConstructor(
                        new Type[] { typeof(int) });

                if (customerConstructor != null)
                {
                    child = (Form)customerConstructor.Invoke(
                        new object[] { loggedInCustomerID });
                }
                else
                {
                    ConstructorInfo defaultConstructor =
                        formType.GetConstructor(Type.EmptyTypes);

                    if (defaultConstructor != null)
                    {
                        child = (Form)defaultConstructor.Invoke(null);
                    }
                    else
                    {
                        throw new Exception(
                            "The selected form has no supported constructor.");
                    }
                }

                child.StartPosition =
                    FormStartPosition.CenterScreen;

                this.Hide();

                try
                {
                    using (child)
                    {
                        child.ShowDialog(this);
                    }
                }
                finally
                {
                    if (!this.IsDisposed && !this.Disposing)
                    {
                        this.Show();
                        this.Activate();

                        if (loggedInCustomerID > 0)
                        {
                            LoadCustomerDetails();
                            LoadCustomerDashboard();
                        }
                    }
                }
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
        // DASHBOARD BUTTON
        // ==========================================

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            LoadCustomerDashboard();
        }

        // ==========================================
        // CREATE TRANSPORT REQUEST
        // ==========================================

        private void btnCreateRequest_Click(object sender, EventArgs e)
        {
            OpenCustomerPage(new string[]
            {
                "FrmTransportRequest",
                "RequestTransportForm",
                "FrmRequestTransport",
                "FrmCreateTransportRequest",
                "CreateTransportRequestForm"
            });
        }

        // ==========================================
        // MY JOBS
        // ==========================================

        private void btnMyJobs_Click(object sender, EventArgs e)
        {
            OpenCustomerPage(new string[]
            {
                "FrmMyTransportJobs",
                "FrmMyJobs",
                "CustomerJobsForm"
            });
        }

        // ==========================================
        // CUSTOMER PROFILE
        // ==========================================

        private void btnProfile_Click(object sender, EventArgs e)
        {
            OpenCustomerPage(new string[]
            {
                "FrmCustomerProfile",
                "FrmProfile",
                "CustomerProfileForm"
            });
        }

        // ==========================================
        // MY PAYMENTS
        // ==========================================

        private void btnMyPayments_Click(object sender, EventArgs e)
        {
            OpenCustomerPage(new string[]
            {
                "FrmMyPayments",
                "FrmCustomerPayments",
                "CustomerPaymentsForm"
            });
        }

        // ==========================================
        // MY REQUESTS
        // ==========================================

        private void btnMyRequests_Click(object sender, EventArgs e)
        {
            OpenCustomerPage(new string[]
            {
                "FrmMyRequests",
                "FrmCustomerRequests",
                "FrmMyTransportJobs"
            });
        }

        // ==========================================
        // VIEW ALL REQUESTS
        // ==========================================

        private void lnkViewAllRequests_Click(
            object sender, EventArgs e)
        {
            btnMyRequests_Click(sender, EventArgs.Empty);
        }

        // ==========================================
        // CUSTOMER LOGOUT
        // ==========================================

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // ==========================================
        // DASHBOARD PANEL PAINT
        // ==========================================

        private void PnlDashboard_Paint(
            object sender, PaintEventArgs e)
        {
            // Existing Designer event.
        }
    }
}

