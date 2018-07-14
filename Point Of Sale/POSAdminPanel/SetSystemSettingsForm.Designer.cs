namespace POSAdminPanel
{
    partial class SetSystemSettingsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvRefundTermsAndCondition = new System.Windows.Forms.DataGridView();
            this.bsRefundTermsAndConditions = new System.Windows.Forms.BindingSource(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.tbxThanksNote = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvBillTermsAndConditions = new System.Windows.Forms.DataGridView();
            this.bsBillTermsAndConditions = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.tbxShopContact = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxShopAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxShopName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.Condition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefundTermsAndCondition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRefundTermsAndConditions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillTermsAndConditions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBillTermsAndConditions)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvRefundTermsAndCondition);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbxThanksNote);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dgvBillTermsAndConditions);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbxShopContact);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbxShopAddress);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbxShopName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(12, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(953, 264);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "System Settings";
            // 
            // dgvRefundTermsAndCondition
            // 
            this.dgvRefundTermsAndCondition.AutoGenerateColumns = false;
            this.dgvRefundTermsAndCondition.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRefundTermsAndCondition.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRefundTermsAndCondition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRefundTermsAndCondition.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.dgvRefundTermsAndCondition.DataSource = this.bsRefundTermsAndConditions;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRefundTermsAndCondition.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRefundTermsAndCondition.Location = new System.Drawing.Point(684, 98);
            this.dgvRefundTermsAndCondition.Name = "dgvRefundTermsAndCondition";
            this.dgvRefundTermsAndCondition.RowTemplate.Height = 25;
            this.dgvRefundTermsAndCondition.Size = new System.Drawing.Size(263, 150);
            this.dgvRefundTermsAndCondition.TabIndex = 81;
            // 
            // bsRefundTermsAndConditions
            // 
            this.bsRefundTermsAndConditions.DataSource = typeof(POSAdminPanel.BillTermsAndConditions);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(462, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(224, 21);
            this.label6.TabIndex = 80;
            this.label6.Text = "Refund Terms and Conditions";
            // 
            // tbxThanksNote
            // 
            this.tbxThanksNote.BackColor = System.Drawing.Color.White;
            this.tbxThanksNote.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxThanksNote.Location = new System.Drawing.Point(684, 63);
            this.tbxThanksNote.Name = "tbxThanksNote";
            this.tbxThanksNote.Size = new System.Drawing.Size(263, 29);
            this.tbxThanksNote.TabIndex = 79;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(462, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 21);
            this.label2.TabIndex = 78;
            this.label2.Text = "Thanks Note";
            // 
            // dgvBillTermsAndConditions
            // 
            this.dgvBillTermsAndConditions.AutoGenerateColumns = false;
            this.dgvBillTermsAndConditions.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBillTermsAndConditions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBillTermsAndConditions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBillTermsAndConditions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Condition});
            this.dgvBillTermsAndConditions.DataSource = this.bsBillTermsAndConditions;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBillTermsAndConditions.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvBillTermsAndConditions.Location = new System.Drawing.Point(198, 98);
            this.dgvBillTermsAndConditions.Name = "dgvBillTermsAndConditions";
            this.dgvBillTermsAndConditions.RowTemplate.Height = 25;
            this.dgvBillTermsAndConditions.Size = new System.Drawing.Size(263, 150);
            this.dgvBillTermsAndConditions.TabIndex = 77;
            // 
            // bsBillTermsAndConditions
            // 
            this.bsBillTermsAndConditions.DataSource = typeof(POSAdminPanel.BillTermsAndConditions);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 21);
            this.label1.TabIndex = 76;
            this.label1.Text = "Bill Terms and Conditions";
            // 
            // tbxShopContact
            // 
            this.tbxShopContact.BackColor = System.Drawing.Color.White;
            this.tbxShopContact.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxShopContact.Location = new System.Drawing.Point(684, 28);
            this.tbxShopContact.Name = "tbxShopContact";
            this.tbxShopContact.Size = new System.Drawing.Size(263, 29);
            this.tbxShopContact.TabIndex = 73;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(462, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 21);
            this.label5.TabIndex = 72;
            this.label5.Text = "Shop Contact";
            // 
            // tbxShopAddress
            // 
            this.tbxShopAddress.BackColor = System.Drawing.Color.White;
            this.tbxShopAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxShopAddress.Location = new System.Drawing.Point(198, 63);
            this.tbxShopAddress.Name = "tbxShopAddress";
            this.tbxShopAddress.Size = new System.Drawing.Size(263, 29);
            this.tbxShopAddress.TabIndex = 71;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 21);
            this.label4.TabIndex = 70;
            this.label4.Text = "Shop Address";
            // 
            // tbxShopName
            // 
            this.tbxShopName.BackColor = System.Drawing.Color.White;
            this.tbxShopName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxShopName.Location = new System.Drawing.Point(198, 28);
            this.tbxShopName.Name = "tbxShopName";
            this.tbxShopName.Size = new System.Drawing.Size(263, 29);
            this.tbxShopName.TabIndex = 69;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 21);
            this.label3.TabIndex = 68;
            this.label3.Text = "Shop Name";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnSave.FlatAppearance.BorderSize = 2;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Navy;
            this.btnSave.Location = new System.Drawing.Point(851, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(108, 41);
            this.btnSave.TabIndex = 67;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel6.Controls.Add(this.btnSave);
            this.panel6.Location = new System.Drawing.Point(-2, 336);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(978, 58);
            this.panel6.TabIndex = 40;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel7.Controls.Add(this.label8);
            this.panel7.Location = new System.Drawing.Point(-2, -2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(978, 53);
            this.panel7.TabIndex = 41;
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
            // Condition
            // 
            this.Condition.DataPropertyName = "Condition";
            this.Condition.HeaderText = "Terms and Conditions";
            this.Condition.Name = "Condition";
            this.Condition.Width = 220;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Condition";
            this.dataGridViewTextBoxColumn1.HeaderText = "Terms and Conditions";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 220;
            // 
            // SetSystemSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(975, 392);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SetSystemSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set System Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefundTermsAndCondition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRefundTermsAndConditions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillTermsAndConditions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBillTermsAndConditions)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbxShopContact;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxShopAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxShopName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tbxThanksNote;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvBillTermsAndConditions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvRefundTermsAndCondition;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.BindingSource bsRefundTermsAndConditions;
        private System.Windows.Forms.BindingSource bsBillTermsAndConditions;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Condition;
    }
}