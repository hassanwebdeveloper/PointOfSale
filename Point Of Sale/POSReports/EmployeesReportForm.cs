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

namespace POSReports
{
    public partial class EmployeesReportForm : Form
    {
        private List<POSSalesMan> mLstSalesMan;

        public EmployeesReportForm()
        {
            InitializeComponent();

            this.mLstSalesMan = POSDbUtility.GetAllPOSSalesMan(-1);

            if (mLstSalesMan.Count > 0)
            {
                List<string> lstStrSalesMan = (from salesMan in mLstSalesMan
                                               where salesMan != null
                                               select salesMan.Name + " " + salesMan.LastName).ToList();

                cbxSalesMans.Items.AddRange(lstStrSalesMan.ToArray());
            }
            else
            {
                MessageBox.Show(this, "No sales man found");
                this.Close();
            }                        
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dtpFrom.Value.Date;
            DateTime ToDate = dtpTo.Value.Date.AddDays(1);

            int selectedIndex = cbxSalesMans.SelectedIndex;

            if (selectedIndex > 0)
            {
                POSSalesMan salesMan = this.mLstSalesMan[selectedIndex];

                if (salesMan == null)
                {
                    MessageBox.Show(this, "Some error occurred, Please close and try again.");
                }
                else
                {

                }
            }
            else
            {
                MessageBox.Show(this, "Please select any sales man.");
            }
        }
    }
}
