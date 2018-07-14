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
    public partial class AppUserListForm : Form
    {
        private List<POSAppUser> mlstUser = null;

        public AppUserListForm()
        {
            InitializeComponent();

            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                this.mlstUser = POSDbUtility.GetAllPOSAppuser();

                PopulateRoles(this.mlstUser);
            }
            catch (Exception ex)
            {
                string errorMsg = POSComonUtility.GetInnerExceptionMessage(ex);
                Cursor.Current = currentCursor;
                MessageBox.Show(this, "Some error occured in fetching Application users.\n\n" + errorMsg);
            }

            Cursor.Current = currentCursor;            

            this.bsPOSAppUser.DataSource = this.mlstUser;
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
                this.mlstUser = POSDbUtility.GetAllPOSAppuser();

                PopulateRoles(this.mlstUser);
            }
            catch (Exception ex)
            {
                string errorMsg = POSComonUtility.GetInnerExceptionMessage(ex);
                Cursor.Current = currentCursor;
                MessageBox.Show(this, "Some error occured in fetching application users.\n\n" + errorMsg);
            }

            Cursor.Current = currentCursor;            

            this.bsPOSAppUser.DataSource = null;
            this.bsPOSAppUser.DataSource = this.mlstUser;
        }

        private void SearchItems()
        {
            string userName = this.tbxName.Text;

            if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show(this, "Please enter any user name.");
            }
            else
            {
                Cursor currentCursor = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;

                try
                {
                    this.mlstUser = POSDbUtility.GetAllPOSAppuser();

                    PopulateRoles(this.mlstUser);

                    if (this.mlstUser != null)
                    {
                        this.mlstUser = this.mlstUser.FindAll(posItem => posItem.Name.Contains(userName));
                    }

                }
                catch (Exception ex)
                {
                    string errorMsg = POSComonUtility.GetInnerExceptionMessage(ex);
                    Cursor.Current = currentCursor;
                    MessageBox.Show(this, "Some error occured in fetching users.\n\n" + errorMsg);
                }

                Cursor.Current = currentCursor;

                this.bsPOSAppUser.DataSource = null;
                this.bsPOSAppUser.DataSource = this.mlstUser;
            }
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            AppUserForm posAppUserForm = new AppUserForm();

            posAppUserForm.ShowDialog(this);

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

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            if (this.dgvAppUsers.SelectedRows == null || this.dgvAppUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show(this, "Select any user to Update");
            }
            else
            {
                POSAppUser userToUpdate = this.dgvAppUsers.SelectedRows[0].Tag as POSAppUser;

                if (userToUpdate == null)
                {
                    MessageBox.Show(this, "There is some error occured please close window and try again.");
                }
                else
                {
                    AppUserForm posItemInfoForm = new AppUserForm(userToUpdate);

                    posItemInfoForm.ShowDialog(this);

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
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dgvAppUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show(this, "Select any user to delete");
            }
            else
            {
                POSAppUser userToDelete = this.dgvAppUsers.SelectedRows[0].Tag as POSAppUser;

                if (userToDelete == null)
                {
                    MessageBox.Show(this, "There is some error occured please close window and try again.");
                }
                else
                {
                    bool billCreated = (userToDelete.Bills != null && userToDelete.Bills.Count > 0) || (userToDelete.Refunds != null && userToDelete.Refunds.Count > 0);

                    if (billCreated)
                    {
                        MessageBox.Show(this, "Some bills or refunds are associated with this app user, so this app user can not be deleted.");
                        return;
                    }

                    DialogResult dialogResult = MessageBox.Show(this, "Are you sure you want to delete user?", "Confirmation Dialog", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        Cursor currentCursor = Cursor.Current;
                        Cursor.Current = Cursors.WaitCursor;
                        
                        string errorMsg = string.Empty;
                        POSStatusCodes status = POSDbUtility.DeletePOSAppUser(userToDelete, ref errorMsg, true);

                        if (status == POSStatusCodes.Success)
                        {
                            string userName = this.tbxName.Text;

                            Cursor.Current = currentCursor;
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
                            Cursor.Current = currentCursor;
                            MessageBox.Show(this, "Some error occured in deleting user.\n\n" + errorMsg);
                        }
                    }

                }
            }
        }

        private void dgvPOSItems_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (this.dgvAppUsers.Rows.Count == 0)
            {
                return;
            }


            List<POSAppUser> users = this.mlstUser;

            if (users != null)
            {
                for (int i = 0; i < users.Count; i++)
                {
                    DataGridViewRow row = this.dgvAppUsers.Rows[i];

                    row.Tag = users[i];
                }
            }
            
        }

        private void PopulateRoles(List<POSAppUser> appUsers)
        {
            foreach (POSAppUser appUser in appUsers)
            {
                if (appUser != null)
                {
                    appUser.PopulatesRolesBoolean();
                }
            }
        }
    }
}
