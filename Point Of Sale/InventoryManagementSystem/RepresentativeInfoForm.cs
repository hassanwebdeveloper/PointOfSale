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
    public partial class RepresentativeInfoForm : Form
    {
        private VendorInfo mVendorInfo = null;
        private RepresentativeInfo mRepresentative = null;

        public RepresentativeInfoForm(VendorInfo vendor)
        {
            InitializeComponent();

            this.mVendorInfo = vendor;

            this.tbxVendorName.Text = vendor.Name;
            this.btnSave.Tag = false;
        }

        public RepresentativeInfoForm(VendorInfo vendor, RepresentativeInfo representativeInfo)
        {
            InitializeComponent();

            this.mVendorInfo = vendor;
            this.mRepresentative = representativeInfo;

            this.tbxName.Text = this.mRepresentative.Name;
            this.tbxAddress.Text = this.mRepresentative.Address;
            this.tbxContactNumber.Text = this.mRepresentative.ContactNumber;
            this.tbxDesignation.Text = this.mRepresentative.Designation;
            this.tbxVendorName.Text = this.mVendorInfo.Name;

            this.btnSave.Tag = true;

            this.btnSave.Text = this.btnSave.Text.Replace("Add", "Update");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isValid = POSComonUtility.ValidateInputs(new List<TextBox>() { this.tbxName, this.tbxAddress, this.tbxContactNumber, this.tbxDesignation });

            if (isValid)
            {
                bool saved = Convert.ToBoolean(this.btnSave.Tag);
                if (saved)
                {
                    this.mRepresentative.Name = this.tbxName.Text;
                    this.mRepresentative.Address = this.tbxAddress.Text;
                    this.mRepresentative.ContactNumber = this.tbxContactNumber.Text;
                    this.mRepresentative.Designation = this.tbxDesignation.Text;

                    POSStatusCodes status = POSDbUtility.UpdateRepresentative(this.mRepresentative);

                }
                else
                {

                    RepresentativeInfo representative = POSFactory.CreateRepresentative(this.tbxName.Text, this.tbxAddress.Text, this.tbxContactNumber.Text, this.tbxDesignation.Text, this.mVendorInfo);

                    POSStatusCodes status = POSDbUtility.AddRepresentative(representative);

                    if (status == POSStatusCodes.Success)
                    {
                        this.mRepresentative = representative;
                        this.btnSave.Tag = true;
                    }
                }
            }
        }
    }
}
