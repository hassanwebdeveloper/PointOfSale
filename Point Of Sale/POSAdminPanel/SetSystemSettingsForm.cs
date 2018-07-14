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
    public partial class SetSystemSettingsForm : Form
    {
        private SystemSettings mSettings = null;

        public SetSystemSettingsForm()
        {
            InitializeComponent();

            List<SystemSettings> settings = POSDbUtility.GetAllSystemSettings();

            SystemSettings systemSettings = null;

            if (settings != null && settings.Count > 0)
            {
                systemSettings = settings.FirstOrDefault();
            }

            this.mSettings = systemSettings;

            if (this.mSettings != null)
            {
                this.tbxShopName.Text = this.mSettings.ShopName;
                this.tbxShopAddress.Text = this.mSettings.ShopAddress;
                this.tbxShopContact.Text = this.mSettings.ShopContact;
                this.tbxThanksNote.Text = this.mSettings.ThanksNote;

                if (!string.IsNullOrEmpty(this.mSettings.BillTermsAndConditions))
                {
                    this.bsBillTermsAndConditions.DataSource = this.mSettings.BillTermsAndConditions.Split('^').ToList().Where(a=> !string.IsNullOrEmpty(a)).Select(x => new BillTermsAndConditions { Condition = x }).ToList();
                }

                if (!string.IsNullOrEmpty(this.mSettings.RefundTermsAndConditions))
                {
                    this.bsRefundTermsAndConditions.DataSource = this.mSettings.RefundTermsAndConditions.Split('^').ToList().Where(a => !string.IsNullOrEmpty(a)).Select(x => new BillTermsAndConditions { Condition = x }).ToList();
                }                               
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                string shopName = this.tbxShopName.Text;
                string shopAddress = this.tbxShopAddress.Text;
                string shopContact = this.tbxShopContact.Text;
                string thanksNote = this.tbxThanksNote.Text;
                string termsAndConditions = string.Empty;
                string refundTermsAndConditions = string.Empty;
                List<string> lstTermsAndConditions = new List<string>();
                List<string> lstRefundTermsAndConditions = new List<string>();

                foreach (DataGridViewRow row in this.dgvBillTermsAndConditions.Rows)
                {
                    if (row != null)
                    {
                        lstTermsAndConditions.Add(row.Cells[0].Value as string);
                    }
                }


                int i = 0;
                int count = lstTermsAndConditions.Count;

                foreach (string terms in lstTermsAndConditions)
                {
                    if (string.IsNullOrEmpty(terms))
                    {
                        continue;
                    }

                    termsAndConditions += terms;

                    if (i < count - 1)
                    {
                        termsAndConditions += "^";
                    }

                    i++;
                }

                foreach (DataGridViewRow row in this.dgvRefundTermsAndCondition.Rows)
                {
                    if (row != null)
                    {
                        lstRefundTermsAndConditions.Add(row.Cells[0].Value as string);
                    }
                }

                i = 0;
                count = lstRefundTermsAndConditions.Count;

                foreach (string terms in lstRefundTermsAndConditions)
                {
                    if (string.IsNullOrEmpty(terms))
                    {
                        continue;
                    }

                    refundTermsAndConditions += terms;

                    if (i < count - 1)
                    {
                        refundTermsAndConditions += "^";
                    }

                    i++;
                }

                bool isSaved = this.mSettings != null;

                this.mSettings = POSFactory.CreateOrUpdateSystemSettings(this.mSettings, shopName, shopAddress, shopContact, thanksNote, termsAndConditions, refundTermsAndConditions);

                POSStatusCodes status = POSStatusCodes.Failed;
                string errorMsg = string.Empty;

                if (isSaved)
                {
                    status = POSDbUtility.UpdateSystemSettings(this.mSettings, ref errorMsg, true);
                }
                else
                {
                    status = POSDbUtility.AddSystemSettings(this.mSettings, ref errorMsg, true);
                }

                Cursor.Current = currentCursor;

                if (status == POSStatusCodes.Success)
                {
                    MessageBox.Show(this, "System settings saved successfully.");
                }
                else
                {
                    
                    MessageBox.Show(this, "Some error occured in updating system settings.\n\n" + errorMsg);
                }
            }
            catch (Exception ex)
            {
                string errorMsg1 = POSComonUtility.GetInnerExceptionMessage(ex);
                Cursor.Current = currentCursor;
                MessageBox.Show(this, "Some error occured in saving system settings.\n\n" + errorMsg1);                
            }

            Cursor.Current = currentCursor;
            
        }
    }
}
