namespace Point_Of_Sale
{
    partial class Form1
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
            this.btnCreateBill = new System.Windows.Forms.Button();
            this.btnRefund = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.btnManageExpenses = new System.Windows.Forms.Button();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreateBill
            // 
            this.btnCreateBill.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnCreateBill.FlatAppearance.BorderSize = 2;
            this.btnCreateBill.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnCreateBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateBill.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateBill.ForeColor = System.Drawing.Color.Navy;
            this.btnCreateBill.Location = new System.Drawing.Point(8, 80);
            this.btnCreateBill.Name = "btnCreateBill";
            this.btnCreateBill.Size = new System.Drawing.Size(137, 41);
            this.btnCreateBill.TabIndex = 1;
            this.btnCreateBill.Text = "&Create Bill";
            this.btnCreateBill.UseVisualStyleBackColor = true;
            this.btnCreateBill.Click += new System.EventHandler(this.btnCreateBill_Click);
            // 
            // btnRefund
            // 
            this.btnRefund.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnRefund.FlatAppearance.BorderSize = 2;
            this.btnRefund.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnRefund.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefund.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefund.ForeColor = System.Drawing.Color.Navy;
            this.btnRefund.Location = new System.Drawing.Point(151, 80);
            this.btnRefund.Name = "btnRefund";
            this.btnRefund.Size = new System.Drawing.Size(137, 41);
            this.btnRefund.TabIndex = 2;
            this.btnRefund.Text = "&Refund";
            this.btnRefund.UseVisualStyleBackColor = true;
            this.btnRefund.Click += new System.EventHandler(this.btnRefund_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnSearch.FlatAppearance.BorderSize = 2;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.Navy;
            this.btnSearch.Location = new System.Drawing.Point(294, 80);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(137, 41);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel7.Controls.Add(this.label7);
            this.panel7.Location = new System.Drawing.Point(-2, -2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(610, 53);
            this.panel7.TabIndex = 31;
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
            // btnManageExpenses
            // 
            this.btnManageExpenses.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnManageExpenses.FlatAppearance.BorderSize = 2;
            this.btnManageExpenses.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnManageExpenses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageExpenses.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageExpenses.ForeColor = System.Drawing.Color.Navy;
            this.btnManageExpenses.Location = new System.Drawing.Point(437, 80);
            this.btnManageExpenses.Name = "btnManageExpenses";
            this.btnManageExpenses.Size = new System.Drawing.Size(159, 41);
            this.btnManageExpenses.TabIndex = 32;
            this.btnManageExpenses.Text = "Manage Expenses";
            this.btnManageExpenses.UseVisualStyleBackColor = true;
            this.btnManageExpenses.Click += new System.EventHandler(this.btnManageExpenses_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(606, 160);
            this.Controls.Add(this.btnManageExpenses);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnRefund);
            this.Controls.Add(this.btnCreateBill);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Point of Sale";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateBill;
        private System.Windows.Forms.Button btnRefund;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnManageExpenses;
    }
}

