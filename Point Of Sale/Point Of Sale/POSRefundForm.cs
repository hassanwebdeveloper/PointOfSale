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

namespace Point_Of_Sale
{
    public partial class POSRefundForm : Form, IScanable
    {
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
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                itemName = itemName.Replace("\0", string.Empty);

                List<POSBillInfo> bills = POSDbUtility.GetAllPOSBillInfo(itemName);

                if (bills == null || bills.Count == 0 || bills[0] == null)
                {
                    Cursor.Current = currentCursor;
                    MessageBox.Show("Bill with barcode: " + itemName + " is not found.");
                    return;
                }
                else
                {
                    POSBillInfo billInfo = bills[0];

                    if (billInfo.BillCanceled)
                    {
                        Cursor.Current = currentCursor;
                        MessageBox.Show("Bill with barcode: " + itemName + " is canceled bill.");
                        return;
                    }

                    if (billInfo.BillPayed)
                    {
                        if (billInfo.BillItems == null)
                        {
                            Cursor.Current = currentCursor;
                            MessageBox.Show("Some error occured in opening bill to refund.\n\n Please close window and try again.");
                            return;
                        }

                        this.mBillInfo = billInfo;

                        List<POSItemInfo> items = new List<POSItemInfo>();
                        Dictionary<int, int> billQuantity = new Dictionary<int, int>();

                        List<POSRefundInfo> refunds = this.mBillInfo.Refunds;

                        foreach (POSBillItemInfo billItem in this.mBillInfo.BillItems)
                        {
                            
                            if (billItem != null)
                            {
                                int quantity = billItem.Quantity;
                                POSItemInfo itemInfo = billItem.PosItem1;

                                foreach (POSRefundInfo posRefund in refunds)
                                {
                                    if (posRefund != null && posRefund.RefundItems != null)
                                    {
                                        foreach (POSRefundItemInfo posRefundItem in posRefund.RefundItems)
                                        {
                                            if (posRefundItem.BillItemInfoId == billItem.Id)
                                            {
                                                quantity -= posRefundItem.Quantity;
                                            }
                                        }
                                    }
                                }

                                //itemInfo.OrderQuantity = billItem.Quantity;
                                billQuantity.Add(itemInfo.Id, quantity);
                                itemInfo.Discount = billItem.Discount;

                                items.Add(itemInfo);
                            }
                        }

                        this.mItems = items;

                        this.bsPosItemInfo.DataSource = null;
                        this.bsPosItemInfo.DataSource = items;

                        foreach (DataGridViewRow row in this.dgvPOSItems.Rows)
                        {
                            if (row != null && row.Tag is POSItemInfo)
                            {
                                int id = (row.Tag as POSItemInfo).Id;
                                int count = billQuantity[id];

                                row.Cells[4].Value = count;
                                row.Cells[5].Value = 0;
                            }
                        }

                        this.UpdateBillInfo();
                    }
                    else
                    {
                        Cursor.Current = currentCursor;
                        MessageBox.Show("Bill with barcode: " + itemName + " is unpaid bill.");
                    }
                }
            }
            catch (Exception e)
            {
                string errorMsg = POSComonUtility.GetInnerExceptionMessage(e);
                Cursor.Current = currentCursor;
                MessageBox.Show(this, "Some error occured in fetching Bills.\n\n" + errorMsg);
            }

            Cursor.Current = currentCursor;
        }

        private void UpdateBillInfo()
        {
            int totalPrice = 0, totalRefundQuantity = 0;

            List<DataGridViewRow> checkedRows = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in this.dgvPOSItems.Rows)
            {
                if (row == null || !Convert.ToBoolean(row.Cells[0].Value))
                {
                    continue;
                }

                checkedRows.Add(row);
            }


            foreach (DataGridViewRow row in checkedRows)
            {
                if (row != null && row.Tag is POSItemInfo)
                {
                    int refundQuantity = Convert.ToInt32(row.Cells[5].Value);

                    if (refundQuantity > 0)
                    {
                        POSItemInfo itemInfo = row.Tag as POSItemInfo;

                        POSBillItemInfo billItem = this.mBillInfo.BillItems.Find(it => it.PosItemId == itemInfo.Id);

                        if (billItem != null)
                        {
                            totalRefundQuantity += refundQuantity;
                            totalPrice += (billItem.Rate - billItem.Discount) * refundQuantity;
                        }
                    }
                }

            }

            //foreach (POSItemInfo item in this.mItems)
            //{
            //    if (item == null)
            //    {
            //        continue;
            //    }
            //    else
            //    {

            //        totalDiscount += item.DiscountPrice;
            //        totalPrice += item.OrderTotal;
            //    }
            //}

            this.lblItemsCount.Text = totalRefundQuantity.ToString();
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
                if (row != null && row.Tag is POSItemInfo)
                {
                    int refundQuantity = Convert.ToInt32(row.Cells[5].Value);

                    if (refundQuantity > 0)
                    {
                        POSItemInfo itemInfo = row.Tag as POSItemInfo;

                        POSBillItemInfo billItemInfo = this.mBillInfo.BillItems.Find(item => item.PosItemId == itemInfo.Id);

                        if (billItemInfo != null)
                        {
                            POSRefundItemInfo refundItem = POSFactory.CreateOrUpdatePOSRefundItemInfo(null, billItemInfo, refundQuantity);

                            refundItems.Add(refundItem);
                        }


                    }
                }
            }

            if (refundItems.Count == 0)
            {
                MessageBox.Show(this, "Please enter some refund quantity.");
            }
            else
            {
                Cursor currentCursor = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;

                POSRefundInfo refundInfo = POSFactory.CreateOrUpdatePOSRefundInfo(null, refundItems, this.mBillInfo, refunded, !refunded, DateTime.Now, LoginForm.mLoggedInUser);

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
                            Cursor.Current = currentCursor;
                            MessageBox.Show(this, "Failed to update total number of sold items.");
                        }

                        i++;
                    }
                }

                if (status == POSStatusCodes.Success)
                {
                    Cursor.Current = currentCursor;
                    this.mRefund = refundInfo;
                    if (print)
                    {
                        //Print
                        string billPrinterName = ConfigurationManager.AppSettings["BillPrinterName"];

                        printDocument1.PrinterSettings.PrinterName = billPrinterName;
                        printDocument1.Print();
                    }
                }
                else
                {
                    Cursor.Current = currentCursor;
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
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                int pixY = 0;

                List<SystemSettings> settings = POSDbUtility.GetAllSystemSettings();

                SystemSettings systemSettings = null;

                if (settings != null && settings.Count > 0)
                {
                    systemSettings = settings.FirstOrDefault();
                }

                if (systemSettings != null)
                {
                    POSComonUtility.DrawShopInfo(graphic, systemSettings.ShopName, systemSettings.ShopAddress, systemSettings.ShopContact, ref pixY, addLogo: true, form: this);
                }

                POSComonUtility.DrawRefundReceiptInfo(graphic, "Refund Slip", this.mRefund.Barcode, this.mBillInfo.Barcode, this.mRefund.RefundDate, this.mBillInfo.AppUser.Name, this.mRefund.Refunded, ref pixY);

                POSComonUtility.DrawItemsHeaders(graphic, ref pixY);

                POSComonUtility.DrawCategoryRow(graphic, "Refund(s)", ref pixY);

                foreach (POSRefundItemInfo refund in this.mRefund.RefundItems)
                {
                    POSComonUtility.DrawPOSItemInfo(graphic, refund.Quantity.ToString(), refund.Name, refund.Barcode, refund.Rate.ToString(), refund.Discount.ToString(), refund.Total.ToString(), ref pixY);
                }

                POSComonUtility.DrawRefundBillInfo(graphic, "No. of item(s) = " + this.mRefund.TotalItems, "Total quantity = " + this.mRefund.TotalQuantity, this.mRefund.Total.ToString(), ref pixY);

                POSComonUtility.DrawBarcode(graphic, this.mRefund.Barcode, ref pixY);

                POSComonUtility.DrawBillEndingInfo(graphic, systemSettings, true, ref pixY);

                graphic.Save();
            }
            catch (Exception e)
            {
                Cursor.Current = currentCursor;
                string errorMsg = POSComonUtility.GetInnerExceptionMessage(e);

                MessageBox.Show(this, "Some error occurred in printing bill./n/n" + errorMsg);
            }

            Cursor.Current = currentCursor;
            this.Close();
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

        private void dgvPOSItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                if (this.dgvPOSItems.Rows[e.RowIndex].Cells[5].Value != null)
                {
                    if (POSComonUtility.IsDigitsOnly(Convert.ToString(this.dgvPOSItems.Rows[e.RowIndex].Cells[5].Value)))
                    {
                        int refundCount = Convert.ToInt32(this.dgvPOSItems.Rows[e.RowIndex].Cells[5].Value);
                        if (refundCount > 0)
                        {
                            int quantity = Convert.ToInt32(this.dgvPOSItems.Rows[e.RowIndex].Cells[4].Value);

                            if (quantity < refundCount)
                            {
                                MessageBox.Show(this, "Refund Items can not be greater than quantity.");

                                this.dgvPOSItems.Rows[e.RowIndex].Cells[5].Value = quantity;
                            }
                            else
                            {
                                this.dgvPOSItems.Rows[e.RowIndex].Cells[0].Value = true;
                            }
                            
                        }
                        else
                        {
                            this.dgvPOSItems.Rows[e.RowIndex].Cells[0].Value = false;
                        }
                    }
                    else
                    {
                        this.dgvPOSItems.CancelEdit();

                        MessageBox.Show(this, "Please enter only numbers.");
                    }

                }
                else
                {
                    this.dgvPOSItems.Rows[e.RowIndex].Cells[0].Value = false;
                }

                this.UpdateBillInfo();
            }
        }

        private void dgvPOSItems_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(NumericColumn_KeyPress);
            if (this.dgvPOSItems.CurrentCell.ColumnIndex == 5) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(NumericColumn_KeyPress);
                }
            }
        }

        private void NumericColumn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !POSComonUtility.IsDigitsOnly(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }
    }
}
