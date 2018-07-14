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
    public partial class POSItemInfoForm : Form
    {
        List<VendorInfo> mVendors = null;
        List<POSItemCategory> mCategories = null;
        List<POSItemType> mTypes = null;
        List<POSItemInfo> mItems = new List<POSItemInfo>();
        POSItemInfo mItemToUpdate = null;
        bool mImageIsUpdated = false;

        string CONST_UPDATE_TEXT = "&Update Changes";
        string CONST_ADD_ITEM_TEXT = "&Add Item";
        string CONST_DDP_TYPE_CATEGORY = "Category";
        string CONST_DDP_TYPE_TYPE = "Type";

        public POSItemInfoForm()
        {
            InitializeComponent();

            PopulateDropDownFields();

            this.nudDiscount.Maximum = decimal.MaxValue;
            this.nudItemsCount.Maximum = decimal.MaxValue;
            this.tbxItemName.Focus();
        }

        public POSItemInfoForm(POSItemInfo itemToUpdate)
        {
            this.mItemToUpdate = itemToUpdate;

            InitializeComponent();

            this.nudDiscount.Maximum = decimal.MaxValue;
            this.nudItemsCount.Maximum = decimal.MaxValue;

            PopulateDropDownFields();

            PopulatePOSItemInfo(itemToUpdate);

            this.btnAddItem.Tag = itemToUpdate;

            this.UpdateLayout(true);

            this.tbxItemName.Focus();

            this.tbxShortName.Enabled = false;
        }

        public POSItemInfoForm(DataGridViewRow rowToUpdate)
        {
            POSItemInfo itemToUpdate = rowToUpdate.Tag as POSItemInfo;

            this.mItemToUpdate = itemToUpdate;

            InitializeComponent();

            this.nudDiscount.Maximum = decimal.MaxValue;
            this.nudItemsCount.Maximum = decimal.MaxValue;

            PopulateDropDownFields();

            PopulatePOSItemInfo(itemToUpdate);

            this.btnAddItem.Tag = rowToUpdate;

            this.UpdateLayout(false);

            this.tbxItemName.Focus();
        }

        #region Events

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            //Mandatory Values Check

            string name = this.tbxItemName.Text;
            string shortName = this.tbxShortName.Text;
            string description = this.tbxDescription.Text;

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show(this, "Please enter item name.");
                return;
            }

            if (string.IsNullOrEmpty(shortName))
            {
                MessageBox.Show(this, "Please enter item short name.");
                return;
            }

            if (this.mVendors == null || this.mVendors.Count == 0 || this.cbxVendor.SelectedIndex < 0)
            {
                MessageBox.Show(this, "Please select any vendor to add item.");
                return;
            }

            VendorInfo vendor = this.mVendors[this.cbxVendor.SelectedIndex];
            POSItemCategory category = null;

            if (this.mCategories == null || this.mCategories.Count == 0 || this.cbxItemCategory.SelectedIndex < 0)
            {
                MessageBox.Show(this, "Please select any category to add item.");
            }
            else
            {
                category = this.mCategories[this.cbxItemCategory.SelectedIndex];
            }          
             
            POSItemType type = null;

            if (this.mTypes == null || this.mTypes.Count == 0 || this.cbxItemType.SelectedIndex < 0)
            {
                MessageBox.Show(this, "Please select any type to add item.");
            }
            else
            {
                type = this.mTypes[this.cbxItemType.SelectedIndex];
            }

            if (string.IsNullOrEmpty(this.tbxBuyingPrice.Text))
            {
                MessageBox.Show(this, "Please enter Buying price.");
                return;
            }

            if (string.IsNullOrEmpty(this.tbxSellingPrice.Text))
            {
                MessageBox.Show(this, "Please enter Selling price.");
                return;
            }            

            int buyingPrice = Convert.ToInt32(this.tbxBuyingPrice.Text);
            int sellingPrice = Convert.ToInt32(this.tbxSellingPrice.Text);
            int discount = Convert.ToInt32(this.nudDiscount.Value);
            int itemsCount = Convert.ToInt32(this.nudItemsCount.Value);

            if (itemsCount <= 0)
            {
                MessageBox.Show(this, "Please enter items count");
                return;
            }

            if (buyingPrice <= 0)
            {
                MessageBox.Show(this, "Please enter buying price");
                return;
            }

            if (sellingPrice <= 0)
            {
                MessageBox.Show(this, "Please enter selling price");
                return;
            }

            if (sellingPrice < buyingPrice)
            {
                DialogResult diaglogResult = MessageBox.Show(this, "Selling price is less than buying price.\n\nDo you want to continue?", "Confirmation Dialog", MessageBoxButtons.YesNo);

                if (diaglogResult == DialogResult.No)
                {
                    return;
                }
            }

            bool discountInPercent = this.chbDiscountInPercent.Checked;

            if (discountInPercent)
            {
                if (discount == 100)
                {
                    DialogResult diaglogResult = MessageBox.Show(this, "Are you sure you want to set 100% discount?", "Confirmation Dialog", MessageBoxButtons.YesNo);

                    if (diaglogResult == DialogResult.No)
                    {
                        return;
                    }
                }
            }
            else
            {
                if (discount >= sellingPrice)
                {
                    DialogResult diaglogResult = MessageBox.Show(this, "Discounted ammount exceeds your selling price.\n\nDo you want to continue?", "Confirmation Dialog", MessageBoxButtons.YesNo);

                    if (diaglogResult == DialogResult.No)
                    {
                        return;
                    }
                }
                else
                {
                    if (discount >= buyingPrice)
                    {
                        DialogResult diaglogResult = MessageBox.Show(this, "Discounted ammount exceeds your buying price.\n\nDo you want to continue?", "Confirmation Dialog", MessageBoxButtons.YesNo);

                        if (diaglogResult == DialogResult.No)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (discount >= (sellingPrice - buyingPrice))
                        {
                            DialogResult diaglogResult = MessageBox.Show(this, "Discounted ammount exceeds your profit.\n\nDo you want to continue?", "Confirmation Dialog", MessageBoxButtons.YesNo);

                            if (diaglogResult == DialogResult.No)
                            {
                                return;
                            }
                        }
                    }
                }
            }      

            if (this.btnAddItem.Text == CONST_UPDATE_TEXT)
            {
                if (this.btnAddItem.Tag == null || (!(this.btnAddItem.Tag is POSItemInfo) && !(this.btnAddItem.Tag is DataGridViewRow && (this.btnAddItem.Tag as DataGridViewRow).Tag is POSItemInfo)))
                {
                    MessageBox.Show(this, "There is some error occured in update close the window and try again.");
                    return;
                }
                else
                {
                    if (this.btnAddItem.Tag is DataGridViewRow)
                    {
                        DataGridViewRow row = this.btnAddItem.Tag as DataGridViewRow;
                        POSItemInfo item = row.Tag as POSItemInfo;

                        byte[] imageContent = this.mImageIsUpdated ? POSComonUtility.ImageToByteArray(this.pbxSnapShot.Image) : item.ImageContent;

                        POSFactory.CreateOrUpdatePOSItemInfo(item, name, shortName, buyingPrice, sellingPrice, description, discount, discountInPercent, imageContent, itemsCount, category, type, vendor);

                        row.SetValues("", shortName, name, description, imageContent, vendor.Name, type.Name, category.Name, buyingPrice, sellingPrice, discount, discountInPercent ? 1 : 0, itemsCount);

                        MessageBox.Show(this, "Item has been updated successfully.");

                    }
                    else
                    {
                        //bool newPurchase = false;
                        //bool newReturn = false;
                        //int oldItemsCount = 0;

                        //if (this.mItemToUpdate.TotalItemsPurchased != itemsCount)
                        //{
                        //    oldItemsCount = this.mItemToUpdate.TotalItemsPurchased;

                        //    if (this.mItemToUpdate.TotalItemsPurchased < itemsCount)
                        //    {
                        //        newPurchase = true;
                        //    }
                        //    else
                        //    {
                        //        newReturn = true;
                        //    }
                        //}                        

                        POSItemInfo item = this.btnAddItem.Tag as POSItemInfo;

                        byte[] imageContent = this.mImageIsUpdated ? POSComonUtility.ImageToByteArray(this.pbxSnapShot.Image) : item.ImageContent;

                        POSFactory.CreateOrUpdatePOSItemInfo(item, name, shortName, buyingPrice, sellingPrice, description, discount, discountInPercent, imageContent, itemsCount, category, type, vendor);

                        if (this.mItemToUpdate != null)
                        {
                            string errorMsg = string.Empty;
                            //if (newPurchase)
                            //{
                            //    POSItemTransactionItem transactionItem = POSFactory.CreatePOSItemTransactionItem(item, true, itemsCount - oldItemsCount, buyingPrice);

                            //    if (transactionItem != null)
                            //    {
                            //        item.Transactions.Add(transactionItem);
                            //    }
                                                             
                            //}

                            //if (newReturn)
                            //{
                            //    POSItemTransactionItem transactionItem = POSFactory.CreatePOSItemTransactionItem(item, false, oldItemsCount - itemsCount, buyingPrice);

                            //    if (transactionItem != null)
                            //    {
                            //        item.Transactions.Add(transactionItem);
                            //    }
                            //}

                            Cursor currentCursor = Cursor.Current;
                            Cursor.Current = Cursors.WaitCursor;

                            POSStatusCodes status = POSDbUtility.UpdatePOSItem(item, ref errorMsg, true);

                            Cursor.Current = currentCursor;
                            if (status == POSStatusCodes.Success)
                            {
                                MessageBox.Show(this, "Item has been updated successfully.");
                            }
                            else
                            {
                                MessageBox.Show(this, "Some error occured in updating item.\n\n" + errorMsg);
                            }


                            return;
                        }
                    }
                    
                }                
            }
            else
            {
                byte[] imageContent = POSComonUtility.ImageToByteArray(this.pbxSnapShot.Image);
                POSItemInfo item = POSFactory.CreateOrUpdatePOSItemInfo(null, name, shortName, buyingPrice, sellingPrice, description, discount, discountInPercent, imageContent, itemsCount, category, type, vendor);

                mItems.Insert(0, item);
            }

            this.bsPOSItemInfo.DataSource = null;
            this.bsPOSItemInfo.DataSource = this.mItems;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {            
            this.ofdBrowseImage.ShowDialog(this);
        }

        private void ofdBrowseImage_FileOk(object sender, CancelEventArgs e)
        {
            string filePath = this.ofdBrowseImage.FileName;

            Bitmap image = new Bitmap(filePath);

            this.pbxSnapShot.Image = image;

            this.mImageIsUpdated = true;
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dgvPOSItems.SelectedRows.Count == 0)
            {
                MessageBox.Show(this, "Select any item to delete");
            }
            else
            {
                POSItemInfo itemToRemove = this.dgvPOSItems.SelectedRows[0].Tag as POSItemInfo;

                if (itemToRemove == null)
                {
                    MessageBox.Show(this, "There is some error occured in adding item please close window and try again.");
                }
                else
                {
                    this.mItems.Remove(itemToRemove);

                    this.bsPOSItemInfo.DataSource = null;
                    this.bsPOSItemInfo.DataSource = this.mItems;
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.dgvPOSItems.SelectedRows.Count == 0)
            {
                MessageBox.Show(this, "Select any item to update");
            }
            else
            {
                POSItemInfo itemToUpdate = this.dgvPOSItems.SelectedRows[0].Tag as POSItemInfo;

                if (itemToUpdate == null)
                {
                    MessageBox.Show(this, "There is some error occured in adding item please close window and try again.");
                }
                else
                {
                    POSItemInfoForm form = new POSItemInfoForm(this.dgvPOSItems.SelectedRows[0]);

                    form.ShowDialog();
                }
            }
        }

        private void btnSaveAll_Click(object sender, EventArgs e)
        {
            if (this.mItems.Count == 0)
            {
                MessageBox.Show(this, "Please add any item.");
                return;
            }
            else
            {
                Cursor currentCursor = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;

                List<POSItemTransactionItem> transactionItems = new List<POSItemTransactionItem>();

                foreach (POSItemInfo item in this.mItems)
                {
                    transactionItems.Add(POSFactory.CreatePOSItemTransactionItem(item, true, item.TotalItemsPurchased, item.BuyingPrice));
                }
                
                POSItemTransactionInfo purchase = POSFactory.CreatePOSItemTransactionInfo(transactionItems);

                string errorMsg = string.Empty;

                POSStatusCodes status = POSDbUtility.AddPOSPurchase(purchase, ref errorMsg, true);

                Cursor.Current = currentCursor;

                if (status == POSStatusCodes.Success)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show(this, "Some error occured in saving Items.\n\n" + errorMsg);
                }
            }            
        }

        private void llUpdateCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UpdateCategoryForm updateCategoryForm = new UpdateCategoryForm();

            updateCategoryForm.ShowDialog(this);

            PopulateDropDownFields(CONST_DDP_TYPE_CATEGORY);
        }

        private void llUpdateType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UpdateItemTypeForm updateItemTypeForm = new UpdateItemTypeForm();

            updateItemTypeForm.ShowDialog(this);

            PopulateDropDownFields(CONST_DDP_TYPE_TYPE);
        }
        

        private void btnCancelChanges_Click(object sender, EventArgs e)
        {
            this.btnAddItem.Text = CONST_ADD_ITEM_TEXT;
            this.btnAddItem.Tag = null;
        }

        #endregion


        #region Private Methods

        private void UpdateLayout(bool oldItem)
        {            
            this.dgvPOSItems.Visible = false;
            this.btnUpdate.Visible = false;
            this.btnDelete.Visible = false;
            this.btnSaveAll.Visible = false;
            this.btnAddItem.Text = CONST_UPDATE_TEXT;

            if (oldItem)
            {
                this.btnPurchase.Visible = true;
                this.tbxBuyingPrice.Enabled = false;
                this.nudItemsCount.Enabled = false;
                this.cbxVendor.Enabled = false;
                this.cbxItemType.Enabled = false;
                this.cbxItemCategory.Enabled = false;
            }
            

            this.Height = this.groupBox1.Height + 105;
        }

        private void PopulateDropDownFields(string ddpType = "")
        {            
            if (string.IsNullOrEmpty(ddpType))
            {
                Cursor currentCursor = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;

                try
                {
                    this.mVendors = POSDbUtility.GetAllVendors();
                }
                catch (Exception e)
                {
                    string errorMsg = POSComonUtility.GetInnerExceptionMessage(e);
                    Cursor.Current = currentCursor;
                    MessageBox.Show(this, "Some error occured in fetching Vendors.\n\n" + errorMsg);
                }

                List<string> vendors = (from vendor in this.mVendors
                                        where vendor != null
                                        select vendor.Name).ToList();
                
                this.cbxVendor.Items.Clear();
                this.cbxVendor.Items.AddRange(vendors.ToArray());

                Cursor.Current = currentCursor;
            }

            if (string.IsNullOrEmpty(ddpType) || ddpType == CONST_DDP_TYPE_CATEGORY)
            {
                Cursor currentCursor = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;

                try
                {
                    this.mCategories = POSDbUtility.GetAllPOSItemCategories();
                }
                catch (Exception e)
                {
                    string errorMsg = POSComonUtility.GetInnerExceptionMessage(e);
                    Cursor.Current = currentCursor;
                    MessageBox.Show(this, "Some error occured in fetching Categories.\n\n" + errorMsg);
                }                

                List<string> categories = (from category in this.mCategories
                                           where category != null
                                           select category.Name).ToList();

                this.cbxItemCategory.Text = string.Empty;
                this.cbxItemCategory.Items.Clear();
                this.cbxItemCategory.Items.AddRange(categories.ToArray());

                Cursor.Current = currentCursor;
            }

            if (string.IsNullOrEmpty(ddpType) || ddpType == CONST_DDP_TYPE_TYPE)
            {
                Cursor currentCursor = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;

                try
                {
                    this.mTypes = POSDbUtility.GetAllPOSItemTypes();
                }
                catch (Exception e)
                {
                    string errorMsg = POSComonUtility.GetInnerExceptionMessage(e);
                    Cursor.Current = currentCursor;
                    MessageBox.Show(this, "Some error occured in fetching types.\n\n" + errorMsg);
                }

                List<string> types = (from type in this.mTypes
                                      where type != null
                                      select type.Name).ToList();

                this.cbxItemType.Text = string.Empty;
                this.cbxItemType.Items.Clear();
                this.cbxItemType.Items.AddRange(types.ToArray());

                Cursor.Current = currentCursor;
            }
        }

        private void PopulatePOSItemInfo(POSItemInfo item)
        {
            this.tbxItemName.Text = item.Name;
            this.tbxShortName.Text = item.ShortName;
            this.tbxDescription.Text = item.Description;

            if (this.mVendors.Contains(item.Vendor))
            {
                this.cbxVendor.SelectedIndex = this.mVendors.IndexOf(item.Vendor);
            }

            if (this.mCategories.Contains(item.Category))
            {
                this.cbxItemCategory.SelectedIndex = this.mCategories.IndexOf(item.Category);
            }

            if (this.mTypes.Contains(item.Type))
            {
                this.cbxItemType.SelectedIndex = this.mTypes.IndexOf(item.Type);
            }
            

            this.tbxBuyingPrice.Text = Convert.ToString(item.BuyingPrice);
            this.tbxSellingPrice.Text = Convert.ToString(item.SellingPrice);
            this.nudDiscount.Value = item.Discount;
            this.nudItemsCount.Value = item.TotalItemsPurchased;

            this.chbDiscountInPercent.Checked = item.DiscountInPercent;

            this.pbxSnapShot.Image = POSComonUtility.ByteArrayToImage(item.ImageContent);
        }




        #endregion

        private void tbxBuyingPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            POSComonUtility.AllowNumericOnly(e);
        }

        private void tbxSellingPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            POSComonUtility.AllowNumericOnly(e);
        }

        private void tbxShortName_TextChanged(object sender, EventArgs e)
        {

        }

        private void chbDiscountInPercent_CheckedChanged(object sender, EventArgs e)
        {
            if (chbDiscountInPercent.Checked)
            {
                if (this.nudDiscount.Value > 100)
                {
                    this.nudDiscount.Value = 0;
                }

                this.nudDiscount.Maximum = 100;
            }
            else
            {
                this.nudDiscount.Maximum = decimal.MaxValue;
            }
        }

        private void nudItemsCount_ValueChanged(object sender, EventArgs e)
        {
            if (this.mItemToUpdate != null)
            {
                if (this.nudItemsCount.Value < this.mItemToUpdate.TotalItemsSold)
                {
                    this.nudItemsCount.Value = this.mItemToUpdate.TotalItemsSold;
                }
            }
        }

        private void tbxShortName_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string completeText = textBox.Text;

            if (!char.IsControl(e.KeyChar) && completeText.Length >= 3)
            {
                e.Handled = true;
            }
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            PurchaseExistingPOSItem form = new PurchaseExistingPOSItem(this.mItemToUpdate);

            form.ShowDialog(this);

            this.nudItemsCount.Value = this.mItemToUpdate.TotalItemsPurchased;
            this.tbxBuyingPrice.Text = this.mItemToUpdate.BuyingPrice.ToString();
        }
    }
}
