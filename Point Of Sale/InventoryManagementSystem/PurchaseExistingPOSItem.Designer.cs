namespace InventoryManagementSystem
{
    partial class PurchaseExistingPOSItem
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
            this.btnPurchase = new System.Windows.Forms.Button();
            this.tbxItemsCount = new System.Windows.Forms.TextBox();
            this.tbxNewBuyingPrice = new System.Windows.Forms.TextBox();
            this.tbxOldBuyingPrice = new System.Windows.Forms.TextBox();
            this.tbxOldItemsCount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnReturn = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
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
            this.btnPurchase.Location = new System.Drawing.Point(695, 4);
            this.btnPurchase.Name = "btnPurchase";
            this.btnPurchase.Size = new System.Drawing.Size(111, 41);
            this.btnPurchase.TabIndex = 15;
            this.btnPurchase.Text = "&Purchase";
            this.btnPurchase.UseVisualStyleBackColor = false;
            this.btnPurchase.Click += new System.EventHandler(this.btnPurchase_Click);
            // 
            // tbxItemsCount
            // 
            this.tbxItemsCount.Location = new System.Drawing.Point(150, 130);
            this.tbxItemsCount.Name = "tbxItemsCount";
            this.tbxItemsCount.Size = new System.Drawing.Size(313, 29);
            this.tbxItemsCount.TabIndex = 14;
            this.tbxItemsCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxNewBuyingPrice_KeyPress);
            // 
            // tbxNewBuyingPrice
            // 
            this.tbxNewBuyingPrice.Location = new System.Drawing.Point(150, 60);
            this.tbxNewBuyingPrice.Name = "tbxNewBuyingPrice";
            this.tbxNewBuyingPrice.Size = new System.Drawing.Size(313, 29);
            this.tbxNewBuyingPrice.TabIndex = 12;
            this.tbxNewBuyingPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxNewBuyingPrice_KeyPress);
            // 
            // tbxOldBuyingPrice
            // 
            this.tbxOldBuyingPrice.Enabled = false;
            this.tbxOldBuyingPrice.Location = new System.Drawing.Point(150, 25);
            this.tbxOldBuyingPrice.Name = "tbxOldBuyingPrice";
            this.tbxOldBuyingPrice.Size = new System.Drawing.Size(313, 29);
            this.tbxOldBuyingPrice.TabIndex = 11;
            // 
            // tbxOldItemsCount
            // 
            this.tbxOldItemsCount.Enabled = false;
            this.tbxOldItemsCount.Location = new System.Drawing.Point(150, 95);
            this.tbxOldItemsCount.Name = "tbxOldItemsCount";
            this.tbxOldItemsCount.Size = new System.Drawing.Size(313, 29);
            this.tbxOldItemsCount.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 21);
            this.label4.TabIndex = 18;
            this.label4.Text = "Old Items Count: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 21);
            this.label3.TabIndex = 19;
            this.label3.Text = "Items Count: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 21);
            this.label2.TabIndex = 17;
            this.label2.Text = "New Buying Price: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 21);
            this.label1.TabIndex = 16;
            this.label1.Text = "Old Buying Price: ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbxOldBuyingPrice);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.tbxItemsCount);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tbxNewBuyingPrice);
            this.groupBox2.Controls.Add(this.tbxOldItemsCount);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(12, 55);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(804, 169);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Purchase Details";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Location = new System.Drawing.Point(-1, -6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(819, 53);
            this.panel1.TabIndex = 41;
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
            this.panel7.Controls.Add(this.btnReturn);
            this.panel7.Controls.Add(this.btnPurchase);
            this.panel7.Location = new System.Drawing.Point(-1, 243);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(819, 53);
            this.panel7.TabIndex = 42;
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.White;
            this.btnReturn.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnReturn.FlatAppearance.BorderSize = 2;
            this.btnReturn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturn.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.ForeColor = System.Drawing.Color.Navy;
            this.btnReturn.Location = new System.Drawing.Point(578, 4);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(111, 41);
            this.btnReturn.TabIndex = 16;
            this.btnReturn.Text = "&Return";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // PurchaseExistingPOSItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(817, 293);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PurchaseExistingPOSItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purchase Existing POSItem";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnPurchase;
        private System.Windows.Forms.TextBox tbxItemsCount;
        private System.Windows.Forms.TextBox tbxNewBuyingPrice;
        private System.Windows.Forms.TextBox tbxOldBuyingPrice;
        private System.Windows.Forms.TextBox tbxOldItemsCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnReturn;
    }
}