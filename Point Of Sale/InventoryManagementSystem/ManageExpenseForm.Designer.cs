namespace InventoryManagementSystem
{
    partial class ManageExpenseForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbxExpenseName = new System.Windows.Forms.TextBox();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.btnExpenseSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvExpneses = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expenseTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ammountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsPOSExpenseInfo = new System.Windows.Forms.BindingSource(this.components);
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpneses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPOSExpenseInfo)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbxExpenseName);
            this.groupBox1.Controls.Add(this.btnShowAll);
            this.groupBox1.Controls.Add(this.btnExpenseSearch);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(12, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(761, 69);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Expense";
            // 
            // tbxExpenseName
            // 
            this.tbxExpenseName.Location = new System.Drawing.Point(130, 22);
            this.tbxExpenseName.Name = "tbxExpenseName";
            this.tbxExpenseName.Size = new System.Drawing.Size(420, 29);
            this.tbxExpenseName.TabIndex = 1;
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
            this.btnShowAll.Location = new System.Drawing.Point(664, 19);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(91, 41);
            this.btnShowAll.TabIndex = 3;
            this.btnShowAll.Text = "Show &All";
            this.btnShowAll.UseVisualStyleBackColor = false;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // btnExpenseSearch
            // 
            this.btnExpenseSearch.BackColor = System.Drawing.Color.White;
            this.btnExpenseSearch.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnExpenseSearch.FlatAppearance.BorderSize = 2;
            this.btnExpenseSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnExpenseSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpenseSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpenseSearch.ForeColor = System.Drawing.Color.Navy;
            this.btnExpenseSearch.Location = new System.Drawing.Point(567, 19);
            this.btnExpenseSearch.Name = "btnExpenseSearch";
            this.btnExpenseSearch.Size = new System.Drawing.Size(91, 41);
            this.btnExpenseSearch.TabIndex = 2;
            this.btnExpenseSearch.Text = "&Search";
            this.btnExpenseSearch.UseVisualStyleBackColor = false;
            this.btnExpenseSearch.Click += new System.EventHandler(this.btnExpenseSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "Expense Name: ";
            // 
            // dgvExpneses
            // 
            this.dgvExpneses.AllowUserToAddRows = false;
            this.dgvExpneses.AllowUserToDeleteRows = false;
            this.dgvExpneses.AutoGenerateColumns = false;
            this.dgvExpneses.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExpneses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvExpneses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExpneses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.expenseTimeDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.ammountDataGridViewTextBoxColumn,
            this.AppUserName,
            this.locationDataGridViewTextBoxColumn});
            this.dgvExpneses.DataSource = this.bsPOSExpenseInfo;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvExpneses.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvExpneses.Location = new System.Drawing.Point(12, 140);
            this.dgvExpneses.MultiSelect = false;
            this.dgvExpneses.Name = "dgvExpneses";
            this.dgvExpneses.ReadOnly = true;
            this.dgvExpneses.RowHeadersVisible = false;
            this.dgvExpneses.RowTemplate.Height = 25;
            this.dgvExpneses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExpneses.Size = new System.Drawing.Size(761, 357);
            this.dgvExpneses.TabIndex = 7;
            this.dgvExpneses.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvExpneses_DataBindingComplete);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 50;
            // 
            // expenseTimeDataGridViewTextBoxColumn
            // 
            this.expenseTimeDataGridViewTextBoxColumn.DataPropertyName = "ExpenseTime";
            this.expenseTimeDataGridViewTextBoxColumn.HeaderText = "Expense Time";
            this.expenseTimeDataGridViewTextBoxColumn.Name = "expenseTimeDataGridViewTextBoxColumn";
            this.expenseTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.expenseTimeDataGridViewTextBoxColumn.Width = 120;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Expense";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 268;
            // 
            // ammountDataGridViewTextBoxColumn
            // 
            this.ammountDataGridViewTextBoxColumn.DataPropertyName = "Ammount";
            this.ammountDataGridViewTextBoxColumn.HeaderText = "Ammount";
            this.ammountDataGridViewTextBoxColumn.Name = "ammountDataGridViewTextBoxColumn";
            this.ammountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // AppUserName
            // 
            this.AppUserName.DataPropertyName = "AppUserName";
            this.AppUserName.HeaderText = "App User";
            this.AppUserName.Name = "AppUserName";
            this.AppUserName.ReadOnly = true;
            this.AppUserName.Width = 110;
            // 
            // locationDataGridViewTextBoxColumn
            // 
            this.locationDataGridViewTextBoxColumn.DataPropertyName = "Location";
            this.locationDataGridViewTextBoxColumn.HeaderText = "Location";
            this.locationDataGridViewTextBoxColumn.Name = "locationDataGridViewTextBoxColumn";
            this.locationDataGridViewTextBoxColumn.ReadOnly = true;
            this.locationDataGridViewTextBoxColumn.Width = 110;
            // 
            // bsPOSExpenseInfo
            // 
            this.bsPOSExpenseInfo.DataSource = typeof(POSRepository.POSExpenseInfo);
            // 
            // btnAddNew
            // 
            this.btnAddNew.BackColor = System.Drawing.Color.White;
            this.btnAddNew.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnAddNew.FlatAppearance.BorderSize = 2;
            this.btnAddNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNew.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.ForeColor = System.Drawing.Color.Navy;
            this.btnAddNew.Location = new System.Drawing.Point(684, 7);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(91, 41);
            this.btnAddNew.TabIndex = 4;
            this.btnAddNew.Text = "Add &New";
            this.btnAddNew.UseVisualStyleBackColor = false;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
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
            this.btnDelete.Location = new System.Drawing.Point(490, 7);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(91, 41);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel7.Controls.Add(this.btnUpdate);
            this.panel7.Controls.Add(this.btnAddNew);
            this.panel7.Controls.Add(this.btnDelete);
            this.panel7.Location = new System.Drawing.Point(-2, 512);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(791, 53);
            this.panel7.TabIndex = 31;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(-2, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(791, 53);
            this.panel1.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(38, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 43);
            this.label2.TabIndex = 34;
            this.label2.Text = "Inventory";
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
            this.btnUpdate.Location = new System.Drawing.Point(587, 7);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(91, 41);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // ManageExpenseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(785, 564);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.dgvExpneses);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ManageExpenseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Expenses";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpneses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPOSExpenseInfo)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExpenseSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvExpneses;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxExpenseName;
        private System.Windows.Forms.BindingSource bsPOSExpenseInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expenseTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ammountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnUpdate;
    }
}