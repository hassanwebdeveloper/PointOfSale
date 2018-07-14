using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            if (!LoginForm.mLoggedInUser.IsAdmin)
            {
                if (!LoginForm.mLoggedInUser.ViewItems)
                {
                    this.btnAddInventory.Enabled = false;
                }

                if (!LoginForm.mLoggedInUser.ViewVendors)
                {
                    this.btnManageVendors.Enabled = false;
                }

                if (!LoginForm.mLoggedInUser.PrintBarcode)
                {
                    this.btnPrintBarcode.Enabled = false;
                }

                if (!LoginForm.mLoggedInUser.ViewInvExpense)
                {
                    this.btnManageExpense.Enabled = false;
                }
            }
        }

        private void btnManageVendors_Click(object sender, EventArgs e)
        {
            ManageVendorsForm manageVendors = new ManageVendorsForm();

            manageVendors.ShowDialog(this);
        }

        private void btnAddInventory_Click(object sender, EventArgs e)
        {
            ManageInventoryForm manageInventoryForm = new ManageInventoryForm();

            manageInventoryForm.ShowDialog(this);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoginForm.mMainForm.Close();
        }

        private void btnPrintBarcode_Click(object sender, EventArgs e)
        {
            PrintBarcodeForm printBarcodeForm = new PrintBarcodeForm();

            printBarcodeForm.ShowDialog(this);
        }

        private void btnManageExpense_Click(object sender, EventArgs e)
        {
            ManageExpenseForm manageExpenseForm = new ManageExpenseForm();

            manageExpenseForm.ShowDialog(this);
        }
    }
}
