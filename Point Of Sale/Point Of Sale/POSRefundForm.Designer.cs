namespace Point_Of_Sale
{
    partial class POSRefundForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(POSRefundForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pbxProductImage = new System.Windows.Forms.PictureBox();
            this.dgvPOSItems = new System.Windows.Forms.DataGridView();
            this.Refunded = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.barcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellingPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderQuantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReturnQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsPosItemInfo = new System.Windows.Forms.BindingSource(this.components);
            this.btnRefund = new System.Windows.Forms.Button();
            this.btnPrintRefundSlip = new System.Windows.Forms.Button();
            this.tbxItemName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOpenBill = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblItemsCount = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbxProductImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPOSItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPosItemInfo)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(8, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "Logged In User:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(163, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "Logged In User:";
            // 
            // pbxProductImage
            // 
            this.pbxProductImage.Image = ((System.Drawing.Image)(resources.GetObject("pbxProductImage.Image")));
            this.pbxProductImage.Location = new System.Drawing.Point(709, 55);
            this.pbxProductImage.Name = "pbxProductImage";
            this.pbxProductImage.Size = new System.Drawing.Size(159, 114);
            this.pbxProductImage.TabIndex = 3;
            this.pbxProductImage.TabStop = false;
            // 
            // dgvPOSItems
            // 
            this.dgvPOSItems.AllowUserToAddRows = false;
            this.dgvPOSItems.AllowUserToDeleteRows = false;
            this.dgvPOSItems.AutoGenerateColumns = false;
            this.dgvPOSItems.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPOSItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPOSItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPOSItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Refunded,
            this.barcodeDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.sellingPriceDataGridViewTextBoxColumn,
            this.orderQuantityDataGridViewTextBoxColumn,
            this.ReturnQty,
            this.orderTotalDataGridViewTextBoxColumn});
            this.dgvPOSItems.DataSource = this.bsPosItemInfo;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPOSItems.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPOSItems.Location = new System.Drawing.Point(12, 175);
            this.dgvPOSItems.MultiSelect = false;
            this.dgvPOSItems.Name = "dgvPOSItems";
            this.dgvPOSItems.RowHeadersVisible = false;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPOSItems.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPOSItems.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPOSItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPOSItems.Size = new System.Drawing.Size(856, 242);
            this.dgvPOSItems.TabIndex = 3;
            this.dgvPOSItems.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvPOSItems_CellBeginEdit);
            this.dgvPOSItems.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvPOSItems_DataBindingComplete);
            this.dgvPOSItems.SelectionChanged += new System.EventHandler(this.dgvPOSItems_SelectionChanged);
            // 
            // Refunded
            // 
            this.Refunded.HeaderText = "";
            this.Refunded.Name = "Refunded";
            this.Refunded.Width = 35;
            // 
            // barcodeDataGridViewTextBoxColumn
            // 
            this.barcodeDataGridViewTextBoxColumn.DataPropertyName = "Barcode";
            this.barcodeDataGridViewTextBoxColumn.HeaderText = "Barcode";
            this.barcodeDataGridViewTextBoxColumn.Name = "barcodeDataGridViewTextBoxColumn";
            this.barcodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.barcodeDataGridViewTextBoxColumn.Width = 110;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Product Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 252;
            // 
            // sellingPriceDataGridViewTextBoxColumn
            // 
            this.sellingPriceDataGridViewTextBoxColumn.DataPropertyName = "SellingPrice";
            this.sellingPriceDataGridViewTextBoxColumn.HeaderText = "Rate";
            this.sellingPriceDataGridViewTextBoxColumn.Name = "sellingPriceDataGridViewTextBoxColumn";
            this.sellingPriceDataGridViewTextBoxColumn.Width = 130;
            // 
            // orderQuantityDataGridViewTextBoxColumn
            // 
            this.orderQuantityDataGridViewTextBoxColumn.DataPropertyName = "OrderQuantity";
            this.orderQuantityDataGridViewTextBoxColumn.HeaderText = "Qty";
            this.orderQuantityDataGridViewTextBoxColumn.Name = "orderQuantityDataGridViewTextBoxColumn";
            // 
            // ReturnQty
            // 
            this.ReturnQty.HeaderText = "Return Qty";
            this.ReturnQty.Name = "ReturnQty";
            this.ReturnQty.Width = 95;
            // 
            // orderTotalDataGridViewTextBoxColumn
            // 
            this.orderTotalDataGridViewTextBoxColumn.DataPropertyName = "OrderTotal";
            this.orderTotalDataGridViewTextBoxColumn.HeaderText = "Total";
            this.orderTotalDataGridViewTextBoxColumn.Name = "orderTotalDataGridViewTextBoxColumn";
            this.orderTotalDataGridViewTextBoxColumn.ReadOnly = true;
            this.orderTotalDataGridViewTextBoxColumn.Width = 130;
            // 
            // bsPosItemInfo
            // 
            this.bsPosItemInfo.DataSource = typeof(POSRepository.POSItemInfo);
            // 
            // btnRefund
            // 
            this.btnRefund.BackColor = System.Drawing.Color.White;
            this.btnRefund.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnRefund.FlatAppearance.BorderSize = 2;
            this.btnRefund.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnRefund.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefund.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefund.ForeColor = System.Drawing.Color.Navy;
            this.btnRefund.Location = new System.Drawing.Point(733, 8);
            this.btnRefund.Name = "btnRefund";
            this.btnRefund.Size = new System.Drawing.Size(137, 41);
            this.btnRefund.TabIndex = 4;
            this.btnRefund.Text = "&Refund";
            this.btnRefund.UseVisualStyleBackColor = false;
            this.btnRefund.Click += new System.EventHandler(this.btnRefund_Click);
            // 
            // btnPrintRefundSlip
            // 
            this.btnPrintRefundSlip.BackColor = System.Drawing.Color.White;
            this.btnPrintRefundSlip.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnPrintRefundSlip.FlatAppearance.BorderSize = 2;
            this.btnPrintRefundSlip.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnPrintRefundSlip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintRefundSlip.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintRefundSlip.ForeColor = System.Drawing.Color.Navy;
            this.btnPrintRefundSlip.Location = new System.Drawing.Point(590, 8);
            this.btnPrintRefundSlip.Name = "btnPrintRefundSlip";
            this.btnPrintRefundSlip.Size = new System.Drawing.Size(137, 41);
            this.btnPrintRefundSlip.TabIndex = 5;
            this.btnPrintRefundSlip.Text = "&Exchange";
            this.btnPrintRefundSlip.UseVisualStyleBackColor = false;
            this.btnPrintRefundSlip.Click += new System.EventHandler(this.btnPrintRefundSlip_Click);
            // 
            // tbxItemName
            // 
            this.tbxItemName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxItemName.ForeColor = System.Drawing.Color.Navy;
            this.tbxItemName.Location = new System.Drawing.Point(167, 100);
            this.tbxItemName.Name = "tbxItemName";
            this.tbxItemName.Size = new System.Drawing.Size(393, 29);
            this.tbxItemName.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(8, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 21);
            this.label4.TabIndex = 8;
            this.label4.Text = "Bill Barcode:";
            // 
            // btnOpenBill
            // 
            this.btnOpenBill.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnOpenBill.FlatAppearance.BorderSize = 2;
            this.btnOpenBill.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnOpenBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenBill.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenBill.ForeColor = System.Drawing.Color.Navy;
            this.btnOpenBill.Location = new System.Drawing.Point(566, 95);
            this.btnOpenBill.Name = "btnOpenBill";
            this.btnOpenBill.Size = new System.Drawing.Size(137, 37);
            this.btnOpenBill.TabIndex = 2;
            this.btnOpenBill.Text = "&Open Bill";
            this.btnOpenBill.UseVisualStyleBackColor = true;
            this.btnOpenBill.Click += new System.EventHandler(this.btnOpenBill_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(600, 423);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(268, 72);
            this.panel1.TabIndex = 10;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Controls.Add(this.lblTotal);
            this.panel4.Location = new System.Drawing.Point(119, 23);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(148, 47);
            this.panel4.TabIndex = 14;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.Lime;
            this.lblTotal.Location = new System.Drawing.Point(113, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(35, 41);
            this.lblTotal.TabIndex = 15;
            this.lblTotal.Text = "0";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.lblItemsCount);
            this.panel2.Location = new System.Drawing.Point(162, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(95, 24);
            this.panel2.TabIndex = 11;
            // 
            // lblItemsCount
            // 
            this.lblItemsCount.AutoSize = true;
            this.lblItemsCount.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblItemsCount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblItemsCount.ForeColor = System.Drawing.Color.Lime;
            this.lblItemsCount.Location = new System.Drawing.Point(76, 0);
            this.lblItemsCount.Name = "lblItemsCount";
            this.lblItemsCount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblItemsCount.Size = new System.Drawing.Size(19, 21);
            this.lblItemsCount.TabIndex = 12;
            this.lblItemsCount.Text = "0";
            this.lblItemsCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Lime;
            this.label9.Location = new System.Drawing.Point(3, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 21);
            this.label9.TabIndex = 9;
            this.label9.Text = "Items Count:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Lime;
            this.label6.Location = new System.Drawing.Point(0, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 41);
            this.label6.TabIndex = 13;
            this.label6.Text = "Total:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel7.Controls.Add(this.label7);
            this.panel7.Location = new System.Drawing.Point(-3, -4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(885, 53);
            this.panel7.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Monotype Corsiva", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(38, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(199, 43);
            this.label7.TabIndex = 34;
            this.label7.Text = "Point Of Sale";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel6.Controls.Add(this.btnRefund);
            this.panel6.Controls.Add(this.btnPrintRefundSlip);
            this.panel6.Location = new System.Drawing.Point(-3, 508);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(886, 64);
            this.panel6.TabIndex = 31;
            // 
            // POSRefundForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(880, 569);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnOpenBill);
            this.Controls.Add(this.tbxItemName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvPOSItems);
            this.Controls.Add(this.pbxProductImage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "POSRefundForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Refund Form";
            ((System.ComponentModel.ISupportInitialize)(this.pbxProductImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPOSItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPosItemInfo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbxProductImage;
        private System.Windows.Forms.DataGridView dgvPOSItems;
        private System.Windows.Forms.Button btnRefund;
        private System.Windows.Forms.Button btnPrintRefundSlip;
        private System.Windows.Forms.TextBox tbxItemName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOpenBill;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblItemsCount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.BindingSource bsPosItemInfo;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Refund;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Refunded;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sellingPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderQuantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReturnQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderTotalDataGridViewTextBoxColumn;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel6;
    }
}