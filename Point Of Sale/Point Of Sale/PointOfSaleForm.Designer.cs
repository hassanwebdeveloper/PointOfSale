namespace Point_Of_Sale
{
    partial class PointOfSaleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PointOfSaleForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pbxProductImage = new System.Windows.Forms.PictureBox();
            this.dgvPOSItems = new System.Windows.Forms.DataGridView();
            this.barcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsPOSGridItemInfo = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.cbxSalesMans = new System.Windows.Forms.ComboBox();
            this.btnNewBill = new System.Windows.Forms.Button();
            this.btnSaveBill = new System.Windows.Forms.Button();
            this.btnCancelBill = new System.Windows.Forms.Button();
            this.btnPayBill = new System.Windows.Forms.Button();
            this.tbxItemName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblBalance = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTotalDiscount = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblItemsCount = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pbxBarcode = new System.Windows.Forms.PictureBox();
            this.tbxAmountPaid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxProductImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPOSItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPOSGridItemInfo)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBarcode)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(12, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 21);
            this.label1.TabIndex = 10;
            this.label1.Text = "Cashier:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(141, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 21);
            this.label2.TabIndex = 11;
            this.label2.Text = "Logged In User:";
            // 
            // pbxProductImage
            // 
            this.pbxProductImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxProductImage.Image = ((System.Drawing.Image)(resources.GetObject("pbxProductImage.Image")));
            this.pbxProductImage.Location = new System.Drawing.Point(709, 57);
            this.pbxProductImage.Name = "pbxProductImage";
            this.pbxProductImage.Size = new System.Drawing.Size(159, 114);
            this.pbxProductImage.TabIndex = 3;
            this.pbxProductImage.TabStop = false;
            // 
            // dgvPOSItems
            // 
            this.dgvPOSItems.AllowUserToAddRows = false;
            this.dgvPOSItems.AutoGenerateColumns = false;
            this.dgvPOSItems.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPOSItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPOSItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPOSItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.barcodeDataGridViewTextBoxColumn,
            this.productNameDataGridViewTextBoxColumn,
            this.rateDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.discountDataGridViewTextBoxColumn,
            this.totalDataGridViewTextBoxColumn});
            this.dgvPOSItems.DataSource = this.bsPOSGridItemInfo;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPOSItems.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPOSItems.EnableHeadersVisualStyles = false;
            this.dgvPOSItems.Location = new System.Drawing.Point(12, 177);
            this.dgvPOSItems.MultiSelect = false;
            this.dgvPOSItems.Name = "dgvPOSItems";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPOSItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPOSItems.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPOSItems.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPOSItems.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPOSItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPOSItems.Size = new System.Drawing.Size(856, 242);
            this.dgvPOSItems.TabIndex = 4;
            this.dgvPOSItems.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvPOSItems_CellBeginEdit);
            this.dgvPOSItems.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPOSItems_CellEndEdit);
            this.dgvPOSItems.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvPOSItems_DataBindingComplete);
            this.dgvPOSItems.SelectionChanged += new System.EventHandler(this.dgvPOSItems_SelectionChanged);
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
            // productNameDataGridViewTextBoxColumn
            // 
            this.productNameDataGridViewTextBoxColumn.DataPropertyName = "ProductName";
            this.productNameDataGridViewTextBoxColumn.HeaderText = "ProductName";
            this.productNameDataGridViewTextBoxColumn.Name = "productNameDataGridViewTextBoxColumn";
            this.productNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.productNameDataGridViewTextBoxColumn.Width = 302;
            // 
            // rateDataGridViewTextBoxColumn
            // 
            this.rateDataGridViewTextBoxColumn.DataPropertyName = "Rate";
            this.rateDataGridViewTextBoxColumn.HeaderText = "Rate";
            this.rateDataGridViewTextBoxColumn.Name = "rateDataGridViewTextBoxColumn";
            this.rateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Quantity";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.Width = 80;
            // 
            // discountDataGridViewTextBoxColumn
            // 
            this.discountDataGridViewTextBoxColumn.DataPropertyName = "Discount";
            this.discountDataGridViewTextBoxColumn.HeaderText = "Discount";
            this.discountDataGridViewTextBoxColumn.Name = "discountDataGridViewTextBoxColumn";
            this.discountDataGridViewTextBoxColumn.Width = 120;
            // 
            // totalDataGridViewTextBoxColumn
            // 
            this.totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
            this.totalDataGridViewTextBoxColumn.HeaderText = "Total";
            this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            this.totalDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalDataGridViewTextBoxColumn.Width = 130;
            // 
            // bsPOSGridItemInfo
            // 
            this.bsPOSGridItemInfo.DataSource = typeof(POSRepository.POSGridItemInfo);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(12, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 21);
            this.label5.TabIndex = 12;
            this.label5.Text = "Sales Person:";
            // 
            // cbxSalesMans
            // 
            this.cbxSalesMans.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxSalesMans.ForeColor = System.Drawing.Color.Green;
            this.cbxSalesMans.FormattingEnabled = true;
            this.cbxSalesMans.Location = new System.Drawing.Point(143, 95);
            this.cbxSalesMans.Name = "cbxSalesMans";
            this.cbxSalesMans.Size = new System.Drawing.Size(241, 29);
            this.cbxSalesMans.TabIndex = 1;
            // 
            // btnNewBill
            // 
            this.btnNewBill.BackColor = System.Drawing.Color.White;
            this.btnNewBill.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnNewBill.FlatAppearance.BorderSize = 2;
            this.btnNewBill.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnNewBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewBill.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewBill.ForeColor = System.Drawing.Color.Navy;
            this.btnNewBill.Location = new System.Drawing.Point(590, 10);
            this.btnNewBill.Name = "btnNewBill";
            this.btnNewBill.Size = new System.Drawing.Size(137, 41);
            this.btnNewBill.TabIndex = 6;
            this.btnNewBill.Text = "&New Bill";
            this.btnNewBill.UseVisualStyleBackColor = false;
            this.btnNewBill.Click += new System.EventHandler(this.btnNewBill_Click);
            // 
            // btnSaveBill
            // 
            this.btnSaveBill.BackColor = System.Drawing.Color.White;
            this.btnSaveBill.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnSaveBill.FlatAppearance.BorderSize = 2;
            this.btnSaveBill.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSaveBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveBill.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveBill.ForeColor = System.Drawing.Color.Navy;
            this.btnSaveBill.Location = new System.Drawing.Point(447, 10);
            this.btnSaveBill.Name = "btnSaveBill";
            this.btnSaveBill.Size = new System.Drawing.Size(137, 41);
            this.btnSaveBill.TabIndex = 8;
            this.btnSaveBill.Text = "Save Bill";
            this.btnSaveBill.UseVisualStyleBackColor = false;
            this.btnSaveBill.Visible = false;
            this.btnSaveBill.Click += new System.EventHandler(this.btnSaveBill_Click);
            // 
            // btnCancelBill
            // 
            this.btnCancelBill.BackColor = System.Drawing.Color.White;
            this.btnCancelBill.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnCancelBill.FlatAppearance.BorderSize = 2;
            this.btnCancelBill.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnCancelBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelBill.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelBill.ForeColor = System.Drawing.Color.Navy;
            this.btnCancelBill.Location = new System.Drawing.Point(304, 10);
            this.btnCancelBill.Name = "btnCancelBill";
            this.btnCancelBill.Size = new System.Drawing.Size(137, 41);
            this.btnCancelBill.TabIndex = 9;
            this.btnCancelBill.Text = "&Cancel Bill";
            this.btnCancelBill.UseVisualStyleBackColor = false;
            this.btnCancelBill.Visible = false;
            this.btnCancelBill.Click += new System.EventHandler(this.btnCancelBill_Click);
            // 
            // btnPayBill
            // 
            this.btnPayBill.BackColor = System.Drawing.Color.White;
            this.btnPayBill.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnPayBill.FlatAppearance.BorderSize = 2;
            this.btnPayBill.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnPayBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayBill.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayBill.ForeColor = System.Drawing.Color.Navy;
            this.btnPayBill.Location = new System.Drawing.Point(733, 10);
            this.btnPayBill.Name = "btnPayBill";
            this.btnPayBill.Size = new System.Drawing.Size(137, 41);
            this.btnPayBill.TabIndex = 7;
            this.btnPayBill.Text = "&Pay Bill";
            this.btnPayBill.UseVisualStyleBackColor = false;
            this.btnPayBill.Click += new System.EventHandler(this.btnPayBill_Click);
            // 
            // tbxItemName
            // 
            this.tbxItemName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.tbxItemName.Location = new System.Drawing.Point(143, 130);
            this.tbxItemName.Name = "tbxItemName";
            this.tbxItemName.Size = new System.Drawing.Size(393, 29);
            this.tbxItemName.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(12, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 21);
            this.label4.TabIndex = 13;
            this.label4.Text = "Name/Barcode:";
            // 
            // btnSearch
            // 
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnSearch.FlatAppearance.BorderSize = 2;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.Navy;
            this.btnSearch.Location = new System.Drawing.Point(566, 119);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(137, 37);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(600, 425);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(268, 119);
            this.panel1.TabIndex = 27;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Black;
            this.panel5.Controls.Add(this.lblBalance);
            this.panel5.Location = new System.Drawing.Point(164, 89);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(95, 24);
            this.panel5.TabIndex = 25;
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblBalance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblBalance.ForeColor = System.Drawing.Color.Lime;
            this.lblBalance.Location = new System.Drawing.Point(76, 0);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblBalance.Size = new System.Drawing.Size(19, 21);
            this.lblBalance.TabIndex = 24;
            this.lblBalance.Text = "0";
            this.lblBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Controls.Add(this.lblTotal);
            this.panel4.Location = new System.Drawing.Point(119, 45);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(148, 47);
            this.panel4.TabIndex = 21;
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
            this.lblTotal.TabIndex = 20;
            this.lblTotal.Text = "0";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Controls.Add(this.lblTotalDiscount);
            this.panel3.Location = new System.Drawing.Point(162, 27);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(95, 24);
            this.panel3.TabIndex = 18;
            // 
            // lblTotalDiscount
            // 
            this.lblTotalDiscount.AutoSize = true;
            this.lblTotalDiscount.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTotalDiscount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalDiscount.ForeColor = System.Drawing.Color.Lime;
            this.lblTotalDiscount.Location = new System.Drawing.Point(76, 0);
            this.lblTotalDiscount.Name = "lblTotalDiscount";
            this.lblTotalDiscount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTotalDiscount.Size = new System.Drawing.Size(19, 21);
            this.lblTotalDiscount.TabIndex = 22;
            this.lblTotalDiscount.Text = "0";
            this.lblTotalDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.Lime;
            this.label8.Location = new System.Drawing.Point(5, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 21);
            this.label8.TabIndex = 26;
            this.label8.Text = "Balance:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.lblItemsCount);
            this.panel2.Location = new System.Drawing.Point(162, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(95, 24);
            this.panel2.TabIndex = 16;
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
            this.lblItemsCount.TabIndex = 23;
            this.lblItemsCount.Text = "0";
            this.lblItemsCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.Lime;
            this.label11.Location = new System.Drawing.Point(3, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(124, 21);
            this.label11.TabIndex = 17;
            this.label11.Text = "Total Discount:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Lime;
            this.label9.Location = new System.Drawing.Point(3, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 21);
            this.label9.TabIndex = 15;
            this.label9.Text = "Items Count:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Lime;
            this.label6.Location = new System.Drawing.Point(0, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 41);
            this.label6.TabIndex = 19;
            this.label6.Text = "Total:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbxBarcode
            // 
            this.pbxBarcode.Image = ((System.Drawing.Image)(resources.GetObject("pbxBarcode.Image")));
            this.pbxBarcode.Location = new System.Drawing.Point(67, 469);
            this.pbxBarcode.Name = "pbxBarcode";
            this.pbxBarcode.Size = new System.Drawing.Size(216, 71);
            this.pbxBarcode.TabIndex = 17;
            this.pbxBarcode.TabStop = false;
            // 
            // tbxAmountPaid
            // 
            this.tbxAmountPaid.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.tbxAmountPaid.Location = new System.Drawing.Point(126, 427);
            this.tbxAmountPaid.Name = "tbxAmountPaid";
            this.tbxAmountPaid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbxAmountPaid.Size = new System.Drawing.Size(159, 29);
            this.tbxAmountPaid.TabIndex = 5;
            this.tbxAmountPaid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxAmountPaid_KeyPress);
            this.tbxAmountPaid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbxAmountPaid_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(12, 430);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 21);
            this.label3.TabIndex = 14;
            this.label3.Text = "Amount Paid:";
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel6.Controls.Add(this.btnNewBill);
            this.panel6.Controls.Add(this.btnPayBill);
            this.panel6.Controls.Add(this.btnSaveBill);
            this.panel6.Controls.Add(this.btnCancelBill);
            this.panel6.Location = new System.Drawing.Point(-2, 550);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(888, 64);
            this.panel6.TabIndex = 28;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel7.Controls.Add(this.label7);
            this.panel7.Location = new System.Drawing.Point(-2, -2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(888, 53);
            this.panel7.TabIndex = 29;
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
            // PointOfSaleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(880, 608);
            this.Controls.Add(this.tbxAmountPaid);
            this.Controls.Add(this.tbxItemName);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pbxBarcode);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxSalesMans);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvPOSItems);
            this.Controls.Add(this.pbxProductImage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PointOfSaleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Point of Sale";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PointOfSaleForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pbxProductImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPOSItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPOSGridItemInfo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBarcode)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbxProductImage;
        private System.Windows.Forms.DataGridView dgvPOSItems;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxSalesMans;
        private System.Windows.Forms.Button btnNewBill;
        private System.Windows.Forms.Button btnSaveBill;
        private System.Windows.Forms.Button btnCancelBill;
        private System.Windows.Forms.Button btnPayBill;
        private System.Windows.Forms.TextBox tbxItemName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblItemsCount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pbxBarcode;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblTotalDiscount;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbxAmountPaid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn discountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bsPOSGridItemInfo;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label7;
    }
}