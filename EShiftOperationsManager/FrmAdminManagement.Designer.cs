namespace EShiftOperationsManager
{
    partial class FrmAdminManagement
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
            this.pnlAdminDetails = new System.Windows.Forms.Panel();
            this.btnResetAdmin = new System.Windows.Forms.Button();
            this.cmbAdminRole = new System.Windows.Forms.ComboBox();
            this.lblAdminRole = new System.Windows.Forms.Label();
            this.btnClearCustomer = new System.Windows.Forms.Button();
            this.btnDeleteCustomer = new System.Windows.Forms.Button();
            this.btnUpdateCustomer = new System.Windows.Forms.Button();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.lblAdminFullName = new System.Windows.Forms.Label();
            this.picAdminDetailsIcon = new System.Windows.Forms.PictureBox();
            this.lblAdminDetailsTitle = new System.Windows.Forms.Label();
            this.txtAdminContact = new System.Windows.Forms.TextBox();
            this.txtAdminUsername = new System.Windows.Forms.TextBox();
            this.txtAdminFullName = new System.Windows.Forms.TextBox();
            this.txtAdminID = new System.Windows.Forms.TextBox();
            this.txtAdminEmail = new System.Windows.Forms.TextBox();
            this.txtAdminPassword = new System.Windows.Forms.TextBox();
            this.lblAdminContact = new System.Windows.Forms.Label();
            this.lblAdminEmail = new System.Windows.Forms.Label();
            this.lblAdminPassword = new System.Windows.Forms.Label();
            this.lblAdminUsername = new System.Windows.Forms.Label();
            this.lblAdminID = new System.Windows.Forms.Label();
            this.pnlAdminList = new System.Windows.Forms.Panel();
            this.picAdminSearchIcon = new System.Windows.Forms.PictureBox();
            this.txtSearchAdmin = new System.Windows.Forms.TextBox();
            this.dgvAdminList = new System.Windows.Forms.DataGridView();
            this.colAdminID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdminName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdminUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdminRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdminStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.picAdminListIcon = new System.Windows.Forms.PictureBox();
            this.lblAdminListTitle = new System.Windows.Forms.Label();
            this.lblAdminManagementSubtitle = new System.Windows.Forms.Label();
            this.lblAdminManagementTitle = new System.Windows.Forms.Label();
            this.pnlSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picleft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLogo)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.pnlAdminDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAdminDetailsIcon)).BeginInit();
            this.pnlAdminList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAdminSearchIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdminList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAdminListIcon)).BeginInit();
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
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(244, 721);
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
            this.pnlMain.Controls.Add(this.pnlAdminDetails);
            this.pnlMain.Controls.Add(this.pnlAdminList);
            this.pnlMain.Controls.Add(this.lblAdminManagementSubtitle);
            this.pnlMain.Controls.Add(this.lblAdminManagementTitle);
            this.pnlMain.Location = new System.Drawing.Point(263, 22);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(856, 655);
            this.pnlMain.TabIndex = 48;
            // 
            // pnlAdminDetails
            // 
            this.pnlAdminDetails.Controls.Add(this.btnResetAdmin);
            this.pnlAdminDetails.Controls.Add(this.cmbAdminRole);
            this.pnlAdminDetails.Controls.Add(this.lblAdminRole);
            this.pnlAdminDetails.Controls.Add(this.btnClearCustomer);
            this.pnlAdminDetails.Controls.Add(this.btnDeleteCustomer);
            this.pnlAdminDetails.Controls.Add(this.btnUpdateCustomer);
            this.pnlAdminDetails.Controls.Add(this.btnAddCustomer);
            this.pnlAdminDetails.Controls.Add(this.lblAdminFullName);
            this.pnlAdminDetails.Controls.Add(this.picAdminDetailsIcon);
            this.pnlAdminDetails.Controls.Add(this.lblAdminDetailsTitle);
            this.pnlAdminDetails.Controls.Add(this.txtAdminContact);
            this.pnlAdminDetails.Controls.Add(this.txtAdminUsername);
            this.pnlAdminDetails.Controls.Add(this.txtAdminFullName);
            this.pnlAdminDetails.Controls.Add(this.txtAdminID);
            this.pnlAdminDetails.Controls.Add(this.txtAdminEmail);
            this.pnlAdminDetails.Controls.Add(this.txtAdminPassword);
            this.pnlAdminDetails.Controls.Add(this.lblAdminContact);
            this.pnlAdminDetails.Controls.Add(this.lblAdminEmail);
            this.pnlAdminDetails.Controls.Add(this.lblAdminPassword);
            this.pnlAdminDetails.Controls.Add(this.lblAdminUsername);
            this.pnlAdminDetails.Controls.Add(this.lblAdminID);
            this.pnlAdminDetails.Location = new System.Drawing.Point(18, 100);
            this.pnlAdminDetails.Name = "pnlAdminDetails";
            this.pnlAdminDetails.Size = new System.Drawing.Size(822, 281);
            this.pnlAdminDetails.TabIndex = 45;
            // 
            // btnResetAdmin
            // 
            this.btnResetAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(246)))));
            this.btnResetAdmin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResetAdmin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnResetAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetAdmin.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetAdmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.btnResetAdmin.Image = global::EShiftOperationsManager.Properties.Resources.CLEARICON2_png;
            this.btnResetAdmin.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnResetAdmin.Location = new System.Drawing.Point(473, 222);
            this.btnResetAdmin.Name = "btnResetAdmin";
            this.btnResetAdmin.Size = new System.Drawing.Size(146, 35);
            this.btnResetAdmin.TabIndex = 63;
            this.btnResetAdmin.Text = "Reset";
            this.btnResetAdmin.UseVisualStyleBackColor = false;
            // 
            // cmbAdminRole
            // 
            this.cmbAdminRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAdminRole.FormattingEnabled = true;
            this.cmbAdminRole.Items.AddRange(new object[] {
            "Super Admin",
            "Admin",
            "Support Admin"});
            this.cmbAdminRole.Location = new System.Drawing.Point(566, 130);
            this.cmbAdminRole.Name = "cmbAdminRole";
            this.cmbAdminRole.Size = new System.Drawing.Size(200, 21);
            this.cmbAdminRole.TabIndex = 62;
            // 
            // lblAdminRole
            // 
            this.lblAdminRole.AutoSize = true;
            this.lblAdminRole.BackColor = System.Drawing.Color.Transparent;
            this.lblAdminRole.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.lblAdminRole.Location = new System.Drawing.Point(427, 132);
            this.lblAdminRole.Name = "lblAdminRole";
            this.lblAdminRole.Size = new System.Drawing.Size(113, 15);
            this.lblAdminRole.TabIndex = 61;
            this.lblAdminRole.Text = "Role / Access Level";
            // 
            // btnClearCustomer
            // 
            this.btnClearCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(246)))));
            this.btnClearCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearCustomer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnClearCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearCustomer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.btnClearCustomer.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnClearCustomer.Location = new System.Drawing.Point(625, 222);
            this.btnClearCustomer.Name = "btnClearCustomer";
            this.btnClearCustomer.Size = new System.Drawing.Size(146, 35);
            this.btnClearCustomer.TabIndex = 60;
            this.btnClearCustomer.Text = "Clear";
            this.btnClearCustomer.UseVisualStyleBackColor = false;
            // 
            // btnDeleteCustomer
            // 
            this.btnDeleteCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(246)))));
            this.btnDeleteCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteCustomer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDeleteCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteCustomer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.btnDeleteCustomer.Image = global::EShiftOperationsManager.Properties.Resources.DELETEBUTTONICON1;
            this.btnDeleteCustomer.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnDeleteCustomer.Location = new System.Drawing.Point(321, 222);
            this.btnDeleteCustomer.Name = "btnDeleteCustomer";
            this.btnDeleteCustomer.Size = new System.Drawing.Size(146, 35);
            this.btnDeleteCustomer.TabIndex = 59;
            this.btnDeleteCustomer.Text = "Delete";
            this.btnDeleteCustomer.UseVisualStyleBackColor = false;
            // 
            // btnUpdateCustomer
            // 
            this.btnUpdateCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(246)))));
            this.btnUpdateCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateCustomer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnUpdateCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateCustomer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.btnUpdateCustomer.Image = global::EShiftOperationsManager.Properties.Resources.UPDATEBUTTOICON1;
            this.btnUpdateCustomer.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnUpdateCustomer.Location = new System.Drawing.Point(169, 222);
            this.btnUpdateCustomer.Name = "btnUpdateCustomer";
            this.btnUpdateCustomer.Size = new System.Drawing.Size(146, 35);
            this.btnUpdateCustomer.TabIndex = 58;
            this.btnUpdateCustomer.Text = "Update";
            this.btnUpdateCustomer.UseVisualStyleBackColor = false;
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(145)))), ((int)(((byte)(203)))));
            this.btnAddCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCustomer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCustomer.ForeColor = System.Drawing.Color.White;
            this.btnAddCustomer.Image = global::EShiftOperationsManager.Properties.Resources.ADDBUTTONICON_png;
            this.btnAddCustomer.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAddCustomer.Location = new System.Drawing.Point(17, 222);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(146, 35);
            this.btnAddCustomer.TabIndex = 56;
            this.btnAddCustomer.Text = "Add";
            this.btnAddCustomer.UseVisualStyleBackColor = false;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // lblAdminFullName
            // 
            this.lblAdminFullName.AutoSize = true;
            this.lblAdminFullName.BackColor = System.Drawing.Color.Transparent;
            this.lblAdminFullName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminFullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.lblAdminFullName.Location = new System.Drawing.Point(15, 92);
            this.lblAdminFullName.Name = "lblAdminFullName";
            this.lblAdminFullName.Size = new System.Drawing.Size(62, 15);
            this.lblAdminFullName.TabIndex = 55;
            this.lblAdminFullName.Text = "Full Name";
            // 
            // picAdminDetailsIcon
            // 
            this.picAdminDetailsIcon.BackColor = System.Drawing.Color.Transparent;
            this.picAdminDetailsIcon.Image = global::EShiftOperationsManager.Properties.Resources.ADMINDETAILICON_png;
            this.picAdminDetailsIcon.Location = new System.Drawing.Point(18, 10);
            this.picAdminDetailsIcon.Name = "picAdminDetailsIcon";
            this.picAdminDetailsIcon.Size = new System.Drawing.Size(24, 24);
            this.picAdminDetailsIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAdminDetailsIcon.TabIndex = 54;
            this.picAdminDetailsIcon.TabStop = false;
            // 
            // lblAdminDetailsTitle
            // 
            this.lblAdminDetailsTitle.AutoSize = true;
            this.lblAdminDetailsTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblAdminDetailsTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminDetailsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.lblAdminDetailsTitle.Location = new System.Drawing.Point(48, 10);
            this.lblAdminDetailsTitle.Name = "lblAdminDetailsTitle";
            this.lblAdminDetailsTitle.Size = new System.Drawing.Size(96, 17);
            this.lblAdminDetailsTitle.TabIndex = 53;
            this.lblAdminDetailsTitle.Text = "Admin Details";
            // 
            // txtAdminContact
            // 
            this.txtAdminContact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdminContact.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdminContact.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.txtAdminContact.Location = new System.Drawing.Point(566, 45);
            this.txtAdminContact.Name = "txtAdminContact";
            this.txtAdminContact.Size = new System.Drawing.Size(200, 22);
            this.txtAdminContact.TabIndex = 52;
            // 
            // txtAdminUsername
            // 
            this.txtAdminUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdminUsername.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdminUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.txtAdminUsername.Location = new System.Drawing.Point(169, 131);
            this.txtAdminUsername.Multiline = true;
            this.txtAdminUsername.Name = "txtAdminUsername";
            this.txtAdminUsername.Size = new System.Drawing.Size(200, 20);
            this.txtAdminUsername.TabIndex = 51;
            // 
            // txtAdminFullName
            // 
            this.txtAdminFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdminFullName.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdminFullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.txtAdminFullName.Location = new System.Drawing.Point(169, 85);
            this.txtAdminFullName.Name = "txtAdminFullName";
            this.txtAdminFullName.Size = new System.Drawing.Size(200, 22);
            this.txtAdminFullName.TabIndex = 50;
            // 
            // txtAdminID
            // 
            this.txtAdminID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdminID.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdminID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.txtAdminID.Location = new System.Drawing.Point(169, 45);
            this.txtAdminID.Name = "txtAdminID";
            this.txtAdminID.Size = new System.Drawing.Size(200, 22);
            this.txtAdminID.TabIndex = 49;
            // 
            // txtAdminEmail
            // 
            this.txtAdminEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdminEmail.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdminEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.txtAdminEmail.Location = new System.Drawing.Point(566, 85);
            this.txtAdminEmail.Name = "txtAdminEmail";
            this.txtAdminEmail.Size = new System.Drawing.Size(200, 22);
            this.txtAdminEmail.TabIndex = 48;
            // 
            // txtAdminPassword
            // 
            this.txtAdminPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdminPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdminPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.txtAdminPassword.Location = new System.Drawing.Point(169, 173);
            this.txtAdminPassword.Name = "txtAdminPassword";
            this.txtAdminPassword.Size = new System.Drawing.Size(200, 22);
            this.txtAdminPassword.TabIndex = 47;
            this.txtAdminPassword.UseSystemPasswordChar = true;
            // 
            // lblAdminContact
            // 
            this.lblAdminContact.AutoSize = true;
            this.lblAdminContact.BackColor = System.Drawing.Color.Transparent;
            this.lblAdminContact.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminContact.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.lblAdminContact.Location = new System.Drawing.Point(427, 52);
            this.lblAdminContact.Name = "lblAdminContact";
            this.lblAdminContact.Size = new System.Drawing.Size(99, 15);
            this.lblAdminContact.TabIndex = 41;
            this.lblAdminContact.Text = "Contact Number";
            // 
            // lblAdminEmail
            // 
            this.lblAdminEmail.AutoSize = true;
            this.lblAdminEmail.BackColor = System.Drawing.Color.Transparent;
            this.lblAdminEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.lblAdminEmail.Location = new System.Drawing.Point(427, 92);
            this.lblAdminEmail.Name = "lblAdminEmail";
            this.lblAdminEmail.Size = new System.Drawing.Size(36, 15);
            this.lblAdminEmail.TabIndex = 39;
            this.lblAdminEmail.Text = "Email";
            // 
            // lblAdminPassword
            // 
            this.lblAdminPassword.AutoSize = true;
            this.lblAdminPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblAdminPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.lblAdminPassword.Location = new System.Drawing.Point(15, 180);
            this.lblAdminPassword.Name = "lblAdminPassword";
            this.lblAdminPassword.Size = new System.Drawing.Size(59, 15);
            this.lblAdminPassword.TabIndex = 37;
            this.lblAdminPassword.Text = "Password";
            // 
            // lblAdminUsername
            // 
            this.lblAdminUsername.AutoSize = true;
            this.lblAdminUsername.BackColor = System.Drawing.Color.Transparent;
            this.lblAdminUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.lblAdminUsername.Location = new System.Drawing.Point(15, 132);
            this.lblAdminUsername.Name = "lblAdminUsername";
            this.lblAdminUsername.Size = new System.Drawing.Size(64, 15);
            this.lblAdminUsername.TabIndex = 32;
            this.lblAdminUsername.Text = "Username";
            // 
            // lblAdminID
            // 
            this.lblAdminID.AutoSize = true;
            this.lblAdminID.BackColor = System.Drawing.Color.Transparent;
            this.lblAdminID.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.lblAdminID.Location = new System.Drawing.Point(15, 52);
            this.lblAdminID.Name = "lblAdminID";
            this.lblAdminID.Size = new System.Drawing.Size(59, 15);
            this.lblAdminID.TabIndex = 28;
            this.lblAdminID.Text = "Admin ID";
            // 
            // pnlAdminList
            // 
            this.pnlAdminList.Controls.Add(this.picAdminSearchIcon);
            this.pnlAdminList.Controls.Add(this.txtSearchAdmin);
            this.pnlAdminList.Controls.Add(this.dgvAdminList);
            this.pnlAdminList.Controls.Add(this.picAdminListIcon);
            this.pnlAdminList.Controls.Add(this.lblAdminListTitle);
            this.pnlAdminList.Location = new System.Drawing.Point(18, 417);
            this.pnlAdminList.Name = "pnlAdminList";
            this.pnlAdminList.Size = new System.Drawing.Size(822, 215);
            this.pnlAdminList.TabIndex = 14;
            // 
            // picAdminSearchIcon
            // 
            this.picAdminSearchIcon.BackColor = System.Drawing.Color.Transparent;
            this.picAdminSearchIcon.Image = global::EShiftOperationsManager.Properties.Resources.SERCHICON1;
            this.picAdminSearchIcon.Location = new System.Drawing.Point(564, 14);
            this.picAdminSearchIcon.Name = "picAdminSearchIcon";
            this.picAdminSearchIcon.Size = new System.Drawing.Size(24, 22);
            this.picAdminSearchIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAdminSearchIcon.TabIndex = 35;
            this.picAdminSearchIcon.TabStop = false;
            // 
            // txtSearchAdmin
            // 
            this.txtSearchAdmin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchAdmin.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchAdmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.txtSearchAdmin.Location = new System.Drawing.Point(590, 14);
            this.txtSearchAdmin.Name = "txtSearchAdmin";
            this.txtSearchAdmin.Size = new System.Drawing.Size(213, 22);
            this.txtSearchAdmin.TabIndex = 34;
            // 
            // dgvAdminList
            // 
            this.dgvAdminList.AllowUserToAddRows = false;
            this.dgvAdminList.AllowUserToDeleteRows = false;
            this.dgvAdminList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAdminList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdminList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAdminID,
            this.colAdminName,
            this.colAdminUsername,
            this.colAdminRole,
            this.colAdminStatus});
            this.dgvAdminList.Location = new System.Drawing.Point(18, 44);
            this.dgvAdminList.MultiSelect = false;
            this.dgvAdminList.Name = "dgvAdminList";
            this.dgvAdminList.ReadOnly = true;
            this.dgvAdminList.RowHeadersVisible = false;
            this.dgvAdminList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAdminList.Size = new System.Drawing.Size(785, 150);
            this.dgvAdminList.TabIndex = 33;
            // 
            // colAdminID
            // 
            this.colAdminID.HeaderText = "Admin ID";
            this.colAdminID.Name = "colAdminID";
            this.colAdminID.ReadOnly = true;
            // 
            // colAdminName
            // 
            this.colAdminName.HeaderText = "Name";
            this.colAdminName.Name = "colAdminName";
            this.colAdminName.ReadOnly = true;
            // 
            // colAdminUsername
            // 
            this.colAdminUsername.HeaderText = "Username";
            this.colAdminUsername.Name = "colAdminUsername";
            this.colAdminUsername.ReadOnly = true;
            // 
            // colAdminRole
            // 
            this.colAdminRole.HeaderText = "Role";
            this.colAdminRole.Name = "colAdminRole";
            this.colAdminRole.ReadOnly = true;
            // 
            // colAdminStatus
            // 
            this.colAdminStatus.HeaderText = "Status";
            this.colAdminStatus.Name = "colAdminStatus";
            this.colAdminStatus.ReadOnly = true;
            // 
            // picAdminListIcon
            // 
            this.picAdminListIcon.BackColor = System.Drawing.Color.Transparent;
            this.picAdminListIcon.Image = global::EShiftOperationsManager.Properties.Resources.T_Requesticon1;
            this.picAdminListIcon.Location = new System.Drawing.Point(17, 14);
            this.picAdminListIcon.Name = "picAdminListIcon";
            this.picAdminListIcon.Size = new System.Drawing.Size(24, 24);
            this.picAdminListIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAdminListIcon.TabIndex = 32;
            this.picAdminListIcon.TabStop = false;
            // 
            // lblAdminListTitle
            // 
            this.lblAdminListTitle.AutoSize = true;
            this.lblAdminListTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblAdminListTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminListTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.lblAdminListTitle.Location = new System.Drawing.Point(47, 21);
            this.lblAdminListTitle.Name = "lblAdminListTitle";
            this.lblAdminListTitle.Size = new System.Drawing.Size(75, 17);
            this.lblAdminListTitle.TabIndex = 30;
            this.lblAdminListTitle.Text = "Admin List";
            // 
            // lblAdminManagementSubtitle
            // 
            this.lblAdminManagementSubtitle.AutoSize = true;
            this.lblAdminManagementSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblAdminManagementSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminManagementSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.lblAdminManagementSubtitle.Location = new System.Drawing.Point(15, 50);
            this.lblAdminManagementSubtitle.Name = "lblAdminManagementSubtitle";
            this.lblAdminManagementSubtitle.Size = new System.Drawing.Size(296, 15);
            this.lblAdminManagementSubtitle.TabIndex = 11;
            this.lblAdminManagementSubtitle.Text = "Household Goods Transportation Management System";
            // 
            // lblAdminManagementTitle
            // 
            this.lblAdminManagementTitle.AutoSize = true;
            this.lblAdminManagementTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblAdminManagementTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminManagementTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.lblAdminManagementTitle.Location = new System.Drawing.Point(13, 16);
            this.lblAdminManagementTitle.Name = "lblAdminManagementTitle";
            this.lblAdminManagementTitle.Size = new System.Drawing.Size(215, 30);
            this.lblAdminManagementTitle.TabIndex = 10;
            this.lblAdminManagementTitle.Text = "Admin Management";
            // 
            // FrmAdminManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 701);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlSidebar);
            this.Name = "FrmAdminManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "e-Shift - Transportation Management System";
            this.Load += new System.EventHandler(this.FrmAdminManagement_Load);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picleft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLogo)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlAdminDetails.ResumeLayout(false);
            this.pnlAdminDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAdminDetailsIcon)).EndInit();
            this.pnlAdminList.ResumeLayout(false);
            this.pnlAdminList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAdminSearchIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdminList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAdminListIcon)).EndInit();
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
        private System.Windows.Forms.Panel pnlAdminDetails;
        private System.Windows.Forms.Button btnResetAdmin;
        private System.Windows.Forms.ComboBox cmbAdminRole;
        internal System.Windows.Forms.Label lblAdminRole;
        private System.Windows.Forms.Button btnClearCustomer;
        private System.Windows.Forms.Button btnDeleteCustomer;
        private System.Windows.Forms.Button btnUpdateCustomer;
        private System.Windows.Forms.Button btnAddCustomer;
        internal System.Windows.Forms.Label lblAdminFullName;
        private System.Windows.Forms.PictureBox picAdminDetailsIcon;
        internal System.Windows.Forms.Label lblAdminDetailsTitle;
        private System.Windows.Forms.TextBox txtAdminContact;
        private System.Windows.Forms.TextBox txtAdminUsername;
        private System.Windows.Forms.TextBox txtAdminFullName;
        private System.Windows.Forms.TextBox txtAdminID;
        private System.Windows.Forms.TextBox txtAdminEmail;
        private System.Windows.Forms.TextBox txtAdminPassword;
        internal System.Windows.Forms.Label lblAdminContact;
        internal System.Windows.Forms.Label lblAdminEmail;
        internal System.Windows.Forms.Label lblAdminPassword;
        internal System.Windows.Forms.Label lblAdminUsername;
        internal System.Windows.Forms.Label lblAdminID;
        private System.Windows.Forms.Panel pnlAdminList;
        private System.Windows.Forms.PictureBox picAdminSearchIcon;
        private System.Windows.Forms.TextBox txtSearchAdmin;
        private System.Windows.Forms.DataGridView dgvAdminList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdminID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdminName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdminUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdminRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdminStatus;
        private System.Windows.Forms.PictureBox picAdminListIcon;
        internal System.Windows.Forms.Label lblAdminListTitle;
        internal System.Windows.Forms.Label lblAdminManagementSubtitle;
        internal System.Windows.Forms.Label lblAdminManagementTitle;
    }
}