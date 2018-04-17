namespace InventoryManagementSystem
{
    partial class PrintBarcodeForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnPrintBarcode = new System.Windows.Forms.Button();
            this.dgvPOSItems = new System.Windows.Forms.DataGridView();
            this.barcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VendorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrintCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsPOSItemInfo = new System.Windows.Forms.BindingSource(this.components);
            this.btnAddItems = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPOSItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPOSItemInfo)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrintBarcode
            // 
            this.btnPrintBarcode.BackColor = System.Drawing.Color.White;
            this.btnPrintBarcode.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnPrintBarcode.FlatAppearance.BorderSize = 2;
            this.btnPrintBarcode.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnPrintBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintBarcode.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintBarcode.ForeColor = System.Drawing.Color.Navy;
            this.btnPrintBarcode.Location = new System.Drawing.Point(681, 4);
            this.btnPrintBarcode.Name = "btnPrintBarcode";
            this.btnPrintBarcode.Size = new System.Drawing.Size(137, 41);
            this.btnPrintBarcode.TabIndex = 8;
            this.btnPrintBarcode.Text = "&Print Barcode";
            this.btnPrintBarcode.UseVisualStyleBackColor = false;
            this.btnPrintBarcode.Click += new System.EventHandler(this.btnPrintBarcode_Click);
            // 
            // dgvPOSItems
            // 
            this.dgvPOSItems.AllowUserToAddRows = false;
            this.dgvPOSItems.AutoGenerateColumns = false;
            this.dgvPOSItems.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPOSItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPOSItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPOSItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.barcodeDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.VendorName,
            this.PrintCount});
            this.dgvPOSItems.DataSource = this.bsPOSItemInfo;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPOSItems.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPOSItems.Location = new System.Drawing.Point(12, 58);
            this.dgvPOSItems.MultiSelect = false;
            this.dgvPOSItems.Name = "dgvPOSItems";
            this.dgvPOSItems.RowHeadersVisible = false;
            this.dgvPOSItems.RowTemplate.Height = 50;
            this.dgvPOSItems.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPOSItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPOSItems.Size = new System.Drawing.Size(804, 294);
            this.dgvPOSItems.TabIndex = 10;
            this.dgvPOSItems.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvPOSItems_CellBeginEdit);
            this.dgvPOSItems.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPOSItems_CellEndEdit);
            this.dgvPOSItems.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvPOSItems_DataBindingComplete);
            this.dgvPOSItems.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvPOSItems_RowsRemoved);
            this.dgvPOSItems.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvPOSItems_UserDeletedRow);
            // 
            // barcodeDataGridViewTextBoxColumn
            // 
            this.barcodeDataGridViewTextBoxColumn.DataPropertyName = "Barcode";
            this.barcodeDataGridViewTextBoxColumn.HeaderText = "Barcode";
            this.barcodeDataGridViewTextBoxColumn.Name = "barcodeDataGridViewTextBoxColumn";
            this.barcodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.barcodeDataGridViewTextBoxColumn.Width = 120;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 360;
            // 
            // VendorName
            // 
            this.VendorName.DataPropertyName = "VendorName";
            this.VendorName.HeaderText = "Vendor";
            this.VendorName.Name = "VendorName";
            this.VendorName.ReadOnly = true;
            this.VendorName.Width = 200;
            // 
            // PrintCount
            // 
            this.PrintCount.HeaderText = "Print Count";
            this.PrintCount.Name = "PrintCount";
            this.PrintCount.Width = 120;
            // 
            // bsPOSItemInfo
            // 
            this.bsPOSItemInfo.DataSource = typeof(POSRepository.POSItemInfo);
            // 
            // btnAddItems
            // 
            this.btnAddItems.BackColor = System.Drawing.Color.White;
            this.btnAddItems.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnAddItems.FlatAppearance.BorderSize = 2;
            this.btnAddItems.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnAddItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddItems.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddItems.ForeColor = System.Drawing.Color.Navy;
            this.btnAddItems.Location = new System.Drawing.Point(14, 4);
            this.btnAddItems.Name = "btnAddItems";
            this.btnAddItems.Size = new System.Drawing.Size(137, 41);
            this.btnAddItems.TabIndex = 11;
            this.btnAddItems.Text = "Add Item(s)";
            this.btnAddItems.UseVisualStyleBackColor = false;
            this.btnAddItems.Click += new System.EventHandler(this.btnAddItems_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel7.Controls.Add(this.btnPrintBarcode);
            this.panel7.Controls.Add(this.btnAddItems);
            this.panel7.Location = new System.Drawing.Point(-2, 371);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(834, 53);
            this.panel7.TabIndex = 38;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Location = new System.Drawing.Point(-2, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(834, 53);
            this.panel1.TabIndex = 39;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Monotype Corsiva", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(38, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(149, 43);
            this.label11.TabIndex = 34;
            this.label11.Text = "Inventory";
            // 
            // PrintBarcodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(830, 420);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.dgvPOSItems);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PrintBarcodeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PrintBarcodeForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPOSItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPOSItemInfo)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnPrintBarcode;
        private System.Windows.Forms.BindingSource bsPOSItemInfo;
        private System.Windows.Forms.DataGridView dgvPOSItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn VendorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrintCount;
        private System.Windows.Forms.Button btnAddItems;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
    }
}