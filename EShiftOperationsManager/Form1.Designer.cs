namespace EShiftOperationsManager
{
    partial class FrmLogin
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
            this.pnlLoginArea = new System.Windows.Forms.Panel();
            this.lnkForgotPassword = new System.Windows.Forms.LinkLabel();
            this.pnlradio = new System.Windows.Forms.Panel();
            this.rdoAdmin = new System.Windows.Forms.RadioButton();
            this.rdoCustomer = new System.Windows.Forms.RadioButton();
            this.grpUserType = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblLoginSubtitle = new System.Windows.Forms.Label();
            this.lblLoginHeading2 = new System.Windows.Forms.Label();
            this.lblLoginHeading = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.picPasswordIcon = new System.Windows.Forms.PictureBox();
            this.picUsernameIcon = new System.Windows.Forms.PictureBox();
            this.picSloganUnderline = new System.Windows.Forms.PictureBox();
            this.picOnTimeDeliveryIcon = new System.Windows.Forms.PictureBox();
            this.pnlLoginArea.SuspendLayout();
            this.pnlradio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPasswordIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUsernameIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSloganUnderline)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOnTimeDeliveryIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLoginArea
            // 
            this.pnlLoginArea.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlLoginArea.Controls.Add(this.btnRegister);
            this.pnlLoginArea.Controls.Add(this.lnkForgotPassword);
            this.pnlLoginArea.Controls.Add(this.btnLogin);
            this.pnlLoginArea.Controls.Add(this.pnlradio);
            this.pnlLoginArea.Controls.Add(this.grpUserType);
            this.pnlLoginArea.Controls.Add(this.txtPassword);
            this.pnlLoginArea.Controls.Add(this.picPasswordIcon);
            this.pnlLoginArea.Controls.Add(this.lblPassword);
            this.pnlLoginArea.Controls.Add(this.picUsernameIcon);
            this.pnlLoginArea.Controls.Add(this.txtUsername);
            this.pnlLoginArea.Controls.Add(this.lblUsername);
            this.pnlLoginArea.Controls.Add(this.picSloganUnderline);
            this.pnlLoginArea.Controls.Add(this.lblLoginSubtitle);
            this.pnlLoginArea.Controls.Add(this.lblLoginHeading2);
            this.pnlLoginArea.Controls.Add(this.lblLoginHeading);
            this.pnlLoginArea.Location = new System.Drawing.Point(310, 12);
            this.pnlLoginArea.Name = "pnlLoginArea";
            this.pnlLoginArea.Padding = new System.Windows.Forms.Padding(1);
            this.pnlLoginArea.Size = new System.Drawing.Size(433, 423);
            this.pnlLoginArea.TabIndex = 8;
            // 
            // lnkForgotPassword
            // 
            this.lnkForgotPassword.AutoSize = true;
            this.lnkForgotPassword.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkForgotPassword.Location = new System.Drawing.Point(266, 302);
            this.lnkForgotPassword.Name = "lnkForgotPassword";
            this.lnkForgotPassword.Size = new System.Drawing.Size(100, 13);
            this.lnkForgotPassword.TabIndex = 36;
            this.lnkForgotPassword.TabStop = true;
            this.lnkForgotPassword.Text = "Forgot Password?";
            // 
            // pnlradio
            // 
            this.pnlradio.BackColor = System.Drawing.Color.Lavender;
            this.pnlradio.Controls.Add(this.rdoAdmin);
            this.pnlradio.Controls.Add(this.rdoCustomer);
            this.pnlradio.Location = new System.Drawing.Point(40, 264);
            this.pnlradio.Name = "pnlradio";
            this.pnlradio.Size = new System.Drawing.Size(327, 35);
            this.pnlradio.TabIndex = 34;
            // 
            // rdoAdmin
            // 
            this.rdoAdmin.AutoSize = true;
            this.rdoAdmin.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoAdmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.rdoAdmin.Location = new System.Drawing.Point(20, 8);
            this.rdoAdmin.Name = "rdoAdmin";
            this.rdoAdmin.Size = new System.Drawing.Size(60, 17);
            this.rdoAdmin.TabIndex = 14;
            this.rdoAdmin.TabStop = true;
            this.rdoAdmin.Text = "Admin";
            this.rdoAdmin.UseVisualStyleBackColor = true;
            // 
            // rdoCustomer
            // 
            this.rdoCustomer.AutoSize = true;
            this.rdoCustomer.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.rdoCustomer.Location = new System.Drawing.Point(205, 8);
            this.rdoCustomer.Name = "rdoCustomer";
            this.rdoCustomer.Size = new System.Drawing.Size(75, 17);
            this.rdoCustomer.TabIndex = 15;
            this.rdoCustomer.TabStop = true;
            this.rdoCustomer.Text = "Customer";
            this.rdoCustomer.UseVisualStyleBackColor = true;
            // 
            // grpUserType
            // 
            this.grpUserType.AutoSize = true;
            this.grpUserType.BackColor = System.Drawing.Color.Transparent;
            this.grpUserType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpUserType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.grpUserType.Location = new System.Drawing.Point(37, 228);
            this.grpUserType.Name = "grpUserType";
            this.grpUserType.Size = new System.Drawing.Size(68, 17);
            this.grpUserType.TabIndex = 33;
            this.grpUserType.Text = "User Type";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.txtPassword.Location = new System.Drawing.Point(141, 180);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(225, 22);
            this.txtPassword.TabIndex = 32;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.lblPassword.Location = new System.Drawing.Point(36, 180);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(66, 17);
            this.lblPassword.TabIndex = 30;
            this.lblPassword.Text = "Password";
            // 
            // txtUsername
            // 
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.txtUsername.Location = new System.Drawing.Point(141, 125);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(225, 22);
            this.txtUsername.TabIndex = 28;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.Color.Transparent;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.lblUsername.Location = new System.Drawing.Point(36, 124);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(69, 17);
            this.lblUsername.TabIndex = 27;
            this.lblUsername.Text = "Username";
            // 
            // lblLoginSubtitle
            // 
            this.lblLoginSubtitle.AutoSize = true;
            this.lblLoginSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblLoginSubtitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblLoginSubtitle.Location = new System.Drawing.Point(80, 48);
            this.lblLoginSubtitle.Name = "lblLoginSubtitle";
            this.lblLoginSubtitle.Size = new System.Drawing.Size(230, 17);
            this.lblLoginSubtitle.TabIndex = 10;
            this.lblLoginSubtitle.Text = "Transportation Management System";
            // 
            // lblLoginHeading2
            // 
            this.lblLoginHeading2.AutoSize = true;
            this.lblLoginHeading2.BackColor = System.Drawing.Color.Transparent;
            this.lblLoginHeading2.Font = new System.Drawing.Font("Segoe UI", 18.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginHeading2.ForeColor = System.Drawing.Color.Blue;
            this.lblLoginHeading2.Location = new System.Drawing.Point(197, 13);
            this.lblLoginHeading2.Name = "lblLoginHeading2";
            this.lblLoginHeading2.Size = new System.Drawing.Size(95, 35);
            this.lblLoginHeading2.TabIndex = 9;
            this.lblLoginHeading2.Text = "e-Shift";
            // 
            // lblLoginHeading
            // 
            this.lblLoginHeading.AutoSize = true;
            this.lblLoginHeading.BackColor = System.Drawing.Color.Transparent;
            this.lblLoginHeading.Font = new System.Drawing.Font("Segoe UI", 18.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginHeading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.lblLoginHeading.Location = new System.Drawing.Point(89, 13);
            this.lblLoginHeading.Name = "lblLoginHeading";
            this.lblLoginHeading.Size = new System.Drawing.Size(112, 35);
            this.lblLoginHeading.TabIndex = 8;
            this.lblLoginHeading.Text = "Login to";
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.White;
            this.btnRegister.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(91)))), ((int)(((byte)(170)))));
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(91)))), ((int)(((byte)(170)))));
            this.btnRegister.Image = global::EShiftOperationsManager.Properties.Resources.NEWBUTTON_ICON_png;
            this.btnRegister.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnRegister.Location = new System.Drawing.Point(39, 369);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(327, 31);
            this.btnRegister.TabIndex = 37;
            this.btnRegister.Text = "Register New Customer";
            this.btnRegister.UseVisualStyleBackColor = false;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(88)))), ((int)(((byte)(214)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Image = global::EShiftOperationsManager.Properties.Resources.login_icon;
            this.btnLogin.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnLogin.Location = new System.Drawing.Point(39, 332);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(327, 31);
            this.btnLogin.TabIndex = 35;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.UseVisualStyleBackColor = false;
            // 
            // picPasswordIcon
            // 
            this.picPasswordIcon.BackColor = System.Drawing.Color.Transparent;
            this.picPasswordIcon.Image = global::EShiftOperationsManager.Properties.Resources.picPasswordIcon_png;
            this.picPasswordIcon.Location = new System.Drawing.Point(111, 180);
            this.picPasswordIcon.Name = "picPasswordIcon";
            this.picPasswordIcon.Size = new System.Drawing.Size(24, 22);
            this.picPasswordIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPasswordIcon.TabIndex = 31;
            this.picPasswordIcon.TabStop = false;
            // 
            // picUsernameIcon
            // 
            this.picUsernameIcon.BackColor = System.Drawing.Color.Transparent;
            this.picUsernameIcon.Image = global::EShiftOperationsManager.Properties.Resources.picUsernameIcon_png;
            this.picUsernameIcon.Location = new System.Drawing.Point(111, 124);
            this.picUsernameIcon.Name = "picUsernameIcon";
            this.picUsernameIcon.Size = new System.Drawing.Size(24, 22);
            this.picUsernameIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picUsernameIcon.TabIndex = 29;
            this.picUsernameIcon.TabStop = false;
            // 
            // picSloganUnderline
            // 
            this.picSloganUnderline.BackColor = System.Drawing.Color.Transparent;
            this.picSloganUnderline.Image = global::EShiftOperationsManager.Properties.Resources.Darkblueline;
            this.picSloganUnderline.Location = new System.Drawing.Point(39, 68);
            this.picSloganUnderline.Name = "picSloganUnderline";
            this.picSloganUnderline.Size = new System.Drawing.Size(280, 41);
            this.picSloganUnderline.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSloganUnderline.TabIndex = 26;
            this.picSloganUnderline.TabStop = false;
            // 
            // picOnTimeDeliveryIcon
            // 
            this.picOnTimeDeliveryIcon.BackColor = System.Drawing.Color.Transparent;
            this.picOnTimeDeliveryIcon.Image = global::EShiftOperationsManager.Properties.Resources.picOnTimeDeliveryIcon;
            this.picOnTimeDeliveryIcon.Location = new System.Drawing.Point(1, -2);
            this.picOnTimeDeliveryIcon.Name = "picOnTimeDeliveryIcon";
            this.picOnTimeDeliveryIcon.Size = new System.Drawing.Size(291, 451);
            this.picOnTimeDeliveryIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picOnTimeDeliveryIcon.TabIndex = 7;
            this.picOnTimeDeliveryIcon.TabStop = false;
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(755, 447);
            this.Controls.Add(this.pnlLoginArea);
            this.Controls.Add(this.picOnTimeDeliveryIcon);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "e-Shift - Login";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.pnlLoginArea.ResumeLayout(false);
            this.pnlLoginArea.PerformLayout();
            this.pnlradio.ResumeLayout(false);
            this.pnlradio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPasswordIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUsernameIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSloganUnderline)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOnTimeDeliveryIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.PictureBox picOnTimeDeliveryIcon;
        private System.Windows.Forms.Panel pnlLoginArea;
        internal System.Windows.Forms.Label lblLoginHeading;
        internal System.Windows.Forms.Label lblLoginHeading2;
        internal System.Windows.Forms.Label lblLoginSubtitle;
        internal System.Windows.Forms.PictureBox picSloganUnderline;
        private System.Windows.Forms.PictureBox picUsernameIcon;
        private System.Windows.Forms.TextBox txtUsername;
        internal System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.PictureBox picPasswordIcon;
        internal System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Panel pnlradio;
        private System.Windows.Forms.RadioButton rdoAdmin;
        private System.Windows.Forms.RadioButton rdoCustomer;
        internal System.Windows.Forms.Label grpUserType;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.LinkLabel lnkForgotPassword;
    }
}

