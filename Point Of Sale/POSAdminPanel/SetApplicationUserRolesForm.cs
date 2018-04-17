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
    public partial class SetApplicationUserRolesForm : Form
    {
        public SetApplicationUserRolesForm()
        {
            InitializeComponent();
        }

        public SetApplicationUserRolesForm(POSAppUser appUser)
        {
            InitializeComponent();

            if (appUser != null)
            {
                appUser.PopulatesRolesBoolean();

                this.chxAdmin.Checked = appUser.IsAdmin;
                this.chxViewItems.Checked = appUser.ViewItems;
                this.chxUpdateItems.Checked = appUser.UpdateItems;
                this.chxViewVendors.Checked = appUser.ViewVendors;
                this.chxUpdateVendors.Checked = appUser.UpdateVendors;
                this.chxPrintBarcode.Checked = appUser.PrintBarcode;
                this.chxCreateBill.Checked = appUser.CreateBill;
                this.chxRefundBill.Checked = appUser.RefundBill;
                this.chxSearchItems.Checked = appUser.SearchItems;
            }

            
        }

        private void btnSetRoles_Click(object sender, EventArgs e)
        {
            this.Roles = POSComonUtility.PopulateRoles(this.chxAdmin.Checked,
                                                        this.chxViewItems.Checked,
                                                        this.chxUpdateItems.Checked,
                                                        this.chxViewVendors.Checked,
                                                        this.chxUpdateVendors.Checked,
                                                        this.chxPrintBarcode.Checked,
                                                        this.chxCreateBill.Checked,
                                                        this.chxRefundBill.Checked,
                                                        this.chxSearchItems.Checked);
            this.Close();
        }

        private void chxAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chxAdmin.Checked)
            {
                this.chxViewItems.Enabled = false;
                this.chxUpdateItems.Enabled = false;
                this.chxViewVendors.Enabled = false;
                this.chxUpdateVendors.Enabled = false;
                this.chxPrintBarcode.Enabled = false;
                this.chxCreateBill.Enabled = false;
                this.chxRefundBill.Enabled = false;
                this.chxSearchItems.Enabled = false;
            }
            else
            {
                this.chxViewItems.Enabled = true;
                this.chxUpdateItems.Enabled = true;
                this.chxViewVendors.Enabled = true;
                this.chxUpdateVendors.Enabled = true;
                this.chxPrintBarcode.Enabled = true;
                this.chxCreateBill.Enabled = true;
                this.chxRefundBill.Enabled = true;
                this.chxSearchItems.Enabled = true;
            }
            

        }

        private void chxUpdateItems_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chxUpdateItems.Checked)
            {
                this.chxViewItems.Checked = true;
            }
        }

        private void chxUpdateVendors_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chxUpdateVendors.Checked)
            {
                this.chxViewVendors.Checked = true;
            }
        }

        private void chxViewItems_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.chxViewItems.Checked)
            {
                this.chxUpdateItems.Checked = false;
            }
        }

        private void chxViewVendors_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.chxViewVendors.Checked)
            {
                this.chxUpdateVendors.Checked = false;
            }
        }

        public string Roles { get; set; }
    }
}
