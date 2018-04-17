namespace POSAdminPanel
{
    partial class SetApplicationUserRolesForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chxSearchItems = new System.Windows.Forms.CheckBox();
            this.chxRefundBill = new System.Windows.Forms.CheckBox();
            this.chxCreateBill = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chxPrintBarcode = new System.Windows.Forms.CheckBox();
            this.chxUpdateVendors = new System.Windows.Forms.CheckBox();
            this.chxViewVendors = new System.Windows.Forms.CheckBox();
            this.chxUpdateItems = new System.Windows.Forms.CheckBox();
            this.chxViewItems = new System.Windows.Forms.CheckBox();
            this.chxAdmin = new System.Windows.Forms.CheckBox();
            this.btnSetRoles = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.chxAdmin);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(11, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(505, 322);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Roles";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chxSearchItems);
            this.groupBox3.Controls.Add(this.chxRefundBill);
            this.groupBox3.Controls.Add(this.chxCreateBill);
            this.groupBox3.ForeColor = System.Drawing.Color.Navy;
            this.groupBox3.Location = new System.Drawing.Point(253, 79);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(241, 237);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Point Of Sale Roles";
            // 
            // chxSearchItems
            // 
            this.chxSearchItems.AutoSize = true;
            this.chxSearchItems.Location = new System.Drawing.Point(6, 112);
            this.chxSearchItems.Name = "chxSearchItems";
            this.chxSearchItems.Size = new System.Drawing.Size(123, 25);
            this.chxSearchItems.TabIndex = 4;
            this.chxSearchItems.Text = "Search Items";
            this.chxSearchItems.UseVisualStyleBackColor = true;
            // 
            // chxRefundBill
            // 
            this.chxRefundBill.AutoSize = true;
            this.chxRefundBill.Location = new System.Drawing.Point(6, 71);
            this.chxRefundBill.Name = "chxRefundBill";
            this.chxRefundBill.Size = new System.Drawing.Size(108, 25);
            this.chxRefundBill.TabIndex = 3;
            this.chxRefundBill.Text = "Refund Bill";
            this.chxRefundBill.UseVisualStyleBackColor = true;
            // 
            // chxCreateBill
            // 
            this.chxCreateBill.AutoSize = true;
            this.chxCreateBill.Location = new System.Drawing.Point(6, 28);
            this.chxCreateBill.Name = "chxCreateBill";
            this.chxCreateBill.Size = new System.Drawing.Size(103, 25);
            this.chxCreateBill.TabIndex = 2;
            this.chxCreateBill.Text = "Create Bill";
            this.chxCreateBill.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chxPrintBarcode);
            this.groupBox2.Controls.Add(this.chxUpdateVendors);
            this.groupBox2.Controls.Add(this.chxViewVendors);
            this.groupBox2.Controls.Add(this.chxUpdateItems);
            this.groupBox2.Controls.Add(this.chxViewItems);
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(6, 79);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(241, 237);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Inventory Management Roles";
            // 
            // chxPrintBarcode
            // 
            this.chxPrintBarcode.AutoSize = true;
            this.chxPrintBarcode.Location = new System.Drawing.Point(6, 195);
            this.chxPrintBarcode.Name = "chxPrintBarcode";
            this.chxPrintBarcode.Size = new System.Drawing.Size(128, 25);
            this.chxPrintBarcode.TabIndex = 6;
            this.chxPrintBarcode.Text = "Print Barcode";
            this.chxPrintBarcode.UseVisualStyleBackColor = true;
            // 
            // chxUpdateVendors
            // 
            this.chxUpdateVendors.AutoSize = true;
            this.chxUpdateVendors.Location = new System.Drawing.Point(6, 155);
            this.chxUpdateVendors.Name = "chxUpdateVendors";
            this.chxUpdateVendors.Size = new System.Drawing.Size(147, 25);
            this.chxUpdateVendors.TabIndex = 5;
            this.chxUpdateVendors.Text = "Update Vendors";
            this.chxUpdateVendors.UseVisualStyleBackColor = true;
            this.chxUpdateVendors.CheckedChanged += new System.EventHandler(this.chxUpdateVendors_CheckedChanged);
            // 
            // chxViewVendors
            // 
            this.chxViewVendors.AutoSize = true;
            this.chxViewVendors.Location = new System.Drawing.Point(6, 112);
            this.chxViewVendors.Name = "chxViewVendors";
            this.chxViewVendors.Size = new System.Drawing.Size(128, 25);
            this.chxViewVendors.TabIndex = 4;
            this.chxViewVendors.Text = "View Vendors";
            this.chxViewVendors.UseVisualStyleBackColor = true;
            this.chxViewVendors.CheckedChanged += new System.EventHandler(this.chxViewVendors_CheckedChanged);
            // 
            // chxUpdateItems
            // 
            this.chxUpdateItems.AutoSize = true;
            this.chxUpdateItems.Location = new System.Drawing.Point(6, 71);
            this.chxUpdateItems.Name = "chxUpdateItems";
            this.chxUpdateItems.Size = new System.Drawing.Size(128, 25);
            this.chxUpdateItems.TabIndex = 3;
            this.chxUpdateItems.Text = "Update Items";
            this.chxUpdateItems.UseVisualStyleBackColor = true;
            this.chxUpdateItems.CheckedChanged += new System.EventHandler(this.chxUpdateItems_CheckedChanged);
            // 
            // chxViewItems
            // 
            this.chxViewItems.AutoSize = true;
            this.chxViewItems.Location = new System.Drawing.Point(6, 28);
            this.chxViewItems.Name = "chxViewItems";
            this.chxViewItems.Size = new System.Drawing.Size(109, 25);
            this.chxViewItems.TabIndex = 2;
            this.chxViewItems.Text = "View Items";
            this.chxViewItems.UseVisualStyleBackColor = true;
            this.chxViewItems.CheckedChanged += new System.EventHandler(this.chxViewItems_CheckedChanged);
            // 
            // chxAdmin
            // 
            this.chxAdmin.AutoSize = true;
            this.chxAdmin.Location = new System.Drawing.Point(12, 38);
            this.chxAdmin.Name = "chxAdmin";
            this.chxAdmin.Size = new System.Drawing.Size(114, 25);
            this.chxAdmin.TabIndex = 0;
            this.chxAdmin.Text = "Admin User";
            this.chxAdmin.UseVisualStyleBackColor = true;
            this.chxAdmin.CheckedChanged += new System.EventHandler(this.chxAdmin_CheckedChanged);
            // 
            // btnSetRoles
            // 
            this.btnSetRoles.BackColor = System.Drawing.Color.White;
            this.btnSetRoles.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnSetRoles.FlatAppearance.BorderSize = 2;
            this.btnSetRoles.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSetRoles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetRoles.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetRoles.ForeColor = System.Drawing.Color.Navy;
            this.btnSetRoles.Location = new System.Drawing.Point(381, 6);
            this.btnSetRoles.Name = "btnSetRoles";
            this.btnSetRoles.Size = new System.Drawing.Size(137, 41);
            this.btnSetRoles.TabIndex = 7;
            this.btnSetRoles.Text = "&Set Roles";
            this.btnSetRoles.UseVisualStyleBackColor = false;
            this.btnSetRoles.Click += new System.EventHandler(this.btnSetRoles_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel6.Controls.Add(this.btnSetRoles);
            this.panel6.Location = new System.Drawing.Point(-2, 404);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(533, 58);
            this.panel6.TabIndex = 39;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Monotype Corsiva", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(38, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(191, 43);
            this.label8.TabIndex = 34;
            this.label8.Text = "Admin Panel";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel7.Controls.Add(this.label8);
            this.panel7.Location = new System.Drawing.Point(-2, -4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(533, 53);
            this.panel7.TabIndex = 40;
            // 
            // SetApplicationUserRolesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(528, 456);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SetApplicationUserRolesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set Application User Roles";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chxViewItems;
        private System.Windows.Forms.CheckBox chxAdmin;
        private System.Windows.Forms.CheckBox chxUpdateItems;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chxSearchItems;
        private System.Windows.Forms.CheckBox chxRefundBill;
        private System.Windows.Forms.CheckBox chxCreateBill;
        private System.Windows.Forms.CheckBox chxPrintBarcode;
        private System.Windows.Forms.CheckBox chxUpdateVendors;
        private System.Windows.Forms.CheckBox chxViewVendors;
        private System.Windows.Forms.Button btnSetRoles;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel7;
    }
}