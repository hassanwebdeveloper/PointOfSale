namespace InventoryManagementSystem
{
    partial class POSItemInfoForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbxDescription = new System.Windows.Forms.TextBox();
            this.tbxShortName = new System.Windows.Forms.TextBox();
            this.tbxItemName = new System.Windows.Forms.TextBox();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.nudDiscount = new System.Windows.Forms.NumericUpDown();
            this.nudItemsCount = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.pbxSnapShot = new System.Windows.Forms.PictureBox();
            this.chbDiscountInPercent = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbxSellingPrice = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxBuyingPrice = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxVendor = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.llUpdateType = new System.Windows.Forms.LinkLabel();
            this.cbxItemType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.llUpdateCategory = new System.Windows.Forms.LinkLabel();
            this.cbxItemCategory = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPOSItems = new System.Windows.Forms.DataGridView();
            this.barcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shortNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.VendorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buyingPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellingPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discountInPercentDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.totalItemsPurchasedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalItemsSoldDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsPOSItemInfo = new System.Windows.Forms.BindingSource(this.components);
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSaveAll = new System.Windows.Forms.Button();
            this.ofdBrowseImage = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnPurchase = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudItemsCount)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSnapShot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPOSItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPOSItemInfo)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPurchase);
            this.groupBox1.Controls.Add(this.tbxDescription);
            this.groupBox1.Controls.Add(this.tbxShortName);
            this.groupBox1.Controls.Add(this.tbxItemName);
            this.groupBox1.Controls.Add(this.btnAddItem);
            this.groupBox1.Controls.Add(this.nudDiscount);
            this.groupBox1.Controls.Add(this.nudItemsCount);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.chbDiscountInPercent);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.tbxSellingPrice);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbxBuyingPrice);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbxVendor);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.llUpdateType);
            this.groupBox1.Controls.Add(this.cbxItemType);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.llUpdateCategory);
            this.groupBox1.Controls.Add(this.cbxItemCategory);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(8, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1199, 285);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Item";
            // 
            // tbxDescription
            // 
            this.tbxDescription.Location = new System.Drawing.Point(101, 95);
            this.tbxDescription.Multiline = true;
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.Size = new System.Drawing.Size(352, 99);
            this.tbxDescription.TabIndex = 3;
            // 
            // tbxShortName
            // 
            this.tbxShortName.Location = new System.Drawing.Point(101, 60);
            this.tbxShortName.Name = "tbxShortName";
            this.tbxShortName.Size = new System.Drawing.Size(352, 29);
            this.tbxShortName.TabIndex = 2;
            this.tbxShortName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxShortName_KeyPress);
            // 
            // tbxItemName
            // 
            this.tbxItemName.Location = new System.Drawing.Point(101, 25);
            this.tbxItemName.Name = "tbxItemName";
            this.tbxItemName.Size = new System.Drawing.Size(352, 29);
            this.tbxItemName.TabIndex = 1;
            // 
            // btnAddItem
            // 
            this.btnAddItem.BackColor = System.Drawing.Color.White;
            this.btnAddItem.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnAddItem.FlatAppearance.BorderSize = 2;
            this.btnAddItem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddItem.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddItem.ForeColor = System.Drawing.Color.Navy;
            this.btnAddItem.Location = new System.Drawing.Point(1083, 239);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(110, 40);
            this.btnAddItem.TabIndex = 15;
            this.btnAddItem.Text = "&Add Item";
            this.btnAddItem.UseVisualStyleBackColor = false;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // nudDiscount
            // 
            this.nudDiscount.Location = new System.Drawing.Point(627, 130);
            this.nudDiscount.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudDiscount.Name = "nudDiscount";
            this.nudDiscount.Size = new System.Drawing.Size(266, 29);
            this.nudDiscount.TabIndex = 9;
            // 
            // nudItemsCount
            // 
            this.nudItemsCount.Location = new System.Drawing.Point(627, 165);
            this.nudItemsCount.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudItemsCount.Name = "nudItemsCount";
            this.nudItemsCount.Size = new System.Drawing.Size(352, 29);
            this.nudItemsCount.TabIndex = 11;
            this.nudItemsCount.ValueChanged += new System.EventHandler(this.nudItemsCount_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(525, 169);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 21);
            this.label10.TabIndex = 29;
            this.label10.Text = "Items Count";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBrowse);
            this.groupBox2.Controls.Add(this.pbxSnapShot);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(1056, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(133, 192);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Image";
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.White;
            this.btnBrowse.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnBrowse.FlatAppearance.BorderSize = 2;
            this.btnBrowse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.ForeColor = System.Drawing.Color.Navy;
            this.btnBrowse.Location = new System.Drawing.Point(17, 151);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(100, 33);
            this.btnBrowse.TabIndex = 14;
            this.btnBrowse.Text = "&Browse";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // pbxSnapShot
            // 
            this.pbxSnapShot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxSnapShot.Location = new System.Drawing.Point(6, 27);
            this.pbxSnapShot.Name = "pbxSnapShot";
            this.pbxSnapShot.Size = new System.Drawing.Size(120, 120);
            this.pbxSnapShot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxSnapShot.TabIndex = 0;
            this.pbxSnapShot.TabStop = false;
            // 
            // chbDiscountInPercent
            // 
            this.chbDiscountInPercent.AutoSize = true;
            this.chbDiscountInPercent.Location = new System.Drawing.Point(899, 132);
            this.chbDiscountInPercent.Name = "chbDiscountInPercent";
            this.chbDiscountInPercent.Size = new System.Drawing.Size(84, 25);
            this.chbDiscountInPercent.TabIndex = 10;
            this.chbDiscountInPercent.Text = "Percent";
            this.chbDiscountInPercent.UseVisualStyleBackColor = true;
            this.chbDiscountInPercent.CheckedChanged += new System.EventHandler(this.chbDiscountInPercent_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(525, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 21);
            this.label9.TabIndex = 28;
            this.label9.Text = "Discount";
            // 
            // tbxSellingPrice
            // 
            this.tbxSellingPrice.Location = new System.Drawing.Point(627, 95);
            this.tbxSellingPrice.Name = "tbxSellingPrice";
            this.tbxSellingPrice.Size = new System.Drawing.Size(352, 29);
            this.tbxSellingPrice.TabIndex = 8;
            this.tbxSellingPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxSellingPrice_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(525, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 21);
            this.label8.TabIndex = 27;
            this.label8.Text = "Selling Price";
            // 
            // tbxBuyingPrice
            // 
            this.tbxBuyingPrice.Location = new System.Drawing.Point(627, 60);
            this.tbxBuyingPrice.Name = "tbxBuyingPrice";
            this.tbxBuyingPrice.Size = new System.Drawing.Size(352, 29);
            this.tbxBuyingPrice.TabIndex = 7;
            this.tbxBuyingPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxBuyingPrice_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(525, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 21);
            this.label7.TabIndex = 25;
            this.label7.Text = "Buying Price";
            // 
            // cbxVendor
            // 
            this.cbxVendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxVendor.FormattingEnabled = true;
            this.cbxVendor.Location = new System.Drawing.Point(627, 25);
            this.cbxVendor.Name = "cbxVendor";
            this.cbxVendor.Size = new System.Drawing.Size(352, 29);
            this.cbxVendor.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(525, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 21);
            this.label6.TabIndex = 24;
            this.label6.Text = "Vendor";
            // 
            // llUpdateType
            // 
            this.llUpdateType.AutoSize = true;
            this.llUpdateType.Location = new System.Drawing.Point(623, 232);
            this.llUpdateType.Name = "llUpdateType";
            this.llUpdateType.Size = new System.Drawing.Size(110, 21);
            this.llUpdateType.TabIndex = 13;
            this.llUpdateType.TabStop = true;
            this.llUpdateType.Text = "Update &Types";
            this.llUpdateType.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llUpdateType_LinkClicked);
            // 
            // cbxItemType
            // 
            this.cbxItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxItemType.FormattingEnabled = true;
            this.cbxItemType.Location = new System.Drawing.Point(627, 200);
            this.cbxItemType.Name = "cbxItemType";
            this.cbxItemType.Size = new System.Drawing.Size(352, 29);
            this.cbxItemType.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(525, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 21);
            this.label5.TabIndex = 30;
            this.label5.Text = "Type";
            // 
            // llUpdateCategory
            // 
            this.llUpdateCategory.AutoSize = true;
            this.llUpdateCategory.Location = new System.Drawing.Point(97, 232);
            this.llUpdateCategory.Name = "llUpdateCategory";
            this.llUpdateCategory.Size = new System.Drawing.Size(147, 21);
            this.llUpdateCategory.TabIndex = 5;
            this.llUpdateCategory.TabStop = true;
            this.llUpdateCategory.Text = "Update &Categories";
            this.llUpdateCategory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llUpdateCategory_LinkClicked);
            // 
            // cbxItemCategory
            // 
            this.cbxItemCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxItemCategory.FormattingEnabled = true;
            this.cbxItemCategory.Location = new System.Drawing.Point(101, 200);
            this.cbxItemCategory.Name = "cbxItemCategory";
            this.cbxItemCategory.Size = new System.Drawing.Size(352, 29);
            this.cbxItemCategory.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 21);
            this.label4.TabIndex = 23;
            this.label4.Text = "Category";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 21);
            this.label3.TabIndex = 22;
            this.label3.Text = "Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 21);
            this.label2.TabIndex = 21;
            this.label2.Text = "ShortName";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 21);
            this.label1.TabIndex = 20;
            this.label1.Text = "Name";
            // 
            // dgvPOSItems
            // 
            this.dgvPOSItems.AllowUserToAddRows = false;
            this.dgvPOSItems.AllowUserToDeleteRows = false;
            this.dgvPOSItems.AutoGenerateColumns = false;
            this.dgvPOSItems.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPOSItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPOSItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPOSItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.barcodeDataGridViewTextBoxColumn,
            this.shortNameDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.imageDataGridViewImageColumn,
            this.VendorName,
            this.TypeName,
            this.CategoryName,
            this.buyingPriceDataGridViewTextBoxColumn,
            this.sellingPriceDataGridViewTextBoxColumn,
            this.discountDataGridViewTextBoxColumn,
            this.discountInPercentDataGridViewCheckBoxColumn,
            this.totalItemsPurchasedDataGridViewTextBoxColumn,
            this.totalItemsSoldDataGridViewTextBoxColumn});
            this.dgvPOSItems.DataSource = this.bsPOSItemInfo;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPOSItems.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPOSItems.Location = new System.Drawing.Point(8, 348);
            this.dgvPOSItems.MultiSelect = false;
            this.dgvPOSItems.Name = "dgvPOSItems";
            this.dgvPOSItems.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPOSItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPOSItems.RowHeadersVisible = false;
            this.dgvPOSItems.RowTemplate.Height = 50;
            this.dgvPOSItems.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPOSItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPOSItems.Size = new System.Drawing.Size(1199, 283);
            this.dgvPOSItems.TabIndex = 32;
            this.dgvPOSItems.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvPOSItems_DataBindingComplete);
            // 
            // barcodeDataGridViewTextBoxColumn
            // 
            this.barcodeDataGridViewTextBoxColumn.DataPropertyName = "Barcode";
            this.barcodeDataGridViewTextBoxColumn.HeaderText = "Barcode";
            this.barcodeDataGridViewTextBoxColumn.Name = "barcodeDataGridViewTextBoxColumn";
            this.barcodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.barcodeDataGridViewTextBoxColumn.Visible = false;
            this.barcodeDataGridViewTextBoxColumn.Width = 80;
            // 
            // shortNameDataGridViewTextBoxColumn
            // 
            this.shortNameDataGridViewTextBoxColumn.DataPropertyName = "ShortName";
            this.shortNameDataGridViewTextBoxColumn.HeaderText = "Short Name";
            this.shortNameDataGridViewTextBoxColumn.Name = "shortNameDataGridViewTextBoxColumn";
            this.shortNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.shortNameDataGridViewTextBoxColumn.Width = 50;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 180;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descriptionDataGridViewTextBoxColumn.Width = 218;
            // 
            // imageDataGridViewImageColumn
            // 
            this.imageDataGridViewImageColumn.DataPropertyName = "Image";
            this.imageDataGridViewImageColumn.HeaderText = "Image";
            this.imageDataGridViewImageColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.imageDataGridViewImageColumn.Name = "imageDataGridViewImageColumn";
            this.imageDataGridViewImageColumn.ReadOnly = true;
            this.imageDataGridViewImageColumn.Width = 130;
            // 
            // VendorName
            // 
            this.VendorName.DataPropertyName = "VendorName";
            this.VendorName.HeaderText = "Vendor";
            this.VendorName.Name = "VendorName";
            this.VendorName.ReadOnly = true;
            this.VendorName.Width = 120;
            // 
            // TypeName
            // 
            this.TypeName.DataPropertyName = "TypeName";
            this.TypeName.HeaderText = "Type";
            this.TypeName.Name = "TypeName";
            this.TypeName.ReadOnly = true;
            // 
            // CategoryName
            // 
            this.CategoryName.DataPropertyName = "CategoryName";
            this.CategoryName.HeaderText = "Category";
            this.CategoryName.Name = "CategoryName";
            this.CategoryName.ReadOnly = true;
            // 
            // buyingPriceDataGridViewTextBoxColumn
            // 
            this.buyingPriceDataGridViewTextBoxColumn.DataPropertyName = "BuyingPrice";
            this.buyingPriceDataGridViewTextBoxColumn.HeaderText = "Buying Price";
            this.buyingPriceDataGridViewTextBoxColumn.Name = "buyingPriceDataGridViewTextBoxColumn";
            this.buyingPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.buyingPriceDataGridViewTextBoxColumn.Width = 70;
            // 
            // sellingPriceDataGridViewTextBoxColumn
            // 
            this.sellingPriceDataGridViewTextBoxColumn.DataPropertyName = "SellingPrice";
            this.sellingPriceDataGridViewTextBoxColumn.HeaderText = "Selling Price";
            this.sellingPriceDataGridViewTextBoxColumn.Name = "sellingPriceDataGridViewTextBoxColumn";
            this.sellingPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.sellingPriceDataGridViewTextBoxColumn.Width = 70;
            // 
            // discountDataGridViewTextBoxColumn
            // 
            this.discountDataGridViewTextBoxColumn.DataPropertyName = "Discount";
            this.discountDataGridViewTextBoxColumn.HeaderText = "Discount";
            this.discountDataGridViewTextBoxColumn.Name = "discountDataGridViewTextBoxColumn";
            this.discountDataGridViewTextBoxColumn.ReadOnly = true;
            this.discountDataGridViewTextBoxColumn.Width = 62;
            // 
            // discountInPercentDataGridViewCheckBoxColumn
            // 
            this.discountInPercentDataGridViewCheckBoxColumn.DataPropertyName = "DiscountInPercent";
            this.discountInPercentDataGridViewCheckBoxColumn.HeaderText = "%";
            this.discountInPercentDataGridViewCheckBoxColumn.Name = "discountInPercentDataGridViewCheckBoxColumn";
            this.discountInPercentDataGridViewCheckBoxColumn.ReadOnly = true;
            this.discountInPercentDataGridViewCheckBoxColumn.Width = 25;
            // 
            // totalItemsPurchasedDataGridViewTextBoxColumn
            // 
            this.totalItemsPurchasedDataGridViewTextBoxColumn.DataPropertyName = "TotalItemsPurchased";
            this.totalItemsPurchasedDataGridViewTextBoxColumn.HeaderText = "Count";
            this.totalItemsPurchasedDataGridViewTextBoxColumn.Name = "totalItemsPurchasedDataGridViewTextBoxColumn";
            this.totalItemsPurchasedDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalItemsPurchasedDataGridViewTextBoxColumn.Width = 70;
            // 
            // totalItemsSoldDataGridViewTextBoxColumn
            // 
            this.totalItemsSoldDataGridViewTextBoxColumn.DataPropertyName = "TotalItemsSold";
            this.totalItemsSoldDataGridViewTextBoxColumn.HeaderText = "Sold";
            this.totalItemsSoldDataGridViewTextBoxColumn.Name = "totalItemsSoldDataGridViewTextBoxColumn";
            this.totalItemsSoldDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalItemsSoldDataGridViewTextBoxColumn.Visible = false;
            this.totalItemsSoldDataGridViewTextBoxColumn.Width = 50;
            // 
            // bsPOSItemInfo
            // 
            this.bsPOSItemInfo.DataSource = typeof(POSRepository.POSItemInfo);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.White;
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnUpdate.FlatAppearance.BorderSize = 2;
            this.btnUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.Navy;
            this.btnUpdate.Location = new System.Drawing.Point(10, 6);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 40);
            this.btnUpdate.TabIndex = 16;
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnDelete.FlatAppearance.BorderSize = 2;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Navy;
            this.btnDelete.Location = new System.Drawing.Point(116, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 40);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSaveAll
            // 
            this.btnSaveAll.BackColor = System.Drawing.Color.White;
            this.btnSaveAll.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnSaveAll.FlatAppearance.BorderSize = 2;
            this.btnSaveAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSaveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAll.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAll.ForeColor = System.Drawing.Color.Navy;
            this.btnSaveAll.Location = new System.Drawing.Point(1065, 6);
            this.btnSaveAll.Name = "btnSaveAll";
            this.btnSaveAll.Size = new System.Drawing.Size(144, 40);
            this.btnSaveAll.TabIndex = 18;
            this.btnSaveAll.Text = "&Save All Items";
            this.btnSaveAll.UseVisualStyleBackColor = false;
            this.btnSaveAll.Click += new System.EventHandler(this.btnSaveAll_Click);
            // 
            // ofdBrowseImage
            // 
            this.ofdBrowseImage.DefaultExt = "jpeg";
            this.ofdBrowseImage.FileName = "image";
            this.ofdBrowseImage.Filter = "Jpeg Files|*.jpg|Jpg Files|*.jpg|Png Files|*.png";
            this.ofdBrowseImage.Title = "Please select a file";
            this.ofdBrowseImage.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdBrowseImage_FileOk);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Location = new System.Drawing.Point(-1, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1221, 53);
            this.panel1.TabIndex = 36;
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
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel7.Controls.Add(this.btnSaveAll);
            this.panel7.Controls.Add(this.btnUpdate);
            this.panel7.Controls.Add(this.btnDelete);
            this.panel7.Location = new System.Drawing.Point(-2, 644);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1222, 53);
            this.panel7.TabIndex = 37;
            // 
            // btnPurchase
            // 
            this.btnPurchase.BackColor = System.Drawing.Color.White;
            this.btnPurchase.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnPurchase.FlatAppearance.BorderSize = 2;
            this.btnPurchase.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnPurchase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPurchase.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPurchase.ForeColor = System.Drawing.Color.Navy;
            this.btnPurchase.Location = new System.Drawing.Point(967, 239);
            this.btnPurchase.Name = "btnPurchase";
            this.btnPurchase.Size = new System.Drawing.Size(110, 40);
            this.btnPurchase.TabIndex = 32;
            this.btnPurchase.Text = "&Purchase";
            this.btnPurchase.UseVisualStyleBackColor = false;
            this.btnPurchase.Visible = false;
            this.btnPurchase.Click += new System.EventHandler(this.btnPurchase_Click);
            // 
            // POSItemInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1219, 696);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvPOSItems);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "POSItemInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item Info";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudItemsCount)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxSnapShot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPOSItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPOSItemInfo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbxDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxShortName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxItemName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel llUpdateCategory;
        private System.Windows.Forms.ComboBox cbxItemCategory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel llUpdateType;
        private System.Windows.Forms.ComboBox cbxItemType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxVendor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxBuyingPrice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxSellingPrice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chbDiscountInPercent;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.PictureBox pbxSnapShot;
        private System.Windows.Forms.NumericUpDown nudDiscount;
        private System.Windows.Forms.NumericUpDown nudItemsCount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.BindingSource bsPOSItemInfo;
        private System.Windows.Forms.DataGridView dgvPOSItems;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSaveAll;
        private System.Windows.Forms.OpenFileDialog ofdBrowseImage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shortNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn imageDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn VendorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn buyingPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sellingPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn discountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn discountInPercentDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalItemsPurchasedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalItemsSoldDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnPurchase;
    }
}