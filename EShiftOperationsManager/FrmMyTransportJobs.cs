
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace EShiftOperationsManager
{
    public partial class FrmMyTransportJobs : Form
    {
        private readonly string connectionString =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=EShiftOperationsDB;Integrated Security=True;TrustServerCertificate=True;";

        private int loggedInCustomerID = 0;
        private int selectedJobID = 0;
        private bool isInitializing = false;

        // ==========================================
        // CONSTRUCTORS
        // ==========================================

        public FrmMyTransportJobs()
        {
            InitializeComponent();
            ConnectButtons();
        }

        public FrmMyTransportJobs(int customerID)
        {
            InitializeComponent();
            loggedInCustomerID = customerID;
            ConnectButtons();
        }

        // ==========================================
        // CONNECT BUTTONS AND EVENTS
        // ==========================================

        private void ConnectButtons()
        {
            btnRefreshJobs.Click -= btnRefreshJobs_Click;
            btnRefreshJobs.Click += btnRefreshJobs_Click;

            btnViewDetails.Click -= btnViewDetails_Click;
            btnViewDetails.Click += btnViewDetails_Click;

            btnCancelRequest.Click -= btnCancelRequest_Click;
            btnCancelRequest.Click += btnCancelRequest_Click;

            btnDashboard.Click -= btnDashboard_Click;
            btnDashboard.Click += btnDashboard_Click;

            btnCreateRequest.Click -= btnCreateRequest_Click;
            btnCreateRequest.Click += btnCreateRequest_Click;

            btnMyJobs.Click -= btnMyJobs_Click;
            btnMyJobs.Click += btnMyJobs_Click;

            btnProfile.Click -= btnProfile_Click;
            btnProfile.Click += btnProfile_Click;

            btnMyPayments.Click -= btnMyPayments_Click;
            btnMyPayments.Click += btnMyPayments_Click;

            btnMyRequests.Click -= btnMyRequests_Click;
            btnMyRequests.Click += btnMyRequests_Click;

            btnLogout.Click -= btnCustomerLogout_Click;
            btnLogout.Click += btnCustomerLogout_Click;

            Load -= FrmMyTransportJobs_Load;
            Load += FrmMyTransportJobs_Load;

            dgvMyTransportJobs.SelectionChanged -=
                dgvMyTransportJobs_SelectionChanged;

            dgvMyTransportJobs.SelectionChanged +=
                dgvMyTransportJobs_SelectionChanged;

            txtSearchJobNo.TextChanged -=
                txtSearchJobNo_TextChanged;

            txtSearchJobNo.TextChanged +=
                txtSearchJobNo_TextChanged;

            cmbFilterStatus.SelectedIndexChanged -=
                cmbFilterStatus_SelectedIndexChanged;

            cmbFilterStatus.SelectedIndexChanged +=
                cmbFilterStatus_SelectedIndexChanged;
        }

        // ==========================================
        // FORM LOAD
        // ==========================================

        private void FrmMyTransportJobs_Load(object sender, EventArgs e)
        {
            isInitializing = true;

            cmbFilterStatus.Items.Clear();

            cmbFilterStatus.Items.Add("All");
            cmbFilterStatus.Items.Add("Pending");
            cmbFilterStatus.Items.Add("Accepted");
            cmbFilterStatus.Items.Add("Declined");
            cmbFilterStatus.Items.Add("Completed");
            cmbFilterStatus.Items.Add("Cancelled");

            cmbFilterStatus.SelectedIndex = 0;

            isInitializing = false;

            ConfigureJobsGrid();

            if (loggedInCustomerID <= 0)
            {
                MessageBox.Show(
                    "Customer information was not received.\n\n" +
                    "Please log in again to view your transport jobs.",
                    "Customer Information Missing",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            LoadMyTransportJobs();
        }

        // ==========================================
        // CHECK OPTIONAL DATABASE COLUMN
        // ==========================================

        private bool ColumnExists(string columnName)
        {
            using (SqlConnection con =
                new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(
                    "SELECT CASE WHEN COL_LENGTH('dbo.TransportJobs', @ColumnName) " +
                    "IS NULL THEN 0 ELSE 1 END;", con))
                {
                    cmd.Parameters.AddWithValue(
                        "@ColumnName", "dbo.TransportJobs." + columnName);

                    return Convert.ToInt32(
                        cmd.ExecuteScalar()) == 1;
                }
            }
        }

        // ==========================================
        // CONFIGURE DATA GRID VIEW
        // ==========================================

        private void ConfigureJobsGrid()
        {
            dgvMyTransportJobs.DataSource = null;
            dgvMyTransportJobs.AutoGenerateColumns = false;

            dgvMyTransportJobs.AllowUserToAddRows = false;
            dgvMyTransportJobs.AllowUserToDeleteRows = false;
            dgvMyTransportJobs.ReadOnly = true;

            dgvMyTransportJobs.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvMyTransportJobs.MultiSelect = false;
            dgvMyTransportJobs.RowHeadersVisible = false;

            dgvMyTransportJobs.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvMyTransportJobs.Columns.Clear();

            dgvMyTransportJobs.Columns.Add("colJobNo", "Job No");
            dgvMyTransportJobs.Columns.Add("colPickup", "Pickup");
            dgvMyTransportJobs.Columns.Add("colDestination", "Destination");
            dgvMyTransportJobs.Columns.Add("colRequestDate", "Request Date");
            dgvMyTransportJobs.Columns.Add("colTransportDate", "Transport Date");
            dgvMyTransportJobs.Columns.Add("colStatus", "Status");
            dgvMyTransportJobs.Columns.Add("colRemarks", "Remarks");

            dgvMyTransportJobs.Columns["colJobNo"].FillWeight = 65;
            dgvMyTransportJobs.Columns["colPickup"].FillWeight = 110;
            dgvMyTransportJobs.Columns["colDestination"].FillWeight = 110;
            dgvMyTransportJobs.Columns["colRequestDate"].FillWeight = 85;
            dgvMyTransportJobs.Columns["colTransportDate"].FillWeight = 85;
            dgvMyTransportJobs.Columns["colStatus"].FillWeight = 65;
            dgvMyTransportJobs.Columns["colRemarks"].FillWeight = 100;
        }

        // ==========================================
        // LOAD CUSTOMER TRANSPORT JOBS
        // ==========================================

        private void LoadMyTransportJobs()
        {
            if (loggedInCustomerID <= 0)
                return;

            try
            {
                string remarksExpression =
                    ColumnExists("AdminRemarks")
                    ? "ISNULL(CAST(j.AdminRemarks AS NVARCHAR(500)), '')"
                    : "CAST('No remarks' AS NVARCHAR(500))";

                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    string query = @"
SELECT
    j.JobID,
    j.JobNo,
    c.CustomerNo,
    j.CustomerID,
    j.PickupLocation,
    j.DestinationLocation,
    j.RequestDate,
    j.RequestedTransportDate,
    j.Status,
    " + remarksExpression + @" AS AdminRemarks,

    (
        SELECT COUNT(*)
        FROM dbo.Loads l
        WHERE l.JobID = j.JobID
    ) AS TotalLoads

FROM dbo.TransportJobs j

INNER JOIN dbo.Customers c
    ON j.CustomerID = c.CustomerID

WHERE j.CustomerID = @CustomerID

AND
(
    @JobNo = ''
    OR j.JobNo LIKE '%' + @JobNo + '%'
)

AND
(
    @Status = 'All'
    OR j.Status = @Status
)

ORDER BY j.RequestDate DESC, j.JobID DESC;";

                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        cmd.Parameters.Add(
                            "@CustomerID", SqlDbType.Int).Value =
                            loggedInCustomerID;

                        cmd.Parameters.Add(
                            "@JobNo", SqlDbType.NVarChar, 50).Value =
                            txtSearchJobNo.Text.Trim();

                        cmd.Parameters.Add(
                            "@Status", SqlDbType.NVarChar, 30).Value =
                            cmbFilterStatus.SelectedItem == null
                            ? "All"
                            : cmbFilterStatus.SelectedItem.ToString();

                        using (SqlDataAdapter adapter =
                            new SqlDataAdapter(cmd))
                        {
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            dgvMyTransportJobs.Rows.Clear();

                            foreach (DataRow dr in table.Rows)
                            {
                                int index =
                                    dgvMyTransportJobs.Rows.Add(
                                        dr["JobNo"].ToString(),
                                        dr["PickupLocation"].ToString(),
                                        dr["DestinationLocation"].ToString(),
                                        Convert.ToDateTime(
                                            dr["RequestDate"]).ToString("yyyy-MM-dd"),
                                        Convert.ToDateTime(
                                            dr["RequestedTransportDate"]).ToString("yyyy-MM-dd"),
                                        dr["Status"].ToString(),
                                        dr["AdminRemarks"].ToString()
                                    );

                                dgvMyTransportJobs.Rows[index].Tag = dr;
                            }

                            ClearSelectedJobDetails();

                            if (dgvMyTransportJobs.Rows.Count > 0)
                            {
                                dgvMyTransportJobs.Rows[0].Selected = true;

                                dgvMyTransportJobs.CurrentCell =
                                    dgvMyTransportJobs.Rows[0].Cells[0];

                                dgvMyTransportJobs_SelectionChanged(
                                    dgvMyTransportJobs, EventArgs.Empty);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load your transport jobs.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // SELECTED JOB DETAILS
        // ==========================================

        private void dgvMyTransportJobs_SelectionChanged(
            object sender, EventArgs e)
        {
            if (dgvMyTransportJobs.SelectedRows.Count == 0)
            {
                ClearSelectedJobDetails();
                return;
            }

            DataGridViewRow row =
                dgvMyTransportJobs.SelectedRows[0];

            DataRow dr = row.Tag as DataRow;

            if (dr == null)
                return;

            selectedJobID = Convert.ToInt32(dr["JobID"]);

            lblValueJobNo.Text = dr["JobNo"].ToString();
            lblValueCustomerNo.Text = dr["CustomerNo"].ToString();
            lblValuePickup.Text = dr["PickupLocation"].ToString();
            lblValueDestination.Text = dr["DestinationLocation"].ToString();

            lblValueRequestDate.Text =
                Convert.ToDateTime(dr["RequestDate"]).ToString("yyyy-MM-dd");

            lblValueTransportDate.Text =
                Convert.ToDateTime(dr["RequestedTransportDate"]).ToString("yyyy-MM-dd");

            lblValueStatus.Text = dr["Status"].ToString();
            lblValueLoads.Text = dr["TotalLoads"].ToString();

            lblValueAssignedUnit.Text = "Check assignment details";

            lblValueAdminRemarks.Text =
                string.IsNullOrWhiteSpace(dr["AdminRemarks"].ToString())
                ? "No remarks"
                : dr["AdminRemarks"].ToString();

            btnCancelRequest.Enabled =
                lblValueStatus.Text.Equals(
                    "Pending", StringComparison.OrdinalIgnoreCase);
        }

        // ==========================================
        // CLEAR JOB DETAILS
        // ==========================================

        private void ClearSelectedJobDetails()
        {
            selectedJobID = 0;

            lblValueJobNo.Text = "-";
            lblValueCustomerNo.Text = "-";
            lblValuePickup.Text = "-";
            lblValueDestination.Text = "-";
            lblValueRequestDate.Text = "-";
            lblValueTransportDate.Text = "-";
            lblValueStatus.Text = "-";
            lblValueLoads.Text = "-";
            lblValueAssignedUnit.Text = "-";
            lblValueAdminRemarks.Text = "-";

            btnCancelRequest.Enabled = false;
        }

        // ==========================================
        // SEARCH JOB NUMBER
        // ==========================================

        private void txtSearchJobNo_TextChanged(
            object sender, EventArgs e)
        {
            LoadMyTransportJobs();
        }

        // ==========================================
        // FILTER BY STATUS
        // ==========================================

        private void cmbFilterStatus_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            if (isInitializing)
                return;

            LoadMyTransportJobs();
        }

        // ==========================================
        // REFRESH JOBS
        // ==========================================

        private void btnRefreshJobs_Click(
            object sender, EventArgs e)
        {
            txtSearchJobNo.Clear();
            cmbFilterStatus.SelectedIndex = 0;

            LoadMyTransportJobs();

            MessageBox.Show(
                "Your transport jobs have been refreshed successfully.",
                "Refresh Successful",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // ==========================================
        // VIEW JOB DETAILS
        // ==========================================

        private void btnViewDetails_Click(
            object sender, EventArgs e)
        {
            if (selectedJobID == 0)
            {
                MessageBox.Show(
                    "Please select a transport job first.",
                    "Select Job",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            MessageBox.Show(
                "Job Number: " + lblValueJobNo.Text +
                "\nCustomer Number: " + lblValueCustomerNo.Text +
                "\nPickup: " + lblValuePickup.Text +
                "\nDestination: " + lblValueDestination.Text +
                "\nRequest Date: " + lblValueRequestDate.Text +
                "\nTransport Date: " + lblValueTransportDate.Text +
                "\nStatus: " + lblValueStatus.Text +
                "\nTotal Loads: " + lblValueLoads.Text +
                "\nAssigned Unit: " + lblValueAssignedUnit.Text +
                "\nAdmin Remarks: " + lblValueAdminRemarks.Text,
                "Transport Job Details",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // ==========================================
        // CANCEL TRANSPORT REQUEST
        // ==========================================

        private void btnCancelRequest_Click(
            object sender, EventArgs e)
        {
            if (selectedJobID == 0)
            {
                MessageBox.Show(
                    "Please select a transport job first.",
                    "Select Job",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (!lblValueStatus.Text.Equals(
                "Pending", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(
                    "Only pending transport requests can be cancelled.",
                    "Cannot Cancel",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to cancel this transport request?",
                "Confirm Cancellation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    con.Open();

                    string query = @"
UPDATE dbo.TransportJobs
SET Status = 'Cancelled'
WHERE JobID = @JobID
AND CustomerID = @CustomerID
AND Status = 'Pending';";

                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        cmd.Parameters.Add(
                            "@JobID", SqlDbType.Int).Value = selectedJobID;

                        cmd.Parameters.Add(
                            "@CustomerID", SqlDbType.Int).Value =
                            loggedInCustomerID;

                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            MessageBox.Show(
                                "Your transport request has been cancelled successfully.",
                                "Cancellation Successful",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            LoadMyTransportJobs();
                        }
                        else
                        {
                            MessageBox.Show(
                                "The request could not be cancelled. Please refresh and try again.",
                                "Cancellation Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to cancel transport request.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // DASHBOARD BUTTON
        // ==========================================

        private void btnDashboard_Click(
            object sender, EventArgs e)
        {
            Form dashboard = Owner;

            if (dashboard == null || dashboard.IsDisposed)
            {
                dashboard = Application.OpenForms
                    .Cast<Form>()
                    .FirstOrDefault(f =>
                        f.GetType().Name == "FrmCustomerDashboard");
            }

            if (dashboard != null && !dashboard.IsDisposed)
            {
                dashboard.Show();
                dashboard.Activate();
                Close();
            }
            else
            {
                MessageBox.Show(
                    "Customer Dashboard is not currently open.",
                    "Navigation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        // ==========================================
        // CREATE REQUEST BUTTON
        // ==========================================

        private void btnCreateRequest_Click(
            object sender, EventArgs e)
        {
            OpenCustomerPage("RequestTransportForm");
        }

        // ==========================================
        // MY JOBS BUTTON
        // ==========================================

        private void btnMyJobs_Click(
            object sender, EventArgs e)
        {
            LoadMyTransportJobs();
        }

        // ==========================================
        // OPEN CUSTOMER PAGE
        // ==========================================

        private void OpenCustomerPage(string formName)
        {
            try
            {
                Type formType =
                    Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .FirstOrDefault(t =>
                        t.Name.Equals(
                            formName,
                            StringComparison.OrdinalIgnoreCase));

                if (formType == null)
                {
                    MessageBox.Show(
                        "The selected page was not found: " + formName,
                        "Page Not Found",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                Form child = null;

                ConstructorInfo customerConstructor =
                    formType.GetConstructor(new Type[] { typeof(int) });

                if (customerConstructor != null)
                {
                    child = (Form)customerConstructor.Invoke(
                        new object[] { loggedInCustomerID });
                }
                else
                {
                    child = (Form)Activator.CreateInstance(formType);
                }

                child.StartPosition = FormStartPosition.CenterScreen;

                Hide();

                using (child)
                {
                    child.ShowDialog(this);
                }

                if (!IsDisposed && !Disposing)
                {
                    Show();
                    Activate();
                    LoadMyTransportJobs();
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
        // PROFILE BUTTON
        // ==========================================

        private void btnProfile_Click(
            object sender, EventArgs e)
        {
            MessageBox.Show(
                "The Customer Profile page will be connected next.",
                "My Profile",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // ==========================================
        // PAYMENTS BUTTON
        // ==========================================

        private void btnMyPayments_Click(
            object sender, EventArgs e)
        {
            MessageBox.Show(
                "The My Payments page will be connected next.",
                "My Payments",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // ==========================================
        // MY REQUESTS BUTTON
        // ==========================================

        private void btnMyRequests_Click(
            object sender, EventArgs e)
        {
            MessageBox.Show(
                "Your transport requests can be viewed in My Transport Jobs.",
                "My Requests",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LoadMyTransportJobs();
        }

        // ==========================================
        // CUSTOMER LOGOUT
        // ==========================================

        private void btnCustomerLogout_Click(
            object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                Form dashboard = Owner;

                Form login = Application.OpenForms
                    .Cast<Form>()
                    .FirstOrDefault(f =>
                        f.GetType().Name == "FrmLogin");

                if (dashboard == null || dashboard.IsDisposed)
                {
                    dashboard = Application.OpenForms
                        .Cast<Form>()
                        .FirstOrDefault(f =>
                            f.GetType().Name == "FrmCustomerDashboard");
                }

                Close();

                if (dashboard != null && !dashboard.IsDisposed)
                {
                    dashboard.Close();
                }

                if (login != null && !login.IsDisposed)
                {
                    login.Show();
                    login.Activate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to logout.\n\n" + ex.Message,
                    "Logout Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // MAIN PANEL PAINT EVENT
        // ==========================================

        private void pnlMain_Paint(
            object sender, PaintEventArgs e)
        {
            // Existing Designer event.
            // No additional painting required.
        }

        // ==========================================
        // SELECTED JOB DETAILS PANEL
        // ==========================================

        private void pnlSelectedJobDetails_Paint(
            object sender, PaintEventArgs e)
        {
            // Existing Designer event.
        }

        private void pnlSelectedJobDetails_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
