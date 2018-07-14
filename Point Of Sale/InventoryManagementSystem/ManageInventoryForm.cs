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
    public partial class ManageInventoryForm : Form
    {
        List<POSItemInfo> mItems = null;

        public ManageInventoryForm()
        {
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            
            InitializeComponent();

            if (!LoginForm.mLoggedInUser.IsAdmin)
            {
                if (!LoginForm.mLoggedInUser.UpdateItems)
                {
                    this.btnAddNewItems.Enabled = false;
                    this.btnAddExisting.Enabled = false;
                    this.btnDelete.Enabled = false;
                }
            }

            try
            {
                this.mItems = POSDbUtility.GetAllPOSItems();
            }
            catch (Exception e)
            {
                string errorMsg = POSComonUtility.GetInnerExceptionMessage(e);
                Cursor.Current = currentCursor;
                MessageBox.Show(this, "Some error occured in fetching users.\n\n" + errorMsg);

            }

            if (this.mItems == null)
            {
                this.mItems = new List<POSItemInfo>();
            }

            this.bsPOSItemInfo.DataSource = this.mItems;

            Cursor.Current = currentCursor;
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            this.ShowAll();
        }

        private void btnItemSearch_Click(object sender, EventArgs e)
        {
            this.SearchItems();
        }

        private void dgvPOSItems_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (this.dgvPOSItems.Rows.Count == 0)
            {
                return;
            }

            string itemName = this.tbxItemName.Text;

            List<POSItemInfo> items = new List<POSItemInfo>();

            if (string.IsNullOrEmpty(itemName))
            {
                items = this.mItems;
            }
            else
            {
                POSItemInfo item = this.mItems.Find(posItem => posItem.Barcode == itemName);

                if (item == null)
                {
                    item = this.mItems.Find(posItem => posItem.Id.ToString() == itemName);

                    if (item == null)
                    {
                        items = this.mItems.FindAll(posItem => posItem.Name.ToLower().Contains(itemName.ToLower()));
                    }
                    else
                    {
                        items.Add(item);
                    }
                }
                else
                {
                    items.Add(item);
                }
            }

            for (int i = 0; i < items.Count; i++)
            {
                DataGridViewRow row = this.dgvPOSItems.Rows[i];

                row.Tag = items[i];
            }
        }

        private void ShowAll()
        {
            Cursor current = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            this.tbxItemName.Text = string.Empty;

            try
            {
                this.mItems = POSDbUtility.GetAllPOSItems();
            }
            catch (Exception e)
            {
                string errorMsg = POSComonUtility.GetInnerExceptionMessage(e);
                Cursor.Current = current;
                MessageBox.Show(this, "Some error occured in getting items.\n\n" + errorMsg);
            }

            if (this.mItems == null)
            {
                this.mItems = new List<POSItemInfo>();
            }

            this.bsPOSItemInfo.DataSource = null;
            this.bsPOSItemInfo.DataSource = this.mItems;

            Cursor.Current = current;
        }

        private void SearchItems()
        {
            string itemName = this.tbxItemName.Text;

            if (string.IsNullOrEmpty(itemName))
            {
                MessageBox.Show(this, "Please enter any item name or barcode.");
            }
            else
            {
                Cursor current = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;

                try
                {
                    this.mItems = POSDbUtility.GetAllPOSItems();
                }
                catch (Exception e)
                {
                    string errorMsg = POSComonUtility.GetInnerExceptionMessage(e);
                    Cursor.Current = current;
                    MessageBox.Show(this, "Some error occured in getting items.\n\n" + errorMsg);
                }

                if (this.mItems == null)
                {
                    this.mItems = new List<POSItemInfo>();
                }

                List<POSItemInfo> items = new List<POSItemInfo>();

                if (string.IsNullOrEmpty(itemName))
                {
                    items = this.mItems;
                }
                else
                {
                    POSItemInfo item = this.mItems.Find(posItem => posItem.Barcode == itemName);

                    if (item == null)
                    {
                        item = this.mItems.Find(posItem => posItem.Id.ToString() == itemName);

                        if (item == null)
                        {
                            items = this.mItems.FindAll(posItem => posItem.Name.ToLower().Contains(itemName.ToLower()));
                        }
                        else
                        {
                            items.Add(item);
                        }
                    }
                    else
                    {
                        items.Add(item);
                    }
                }
                

                this.bsPOSItemInfo.DataSource = null;
                this.bsPOSItemInfo.DataSource = items;

                Cursor.Current = current;
            }
        }

        private void btnAddNewItems_Click(object sender, EventArgs e)
        {
            POSItemInfoForm posItemInfoForm = new POSItemInfoForm();

            posItemInfoForm.ShowDialog(this);

            string itemName = this.tbxItemName.Text;

            if (string.IsNullOrEmpty(itemName))
            {
                this.ShowAll();
            }
            else
            {
                this.SearchItems();
            }
        }

        private void btnAddExisting_Click(object sender, EventArgs e)
        {
            if (this.dgvPOSItems.SelectedRows == null || this.dgvPOSItems.SelectedRows.Count == 0)
            {
                MessageBox.Show(this, "Select any item to Update");
            }
            else
            {
                POSItemInfo itemToUpdate = this.dgvPOSItems.SelectedRows[0].Tag as POSItemInfo;

                if (itemToUpdate == null)
                {
                    MessageBox.Show(this, "There is some error occured please close window and try again.");
                }
                else
                {
                    POSItemInfoForm posItemInfoForm = new POSItemInfoForm(itemToUpdate);

                    posItemInfoForm.ShowDialog(this);

                    string itemName = this.tbxItemName.Text;

                    if (string.IsNullOrEmpty(itemName))
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
            if (this.dgvPOSItems.SelectedRows.Count == 0)
            {
                MessageBox.Show(this, "Select any item to delete");
            }
            else
            {
                POSItemInfo itemToDelete = this.dgvPOSItems.SelectedRows[0].Tag as POSItemInfo;

                if (itemToDelete == null)
                {
                    MessageBox.Show(this, "There is some error occured please close window and try again.");
                }
                else
                {
                    bool billCreated = itemToDelete.BillItems != null && itemToDelete.BillItems.Count > 0;

                    if (billCreated)
                    {
                        MessageBox.Show(this, "This item is already sold, so this item can not be deleted.");
                        return;
                    }

                    DialogResult dialogResult = MessageBox.Show(this, "Are you sure you want to delete selected item?", "Confirmation Dialog", MessageBoxButtons.YesNo);

                    string errorMsg = string.Empty;
                    if (dialogResult == DialogResult.Yes)
                    {
                        Cursor currentCursor = Cursor.Current;
                        Cursor.Current = Cursors.WaitCursor;
                        
                        POSStatusCodes status = POSDbUtility.DeletePOSItem(itemToDelete, ref errorMsg, true);

                        Cursor.Current = currentCursor;
                        if (status == POSStatusCodes.Success)
                        {
                            string itemName = this.tbxItemName.Text;

                            if (string.IsNullOrEmpty(itemName))
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
                            MessageBox.Show(this, "Some error occured in deleting Item.\n\n" + errorMsg);
                        }

                                  
                    }
                }
            }
        }
    }
}
