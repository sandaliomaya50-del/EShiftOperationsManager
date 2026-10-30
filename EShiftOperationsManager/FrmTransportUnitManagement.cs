
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EShiftOperationsManager
{
    public partial class FrmTransportUnitManagement : Form
    {
        private readonly string connectionString =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=EShiftOperationsDB;Integrated Security=True;TrustServerCertificate=True;";

        private int selectedUnitID = 0;

        public FrmTransportUnitManagement()
        {
            InitializeComponent();

            // Button events
            btnAddCustomer.Click -= btnAddCustomer_Click;
            btnAddCustomer.Click += btnAddCustomer_Click;

            btnUpdateCustomer.Click -= btnUpdateCustomer_Click;
            btnUpdateCustomer.Click += btnUpdateCustomer_Click;

            btnDeleteCustomer.Click -= btnDeleteCustomer_Click;
            btnDeleteCustomer.Click += btnDeleteCustomer_Click;

            btnResetAdmin.Click -= btnResetAdmin_Click;
            btnResetAdmin.Click += btnResetAdmin_Click;

            btnClearCustomer.Click -= btnClearCustomer_Click;
            btnClearCustomer.Click += btnClearCustomer_Click;

            // Search and grid events
            txtSearchTransportUnits.TextChanged -= txtSearchTransportUnits_TextChanged;
            txtSearchTransportUnits.TextChanged += txtSearchTransportUnits_TextChanged;

            dgvTransportUnitList.CellClick -= dgvTransportUnitList_CellClick;
            dgvTransportUnitList.CellClick += dgvTransportUnitList_CellClick;

            // Sidebar events
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

            Load -= FrmTransportUnitManagement_Load;
            Load += FrmTransportUnitManagement_Load;
        }

        // =====================================================
        // FORM LOAD
        // =====================================================

        private void FrmTransportUnitManagement_Load(
            object sender, EventArgs e)
        {
            try
            {
                LoadDrivers();
                LoadAssistants();
                LoadContainerTypes();
                LoadAvailabilityStatuses();

                LoadTransportUnits();

                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load Transport Unit Management.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =====================================================
        // LOAD DRIVERS
        // =====================================================

        private void LoadDrivers()
        {
            using (SqlConnection con =
                new SqlConnection(connectionString))
            {
                string query = @"
SELECT DriverID, FullName
FROM dbo.Drivers
ORDER BY FullName;";

                using (SqlDataAdapter adapter =
                    new SqlDataAdapter(query, con))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    DataRow emptyRow = table.NewRow();
                    emptyRow["DriverID"] = DBNull.Value;
                    emptyRow["FullName"] = "-- Select Driver --";

                    table.Rows.InsertAt(emptyRow, 0);

                    cmbDriverDetails.DataSource = null;
                    cmbDriverDetails.DisplayMember = "FullName";
                    cmbDriverDetails.ValueMember = "DriverID";
                    cmbDriverDetails.DataSource = table;

                    cmbDriverDetails.SelectedIndex = 0;
                }
            }
        }

        // =====================================================
        // LOAD ASSISTANTS
        // =====================================================

        private void LoadAssistants()
        {
            using (SqlConnection con =
                new SqlConnection(connectionString))
            {
                string query = @"
SELECT AssistantID, FullName
FROM dbo.Assistants
ORDER BY FullName;";

                using (SqlDataAdapter adapter =
                    new SqlDataAdapter(query, con))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    DataRow emptyRow = table.NewRow();
                    emptyRow["AssistantID"] = DBNull.Value;
                    emptyRow["FullName"] = "-- Select Assistant --";

                    table.Rows.InsertAt(emptyRow, 0);

                    cmbAssistantDetails.DataSource = null;
                    cmbAssistantDetails.DisplayMember = "FullName";
                    cmbAssistantDetails.ValueMember = "AssistantID";
                    cmbAssistantDetails.DataSource = table;

                    cmbAssistantDetails.SelectedIndex = 0;
                }
            }
        }

        // =====================================================
        // LOAD CONTAINER TYPES
        // =====================================================

        private void LoadContainerTypes()
        {
            cmbContainerType.Items.Clear();

            cmbContainerType.Items.Add("-- Select Container --");
            cmbContainerType.Items.Add("20 ft Container");
            cmbContainerType.Items.Add("40 ft Container");
            cmbContainerType.Items.Add("Other");

            cmbContainerType.SelectedIndex = 0;
        }

        // =====================================================
        // LOAD AVAILABILITY STATUS
        // =====================================================

        private void LoadAvailabilityStatuses()
        {
            cmbAvailabilityStatus.Items.Clear();

            cmbAvailabilityStatus.Items.Add("Available");
            cmbAvailabilityStatus.Items.Add("Assigned");
            cmbAvailabilityStatus.Items.Add("Maintenance");
            cmbAvailabilityStatus.Items.Add("Unavailable");

            cmbAvailabilityStatus.SelectedIndex = 0;
        }

        // =====================================================
        // LOAD TRANSPORT UNITS
        // =====================================================

        private void LoadTransportUnits(string searchText = "")
        {
            using (SqlConnection con =
                new SqlConnection(connectionString))
            {
                string query = @"
SELECT
    UnitID,
    LorryRegistrationNo,
    UnitType,
    ISNULL(DriverName, '') AS DriverName,
    ISNULL(AssistantName, '') AS AssistantName,
    ISNULL(ContainerNo, '') AS ContainerNo,
    ISNULL(ContainerType, '') AS ContainerType,
    ISNULL(LoadCapacityKg, 0) AS LoadCapacityKg,
    AvailabilityStatus
FROM dbo.TransportUnits
WHERE
    @Search = ''
    OR UnitCode LIKE @Pattern
    OR LorryRegistrationNo LIKE @Pattern
    OR UnitType LIKE @Pattern
    OR ISNULL(DriverName, '') LIKE @Pattern
    OR ISNULL(AssistantName, '') LIKE @Pattern
    OR ISNULL(ContainerNo, '') LIKE @Pattern
    OR AvailabilityStatus LIKE @Pattern
ORDER BY UnitID DESC;";

                using (SqlCommand cmd =
                    new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@Search", searchText);

                    cmd.Parameters.AddWithValue(
                        "@Pattern", "%" + searchText + "%");

                    using (SqlDataAdapter adapter =
                        new SqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        dgvTransportUnitList.Rows.Clear();

                        foreach (DataRow row in table.Rows)
                        {
                            dgvTransportUnitList.Rows.Add(
                                row["UnitID"],
                                row["LorryRegistrationNo"],
                                row["UnitType"],
                                row["DriverName"],
                                row["AssistantName"],
                                row["ContainerNo"],
                                row["ContainerType"],
                                row["LoadCapacityKg"],
                                row["AvailabilityStatus"]);
                        }
                    }
                }
            }

            dgvTransportUnitList.ClearSelection();
        }

        // =====================================================
        // GET COMBOBOX SELECTED ID
        // =====================================================

        private object GetSelectedID(ComboBox combo)
        {
            if (combo.SelectedValue == null ||
                combo.SelectedValue == DBNull.Value)
            {
                return DBNull.Value;
            }

            if (combo.SelectedValue is DataRowView)
                return DBNull.Value;

            return combo.SelectedValue;
        }

        // =====================================================
        // GET COMBOBOX SELECTED NAME
        // =====================================================

        private string GetSelectedName(ComboBox combo)
        {
            if (combo.SelectedIndex <= 0)
                return "";

            return combo.Text.Trim();
        }

        // =====================================================
        // ADD TRANSPORT UNIT
        // =====================================================

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            if (!ValidateFields())
                return;

            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    con.Open();

                    string unitCode =
                        "TU" + DateTime.Now.ToString("yyyyMMddHHmmssfff");

                    string query = @"
INSERT INTO dbo.TransportUnits
(
    UnitCode,
    LorryRegistrationNo,
    UnitType,
    DriverName,
    AssistantName,
    ContainerNo,
    ContainerType,
    LoadCapacityKg,
    AvailabilityStatus,
    Remarks,
    DriverID,
    AssistantID
)
VALUES
(
    @UnitCode,
    @LorryRegistrationNo,
    @UnitType,
    @DriverName,
    @AssistantName,
    @ContainerNo,
    @ContainerType,
    @LoadCapacityKg,
    @AvailabilityStatus,
    @Remarks,
    @DriverID,
    @AssistantID
);

SELECT CAST(SCOPE_IDENTITY() AS INT);";

                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        AddParameters(cmd, unitCode);

                        int newID = Convert.ToInt32(
                            cmd.ExecuteScalar());

                        txtUnitID.Text = newID.ToString();
                    }
                }

                MessageBox.Show(
                    "Transport unit added successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadTransportUnits();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to add transport unit.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =====================================================
        // ADD SQL PARAMETERS
        // =====================================================

        private void AddParameters(
            SqlCommand cmd, string unitCode)
        {
            decimal capacity;

            decimal.TryParse(
                txtLoadCapacity.Text.Trim(),
                out capacity);

            cmd.Parameters.AddWithValue(
                "@UnitCode", unitCode);

            cmd.Parameters.AddWithValue(
                "@LorryRegistrationNo",
                txtLorryRegistration.Text.Trim());

            cmd.Parameters.AddWithValue(
                "@UnitType",
                txtLorryDetails.Text.Trim());

            cmd.Parameters.AddWithValue(
                "@DriverName",
                GetSelectedName(cmbDriverDetails));

            cmd.Parameters.AddWithValue(
                "@AssistantName",
                GetSelectedName(cmbAssistantDetails));

            cmd.Parameters.AddWithValue(
                "@ContainerNo",
                string.IsNullOrWhiteSpace(txtContainerNo.Text)
                    ? (object)DBNull.Value
                    : txtContainerNo.Text.Trim());

            cmd.Parameters.AddWithValue(
                "@ContainerType",
                cmbContainerType.SelectedIndex <= 0
                    ? (object)DBNull.Value
                    : cmbContainerType.Text);

            cmd.Parameters.AddWithValue(
                "@LoadCapacityKg",
                capacity);

            cmd.Parameters.AddWithValue(
                "@AvailabilityStatus",
                cmbAvailabilityStatus.Text);

            cmd.Parameters.AddWithValue(
                "@Remarks",
                string.IsNullOrWhiteSpace(
                    txtTransportUnitRemarks.Text)
                    ? (object)DBNull.Value
                    : txtTransportUnitRemarks.Text.Trim());

            cmd.Parameters.AddWithValue(
                "@DriverID",
                GetSelectedID(cmbDriverDetails));

            cmd.Parameters.AddWithValue(
                "@AssistantID",
                GetSelectedID(cmbAssistantDetails));
        }

        // =====================================================
        // VALIDATE FIELDS
        // =====================================================

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(
                txtLorryRegistration.Text))
            {
                MessageBox.Show(
                    "Please enter the lorry registration number.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtLorryRegistration.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(
                txtLorryDetails.Text))
            {
                MessageBox.Show(
                    "Please enter the lorry details / unit type.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtLorryDetails.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtLoadCapacity.Text))
            {
                decimal capacity;

                if (!decimal.TryParse(
                    txtLoadCapacity.Text.Trim(),
                    out capacity) || capacity <= 0)
                {
                    MessageBox.Show(
                        "Please enter a valid load capacity greater than zero.",
                        "Invalid Capacity",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtLoadCapacity.Focus();
                    return false;
                }
            }

            if (cmbAvailabilityStatus.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Please select an availability status.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbAvailabilityStatus.Focus();
                return false;
            }

            return true;
        }

        // =====================================================
        // UPDATE TRANSPORT UNIT
        // =====================================================

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            if (selectedUnitID == 0)
            {
                MessageBox.Show(
                    "Please select a transport unit from the list.",
                    "Select Transport Unit",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (!ValidateFields())
                return;

            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    con.Open();

                    string query = @"
UPDATE dbo.TransportUnits
SET
    LorryRegistrationNo = @LorryRegistrationNo,
    UnitType = @UnitType,
    DriverName = @DriverName,
    AssistantName = @AssistantName,
    ContainerNo = @ContainerNo,
    ContainerType = @ContainerType,
    LoadCapacityKg = @LoadCapacityKg,
    AvailabilityStatus = @AvailabilityStatus,
    Remarks = @Remarks,
    DriverID = @DriverID,
    AssistantID = @AssistantID
WHERE UnitID = @UnitID;";

                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        AddParameters(cmd, "");

                        cmd.Parameters.AddWithValue(
                            "@UnitID", selectedUnitID);

                        int result = cmd.ExecuteNonQuery();

                        if (result == 0)
                        {
                            MessageBox.Show(
                                "The selected transport unit was not found.",
                                "Update Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }
                    }
                }

                MessageBox.Show(
                    "Transport unit updated successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadTransportUnits();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to update transport unit.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =====================================================
        // DELETE TRANSPORT UNIT
        // =====================================================

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (selectedUnitID == 0)
            {
                MessageBox.Show(
                    "Please select a transport unit from the list.",
                    "Select Transport Unit",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this transport unit?",
                "Confirm Delete",
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
DELETE FROM dbo.TransportUnits
WHERE UnitID = @UnitID;";

                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@UnitID", selectedUnitID);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Transport unit deleted successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadTransportUnits();
                ClearFields();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Unable to delete this transport unit. " +
                    "It may already be linked to a job assignment.\n\n" +
                    ex.Message,
                    "Delete Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to delete transport unit.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =====================================================
        // SELECT TRANSPORT UNIT FROM GRID
        // =====================================================

        private void dgvTransportUnitList_CellClick(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row =
                dgvTransportUnitList.Rows[e.RowIndex];

            if (row.Cells[0].Value == null)
                return;

            selectedUnitID =
                Convert.ToInt32(row.Cells[0].Value);

            txtUnitID.Text = selectedUnitID.ToString();

            txtLorryRegistration.Text =
                GetCellText(row, 1);

            txtLorryDetails.Text =
                GetCellText(row, 2);

            SelectComboByText(
                cmbDriverDetails, GetCellText(row, 3));

            SelectComboByText(
                cmbAssistantDetails, GetCellText(row, 4));

            txtContainerNo.Text =
                GetCellText(row, 5);

            SelectComboByText(
                cmbContainerType, GetCellText(row, 6));

            txtLoadCapacity.Text =
                GetCellText(row, 7);

            SelectComboByText(
                cmbAvailabilityStatus, GetCellText(row, 8));

            LoadRemarks(selectedUnitID);
        }

        // =====================================================
        // LOAD REMARKS
        // =====================================================

        private void LoadRemarks(int unitID)
        {
            using (SqlConnection con =
                new SqlConnection(connectionString))
            {
                string query = @"
SELECT Remarks
FROM dbo.TransportUnits
WHERE UnitID = @UnitID;";

                using (SqlCommand cmd =
                    new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@UnitID", unitID);

                    con.Open();

                    object result = cmd.ExecuteScalar();

                    txtTransportUnitRemarks.Text =
                        result == null || result == DBNull.Value
                            ? ""
                            : result.ToString();
                }
            }
        }

        // =====================================================
        // GET GRID CELL TEXT
        // =====================================================

        private string GetCellText(
            DataGridViewRow row, int columnIndex)
        {
            object value = row.Cells[columnIndex].Value;

            return value == null || value == DBNull.Value
                ? ""
                : value.ToString();
        }

        // =====================================================
        // SELECT COMBOBOX ITEM
        // =====================================================

        private void SelectComboByText(
            ComboBox combo, string value)
        {
            combo.SelectedIndex = 0;

            if (string.IsNullOrWhiteSpace(value))
                return;

            for (int i = 0; i < combo.Items.Count; i++)
            {
                combo.SelectedIndex = i;

                if (string.Equals(
                    combo.Text.Trim(),
                    value.Trim(),
                    StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }
            }

            combo.SelectedIndex = 0;
        }

        // =====================================================
        // SEARCH TRANSPORT UNITS
        // =====================================================

        private void txtSearchTransportUnits_TextChanged(
            object sender, EventArgs e)
        {
            try
            {
                LoadTransportUnits(
                    txtSearchTransportUnits.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to search transport units.\n\n" +
                    ex.Message,
                    "Search Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =====================================================
        // RESET BUTTON
        // =====================================================

        private void btnResetAdmin_Click(object sender, EventArgs e)
        {
            ClearFields();

            LoadDrivers();
            LoadAssistants();
            LoadTransportUnits();
        }

        // =====================================================
        // CLEAR BUTTON
        // =====================================================

        private void btnClearCustomer_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        // =====================================================
        // CLEAR ALL FIELDS
        // =====================================================

        private void ClearFields()
        {
            selectedUnitID = 0;

            txtUnitID.Clear();
            txtLorryRegistration.Clear();
            txtLorryDetails.Clear();
            txtContainerNo.Clear();
            txtLoadCapacity.Clear();
            txtTransportUnitRemarks.Clear();

            if (cmbDriverDetails.Items.Count > 0)
                cmbDriverDetails.SelectedIndex = 0;

            if (cmbAssistantDetails.Items.Count > 0)
                cmbAssistantDetails.SelectedIndex = 0;

            if (cmbContainerType.Items.Count > 0)
                cmbContainerType.SelectedIndex = 0;

            if (cmbAvailabilityStatus.Items.Count > 0)
                cmbAvailabilityStatus.SelectedIndex = 0;

            dgvTransportUnitList.ClearSelection();

            txtLorryRegistration.Focus();
        }

        // =====================================================
        // NAVIGATION
        // =====================================================

        private void OpenChildForm(Form child)
        {
            if (child == null || IsDisposed || Disposing)
            {
                if (child != null)
                    child.Dispose();

                return;
            }

            Hide();

            try
            {
                using (child)
                {
                    child.StartPosition =
                        FormStartPosition.CenterScreen;

                    child.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to open selected page.\n\n" +
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

                    try
                    {
                        LoadTransportUnits();
                    }
                    catch
                    {
                        // Keep the current form open if refresh fails.
                    }
                }
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmAdminDashboard());
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
            LoadTransportUnits();
        }

        private void btnManageJobAssignments_Click(
            object sender, EventArgs e)
        {
            MessageBox.Show(
                "The Job Assignments management form has not been connected yet.",
                "Job Assignments",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmReports());
        }

        // =====================================================
        // LOGOUT
        // =====================================================

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show(
                "Are you sure you want to logout?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (answer != DialogResult.Yes)
                return;

            FrmLogin login = null;
            FrmAdminDashboard dashboard = null;

            foreach (Form form in Application.OpenForms)
            {
                if (form is FrmLogin && !form.IsDisposed)
                    login = (FrmLogin)form;

                if (form is FrmAdminDashboard && !form.IsDisposed)
                    dashboard = (FrmAdminDashboard)form;
            }

            if (login == null)
                login = new FrmLogin();

            login.StartPosition = FormStartPosition.CenterScreen;
            login.WindowState = FormWindowState.Normal;

            login.Show();
            login.BringToFront();
            login.Activate();

            if (dashboard != null)
                dashboard.Close();

            Close();
        }
    }
}
