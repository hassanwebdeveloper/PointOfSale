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
    public partial class ManageExpenseForm : Form
    {
        private List<POSExpenseInfo> mExpenses = null;

        public ManageExpenseForm()
        {
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            
            InitializeComponent();

            if (!LoginForm.mLoggedInUser.IsAdmin)
            {
                if (!LoginForm.mLoggedInUser.UpdateInvExpense)
                {
                    this.btnAddNew.Enabled = false;
                    this.btnDelete.Enabled = false;
                    this.btnUpdate.Enabled = false;
                }
            }

            try
            {
                this.mExpenses = POSDbUtility.GetAllPOSExpenses();
            }
            catch (Exception e)
            {
                string errorMsg = POSComonUtility.GetInnerExceptionMessage(e);
                Cursor.Current = currentCursor;
                MessageBox.Show(this, "Some error occured in fetching expenses.\n\n" + errorMsg);
            }

            if (this.mExpenses == null)
            {
                this.mExpenses = new List<POSExpenseInfo>();
            }

            this.bsPOSExpenseInfo.DataSource = this.mExpenses;

            Cursor.Current = currentCursor;
        }

        private void btnExpenseSearch_Click(object sender, EventArgs e)
        {
            string expenseName = this.tbxExpenseName.Text;

            if (string.IsNullOrEmpty(expenseName))
            {
                MessageBox.Show(this, "Please enter any expense.");
            }
            else
            {
                this.ShowExpenses();
            }
        }

        private void dgvExpneses_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (this.dgvExpneses.Rows.Count == 0)
            {
                return;
            }
            string expenseName = this.tbxExpenseName.Text;

            List<POSExpenseInfo> lstExpenses = this.mExpenses;

            lstExpenses = string.IsNullOrEmpty(expenseName) ? lstExpenses : lstExpenses.FindAll(v => v.Name.Contains(expenseName));

            for (int i = 0; i < lstExpenses.Count; i++)
            {
                DataGridViewRow row = this.dgvExpneses.Rows[i];

                row.Tag = lstExpenses[i];
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            this.tbxExpenseName.Text = string.Empty;

            this.ShowExpenses();
        }

        private void ShowExpenses()
        {
            string expenseName = this.tbxExpenseName.Text;

            if (string.IsNullOrEmpty(expenseName))
            {
                this.bsPOSExpenseInfo.DataSource = null;
                this.bsPOSExpenseInfo.DataSource = this.mExpenses;
            }
            else
            {
                List<POSExpenseInfo> expenses = this.mExpenses;

                List<POSExpenseInfo> filteredExpenses = expenses.FindAll(v => v.Name.ToLower().Contains(expenseName.ToLower()));

                this.bsPOSExpenseInfo.DataSource = null;
                this.bsPOSExpenseInfo.DataSource = filteredExpenses;
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            ExpenseInfoForm expenseInfoForm = new ExpenseInfoForm();

            expenseInfoForm.ShowDialog(this);

            if (expenseInfoForm.mExpenseInfo != null)
            {
                this.mExpenses.Add(expenseInfoForm.mExpenseInfo);

                this.ShowExpenses();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dgvExpneses.SelectedRows != null)
            {
                if (this.dgvExpneses.SelectedRows.Count > 0)
                {

                    string errorMsg = string.Empty;

                    POSExpenseInfo expense = this.dgvExpneses.SelectedRows[0].Tag as POSExpenseInfo;

                    if (expense == null)
                    {
                        MessageBox.Show(this, "Some error occurred, please close window and retry.");
                        return;
                    }
                    
                    DialogResult result = MessageBox.Show(this, "Are you sure you want to delete this expense?", "Confirmation", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        Cursor currentCursor = Cursor.Current;
                        Cursor.Current = Cursors.WaitCursor;
                        
                        POSStatusCodes status = POSDbUtility.DeletePOSExpenseInfo(expense, ref errorMsg, true);

                        Cursor.Current = currentCursor;

                        if (status == POSStatusCodes.Success)
                        {
                            this.mExpenses.Remove(expense);
                            this.ShowExpenses();
                        }
                        else
                        {
                            MessageBox.Show(this, "Some error occured in deleting expense.\n\n" + errorMsg);
                        }

                        
                    }

                }
                else
                {
                    MessageBox.Show(this, "Select any expense to delete.");
                }
            }
            else
            {
                MessageBox.Show(this, "Select any expense to delete.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.dgvExpneses.SelectedRows != null && this.dgvExpneses.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = this.dgvExpneses.SelectedRows[0];

                if (selectedRow.Tag is POSExpenseInfo)
                {
                    POSExpenseInfo expense = selectedRow.Tag as POSExpenseInfo;

                    ExpenseInfoForm expenseInfoForm = new ExpenseInfoForm(expense);

                    expenseInfoForm.ShowDialog(this);

                    POSExpenseInfo updatedExpense = expenseInfoForm.UpdatedExpense;

                    if (updatedExpense != null)
                    {
                        this.ShowExpenses();
                    }

                }
                else
                {
                    MessageBox.Show(this, "Some error occured in opening expense form.");
                }
            }
            else
            {
                MessageBox.Show(this, "Please select any expense to update.");
            }
        }
    }
}
