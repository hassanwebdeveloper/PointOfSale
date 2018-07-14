using POSRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSAdminPanel
{
    public partial class SalesManForm : Form
    {
        private POSSalesMan mSalesMan = null;

        public SalesManForm()
        {
            InitializeComponent();

            this.nudCommision.Maximum = Decimal.MaxValue;
            this.nudSalary.Maximum = Decimal.MaxValue;
        }

        public SalesManForm(POSSalesMan salesMan)
        {
            InitializeComponent();

            this.btnPrintCard.Enabled = true;

            this.mSalesMan = salesMan;

            this.nudCommision.Maximum = salesMan.Commisioned && salesMan.InPercent ? 100 : Decimal.MaxValue;
            this.nudSalary.Maximum = Decimal.MaxValue;

            this.tbxName.Text = salesMan.Name;
            this.tbxLastName.Text = salesMan.LastName;
            this.tbxName.Text = salesMan.Name;
            this.tbxCnicNumber.Text = salesMan.CNICNumber;
            this.tbxAddress.Text = salesMan.Address;
            this.tbxContactNumber.Text = salesMan.ContactNumber;
            this.chxSalary.Checked = salesMan.Salaried;
            this.nudSalary.Value = salesMan.Salary;
            this.chxCommisioned.Checked = salesMan.Commisioned;
            this.chxInPercent.Checked = salesMan.InPercent;
            this.nudCommision.Value = salesMan.Commision;

            

            this.btnAddSalesMan.Text = "&Update";
        }

        private void btnAddSalesMan_Click(object sender, EventArgs e)
        {
            bool isValidTbxInputs = POSComonUtility.ValidateInputs(new List<TextBox>() { this.tbxName, this.tbxLastName, this.tbxContactNumber, this.tbxAddress, this.tbxCnicNumber });

            if (isValidTbxInputs)
            {
                bool salaried = this.chxSalary.Checked;
                bool commisioned = this.chxCommisioned.Checked;

                if (salaried || commisioned)
                {
                    string name = this.tbxName.Text;
                    string lastName = this.tbxLastName.Text;
                    string contactNumber = this.tbxContactNumber.Text;
                    string address = this.tbxAddress.Text;
                    string cnicNumber = this.tbxCnicNumber.Text;
                    bool inPercent = this.chxInPercent.Checked;
                    int salary = Convert.ToInt32(this.nudSalary.Value);
                    int commision = Convert.ToInt32(this.nudCommision.Value);

                    POSSalesMan salesMan = POSFactory.CreateOrUpdatePOSSalesMan(this.mSalesMan,
                                                                                name,
                                                                                lastName,
                                                                                contactNumber,
                                                                                address, 
                                                                                cnicNumber, 
                                                                                salaried,
                                                                                salary,
                                                                                commisioned, 
                                                                                inPercent,
                                                                                commision);

                    string errorMsg = string.Empty;
                    POSStatusCodes status = POSStatusCodes.Failed;
                    Cursor currentCursor = Cursor.Current;
                    Cursor.Current = Cursors.WaitCursor;
                    

                    if (this.mSalesMan == null)
                    {
                        status = POSDbUtility.AddPOSSalesMan(salesMan, ref errorMsg, true);
                    }
                    else
                    {
                        status = POSDbUtility.UpdatePOSSalesMan(salesMan, ref errorMsg);
                    }

                    Cursor.Current = currentCursor;

                    if (status == POSStatusCodes.Success)
                    {
                        if (this.mSalesMan == null)
                        {
                            this.mSalesMan = salesMan;
                            this.btnPrintCard.Enabled = true;
                            this.btnAddSalesMan.Text = "&Update";
                        }
                        else
                        {
                            MessageBox.Show(this, "Sales main updated successfully.");
                        }
                    }
                    else
                    {
                        if (this.mSalesMan == null)
                        {
                            MessageBox.Show(this, "Failed to add sales man.\n\n" + errorMsg);
                        }
                        else
                        {
                            MessageBox.Show(this, "Failed to update sales man.\n\n" + errorMsg);
                        }
                    }
                }
                else
                {
                    MessageBox.Show(this, "Please select any one from salary or commision.");
                }                
            }
        }

        private void chxCommisioned_CheckedChanged(object sender, EventArgs e)
        {
            bool commisioned = this.chxCommisioned.Checked;

            if (commisioned)
            {
                this.nudCommision.Enabled = true;
                this.chxInPercent.Enabled = true;
            }
            else
            {
                this.nudCommision.Enabled = false;
                this.chxInPercent.Enabled = false;
            }
        }

        private void chxSalary_CheckedChanged(object sender, EventArgs e)
        {
            bool salaried = this.chxSalary.Checked;

            if (salaried)
            {
                this.nudSalary.Enabled = true;
            }
            else
            {
                this.nudSalary.Enabled = false;
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int x = 45;
            int y = 5;
            int width = 220;

            List<SystemSettings> settings = POSDbUtility.GetAllSystemSettings();

            SystemSettings systemSettings = null;

            if (settings != null && settings.Count > 0)
            {
                systemSettings = settings.FirstOrDefault();
            }

            e.Graphics.DrawRectangle(new Pen(Color.DarkBlue, 2), new Rectangle(x, y, width, 300));

            if (systemSettings != null)
            {
                POSComonUtility.DrawShopInfo(e.Graphics, systemSettings.ShopName, systemSettings.ShopAddress, systemSettings.ShopContact, ref y, Brushes.DarkBlue, Brushes.DarkBlue, Brushes.DarkBlue, fillBackGround: false, nameFontFamily: "Monotype Corsiva", addressFontFamily: "Monotype Corsiva", contactFontFamily: "Monotype Corsiva", pixX: x, width: width, fontSize: 12, fontHeight: 22, addLogo: false);
            }           

            POSComonUtility.DrawSalesManInfo(e.Graphics, this.mSalesMan.Name + " " + this.mSalesMan.LastName, ref y, x);

            POSComonUtility.DrawBarcode(e.Graphics, this.mSalesMan.Barcode, ref y, width, x, 60, 200, false, 10);
        }

        private void btnPrintCard_Click(object sender, EventArgs e)
        {
            if (this.mSalesMan == null)
            {
                MessageBox.Show("Sales man info is not saved in system.");
            }
            else
            {
                string salesManCardPrinterName = ConfigurationManager.AppSettings["SalesManCardPrinter"];

                this.printDocument1.PrinterSettings.PrinterName = salesManCardPrinterName;
                this.printDocument1.Print();
            }
            
        }
    }
}
