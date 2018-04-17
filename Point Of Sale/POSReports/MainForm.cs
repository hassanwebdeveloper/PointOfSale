using POSRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSReports
{
    public partial class MainForm : Form
    {
        private POSReportConfig mReportConfig = null;

        public MainForm()
        {
            InitializeComponent();

            if (!LoginForm.mLoggedInUser.IsAdmin)
            {
                this.btnFastRunningItems.Enabled = false;
                this.btnAccountsReport.Enabled = false;
                this.btnProfitAndSale.Enabled = false;
                this.btnEmployeesReport.Enabled = false;
                this.btnStockReport.Enabled = false;
                this.btnDailyReport.Enabled = false;
            }
        }
        

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoginForm.mMainForm.Close();
        }
        

        private void btnFastRunningItems_Click(object sender, EventArgs e)
        {

        }

        private void btnAccountsReport_Click(object sender, EventArgs e)
        {

        }

        private void btnProfitAndSale_Click(object sender, EventArgs e)
        {

        }

        private void btnEmployeesReport_Click(object sender, EventArgs e)
        {
            

            
        }

        private void btnStockReport_Click(object sender, EventArgs e)
        {
            List<POSItemInfo> items = POSDbUtility.GetAllPOSItems();

            POSReportConfig report = new POSReportConfig();

            POSReportsCommonUtility.SetReportConfigStyling(report);

            report.SheetName = "Stock Report";
            report.Heading = "Stock Report";

            List<POSReportMetaInfo> metaInfos = new List<POSReportMetaInfo>();

            metaInfos.Add(new POSReportMetaInfo() { ColSpan = 1, Label = "Items in stock:", RowHeight = 20, Value = items.Count.ToString() });

            List<POSReportColumn> columns = new List<POSReportColumn>();

            columns.Add(new POSReportColumn() { Name = "Barcode", Width = 18 });
            columns.Add(new POSReportColumn() { Name = "Item Name", Width = 40 });
            columns.Add(new POSReportColumn() { Name = "Sold", Width = 20 });
            columns.Add(new POSReportColumn() { Name = "Remaining", Width = 20 });
            columns.Add(new POSReportColumn() { Name = "Buying Price", Width = 20 });
            columns.Add(new POSReportColumn() { Name = "Discount", Width = 20 });
            columns.Add(new POSReportColumn() { Name = "Selling Price", Width = 20 });

            report.Columns = columns;

            List<POSReportData> data = new List<POSReportData>();

            foreach (POSItemInfo item in items)
            {
                if (item != null)
                {
                    data.Add(new POSReportData() { Values= new List<string>() { item.Barcode,
                                                                                item.Name,
                                                                                item.TotalItemsSold.ToString(),
                                                                                item.RemaningQuantity.ToString(),
                                                                                item.BuyingPrice.ToString(),
                                                                                item.DiscountPrice.ToString(),
                                                                                item.SellingPrice.ToString() } });
                }
            }

            report.Data = data;

            this.mReportConfig = report;

            if (this.mReportConfig != null && this.mReportConfig.Data.Count > 0)
            {
                this.saveFileDialog1.ShowDialog(this);
            }
            else
            {
                MessageBox.Show(this, "No Data Found.");
            }
        }

        private void btnDailyReport_Click(object sender, EventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            POSReportsCommonUtility.GenerateReportAsExcel(this, this.mReportConfig, this.saveFileDialog1.FileName);
        }
    }
}
