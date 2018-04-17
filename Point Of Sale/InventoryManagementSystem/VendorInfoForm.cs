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
    public partial class VendorInfoForm : Form
    {
        public VendorInfo mVendorInfo = null;

        public VendorInfoForm()
        {
            InitializeComponent();
            this.btnSave.Tag = false;
            this.btnAddNew.Enabled = false;
            this.btnDelete.Enabled = false;
            this.btnUpdate.Enabled = false;
        }

        public VendorInfoForm(VendorInfo vendorInfo)
        {
            InitializeComponent();

            this.mVendorInfo = vendorInfo;

            this.tbxName.Text = this.mVendorInfo.Name;
            this.tbxAddress.Text = this.mVendorInfo.Address;
            this.tbxContactNumber.Text = this.mVendorInfo.ContactNumber;
            this.tbxCellPhone.Text = this.mVendorInfo.CellPhoneNumber;

            //if (this.mVendorInfo.Representatives != null)
            //{
            //    this.representativeInfoBindingSource.DataSource = this.mVendorInfo.Representatives;
            //}

            this.btnSave.Text = "Update Vendor";
            this.btnSave.Tag = true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isValid = POSComonUtility.ValidateInputs(new List<TextBox>() { this.tbxName, this.tbxAddress, this.tbxContactNumber });
            string errorMsg = string.Empty;

            if (isValid)
            {
                bool saved = Convert.ToBoolean(this.btnSave.Tag);
                if (saved)
                {
                    this.mVendorInfo.Name = this.tbxName.Text;
                    this.mVendorInfo.Address = this.tbxAddress.Text;
                    this.mVendorInfo.ContactNumber = this.tbxContactNumber.Text;
                    this.mVendorInfo.CellPhoneNumber = this.tbxCellPhone.Text;

                    POSStatusCodes status = POSDbUtility.UpdateVendor(this.mVendorInfo, ref errorMsg);

                    if (status == POSStatusCodes.Success)
                    {
                        this.UpdatedVendor = this.mVendorInfo;                        
                    }
                    else
                    {
                        MessageBox.Show(this, "Some error occured in updating vendor.\n\n" + errorMsg);
                    }
                }
                else
                {

                    VendorInfo vendor = POSFactory.CreateVendor(this.tbxName.Text, this.tbxAddress.Text, this.tbxContactNumber.Text, this.tbxCellPhone.Text);
                    
                    //RepresentativeInfo representative = POSComonUtility.CreateRepresentative(this.tbxName.Text, this.tbxAddress.Text, this.tbxContactNumber.Text, "Sales Man", vendor);
                    
                    POSStatusCodes status = POSDbUtility.AddVendor(vendor, ref errorMsg);

                    if (status == POSStatusCodes.Success)
                    {
                        this.mVendorInfo = vendor;
                        this.btnSave.Text = "Update Vendor";
                        this.btnSave.Tag = true;

                        this.btnAddNew.Enabled = true;
                        this.btnDelete.Enabled = true;
                        this.btnUpdate.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show(this, "Some error occured in adding vendor.\n\n" + errorMsg);
                    }
                }
            }
        }

        private void btnRepresentativeSearch_Click(object sender, EventArgs e)
        {
            //string representativeName = this.tbxSearchName.Text;

            //if (string.IsNullOrEmpty(representativeName))
            //{
            //    MessageBox.Show(this, "Please enter any representative name.");
            //}
            //else
            //{
            //    List<RepresentativeInfo> representatives = this.mVendorInfo.Representatives;

            //    List<RepresentativeInfo> filteredVendors = representatives.FindAll(v => v.Name.Contains(representativeName));

            //    this.representativeInfoBindingSource.DataSource = filteredVendors;
            //}
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            //this.tbxSearchName.Text = string.Empty;

            //this.representativeInfoBindingSource.DataSource = this.mVendorInfo.Representatives;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void dgvRepresentative_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //string representativeName = this.tbxSearchName.Text;

            //List<RepresentativeInfo> lstRepresentatives = this.mVendorInfo.Representatives;

            //lstRepresentatives = string.IsNullOrEmpty(representativeName) ? lstRepresentatives : lstRepresentatives.FindAll(v => v.Name.Contains(representativeName));

            //for (int i = 0; i < lstRepresentatives.Count; i++)
            //{
            //    DataGridViewRow row = this.dgvRepresentative.Rows[i];

            //    row.Tag = lstRepresentatives[i];
            //}
        }

        public VendorInfo UpdatedVendor { get; set; }

    }
}
