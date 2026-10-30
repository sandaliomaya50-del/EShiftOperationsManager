
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EShiftOperationsManager
{
    public partial class FrmProductManagement : Form
    {
        private readonly string connectionString =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=EShiftOperationsDB;Integrated Security=True;TrustServerCertificate=True;";

        private string selectedProductID = "";
        private bool isLoggingOut = false;

        public FrmProductManagement()
        {
            InitializeComponent();

            this.Load -= FrmProductManagement_Load;
            this.Load += FrmProductManagement_Load;

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

            txtSearchProducts.TextChanged -= txtSearchProducts_TextChanged;
            txtSearchProducts.TextChanged += txtSearchProducts_TextChanged;

            dgvProductList.CellClick -= dgvProductList_CellClick;
            dgvProductList.CellClick += dgvProductList_CellClick;

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

        // =========================================================
        // FORM LOAD
        // =========================================================

        private void FrmProductManagement_Load(object sender, EventArgs e)
        {
            txtProductID.ReadOnly = true;
            txtLoadNumber.ReadOnly = true;

            cmbProductCategory.Items.Clear();
            cmbProductCategory.Items.AddRange(new object[]
            {
                "Furniture",
                "Electronics",
                "Kitchenware",
                "Clothing",
                "Appliances",
                "Household Goods",
                "Other"
            });

            cmbProductCategory.DropDownStyle = ComboBoxStyle.DropDown;

            cmbProductUnit.Items.Clear();
            cmbProductUnit.Items.AddRange(new object[]
            {
                "Piece",
                "Box",
                "Carton",
                "Bag",
                "Set",
                "Item"
            });

            cmbProductUnit.DropDownStyle = ComboBoxStyle.DropDown;

            // Use the existing Designer columns.
            // This prevents duplicate columns appearing in the grid.

            dgvProductList.AutoGenerateColumns = false;
            dgvProductList.ReadOnly = true;
            dgvProductList.AllowUserToAddRows = false;
            dgvProductList.AllowUserToDeleteRows = false;
            dgvProductList.MultiSelect = false;
            dgvProductList.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvProductList.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            colProductID.DataPropertyName = "ProductID";
            colProductName.DataPropertyName = "ProductName";
            colCategory.DataPropertyName = "Category";
            colUnit.DataPropertyName = "Unit";
            colLoadNumber.DataPropertyName = "LoadNo";
            colProductQuantity.DataPropertyName = "Quantity";
            colAverageSize.DataPropertyName = "AverageSize";
            colAverageWeight.DataPropertyName = "AverageWeight";
            colProductStatus.DataPropertyName = "Status";

            LoadProducts();
            ResetProductFields();
        }

        // =========================================================
        // GENERATE PRODUCT ID
        // =========================================================

        private string GenerateProductID()
        {
            return "PRD" +
                Guid.NewGuid().ToString("N")
                .Substring(0, 17).ToUpperInvariant();
        }

        // =========================================================
        // LOAD PRODUCTS
        // =========================================================

        private void LoadProducts()
        {
            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    string sql = @"
SELECT
    p.ProductID,
    p.ProductName,
    p.Category,
    p.Unit,
    p.Description,
    p.AverageSize,
    p.AverageWeight,
    p.Status,
    ISNULL(LD.LoadNo, '') AS LoadNo,
    LD.Quantity
FROM dbo.Products AS p

OUTER APPLY
(
    SELECT TOP 1
        l.LoadNo,
        l.Quantity,
        j.JobNo
    FROM dbo.Loads AS l
    LEFT JOIN dbo.TransportJobs AS j
        ON l.JobID = j.JobID
    WHERE l.ProductID = p.ProductID
    ORDER BY l.LoadID DESC
) AS LD

WHERE
(
    @Search = ''
    OR p.ProductID LIKE @Pattern
    OR p.ProductName LIKE @Pattern
    OR ISNULL(p.Category, '') LIKE @Pattern
    OR p.Unit LIKE @Pattern
    OR ISNULL(p.Description, '') LIKE @Pattern
    OR ISNULL(p.AverageSize, '') LIKE @Pattern
    OR ISNULL(p.Status, '') LIKE @Pattern
    OR ISNULL(LD.LoadNo, '') LIKE @Pattern
)

ORDER BY p.ProductID DESC;";

                    using (SqlCommand cmd =
                        new SqlCommand(sql, con))
                    {
                        string search = txtSearchProducts.Text.Trim();

                        cmd.Parameters.Add("@Search",
                            SqlDbType.NVarChar, 200).Value = search;

                        cmd.Parameters.Add("@Pattern",
                            SqlDbType.NVarChar, 202).Value =
                            "%" + search + "%";

                        using (SqlDataAdapter adapter =
                            new SqlDataAdapter(cmd))
                        {
                            DataTable table = new DataTable();

                            adapter.Fill(table);

                            dgvProductList.DataSource = table;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load products.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // SEARCH PRODUCTS
        // =========================================================

        private void txtSearchProducts_TextChanged(
            object sender, EventArgs e)
        {
            LoadProducts();
        }

        // =========================================================
        // SELECT PRODUCT
        // =========================================================

        private void dgvProductList_CellClick(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row =
                dgvProductList.Rows[e.RowIndex];

            if (row.Cells["colProductID"].Value == null ||
                row.Cells["colProductID"].Value == DBNull.Value)
                return;

            selectedProductID =
                row.Cells["colProductID"].Value.ToString();

            txtProductID.Text = selectedProductID;

            txtProductName.Text =
                CellText(row, "colProductName");

            cmbProductCategory.Text =
                CellText(row, "colCategory");

            cmbProductUnit.Text =
                CellText(row, "colUnit");

            txtAverageSize.Text =
                CellText(row, "colAverageSize");

            txtAverageWeight.Text =
                CellText(row, "colAverageWeight");

            txtProductDescription.Clear();
            txtLoadNumber.Clear();
            txtProductQuantity.Clear();
            txtAssociatedJobNo.Clear();

            LoadProductDetails(selectedProductID);
            LoadProductLoadDetails();
        }

        private string CellText(
            DataGridViewRow row, string column)
        {
            if (!dgvProductList.Columns.Contains(column))
                return "";

            object value = row.Cells[column].Value;

            return value == null || value == DBNull.Value
                ? ""
                : value.ToString();
        }

        private void LoadProductDetails(string productID)
        {
            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    string sql = @"
SELECT Description
FROM dbo.Products
WHERE ProductID = @ProductID;";

                    using (SqlCommand cmd =
                        new SqlCommand(sql, con))
                    {
                        cmd.Parameters.Add("@ProductID",
                            SqlDbType.VarChar, 20).Value = productID;

                        con.Open();

                        object result = cmd.ExecuteScalar();

                        txtProductDescription.Text =
                            result == null || result == DBNull.Value
                            ? ""
                            : result.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load product description.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // ADD PRODUCT
        // =========================================================

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            if (!ValidateProduct())
                return;

            string newProductID = GenerateProductID();

            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    con.Open();

                    using (SqlTransaction transaction =
                        con.BeginTransaction())
                    {
                        try
                        {
                            string sql = @"
INSERT INTO dbo.Products
(
    ProductID,
    ProductName,
    Category,
    Unit,
    Description,
    AverageSize,
    AverageWeight,
    Status
)
VALUES
(
    @ProductID,
    @Name,
    @Category,
    @Unit,
    @Description,
    @AverageSize,
    @AverageWeight,
    'Active'
);";

                            using (SqlCommand cmd =
                                new SqlCommand(sql, con, transaction))
                            {
                                cmd.Parameters.Add("@ProductID",
                                    SqlDbType.VarChar, 20).Value =
                                    newProductID;

                                AddProductParameters(cmd);

                                cmd.ExecuteNonQuery();
                            }

                            // Associated Job Number is OPTIONAL.
                            // Only create load details if supplied.

                            if (HasLoadDetails())
                            {
                                SaveLoadDetails(
                                    con, transaction, newProductID);
                            }

                            transaction.Commit();

                            string message =
                                "Product added successfully.\n\n" +
                                "Product ID: " + newProductID;

                            if (!HasLoadDetails())
                            {
                                message +=
                                    "\n\nNo load was created. " +
                                    "You can associate a transport job later.";
                            }

                            MessageBox.Show(
                                message,
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            LoadProducts();
                            ResetProductFields();
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
                    "Unable to add product.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // UPDATE PRODUCT
        // =========================================================

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedProductID))
            {
                MessageBox.Show(
                    "Select a product from the table first.",
                    "Select Product",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (!ValidateProduct())
                return;

            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    con.Open();

                    using (SqlTransaction transaction =
                        con.BeginTransaction())
                    {
                        try
                        {
                            string sql = @"
UPDATE dbo.Products
SET
    ProductName = @Name,
    Category = @Category,
    Unit = @Unit,
    Description = @Description,
    AverageSize = @AverageSize,
    AverageWeight = @AverageWeight
WHERE ProductID = @ProductID;";

                            using (SqlCommand cmd =
                                new SqlCommand(sql, con, transaction))
                            {
                                AddProductParameters(cmd);

                                cmd.Parameters.Add("@ProductID",
                                    SqlDbType.VarChar, 20).Value =
                                    selectedProductID;

                                if (cmd.ExecuteNonQuery() == 0)
                                {
                                    throw new Exception(
                                        "The selected product no longer exists.");
                                }
                            }

                            // Update or create load details only
                            // when load information is supplied.

                            if (HasLoadDetails())
                            {
                                SaveLoadDetails(
                                    con, transaction, selectedProductID);
                            }

                            transaction.Commit();

                            MessageBox.Show(
                                "Product updated successfully.",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            LoadProducts();
                            ResetProductFields();
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
                    "Unable to update product.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // DELETE PRODUCT
        // =========================================================

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedProductID))
            {
                MessageBox.Show(
                    "Select a product from the table first.",
                    "Select Product",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (MessageBox.Show(
                "Delete this product? Products used in existing loads cannot be deleted.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(@"
DELETE FROM dbo.Products
WHERE ProductID = @ProductID
AND NOT EXISTS
(
    SELECT 1
    FROM dbo.Loads
    WHERE Loads.ProductID = Products.ProductID
);", con))
                    {
                        cmd.Parameters.Add("@ProductID",
                            SqlDbType.VarChar, 20).Value =
                            selectedProductID;

                        int affected = cmd.ExecuteNonQuery();

                        if (affected == 0)
                        {
                            MessageBox.Show(
                                "The product was not deleted. " +
                                "It may be used in existing loads.",
                                "Cannot Delete Product",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }
                    }
                }

                MessageBox.Show(
                    "Product deleted successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadProducts();
                ResetProductFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to delete product.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // VALIDATE PRODUCT
        // =========================================================

        private bool ValidateProduct()
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text) ||
                string.IsNullOrWhiteSpace(cmbProductCategory.Text) ||
                string.IsNullOrWhiteSpace(cmbProductUnit.Text))
            {
                MessageBox.Show(
                    "Enter Product Name, Category, and Unit.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (txtProductName.Text.Trim().Length > 100)
            {
                MessageBox.Show(
                    "Product Name cannot exceed 100 characters.",
                    "Invalid Product Name",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (cmbProductCategory.Text.Trim().Length > 50)
            {
                MessageBox.Show(
                    "Category cannot exceed 50 characters.",
                    "Invalid Category",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (cmbProductUnit.Text.Trim().Length > 30)
            {
                MessageBox.Show(
                    "Unit cannot exceed 30 characters.",
                    "Invalid Unit",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (txtProductDescription.Text.Trim().Length > 500)
            {
                MessageBox.Show(
                    "Description cannot exceed 500 characters.",
                    "Invalid Description",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            decimal weight;

            if (!string.IsNullOrWhiteSpace(txtAverageWeight.Text) &&
                (!decimal.TryParse(
                    txtAverageWeight.Text.Trim(), out weight) ||
                 weight < 0))
            {
                MessageBox.Show(
                    "Average Weight must be a valid non-negative number.",
                    "Invalid Weight",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtAverageSize.Text) &&
                txtAverageSize.Text.Trim().Length > 100)
            {
                MessageBox.Show(
                    "Average Size cannot exceed 100 characters.",
                    "Invalid Average Size",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            // Load details are optional.
            // If the user starts entering load information,
            // both Job Number and Quantity must be supplied.

            bool hasJobNumber =
                !string.IsNullOrWhiteSpace(txtAssociatedJobNo.Text);

            bool hasQuantity =
                !string.IsNullOrWhiteSpace(txtProductQuantity.Text);

            if (hasJobNumber != hasQuantity)
            {
                MessageBox.Show(
                    "To create load details, enter both Associated Job No and Quantity.\n\n" +
                    "If you only want to save the product, leave both fields empty.",
                    "Incomplete Load Details",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (hasJobNumber &&
                txtAssociatedJobNo.Text.Trim().Length > 20)
            {
                MessageBox.Show(
                    "Associated Job Number cannot exceed 20 characters.",
                    "Invalid Job Number",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            int quantity;

            if (hasQuantity &&
                (!int.TryParse(
                    txtProductQuantity.Text.Trim(), out quantity) ||
                 quantity <= 0))
            {
                MessageBox.Show(
                    "Product Quantity must be a positive whole number.",
                    "Invalid Quantity",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        // =========================================================
        // PRODUCT PARAMETERS
        // =========================================================

        private void AddProductParameters(SqlCommand cmd)
        {
            cmd.Parameters.Add("@Name",
                SqlDbType.NVarChar, 100)
                .Value = txtProductName.Text.Trim();

            cmd.Parameters.Add("@Category",
                SqlDbType.NVarChar, 50)
                .Value = cmbProductCategory.Text.Trim();

            cmd.Parameters.Add("@Unit",
                SqlDbType.NVarChar, 30)
                .Value = cmbProductUnit.Text.Trim();

            cmd.Parameters.Add("@Description",
                SqlDbType.NVarChar, 500)
                .Value =
                string.IsNullOrWhiteSpace(txtProductDescription.Text)
                ? (object)DBNull.Value
                : txtProductDescription.Text.Trim();

            cmd.Parameters.Add("@AverageSize",
                SqlDbType.NVarChar, 100)
                .Value =
                string.IsNullOrWhiteSpace(txtAverageSize.Text)
                ? (object)DBNull.Value
                : txtAverageSize.Text.Trim();

            SqlParameter weightParameter =
                cmd.Parameters.Add("@AverageWeight",
                    SqlDbType.Decimal);

            weightParameter.Precision = 18;
            weightParameter.Scale = 2;

            decimal weight;

            weightParameter.Value =
                decimal.TryParse(
                    txtAverageWeight.Text.Trim(), out weight)
                ? (object)weight
                : DBNull.Value;
        }

        // =========================================================
        // LOAD DETAILS
        // =========================================================

        private bool HasLoadDetails()
        {
            return
                !string.IsNullOrWhiteSpace(txtAssociatedJobNo.Text) ||
                !string.IsNullOrWhiteSpace(txtProductQuantity.Text);
        }

        private void SaveLoadDetails(
            SqlConnection con,
            SqlTransaction transaction,
            string productID)
        {
            if (string.IsNullOrWhiteSpace(txtAssociatedJobNo.Text))
            {
                throw new Exception(
                    "Enter an Associated Job Number to create load details.");
            }

            int quantity;

            if (!int.TryParse(
                txtProductQuantity.Text.Trim(), out quantity) ||
                quantity <= 0)
            {
                throw new Exception(
                    "Enter a valid positive load quantity.");
            }

            int jobID;

            using (SqlCommand findJob = new SqlCommand(@"
SELECT JobID
FROM dbo.TransportJobs
WHERE JobNo = @JobNo;",
                con, transaction))
            {
                findJob.Parameters.Add("@JobNo",
                    SqlDbType.VarChar, 20)
                    .Value = txtAssociatedJobNo.Text.Trim();

                object result = findJob.ExecuteScalar();

                if (result == null || result == DBNull.Value)
                {
                    throw new Exception(
                        "The associated Job Number was not found. " +
                        "Please enter an existing Job Number.");
                }

                jobID = Convert.ToInt32(result);
            }

            int existingLoadID = 0;

            using (SqlCommand findLoad = new SqlCommand(@"
SELECT TOP 1 LoadID
FROM dbo.Loads
WHERE JobID = @JobID
AND ProductID = @ProductID
ORDER BY LoadID DESC;",
                con, transaction))
            {
                findLoad.Parameters.Add("@JobID",
                    SqlDbType.Int).Value = jobID;

                findLoad.Parameters.Add("@ProductID",
                    SqlDbType.VarChar, 20).Value = productID;

                object result = findLoad.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    existingLoadID = Convert.ToInt32(result);
                }
            }

            string sql;

            if (existingLoadID > 0)
            {
                sql = @"
UPDATE dbo.Loads
SET
    LoadName = @LoadName,
    Quantity = @Quantity
WHERE LoadID = @LoadID;";
            }
            else
            {
                sql = @"
INSERT INTO dbo.Loads
(
    LoadNo,
    JobID,
    ProductID,
    LoadName,
    Quantity
)
VALUES
(
    @LoadNo,
    @JobID,
    @ProductID,
    @LoadName,
    @Quantity
);";
            }

            using (SqlCommand cmd =
                new SqlCommand(sql, con, transaction))
            {
                cmd.Parameters.Add("@JobID",
                    SqlDbType.Int).Value = jobID;

                cmd.Parameters.Add("@ProductID",
                    SqlDbType.VarChar, 20).Value = productID;

                cmd.Parameters.Add("@Quantity",
                    SqlDbType.Int).Value = quantity;

                cmd.Parameters.Add("@LoadName",
                    SqlDbType.NVarChar, 100)
                    .Value = txtProductName.Text.Trim();

                if (existingLoadID > 0)
                {
                    cmd.Parameters.Add("@LoadID",
                        SqlDbType.Int).Value = existingLoadID;
                }
                else
                {
                    string newLoadNo = "LD" +
                        Guid.NewGuid().ToString("N")
                        .Substring(0, 12).ToUpperInvariant();

                    cmd.Parameters.Add("@LoadNo",
                        SqlDbType.VarChar, 20).Value = newLoadNo;

                    txtLoadNumber.Text = newLoadNo;
                }

                cmd.ExecuteNonQuery();
            }
        }

        // =========================================================
        // LOAD EXISTING LOAD DETAILS
        // =========================================================

        private void LoadProductLoadDetails()
        {
            if (string.IsNullOrWhiteSpace(selectedProductID))
                return;

            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(@"
SELECT TOP 1
    l.LoadNo,
    l.Quantity,
    j.JobNo
FROM dbo.Loads AS l
INNER JOIN dbo.TransportJobs AS j
    ON l.JobID = j.JobID
WHERE l.ProductID = @ProductID
ORDER BY l.LoadID DESC;",
                        con))
                    {
                        cmd.Parameters.Add("@ProductID",
                            SqlDbType.VarChar, 20).Value =
                            selectedProductID;

                        using (SqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtLoadNumber.Text =
                                    reader["LoadNo"] == DBNull.Value
                                    ? ""
                                    : reader["LoadNo"].ToString();

                                txtProductQuantity.Text =
                                    reader["Quantity"].ToString();

                                txtAssociatedJobNo.Text =
                                    reader["JobNo"] == DBNull.Value
                                    ? ""
                                    : reader["JobNo"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load associated load details.\n\n" +
                    ex.Message,
                    "Load Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        // =========================================================
        // RESET BUTTON
        // =========================================================

        private void btnResetAdmin_Click(object sender, EventArgs e)
        {
            ResetProductFields();

            MessageBox.Show(
                "Product form reset.",
                "Reset",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // =========================================================
        // CLEAR SEARCH BUTTON
        // =========================================================

        private void btnClearCustomer_Click(object sender, EventArgs e)
        {
            txtSearchProducts.Clear();

            ResetProductFields();

            LoadProducts();

            MessageBox.Show(
                "Search cleared.",
                "Clear Search",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // =========================================================
        // CLEAR PRODUCT FIELDS
        // =========================================================

        private void ResetProductFields()
        {
            selectedProductID = "";

            txtProductID.Clear();
            txtProductName.Clear();
            txtProductDescription.Clear();
            txtAverageSize.Clear();
            txtAverageWeight.Clear();

            txtLoadNumber.Clear();
            txtProductQuantity.Clear();
            txtAssociatedJobNo.Clear();

            cmbProductCategory.SelectedIndex = -1;
            cmbProductCategory.Text = "";

            cmbProductUnit.SelectedIndex = -1;
            cmbProductUnit.Text = "";

            dgvProductList.ClearSelection();

            txtProductName.Focus();
        }

        // =========================================================
        // NAVIGATION
        // =========================================================

        private void OpenChildForm(Form child)
        {
            if (isLoggingOut || IsDisposed || Disposing)
            {
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
                    "Unable to open the selected page.\n\n" +
                    ex.Message,
                    "Navigation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                if (!IsDisposed && !Disposing && !isLoggingOut)
                {
                    Show();
                    Activate();
                    LoadProducts();
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
            LoadProducts();
        }

        private void btnTransportUnits_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmTransportUnitManagement());
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

        // =========================================================
        // LOGOUT
        // =========================================================

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Are you sure you want to logout?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            isLoggingOut = true;

            FrmLogin login = null;
            FrmAdminDashboard dashboard = null;

            foreach (Form form in Application.OpenForms)
            {
                if (form is FrmLogin && !form.IsDisposed)
                    login = (FrmLogin)form;

                if (form is FrmAdminDashboard && !form.IsDisposed)
                    dashboard = (FrmAdminDashboard)form;
            }

            if (login != null)
            {
                login.Show();
                login.WindowState = FormWindowState.Normal;
                login.BringToFront();
                login.Activate();
            }

            if (dashboard != null)
                dashboard.Close();

            Close();
        }

        // =========================================================
        // EXISTING DESIGNER EVENT
        // =========================================================

        private void picMovingTruck_Click(object sender, EventArgs e)
        {
            // Existing Designer event retained.
        }
    }
}

