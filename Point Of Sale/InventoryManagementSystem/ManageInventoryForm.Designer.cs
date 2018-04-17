namespace InventoryManagementSystem
{
    partial class ManageInventoryForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbxItemName = new System.Windows.Forms.TextBox();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.btnItemSearch = new System.Windows.Forms.Button();
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
            this.btnAddExisting = new System.Windows.Forms.Button();
            this.btnAddNewItems = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPOSItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPOSItemInfo)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbxItemName);
            this.groupBox1.Controls.Add(this.btnShowAll);
            this.groupBox1.Controls.Add(this.btnItemSearch);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(12, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1338, 69);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Item";
            // 
            // tbxItemName
            // 
            this.tbxItemName.Location = new System.Drawing.Point(192, 25);
            this.tbxItemName.Name = "tbxItemName";
            this.tbxItemName.Size = new System.Drawing.Size(844, 29);
            this.tbxItemName.TabIndex = 1;
            // 
            // btnShowAll
            // 
            this.btnShowAll.BackColor = System.Drawing.Color.White;
            this.btnShowAll.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnShowAll.FlatAppearance.BorderSize = 2;
            this.btnShowAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnShowAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowAll.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowAll.ForeColor = System.Drawing.Color.Navy;
            this.btnShowAll.Location = new System.Drawing.Point(1241, 18);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(91, 41);
            this.btnShowAll.TabIndex = 3;
            this.btnShowAll.Text = "Show &All";
            this.btnShowAll.UseVisualStyleBackColor = false;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // btnItemSearch
            // 
            this.btnItemSearch.BackColor = System.Drawing.Color.White;
            this.btnItemSearch.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnItemSearch.FlatAppearance.BorderSize = 2;
            this.btnItemSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnItemSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnItemSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItemSearch.ForeColor = System.Drawing.Color.Navy;
            this.btnItemSearch.Location = new System.Drawing.Point(1144, 18);
            this.btnItemSearch.Name = "btnItemSearch";
            this.btnItemSearch.Size = new System.Drawing.Size(91, 41);
            this.btnItemSearch.TabIndex = 2;
            this.btnItemSearch.Text = "&Search";
            this.btnItemSearch.UseVisualStyleBackColor = false;
            this.btnItemSearch.Click += new System.EventHandler(this.btnItemSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "Item Name or Barcode:";
            // 
            // dgvPOSItems
            // 
            this.dgvPOSItems.AllowUserToAddRows = false;
            this.dgvPOSItems.AllowUserToDeleteRows = false;
            this.dgvPOSItems.AutoGenerateColumns = false;
            this.dgvPOSItems.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPOSItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPOSItems.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPOSItems.GridColor = System.Drawing.Color.Navy;
            this.dgvPOSItems.Location = new System.Drawing.Point(12, 132);
            this.dgvPOSItems.MultiSelect = false;
            this.dgvPOSItems.Name = "dgvPOSItems";
            this.dgvPOSItems.ReadOnly = true;
            this.dgvPOSItems.RowHeadersVisible = false;
            this.dgvPOSItems.RowTemplate.Height = 50;
            this.dgvPOSItems.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPOSItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPOSItems.Size = new System.Drawing.Size(1338, 356);
            this.dgvPOSItems.TabIndex = 9;
            this.dgvPOSItems.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvPOSItems_DataBindingComplete);
            // 
            // barcodeDataGridViewTextBoxColumn
            // 
            this.barcodeDataGridViewTextBoxColumn.DataPropertyName = "Barcode";
            this.barcodeDataGridViewTextBoxColumn.HeaderText = "Barcode";
            this.barcodeDataGridViewTextBoxColumn.Name = "barcodeDataGridViewTextBoxColumn";
            this.barcodeDataGridViewTextBoxColumn.ReadOnly = true;
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
            this.nameDataGridViewTextBoxColumn.Width = 210;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descriptionDataGridViewTextBoxColumn.Width = 200;
            // 
            // imageDataGridViewImageColumn
            // 
            this.imageDataGridViewImageColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.imageDataGridViewImageColumn.DataPropertyName = "Image";
            this.imageDataGridViewImageColumn.HeaderText = "Image";
            this.imageDataGridViewImageColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.imageDataGridViewImageColumn.Name = "imageDataGridViewImageColumn";
            this.imageDataGridViewImageColumn.ReadOnly = true;
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
            this.discountDataGridViewTextBoxColumn.Width = 60;
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
            this.totalItemsPurchasedDataGridViewTextBoxColumn.HeaderText = "Purchased";
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
            this.totalItemsSoldDataGridViewTextBoxColumn.Width = 50;
            // 
            // bsPOSItemInfo
            // 
            this.bsPOSItemInfo.DataSource = typeof(POSRepository.POSItemInfo);
            // 
            // btnAddExisting
            // 
            this.btnAddExisting.BackColor = System.Drawing.Color.White;
            this.btnAddExisting.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnAddExisting.FlatAppearance.BorderSize = 2;
            this.btnAddExisting.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnAddExisting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddExisting.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddExisting.ForeColor = System.Drawing.Color.Navy;
            this.btnAddExisting.Location = new System.Drawing.Point(1133, 10);
            this.btnAddExisting.Name = "btnAddExisting";
            this.btnAddExisting.Size = new System.Drawing.Size(106, 41);
            this.btnAddExisting.TabIndex = 5;
            this.btnAddExisting.Text = "&Update";
            this.btnAddExisting.UseVisualStyleBackColor = false;
            this.btnAddExisting.Click += new System.EventHandler(this.btnAddExisting_Click);
            // 
            // btnAddNewItems
            // 
            this.btnAddNewItems.BackColor = System.Drawing.Color.White;
            this.btnAddNewItems.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnAddNewItems.FlatAppearance.BorderSize = 2;
            this.btnAddNewItems.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnAddNewItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewItems.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewItems.ForeColor = System.Drawing.Color.Navy;
            this.btnAddNewItems.Location = new System.Drawing.Point(1245, 10);
            this.btnAddNewItems.Name = "btnAddNewItems";
            this.btnAddNewItems.Size = new System.Drawing.Size(106, 41);
            this.btnAddNewItems.TabIndex = 4;
            this.btnAddNewItems.Text = "New";
            this.btnAddNewItems.UseVisualStyleBackColor = false;
            this.btnAddNewItems.Click += new System.EventHandler(this.btnAddNewItems_Click);
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
            this.btnDelete.Location = new System.Drawing.Point(1021, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(106, 41);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel6.Controls.Add(this.btnAddNewItems);
            this.panel6.Controls.Add(this.btnDelete);
            this.panel6.Controls.Add(this.btnAddExisting);
            this.panel6.Location = new System.Drawing.Point(-1, 512);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1361, 64);
            this.panel6.TabIndex = 29;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel7.Controls.Add(this.label7);
            this.panel7.Location = new System.Drawing.Point(-1, -2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1361, 53);
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
            // ManageInventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1358, 574);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.dgvPOSItems);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ManageInventoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Inventory";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPOSItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPOSItemInfo)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Button btnItemSearch;
        private System.Windows.Forms.TextBox tbxItemName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPOSItems;
        private System.Windows.Forms.BindingSource bsPOSItemInfo;
        private System.Windows.Forms.Button btnAddExisting;
        private System.Windows.Forms.Button btnAddNewItems;
        private System.Windows.Forms.Button btnDelete;
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
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label7;
    }
}