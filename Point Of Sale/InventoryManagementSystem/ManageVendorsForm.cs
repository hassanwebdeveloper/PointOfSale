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
    public partial class ManageVendorsForm : Form
    {
        private List<VendorInfo> mVendors = null;

        public ManageVendorsForm()
        {
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            
            InitializeComponent();

            if (!LoginForm.mLoggedInUser.IsAdmin)
            {
                if (!LoginForm.mLoggedInUser.UpdateVendors)
                {
                    this.btnAddNew.Enabled = false;
                    this.btnUpdate.Enabled = false;
                    this.btnDelete.Enabled = false;
                }
            }

            try
            {
                this.mVendors = POSDbUtility.GetAllVendors();
            }
            catch (Exception e)
            {
                string errorMsg = POSComonUtility.GetInnerExceptionMessage(e);
                Cursor.Current = currentCursor;
                MessageBox.Show(this, "Some error occured in fetching vendors.\n\n" + errorMsg);
            }

            if (this.mVendors == null)
            {
                this.mVendors = new List<VendorInfo>();
            }

            this.vendorInfoBindingSource.DataSource = this.mVendors;

            Cursor.Current = currentCursor;
        }

        private void btnVendorSearch_Click(object sender, EventArgs e)
        {
            string vendorName = this.tbxVendorName.Text;

            if (string.IsNullOrEmpty(vendorName))
            {
                MessageBox.Show(this, "Please enter any vendor name.");
            }
            else
            {
                this.ShowVendors();
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (this.dataGridView1.Rows.Count == 0)
            {
                return;
            }
            string vendorName = this.tbxVendorName.Text;

            List<VendorInfo> lstVendors = this.mVendors;

            lstVendors = string.IsNullOrEmpty(vendorName) ? lstVendors : lstVendors.FindAll(v => v.Name.Contains(vendorName));

            for (int i = 0; i < lstVendors.Count; i++)
            {
                DataGridViewRow row = this.dataGridView1.Rows[i];

                row.Tag = lstVendors[i];
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            this.tbxVendorName.Text = string.Empty;

            this.ShowVendors();
        }

        private void ShowVendors()
        {
            string vendorName = this.tbxVendorName.Text;

            if (string.IsNullOrEmpty(vendorName))
            {
                this.vendorInfoBindingSource.DataSource = null;
                this.vendorInfoBindingSource.DataSource = this.mVendors;
            }
            else
            {
                List<VendorInfo> vendors = this.mVendors;

                List<VendorInfo> filteredVendors = vendors.FindAll(v => v.Name.ToLower().Contains(vendorName.ToLower()));

                this.vendorInfoBindingSource.DataSource = null;
                this.vendorInfoBindingSource.DataSource = filteredVendors;
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            VendorInfoForm vendorInfoForm = new VendorInfoForm();

            vendorInfoForm.ShowDialog(this);

            if (vendorInfoForm.mVendorInfo != null)
            {
                this.mVendors.Add(vendorInfoForm.mVendorInfo);

                this.ShowVendors();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows != null)
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {

                    string errorMsg = string.Empty;

                    VendorInfo vendor = this.dataGridView1.SelectedRows[0].Tag as VendorInfo;

                    if (vendor == null || vendor.Items == null)
                    {
                        MessageBox.Show(this, "Some error occurred, please close window and retry.");
                        return;
                    }

                    bool billCreated = (from item in vendor.Items
                                        where item != null && item.BillItems != null && item.BillItems.Count > 0
                                        select item).Any();

                    if (billCreated)
                    {
                        MessageBox.Show(this, "Some items from this vendor are sold, so this vendor can not be deleted.");
                        return;
                    }

                    DialogResult result = MessageBox.Show(this, "Are you sure you want to delete this vendor?", "Confirmation", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        Cursor currentCursor = Cursor.Current;
                        Cursor.Current = Cursors.WaitCursor;
                        
                        POSStatusCodes status = POSDbUtility.DeleteVendor(vendor, ref errorMsg, true);

                        Cursor.Current = currentCursor;

                        if (status == POSStatusCodes.Success)
                        {
                            this.mVendors.Remove(vendor);
                            this.ShowVendors();
                        }
                        else
                        {
                            MessageBox.Show(this, "Some error occured in deleting vendor.\n\n" + errorMsg);
                        }

                        
                    }

                }
                else
                {
                    MessageBox.Show(this, "Select any vendor to delete.");
                }
            }
            else
            {
                MessageBox.Show(this, "Select any vendor to delete.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows != null && this.dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = this.dataGridView1.SelectedRows[0];

                if (selectedRow.Tag is VendorInfo)
                {
                    VendorInfo vendor = selectedRow.Tag as VendorInfo;

                    VendorInfoForm vendorInfoForm = new VendorInfoForm(vendor);

                    vendorInfoForm.ShowDialog(this);

                    VendorInfo updatedVendor = vendorInfoForm.UpdatedVendor;

                    if (updatedVendor != null)
                    {
                        this.ShowVendors();
                    }

                }
                else
                {
                    MessageBox.Show(this, "Some error occured in opening vendor form.");
                }
            }
            else
            {
                MessageBox.Show(this, "Please select any vendor to update.");
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
