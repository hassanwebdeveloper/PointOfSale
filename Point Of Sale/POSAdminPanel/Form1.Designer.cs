namespace POSAdminPanel
{
    partial class Form1
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
            this.btnAddSalesMan = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSystemSettings = new System.Windows.Forms.Button();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddAppUser
            // 
            this.btnAddAppUser.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnAddAppUser.FlatAppearance.BorderSize = 2;
            this.btnAddAppUser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnAddAppUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAppUser.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAppUser.ForeColor = System.Drawing.Color.Navy;
            this.btnAddAppUser.Location = new System.Drawing.Point(31, 72);
            this.btnAddAppUser.Name = "btnAddAppUser";
            this.btnAddAppUser.Size = new System.Drawing.Size(137, 41);
            this.btnAddAppUser.TabIndex = 10;
            this.btnAddAppUser.Text = "App Users";
            this.btnAddAppUser.UseVisualStyleBackColor = true;
            this.btnAddAppUser.Click += new System.EventHandler(this.btnAddAppUser_Click);
            // 
            // btnAddSalesMan
            // 
            this.btnAddSalesMan.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnAddSalesMan.FlatAppearance.BorderSize = 2;
            this.btnAddSalesMan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnAddSalesMan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSalesMan.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSalesMan.ForeColor = System.Drawing.Color.Navy;
            this.btnAddSalesMan.Location = new System.Drawing.Point(203, 72);
            this.btnAddSalesMan.Name = "btnAddSalesMan";
            this.btnAddSalesMan.Size = new System.Drawing.Size(137, 41);
            this.btnAddSalesMan.TabIndex = 11;
            this.btnAddSalesMan.Text = "Sales Man";
            this.btnAddSalesMan.UseVisualStyleBackColor = true;
            this.btnAddSalesMan.Click += new System.EventHandler(this.btnAddSalesMan_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel7.Controls.Add(this.label7);
            this.panel7.Location = new System.Drawing.Point(-4, -4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(531, 53);
            this.panel7.TabIndex = 36;
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
            // btnSystemSettings
            // 
            this.btnSystemSettings.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnSystemSettings.FlatAppearance.BorderSize = 2;
            this.btnSystemSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSystemSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSystemSettings.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSystemSettings.ForeColor = System.Drawing.Color.Navy;
            this.btnSystemSettings.Location = new System.Drawing.Point(369, 72);
            this.btnSystemSettings.Name = "btnSystemSettings";
            this.btnSystemSettings.Size = new System.Drawing.Size(144, 41);
            this.btnSystemSettings.TabIndex = 37;
            this.btnSystemSettings.Text = "System Settings";
            this.btnSystemSettings.UseVisualStyleBackColor = true;
            this.btnSystemSettings.Click += new System.EventHandler(this.btnSystemSettings_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(525, 138);
            this.Controls.Add(this.btnSystemSettings);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.btnAddSalesMan);
            this.Controls.Add(this.btnAddAppUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Panel";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddAppUser;
        private System.Windows.Forms.Button btnAddSalesMan;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSystemSettings;
    }
}

