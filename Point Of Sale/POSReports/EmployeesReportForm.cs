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
        private POSReportConfig mReport;

        public EmployeesReportForm()
        {
            InitializeComponent();

            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                this.mLstSalesMan = POSDbUtility.GetAllPOSSalesMan(-1);
            }
            catch (Exception ex)
            {
                string errorMsg = POSComonUtility.GetInnerExceptionMessage(ex);
                Cursor.Current = currentCursor;
                MessageBox.Show(this, "Some error occured in fetching sales man.\n\n" + errorMsg);                
            }

            Cursor.Current = currentCursor;            

            if (this.mLstSalesMan != null && this.mLstSalesMan.Count > 0)
            {
                List<CCBoxItem> lstStrSalesMan = (from salesMan in mLstSalesMan
                                                  where salesMan != null
                                                  select new CCBoxItem() { Name = salesMan.Name + " " + salesMan.LastName, Value = salesMan.Id }).ToList();

                cbxSalesMans.Items.AddRange(lstStrSalesMan.ToArray());

                // If more then 5 items, add a scroll bar to the dropdown.
                cbxSalesMans.MaxDropDownItems = 5;
                // Make the "Name" property the one to display, rather than the ToString() representation.
                cbxSalesMans.DisplayMember = "Name";
                //cbxSalesMans.ValueSeparator = ", ";
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

            //CheckedListBox.CheckedItemCollection selectedItems = cbxSalesMans.CheckedItems;
            CCBoxItem selectedItem = cbxSalesMans.SelectedItem as CCBoxItem;


            if (selectedItem != null)
            {
                Cursor currentCursor = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;

                try
                {
                    this.mReport = new POSReportConfig();

                    POSReportsCommonUtility.SetReportConfigStyling(this.mReport);

                    this.mReport.SheetName = "Employee Report";
                    this.mReport.Heading = "Employee Report";

                    List<POSReportMetaInfo> metaInfos = new List<POSReportMetaInfo>();

                    metaInfos.Add(new POSReportMetaInfo() { ValueColSpan = 1, Label = "From Date:", RowHeight = 20, Value = dtpFrom.Value.Date.ToString() });
                    metaInfos.Add(new POSReportMetaInfo() { ValueColSpan = 1, Label = "To Date:", RowHeight = 20, Value = dtpTo.Value.Date.ToString() });

                    this.mReport.MetaInfo = metaInfos;

                    //foreach (CCBoxItem item in selectedItems)
                    //{
                    //    if (item != null)
                    //    {
                            metaInfos.Add(new POSReportMetaInfo() { ValueColSpan = 1, Label = "Employee Name:", RowHeight = 20, Value = selectedItem.Name });
                    //    }
                    //}

                    List<POSReportColumn> columns = new List<POSReportColumn>();

                    columns.Add(new POSReportColumn() { Name = "ID", Width = 18 });
                    columns.Add(new POSReportColumn() { Name = "Name", Width = 40 });
                    columns.Add(new POSReportColumn() { Name = "Date", Width = 25 });
                    columns.Add(new POSReportColumn() { Name = "Salary", Width = 20 });
                    columns.Add(new POSReportColumn() { Name = "Items Sold", Width = 25 });                    
                    columns.Add(new POSReportColumn() { Name = "Commision", Width = 20 });
                    columns.Add(new POSReportColumn() { Name = "Total", Width = 20 });

                    this.mReport.Columns = columns;

                    List<POSReportData> data = new List<POSReportData>();

                    string id, name, date = string.Empty;

                    int salary, itemsSoldInt, commisionInt, totalInt = 0;

                    int salaryValue, daysInMonth = 0;

                    bool monthWise = rdbMonthWise.Checked;

                    //foreach (CCBoxItem item in selectedItems)
                    //{
                        //if (item != null)
                        //{
                            POSSalesMan salesMan = this.mLstSalesMan.Find(s => s.Id == selectedItem.Value);

                            if (salesMan != null && salesMan.Bills != null)
                            {
                                List<POSBillInfo> bills = salesMan.Bills.FindAll(bill => bill != null && bill.BillCreatedDate >= fromDate && bill.BillCreatedDate < ToDate);

                                Dictionary<string, List<int>> salesManData = new Dictionary<string, List<int>>();

                                if (bills != null)
                                {
                                    foreach (POSBillInfo bill in bills)
                                    {
                                        if (bill == null)
                                        {
                                            continue;
                                        }

                                        string currentDate = monthWise ? bill.BillCreatedDate.ToString("MMMM") : bill.BillCreatedDate.Date.ToShortDateString();

                                        daysInMonth = DateTime.DaysInMonth(bill.BillCreatedDate.Year, bill.BillCreatedDate.Month);
                                        int perDaySalary = (salesMan.Salary / daysInMonth);

                                        salaryValue = monthWise ? salesMan.Salary : perDaySalary;

                                        int itemsSold = bill.TotalItems;
                                        int commision = bill.TotalSalesManCommision;

                                        List<int> financeData = new List<int>();

                                        if (salesManData.ContainsKey(currentDate))
                                        {
                                            financeData = salesManData[currentDate];

                                            financeData[0] = salaryValue;
                                            financeData[1] += itemsSold;
                                            financeData[2] += commision;
                                            financeData[3] += commision;
                                        }
                                        else
                                        {
                                            financeData.Add(salaryValue);
                                            financeData.Add(itemsSold);
                                            financeData.Add(commision);
                                            financeData.Add(salaryValue + commision);
                                            salesManData.Add(currentDate, financeData);
                                        }
                                    }

                                    id = salesMan.Barcode.ToString();
                                    name = salesMan.Name + " " + salesMan.LastName;

                                    foreach (KeyValuePair<string, List<int>> dataItem in salesManData)
                                    {
                                        List<int> financeData = dataItem.Value;

                                        if (financeData == null || financeData.Count < 4)
                                        {
                                            continue;
                                        }

                                        date = dataItem.Key;
                                        salary = financeData[0];
                                        itemsSoldInt = financeData[1];
                                        commisionInt = financeData[2];
                                        totalInt = financeData[3];

                                        data.Add(new POSReportData() { Values = new List<object>() { id, name, date, salary, itemsSoldInt, commisionInt, totalInt } });
                                    }
                                }
                            }
                        //}
                    //}

                    this.mReport.Data = data;
                }
                catch (Exception ex)
                {
                    string errorMsg = POSComonUtility.GetInnerExceptionMessage(ex);
                    Cursor.Current = currentCursor;
                    MessageBox.Show(this, "Some error occured in generating report.\n\n" + errorMsg);
                }

                Cursor.Current = currentCursor;
                this.Close();
            }
            else
            {
                MessageBox.Show(this, "Please select any sales man.");
            }
        }

        public POSReportConfig Report
        {
            get
            {
                return this.mReport;
            }
        }
    }
}
