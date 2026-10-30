namespace EShiftOperationsManager
{
    partial class FrmJobManagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.picleft = new System.Windows.Forms.PictureBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnManageJobAssignments = new System.Windows.Forms.Button();
            this.btnTransportUnits = new System.Windows.Forms.Button();
            this.btnProducts = new System.Windows.Forms.Button();
            this.btnJobs = new System.Windows.Forms.Button();
            this.btnAdmins = new System.Windows.Forms.Button();
            this.btnCustomers = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.lblBrandSubtitle2 = new System.Windows.Forms.Label();
            this.lblBrandSubtitle = new System.Windows.Forms.Label();
            this.lblLoginHeading3 = new System.Windows.Forms.Label();
            this.lblLoginHeading2 = new System.Windows.Forms.Label();
            this.lblLogo = new System.Windows.Forms.PictureBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlTransportJobs = new System.Windows.Forms.Panel();
            this.dgvTransportJobs = new System.Windows.Forms.DataGridView();
            this.colJobNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDestination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPickup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRequestDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTransportJobsTitle = new System.Windows.Forms.Label();
            this.picTransportJobsIcon = new System.Windows.Forms.PictureBox();
            this.pnlWelcomeAdmin = new System.Windows.Forms.Panel();
            this.lblWelcomeDescription2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblWelcomeDescription = new System.Windows.Forms.Label();
            this.picWelcomeAdmin = new System.Windows.Forms.PictureBox();
            this.lblWelcomeAdmin = new System.Windows.Forms.Label();
            this.pnlSelectedJobDetails = new System.Windows.Forms.Panel();
            this.txtAdminRemarks = new System.Windows.Forms.TextBox();
            this.lblAdminRemarks = new System.Windows.Forms.Label();
            this.btnAssignTransportUnit = new System.Windows.Forms.Button();
            this.btnUpdateJob = new System.Windows.Forms.Button();
            this.pnlJobInformationValues = new System.Windows.Forms.Panel();
            this.lblValueJobStatus = new System.Windows.Forms.Label();
            this.lblValueAssignedTransportUnit = new System.Windows.Forms.Label();
            this.lblValueLoadDetails = new System.Windows.Forms.Label();
            this.lblValueDestination = new System.Windows.Forms.Label();
            this.lblValueRequestedTransportDate = new System.Windows.Forms.Label();
            this.lblValueRequestDate = new System.Windows.Forms.Label();
            this.lblValueCustomer = new System.Windows.Forms.Label();
            this.lblValueJobNo = new System.Windows.Forms.Label();
            this.lblValuePickupLocation = new System.Windows.Forms.Label();
            this.btnDeclineJob = new System.Windows.Forms.Button();
            this.btnAcceptJob = new System.Windows.Forms.Button();
            this.pnlJobInformation = new System.Windows.Forms.Panel();
            this.lblJobStatus = new System.Windows.Forms.Label();
            this.lblAssignedTransportUnit = new System.Windows.Forms.Label();
            this.lblLoadDetails = new System.Windows.Forms.Label();
            this.lblRequestedTransportDate = new System.Windows.Forms.Label();
            this.lblRequestDate = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblDestination = new System.Windows.Forms.Label();
            this.lblJobNo = new System.Windows.Forms.Label();
            this.lblPickupLocation = new System.Windows.Forms.Label();
            this.picSelectedJobDetailsIcon = new System.Windows.Forms.PictureBox();
            this.lblSelectedJobDetailsTitle = new System.Windows.Forms.Label();
            this.pnlJobSearch = new System.Windows.Forms.Panel();
            this.btnSearchJobs = new System.Windows.Forms.Button();
            this.btnClearJobSearch = new System.Windows.Forms.Button();
            this.cmbFilterJobStatus = new System.Windows.Forms.ComboBox();
            this.lblFilterJobStatus = new System.Windows.Forms.Label();
            this.picJobSearchIcon = new System.Windows.Forms.PictureBox();
            this.txtSearchJobNo = new System.Windows.Forms.TextBox();
            this.lblSearchJobNo = new System.Windows.Forms.Label();
            this.lblJobManagementSubtitle = new System.Windows.Forms.Label();
            this.lblJobManagementTitle = new System.Windows.Forms.Label();
            this.pnlSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picleft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLogo)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.pnlTransportJobs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransportJobs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTransportJobsIcon)).BeginInit();
            this.pnlWelcomeAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWelcomeAdmin)).BeginInit();
            this.pnlSelectedJobDetails.SuspendLayout();
            this.pnlJobInformationValues.SuspendLayout();
            this.pnlJobInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSelectedJobDetailsIcon)).BeginInit();
            this.pnlJobSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picJobSearchIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(56)))), ((int)(((byte)(101)))));
            this.pnlSidebar.Controls.Add(this.picleft);
            this.pnlSidebar.Controls.Add(this.btnLogout);
            this.pnlSidebar.Controls.Add(this.btnReports);
            this.pnlSidebar.Controls.Add(this.btnManageJobAssignments);
            this.pnlSidebar.Controls.Add(this.btnTransportUnits);
            this.pnlSidebar.Controls.Add(this.btnProducts);
            this.pnlSidebar.Controls.Add(this.btnJobs);
            this.pnlSidebar.Controls.Add(this.btnAdmins);
            this.pnlSidebar.Controls.Add(this.btnCustomers);
            this.pnlSidebar.Controls.Add(this.btnDashboard);
            this.pnlSidebar.Controls.Add(this.lblBrandSubtitle2);
            this.pnlSidebar.Controls.Add(this.lblBrandSubtitle);
            this.pnlSidebar.Controls.Add(this.lblLoginHeading3);
            this.pnlSidebar.Controls.Add(this.lblLoginHeading2);
            this.pnlSidebar.Controls.Add(this.lblLogo);
            this.pnlSidebar.Location = new System.Drawing.Point(1, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(244, 749);
            this.pnlSidebar.TabIndex = 2;
            // 
            // picleft
            // 
            this.picleft.BackColor = System.Drawing.Color.Transparent;
            this.picleft.Image = global::EShiftOperationsManager.Properties.Resources.BlueHaven_Moving_Poster_png;
            this.picleft.Location = new System.Drawing.Point(24, 476);
            this.picleft.Name = "picleft";
            this.picleft.Size = new System.Drawing.Size(201, 225);
            this.picleft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picleft.TabIndex = 23;
            this.picleft.TabStop = false;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(145)))), ((int)(((byte)(203)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Image = global::EShiftOperationsManager.Properties.Resources.exit_icon__3_;
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnLogout.Location = new System.Drawing.Point(11, 436);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(214, 34);
            this.btnLogout.TabIndex = 22;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(84)))), ((int)(((byte)(129)))));
            this.btnReports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.ForeColor = System.Drawing.Color.White;
            this.btnReports.Image = global::EShiftOperationsManager.Properties.Resources.Reportsicon_png;
            this.btnReports.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnReports.Location = new System.Drawing.Point(30, 396);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(183, 34);
            this.btnReports.TabIndex = 21;
            this.btnReports.Text = "Reports";
            this.btnReports.UseVisualStyleBackColor = false;
            // 
            // btnManageJobAssignments
            // 
            this.btnManageJobAssignments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(84)))), ((int)(((byte)(129)))));
            this.btnManageJobAssignments.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnManageJobAssignments.FlatAppearance.BorderSize = 0;
            this.btnManageJobAssignments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageJobAssignments.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageJobAssignments.ForeColor = System.Drawing.Color.White;
            this.btnManageJobAssignments.Image = global::EShiftOperationsManager.Properties.Resources.JOBICON_png;
            this.btnManageJobAssignments.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnManageJobAssignments.Location = new System.Drawing.Point(30, 356);
            this.btnManageJobAssignments.Name = "btnManageJobAssignments";
            this.btnManageJobAssignments.Size = new System.Drawing.Size(183, 34);
            this.btnManageJobAssignments.TabIndex = 20;
            this.btnManageJobAssignments.Text = "Assignments";
            this.btnManageJobAssignments.UseVisualStyleBackColor = false;
            // 
            // btnTransportUnits
            // 
            this.btnTransportUnits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(84)))), ((int)(((byte)(129)))));
            this.btnTransportUnits.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTransportUnits.FlatAppearance.BorderSize = 0;
            this.btnTransportUnits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransportUnits.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransportUnits.ForeColor = System.Drawing.Color.White;
            this.btnTransportUnits.Image = global::EShiftOperationsManager.Properties.Resources.TRANSPORTIcon_png;
            this.btnTransportUnits.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnTransportUnits.Location = new System.Drawing.Point(30, 316);
            this.btnTransportUnits.Name = "btnTransportUnits";
            this.btnTransportUnits.Size = new System.Drawing.Size(183, 34);
            this.btnTransportUnits.TabIndex = 19;
            this.btnTransportUnits.Text = "Transport Units";
            this.btnTransportUnits.UseVisualStyleBackColor = false;
            // 
            // btnProducts
            // 
            this.btnProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(84)))), ((int)(((byte)(129)))));
            this.btnProducts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProducts.FlatAppearance.BorderSize = 0;
            this.btnProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProducts.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProducts.ForeColor = System.Drawing.Color.White;
            this.btnProducts.Image = global::EShiftOperationsManager.Properties.Resources.Productsicon_png;
            this.btnProducts.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnProducts.Location = new System.Drawing.Point(30, 276);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(183, 34);
            this.btnProducts.TabIndex = 18;
            this.btnProducts.Text = "Products";
            this.btnProducts.UseVisualStyleBackColor = false;
            // 
            // btnJobs
            // 
            this.btnJobs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(84)))), ((int)(((byte)(129)))));
            this.btnJobs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJobs.FlatAppearance.BorderSize = 0;
            this.btnJobs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJobs.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobs.ForeColor = System.Drawing.Color.White;
            this.btnJobs.Image = global::EShiftOperationsManager.Properties.Resources.JOBICON_png;
            this.btnJobs.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnJobs.Location = new System.Drawing.Point(30, 236);
            this.btnJobs.Name = "btnJobs";
            this.btnJobs.Size = new System.Drawing.Size(183, 34);
            this.btnJobs.TabIndex = 17;
            this.btnJobs.Text = "Jobs";
            this.btnJobs.UseVisualStyleBackColor = false;
            // 
            // btnAdmins
            // 
            this.btnAdmins.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(84)))), ((int)(((byte)(129)))));
            this.btnAdmins.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdmins.FlatAppearance.BorderSize = 0;
            this.btnAdmins.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdmins.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdmins.ForeColor = System.Drawing.Color.White;
            this.btnAdmins.Image = global::EShiftOperationsManager.Properties.Resources.ADMINICON_png;
            this.btnAdmins.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAdmins.Location = new System.Drawing.Point(30, 196);
            this.btnAdmins.Name = "btnAdmins";
            this.btnAdmins.Size = new System.Drawing.Size(183, 34);
            this.btnAdmins.TabIndex = 16;
            this.btnAdmins.Text = "Admins";
            this.btnAdmins.UseVisualStyleBackColor = false;
            // 
            // btnCustomers
            // 
            this.btnCustomers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(84)))), ((int)(((byte)(129)))));
            this.btnCustomers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCustomers.FlatAppearance.BorderSize = 0;
            this.btnCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomers.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomers.ForeColor = System.Drawing.Color.White;
            this.btnCustomers.Image = global::EShiftOperationsManager.Properties.Resources.Customer_icon_png;
            this.btnCustomers.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCustomers.Location = new System.Drawing.Point(30, 156);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(183, 34);
            this.btnCustomers.TabIndex = 15;
            this.btnCustomers.Text = "Customers";
            this.btnCustomers.UseVisualStyleBackColor = false;
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(84)))), ((int)(((byte)(129)))));
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Image = global::EShiftOperationsManager.Properties.Resources.home_icon;
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnDashboard.Location = new System.Drawing.Point(30, 116);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(183, 34);
            this.btnDashboard.TabIndex = 14;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = false;
            // 
            // lblBrandSubtitle2
            // 
            this.lblBrandSubtitle2.AutoSize = true;
            this.lblBrandSubtitle2.BackColor = System.Drawing.Color.Transparent;
            this.lblBrandSubtitle2.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrandSubtitle2.ForeColor = System.Drawing.Color.White;
            this.lblBrandSubtitle2.Location = new System.Drawing.Point(105, 69);
            this.lblBrandSubtitle2.Name = "lblBrandSubtitle2";
            this.lblBrandSubtitle2.Size = new System.Drawing.Size(131, 12);
            this.lblBrandSubtitle2.TabIndex = 13;
            this.lblBrandSubtitle2.Text = "M A N A G E M E N T S Y S T E M";
            // 
            // lblBrandSubtitle
            // 
            this.lblBrandSubtitle.AutoSize = true;
            this.lblBrandSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblBrandSubtitle.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrandSubtitle.ForeColor = System.Drawing.Color.White;
            this.lblBrandSubtitle.Location = new System.Drawing.Point(105, 57);
            this.lblBrandSubtitle.Name = "lblBrandSubtitle";
            this.lblBrandSubtitle.Size = new System.Drawing.Size(108, 12);
            this.lblBrandSubtitle.TabIndex = 12;
            this.lblBrandSubtitle.Text = "T R A N S P O R T A T I O N";
            // 
            // lblLoginHeading3
            // 
            this.lblLoginHeading3.AutoSize = true;
            this.lblLoginHeading3.BackColor = System.Drawing.Color.Transparent;
            this.lblLoginHeading3.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginHeading3.ForeColor = System.Drawing.Color.White;
            this.lblLoginHeading3.Location = new System.Drawing.Point(135, 22);
            this.lblLoginHeading3.Name = "lblLoginHeading3";
            this.lblLoginHeading3.Size = new System.Drawing.Size(78, 37);
            this.lblLoginHeading3.TabIndex = 11;
            this.lblLoginHeading3.Text = "Shift";
            // 
            // lblLoginHeading2
            // 
            this.lblLoginHeading2.AutoSize = true;
            this.lblLoginHeading2.BackColor = System.Drawing.Color.Transparent;
            this.lblLoginHeading2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginHeading2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(145)))), ((int)(((byte)(203)))));
            this.lblLoginHeading2.Location = new System.Drawing.Point(100, 22);
            this.lblLoginHeading2.Name = "lblLoginHeading2";
            this.lblLoginHeading2.Size = new System.Drawing.Size(43, 37);
            this.lblLoginHeading2.TabIndex = 10;
            this.lblLoginHeading2.Text = "e-";
            // 
            // lblLogo
            // 
            this.lblLogo.BackColor = System.Drawing.Color.Transparent;
            this.lblLogo.Image = global::EShiftOperationsManager.Properties.Resources.logo_truck_png;
            this.lblLogo.Location = new System.Drawing.Point(11, 12);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(88, 69);
            this.lblLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.lblLogo.TabIndex = 1;
            this.lblLogo.TabStop = false;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlMain.Controls.Add(this.pnlTransportJobs);
            this.pnlMain.Controls.Add(this.pnlWelcomeAdmin);
            this.pnlMain.Controls.Add(this.pnlSelectedJobDetails);
            this.pnlMain.Controls.Add(this.pnlJobSearch);
            this.pnlMain.Controls.Add(this.lblJobManagementSubtitle);
            this.pnlMain.Controls.Add(this.lblJobManagementTitle);
            this.pnlMain.Location = new System.Drawing.Point(267, 22);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(936, 658);
            this.pnlMain.TabIndex = 47;
            // 
            // pnlTransportJobs
            // 
            this.pnlTransportJobs.Controls.Add(this.dgvTransportJobs);
            this.pnlTransportJobs.Controls.Add(this.lblTransportJobsTitle);
            this.pnlTransportJobs.Controls.Add(this.picTransportJobsIcon);
            this.pnlTransportJobs.Location = new System.Drawing.Point(18, 200);
            this.pnlTransportJobs.Name = "pnlTransportJobs";
            this.pnlTransportJobs.Size = new System.Drawing.Size(904, 156);
            this.pnlTransportJobs.TabIndex = 38;
            // 
            // dgvTransportJobs
            // 
            this.dgvTransportJobs.AllowUserToAddRows = false;
            this.dgvTransportJobs.AllowUserToDeleteRows = false;
            this.dgvTransportJobs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTransportJobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransportJobs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colJobNo,
            this.colDestination,
            this.colCustomer,
            this.colPickup,
            this.colRequestDate,
            this.colStatus});
            this.dgvTransportJobs.Location = new System.Drawing.Point(20, 40);
            this.dgvTransportJobs.MultiSelect = false;
            this.dgvTransportJobs.Name = "dgvTransportJobs";
            this.dgvTransportJobs.ReadOnly = true;
            this.dgvTransportJobs.RowHeadersVisible = false;
            this.dgvTransportJobs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransportJobs.Size = new System.Drawing.Size(866, 103);
            this.dgvTransportJobs.TabIndex = 35;
            // 
            // colJobNo
            // 
            this.colJobNo.HeaderText = "Job No";
            this.colJobNo.Name = "colJobNo";
            this.colJobNo.ReadOnly = true;
            // 
            // colDestination
            // 
            this.colDestination.HeaderText = "Destination";
            this.colDestination.Name = "colDestination";
            this.colDestination.ReadOnly = true;
            // 
            // colCustomer
            // 
            this.colCustomer.HeaderText = "Customer";
            this.colCustomer.Name = "colCustomer";
            this.colCustomer.ReadOnly = true;
            // 
            // colPickup
            // 
            this.colPickup.HeaderText = "Pickup";
            this.colPickup.Name = "colPickup";
            this.colPickup.ReadOnly = true;
            // 
            // colRequestDate
            // 
            this.colRequestDate.HeaderText = "Request Date";
            this.colRequestDate.Name = "colRequestDate";
            this.colRequestDate.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // lblTransportJobsTitle
            // 
            this.lblTransportJobsTitle.AutoSize = true;
            this.lblTransportJobsTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTransportJobsTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransportJobsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.lblTransportJobsTitle.Location = new System.Drawing.Point(41, 10);
            this.lblTransportJobsTitle.Name = "lblTransportJobsTitle";
            this.lblTransportJobsTitle.Size = new System.Drawing.Size(99, 17);
            this.lblTransportJobsTitle.TabIndex = 34;
            this.lblTransportJobsTitle.Text = "Transport Jobs";
            // 
            // picTransportJobsIcon
            // 
            this.picTransportJobsIcon.BackColor = System.Drawing.Color.Transparent;
            this.picTransportJobsIcon.Image = global::EShiftOperationsManager.Properties.Resources.T_Requesticon_png;
            this.picTransportJobsIcon.Location = new System.Drawing.Point(7, 10);
            this.picTransportJobsIcon.Name = "picTransportJobsIcon";
            this.picTransportJobsIcon.Size = new System.Drawing.Size(24, 24);
            this.picTransportJobsIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTransportJobsIcon.TabIndex = 33;
            this.picTransportJobsIcon.TabStop = false;
            // 
            // pnlWelcomeAdmin
            // 
            this.pnlWelcomeAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            this.pnlWelcomeAdmin.Controls.Add(this.lblWelcomeDescription2);
            this.pnlWelcomeAdmin.Controls.Add(this.label1);
            this.pnlWelcomeAdmin.Controls.Add(this.lblWelcomeDescription);
            this.pnlWelcomeAdmin.Controls.Add(this.picWelcomeAdmin);
            this.pnlWelcomeAdmin.Controls.Add(this.lblWelcomeAdmin);
            this.pnlWelcomeAdmin.Location = new System.Drawing.Point(635, 8);
            this.pnlWelcomeAdmin.Name = "pnlWelcomeAdmin";
            this.pnlWelcomeAdmin.Size = new System.Drawing.Size(287, 62);
            this.pnlWelcomeAdmin.TabIndex = 37;
            // 
            // lblWelcomeDescription2
            // 
            this.lblWelcomeDescription2.AutoSize = true;
            this.lblWelcomeDescription2.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcomeDescription2.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcomeDescription2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(75)))), ((int)(((byte)(90)))));
            this.lblWelcomeDescription2.Location = new System.Drawing.Point(54, 38);
            this.lblWelcomeDescription2.Name = "lblWelcomeDescription2";
            this.lblWelcomeDescription2.Size = new System.Drawing.Size(148, 12);
            this.lblWelcomeDescription2.TabIndex = 33;
            this.lblWelcomeDescription2.Text = "services run smoothly and efficiently.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(75)))), ((int)(((byte)(90)))));
            this.label1.Location = new System.Drawing.Point(54, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 12);
            this.label1.TabIndex = 32;
            this.label1.Text = "Oversee transportation operations and ensure e-Shift";
            // 
            // lblWelcomeDescription
            // 
            this.lblWelcomeDescription.AutoSize = true;
            this.lblWelcomeDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcomeDescription.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcomeDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(75)))), ((int)(((byte)(90)))));
            this.lblWelcomeDescription.Location = new System.Drawing.Point(54, 26);
            this.lblWelcomeDescription.Name = "lblWelcomeDescription";
            this.lblWelcomeDescription.Size = new System.Drawing.Size(161, 12);
            this.lblWelcomeDescription.TabIndex = 31;
            this.lblWelcomeDescription.Text = "Manage transport jobs and keep e-Shift";
            // 
            // picWelcomeAdmin
            // 
            this.picWelcomeAdmin.BackColor = System.Drawing.Color.Transparent;
            this.picWelcomeAdmin.Image = global::EShiftOperationsManager.Properties.Resources.ADMINNEWICON1;
            this.picWelcomeAdmin.Location = new System.Drawing.Point(3, 3);
            this.picWelcomeAdmin.Name = "picWelcomeAdmin";
            this.picWelcomeAdmin.Size = new System.Drawing.Size(45, 56);
            this.picWelcomeAdmin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picWelcomeAdmin.TabIndex = 27;
            this.picWelcomeAdmin.TabStop = false;
            // 
            // lblWelcomeAdmin
            // 
            this.lblWelcomeAdmin.AutoSize = true;
            this.lblWelcomeAdmin.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcomeAdmin.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcomeAdmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.lblWelcomeAdmin.Location = new System.Drawing.Point(54, 9);
            this.lblWelcomeAdmin.Name = "lblWelcomeAdmin";
            this.lblWelcomeAdmin.Size = new System.Drawing.Size(96, 13);
            this.lblWelcomeAdmin.TabIndex = 30;
            this.lblWelcomeAdmin.Text = "Welcome, Admin";
            // 
            // pnlSelectedJobDetails
            // 
            this.pnlSelectedJobDetails.Controls.Add(this.txtAdminRemarks);
            this.pnlSelectedJobDetails.Controls.Add(this.lblAdminRemarks);
            this.pnlSelectedJobDetails.Controls.Add(this.btnAssignTransportUnit);
            this.pnlSelectedJobDetails.Controls.Add(this.btnUpdateJob);
            this.pnlSelectedJobDetails.Controls.Add(this.pnlJobInformationValues);
            this.pnlSelectedJobDetails.Controls.Add(this.btnDeclineJob);
            this.pnlSelectedJobDetails.Controls.Add(this.btnAcceptJob);
            this.pnlSelectedJobDetails.Controls.Add(this.pnlJobInformation);
            this.pnlSelectedJobDetails.Controls.Add(this.picSelectedJobDetailsIcon);
            this.pnlSelectedJobDetails.Controls.Add(this.lblSelectedJobDetailsTitle);
            this.pnlSelectedJobDetails.Location = new System.Drawing.Point(25, 377);
            this.pnlSelectedJobDetails.Name = "pnlSelectedJobDetails";
            this.pnlSelectedJobDetails.Size = new System.Drawing.Size(879, 254);
            this.pnlSelectedJobDetails.TabIndex = 14;
            this.pnlSelectedJobDetails.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSelectedJobDetails_Paint);
            // 
            // txtAdminRemarks
            // 
            this.txtAdminRemarks.Location = new System.Drawing.Point(442, 183);
            this.txtAdminRemarks.MaxLength = 500;
            this.txtAdminRemarks.Multiline = true;
            this.txtAdminRemarks.Name = "txtAdminRemarks";
            this.txtAdminRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAdminRemarks.Size = new System.Drawing.Size(401, 20);
            this.txtAdminRemarks.TabIndex = 62;
            // 
            // lblAdminRemarks
            // 
            this.lblAdminRemarks.AutoSize = true;
            this.lblAdminRemarks.BackColor = System.Drawing.Color.Transparent;
            this.lblAdminRemarks.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.lblAdminRemarks.Location = new System.Drawing.Point(439, 157);
            this.lblAdminRemarks.Name = "lblAdminRemarks";
            this.lblAdminRemarks.Size = new System.Drawing.Size(105, 17);
            this.lblAdminRemarks.TabIndex = 61;
            this.lblAdminRemarks.Text = "Admin Remarks";
            // 
            // btnAssignTransportUnit
            // 
            this.btnAssignTransportUnit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(248)))));
            this.btnAssignTransportUnit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAssignTransportUnit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAssignTransportUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssignTransportUnit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssignTransportUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(28)))), ((int)(((byte)(76)))));
            this.btnAssignTransportUnit.Image = global::EShiftOperationsManager.Properties.Resources.ASSIGNUNITICON_png;
            this.btnAssignTransportUnit.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAssignTransportUnit.Location = new System.Drawing.Point(655, 105);
            this.btnAssignTransportUnit.Name = "btnAssignTransportUnit";
            this.btnAssignTransportUnit.Size = new System.Drawing.Size(188, 35);
            this.btnAssignTransportUnit.TabIndex = 60;
            this.btnAssignTransportUnit.Text = "Assign Unit";
            this.btnAssignTransportUnit.UseVisualStyleBackColor = false;
            // 
            // btnUpdateJob
            // 
            this.btnUpdateJob.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(246)))));
            this.btnUpdateJob.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateJob.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnUpdateJob.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateJob.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateJob.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.btnUpdateJob.Image = global::EShiftOperationsManager.Properties.Resources.UPDATEBUTTOICON2;
            this.btnUpdateJob.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnUpdateJob.Location = new System.Drawing.Point(442, 106);
            this.btnUpdateJob.Name = "btnUpdateJob";
            this.btnUpdateJob.Size = new System.Drawing.Size(188, 35);
            this.btnUpdateJob.TabIndex = 59;
            this.btnUpdateJob.Text = "Update";
            this.btnUpdateJob.UseVisualStyleBackColor = false;
            // 
            // pnlJobInformationValues
            // 
            this.pnlJobInformationValues.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlJobInformationValues.Controls.Add(this.lblValueJobStatus);
            this.pnlJobInformationValues.Controls.Add(this.lblValueAssignedTransportUnit);
            this.pnlJobInformationValues.Controls.Add(this.lblValueLoadDetails);
            this.pnlJobInformationValues.Controls.Add(this.lblValueDestination);
            this.pnlJobInformationValues.Controls.Add(this.lblValueRequestedTransportDate);
            this.pnlJobInformationValues.Controls.Add(this.lblValueRequestDate);
            this.pnlJobInformationValues.Controls.Add(this.lblValueCustomer);
            this.pnlJobInformationValues.Controls.Add(this.lblValueJobNo);
            this.pnlJobInformationValues.Controls.Add(this.lblValuePickupLocation);
            this.pnlJobInformationValues.Location = new System.Drawing.Point(183, 57);
            this.pnlJobInformationValues.Name = "pnlJobInformationValues";
            this.pnlJobInformationValues.Size = new System.Drawing.Size(164, 166);
            this.pnlJobInformationValues.TabIndex = 50;
            // 
            // lblValueJobStatus
            // 
            this.lblValueJobStatus.AutoSize = true;
            this.lblValueJobStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblValueJobStatus.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValueJobStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.lblValueJobStatus.Location = new System.Drawing.Point(10, 136);
            this.lblValueJobStatus.Name = "lblValueJobStatus";
            this.lblValueJobStatus.Size = new System.Drawing.Size(38, 13);
            this.lblValueJobStatus.TabIndex = 72;
            this.lblValueJobStatus.Text = "label1";
            // 
            // lblValueAssignedTransportUnit
            // 
            this.lblValueAssignedTransportUnit.AutoSize = true;
            this.lblValueAssignedTransportUnit.BackColor = System.Drawing.Color.Transparent;
            this.lblValueAssignedTransportUnit.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValueAssignedTransportUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.lblValueAssignedTransportUnit.Location = new System.Drawing.Point(10, 120);
            this.lblValueAssignedTransportUnit.Name = "lblValueAssignedTransportUnit";
            this.lblValueAssignedTransportUnit.Size = new System.Drawing.Size(38, 13);
            this.lblValueAssignedTransportUnit.TabIndex = 71;
            this.lblValueAssignedTransportUnit.Text = "label1";
            // 
            // lblValueLoadDetails
            // 
            this.lblValueLoadDetails.AutoSize = true;
            this.lblValueLoadDetails.BackColor = System.Drawing.Color.Transparent;
            this.lblValueLoadDetails.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValueLoadDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.lblValueLoadDetails.Location = new System.Drawing.Point(10, 107);
            this.lblValueLoadDetails.Name = "lblValueLoadDetails";
            this.lblValueLoadDetails.Size = new System.Drawing.Size(38, 13);
            this.lblValueLoadDetails.TabIndex = 70;
            this.lblValueLoadDetails.Text = "label1";
            // 
            // lblValueDestination
            // 
            this.lblValueDestination.AutoSize = true;
            this.lblValueDestination.BackColor = System.Drawing.Color.Transparent;
            this.lblValueDestination.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValueDestination.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.lblValueDestination.Location = new System.Drawing.Point(10, 93);
            this.lblValueDestination.Name = "lblValueDestination";
            this.lblValueDestination.Size = new System.Drawing.Size(38, 13);
            this.lblValueDestination.TabIndex = 69;
            this.lblValueDestination.Text = "label1";
            // 
            // lblValueRequestedTransportDate
            // 
            this.lblValueRequestedTransportDate.AutoSize = true;
            this.lblValueRequestedTransportDate.BackColor = System.Drawing.Color.Transparent;
            this.lblValueRequestedTransportDate.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValueRequestedTransportDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.lblValueRequestedTransportDate.Location = new System.Drawing.Point(10, 61);
            this.lblValueRequestedTransportDate.Name = "lblValueRequestedTransportDate";
            this.lblValueRequestedTransportDate.Size = new System.Drawing.Size(38, 13);
            this.lblValueRequestedTransportDate.TabIndex = 67;
            this.lblValueRequestedTransportDate.Text = "label1";
            // 
            // lblValueRequestDate
            // 
            this.lblValueRequestDate.AutoSize = true;
            this.lblValueRequestDate.BackColor = System.Drawing.Color.Transparent;
            this.lblValueRequestDate.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValueRequestDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.lblValueRequestDate.Location = new System.Drawing.Point(10, 48);
            this.lblValueRequestDate.Name = "lblValueRequestDate";
            this.lblValueRequestDate.Size = new System.Drawing.Size(38, 13);
            this.lblValueRequestDate.TabIndex = 66;
            this.lblValueRequestDate.Text = "label1";
            // 
            // lblValueCustomer
            // 
            this.lblValueCustomer.AutoSize = true;
            this.lblValueCustomer.BackColor = System.Drawing.Color.Transparent;
            this.lblValueCustomer.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValueCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.lblValueCustomer.Location = new System.Drawing.Point(10, 35);
            this.lblValueCustomer.Name = "lblValueCustomer";
            this.lblValueCustomer.Size = new System.Drawing.Size(38, 13);
            this.lblValueCustomer.TabIndex = 65;
            this.lblValueCustomer.Text = "label1";
            // 
            // lblValueJobNo
            // 
            this.lblValueJobNo.AutoSize = true;
            this.lblValueJobNo.BackColor = System.Drawing.Color.Transparent;
            this.lblValueJobNo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValueJobNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.lblValueJobNo.Location = new System.Drawing.Point(10, 22);
            this.lblValueJobNo.Name = "lblValueJobNo";
            this.lblValueJobNo.Size = new System.Drawing.Size(38, 13);
            this.lblValueJobNo.TabIndex = 64;
            this.lblValueJobNo.Text = "label1";
            // 
            // lblValuePickupLocation
            // 
            this.lblValuePickupLocation.AutoSize = true;
            this.lblValuePickupLocation.BackColor = System.Drawing.Color.Transparent;
            this.lblValuePickupLocation.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValuePickupLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.lblValuePickupLocation.Location = new System.Drawing.Point(10, 78);
            this.lblValuePickupLocation.Name = "lblValuePickupLocation";
            this.lblValuePickupLocation.Size = new System.Drawing.Size(38, 13);
            this.lblValuePickupLocation.TabIndex = 68;
            this.lblValuePickupLocation.Text = "label1";
            // 
            // btnDeclineJob
            // 
            this.btnDeclineJob.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(237)))));
            this.btnDeclineJob.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeclineJob.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnDeclineJob.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeclineJob.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeclineJob.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.btnDeclineJob.Image = global::EShiftOperationsManager.Properties.Resources.DECLINEBUTTONICON_png;
            this.btnDeclineJob.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnDeclineJob.Location = new System.Drawing.Point(655, 57);
            this.btnDeclineJob.Name = "btnDeclineJob";
            this.btnDeclineJob.Size = new System.Drawing.Size(188, 35);
            this.btnDeclineJob.TabIndex = 49;
            this.btnDeclineJob.Text = "Decline";
            this.btnDeclineJob.UseVisualStyleBackColor = false;
            // 
            // btnAcceptJob
            // 
            this.btnAcceptJob.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(145)))), ((int)(((byte)(203)))));
            this.btnAcceptJob.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAcceptJob.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcceptJob.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcceptJob.ForeColor = System.Drawing.Color.White;
            this.btnAcceptJob.Image = global::EShiftOperationsManager.Properties.Resources.ACCEPTBUTTONICON2_png;
            this.btnAcceptJob.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAcceptJob.Location = new System.Drawing.Point(442, 57);
            this.btnAcceptJob.Name = "btnAcceptJob";
            this.btnAcceptJob.Size = new System.Drawing.Size(188, 35);
            this.btnAcceptJob.TabIndex = 46;
            this.btnAcceptJob.Text = "Accept";
            this.btnAcceptJob.UseVisualStyleBackColor = false;
            // 
            // pnlJobInformation
            // 
            this.pnlJobInformation.BackColor = System.Drawing.Color.Lavender;
            this.pnlJobInformation.Controls.Add(this.lblJobStatus);
            this.pnlJobInformation.Controls.Add(this.lblAssignedTransportUnit);
            this.pnlJobInformation.Controls.Add(this.lblLoadDetails);
            this.pnlJobInformation.Controls.Add(this.lblRequestedTransportDate);
            this.pnlJobInformation.Controls.Add(this.lblRequestDate);
            this.pnlJobInformation.Controls.Add(this.lblCustomer);
            this.pnlJobInformation.Controls.Add(this.lblDestination);
            this.pnlJobInformation.Controls.Add(this.lblJobNo);
            this.pnlJobInformation.Controls.Add(this.lblPickupLocation);
            this.pnlJobInformation.Location = new System.Drawing.Point(20, 57);
            this.pnlJobInformation.Name = "pnlJobInformation";
            this.pnlJobInformation.Size = new System.Drawing.Size(167, 166);
            this.pnlJobInformation.TabIndex = 33;
            // 
            // lblJobStatus
            // 
            this.lblJobStatus.AutoSize = true;
            this.lblJobStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblJobStatus.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.lblJobStatus.Location = new System.Drawing.Point(16, 133);
            this.lblJobStatus.Name = "lblJobStatus";
            this.lblJobStatus.Size = new System.Drawing.Size(39, 13);
            this.lblJobStatus.TabIndex = 61;
            this.lblJobStatus.Text = "Status";
            // 
            // lblAssignedTransportUnit
            // 
            this.lblAssignedTransportUnit.AutoSize = true;
            this.lblAssignedTransportUnit.BackColor = System.Drawing.Color.Transparent;
            this.lblAssignedTransportUnit.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssignedTransportUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.lblAssignedTransportUnit.Location = new System.Drawing.Point(16, 117);
            this.lblAssignedTransportUnit.Name = "lblAssignedTransportUnit";
            this.lblAssignedTransportUnit.Size = new System.Drawing.Size(132, 13);
            this.lblAssignedTransportUnit.TabIndex = 60;
            this.lblAssignedTransportUnit.Text = "Assigned Transport Unit";
            // 
            // lblLoadDetails
            // 
            this.lblLoadDetails.BackColor = System.Drawing.Color.Transparent;
            this.lblLoadDetails.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoadDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.lblLoadDetails.Location = new System.Drawing.Point(16, 104);
            this.lblLoadDetails.Name = "lblLoadDetails";
            this.lblLoadDetails.Size = new System.Drawing.Size(67, 13);
            this.lblLoadDetails.TabIndex = 58;
            this.lblLoadDetails.Text = "Load Details";
            // 
            // lblRequestedTransportDate
            // 
            this.lblRequestedTransportDate.AutoSize = true;
            this.lblRequestedTransportDate.BackColor = System.Drawing.Color.Transparent;
            this.lblRequestedTransportDate.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequestedTransportDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.lblRequestedTransportDate.Location = new System.Drawing.Point(16, 61);
            this.lblRequestedTransportDate.Name = "lblRequestedTransportDate";
            this.lblRequestedTransportDate.Size = new System.Drawing.Size(141, 13);
            this.lblRequestedTransportDate.TabIndex = 32;
            this.lblRequestedTransportDate.Text = "Requested Transport Date";
            // 
            // lblRequestDate
            // 
            this.lblRequestDate.AutoSize = true;
            this.lblRequestDate.BackColor = System.Drawing.Color.Transparent;
            this.lblRequestDate.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequestDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.lblRequestDate.Location = new System.Drawing.Point(16, 48);
            this.lblRequestDate.Name = "lblRequestDate";
            this.lblRequestDate.Size = new System.Drawing.Size(76, 13);
            this.lblRequestDate.TabIndex = 31;
            this.lblRequestDate.Text = "Request Date";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.BackColor = System.Drawing.Color.Transparent;
            this.lblCustomer.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.lblCustomer.Location = new System.Drawing.Point(16, 35);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(57, 13);
            this.lblCustomer.TabIndex = 30;
            this.lblCustomer.Text = "Customer";
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.BackColor = System.Drawing.Color.Transparent;
            this.lblDestination.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDestination.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.lblDestination.Location = new System.Drawing.Point(16, 91);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(67, 13);
            this.lblDestination.TabIndex = 30;
            this.lblDestination.Text = "Destination";
            // 
            // lblJobNo
            // 
            this.lblJobNo.AutoSize = true;
            this.lblJobNo.BackColor = System.Drawing.Color.Transparent;
            this.lblJobNo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.lblJobNo.Location = new System.Drawing.Point(16, 22);
            this.lblJobNo.Name = "lblJobNo";
            this.lblJobNo.Size = new System.Drawing.Size(45, 13);
            this.lblJobNo.TabIndex = 29;
            this.lblJobNo.Text = "Job No";
            // 
            // lblPickupLocation
            // 
            this.lblPickupLocation.AutoSize = true;
            this.lblPickupLocation.BackColor = System.Drawing.Color.Transparent;
            this.lblPickupLocation.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPickupLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.lblPickupLocation.Location = new System.Drawing.Point(16, 78);
            this.lblPickupLocation.Name = "lblPickupLocation";
            this.lblPickupLocation.Size = new System.Drawing.Size(90, 13);
            this.lblPickupLocation.TabIndex = 29;
            this.lblPickupLocation.Text = "Pickup Location";
            // 
            // picSelectedJobDetailsIcon
            // 
            this.picSelectedJobDetailsIcon.BackColor = System.Drawing.Color.Transparent;
            this.picSelectedJobDetailsIcon.Image = global::EShiftOperationsManager.Properties.Resources.T_Requesticon_png;
            this.picSelectedJobDetailsIcon.Location = new System.Drawing.Point(17, 21);
            this.picSelectedJobDetailsIcon.Name = "picSelectedJobDetailsIcon";
            this.picSelectedJobDetailsIcon.Size = new System.Drawing.Size(24, 24);
            this.picSelectedJobDetailsIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSelectedJobDetailsIcon.TabIndex = 32;
            this.picSelectedJobDetailsIcon.TabStop = false;
            // 
            // lblSelectedJobDetailsTitle
            // 
            this.lblSelectedJobDetailsTitle.AutoSize = true;
            this.lblSelectedJobDetailsTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSelectedJobDetailsTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedJobDetailsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.lblSelectedJobDetailsTitle.Location = new System.Drawing.Point(47, 21);
            this.lblSelectedJobDetailsTitle.Name = "lblSelectedJobDetailsTitle";
            this.lblSelectedJobDetailsTitle.Size = new System.Drawing.Size(132, 17);
            this.lblSelectedJobDetailsTitle.TabIndex = 30;
            this.lblSelectedJobDetailsTitle.Text = "Selected Job Details";
            // 
            // pnlJobSearch
            // 
            this.pnlJobSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(246)))));
            this.pnlJobSearch.Controls.Add(this.btnSearchJobs);
            this.pnlJobSearch.Controls.Add(this.btnClearJobSearch);
            this.pnlJobSearch.Controls.Add(this.cmbFilterJobStatus);
            this.pnlJobSearch.Controls.Add(this.lblFilterJobStatus);
            this.pnlJobSearch.Controls.Add(this.picJobSearchIcon);
            this.pnlJobSearch.Controls.Add(this.txtSearchJobNo);
            this.pnlJobSearch.Controls.Add(this.lblSearchJobNo);
            this.pnlJobSearch.Location = new System.Drawing.Point(18, 90);
            this.pnlJobSearch.Name = "pnlJobSearch";
            this.pnlJobSearch.Size = new System.Drawing.Size(904, 88);
            this.pnlJobSearch.TabIndex = 12;
            // 
            // btnSearchJobs
            // 
            this.btnSearchJobs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.btnSearchJobs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchJobs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchJobs.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchJobs.ForeColor = System.Drawing.Color.White;
            this.btnSearchJobs.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSearchJobs.Location = new System.Drawing.Point(578, 27);
            this.btnSearchJobs.Name = "btnSearchJobs";
            this.btnSearchJobs.Size = new System.Drawing.Size(146, 35);
            this.btnSearchJobs.TabIndex = 62;
            this.btnSearchJobs.Text = "Search";
            this.btnSearchJobs.UseVisualStyleBackColor = false;
            // 
            // btnClearJobSearch
            // 
            this.btnClearJobSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(246)))));
            this.btnClearJobSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearJobSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnClearJobSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearJobSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearJobSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.btnClearJobSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnClearJobSearch.Location = new System.Drawing.Point(730, 27);
            this.btnClearJobSearch.Name = "btnClearJobSearch";
            this.btnClearJobSearch.Size = new System.Drawing.Size(146, 35);
            this.btnClearJobSearch.TabIndex = 61;
            this.btnClearJobSearch.Text = "Clear";
            this.btnClearJobSearch.UseVisualStyleBackColor = false;
            // 
            // cmbFilterJobStatus
            // 
            this.cmbFilterJobStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterJobStatus.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFilterJobStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.cmbFilterJobStatus.FormattingEnabled = true;
            this.cmbFilterJobStatus.Items.AddRange(new object[] {
            "All Status",
            "Pending",
            "Accepted",
            "Declined",
            "In Progress",
            "Completed"});
            this.cmbFilterJobStatus.Location = new System.Drawing.Point(371, 36);
            this.cmbFilterJobStatus.Name = "cmbFilterJobStatus";
            this.cmbFilterJobStatus.Size = new System.Drawing.Size(200, 21);
            this.cmbFilterJobStatus.TabIndex = 13;
            // 
            // lblFilterJobStatus
            // 
            this.lblFilterJobStatus.AutoSize = true;
            this.lblFilterJobStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblFilterJobStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilterJobStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.lblFilterJobStatus.Location = new System.Drawing.Point(368, 14);
            this.lblFilterJobStatus.Name = "lblFilterJobStatus";
            this.lblFilterJobStatus.Size = new System.Drawing.Size(90, 15);
            this.lblFilterJobStatus.TabIndex = 32;
            this.lblFilterJobStatus.Text = "Filter by Status";
            // 
            // picJobSearchIcon
            // 
            this.picJobSearchIcon.BackColor = System.Drawing.Color.Transparent;
            this.picJobSearchIcon.Image = global::EShiftOperationsManager.Properties.Resources.SERCHICON1;
            this.picJobSearchIcon.Location = new System.Drawing.Point(7, 35);
            this.picJobSearchIcon.Name = "picJobSearchIcon";
            this.picJobSearchIcon.Size = new System.Drawing.Size(24, 22);
            this.picJobSearchIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picJobSearchIcon.TabIndex = 31;
            this.picJobSearchIcon.TabStop = false;
            // 
            // txtSearchJobNo
            // 
            this.txtSearchJobNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchJobNo.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchJobNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.txtSearchJobNo.Location = new System.Drawing.Point(37, 35);
            this.txtSearchJobNo.Name = "txtSearchJobNo";
            this.txtSearchJobNo.Size = new System.Drawing.Size(328, 22);
            this.txtSearchJobNo.TabIndex = 30;
            // 
            // lblSearchJobNo
            // 
            this.lblSearchJobNo.AutoSize = true;
            this.lblSearchJobNo.BackColor = System.Drawing.Color.Transparent;
            this.lblSearchJobNo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchJobNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.lblSearchJobNo.Location = new System.Drawing.Point(17, 14);
            this.lblSearchJobNo.Name = "lblSearchJobNo";
            this.lblSearchJobNo.Size = new System.Drawing.Size(102, 15);
            this.lblSearchJobNo.TabIndex = 29;
            this.lblSearchJobNo.Text = "Search by Job No";
            // 
            // lblJobManagementSubtitle
            // 
            this.lblJobManagementSubtitle.AutoSize = true;
            this.lblJobManagementSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblJobManagementSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobManagementSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.lblJobManagementSubtitle.Location = new System.Drawing.Point(15, 38);
            this.lblJobManagementSubtitle.Name = "lblJobManagementSubtitle";
            this.lblJobManagementSubtitle.Size = new System.Drawing.Size(373, 15);
            this.lblJobManagementSubtitle.TabIndex = 11;
            this.lblJobManagementSubtitle.Text = "Manage customer transport jobs, review details and update job status";
            // 
            // lblJobManagementTitle
            // 
            this.lblJobManagementTitle.AutoSize = true;
            this.lblJobManagementTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblJobManagementTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobManagementTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.lblJobManagementTitle.Location = new System.Drawing.Point(13, 8);
            this.lblJobManagementTitle.Name = "lblJobManagementTitle";
            this.lblJobManagementTitle.Size = new System.Drawing.Size(184, 30);
            this.lblJobManagementTitle.TabIndex = 10;
            this.lblJobManagementTitle.Text = "Job Management";
            // 
            // FrmJobManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 749);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlSidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmJobManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "e-Shift - Transportation Management System";
            this.Load += new System.EventHandler(this.FrmJobManagement_Load);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picleft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLogo)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTransportJobs.ResumeLayout(false);
            this.pnlTransportJobs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransportJobs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTransportJobsIcon)).EndInit();
            this.pnlWelcomeAdmin.ResumeLayout(false);
            this.pnlWelcomeAdmin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWelcomeAdmin)).EndInit();
            this.pnlSelectedJobDetails.ResumeLayout(false);
            this.pnlSelectedJobDetails.PerformLayout();
            this.pnlJobInformationValues.ResumeLayout(false);
            this.pnlJobInformationValues.PerformLayout();
            this.pnlJobInformation.ResumeLayout(false);
            this.pnlJobInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSelectedJobDetailsIcon)).EndInit();
            this.pnlJobSearch.ResumeLayout(false);
            this.pnlJobSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picJobSearchIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        internal System.Windows.Forms.PictureBox picleft;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnManageJobAssignments;
        private System.Windows.Forms.Button btnTransportUnits;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnJobs;
        private System.Windows.Forms.Button btnAdmins;
        private System.Windows.Forms.Button btnCustomers;
        private System.Windows.Forms.Button btnDashboard;
        internal System.Windows.Forms.Label lblBrandSubtitle2;
        internal System.Windows.Forms.Label lblBrandSubtitle;
        internal System.Windows.Forms.Label lblLoginHeading3;
        internal System.Windows.Forms.Label lblLoginHeading2;
        internal System.Windows.Forms.PictureBox lblLogo;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlTransportJobs;
        private System.Windows.Forms.DataGridView dgvTransportJobs;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJobNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDestination;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPickup;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRequestDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        internal System.Windows.Forms.Label lblTransportJobsTitle;
        private System.Windows.Forms.PictureBox picTransportJobsIcon;
        private System.Windows.Forms.Panel pnlWelcomeAdmin;
        internal System.Windows.Forms.Label lblWelcomeDescription2;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label lblWelcomeDescription;
        private System.Windows.Forms.PictureBox picWelcomeAdmin;
        internal System.Windows.Forms.Label lblWelcomeAdmin;
        private System.Windows.Forms.Panel pnlSelectedJobDetails;
        private System.Windows.Forms.TextBox txtAdminRemarks;
        internal System.Windows.Forms.Label lblAdminRemarks;
        private System.Windows.Forms.Button btnAssignTransportUnit;
        private System.Windows.Forms.Button btnUpdateJob;
        private System.Windows.Forms.Panel pnlJobInformationValues;
        private System.Windows.Forms.Label lblValueJobStatus;
        private System.Windows.Forms.Label lblValueAssignedTransportUnit;
        private System.Windows.Forms.Label lblValueLoadDetails;
        private System.Windows.Forms.Label lblValueDestination;
        private System.Windows.Forms.Label lblValueRequestedTransportDate;
        private System.Windows.Forms.Label lblValueRequestDate;
        private System.Windows.Forms.Label lblValueCustomer;
        private System.Windows.Forms.Label lblValueJobNo;
        private System.Windows.Forms.Label lblValuePickupLocation;
        private System.Windows.Forms.Button btnDeclineJob;
        private System.Windows.Forms.Button btnAcceptJob;
        private System.Windows.Forms.Panel pnlJobInformation;
        internal System.Windows.Forms.Label lblJobStatus;
        internal System.Windows.Forms.Label lblAssignedTransportUnit;
        internal System.Windows.Forms.Label lblLoadDetails;
        internal System.Windows.Forms.Label lblRequestedTransportDate;
        internal System.Windows.Forms.Label lblRequestDate;
        internal System.Windows.Forms.Label lblCustomer;
        internal System.Windows.Forms.Label lblDestination;
        internal System.Windows.Forms.Label lblJobNo;
        internal System.Windows.Forms.Label lblPickupLocation;
        private System.Windows.Forms.PictureBox picSelectedJobDetailsIcon;
        internal System.Windows.Forms.Label lblSelectedJobDetailsTitle;
        private System.Windows.Forms.Panel pnlJobSearch;
        private System.Windows.Forms.Button btnSearchJobs;
        private System.Windows.Forms.Button btnClearJobSearch;
        private System.Windows.Forms.ComboBox cmbFilterJobStatus;
        internal System.Windows.Forms.Label lblFilterJobStatus;
        private System.Windows.Forms.PictureBox picJobSearchIcon;
        private System.Windows.Forms.TextBox txtSearchJobNo;
        internal System.Windows.Forms.Label lblSearchJobNo;
        internal System.Windows.Forms.Label lblJobManagementSubtitle;
        internal System.Windows.Forms.Label lblJobManagementTitle;
    }
}