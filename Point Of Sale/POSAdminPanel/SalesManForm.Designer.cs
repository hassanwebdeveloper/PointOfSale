namespace POSAdminPanel
{
    partial class SalesManForm
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
            this.btnAddSalesMan = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chxInPercent = new System.Windows.Forms.CheckBox();
            this.nudCommision = new System.Windows.Forms.NumericUpDown();
            this.chxCommisioned = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nudSalary = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.chxSalary = new System.Windows.Forms.CheckBox();
            this.tbxContactNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxCnicNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxLastName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.btnPrintCard = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCommision)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSalary)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddSalesMan
            // 
            this.btnAddSalesMan.BackColor = System.Drawing.Color.White;
            this.btnAddSalesMan.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnAddSalesMan.FlatAppearance.BorderSize = 2;
            this.btnAddSalesMan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnAddSalesMan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSalesMan.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSalesMan.ForeColor = System.Drawing.Color.Navy;
            this.btnAddSalesMan.Location = new System.Drawing.Point(465, 6);
            this.btnAddSalesMan.Name = "btnAddSalesMan";
            this.btnAddSalesMan.Size = new System.Drawing.Size(137, 41);
            this.btnAddSalesMan.TabIndex = 23;
            this.btnAddSalesMan.Text = "Add";
            this.btnAddSalesMan.UseVisualStyleBackColor = false;
            this.btnAddSalesMan.Click += new System.EventHandler(this.btnAddSalesMan_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.tbxContactNumber);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbxAddress);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbxCnicNumber);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbxLastName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbxName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(12, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(589, 314);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sales Man";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chxInPercent);
            this.groupBox3.Controls.Add(this.nudCommision);
            this.groupBox3.Controls.Add(this.chxCommisioned);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(294, 198);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(280, 100);
            this.groupBox3.TabIndex = 37;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Commision";
            // 
            // chxInPercent
            // 
            this.chxInPercent.AutoSize = true;
            this.chxInPercent.Location = new System.Drawing.Point(142, 26);
            this.chxInPercent.Name = "chxInPercent";
            this.chxInPercent.Size = new System.Drawing.Size(102, 25);
            this.chxInPercent.TabIndex = 18;
            this.chxInPercent.Text = "In Percent";
            this.chxInPercent.UseVisualStyleBackColor = true;
            // 
            // nudCommision
            // 
            this.nudCommision.Location = new System.Drawing.Point(102, 57);
            this.nudCommision.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudCommision.Name = "nudCommision";
            this.nudCommision.Size = new System.Drawing.Size(168, 29);
            this.nudCommision.TabIndex = 17;
            // 
            // chxCommisioned
            // 
            this.chxCommisioned.AutoSize = true;
            this.chxCommisioned.Location = new System.Drawing.Point(10, 26);
            this.chxCommisioned.Name = "chxCommisioned";
            this.chxCommisioned.Size = new System.Drawing.Size(130, 25);
            this.chxCommisioned.TabIndex = 15;
            this.chxCommisioned.Text = "Commisioned";
            this.chxCommisioned.UseVisualStyleBackColor = true;
            this.chxCommisioned.CheckedChanged += new System.EventHandler(this.chxCommisioned_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 21);
            this.label7.TabIndex = 16;
            this.label7.Text = "Commision";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nudSalary);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.chxSalary);
            this.groupBox2.Location = new System.Drawing.Point(10, 198);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(278, 100);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Salary";
            // 
            // nudSalary
            // 
            this.nudSalary.Location = new System.Drawing.Point(90, 57);
            this.nudSalary.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudSalary.Name = "nudSalary";
            this.nudSalary.Size = new System.Drawing.Size(180, 29);
            this.nudSalary.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 21);
            this.label6.TabIndex = 13;
            this.label6.Text = "Salary";
            // 
            // chxSalary
            // 
            this.chxSalary.AutoSize = true;
            this.chxSalary.Checked = true;
            this.chxSalary.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chxSalary.Location = new System.Drawing.Point(10, 28);
            this.chxSalary.Name = "chxSalary";
            this.chxSalary.Size = new System.Drawing.Size(87, 25);
            this.chxSalary.TabIndex = 0;
            this.chxSalary.Text = "Salaried";
            this.chxSalary.UseVisualStyleBackColor = true;
            this.chxSalary.CheckedChanged += new System.EventHandler(this.chxSalary_CheckedChanged);
            // 
            // tbxContactNumber
            // 
            this.tbxContactNumber.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxContactNumber.Location = new System.Drawing.Point(138, 163);
            this.tbxContactNumber.Name = "tbxContactNumber";
            this.tbxContactNumber.Size = new System.Drawing.Size(436, 29);
            this.tbxContactNumber.TabIndex = 35;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 21);
            this.label5.TabIndex = 34;
            this.label5.Text = "CNIC Number";
            // 
            // tbxAddress
            // 
            this.tbxAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxAddress.Location = new System.Drawing.Point(138, 128);
            this.tbxAddress.Name = "tbxAddress";
            this.tbxAddress.Size = new System.Drawing.Size(436, 29);
            this.tbxAddress.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 21);
            this.label4.TabIndex = 32;
            this.label4.Text = "Address";
            // 
            // tbxCnicNumber
            // 
            this.tbxCnicNumber.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxCnicNumber.Location = new System.Drawing.Point(138, 93);
            this.tbxCnicNumber.Name = "tbxCnicNumber";
            this.tbxCnicNumber.Size = new System.Drawing.Size(436, 29);
            this.tbxCnicNumber.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 21);
            this.label3.TabIndex = 30;
            this.label3.Text = "Contact Number";
            // 
            // tbxLastName
            // 
            this.tbxLastName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxLastName.Location = new System.Drawing.Point(138, 58);
            this.tbxLastName.Name = "tbxLastName";
            this.tbxLastName.Size = new System.Drawing.Size(436, 29);
            this.tbxLastName.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 21);
            this.label2.TabIndex = 28;
            this.label2.Text = "Last Name";
            // 
            // tbxName
            // 
            this.tbxName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxName.Location = new System.Drawing.Point(138, 23);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(436, 29);
            this.tbxName.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 21);
            this.label1.TabIndex = 26;
            this.label1.Text = "Name";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel7.Controls.Add(this.label8);
            this.panel7.Location = new System.Drawing.Point(1, -5);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(614, 53);
            this.panel7.TabIndex = 37;
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
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel6.Controls.Add(this.btnPrintCard);
            this.panel6.Controls.Add(this.btnAddSalesMan);
            this.panel6.Location = new System.Drawing.Point(-1, 379);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(615, 64);
            this.panel6.TabIndex = 38;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // btnPrintCard
            // 
            this.btnPrintCard.BackColor = System.Drawing.Color.White;
            this.btnPrintCard.Enabled = false;
            this.btnPrintCard.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnPrintCard.FlatAppearance.BorderSize = 2;
            this.btnPrintCard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnPrintCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintCard.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintCard.ForeColor = System.Drawing.Color.Navy;
            this.btnPrintCard.Location = new System.Drawing.Point(322, 6);
            this.btnPrintCard.Name = "btnPrintCard";
            this.btnPrintCard.Size = new System.Drawing.Size(137, 41);
            this.btnPrintCard.TabIndex = 24;
            this.btnPrintCard.Text = "Print Card";
            this.btnPrintCard.UseVisualStyleBackColor = false;
            this.btnPrintCard.Click += new System.EventHandler(this.btnPrintCard_Click);
            // 
            // SalesManForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(613, 433);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SalesManForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Man Form";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCommision)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSalary)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddSalesMan;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chxSalary;
        private System.Windows.Forms.TextBox tbxContactNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxCnicNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxLastName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chxInPercent;
        private System.Windows.Forms.NumericUpDown nudCommision;
        private System.Windows.Forms.CheckBox chxCommisioned;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudSalary;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel6;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Button btnPrintCard;
    }
}