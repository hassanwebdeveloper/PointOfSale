namespace POSAdminPanel
{
    partial class SalesManListForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.btnSearchUser = new System.Windows.Forms.Button();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdateUser = new System.Windows.Forms.Button();
            this.btnAddNewUser = new System.Windows.Forms.Button();
            this.dgvSalesMan = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNICNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salariedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.salaryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commisionedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.inPercentDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.commisionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsPOSSalesMan = new System.Windows.Forms.BindingSource(this.components);
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesMan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPOSSalesMan)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnShowAll);
            this.groupBox1.Controls.Add(this.btnSearchUser);
            this.groupBox1.Controls.Add(this.tbxName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(12, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1091, 69);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Sales Man";
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
            this.btnShowAll.Location = new System.Drawing.Point(994, 18);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(91, 41);
            this.btnShowAll.TabIndex = 3;
            this.btnShowAll.Text = "Show &All";
            this.btnShowAll.UseVisualStyleBackColor = false;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // btnSearchUser
            // 
            this.btnSearchUser.BackColor = System.Drawing.Color.White;
            this.btnSearchUser.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnSearchUser.FlatAppearance.BorderSize = 2;
            this.btnSearchUser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSearchUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchUser.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchUser.ForeColor = System.Drawing.Color.Navy;
            this.btnSearchUser.Location = new System.Drawing.Point(897, 18);
            this.btnSearchUser.Name = "btnSearchUser";
            this.btnSearchUser.Size = new System.Drawing.Size(91, 41);
            this.btnSearchUser.TabIndex = 2;
            this.btnSearchUser.Text = "&Search";
            this.btnSearchUser.UseVisualStyleBackColor = false;
            this.btnSearchUser.Click += new System.EventHandler(this.btnSearchUser_Click);
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(64, 25);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(815, 29);
            this.tbxName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "Name";
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
            this.btnDelete.Location = new System.Drawing.Point(649, 8);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(153, 41);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "&Delete Sales Man";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdateUser
            // 
            this.btnUpdateUser.BackColor = System.Drawing.Color.White;
            this.btnUpdateUser.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnUpdateUser.FlatAppearance.BorderSize = 2;
            this.btnUpdateUser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnUpdateUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateUser.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateUser.ForeColor = System.Drawing.Color.Navy;
            this.btnUpdateUser.Location = new System.Drawing.Point(808, 8);
            this.btnUpdateUser.Name = "btnUpdateUser";
            this.btnUpdateUser.Size = new System.Drawing.Size(154, 41);
            this.btnUpdateUser.TabIndex = 11;
            this.btnUpdateUser.Text = "&Update Sales Man";
            this.btnUpdateUser.UseVisualStyleBackColor = false;
            this.btnUpdateUser.Click += new System.EventHandler(this.btnUpdateUser_Click);
            // 
            // btnAddNewUser
            // 
            this.btnAddNewUser.BackColor = System.Drawing.Color.White;
            this.btnAddNewUser.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnAddNewUser.FlatAppearance.BorderSize = 2;
            this.btnAddNewUser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnAddNewUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewUser.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewUser.ForeColor = System.Drawing.Color.Navy;
            this.btnAddNewUser.Location = new System.Drawing.Point(968, 8);
            this.btnAddNewUser.Name = "btnAddNewUser";
            this.btnAddNewUser.Size = new System.Drawing.Size(137, 41);
            this.btnAddNewUser.TabIndex = 10;
            this.btnAddNewUser.Text = "&New Sales Man";
            this.btnAddNewUser.UseVisualStyleBackColor = false;
            this.btnAddNewUser.Click += new System.EventHandler(this.btnAddNewUser_Click);
            // 
            // dgvSalesMan
            // 
            this.dgvSalesMan.AllowUserToAddRows = false;
            this.dgvSalesMan.AutoGenerateColumns = false;
            this.dgvSalesMan.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalesMan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSalesMan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesMan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.lastNameDataGridViewTextBoxColumn,
            this.cNICNumberDataGridViewTextBoxColumn,
            this.contactNumberDataGridViewTextBoxColumn,
            this.salariedDataGridViewCheckBoxColumn,
            this.salaryDataGridViewTextBoxColumn,
            this.commisionedDataGridViewCheckBoxColumn,
            this.inPercentDataGridViewCheckBoxColumn,
            this.commisionDataGridViewTextBoxColumn});
            this.dgvSalesMan.DataSource = this.bsPOSSalesMan;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalesMan.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSalesMan.Location = new System.Drawing.Point(12, 140);
            this.dgvSalesMan.MultiSelect = false;
            this.dgvSalesMan.Name = "dgvSalesMan";
            this.dgvSalesMan.ReadOnly = true;
            this.dgvSalesMan.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSalesMan.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSalesMan.RowTemplate.Height = 25;
            this.dgvSalesMan.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalesMan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSalesMan.Size = new System.Drawing.Size(1091, 323);
            this.dgvSalesMan.TabIndex = 9;
            this.dgvSalesMan.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvPOSItems_DataBindingComplete);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 200;
            // 
            // lastNameDataGridViewTextBoxColumn
            // 
            this.lastNameDataGridViewTextBoxColumn.DataPropertyName = "LastName";
            this.lastNameDataGridViewTextBoxColumn.HeaderText = "LastName";
            this.lastNameDataGridViewTextBoxColumn.Name = "lastNameDataGridViewTextBoxColumn";
            this.lastNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.lastNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // cNICNumberDataGridViewTextBoxColumn
            // 
            this.cNICNumberDataGridViewTextBoxColumn.DataPropertyName = "CNICNumber";
            this.cNICNumberDataGridViewTextBoxColumn.HeaderText = "CNICNumber";
            this.cNICNumberDataGridViewTextBoxColumn.Name = "cNICNumberDataGridViewTextBoxColumn";
            this.cNICNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.cNICNumberDataGridViewTextBoxColumn.Width = 145;
            // 
            // contactNumberDataGridViewTextBoxColumn
            // 
            this.contactNumberDataGridViewTextBoxColumn.DataPropertyName = "ContactNumber";
            this.contactNumberDataGridViewTextBoxColumn.HeaderText = "ContactNumber";
            this.contactNumberDataGridViewTextBoxColumn.Name = "contactNumberDataGridViewTextBoxColumn";
            this.contactNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.contactNumberDataGridViewTextBoxColumn.Width = 150;
            // 
            // salariedDataGridViewCheckBoxColumn
            // 
            this.salariedDataGridViewCheckBoxColumn.DataPropertyName = "Salaried";
            this.salariedDataGridViewCheckBoxColumn.HeaderText = "Salaried";
            this.salariedDataGridViewCheckBoxColumn.Name = "salariedDataGridViewCheckBoxColumn";
            this.salariedDataGridViewCheckBoxColumn.ReadOnly = true;
            this.salariedDataGridViewCheckBoxColumn.Width = 70;
            // 
            // salaryDataGridViewTextBoxColumn
            // 
            this.salaryDataGridViewTextBoxColumn.DataPropertyName = "Salary";
            this.salaryDataGridViewTextBoxColumn.HeaderText = "Salary";
            this.salaryDataGridViewTextBoxColumn.Name = "salaryDataGridViewTextBoxColumn";
            this.salaryDataGridViewTextBoxColumn.ReadOnly = true;
            this.salaryDataGridViewTextBoxColumn.Width = 90;
            // 
            // commisionedDataGridViewCheckBoxColumn
            // 
            this.commisionedDataGridViewCheckBoxColumn.DataPropertyName = "Commisioned";
            this.commisionedDataGridViewCheckBoxColumn.HeaderText = "Commisioned";
            this.commisionedDataGridViewCheckBoxColumn.Name = "commisionedDataGridViewCheckBoxColumn";
            this.commisionedDataGridViewCheckBoxColumn.ReadOnly = true;
            this.commisionedDataGridViewCheckBoxColumn.Width = 110;
            // 
            // inPercentDataGridViewCheckBoxColumn
            // 
            this.inPercentDataGridViewCheckBoxColumn.DataPropertyName = "InPercent";
            this.inPercentDataGridViewCheckBoxColumn.HeaderText = "InPercent";
            this.inPercentDataGridViewCheckBoxColumn.Name = "inPercentDataGridViewCheckBoxColumn";
            this.inPercentDataGridViewCheckBoxColumn.ReadOnly = true;
            this.inPercentDataGridViewCheckBoxColumn.Width = 80;
            // 
            // commisionDataGridViewTextBoxColumn
            // 
            this.commisionDataGridViewTextBoxColumn.DataPropertyName = "Commision";
            this.commisionDataGridViewTextBoxColumn.HeaderText = "Commision";
            this.commisionDataGridViewTextBoxColumn.Name = "commisionDataGridViewTextBoxColumn";
            this.commisionDataGridViewTextBoxColumn.ReadOnly = true;
            this.commisionDataGridViewTextBoxColumn.Width = 93;
            // 
            // bsPOSSalesMan
            // 
            this.bsPOSSalesMan.DataSource = typeof(POSRepository.POSSalesMan);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel6.Controls.Add(this.btnAddNewUser);
            this.panel6.Controls.Add(this.btnDelete);
            this.panel6.Controls.Add(this.btnUpdateUser);
            this.panel6.Location = new System.Drawing.Point(-2, 484);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1118, 64);
            this.panel6.TabIndex = 39;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel7.Controls.Add(this.label8);
            this.panel7.Location = new System.Drawing.Point(-2, -4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1118, 53);
            this.panel7.TabIndex = 40;
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
            // SalesManListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1115, 545);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.dgvSalesMan);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SalesManListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Men List";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesMan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPOSSalesMan)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Button btnSearchUser;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdateUser;
        private System.Windows.Forms.Button btnAddNewUser;
        private System.Windows.Forms.DataGridView dgvSalesMan;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNICNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn salariedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salaryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn commisionedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn inPercentDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commisionDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bsPOSSalesMan;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label8;
    }
}