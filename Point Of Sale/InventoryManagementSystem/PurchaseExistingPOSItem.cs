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

namespace InventoryManagementSystem
{
    public partial class PurchaseExistingPOSItem : Form
    {
        private POSItemInfo mPosItemInfo;

        public PurchaseExistingPOSItem(POSItemInfo posItemInfo)
        {
            this.mPosItemInfo = posItemInfo;

            InitializeComponent();

            this.tbxOldBuyingPrice.Text = this.mPosItemInfo.BuyingPrice.ToString();
            this.tbxNewBuyingPrice.Text = this.mPosItemInfo.BuyingPrice.ToString();
            this.tbxOldItemsCount.Text = this.mPosItemInfo.TotalItemsPurchased.ToString();
            this.tbxItemsCount.Text = "0";
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            int oldItemsCount = Convert.ToInt32(this.tbxOldItemsCount.Text);
            int itemsCount = Convert.ToInt32(this.tbxItemsCount.Text);
            int oldBuyingPrice = Convert.ToInt32(this.tbxOldBuyingPrice.Text);
            int newBuyingPrice = Convert.ToInt32(this.tbxNewBuyingPrice.Text);

            if (newBuyingPrice <= 0)
            {
                MessageBox.Show(this, "Buying price can not be less than or equal to zero.");
                return;
            }

            if (itemsCount <= 0)
            {
                MessageBox.Show(this, "Items Count can not be less than or equal to zero.");
                return;
            }

            POSFactory.CreateOrUpdatePOSItemInfo(this.mPosItemInfo, this.mPosItemInfo.Name, this.mPosItemInfo.ShortName, newBuyingPrice, this.mPosItemInfo.SellingPrice, this.mPosItemInfo.Description, this.mPosItemInfo.Discount, this.mPosItemInfo.DiscountInPercent, this.mPosItemInfo.ImageContent, itemsCount + oldItemsCount, this.mPosItemInfo.Category, this.mPosItemInfo.Type, this.mPosItemInfo.Vendor);

            if (this.mPosItemInfo != null)
            {
                string errorMsg = string.Empty;
                POSItemTransactionItem transactionItem = POSFactory.CreatePOSItemTransactionItem(this.mPosItemInfo, true, itemsCount, newBuyingPrice);

                if (transactionItem != null)
                {
                    this.mPosItemInfo.Transactions.Add(transactionItem);
                }

                Cursor currentCursor = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;

                POSStatusCodes status = POSDbUtility.UpdatePOSItem(this.mPosItemInfo, ref errorMsg, true);

                Cursor.Current = currentCursor;
                if (status == POSStatusCodes.Success)
                {
                    MessageBox.Show(this, "Item has been updated successfully.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show(this, "Some error occured in updating item.\n\n" + errorMsg);
                }
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            int oldItemsCount = Convert.ToInt32(this.tbxOldItemsCount.Text);
            int itemsCount = Convert.ToInt32(this.tbxItemsCount.Text);
            int oldBuyingPrice = Convert.ToInt32(this.tbxOldBuyingPrice.Text);
            int newBuyingPrice = Convert.ToInt32(this.tbxNewBuyingPrice.Text);
            int remainingItemsCount = this.mPosItemInfo.GetRemaningQuantity();

            if (newBuyingPrice != oldBuyingPrice)
            {
                MessageBox.Show(this, "Buying price can not be changed while returning.");
                return;
            }

            if (itemsCount <= 0)
            {
                MessageBox.Show(this, "Items Count can not be less than or equal to zero.");
                return;
            }

            if (itemsCount > remainingItemsCount)
            {
                MessageBox.Show(this, "Items Count can not be greater than remaining items count.");
                return;
            }

            POSFactory.CreateOrUpdatePOSItemInfo(this.mPosItemInfo, this.mPosItemInfo.Name, this.mPosItemInfo.ShortName, newBuyingPrice, this.mPosItemInfo.SellingPrice, this.mPosItemInfo.Description, this.mPosItemInfo.Discount, this.mPosItemInfo.DiscountInPercent, this.mPosItemInfo.ImageContent, oldItemsCount - itemsCount, this.mPosItemInfo.Category, this.mPosItemInfo.Type, this.mPosItemInfo.Vendor);

            if (this.mPosItemInfo != null)
            {
                string errorMsg = string.Empty;
                POSItemTransactionItem transactionItem = POSFactory.CreatePOSItemTransactionItem(this.mPosItemInfo, false, itemsCount, newBuyingPrice);

                if (transactionItem != null)
                {
                    this.mPosItemInfo.Transactions.Add(transactionItem);
                }

                Cursor currentCursor = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;

                POSStatusCodes status = POSDbUtility.UpdatePOSItem(this.mPosItemInfo, ref errorMsg, true);

                Cursor.Current = currentCursor;
                if (status == POSStatusCodes.Success)
                {
                    MessageBox.Show(this, "Item has been updated successfully.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show(this, "Some error occured in updating item.\n\n" + errorMsg);
                }
            }
        }

        private void tbxNewBuyingPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            POSComonUtility.AllowNumericOnly(e);
        }
    }
}
