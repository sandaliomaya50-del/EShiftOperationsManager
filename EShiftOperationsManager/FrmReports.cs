

using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace EShiftOperationsManager
{
    public partial class FrmReports : Form
    {
        private readonly string connectionString =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=EShiftOperationsDB;Integrated Security=True;TrustServerCertificate=True;";

        private DataTable reportTable = new DataTable();
        private DataTable generatedReports = new DataTable();

        private PrintDocument printDocument = new PrintDocument();
        private int printRowIndex = 0;

        public FrmReports()
        {
            InitializeComponent();

            btnGenerateReport.Click -= btnGenerateReport_Click;
            btnGenerateReport.Click += btnGenerateReport_Click;

            btnPrintReport.Click -= btnPrintReport_Click;
            btnPrintReport.Click += btnPrintReport_Click;

            btnExportReport.Click -= btnExportReport_Click;
            btnExportReport.Click += btnExportReport_Click;

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

            Load -= FrmReports_Load;
            Load += FrmReports_Load;

            printDocument.PrintPage += printDocument_PrintPage;

            printDocument.BeginPrint += (s, e) =>
            {
                printRowIndex = 0;
            };
        }

        // ==========================================
        // FORM LOAD
        // ==========================================

        private void FrmReports_Load(object sender, EventArgs e)
        {
            try
            {
                cmbReportType.Items.Clear();

                cmbReportType.Items.Add("Customer Report");
                cmbReportType.Items.Add("Transport Job Report");
                cmbReportType.Items.Add("Pending Jobs Report");
                cmbReportType.Items.Add("Accepted Jobs Report");
                cmbReportType.Items.Add("Declined Jobs Report");
                cmbReportType.Items.Add("Completed Transport Report");

                cmbReportType.SelectedIndex = 0;

                cmbReportStatus.Items.Clear();

                cmbReportStatus.Items.Add("All");
                cmbReportStatus.Items.Add("Pending");
                cmbReportStatus.Items.Add("Accepted");
                cmbReportStatus.Items.Add("Declined");
                cmbReportStatus.Items.Add("Completed");

                cmbReportStatus.SelectedIndex = 0;

                dtpStartDate.Value = DateTime.Today.AddMonths(-1);
                dtpEndDate.Value = DateTime.Today;

                InitializeGeneratedReportsTable();

                LoadSummaryCards();
                LoadJobsChart();

                GenerateReport(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load Reports page.\n\n" + ex.Message,
                    "Reports Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // GENERATED REPORTS TABLE
        // ==========================================

        private void InitializeGeneratedReportsTable()
        {
            generatedReports = new DataTable();

            generatedReports.Columns.Add("ReportID", typeof(int));
            generatedReports.Columns.Add("ReportType", typeof(string));
            generatedReports.Columns.Add("ReportPeriod", typeof(string));
            generatedReports.Columns.Add("TotalRecords", typeof(int));
            generatedReports.Columns.Add("GeneratedBy", typeof(string));
            generatedReports.Columns.Add("GeneratedDate", typeof(DateTime));

            dgvGeneratedReports.AutoGenerateColumns = false;

            colReportID.DataPropertyName = "ReportID";
            colReportType.DataPropertyName = "ReportType";
            colReportPeriod.DataPropertyName = "ReportPeriod";
            colTotalRecords.DataPropertyName = "TotalRecords";
            colGeneratedBy.DataPropertyName = "GeneratedBy";
            colGeneratedDate.DataPropertyName = "GeneratedDate";

            dgvGeneratedReports.DataSource = generatedReports;
        }

        // ==========================================
        // SUMMARY CARDS
        // ==========================================

        private void LoadSummaryCards()
        {
            using (SqlConnection con =
                new SqlConnection(connectionString))
            {
                con.Open();

                string query = @"
SELECT
    (SELECT COUNT(*)
     FROM dbo.Customers) AS TotalCustomers,

    (SELECT COUNT(*)
     FROM dbo.TransportJobs) AS TotalJobs,

    (SELECT COUNT(*)
     FROM dbo.TransportJobs
     WHERE Status = 'Pending') AS PendingRequests,

    (SELECT COUNT(*)
     FROM dbo.TransportJobs
     WHERE Status = 'Completed') AS CompletedJobs;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lblTotalCustomers.Text =
                            reader["TotalCustomers"].ToString();

                        lblTotalJobs.Text =
                            reader["TotalJobs"].ToString();

                        lblPendingRequests.Text =
                            reader["PendingRequests"].ToString();

                        lblCompletedJobs.Text =
                            reader["CompletedJobs"].ToString();
                    }
                }
            }
        }

        // ==========================================
        // JOBS OVERVIEW CHART
        // ==========================================

        private void LoadJobsChart()
        {
            chartJobsOverview.Series.Clear();
            chartJobsOverview.ChartAreas.Clear();
            chartJobsOverview.Legends.Clear();

            ChartArea area = new ChartArea("JobsArea");

            area.AxisX.Interval = 1;
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.LineColor = Color.LightGray;

            chartJobsOverview.ChartAreas.Add(area);

            Series series = new Series("Transport Jobs");

            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;
            series.ChartArea = "JobsArea";

            chartJobsOverview.Series.Add(series);

            using (SqlConnection con =
                new SqlConnection(connectionString))
            {
                con.Open();

                string query = @"
SELECT Status, COUNT(*) AS Total
FROM dbo.TransportJobs
GROUP BY Status
ORDER BY Status;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string status =
                            reader["Status"].ToString();

                        int total =
                            Convert.ToInt32(reader["Total"]);

                        series.Points.AddXY(status, total);
                    }
                }
            }

            chartJobsOverview.Titles.Clear();

            chartJobsOverview.Titles.Add(
                "Transport Jobs Overview");
        }

        // ==========================================
        // GENERATE REPORT
        // ==========================================

        private void btnGenerateReport_Click(
            object sender, EventArgs e)
        {
            GenerateReport(true);
        }

        private void GenerateReport(
            bool showSuccessMessage = true)
        {
            try
            {
                if (dtpStartDate.Value.Date >
                    dtpEndDate.Value.Date)
                {
                    MessageBox.Show(
                        "Start Date cannot be later than End Date.",
                        "Invalid Date Range",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                string reportType = cmbReportType.Text;
                string status = cmbReportStatus.Text;

                if (string.IsNullOrWhiteSpace(reportType))
                {
                    MessageBox.Show(
                        "Please select a Report Type.",
                        "Report Required",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                string query;

                if (reportType == "Customer Report")
                {
                    query = @"
SELECT
    CustomerID,
    FullName,
    Address,
    Telephone,
    Email
FROM dbo.Customers
ORDER BY CustomerID DESC;";
                }
                else
                {
                    query = @"
SELECT
    j.JobID,
    j.JobNo,
    c.FullName AS Customer,
    j.RequestDate,
    j.RequestedTransportDate,
    j.PickupLocation,
    j.DestinationLocation,
    j.Status
FROM dbo.TransportJobs j
LEFT JOIN dbo.Customers c
    ON j.CustomerID = c.CustomerID
WHERE j.RequestDate >= @StartDate
AND j.RequestDate < @EndDate";

                    if (reportType == "Pending Jobs Report")
                    {
                        query += " AND j.Status = 'Pending'";
                    }
                    else if (reportType == "Accepted Jobs Report")
                    {
                        query += " AND j.Status = 'Accepted'";
                    }
                    else if (reportType == "Declined Jobs Report")
                    {
                        query += " AND j.Status = 'Declined'";
                    }
                    else if (reportType == "Completed Transport Report")
                    {
                        query += " AND j.Status = 'Completed'";
                    }
                    else if (status != "All")
                    {
                        query += " AND j.Status = @Status";
                    }

                    query += " ORDER BY j.RequestDate DESC;";
                }

                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    con.Open();

                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        if (reportType != "Customer Report")
                        {
                            cmd.Parameters.AddWithValue(
                                "@StartDate",
                                dtpStartDate.Value.Date);

                            cmd.Parameters.AddWithValue(
                                "@EndDate",
                                dtpEndDate.Value.Date.AddDays(1));

                            if (reportType == "Transport Job Report"
                                && status != "All")
                            {
                                cmd.Parameters.AddWithValue(
                                    "@Status", status);
                            }
                        }

                        using (SqlDataAdapter adapter =
                            new SqlDataAdapter(cmd))
                        {
                            reportTable = new DataTable();

                            adapter.Fill(reportTable);
                        }
                    }
                }

                // Keep the Generated Reports table
                // connected to generatedReports.
                // reportTable is retained separately for
                // printing and CSV export.

                if (showSuccessMessage)
                {
                    AddGeneratedReportHistory(reportType);

                    MessageBox.Show(
                        "Report generated successfully!\n\n" +
                        "Total Records: " + reportTable.Rows.Count,
                        "Reports",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to generate report.\n\n" +
                    ex.Message,
                    "Report Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // GENERATED REPORT HISTORY
        // ==========================================

        private void AddGeneratedReportHistory(string reportType)
        {
            int nextID = generatedReports.Rows.Count + 1;

            string period = reportType == "Customer Report"
                ? "All Customers"
                : dtpStartDate.Value.ToString("dd/MM/yyyy") +
                  " - " +
                  dtpEndDate.Value.ToString("dd/MM/yyyy");

            generatedReports.Rows.Add(
                nextID,
                reportType,
                period,
                reportTable.Rows.Count,
                "Admin",
                DateTime.Now);
        }

        // ==========================================
        // FORMAT REPORT GRID
        // ==========================================

        private void FormatReportGrid()
        {
            dgvGeneratedReports.ReadOnly = true;

            dgvGeneratedReports.AllowUserToAddRows = false;
            dgvGeneratedReports.AllowUserToDeleteRows = false;

            dgvGeneratedReports.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvGeneratedReports.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvGeneratedReports.MultiSelect = false;

            dgvGeneratedReports.RowHeadersVisible = false;
        }

        // ==========================================
        // PRINT REPORT
        // ==========================================

        private void btnPrintReport_Click(
            object sender, EventArgs e)
        {
            if (reportTable == null ||
                reportTable.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Please generate a report before printing.",
                    "No Report",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                using (PrintDialog dialog = new PrintDialog())
                {
                    dialog.Document = printDocument;

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        printRowIndex = 0;

                        printDocument.Print();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to print report.\n\n" + ex.Message,
                    "Print Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // PRINT PAGE
        // ==========================================

        private void printDocument_PrintPage(
            object sender, PrintPageEventArgs e)
        {
            using (Font titleFont =
                new Font("Arial", 15, FontStyle.Bold))
            using (Font headerFont =
                new Font("Arial", 8, FontStyle.Bold))
            using (Font rowFont =
                new Font("Arial", 8))
            {
                float x = e.MarginBounds.Left;
                float y = e.MarginBounds.Top;

                float columnWidth =
                    (float)e.MarginBounds.Width /
                    Math.Max(1, reportTable.Columns.Count);

                e.Graphics.DrawString(
                    "e-Shift Transport Management System",
                    titleFont,
                    Brushes.Black,
                    x,
                    y);

                y += 35;

                e.Graphics.DrawString(
                    "Generated Report - " +
                    DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                    rowFont,
                    Brushes.Black,
                    x,
                    y);

                y += 30;

                for (int i = 0;
                    i < reportTable.Columns.Count; i++)
                {
                    e.Graphics.DrawString(
                        reportTable.Columns[i].ColumnName,
                        headerFont,
                        Brushes.Black,
                        x + i * columnWidth,
                        y);
                }

                y += 25;

                while (printRowIndex < reportTable.Rows.Count)
                {
                    if (y > e.MarginBounds.Bottom - 30)
                    {
                        e.HasMorePages = true;
                        return;
                    }

                    DataRow row =
                        reportTable.Rows[printRowIndex];

                    for (int i = 0;
                        i < reportTable.Columns.Count; i++)
                    {
                        string value =
                            row[i].ToString();

                        e.Graphics.DrawString(
                            value.Length > 20
                                ? value.Substring(0, 20)
                                : value,
                            rowFont,
                            Brushes.Black,
                            x + i * columnWidth,
                            y);
                    }

                    y += 22;
                    printRowIndex++;
                }

                e.HasMorePages = false;
            }
        }

        // ==========================================
        // EXPORT REPORT TO CSV
        // ==========================================

        private void btnExportReport_Click(
            object sender, EventArgs e)
        {
            if (reportTable == null ||
                reportTable.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Please generate a report before exporting.",
                    "No Report",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                using (SaveFileDialog dialog =
                    new SaveFileDialog())
                {
                    dialog.Filter =
                        "CSV Files (*.csv)|*.csv";

                    dialog.FileName =
                        "eShift_Report_" +
                        DateTime.Now.ToString("yyyyMMdd");

                    if (dialog.ShowDialog() != DialogResult.OK)
                        return;

                    using (StreamWriter writer =
                        new StreamWriter(
                            dialog.FileName,
                            false,
                            System.Text.Encoding.UTF8))
                    {
                        for (int i = 0;
                            i < reportTable.Columns.Count; i++)
                        {
                            string heading =
                                reportTable.Columns[i].ColumnName
                                .Replace("\"", "\"\"");

                            writer.Write("\"" + heading + "\"");

                            if (i < reportTable.Columns.Count - 1)
                                writer.Write(",");
                        }

                        writer.WriteLine();

                        foreach (DataRow row in reportTable.Rows)
                        {
                            for (int i = 0;
                                i < reportTable.Columns.Count; i++)
                            {
                                string value =
                                    row[i].ToString()
                                    .Replace("\"", "\"\"");

                                writer.Write("\"" + value + "\"");

                                if (i < reportTable.Columns.Count - 1)
                                    writer.Write(",");
                            }

                            writer.WriteLine();
                        }
                    }

                    MessageBox.Show(
                        "Report exported successfully!",
                        "Export Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to export report.\n\n" +
                    ex.Message,
                    "Export Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // SIDEBAR NAVIGATION
        // ==========================================

        private void OpenChildForm(Form child)
        {
            if (child == null || IsDisposed || Disposing)
                return;

            Hide();

            try
            {
                child.StartPosition =
                    FormStartPosition.CenterScreen;

                using (child)
                {
                    child.ShowDialog();
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
            finally
            {
                if (!IsDisposed && !Disposing)
                {
                    Show();
                    Activate();

                    LoadSummaryCards();
                    LoadJobsChart();
                }
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmCustomerManagement());
        }

        private void btnAdmins_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmAdminManagement());
        }

        private void btnJobs_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmJobManagement());
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmProductManagement());
        }

        private void btnTransportUnits_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmTransportUnitManagement());
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
            // Already on the Reports page.
        }

        // ==========================================
        // LOGOUT
        // ==========================================

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            FrmAdminDashboard dashboard =
                Application.OpenForms
                    .OfType<FrmAdminDashboard>()
                    .FirstOrDefault();

            if (dashboard != null)
            {
                // Notify the dashboard that logout was requested.
                MethodInfo logoutMethod =
                    dashboard.GetType().GetMethod(
                        "RequestLogout",
                        BindingFlags.Instance |
                        BindingFlags.Public |
                        BindingFlags.NonPublic);

                if (logoutMethod != null)
                {
                    logoutMethod.Invoke(dashboard, null);
                }

                Close();
            }
            else
            {
                FrmLogin login =
                    Application.OpenForms
                        .OfType<FrmLogin>()
                        .FirstOrDefault();

                if (login == null)
                    login = new FrmLogin();

                login.StartPosition =
                    FormStartPosition.CenterScreen;

                login.Show();
                login.BringToFront();
                login.Activate();

                Close();
            }
        }

        // ==========================================
        // EXISTING DESIGNER EVENTS
        // ==========================================

        private void lblReportsSubtitle_Click(
            object sender, EventArgs e)
        {
        }

        private void PnlDashboard_Paint(
            object sender, PaintEventArgs e)
        {
        }
    }
}

