namespace POSAdminPanel
{
    partial class AppUserForm
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
            this.btnAddAppUser = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.llSetRoles = new System.Windows.Forms.LinkLabel();
            this.tbxRoles = new System.Windows.Forms.TextBox();
            this.tbxConfirmPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.tbxNewPassword = new System.Windows.Forms.TextBox();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxContactNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxLastName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddAppUser
            // 
            this.btnAddAppUser.BackColor = System.Drawing.Color.White;
            this.btnAddAppUser.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnAddAppUser.FlatAppearance.BorderSize = 2;
            this.btnAddAppUser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnAddAppUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAppUser.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAppUser.ForeColor = System.Drawing.Color.Navy;
            this.btnAddAppUser.Location = new System.Drawing.Point(455, 8);
            this.btnAddAppUser.Name = "btnAddAppUser";
            this.btnAddAppUser.Size = new System.Drawing.Size(137, 41);
            this.btnAddAppUser.TabIndex = 12;
            this.btnAddAppUser.Text = "&Add User";
            this.btnAddAppUser.UseVisualStyleBackColor = false;
            this.btnAddAppUser.Click += new System.EventHandler(this.btnAddAppUser_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.llSetRoles);
            this.groupBox1.Controls.Add(this.tbxRoles);
            this.groupBox1.Controls.Add(this.tbxConfirmPassword);
            this.groupBox1.Controls.Add(this.lblConfirmPassword);
            this.groupBox1.Controls.Add(this.tbxNewPassword);
            this.groupBox1.Controls.Add(this.lblNewPassword);
            this.groupBox1.Controls.Add(this.tbxPassword);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbxAddress);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbxContactNumber);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbxLastName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbxName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(12, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(594, 312);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Application User Details";
            // 
            // llSetRoles
            // 
            this.llSetRoles.AutoSize = true;
            this.llSetRoles.Location = new System.Drawing.Point(503, 166);
            this.llSetRoles.Name = "llSetRoles";
            this.llSetRoles.Size = new System.Drawing.Size(78, 21);
            this.llSetRoles.TabIndex = 37;
            this.llSetRoles.TabStop = true;
            this.llSetRoles.Text = "Set Roles";
            this.llSetRoles.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llSetRoles_LinkClicked);
            // 
            // tbxRoles
            // 
            this.tbxRoles.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxRoles.Location = new System.Drawing.Point(149, 163);
            this.tbxRoles.Name = "tbxRoles";
            this.tbxRoles.ReadOnly = true;
            this.tbxRoles.Size = new System.Drawing.Size(348, 29);
            this.tbxRoles.TabIndex = 36;
            // 
            // tbxConfirmPassword
            // 
            this.tbxConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxConfirmPassword.Location = new System.Drawing.Point(149, 268);
            this.tbxConfirmPassword.Name = "tbxConfirmPassword";
            this.tbxConfirmPassword.Size = new System.Drawing.Size(428, 29);
            this.tbxConfirmPassword.TabIndex = 35;
            this.tbxConfirmPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmPassword.Location = new System.Drawing.Point(6, 271);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(142, 21);
            this.lblConfirmPassword.TabIndex = 34;
            this.lblConfirmPassword.Text = "Confirm Password";
            // 
            // tbxNewPassword
            // 
            this.tbxNewPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxNewPassword.Location = new System.Drawing.Point(149, 233);
            this.tbxNewPassword.Name = "tbxNewPassword";
            this.tbxNewPassword.Size = new System.Drawing.Size(428, 29);
            this.tbxNewPassword.TabIndex = 33;
            this.tbxNewPassword.UseSystemPasswordChar = true;
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewPassword.Location = new System.Drawing.Point(6, 236);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(116, 21);
            this.lblNewPassword.TabIndex = 32;
            this.lblNewPassword.Text = "New Password";
            // 
            // tbxPassword
            // 
            this.tbxPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPassword.Location = new System.Drawing.Point(149, 198);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.Size = new System.Drawing.Size(428, 29);
            this.tbxPassword.TabIndex = 31;
            this.tbxPassword.UseSystemPasswordChar = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 201);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 21);
            this.label8.TabIndex = 30;
            this.label8.Text = "Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 21);
            this.label5.TabIndex = 29;
            this.label5.Text = "Roles";
            // 
            // tbxAddress
            // 
            this.tbxAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxAddress.Location = new System.Drawing.Point(149, 128);
            this.tbxAddress.Name = "tbxAddress";
            this.tbxAddress.Size = new System.Drawing.Size(428, 29);
            this.tbxAddress.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 21);
            this.label4.TabIndex = 27;
            this.label4.Text = "Address";
            // 
            // tbxContactNumber
            // 
            this.tbxContactNumber.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxContactNumber.Location = new System.Drawing.Point(149, 93);
            this.tbxContactNumber.Name = "tbxContactNumber";
            this.tbxContactNumber.Size = new System.Drawing.Size(428, 29);
            this.tbxContactNumber.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 21);
            this.label3.TabIndex = 25;
            this.label3.Text = "Contact Number";
            // 
            // tbxLastName
            // 
            this.tbxLastName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxLastName.Location = new System.Drawing.Point(149, 58);
            this.tbxLastName.Name = "tbxLastName";
            this.tbxLastName.Size = new System.Drawing.Size(428, 29);
            this.tbxLastName.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 21);
            this.label2.TabIndex = 23;
            this.label2.Text = "Last Name";
            // 
            // tbxName
            // 
            this.tbxName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxName.Location = new System.Drawing.Point(149, 23);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(428, 29);
            this.tbxName.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 21);
            this.label1.TabIndex = 21;
            this.label1.Text = "Name";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel7.Controls.Add(this.label7);
            this.panel7.Location = new System.Drawing.Point(-3, -5);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(619, 53);
            this.panel7.TabIndex = 34;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Monotype Corsiva", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(38, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(191, 43);
            this.label7.TabIndex = 34;
            this.label7.Text = "Admin Panel";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel6.Controls.Add(this.btnAddAppUser);
            this.panel6.Location = new System.Drawing.Point(-3, 373);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(619, 64);
            this.panel6.TabIndex = 35;
            // 
            // AppUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(614, 434);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AppUserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Application User Form";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAddAppUser;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel llSetRoles;
        private System.Windows.Forms.TextBox tbxRoles;
        private System.Windows.Forms.TextBox tbxConfirmPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox tbxNewPassword;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxContactNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxLastName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel6;
    }
}