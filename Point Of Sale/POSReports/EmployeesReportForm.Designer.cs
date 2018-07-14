namespace POSReports
{
    partial class EmployeesReportForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.bsPOSGridItemInfo = new System.Windows.Forms.BindingSource(this.components);
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxSalesMans = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.rdbDayWise = new System.Windows.Forms.RadioButton();
            this.rdbMonthWise = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.bsPOSGridItemInfo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 21);
            this.label4.TabIndex = 5;
            this.label4.Text = "Sales Man:";
            // 
            // bsPOSGridItemInfo
            // 
            this.bsPOSGridItemInfo.DataSource = typeof(POSRepository.POSGridItemInfo);
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.BackColor = System.Drawing.Color.White;
            this.btnGenerateReport.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnGenerateReport.FlatAppearance.BorderSize = 2;
            this.btnGenerateReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnGenerateReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateReport.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateReport.ForeColor = System.Drawing.Color.Navy;
            this.btnGenerateReport.Location = new System.Drawing.Point(593, 13);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(123, 36);
            this.btnGenerateReport.TabIndex = 4;
            this.btnGenerateReport.Text = "&Generate";
            this.btnGenerateReport.UseVisualStyleBackColor = false;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxSalesMans);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(12, 61);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(704, 71);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Sales Man";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel6.Controls.Add(this.btnGenerateReport);
            this.panel6.Location = new System.Drawing.Point(-3, 287);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(734, 64);
            this.panel6.TabIndex = 32;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel7.Controls.Add(this.label7);
            this.panel7.Location = new System.Drawing.Point(-1, -4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(730, 53);
            this.panel7.TabIndex = 33;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Monotype Corsiva", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(38, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 43);
            this.label7.TabIndex = 34;
            this.label7.Text = "Reports";
            // 
            // cbxSalesMans
            // 
            this.cbxSalesMans.FormattingEnabled = true;
            this.cbxSalesMans.Location = new System.Drawing.Point(98, 27);
            this.cbxSalesMans.Name = "cbxSalesMans";
            this.cbxSalesMans.Size = new System.Drawing.Size(331, 29);
            this.cbxSalesMans.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbMonthWise);
            this.groupBox2.Controls.Add(this.rdbDayWise);
            this.groupBox2.Controls.Add(this.dtpTo);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dtpFrom);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(12, 142);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(704, 108);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Date Range";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "From:";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(65, 24);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(285, 29);
            this.dtpFrom.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(366, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "To:";
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(403, 24);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(285, 29);
            this.dtpTo.TabIndex = 8;
            // 
            // rdbDayWise
            // 
            this.rdbDayWise.AutoSize = true;
            this.rdbDayWise.Location = new System.Drawing.Point(65, 65);
            this.rdbDayWise.Name = "rdbDayWise";
            this.rdbDayWise.Size = new System.Drawing.Size(94, 25);
            this.rdbDayWise.TabIndex = 9;
            this.rdbDayWise.TabStop = true;
            this.rdbDayWise.Text = "Day Wise";
            this.rdbDayWise.UseVisualStyleBackColor = true;
            // 
            // rdbMonthWise
            // 
            this.rdbMonthWise.AutoSize = true;
            this.rdbMonthWise.Location = new System.Drawing.Point(165, 65);
            this.rdbMonthWise.Name = "rdbMonthWise";
            this.rdbMonthWise.Size = new System.Drawing.Size(116, 25);
            this.rdbMonthWise.TabIndex = 10;
            this.rdbMonthWise.TabStop = true;
            this.rdbMonthWise.Text = "Month Wise";
            this.rdbMonthWise.UseVisualStyleBackColor = true;
            // 
            // EmployeesReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(728, 350);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EmployeesReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employees Report Form";
            ((System.ComponentModel.ISupportInitialize)(this.bsPOSGridItemInfo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.BindingSource bsPOSGridItemInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxSalesMans;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdbMonthWise;
        private System.Windows.Forms.RadioButton rdbDayWise;
    }
}