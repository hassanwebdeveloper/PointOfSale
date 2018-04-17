namespace InventoryManagementSystem
{
    partial class MainForm
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
            this.btnAddInventory = new System.Windows.Forms.Button();
            this.btnManageVendors = new System.Windows.Forms.Button();
            this.btnPrintBarcode = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddInventory
            // 
            this.btnAddInventory.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnAddInventory.FlatAppearance.BorderSize = 2;
            this.btnAddInventory.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnAddInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddInventory.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddInventory.ForeColor = System.Drawing.Color.Navy;
            this.btnAddInventory.Location = new System.Drawing.Point(18, 84);
            this.btnAddInventory.Name = "btnAddInventory";
            this.btnAddInventory.Size = new System.Drawing.Size(159, 48);
            this.btnAddInventory.TabIndex = 1;
            this.btnAddInventory.Text = "Manage &Inventory";
            this.btnAddInventory.UseVisualStyleBackColor = true;
            this.btnAddInventory.Click += new System.EventHandler(this.btnAddInventory_Click);
            // 
            // btnManageVendors
            // 
            this.btnManageVendors.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnManageVendors.FlatAppearance.BorderSize = 2;
            this.btnManageVendors.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnManageVendors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageVendors.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageVendors.ForeColor = System.Drawing.Color.Navy;
            this.btnManageVendors.Location = new System.Drawing.Point(193, 84);
            this.btnManageVendors.Name = "btnManageVendors";
            this.btnManageVendors.Size = new System.Drawing.Size(154, 48);
            this.btnManageVendors.TabIndex = 2;
            this.btnManageVendors.Text = "Manage &Vendors";
            this.btnManageVendors.UseVisualStyleBackColor = true;
            this.btnManageVendors.Click += new System.EventHandler(this.btnManageVendors_Click);
            // 
            // btnPrintBarcode
            // 
            this.btnPrintBarcode.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnPrintBarcode.FlatAppearance.BorderSize = 2;
            this.btnPrintBarcode.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnPrintBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintBarcode.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintBarcode.ForeColor = System.Drawing.Color.Navy;
            this.btnPrintBarcode.Location = new System.Drawing.Point(360, 84);
            this.btnPrintBarcode.Name = "btnPrintBarcode";
            this.btnPrintBarcode.Size = new System.Drawing.Size(154, 48);
            this.btnPrintBarcode.TabIndex = 3;
            this.btnPrintBarcode.Text = "&Print Barcodes";
            this.btnPrintBarcode.UseVisualStyleBackColor = true;
            this.btnPrintBarcode.Click += new System.EventHandler(this.btnPrintBarcode_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel7.Controls.Add(this.label7);
            this.panel7.Location = new System.Drawing.Point(-1, -1);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(531, 53);
            this.panel7.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Monotype Corsiva", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(38, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 43);
            this.label7.TabIndex = 34;
            this.label7.Text = "Inventory";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(529, 166);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.btnPrintBarcode);
            this.Controls.Add(this.btnManageVendors);
            this.Controls.Add(this.btnAddInventory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory Management";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddInventory;
        private System.Windows.Forms.Button btnManageVendors;
        private System.Windows.Forms.Button btnPrintBarcode;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label7;
    }
}

