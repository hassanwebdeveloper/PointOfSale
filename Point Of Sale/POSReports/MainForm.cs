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
                this.btnFastRunningItems.Enabled = LoginForm.mLoggedInUser.FastRunningReport;
                this.btnAccountsReport.Enabled = LoginForm.mLoggedInUser.AccountReport;
                this.btnProfitAndSale.Enabled = LoginForm.mLoggedInUser.ProfitAndSaleReport;
                this.btnEmployeesReport.Enabled = LoginForm.mLoggedInUser.EmployeeReport;
                this.btnStockReport.Enabled = LoginForm.mLoggedInUser.StockReport;
                this.btnDailyReport.Enabled = LoginForm.mLoggedInUser.DailyReport;
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

            List<POSBillInfo> bills = null;

            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                bills = POSDbUtility.GetAllPOSBillInfo(fromDate, toDate);


                if (bills == null || bills.Count == 0)
                {
                    Cursor.Current = currentCursor;
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
                        if (bill != null && bill.BillItems != null)
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

                                    reportData[barcode] = billData;
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

                    metaInfos.Add(new POSReportMetaInfo() { ValueColSpan = 1, Label = "From Date:", RowHeight = 20, Value = fromDate.ToString() });
                    metaInfos.Add(new POSReportMetaInfo() { ValueColSpan = 1, Label = "To Date:", RowHeight = 20, Value = toDate.ToString() });
                    metaInfos.Add(new POSReportMetaInfo() { ValueColSpan = 1, Label = "Total Sold:", RowHeight = 20, Value = totalSold.ToString() });
                    metaInfos.Add(new POSReportMetaInfo() { ValueColSpan = 1, Label = "Total Ammount:", RowHeight = 20, Value = totalOfAll.ToString() });
                    metaInfos.Add(new POSReportMetaInfo() { ValueColSpan = 1, Label = "Total Profit:", RowHeight = 20, Value = totalProfit.ToString() });

                    report.MetaInfo = metaInfos;

                    List<POSReportData> data = new List<POSReportData>();

                    var orderedList =  reportData.OrderByDescending(t => t.Value.Item2);
                    var orderedKeyValuePair = orderedList.ToList();

                    foreach (KeyValuePair<string, Tuple<string, int, int, int>> dataItem in orderedKeyValuePair)
                    {
                        Tuple<string, int, int, int> dataItemDetails = dataItem.Value;

                        string barcode = dataItem.Key;
                        string name = dataItemDetails.Item1;
                        int soldCount = dataItemDetails.Item2;
                        int total = dataItemDetails.Item3;
                        int profit = dataItemDetails.Item4;

                        data.Add(new POSReportData()
                        {
                            Values = new List<object>() {
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

                    Cursor.Current = currentCursor;
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
            catch (Exception ex)
            {
                string errorMsg = POSComonUtility.GetInnerExceptionMessage(ex);
                Cursor.Current = currentCursor;
                MessageBox.Show(this, "Some error occured in generating report.\n\n" + errorMsg);
            }
        }

        private void btnAccountsReport_Click(object sender, EventArgs e)
        {
            SelectDateRangeForm form = new SelectDateRangeForm("Accounts Report");
            form.ShowDialog(this);

            DateTime fromDate = form.FromDate.Date;
            DateTime toDate = form.ToDate.Date.AddDays(1);

            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                //List<POSItemInfo> items = POSDbUtility.GetAllPOSItems();
                

                //if (items != null)
                //{
                //    items = (from item in items
                //             where item != null &&
                //                   (item.Transactions != null &&
                //                   item.Transactions.Exists(it => it.TransactionTime.Date >= fromDate && it.TransactionTime.Date < toDate)) ||
                //                   (item.BillItems != null && item.BillItems.Exists(it => it.BillDate.Date >= fromDate && it.BillDate.Date < toDate))
                //             select item).ToList();
                //}
                
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
                columns.Add(new POSReportColumn() { Name = "Profit", Width = 20 });
                columns.Add(new POSReportColumn() { Name = "Refund Count", Width = 20 });
                columns.Add(new POSReportColumn() { Name = "Refund Ammount", Width = 20 });
                columns.Add(new POSReportColumn() { Name = "Exchange Count", Width = 20 });
                columns.Add(new POSReportColumn() { Name = "Exchange Ammount", Width = 20 });

                report.Columns = columns;

                List<POSReportData> data = new List<POSReportData>();                             

                int totalSold = 0, totalProfit = 0, totalSoldOfAll = 0, totalPurchased = 0, totalPurchasedAmmount = 0, totalReturned = 0, totalReturnedAmmount = 0, totalRefund = 0, totalRefundAmmount = 0, totalExchange = 0, totalExchangeAmmount = 0;

                Dictionary<string, POSReportModel> reportData = this.GetAccountReportData(fromDate, toDate, ref totalSold, ref totalProfit, ref totalSoldOfAll, ref totalPurchased, ref totalPurchasedAmmount, ref totalReturned, ref totalReturnedAmmount, ref totalRefund, ref totalRefundAmmount, ref totalExchange, ref totalExchangeAmmount);

                int totalExpenses = this.GetTotalExpenseAmount(fromDate, toDate);

                List<POSReportMetaInfo> metaInfos = new List<POSReportMetaInfo>();

                metaInfos.Add(new POSReportMetaInfo() { ValueColSpan = 1, Label = "From Date:", RowHeight = 20, Value = fromDate.ToString() });
                metaInfos.Add(new POSReportMetaInfo() { ValueColSpan = 1, Label = "To Date:", RowHeight = 20, Value = toDate.ToString() });
                metaInfos.Add(new POSReportMetaInfo() { ValueColSpan = 1, Label = "Total Purchased:", RowHeight = 20, Value = totalPurchased.ToString() });
                metaInfos.Add(new POSReportMetaInfo() { LabelColSpan = 1, ValueColSpan = 1, Label = "Purchased Ammount:", RowHeight = 20, Value = totalPurchasedAmmount.ToString() });
                metaInfos.Add(new POSReportMetaInfo() { ValueColSpan = 1, Label = "Total Returned:", RowHeight = 20, Value = totalReturned.ToString() });
                metaInfos.Add(new POSReportMetaInfo() { ValueColSpan = 1, Label = "Returned Ammount:", RowHeight = 20, Value = totalReturnedAmmount.ToString() });
                metaInfos.Add(new POSReportMetaInfo() { ValueColSpan = 1, Label = "Total Sold:", RowHeight = 20, Value = totalSold.ToString() });
                metaInfos.Add(new POSReportMetaInfo() { ValueColSpan = 1, Label = "Sold Ammount:", RowHeight = 20, Value = totalSoldOfAll.ToString() });
                metaInfos.Add(new POSReportMetaInfo() { ValueColSpan = 1, Label = "Total Profit:", RowHeight = 20, Value = totalProfit.ToString() });
                metaInfos.Add(new POSReportMetaInfo() { ValueColSpan = 1, Label = "Total Refunded:", RowHeight = 20, Value = totalRefund.ToString() });
                metaInfos.Add(new POSReportMetaInfo() { ValueColSpan = 1, Label = "Refund Ammount:", RowHeight = 20, Value = totalRefundAmmount.ToString() });
                metaInfos.Add(new POSReportMetaInfo() { ValueColSpan = 1, Label = "Total Exchange:", RowHeight = 20, Value = totalExchange.ToString() });
                metaInfos.Add(new POSReportMetaInfo() { ValueColSpan = 1, Label = "Exchange Ammount:", RowHeight = 20, Value = totalExchangeAmmount.ToString() });
                metaInfos.Add(new POSReportMetaInfo() { ValueColSpan = 1, Label = "Total Expenses:", RowHeight = 20, Value = totalExpenses.ToString() });
                metaInfos.Add(new POSReportMetaInfo() { ValueColSpan = 1, Label = "Cash On Hand:", RowHeight = 20, Value = (totalSoldOfAll + totalReturnedAmmount - totalPurchasedAmmount - totalRefundAmmount - totalExchangeAmmount - totalExpenses).ToString() });

                report.MetaInfo = metaInfos;

                foreach (KeyValuePair<string, POSReportModel> dataItem in reportData)
                {
                    POSReportModel dataItemDetails = dataItem.Value;

                    string barcode = dataItem.Key;
                    string name = dataItemDetails.Name;
                    int purchased = dataItemDetails.PurchasedCount;
                    int purchasedAmmount = dataItemDetails.PurchasedAmount;
                    int returned = dataItemDetails.ReturnedCount;
                    int returnedAmmount = dataItemDetails.ReturnedAmount;
                    int soldCount = dataItemDetails.SoldCount;
                    int soldAmmount = dataItemDetails.SoldAmount;
                    int profit = dataItemDetails.Profit;
                    int refundCount = dataItemDetails.RefundCount;
                    int refundAmmount = dataItemDetails.RefundAmount;
                    int totalExchangeValue = dataItemDetails.ExchangeCount;
                    int totalExchangeAmountValue = dataItemDetails.ExchangeAmount;


                    data.Add(new POSReportData()
                    {
                        Values = new List<object>() {
                                                        barcode,
                                                        name,
                                                        purchased,
                                                        purchasedAmmount,
                                                        returned,
                                                        returnedAmmount,
                                                        soldCount,
                                                        soldAmmount,
                                                        profit,
                                                        refundCount,
                                                        refundAmmount,
                                                        totalExchangeValue,
                                                        totalExchangeAmountValue
                                                }
                    });
                }

                report.Data = data;

                this.mReportConfig = report;

                Cursor.Current = currentCursor;

                if (this.mReportConfig != null && this.mReportConfig.Data.Count > 0)
                {
                    this.saveFileDialog1.ShowDialog(this);
                }
                else
                {
                    MessageBox.Show(this, "No Data Found.");
                }
            }
            catch (Exception ex)
            {
                string errorMsg = POSComonUtility.GetInnerExceptionMessage(ex);
                Cursor.Current = currentCursor;
                MessageBox.Show(this, "Some error occured in Generating report.\n\n" + errorMsg);
            }            
        }

        private Dictionary<string, POSReportModel> GetAccountReportData(DateTime fromDate, DateTime toDate, ref int totalSold, ref int totalProfit, ref int totalSoldOfAll, ref int totalPurchased, ref int totalPurchasedAmmount, ref int totalReturned, ref int totalReturnedAmmount, ref int totalRefund, ref int totalRefundAmmount, ref int totalExchange, ref int totalExchangeAmmount)
        {
            Dictionary<string, POSReportModel> reportData = new Dictionary<string, POSReportModel>();

            List<POSBillInfo> bills = POSDbUtility.GetAllPOSBillInfo(fromDate, toDate);

            List<POSRefundInfo> refunds = POSDbUtility.GetAllPOSRefundInfo(fromDate, toDate, true);

            List<POSItemTransactionInfo> transactions = POSDbUtility.GetAllPOSPurchases(fromDate, toDate);

            if (bills != null)
            {
                foreach (POSBillInfo posBill in bills)
                {
                    if (posBill != null)
                    {
                        if (posBill.BillItems != null)
                        {
                            //List<POSBillItemInfo> billItems = posBill.BillItems.FindAll(it => it.BillDate.Date >= fromDate && it.BillDate.Date < toDate);

                            foreach (POSBillItemInfo billItem in posBill.BillItems)
                            {
                                if (billItem == null || billItem.PosItem1 == null)
                                {
                                    continue;
                                }

                                POSItemInfo item = billItem.PosItem1;

                                string barcode = item.Barcode;
                                string name = item.Name;
                                int soldCount = billItem.Quantity;
                                int total = billItem.Total;
                                int profit = billItem.Profit;

                                totalSold += soldCount;
                                totalSoldOfAll += total;
                                totalProfit += profit;

                                POSReportModel billData = null;

                                if (reportData.ContainsKey(barcode))
                                {
                                    billData = reportData[barcode];

                                    billData.SoldCount += soldCount;
                                    billData.SoldAmount += total;
                                    billData.Profit += profit;

                                    //billData = new Tuple<string, int, int, int, int, int, int>(name, billData.Item2, billData.Item3, billData.Item4, billData.Item5, billData.Item6 + soldCount, billData.Item7 + total);

                                    reportData[barcode] = billData;
                                }
                                else
                                {
                                    billData = new POSReportModel()
                                    {
                                        Name = name,
                                        PurchasedCount = 0,
                                        PurchasedAmount = 0,
                                        ReturnedCount = 0,
                                        ReturnedAmount = 0,
                                        SoldCount = soldCount,
                                        SoldAmount = total,
                                        Profit = profit,
                                        RefundCount = 0,
                                        RefundAmount = 0,
                                        ExchangeCount = 0,
                                        ExchangeAmount = 0,
                                    };
                                    //billData = new Tuple<string, int, int, int, int, int, int>(name, 0, 0, 0, 0, soldCount, total);

                                    reportData.Add(barcode, billData);
                                }
                            }
                        }
                    }
                }
            }

            if (transactions != null)
            {
                foreach (POSItemTransactionInfo transaction in transactions)
                {
                    if (transaction != null)
                    {
                        if (transaction.Items != null)
                        {
                            //List<POSItemTransactionItem> trnasactions = posItem.Transactions.FindAll(it => it.TransactionTime.Date >= fromDate && it.TransactionTime.Date < toDate);

                            foreach (POSItemTransactionItem transactionItem in transaction.Items)
                            {
                                if (transactionItem == null || transactionItem.Item == null)
                                {
                                    continue;
                                }

                                POSItemInfo item = transactionItem.Item;

                                string barcode = item.Barcode;
                                string name = item.Name;

                                int purchased = 0;
                                int purchasedAmount = 0;
                                int returned = 0;
                                int returnedAmmount = 0;

                                if (transactionItem.IsPurchased)
                                {
                                    purchased = transactionItem.ItemCount;
                                    purchasedAmount = transactionItem.ItemCount * transactionItem.ItemRate;

                                    totalPurchased += purchased;
                                    totalPurchasedAmmount += purchasedAmount;
                                }
                                else
                                {
                                    returned = transactionItem.ItemCount;
                                    returnedAmmount = transactionItem.ItemCount * transactionItem.ItemRate;

                                    totalReturned += returned;
                                    totalReturnedAmmount += returnedAmmount;
                                }


                                POSReportModel billData = null;

                                if (reportData.ContainsKey(barcode))
                                {
                                    billData = reportData[barcode];

                                    if (transactionItem.IsPurchased)
                                    {
                                        billData.PurchasedCount += purchased;
                                        billData.PurchasedAmount += purchasedAmount;
                                    }
                                    else
                                    {
                                        billData.ReturnedCount += returned;
                                        billData.ReturnedAmount += returnedAmmount;
                                    }

                                    //if (transaction.IsPurchased)
                                    //{
                                    //    billData = new Tuple<string, int, int, int, int, int, int>(name, billData.Item2 + purchased, billData.Item3 + purchasedAmount, billData.Item4, billData.Item5, billData.Item6, billData.Item7);
                                    //}
                                    //else
                                    //{
                                    //    billData = new Tuple<string, int, int, int, int, int, int>(name, billData.Item2, billData.Item3, billData.Item4 + returned, billData.Item5 + returnedAmmount, billData.Item6, billData.Item7);
                                    //}

                                    reportData[barcode] = billData;
                                }
                                else
                                {
                                    billData = new POSReportModel()
                                    {
                                        Name = name,
                                        PurchasedCount = 0,
                                        PurchasedAmount = 0,
                                        ReturnedCount = 0,
                                        ReturnedAmount = 0,
                                        SoldCount = 0,
                                        SoldAmount = 0,
                                        Profit = 0,
                                        RefundCount = 0,
                                        RefundAmount = 0,
                                        ExchangeCount = 0,
                                        ExchangeAmount = 0,
                                    };

                                    if (transactionItem.IsPurchased)
                                    {
                                        billData.PurchasedCount = purchased;
                                        billData.PurchasedAmount = purchasedAmount;

                                        //billData = new Tuple<string, int, int, int, int, int, int>(name, purchased, purchasedAmount, 0, 0, 0, 0);
                                    }
                                    else
                                    {
                                        billData.ReturnedCount = returned;
                                        billData.ReturnedAmount = returnedAmmount;
                                        //billData = new Tuple<string, int, int, int, int, int, int>(name, 0, 0, returned, returnedAmmount, 0, 0);
                                    }

                                    reportData.Add(barcode, billData);
                                }
                            }
                        }
                    }

                }
            }

            if (refunds != null)
            {
                foreach (POSRefundInfo refund in refunds)
                {
                    if (refund == null || refund.RefundItems == null)
                    {
                        continue;
                    }

                    foreach (POSRefundItemInfo refundItem in refund.RefundItems)
                    {
                        if (refundItem == null || refundItem.BillItemInfo == null || refundItem.BillItemInfo.PosItem1 == null)
                        {
                            continue;
                        }
                        POSItemInfo item = refundItem.BillItemInfo.PosItem1;

                        string barcode = item.Barcode;
                        string name = item.Name;
                        int refundCount = 0;
                        int refundAmmount = 0;
                        int exchangeCount = 0;
                        int exchangeAmount = 0;

                        if (refund.Exchange)
                        {
                            exchangeCount = refundItem.Quantity;
                            exchangeAmount = refundItem.Total;

                            totalExchange += exchangeCount;
                            totalExchangeAmmount += exchangeAmount;
                        }
                        else
                        {
                            refundCount = refundItem.Quantity;
                            refundAmmount = refundItem.Total;

                            totalRefund += refundCount;
                            totalRefundAmmount += refundAmmount;
                        }



                        POSReportModel billData = null;

                        if (reportData.ContainsKey(barcode))
                        {
                            billData = reportData[barcode];

                            billData.RefundCount += refundCount;
                            billData.RefundAmount += refundAmmount;
                            billData.ExchangeCount += exchangeCount;
                            billData.ExchangeAmount += exchangeAmount;

                            //billData = new Tuple<string, int, int, int, int, int, int, int>(name, billData.Item2, billData.Item3, billData.Item4, billData.Item5 + refundCount, billData.Item6 + refundAmmount, billData.Item7 + totalExchange, billData.Rest + totalExchangeAmmount);

                            reportData[barcode] = billData;
                        }
                        else
                        {
                            billData = new POSReportModel()
                            {
                                Name = name,
                                PurchasedCount = 0,
                                PurchasedAmount = 0,
                                ReturnedCount = 0,
                                ReturnedAmount = 0,
                                SoldCount = 0,
                                SoldAmount = 0,
                                Profit = 0,
                                RefundCount = refundCount,
                                RefundAmount = refundAmmount,
                                ExchangeCount = exchangeCount,
                                ExchangeAmount = exchangeAmount,
                            };

                            //billData = new Tuple<string, int, int, int, int, int, int, int>(name, 0, 0, 0, refundCount, refundAmmount, totalExchange, totalExchangeAmmount);

                            reportData.Add(barcode, billData);
                        }
                    }
                }
            }

            return reportData;
        }

        private int GetTotalExpenseAmount(DateTime fromDate, DateTime toDate)
        {
            int expense = 0;

            List<POSExpenseInfo> expenses = POSDbUtility.GetAllPOSExpenses(fromDate, toDate);

            foreach (POSExpenseInfo expenseInfo in expenses)
            {
                if (expenseInfo != null)
                {
                    expense += expenseInfo.Ammount;
                }
            }

            return expense;
        }

        private void btnProfitAndSale_Click(object sender, EventArgs e)
        {
            SelectDateRangeForm form = new SelectDateRangeForm("Fast Running Items");
            form.ShowDialog(this);

            DateTime fromDate = form.FromDate.Date;
            DateTime toDate = form.ToDate.Date.AddDays(1);

            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                List<POSItemInfo> items = POSDbUtility.GetAllPOSItems();

                if (items == null || items.Count == 0)
                {
                    Cursor.Current = currentCursor;
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
                        if (item != null && item.BillItems != null)
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

                                        reportData[barcode] = billData;
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

                    metaInfos.Add(new POSReportMetaInfo() { ValueColSpan = 1, Label = "From Date:", RowHeight = 20, Value = fromDate.ToString() });
                    metaInfos.Add(new POSReportMetaInfo() { ValueColSpan = 1, Label = "To Date:", RowHeight = 20, Value = toDate.ToString() });
                    metaInfos.Add(new POSReportMetaInfo() { ValueColSpan = 1, Label = "Total Sold:", RowHeight = 20, Value = totalSold.ToString() });
                    metaInfos.Add(new POSReportMetaInfo() { ValueColSpan = 1, Label = "Total Ammount:", RowHeight = 20, Value = totalOfAll.ToString() });
                    metaInfos.Add(new POSReportMetaInfo() { ValueColSpan = 1, Label = "Total Profit:", RowHeight = 20, Value = totalProfit.ToString() });

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
                            Values = new List<object>() {
                                                        barcode,
                                                        name,
                                                        soldCount,
                                                        total,
                                                        profit
                                                    }
                        });
                    }

                    report.Data = data;

                    this.mReportConfig = report;

                    Cursor.Current = currentCursor;

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
            catch (Exception ex)
            {
                string errorMsg = POSComonUtility.GetInnerExceptionMessage(ex);
                Cursor.Current = currentCursor;
                MessageBox.Show(this, "Some error occured in generating report.\n\n" + errorMsg);
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
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                List<POSItemInfo> items = POSDbUtility.GetAllPOSItems();

                if (items == null)
                {
                    Cursor.Current = currentCursor;
                    MessageBox.Show(this, "No Data Found.");
                }
                else
                {
                    POSReportConfig report = new POSReportConfig();

                    POSReportsCommonUtility.SetReportConfigStyling(report);

                    report.SheetName = "Stock Report";
                    report.Heading = "Stock Report";

                    List<POSReportMetaInfo> metaInfos = new List<POSReportMetaInfo>();

                    int totalQuantity = 0, totalAmmount = 0;

                    Dictionary<string, int> categoryWiseTotalAmmount = new Dictionary<string, int>();
                    Dictionary<string, int> categoryWiseTotalQuantity = new Dictionary<string, int>();

                    int totalRemainingQuantity = 0, totalRemainingAmmount = 0;

                    Dictionary<string, int> categoryWiseTotalRemainingAmmount = new Dictionary<string, int>();
                    Dictionary<string, int> categoryWiseTotalRemainingQuantity = new Dictionary<string, int>();

                    foreach (POSItemInfo item in items)
                    {
                        if (item != null)
                        {
                            totalQuantity += item.TotalItemsPurchased;
                            totalAmmount += item.TotalStockAmmount;

                            if (categoryWiseTotalQuantity.ContainsKey(item.CategoryName))
                            {
                                categoryWiseTotalQuantity[item.CategoryName] =
                                    categoryWiseTotalQuantity[item.CategoryName] + item.TotalItemsPurchased;
                            }
                            else
                            {
                                categoryWiseTotalQuantity.Add(item.CategoryName, item.TotalItemsPurchased);
                            }

                            if (categoryWiseTotalAmmount.ContainsKey(item.CategoryName))
                            {
                                categoryWiseTotalAmmount[item.CategoryName] =
                                    categoryWiseTotalAmmount[item.CategoryName] + item.TotalStockAmmount;
                            }
                            else
                            {
                                categoryWiseTotalAmmount.Add(item.CategoryName, item.TotalStockAmmount);
                            }
                            
                            totalRemainingQuantity += item.RemainingQuantity;
                            totalRemainingAmmount += item.RemainingStockAmmount;

                            if (categoryWiseTotalRemainingQuantity.ContainsKey(item.CategoryName))
                            {
                                categoryWiseTotalRemainingQuantity[item.CategoryName] =
                                    categoryWiseTotalRemainingQuantity[item.CategoryName] + item.RemainingQuantity;
                            }
                            else
                            {
                                categoryWiseTotalRemainingQuantity.Add(item.CategoryName, item.RemainingQuantity);
                            }

                            if (categoryWiseTotalRemainingAmmount.ContainsKey(item.CategoryName))
                            {
                                categoryWiseTotalRemainingAmmount[item.CategoryName] =
                                    categoryWiseTotalRemainingAmmount[item.CategoryName] + item.RemainingStockAmmount;
                            }
                            else
                            {
                                categoryWiseTotalRemainingAmmount.Add(item.CategoryName, item.RemainingStockAmmount);
                            }
                        }
                    }


                    metaInfos.Add(new POSReportMetaInfo() { ValueColSpan = 1, Label = "Items in stock:", RowHeight = 20, Value = items.Count.ToString() });
                    metaInfos.Add(new POSReportMetaInfo() { ValueColSpan = 1, Label = "Total Quantity:", RowHeight = 20, Value = totalQuantity.ToString() });
                    metaInfos.Add(new POSReportMetaInfo() { LabelColSpan = 1, ValueColSpan = 1, Label = "Remaining Quantity:", RowHeight = 20, Value = totalRemainingQuantity.ToString() });
                    metaInfos.Add(new POSReportMetaInfo() { LabelColSpan = 1, ValueColSpan = 1, Label = "Total Stock Amount:", RowHeight = 20, Value = totalAmmount.ToString() });
                    metaInfos.Add(new POSReportMetaInfo() { LabelColSpan = 1, ValueColSpan = 1, Label = "Remaining Stock Amount:", RowHeight = 20, Value = totalRemainingAmmount.ToString() });

                    foreach (KeyValuePair<string, int> item in categoryWiseTotalQuantity)
                    {
                        string categoryName = item.Key;

                        int categoryTotalQuantity = categoryWiseTotalQuantity[categoryName];
                        int categoryTotalRemainingQuantity = categoryWiseTotalRemainingQuantity[categoryName];
                        int categoryTotalAmount = categoryWiseTotalAmmount[categoryName];
                        int categoryTotalRemainingAmount = categoryWiseTotalRemainingAmmount[categoryName];

                        string quantityLabel = categoryName + " Total Quantity:";
                        string remainingQuantityLabel = categoryName + " Total Remaining Quantity:";
                        string stockAmountLabel = categoryName + " Total Stock Amount:";
                        string remainingStockAmountLabel = categoryName + " Remaining Stock Amount:";

                        metaInfos.Add(new POSReportMetaInfo() { LabelColSpan = quantityLabel.Length > 16 ? 1 : 0, ValueColSpan = 1, Label = quantityLabel, RowHeight = 20, Value = categoryTotalQuantity.ToString() });
                        metaInfos.Add(new POSReportMetaInfo() { LabelColSpan = remainingQuantityLabel.Length > 16 ? 1 : 0, ValueColSpan = 1, Label = remainingQuantityLabel, RowHeight = 20, Value = categoryTotalRemainingQuantity.ToString() });
                        metaInfos.Add(new POSReportMetaInfo() { LabelColSpan = stockAmountLabel.Length > 16 ? 1 : 0, ValueColSpan = 1, Label = stockAmountLabel, RowHeight = 20, Value = categoryTotalAmount.ToString() });
                        metaInfos.Add(new POSReportMetaInfo() { LabelColSpan = remainingStockAmountLabel.Length > 16 ? 1 : 0, ValueColSpan = 1, Label = remainingStockAmountLabel, RowHeight = 20, Value = categoryTotalRemainingAmount.ToString() });

                    }

                    report.MetaInfo = metaInfos;

                    List<POSReportColumn> columns = new List<POSReportColumn>();

                    columns.Add(new POSReportColumn() { Name = "Barcode", Width = 18 });
                    columns.Add(new POSReportColumn() { Name = "Item Name", Width = 40 });
                    columns.Add(new POSReportColumn() { Name = "Vendor Name", Width = 40 });
                    columns.Add(new POSReportColumn() { Name = "Total Purchased", Width = 20 });
                    columns.Add(new POSReportColumn() { Name = "Sold", Width = 20 });
                    columns.Add(new POSReportColumn() { Name = "Remaining", Width = 20 });
                    columns.Add(new POSReportColumn() { Name = "Buying Price", Width = 20 });
                    columns.Add(new POSReportColumn() { Name = "Selling Price", Width = 20 });
                    columns.Add(new POSReportColumn() { Name = "Discount", Width = 20 });
                    columns.Add(new POSReportColumn() { Name = "Discounted Price", Width = 20 });


                    report.Columns = columns;

                    List<POSReportData> data = new List<POSReportData>();

                    foreach (POSItemInfo item in items)
                    {
                        if (item != null)
                        {
                            data.Add(new POSReportData()
                            {
                                Values = new List<object>() { item.Barcode,
                                                              item.Name,
                                                              item.VendorName,
                                                              item.TotalItemsPurchased,
                                                              item.TotalItemsSold,
                                                              item.GetRemaningQuantity(0),
                                                              item.BuyingPrice,
                                                              item.SellingPrice,
                                                              item.DiscountPrice,                                                              
                                                              item.DiscountedPrice}
                            });
                        }
                    }

                    Cursor.Current = currentCursor;

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
            catch (Exception ex)
            {
                string errorMsg = POSComonUtility.GetInnerExceptionMessage(ex);
                Cursor.Current = currentCursor;
                MessageBox.Show(this, "Some error occured in generating report.\n\n" + errorMsg);
            }
        }

        private void btnDailyReport_Click(object sender, EventArgs e)
        {
            DateTime fromDate = DateTime.Now.Date;
            DateTime toDate = DateTime.Now.Date.AddDays(1);

            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                //List<POSBillInfo> bills = POSDbUtility.GetAllPOSBillInfo(fromDate, toDate);

                //List<POSRefundInfo> refunds = POSDbUtility.GetAllPOSRefundInfo(fromDate, toDate, true);

                //List<POSItemTransactionInfo> transactions = POSDbUtility.GetAllPOSPurchases(fromDate, toDate);

                //if (bills == null || bills.Count == 0)
                //{
                //    Cursor.Current = currentCursor;
                //    MessageBox.Show(this, "No item sold today");
                //}
                //else
                //{
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
                columns.Add(new POSReportColumn() { Name = "Refund Count", Width = 20 });
                columns.Add(new POSReportColumn() { Name = "Refund Ammount", Width = 20 });
                columns.Add(new POSReportColumn() { Name = "Exchange Count", Width = 20 });
                columns.Add(new POSReportColumn() { Name = "Exchange Ammount", Width = 20 });
                columns.Add(new POSReportColumn() { Name = "Purchased", Width = 20 });
                columns.Add(new POSReportColumn() { Name = "Purchase Ammount", Width = 20 });
                columns.Add(new POSReportColumn() { Name = "Returned", Width = 20 });
                columns.Add(new POSReportColumn() { Name = "Returned Ammount", Width = 20 });

                report.Columns = columns;

                int totalSold = 0, totalProfit = 0, totalSoldOfAll = 0, totalPurchased = 0, totalPurchasedAmmount = 0, totalReturned = 0, totalReturnedAmmount = 0, totalRefund = 0, totalRefundAmmount = 0, totalExchange = 0, totalExchangeAmmount = 0;

                Dictionary<string, POSReportModel> reportData = this.GetAccountReportData(fromDate, toDate, ref totalSold, ref totalProfit, ref totalSoldOfAll, ref totalPurchased, ref totalPurchasedAmmount, ref totalReturned, ref totalReturnedAmmount, ref totalRefund, ref totalRefundAmmount, ref totalExchange, ref totalExchangeAmmount);

                int totalExpenses = this.GetTotalExpenseAmount(fromDate, toDate);

                #region oldCode
                //Dictionary<string, POSReportModel> reportData = new Dictionary<string, POSReportModel>();

                //int totalSold = 0, totalOfAll = 0, totalProfit = 0, totalRefund = 0, totalRefundAmmount = 0, totalExchange = 0, totalExchangeAmmount = 0;

                //foreach (POSBillInfo bill in bills)
                //{
                //    if (bill != null)
                //    {
                //        foreach (POSBillItemInfo billItem in bill.BillItems)
                //        {
                //            POSItemInfo item = billItem.PosItem1;

                //            string barcode = item.Barcode;
                //            string name = item.Name;
                //            int soldCount = billItem.Quantity;
                //            int total = billItem.Total;
                //            int profit = billItem.Profit;

                //            totalSold += soldCount;
                //            totalOfAll += total;
                //            totalProfit += profit;

                //            POSReportModel billData = null;

                //            if (reportData.ContainsKey(barcode))
                //            {
                //                billData = reportData[barcode];

                //                billData.SoldCount += soldCount;
                //                billData.SoldAmount += total;
                //                billData.Profit += profit;

                //                //billData = new Tuple<string, int, int, int, int, int, int, int>(name, billData.Item2 + soldCount, billData.Item3 + total, billData.Item4 + profit, billData.Item5, billData.Item6, billData.Item7, billData.Rest);

                //                reportData[barcode] = billData;
                //            }
                //            else
                //            {
                //                billData = new POSReportModel()
                //                {
                //                    Name = name,
                //                    SoldCount = soldCount,
                //                    SoldAmount = total,
                //                    Profit = profit,
                //                    RefundCount = 0,
                //                    RefundAmount = 0,
                //                    ExchangeCount = 0,
                //                    ExchangeAmount = 0,
                //                };

                //                //billData = new Tuple<string, int, int, int, int, int, int, int>(name, soldCount, total, profit, 0, 0, 0, 0);

                //                reportData.Add(barcode, billData);
                //            }
                //        }
                //    }
                //}

                //foreach (POSRefundInfo refund in refunds)
                //{
                //    if (refund == null || refund.RefundItems == null)
                //    {
                //        continue;
                //    }

                //    foreach (POSRefundItemInfo refundItem in refund.RefundItems)
                //    {
                //        if (refundItem == null || refundItem.BillItemInfo == null || refundItem.BillItemInfo.PosItem1 == null)
                //        {
                //            continue;
                //        }
                //        POSItemInfo item = refundItem.BillItemInfo.PosItem1;

                //        string barcode = item.Barcode;
                //        string name = item.Name;
                //        int refundCount = 0;
                //        int refundAmmount = 0;
                //        int exchangeCount = 0;
                //        int exchangeAmount = 0;

                //        if (refund.Exchange)
                //        {
                //            exchangeCount = refundItem.Quantity;
                //            exchangeAmount = refundItem.Total;

                //            totalExchange += refundCount;
                //            totalExchangeAmmount += refundAmmount;
                //        }
                //        else
                //        {
                //            refundCount = refundItem.Quantity;
                //            refundAmmount = refundItem.Total;

                //            totalRefund += refundCount;
                //            totalRefundAmmount += refundAmmount;
                //        }



                //        POSReportModel billData = null;

                //        if (reportData.ContainsKey(barcode))
                //        {
                //            billData = reportData[barcode];

                //            billData.RefundCount += refundCount;
                //            billData.ReturnedAmount += refundAmmount;
                //            billData.ExchangeCount += exchangeCount;
                //            billData.ExchangeAmount += exchangeAmount;

                //            //billData = new Tuple<string, int, int, int, int, int, int, int>(name, billData.Item2, billData.Item3, billData.Item4, billData.Item5 + refundCount, billData.Item6 + refundAmmount, billData.Item7 + totalExchange, billData.Rest + totalExchangeAmmount);

                //            reportData[barcode] = billData;
                //        }
                //        else
                //        {
                //            billData = new POSReportModel()
                //            {
                //                Name = name,
                //                SoldCount = 0,
                //                SoldAmount = 0,
                //                Profit = 0,
                //                RefundCount = refundCount,
                //                RefundAmount = refundAmmount,
                //                ExchangeCount = exchangeCount,
                //                ExchangeAmount = exchangeAmount,
                //            };

                //            //billData = new Tuple<string, int, int, int, int, int, int, int>(name, 0, 0, 0, refundCount, refundAmmount, totalExchange, totalExchangeAmmount);

                //            reportData.Add(barcode, billData);
                //        }
                //    }
                //}

                #endregion

                List<POSReportMetaInfo> metaInfos = new List<POSReportMetaInfo>();

                metaInfos.Add(new POSReportMetaInfo() { ValueColSpan = 1, Label = "Date:", RowHeight = 20, Value = DateTime.Now.Date.ToString() });
                metaInfos.Add(new POSReportMetaInfo() { ValueColSpan = 1, Label = "Total Sold:", RowHeight = 20, Value = totalSold.ToString() });
                metaInfos.Add(new POSReportMetaInfo() { ValueColSpan = 1, Label = "Total Ammount:", RowHeight = 20, Value = totalSoldOfAll.ToString() });
                metaInfos.Add(new POSReportMetaInfo() { ValueColSpan = 1, Label = "Total Profit:", RowHeight = 20, Value = totalProfit.ToString() });
                metaInfos.Add(new POSReportMetaInfo() { ValueColSpan = 1, Label = "Total Purchased:", RowHeight = 20, Value = totalPurchased.ToString() });
                metaInfos.Add(new POSReportMetaInfo() { ValueColSpan = 1, Label = "Purchased Ammount:", RowHeight = 20, Value = totalPurchasedAmmount.ToString() });
                metaInfos.Add(new POSReportMetaInfo() { ValueColSpan = 1, Label = "Total Returned:", RowHeight = 20, Value = totalReturned.ToString() });
                metaInfos.Add(new POSReportMetaInfo() { ValueColSpan = 1, Label = "Returned Ammount:", RowHeight = 20, Value = totalReturnedAmmount.ToString() });
                metaInfos.Add(new POSReportMetaInfo() { ValueColSpan = 1, Label = "Total Refunded:", RowHeight = 20, Value = totalRefund.ToString() });
                metaInfos.Add(new POSReportMetaInfo() { ValueColSpan = 1, Label = "Refund Ammount:", RowHeight = 20, Value = totalRefundAmmount.ToString() });
                metaInfos.Add(new POSReportMetaInfo() { ValueColSpan = 1, Label = "Total Exchange:", RowHeight = 20, Value = totalExchange.ToString() });
                metaInfos.Add(new POSReportMetaInfo() { ValueColSpan = 1, Label = "Exchange Ammount:", RowHeight = 20, Value = totalExchangeAmmount.ToString() });
                metaInfos.Add(new POSReportMetaInfo() { ValueColSpan = 1, Label = "Total Expenses:", RowHeight = 20, Value = totalExpenses.ToString() });
                metaInfos.Add(new POSReportMetaInfo() { ValueColSpan = 1, Label = "Cash On Hand:", RowHeight = 20, Value = (totalSoldOfAll + totalReturnedAmmount - totalPurchasedAmmount - totalRefundAmmount - totalExchangeAmmount - totalExpenses).ToString() });

                report.MetaInfo = metaInfos;

                List<POSReportData> data = new List<POSReportData>();

                foreach (KeyValuePair<string, POSReportModel> dataItem in reportData)
                {
                    POSReportModel dataItemDetails = dataItem.Value;

                    string barcode = dataItem.Key;
                    string name = dataItemDetails.Name;
                    int soldCount = dataItemDetails.SoldCount;
                    int total = dataItemDetails.SoldAmount;
                    int profit = dataItemDetails.Profit;
                    int refundCount = dataItemDetails.RefundCount;
                    int refundAmmount = dataItemDetails.RefundAmount;
                    int totalExchangeValue = dataItemDetails.ExchangeCount;
                    int totalExchangeAmountValue = dataItemDetails.ExchangeAmount;
                    int purchased = dataItemDetails.PurchasedCount;
                    int purchasedAmmount = dataItemDetails.PurchasedAmount;
                    int returned = dataItemDetails.ReturnedCount;
                    int returnedAmmount = dataItemDetails.ReturnedAmount;

                    data.Add(new POSReportData()
                    {
                        Values = new List<object>() {
                                                        barcode,
                                                        name,
                                                        soldCount,
                                                        total,
                                                        profit,
                                                        refundCount,
                                                        refundAmmount,
                                                        totalExchangeValue,
                                                        totalExchangeAmountValue,
                                                        purchased,
                                                        purchasedAmmount,
                                                        returned,
                                                        returnedAmmount,
                                                    }
                    });
                }

                Cursor.Current = currentCursor;

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
                //}
            }
            catch (Exception ex)
            {
                string errorMsg = POSComonUtility.GetInnerExceptionMessage(ex);
                Cursor.Current = currentCursor;
                MessageBox.Show(this, "Some error occured in generating report.\n\n" + errorMsg);
            }


        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            POSReportsCommonUtility.GenerateReportAsExcel(this, this.mReportConfig, this.saveFileDialog1.FileName);
        }
    }
}
