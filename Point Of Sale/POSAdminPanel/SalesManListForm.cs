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

namespace POSAdminPanel
{
    public partial class SalesManListForm : Form
    {
        private List<POSSalesMan> mlstSalesMans = null;

        public SalesManListForm()
        {
            InitializeComponent();

            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                this.mlstSalesMans = POSDbUtility.GetAllPOSSalesMan(-1);
            }
            catch (Exception ex)
            {
                string errorMsg = POSComonUtility.GetInnerExceptionMessage(ex);
                Cursor.Current = currentCursor;
                MessageBox.Show(this, "Some error occured in fetching sales man.\n\n" + errorMsg);
            }

            Cursor.Current = currentCursor;

            this.bsPOSSalesMan.DataSource = this.mlstSalesMans;
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            this.ShowAll();
        }

        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            this.SearchItems();
        }

        private void ShowAll()
        {
            this.tbxName.Text = string.Empty;

            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                this.mlstSalesMans = POSDbUtility.GetAllPOSSalesMan(-1);
            }
            catch (Exception ex)
            {
                string errorMsg = POSComonUtility.GetInnerExceptionMessage(ex);
                Cursor.Current = currentCursor;
                MessageBox.Show(this, "Some error occured in fetching sales man.\n\n" + errorMsg);
            }

            Cursor.Current = currentCursor;

            this.bsPOSSalesMan.DataSource = null;
            this.bsPOSSalesMan.DataSource = this.mlstSalesMans;
        }

        private void SearchItems()
        {
            string name = this.tbxName.Text;

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show(this, "Please enter any sales man name.");
            }
            else
            {
                Cursor currentCursor = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;

                try
                {
                    this.mlstSalesMans = POSDbUtility.GetAllPOSSalesMan(-1);

                    if (this.mlstSalesMans != null)
                    {
                        this.mlstSalesMans = this.mlstSalesMans.FindAll(salesMan => salesMan.Name.Contains(name));
                    }
                    
                }
                catch (Exception ex)
                {
                    string errorMsg = POSComonUtility.GetInnerExceptionMessage(ex);
                    Cursor.Current = currentCursor;
                    MessageBox.Show(this, "Some error occured in fetching users.\n\n" + errorMsg);
                }

                Cursor.Current = currentCursor;
                
                this.bsPOSSalesMan.DataSource = null;
                this.bsPOSSalesMan.DataSource = this.mlstSalesMans;
            }
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            SalesManForm posSalesManForm = new SalesManForm();

            posSalesManForm.ShowDialog(this);

            string name = this.tbxName.Text;

            if (string.IsNullOrEmpty(name))
            {
                this.ShowAll();
            }
            else
            {
                this.SearchItems();
            }
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            if (this.dgvSalesMan.SelectedRows == null || this.dgvSalesMan.SelectedRows.Count == 0)
            {
                MessageBox.Show(this, "Select any sales man to update");
            }
            else
            {
                POSSalesMan salesManToUpdate = this.dgvSalesMan.SelectedRows[0].Tag as POSSalesMan;

                if (salesManToUpdate == null)
                {
                    MessageBox.Show(this, "There is some error occured please close window and try again.");
                }
                else
                {
                    SalesManForm posSalesManForm = new SalesManForm(salesManToUpdate);

                    posSalesManForm.ShowDialog(this);

                    string name = this.tbxName.Text;

                    if (string.IsNullOrEmpty(name))
                    {
                        this.ShowAll();
                    }
                    else
                    {
                        this.SearchItems();
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dgvSalesMan.SelectedRows.Count == 0)
            {
                MessageBox.Show(this, "Select any sales man to delete");
            }
            else
            {
                POSSalesMan posSalesMantoDelete = this.dgvSalesMan.SelectedRows[0].Tag as POSSalesMan;

                if (posSalesMantoDelete == null)
                {
                    MessageBox.Show(this, "There is some error occured please close window and try again.");
                }
                else
                {
                    bool billCreated = posSalesMantoDelete.Bills != null && posSalesMantoDelete.Bills.Count > 0;

                    if (billCreated)
                    {
                        MessageBox.Show(this, "Some bills are associated with this sales man, so this sales man can not be deleted.");
                        return;
                    }

                    DialogResult dialogResult = MessageBox.Show(this, "Are you sure you want to delete salesm man?", "Confirmation Dialog", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        Cursor currentCursor = Cursor.Current;
                        Cursor.Current = Cursors.WaitCursor;
                        
                        string errorMsg = string.Empty;
                        POSStatusCodes status = POSDbUtility.DeletePOSSalesMan(posSalesMantoDelete, ref errorMsg, true);

                        Cursor.Current = currentCursor;
                        if (status == POSStatusCodes.Success)
                        {
                            string userName = this.tbxName.Text;

                            if (string.IsNullOrEmpty(userName))
                            {
                                this.ShowAll();
                            }
                            else
                            {
                                this.SearchItems();
                            }
                        }
                        else
                        {
                            MessageBox.Show(this, "Some error occured in deleting user.\n\n" + errorMsg);
                        }
                    }

                }
            }
        }

        private void dgvPOSItems_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (this.dgvSalesMan.Rows.Count == 0)
            {
                return;
            }


            List<POSSalesMan> users = this.mlstSalesMans;

            if (users != null)
            {
                for (int i = 0; i < users.Count; i++)
                {
                    DataGridViewRow row = this.dgvSalesMan.Rows[i];

                    row.Tag = users[i];
                }
            }
            
        }
    }
}
