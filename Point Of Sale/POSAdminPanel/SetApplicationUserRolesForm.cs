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
    public partial class SetApplicationUserRoles : Form
    {
        public SetApplicationUserRoles()
        {
            InitializeComponent();
        }

        public SetApplicationUserRoles(POSAppUser appUser)
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
                this.chxViewInvExpenses.Checked = appUser.ViewInvExpense;
                this.chxUpdateInvExpenses.Checked = appUser.UpdateInvExpense;
                this.chxViewPosExpenses.Checked = appUser.ViewPosExpense;
                this.chxUpdatePosExpenses.Checked = appUser.UpdatePosExpense;
                this.chxFastRunningReport.Checked = appUser.FastRunningReport;
                this.chxAccountsReport.Checked = appUser.AccountReport;
                this.chxProfitAndSale.Checked = appUser.ProfitAndSaleReport;
                this.chxEmployeeReport.Checked = appUser.EmployeeReport;
                this.chxStockReport.Checked = appUser.StockReport;
                this.chxDailyReport.Checked = appUser.DailyReport;

                UpdateCheckBoxesState(appUser.IsAdmin);

                this.Roles = POSComonUtility.PopulateRoles(this.chxAdmin.Checked,
                                                        this.chxViewItems.Checked,
                                                        this.chxUpdateItems.Checked,
                                                        this.chxViewVendors.Checked,
                                                        this.chxUpdateVendors.Checked,
                                                        this.chxPrintBarcode.Checked,
                                                        this.chxCreateBill.Checked,
                                                        this.chxRefundBill.Checked,
                                                        this.chxSearchItems.Checked,
                                                        this.chxViewInvExpenses.Checked,
                                                        this.chxUpdateInvExpenses.Checked,
                                                        this.chxViewPosExpenses.Checked,
                                                        this.chxUpdatePosExpenses.Checked,
                                                        this.chxFastRunningReport.Checked,
                                                        this.chxAccountsReport.Checked,
                                                        this.chxProfitAndSale.Checked,
                                                        this.chxEmployeeReport.Checked,
                                                        this.chxStockReport.Checked,
                                                        this.chxDailyReport.Checked);
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
                                                        this.chxSearchItems.Checked,
                                                        this.chxViewInvExpenses.Checked,
                                                        this.chxUpdateInvExpenses.Checked,
                                                        this.chxViewPosExpenses.Checked,
                                                        this.chxUpdatePosExpenses.Checked,
                                                        this.chxFastRunningReport.Checked,
                                                        this.chxAccountsReport.Checked,
                                                        this.chxProfitAndSale.Checked,
                                                        this.chxEmployeeReport.Checked,
                                                        this.chxStockReport.Checked,
                                                        this.chxDailyReport.Checked);
            this.Close();
        }

        private void chxAdmin_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCheckBoxesState(this.chxAdmin.Checked);
        }

        private void UpdateCheckBoxesState(bool IsAdmin)
        {
            if (IsAdmin)
            {
                this.chxViewItems.Enabled = false;
                this.chxUpdateItems.Enabled = false;
                this.chxViewVendors.Enabled = false;
                this.chxUpdateVendors.Enabled = false;
                this.chxPrintBarcode.Enabled = false;
                this.chxCreateBill.Enabled = false;
                this.chxRefundBill.Enabled = false;
                this.chxSearchItems.Enabled = false;
                this.chxViewInvExpenses.Enabled = false;
                this.chxUpdateInvExpenses.Enabled = false;
                this.chxViewPosExpenses.Enabled = false;
                this.chxUpdatePosExpenses.Enabled = false;
                this.chxFastRunningReport.Enabled = false;
                this.chxAccountsReport.Enabled = false;
                this.chxProfitAndSale.Enabled = false;
                this.chxEmployeeReport.Enabled = false;
                this.chxStockReport.Enabled = false;
                this.chxDailyReport.Enabled = false;
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
                this.chxViewInvExpenses.Enabled = true;
                this.chxUpdateInvExpenses.Enabled = true;
                this.chxViewPosExpenses.Enabled = true;
                this.chxUpdatePosExpenses.Enabled = true;
                this.chxFastRunningReport.Enabled = true;
                this.chxAccountsReport.Enabled = true;
                this.chxProfitAndSale.Enabled = true;
                this.chxEmployeeReport.Enabled = true;
                this.chxStockReport.Enabled = true;
                this.chxDailyReport.Enabled = true;
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

        private void chxUpdateInvExpenses_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chxUpdateInvExpenses.Checked)
            {
                this.chxViewInvExpenses.Checked = true;
            }
        }

        private void chxUpdatePosExpenses_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chxUpdatePosExpenses.Checked)
            {
                this.chxViewPosExpenses.Checked = true;
            }
        }
    }
}
