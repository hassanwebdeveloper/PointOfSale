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
            SelectDateRangeForm form = new SelectDateRangeForm("Fast Running Items");
            form.ShowDialog(this);

            DateTime fromDate = form.FromDate.Date;
            DateTime toDate = form.ToDate.Date.AddDays(1);

            List<POSBillInfo> bills = POSDbUtility.GetAllPOSBillInfo(fromDate, toDate);

            if (bills == null || bills.Count == 0)
            {
                MessageBox.Show(this, "No item sold today");
            }
            else
            {
                POSReportConfig report = new POSReportConfig();

                POSReportsCommonUtility.SetReportConfigStyling(report);

                report.SheetName = "Fast Running Items";
                report.Heading = "Fast Running Items";


                List<POSReportColumn> columns = new List<POSReportColumn>();

                columns.Add(new POSReportColumn() { Name = "Barcode", Width = 18 });
                columns.Add(new POSReportColumn() { Name = "Item Name", Width = 40 });
                columns.Add(new POSReportColumn() { Name = "Sold Count", Width = 20 });
                columns.Add(new POSReportColumn() { Name = "Total Ammount", Width = 20 });
                columns.Add(new POSReportColumn() { Name = "Profit", Width = 20 });

                report.Columns = columns;

                Dictionary<string, Tuple<string, int, int, int>> reportData = new Dictionary<string, Tuple<string, int, int, int>>();

                int totalSold = 0, totalOfAll = 0, totalProfit = 0;

                foreach (POSBillInfo bill in bills)
                {
                    if (bill != null)
                    {
                        foreach (POSBillItemInfo billItem in bill.BillItems)
                        {
                            POSItemInfo item = billItem.PosItem1;

                            string barcode = item.Barcode;
                            string name = item.Name;
                            int soldCount = billItem.Quantity;
                            int total = billItem.Total;
                            int profit = billItem.Profit;

                            totalSold += soldCount;
                            totalOfAll += total;
                            totalProfit += profit;

                            Tuple<string, int, int, int> billData = null;

                            if (reportData.ContainsKey(barcode))
                            {
                                billData = reportData[barcode];

                                billData = new Tuple<string, int, int, int>(name, billData.Item2 + soldCount, billData.Item3 + total, billData.Item4 + profit);
                            }
                            else
                            {
                                billData = new Tuple<string, int, int, int>(name, soldCount, total, profit);

                                reportData.Add(barcode, billData);
                            }
                        }
                    }
                }

                List<POSReportMetaInfo> metaInfos = new List<POSReportMetaInfo>();

                metaInfos.Add(new POSReportMetaInfo() { ColSpan = 1, Label = "From Date:", RowHeight = 20, Value = fromDate.ToString() });
                metaInfos.Add(new POSReportMetaInfo() { ColSpan = 1, Label = "To Date:", RowHeight = 20, Value = toDate.ToString() });
                metaInfos.Add(new POSReportMetaInfo() { ColSpan = 1, Label = "Total Sold:", RowHeight = 20, Value = totalSold.ToString() });
                metaInfos.Add(new POSReportMetaInfo() { ColSpan = 1, Label = "Total Ammount:", RowHeight = 20, Value = totalOfAll.ToString() });
                metaInfos.Add(new POSReportMetaInfo() { ColSpan = 1, Label = "Total Profit:", RowHeight = 20, Value = totalProfit.ToString() });

                report.MetaInfo = metaInfos;

                List<POSReportData> data = new List<POSReportData>();

                reportData.OrderByDescending(t => t.Value.Item2);

                foreach (KeyValuePair<string, Tuple<string, int, int, int>> dataItem in reportData)
                {
                    Tuple<string, int, int, int> dataItemDetails = dataItem.Value;

                    string barcode = dataItem.Key;
                    string name = dataItemDetails.Item1;
                    int soldCount = dataItemDetails.Item2;
                    int total = dataItemDetails.Item3;
                    int profit = dataItemDetails.Item4;

                    data.Add(new POSReportData()
                    {
                        Values = new List<string>() {
                                                        barcode,
                                                        name,
                                                        soldCount.ToString(),
                                                        total.ToString(),
                                                        profit.ToString()
                                                    }
                    });
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
        }

        private void btnAccountsReport_Click(object sender, EventArgs e)
        {
            SelectDateRangeForm form = new SelectDateRangeForm("Accounts Report");
            form.ShowDialog(this);

            DateTime fromDate = form.FromDate.Date;
            DateTime toDate = form.ToDate.Date.AddDays(1);

            List<POSItemInfo> items = POSDbUtility.GetAllPOSItems();

            items = (from item in items
                     where item != null &&
                           (item.Transactions != null && 
                           item.Transactions.Exists(it => it.TransactionTime.Date >= fromDate && it.TransactionTime.Date < toDate)) ||
                           (item.BillItems != null && item.BillItems.Exists(it => it.BillDate.Date >= fromDate && it.BillDate.Date < toDate))
                     select item).ToList();

            POSReportConfig report = new POSReportConfig();

            POSReportsCommonUtility.SetReportConfigStyling(report);

            report.SheetName = "Accounts Report";
            report.Heading = "Accounts Report";

           
            List<POSReportColumn> columns = new List<POSReportColumn>();

            columns.Add(new POSReportColumn() { Name = "Barcode", Width = 18 });
            columns.Add(new POSReportColumn() { Name = "Item Name", Width = 40 });
            columns.Add(new POSReportColumn() { Name = "Purchased", Width = 20 });
            columns.Add(new POSReportColumn() { Name = "Purchase Ammount", Width = 20 });
            columns.Add(new POSReportColumn() { Name = "Returned", Width = 20 });
            columns.Add(new POSReportColumn() { Name = "Returned Ammount", Width = 20 });
            columns.Add(new POSReportColumn() { Name = "Sold", Width = 20 });
            columns.Add(new POSReportColumn() { Name = "Sold Ammount", Width = 20 });

            report.Columns = columns;

            List<POSReportData> data = new List<POSReportData>();

            Dictionary<string, Tuple<string, int, int, int, int, int, int>> reportData = new Dictionary<string, Tuple<string, int, int, int, int, int, int>>();

            int totalSold = 0, totalSoldOfAll = 0, totalPurchased = 0, totalPurchasedAmmount = 0, totalReturned = 0, totalReturnedAmmount = 0;

            foreach (POSItemInfo posItem in items)
            {
                if (posItem != null)
                {
                    List<POSBillItemInfo> billItems = posItem.BillItems.FindAll(it => it.BillDate.Date >= fromDate && it.BillDate.Date < toDate);

                    foreach (POSBillItemInfo billItem in billItems)
                    {
                        POSItemInfo item = billItem.PosItem1;

                        string barcode = item.Barcode;
                        string name = item.Name;
                        int soldCount = billItem.Quantity;
                        int total = billItem.Total;
                        int profit = billItem.Profit;

                        totalSold += soldCount;
                        totalSoldOfAll += total;

                        Tuple<string, int, int, int, int, int, int> billData = null;

                        if (reportData.ContainsKey(barcode))
                        {
                            billData = reportData[barcode];

                            billData = new Tuple<string, int, int, int, int, int, int>(name, billData.Item2, billData.Item3, billData.Item4, billData.Item5, billData.Item6 + soldCount, billData.Item7 + total);
                        }
                        else
                        {
                            billData = new Tuple<string, int, int, int, int, int, int>(name, 0, 0, 0, 0, soldCount, total);

                            reportData.Add(barcode, billData);
                        }
                    }

                    List<POSItemTransactionItem> trnasactions = posItem.Transactions.FindAll(it => it.TransactionTime.Date >= fromDate && it.TransactionTime.Date < toDate);

                    foreach (POSItemTransactionItem transaction in trnasactions)
                    {
                        POSItemInfo item = transaction.Item;

                        string barcode = item.Barcode;
                        string name = item.Name;

                        int purchased = 0;
                        int purchasedAmount = 0;
                        int returned = 0;
                        int returnedAmmount = 0;

                        if (transaction.IsPurchased)
                        {
                            purchased = transaction.ItemCount;
                            purchasedAmount = transaction.ItemCount * transaction.ItemRate;

                            totalPurchased += purchased;
                            totalPurchasedAmmount += purchasedAmount;
                        }
                        else
                        {
                            returned = transaction.ItemCount;
                            returnedAmmount = transaction.ItemCount * transaction.ItemRate;

                            totalReturned += returned;
                            totalReturnedAmmount += returnedAmmount;
                        }
                        

                        Tuple<string, int, int, int, int, int, int> billData = null;

                        if (reportData.ContainsKey(barcode))
                        {
                            billData = reportData[barcode];

                            if (transaction.IsPurchased)
                            {
                                billData = new Tuple<string, int, int, int, int, int, int>(name, billData.Item2 + purchased, billData.Item3 + purchasedAmount, billData.Item4, billData.Item5, billData.Item6, billData.Item7);
                            }
                            else
                            {
                                billData = new Tuple<string, int, int, int, int, int, int>(name, billData.Item2, billData.Item3, billData.Item4 + returned, billData.Item5 + returnedAmmount, billData.Item6, billData.Item7);
                            }
                        }
                        else
                        {
                            if (transaction.IsPurchased)
                            {
                                billData = new Tuple<string, int, int, int, int, int, int>(name, purchased, purchasedAmount, 0, 0, 0, 0);
                            }
                            else
                            {
                                billData = new Tuple<string, int, int, int, int, int, int>(name, 0, 0, returned, returnedAmmount, 0, 0);
                            }

                            reportData.Add(barcode, billData);
                        }
                    }
                }
            }

            List<POSReportMetaInfo> metaInfos = new List<POSReportMetaInfo>();

            metaInfos.Add(new POSReportMetaInfo() { ColSpan = 1, Label = "From Date:", RowHeight = 20, Value = fromDate.ToString() });
            metaInfos.Add(new POSReportMetaInfo() { ColSpan = 1, Label = "To Date:", RowHeight = 20, Value = toDate.ToString() });
            metaInfos.Add(new POSReportMetaInfo() { ColSpan = 1, Label = "Total Purchased:", RowHeight = 20, Value = totalPurchased.ToString() });
            metaInfos.Add(new POSReportMetaInfo() { ColSpan = 1, Label = "Purchased Ammount:", RowHeight = 20, Value = totalPurchasedAmmount.ToString() });
            metaInfos.Add(new POSReportMetaInfo() { ColSpan = 1, Label = "Total Returned:", RowHeight = 20, Value = totalReturned.ToString() });
            metaInfos.Add(new POSReportMetaInfo() { ColSpan = 1, Label = "Returned Ammount:", RowHeight = 20, Value = totalReturnedAmmount.ToString() });
            metaInfos.Add(new POSReportMetaInfo() { ColSpan = 1, Label = "Total Sold:", RowHeight = 20, Value = totalSold.ToString() });
            metaInfos.Add(new POSReportMetaInfo() { ColSpan = 1, Label = "Sold Ammount:", RowHeight = 20, Value = totalSoldOfAll.ToString() });
            metaInfos.Add(new POSReportMetaInfo() { ColSpan = 1, Label = "Cash On Hand:", RowHeight = 20, Value = (totalSoldOfAll + totalReturnedAmmount - totalPurchasedAmmount).ToString() });

            report.MetaInfo = metaInfos;

            foreach (KeyValuePair<string, Tuple<string, int, int, int, int, int, int>> dataItem in reportData)
            {
                Tuple<string, int, int, int, int, int, int> dataItemDetails = dataItem.Value;

                string barcode = dataItem.Key;
                string name = dataItemDetails.Item1;
                int purchased = dataItemDetails.Item2;
                int purchasedAmmount = dataItemDetails.Item3;
                int returned = dataItemDetails.Item4;
                int returnedAmmount = dataItemDetails.Item5;
                int soldCount = dataItemDetails.Item6;
                int soldAmmount = dataItemDetails.Item7;

                data.Add(new POSReportData()
                {
                    Values = new List<string>() {
                                                        barcode,
                                                        name,
                                                        purchased.ToString(),
                                                        purchasedAmmount.ToString(),
                                                        returned.ToString(),
                                                        returnedAmmount.ToString(),
                                                        soldCount.ToString(),
                                                        soldAmmount.ToString()
                                                }
                });
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

        private void btnProfitAndSale_Click(object sender, EventArgs e)
        {
            SelectDateRangeForm form = new SelectDateRangeForm("Fast Running Items");
            form.ShowDialog(this);

            DateTime fromDate = form.FromDate.Date;
            DateTime toDate = form.ToDate.Date.AddDays(1);

            List<POSItemInfo> items = POSDbUtility.GetAllPOSItems();

            if (items == null || items.Count == 0)
            {
                MessageBox.Show(this, "No item found.");
            }
            else
            {
                POSReportConfig report = new POSReportConfig();

                POSReportsCommonUtility.SetReportConfigStyling(report);

                report.SheetName = "Profit And Sale Report";
                report.Heading = "Profit And Sale Report";


                List<POSReportColumn> columns = new List<POSReportColumn>();

                columns.Add(new POSReportColumn() { Name = "Barcode", Width = 18 });
                columns.Add(new POSReportColumn() { Name = "Item Name", Width = 40 });
                columns.Add(new POSReportColumn() { Name = "Sold Count", Width = 20 });
                columns.Add(new POSReportColumn() { Name = "Total Ammount", Width = 20 });
                columns.Add(new POSReportColumn() { Name = "Profit", Width = 20 });

                report.Columns = columns;

                Dictionary<string, Tuple<string, int, int, int>> reportData = new Dictionary<string, Tuple<string, int, int, int>>();

                int totalSold = 0, totalOfAll = 0, totalProfit = 0;

                foreach (POSItemInfo item in items)
                {
                    if (item != null)
                    {
                        Tuple<string, int, int, int> billData = null;
                        string barcode = item.Barcode;
                        string name = item.Name;

                        List<POSBillItemInfo> billItems = item.BillItems.FindAll(it => it.BillDate.Date >= fromDate && it.BillDate.Date < toDate);
                        if (billItems == null || billItems.Count == 0)
                        {
                            billData = new Tuple<string, int, int, int>(name, 0, 0, 0);
                            reportData.Add(barcode, billData);
                        }
                        else
                        {
                            foreach (POSBillItemInfo billItem in billItems)
                            {                                
                                int soldCount = billItem.Quantity;
                                int total = billItem.Total;
                                int profit = billItem.Profit;

                                totalSold += soldCount;
                                totalOfAll += total;
                                totalProfit += profit;                                

                                if (reportData.ContainsKey(barcode))
                                {
                                    billData = reportData[barcode];

                                    billData = new Tuple<string, int, int, int>(name, billData.Item2 + soldCount, billData.Item3 + total, billData.Item4 + profit);
                                }
                                else
                                {
                                    billData = new Tuple<string, int, int, int>(name, soldCount, total, profit);

                                    reportData.Add(barcode, billData);
                                }
                            }
                        }
                        
                    }
                }

                List<POSReportMetaInfo> metaInfos = new List<POSReportMetaInfo>();

                metaInfos.Add(new POSReportMetaInfo() { ColSpan = 1, Label = "From Date:", RowHeight = 20, Value = fromDate.ToString() });
                metaInfos.Add(new POSReportMetaInfo() { ColSpan = 1, Label = "To Date:", RowHeight = 20, Value = toDate.ToString() });
                metaInfos.Add(new POSReportMetaInfo() { ColSpan = 1, Label = "Total Sold:", RowHeight = 20, Value = totalSold.ToString() });
                metaInfos.Add(new POSReportMetaInfo() { ColSpan = 1, Label = "Total Ammount:", RowHeight = 20, Value = totalOfAll.ToString() });
                metaInfos.Add(new POSReportMetaInfo() { ColSpan = 1, Label = "Total Profit:", RowHeight = 20, Value = totalProfit.ToString() });

                report.MetaInfo = metaInfos;

                List<POSReportData> data = new List<POSReportData>();

                reportData.OrderByDescending(t => t.Value.Item2);

                foreach (KeyValuePair<string, Tuple<string, int, int, int>> dataItem in reportData)
                {
                    Tuple<string, int, int, int> dataItemDetails = dataItem.Value;

                    string barcode = dataItem.Key;
                    string name = dataItemDetails.Item1;
                    int soldCount = dataItemDetails.Item2;
                    int total = dataItemDetails.Item3;
                    int profit = dataItemDetails.Item4;

                    data.Add(new POSReportData()
                    {
                        Values = new List<string>() {
                                                        barcode,
                                                        name,
                                                        soldCount.ToString(),
                                                        total.ToString(),
                                                        profit.ToString()
                                                    }
                    });
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
        }

        private void btnEmployeesReport_Click(object sender, EventArgs e)
        {
            EmployeesReportForm form = new EmployeesReportForm();

            form.ShowDialog(this);

            this.mReportConfig = form.Report;

            if (this.mReportConfig != null && this.mReportConfig.Data.Count > 0)
            {
                this.saveFileDialog1.ShowDialog(this);
            }
            else
            {
                MessageBox.Show(this, "No Data Found.");
            }
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

            report.MetaInfo = metaInfos;

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
            DateTime fromDate = DateTime.Now.Date;
            DateTime toDate = DateTime.Now.Date.AddDays(1);

            List<POSBillInfo> bills = POSDbUtility.GetAllPOSBillInfo(fromDate, toDate);

            if (bills == null || bills.Count == 0)
            {
                MessageBox.Show(this, "No item sold today");
            }
            else
            {
                POSReportConfig report = new POSReportConfig();

                POSReportsCommonUtility.SetReportConfigStyling(report);

                report.SheetName = "Daily Report";
                report.Heading = "Daily Report";

                
                List<POSReportColumn> columns = new List<POSReportColumn>();

                columns.Add(new POSReportColumn() { Name = "Barcode", Width = 18 });
                columns.Add(new POSReportColumn() { Name = "Item Name", Width = 40 });
                columns.Add(new POSReportColumn() { Name = "Sold Count", Width = 20 });
                columns.Add(new POSReportColumn() { Name = "Total Ammount", Width = 20 });
                columns.Add(new POSReportColumn() { Name = "Profit", Width = 20 });

                report.Columns = columns;

                Dictionary<string, Tuple<string, int, int, int>> reportData = new Dictionary<string, Tuple<string, int, int, int>>();

                int totalSold = 0, totalOfAll = 0, totalProfit = 0;

                foreach (POSBillInfo bill in bills)
                {
                    if (bill != null)
                    {
                        foreach (POSBillItemInfo billItem in bill.BillItems)
                        {
                            POSItemInfo item = billItem.PosItem1;

                            string barcode = item.Barcode;
                            string name = item.Name;
                            int soldCount = billItem.Quantity;
                            int total = billItem.Total;
                            int profit = billItem.Profit;

                            totalSold += soldCount;
                            totalOfAll += total;
                            totalProfit += profit;

                            Tuple<string, int, int, int> billData = null;

                            if (reportData.ContainsKey(barcode))
                            {
                                billData = reportData[barcode];

                                billData = new Tuple<string, int, int, int>(name, billData.Item2 + soldCount, billData.Item3 + total, billData.Item4 + profit);
                            }
                            else
                            {
                                billData = new Tuple<string, int, int, int>(name, soldCount, total, profit);

                                reportData.Add(barcode, billData);
                            }
                        }                        
                    }
                }

                List<POSReportMetaInfo> metaInfos = new List<POSReportMetaInfo>();

                metaInfos.Add(new POSReportMetaInfo() { ColSpan = 1, Label = "Date:", RowHeight = 20, Value = DateTime.Now.Date.ToString() });
                metaInfos.Add(new POSReportMetaInfo() { ColSpan = 1, Label = "Total Sold:", RowHeight = 20, Value = totalSold.ToString() });
                metaInfos.Add(new POSReportMetaInfo() { ColSpan = 1, Label = "Total Ammount:", RowHeight = 20, Value = totalOfAll.ToString() });
                metaInfos.Add(new POSReportMetaInfo() { ColSpan = 1, Label = "Total Profit:", RowHeight = 20, Value = totalProfit.ToString() });

                report.MetaInfo = metaInfos;

                List<POSReportData> data = new List<POSReportData>();

                foreach (KeyValuePair<string, Tuple<string, int, int, int>> dataItem in reportData)
                {
                    Tuple<string, int, int, int> dataItemDetails = dataItem.Value;

                    string barcode = dataItem.Key;
                    string name = dataItemDetails.Item1;
                    int soldCount = dataItemDetails.Item2;
                    int total = dataItemDetails.Item3;
                    int profit = dataItemDetails.Item4;

                    data.Add(new POSReportData()
                    {
                        Values = new List<string>() {
                                                        barcode,
                                                        name,
                                                        soldCount.ToString(),
                                                        total.ToString(),
                                                        profit.ToString()
                                                    }
                    });
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
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            POSReportsCommonUtility.GenerateReportAsExcel(this, this.mReportConfig, this.saveFileDialog1.FileName);
        }
    }
}
