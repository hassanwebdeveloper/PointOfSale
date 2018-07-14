using POSRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class ExpenseInfoForm : Form
    {
        private const string LOCATION = "Inventory";

        public POSExpenseInfo mExpenseInfo = null;

        public ExpenseInfoForm()
        {
            InitializeComponent();
            this.btnAdd.Tag = false;
        }

        public ExpenseInfoForm(POSExpenseInfo expenseInfo)
        {
            InitializeComponent();

            this.mExpenseInfo = expenseInfo;

            this.tbxExpense.Text = this.mExpenseInfo.Name;
            this.tbxAmount.Text = this.mExpenseInfo.Ammount.ToString();
            
            this.btnAdd.Text = "&Update Expense";
            this.btnAdd.Tag = true;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool isValid = POSComonUtility.ValidateInputs(new List<TextBox>() { this.tbxExpense, this.tbxAmount});
            string errorMsg = string.Empty;

            if (isValid)
            {
                Cursor currentCursor = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;
            
                bool saved = Convert.ToBoolean(this.btnAdd.Tag);
                if (saved)
                {
                    POSExpenseInfo expense = POSFactory.CreateOrUpdatePOSExpenseInfo(this.mExpenseInfo, this.tbxExpense.Text, LOCATION, Convert.ToInt32(this.tbxAmount.Text), DateTime.Now, LoginForm.mLoggedInUser);

                    POSStatusCodes status = POSDbUtility.UpdatePOSExpenseInfo(expense, ref errorMsg);

                    if (status == POSStatusCodes.Success)
                    {
                        this.UpdatedExpense = this.mExpenseInfo;                        
                    }
                    else
                    {
                        Cursor.Current = currentCursor;
                        MessageBox.Show(this, "Some error occured in updating expense.\n\n" + errorMsg);
                    }
                }
                else
                {

                    POSExpenseInfo expense = POSFactory.CreateOrUpdatePOSExpenseInfo(this.mExpenseInfo, this.tbxExpense.Text, LOCATION, Convert.ToInt32(this.tbxAmount.Text), DateTime.Now, LoginForm.mLoggedInUser);
                                        
                    POSStatusCodes status = POSDbUtility.AddPOSExpenseInfo(expense, ref errorMsg, true);

                    if (status == POSStatusCodes.Success)
                    {
                        this.mExpenseInfo = expense;
                        this.btnAdd.Text = "&Update Expense";
                        this.btnAdd.Tag = true;
                    }
                    else
                    {
                        Cursor.Current = currentCursor;
                        MessageBox.Show(this, "Some error occured in adding expense.\n\n" + errorMsg);
                    }
                }

                Cursor.Current = currentCursor;
            }
        }

        public POSExpenseInfo UpdatedExpense { get; set; }

        private void tbxAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            POSComonUtility.AllowNumericOnly(e);
        }
    }
}
