using BarcodeLib;
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

namespace Point_Of_Sale
{
    public partial class PointOfSaleForm : Form, IScanable
    {
        private List<POSSalesMan> mSalesMans;
        private List<POSGridItemInfo> mItems = new List<POSGridItemInfo>();
        private POSBillInfo mBillInfo = null;

        public PointOfSaleForm()
        {
            InitializeComponent();

            PopulateDropDowns();
        }

        private void PopulateDropDowns()
        {
            List<POSSalesMan> salesMans = POSDbUtility.GetAllPOSSalesMan(-1);

            this.mSalesMans = salesMans;

            List<string> names = (from saleMan in salesMans
                                  select saleMan.Name).ToList();

            this.cbxSalesMans.Items.AddRange(names.ToArray());

        }
        
        private void dgvPOSItems_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (this.dgvPOSItems.Rows.Count == 0)
            {
                return;
            }

            for (int i = 0; i < this.mItems.Count; i++)
            {
                DataGridViewRow row = this.dgvPOSItems.Rows[i];

                row.Tag = this.mItems[i];
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string itemName = this.tbxItemName.Text;

            SearchPOSItemInfoForm search = new SearchPOSItemInfoForm(itemName);

            search.ShowDialog(this);

            if (search.SelectedItem != null)
            {
                this.mItems.Add(search.SelectedItem);

                this.bsPOSGridItemInfo.DataSource = null;
                this.bsPOSGridItemInfo.DataSource = this.mItems;

                

                DataGridViewRow row = this.dgvPOSItems.Rows[this.dgvPOSItems.Rows.Count -1];
                
                this.dgvPOSItems.ClearSelection();
                row.Selected = true;
                this.UpdateBillInfo();
            }
        }

        private void UpdateBillInfo()
        {            
            int totalDiscount = 0;
            int totalPrice = 0;
            int balance = 0;
            int amountPaid = string.IsNullOrEmpty(this.tbxAmountPaid.Text) ? 0 : Convert.ToInt32(this.tbxAmountPaid.Text);

            foreach (POSGridItemInfo item in this.mItems)
            {
                if (item == null)
                {
                    continue;
                }
                else
                {
                    totalDiscount += item.Discount;
                    totalPrice += item.Total;
                }
            }

            this.lblItemsCount.Text = this.mItems.Count(gridItem => gridItem.POSItem != null).ToString();
            this.lblTotalDiscount.Text = totalDiscount.ToString();
            this.lblTotal.Text = (totalPrice).ToString();
            this.lblBalance.Text = amountPaid == 0 ? "0" :(amountPaid - (totalPrice)).ToString();
        }

        private void dgvPOSItems_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dgvPOSItems.SelectedRows == null ||
                this.dgvPOSItems.SelectedRows.Count == 0 ||
                this.dgvPOSItems.SelectedRows[0] == null ||
                this.dgvPOSItems.SelectedRows[0].Tag == null)
            {

                return;
            }

            POSGridItemInfo itemInfo = this.dgvPOSItems.SelectedRows[0].Tag as POSGridItemInfo;

            this.pbxProductImage.Image = itemInfo.Image;
        }

        private void dgvPOSItems_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 0 || e.ColumnIndex == 1 || e.ColumnIndex == 2 || e.ColumnIndex == 5)
            {
                e.Cancel = true;
                return;
            }
        }

        private void dgvPOSItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dgvPOSItems.Rows[e.RowIndex];
            string cellValue = Convert.ToString(row.Cells[e.ColumnIndex].Value);

            if (POSComonUtility.IsDigitsOnly(cellValue))
            {
                int value = Convert.ToInt32(cellValue);

                POSGridItemInfo itemInfo = row.Tag as POSGridItemInfo;

                if (e.ColumnIndex == 3)
                {
                    itemInfo.Quantity = value;
                }
                else if (e.ColumnIndex == 4)
                {
                    itemInfo.Discount = value;
                }

                row.Cells[5].Value = itemInfo.Total;
                this.UpdateBillInfo();
            }
            else
            {
                this.dgvPOSItems.CancelEdit();

                MessageBox.Show(this, "Please enter only numbers.");
            }
        }

        private void btnNewBill_Click(object sender, EventArgs e)
        {
            PointOfSaleForm posForm = new PointOfSaleForm();

            posForm.Show();

        }

        private void tbxAmountPaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            POSComonUtility.AllowNumericOnly(e);
        }

        private void tbxAmountPaid_KeyUp(object sender, KeyEventArgs e)
        {
            this.UpdateBillInfo();
        }

        private void btnSaveBill_Click(object sender, EventArgs e)
        {
            int amountPaid = string.IsNullOrEmpty(this.tbxAmountPaid.Text) ? 0 : Convert.ToInt32(this.tbxAmountPaid.Text);
            string errorMsg = string.Empty;

            POSStatusCodes status = SaveBill(this.mBillInfo, amountPaid, false, false, ref errorMsg);

            if (status == POSStatusCodes.Failed)
            {
                MessageBox.Show(this, "Some error occured in saving bill.\n\n" + errorMsg);
            }
            else if(status == POSStatusCodes.Aborted)
            {
                MessageBox.Show(this, errorMsg);
            }
        }

        private POSStatusCodes SaveBill(POSBillInfo posBill, int amountPayed, bool billPayed, bool billCanceled, ref string errorMsg)
        {

            if (posBill != null && posBill.BillPayed)
            {
                errorMsg = "Bill is already Paid.";
                return POSStatusCodes.Aborted;
            }

            if (posBill != null && posBill.BillCanceled)
            {
                errorMsg = "Bill is already Canceled.";
                return POSStatusCodes.Aborted;
            }

            if (this.cbxSalesMans.SelectedIndex < 0)
            {
                errorMsg = "Please select any sales man.";
                return POSStatusCodes.Aborted;
            }

            if (this.dgvPOSItems.Rows == null || this.dgvPOSItems.Rows.Count == 0)
            {
                errorMsg = "Please add some items in bill.";
                return POSStatusCodes.Aborted; ;
            }

            
            POSAppUser appUser = LoginForm.mLoggedInUser;
            POSSalesMan salesMan = this.mSalesMans[this.cbxSalesMans.SelectedIndex];

            List<POSRefundInfo> refunds = new List<POSRefundInfo>();
            List<POSBillItemInfo> billItems = new List<POSBillItemInfo>();

            foreach (DataGridViewRow row in this.dgvPOSItems.Rows)
            {
                if (row != null && row.Tag != null)
                {
                    int quantity = Convert.ToInt32(row.Cells[3].Value);

                    if (quantity > 0)
                    {
                        POSGridItemInfo itemInfo = row.Tag as POSGridItemInfo;

                        if (itemInfo.POSItem == null)
                        {
                            refunds.Add(itemInfo.POSRefund);
                        }
                        else
                        {
                            int discount = Convert.ToInt32(row.Cells[4].Value);
                            POSBillItemInfo billItem = POSFactory.CreateOrUpdatePOSBillItemInfo(null, itemInfo.POSItem, itemInfo.Rate, quantity, discount);

                            //POSStatusCodes result = POSDbUtility.AddPOSBillItemInfo(billItem, ref errorMsg, true);

                            //if (result == POSStatusCodes.Success)
                            //{
                                billItems.Add(billItem);
                            //}
                            
                        }

                       
                    }


                }
            }

            if (billItems.Count == 0 && refunds.Count == 0)
            {
                errorMsg = "Please add some quantity in items.";
                return POSStatusCodes.Aborted;
            }

            POSBillInfo billInfo = POSFactory.CreateOrUpdatePOSBillInfo(posBill, billItems, refunds, amountPayed, billCanceled, billPayed, appUser, salesMan);
            POSStatusCodes status = POSStatusCodes.Failed;

            if (posBill == null)
            {
                status = POSDbUtility.AddPOSBillInfo(billInfo, ref errorMsg, true);

                if (status == POSStatusCodes.Success)
                {
                    this.mBillInfo = billInfo;
                    //set barcode.
                    if (!billPayed)
                    {
                        Barcode barcode = new Barcode();
                        barcode.Alignment = AlignmentPositions.CENTER;
                        barcode.Height = 60;
                        barcode.Width = 216;
                        barcode.IncludeLabel = true;

                        this.pbxBarcode.Image = barcode.Encode(TYPE.CODE128, billInfo.Barcode);
                    }
                }
            }
            else
            {
                status = POSDbUtility.UpdatePOSBillInfo(billInfo, ref errorMsg, true);
            }

            if (status == POSStatusCodes.Success)
            {
                this.mBillInfo = billInfo;

                if (billPayed)
                {
                    int count = this.mBillInfo.BillItems.Count;
                    int i = 0;

                    foreach (POSRefundInfo refund in this.mBillInfo.Refunds)
                    {
                        if (!refund.Refunded)
                        {
                            refund.Refunded = true;

                            status = POSDbUtility.UpdatePOSRefundInfo(refund, ref errorMsg, count == 0);

                            if (status != POSStatusCodes.Success)
                            {
                                MessageBox.Show(this, "Failed to update Refund Info.\n\n" + errorMsg);
                            }
                        }
                    }

                    foreach (POSBillItemInfo billItem in this.mBillInfo.BillItems)
                    {
                        billItem.PosItem1.TotalItemsSold += billItem.Quantity;

                        errorMsg = string.Empty;

                        status = POSDbUtility.UpdatePOSItem(billItem.PosItem1, ref errorMsg, i == count - 1);

                        if (status != POSStatusCodes.Success)
                        {
                            MessageBox.Show(this, "Failed to update total number of sold items.\n\n" + errorMsg);
                        }

                        i++;
                    }

                    if (status == POSStatusCodes.Success)
                    {
                        Barcode barcode = new Barcode();
                        barcode.Alignment = AlignmentPositions.CENTER;
                        barcode.Height = 60;
                        barcode.Width = 216;
                        barcode.IncludeLabel = true;

                        this.pbxBarcode.Image = barcode.Encode(TYPE.CODE128, billInfo.Barcode);
                    }
                }                
                
            }

            return status;
        }

        private void btnCancelBill_Click(object sender, EventArgs e)
        {
            this.CancelBill();

            this.Close();

        }

        private void CancelBill()
        {
            if (this.mBillInfo != null)
            {
                POSFactory.CreateOrUpdatePOSBillInfo(this.mBillInfo, this.mBillInfo.BillItems, this.mBillInfo.Refunds, this.mBillInfo.AmountPaid, true, false, this.mBillInfo.AppUser, this.mBillInfo.SalesMan);
                string errorMsg = string.Empty;

                POSStatusCodes status = POSDbUtility.UpdatePOSBillInfo(this.mBillInfo, ref errorMsg, true);

                if (status != POSStatusCodes.Success)
                {
                    MessageBox.Show(this, "Some error occured in canceling bill.\n\n" + errorMsg);
                }
            }
        }

        private void btnPayBill_Click(object sender, EventArgs e)
        {
            var ls = POSDbUtility.GetAllPOSBillInfo();
            int amountPaid = string.IsNullOrEmpty(this.tbxAmountPaid.Text) ? 0 : Convert.ToInt32(this.tbxAmountPaid.Text);
            int balance = string.IsNullOrEmpty(this.lblBalance.Text) ? 0 : Convert.ToInt32(this.lblBalance.Text);
            int totalPrice = string.IsNullOrEmpty(this.lblTotal.Text) ? 0 : Convert.ToInt32(this.lblTotal.Text);

            if (amountPaid < totalPrice)
            {
                MessageBox.Show(this, "Ammount paid is less than total price.");
                return;
            }

            if (balance < 0)
            {
                MessageBox.Show(this, "Ammount paid is less than the total amount.");
                return;
            }

            string errorMsg = string.Empty;

            POSStatusCodes status = SaveBill(this.mBillInfo, amountPaid, true, false, ref errorMsg);

            if(status == POSStatusCodes.Failed)
            {
                MessageBox.Show(this, "Some error occured in saving bill.\n\n" + errorMsg);
                return;
            }
            else if (status == POSStatusCodes.Aborted)
            {
                MessageBox.Show(this, errorMsg);
                return;
            }

            //print bill
            printDocument1.PrinterSettings.PrinterName = "BlackCopper 80mm Series";
            printDocument1.Print();
        }

        private void PrintBill(Graphics graphic)
        {
            try
            {
                int pixY = 0;

                SystemSettings systemSettings = POSDbUtility.GetAllSystemSettings().FirstOrDefault();

                if (systemSettings != null)
                {
                    POSComonUtility.DrawShopInfo(graphic, systemSettings.ShopName, systemSettings.ShopAddress, systemSettings.ShopContact, ref pixY);
                }


                POSComonUtility.DrawSalesReceiptInfo(graphic, "Sales Receipt", this.mBillInfo.Barcode, this.mBillInfo.BillCreatedDate, this.mBillInfo.AppUser.Name, ref pixY);

                POSComonUtility.DrawItemsHeaders(graphic, ref pixY);

                Dictionary<string, List<POSBillItemInfo>> billItems = new Dictionary<string, List<POSBillItemInfo>>();

                foreach (POSBillItemInfo item in this.mBillInfo.BillItems)
                {
                    if (item != null)
                    {
                        string categoryName = item.PosItem1.CategoryName;

                        List<POSBillItemInfo> items = null;

                        if (billItems.ContainsKey(categoryName))
                        {
                            items = billItems[categoryName];
                            items.Add(item);
                        }
                        else
                        {
                            items = new List<POSBillItemInfo>();
                            items.Add(item);
                            billItems.Add(categoryName, items);
                        }
                    }
                }

                foreach (KeyValuePair<string, List<POSBillItemInfo>> keyValue in billItems)
                {
                    POSComonUtility.DrawCategoryRow(graphic, keyValue.Key, ref pixY);

                    List<POSBillItemInfo> items = keyValue.Value;

                    foreach (POSBillItemInfo billItem in items)
                    {
                        POSComonUtility.DrawPOSItemInfo(graphic, billItem.Quantity.ToString(), billItem.PosItem1.Name, billItem.PosItem1.Barcode, billItem.Rate.ToString(), billItem.Discount.ToString(), billItem.Total.ToString(), ref pixY);
                    }
                }

                if (this.mBillInfo.Refunds != null && this.mBillInfo.Refunds.Count > 0)
                {
                    POSComonUtility.DrawCategoryRow(graphic, "Refund Slip(s)", ref pixY);

                    foreach (POSRefundInfo refund in this.mBillInfo.Refunds)
                    {
                        POSComonUtility.DrawPOSItemInfo(graphic, refund.Quantity.ToString(), refund.Name, refund.Barcode, refund.Rate.ToString(), refund.Discount.ToString(), refund.Rate.ToString(), ref pixY);
                    }
                }


                POSComonUtility.DrawBillInfo(graphic, "No. of item(s) = " + this.mBillInfo.TotalItems, "Total quantity = " + this.mBillInfo.TotalQuantity, this.mBillInfo.TotalGross.ToString(), this.mBillInfo.TotalDiscount.ToString(), this.mBillInfo.TotalAmount.ToString(), this.mBillInfo.AmountPaid.ToString(), this.mBillInfo.AmountReturned.ToString(), ref pixY);

                POSComonUtility.DrawBarcode(graphic, this.mBillInfo.Barcode, ref pixY);

                POSComonUtility.DrawBillEndingInfo(graphic, systemSettings, false, ref pixY);

                graphic.Save();
            }
            catch (Exception e)
            {
                string errorMsg = POSComonUtility.GetInnerExceptionMessage(e);

                MessageBox.Show(this, "Some error occurred in printing bill./n/n" + errorMsg);
            }

            this.Close();
            
        }

        private void PointOfSaleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.CancelBill();            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics graphic = e.Graphics;           

            this.PrintBill(graphic);            
        }

        #region IScanable

        public void OnBarcodeScannerRead(string barcode)
        {
            barcode = barcode.Replace("\0", string.Empty);
            List<POSGridItemInfo> searchedItems = POSComonUtility.SearchItem(barcode, this);

            if (searchedItems == null || searchedItems.Count == 0 || searchedItems[0] == null)
            {
                MessageBox.Show(this, "Unable to find any product with barcode: " + barcode);
                return;
            }

            POSGridItemInfo itemInfo = searchedItems[0];

            if (itemInfo.RemaningQuantity == 0)
            {
                MessageBox.Show(this, "Searched item stock is finished.");
            }
            else
            {
                itemInfo.Quantity += 1;

                this.mItems.AddRange(searchedItems);

                this.bsPOSGridItemInfo.DataSource = null;
                this.bsPOSGridItemInfo.DataSource = this.mItems;



                DataGridViewRow row = this.dgvPOSItems.Rows[this.dgvPOSItems.Rows.Count - 1];

                this.dgvPOSItems.ClearSelection();
                row.Selected = true;
                this.UpdateBillInfo();
            }

            
        }



        #endregion

        private void dgvPOSItems_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            POSGridItemInfo deletingItem = e.Row.Tag as POSGridItemInfo;

            if (deletingItem != null)
            {
                bool deleted = this.mItems.Remove(deletingItem);

                if (deleted)
                {
                    this.UpdateBillInfo();
                }
            }            
        }
    }
}
