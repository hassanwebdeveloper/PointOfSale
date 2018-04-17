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

            this.mVendors = POSDbUtility.GetAllVendors();

            this.vendorInfoBindingSource.DataSource = this.mVendors;

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

                    POSStatusCodes status = POSDbUtility.DeleteVendor(vendor, ref errorMsg, true);

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
            if (this.dataGridView1.SelectedRows.Count > 0)
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
                        //VendorInfo vend = this.mVendors.Find(vendorInfo => vendorInfo.VendorId == updatedVendor.VendorId);
                        //vend = updatedVendor;

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
