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
    public partial class POSRefundForm : Form, IScanable
    {
        private List<POSSalesMan> mSalesMans;
        private List<POSItemInfo> mItems = new List<POSItemInfo>();
        private POSBillInfo mBillInfo = null;
        private POSRefundInfo mRefund = null;


        public POSRefundForm()
        {
            InitializeComponent();
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

        private void btnOpenBill_Click(object sender, EventArgs e)
        {
            string itemName = this.tbxItemName.Text;

            this.OpenBill(itemName);            
        }

        private void OpenBill(string itemName)
        {
            List<POSBillInfo> bills = POSDbUtility.GetAllPOSBillInfo();

            itemName = itemName.Replace("\0", string.Empty);

            POSBillInfo billInfo = bills.Find(bill => bill.Barcode == itemName);

            if (billInfo == null)
            {
                MessageBox.Show("Bill with barcode: " + itemName + " is not found.");
                return;
            }
            else
            {
                if (billInfo.BillCanceled)
                {
                    MessageBox.Show("Bill with barcode: " + itemName + " is canceled bill.");
                    return;
                }

                if (billInfo.BillPayed)
                {
                    this.mBillInfo = billInfo;

                    List<POSItemInfo> items = new List<POSItemInfo>();

                    foreach (POSBillItemInfo billItem in this.mBillInfo.BillItems)
                    {
                        if (billItem != null)
                        {
                            POSItemInfo itemInfo = billItem.PosItem1;

                            itemInfo.OrderQuantity = billItem.Quantity;
                            itemInfo.Discount = billItem.Discount;

                            items.Add(itemInfo);
                        }
                    }

                    this.mItems = items;

                    this.bsPosItemInfo.DataSource = null;
                    this.bsPosItemInfo.DataSource = items;

                    this.UpdateBillInfo();
                }
                else
                {
                    MessageBox.Show("Bill with barcode: " + itemName + " is unpaid bill.");
                }
            }
        }

        private void UpdateBillInfo()
        {            
            int totalDiscount = 0;
            int totalPrice = 0;

            foreach (POSItemInfo item in this.mItems)
            {
                if (item == null)
                {
                    continue;
                }
                else
                {
                    totalDiscount += item.DiscountPrice;
                    totalPrice += item.OrderTotal;
                }
            }

            this.lblItemsCount.Text = this.mItems.Count.ToString();
            this.lblTotal.Text = totalPrice.ToString();
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

            POSItemInfo itemInfo = this.dgvPOSItems.SelectedRows[0].Tag as POSItemInfo;

            this.pbxProductImage.Image = itemInfo.Image;
        }

        private void dgvPOSItems_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 1 ||
                e.ColumnIndex == 2 || 
                e.ColumnIndex == 3 ||
                e.ColumnIndex == 4 || 
                e.ColumnIndex == 6)
            {
                e.Cancel = true;
                return;
            }
        }
        

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.R))
            {
                this.btnRefund.PerformClick();
                return true;
            }

            if (keyData == (Keys.Control | Keys.P))
            {
                this.btnPrintRefundSlip.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnRefund_Click(object sender, EventArgs e)
        {
            this.RefundCore(true, true);
        }

        private void RefundCore(bool refunded, bool print)
        {
            if (this.dgvPOSItems.Rows == null || this.dgvPOSItems.Rows.Count == 0)
            {
                MessageBox.Show(this, "Please open any bill.");
                return;
            }

            List<DataGridViewRow> checkedRows = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in this.dgvPOSItems.Rows)
            {
                if (row == null || !Convert.ToBoolean(row.Cells[0].Value))
                {
                    continue;
                }

                checkedRows.Add(row);
            }

            if (checkedRows.Count == 0)
            {
                MessageBox.Show(this, "Please check any item to refund.");
                return;
            }

            List<POSRefundItemInfo> refundItems = new List<POSRefundItemInfo>();

            foreach (DataGridViewRow row in checkedRows)
            {
                int refundQuantity = Convert.ToInt32(row.Cells[5].Value);

                if (refundQuantity > 0)
                {
                    POSItemInfo itemInfo = row.Tag as POSItemInfo;

                    POSBillItemInfo billItemInfo = this.mBillInfo.BillItems.Find(item => item.PosItemId == itemInfo.Id);

                    POSRefundItemInfo refundItem = POSFactory.CreateOrUpdatePOSRefundItemInfo(null, billItemInfo, refundQuantity);

                    refundItems.Add(refundItem);
                }
            }

            if (refundItems.Count == 0)
            {
                MessageBox.Show(this, "Please enter some refund quantity.");
            }
            else
            {
                POSRefundInfo refundInfo = POSFactory.CreateOrUpdatePOSRefundInfo(null, refundItems, this.mBillInfo, refunded, DateTime.Now, LoginForm.mLoggedInUser);

                string errorMsg = string.Empty;

                POSStatusCodes status = POSDbUtility.AddPOSRefundInfo(refundInfo, ref errorMsg, !refunded);

                if (refunded)
                {
                    int count = refundItems.Count;
                    int i = 0;

                    foreach (POSRefundItemInfo refundItem in refundItems)
                    {
                        POSBillItemInfo billItemInfo = this.mBillInfo.BillItems.Find(item => item.Id == refundItem.BillItemInfo.Id);

                        billItemInfo.PosItem1.TotalItemsSold -= refundItem.Quantity;

                        errorMsg = string.Empty;

                        status = POSDbUtility.UpdatePOSItem(billItemInfo.PosItem1, ref errorMsg, i == count - 1);

                        if (status != POSStatusCodes.Success)
                        {
                            MessageBox.Show(this, "Failed to update total number of sold items.");
                        }

                        i++;
                    }
                }                

                if (status == POSStatusCodes.Success)
                {
                    this.mRefund = refundInfo;
                    if (print)
                    {
                        //Print
                        printDocument1.PrinterSettings.PrinterName = "BlackCopper 80mm Series";
                        printDocument1.Print();
                    }
                }
                else
                {
                    MessageBox.Show(this, "Some error occured in refunding Items.\n\n" + errorMsg);
                }
            }
        }

        private void btnPrintRefundSlip_Click(object sender, EventArgs e)
        {
            this.RefundCore(false, true);
        }

        private void PrintRefundSlip(Graphics graphic)
        {
            int pixY = 0;

            SystemSettings systemSettings = POSDbUtility.GetAllSystemSettings().FirstOrDefault();

            if (systemSettings != null)
            {
                POSComonUtility.DrawShopInfo(graphic, systemSettings.ShopName, systemSettings.ShopAddress, systemSettings.ShopContact, ref pixY);
            }

            POSComonUtility.DrawRefundReceiptInfo(graphic, "Refund Slip", this.mRefund.Barcode, this.mBillInfo.Barcode, this.mRefund.RefundDate, this.mBillInfo.AppUser.Name, this.mRefund.Refunded, ref pixY);

            POSComonUtility.DrawItemsHeaders(graphic, ref pixY);

            POSComonUtility.DrawCategoryRow(graphic, "Refund(s)", ref pixY);

            foreach (POSRefundItemInfo refund in this.mRefund.RefundItems)
            {
                POSComonUtility.DrawPOSItemInfo(graphic, refund.Quantity.ToString(), refund.Name, refund.Barcode, refund.Rate.ToString(), refund.Discount.ToString(), refund.Total.ToString(), ref pixY);
            }

            POSComonUtility.DrawRefundBillInfo(graphic, "No. of item(s) = " + this.mRefund.TotalItems, "Total quantity = " + this.mRefund.TotalQuantity,  this.mRefund.Total.ToString(),  ref pixY);

            POSComonUtility.DrawBarcode(graphic, this.mRefund.Barcode, ref pixY);

            POSComonUtility.DrawBillEndingInfo(graphic, systemSettings, true, ref pixY);

            graphic.Save();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            PrintRefundSlip(e.Graphics);
        }

        #region IScanable

        public void OnBarcodeScannerRead(string barcode)
        {
            if (this.mBillInfo == null)
            {
                this.OpenBill(barcode);
            }
        }

        #endregion
    }
}
