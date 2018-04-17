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
    public partial class PrintBarcodeForm : Form
    {
        List<POSItemInfo> mItems = new List<POSItemInfo>();

        public PrintBarcodeForm()
        {
            InitializeComponent();
        }
        

        private void dgvPOSItems_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (this.dgvPOSItems.Rows.Count == 0 || this.mItems == null)
            {
                return;
            }
            

            for (int i = 0; i < this.mItems.Count; i++)
            {
                DataGridViewRow row = this.dgvPOSItems.Rows[i];

                row.Tag = this.mItems[i];
            }
        }
        

        private void btnPrintBarcode_Click(object sender, EventArgs e)
        {
            if (this.dgvPOSItems.Rows == null || this.dgvPOSItems.Rows.Count == 0)
            {
                MessageBox.Show(this, "Please add any item to print barcode.");
            }

            SystemSettings systemSettings = POSDbUtility.GetAllSystemSettings().FirstOrDefault();

            string shopName = string.Empty;

            if (systemSettings != null)
            {
                shopName = systemSettings.ShopName;
            }

            List<POSItemInfo> itemsToPrint = new List<POSItemInfo>();

            foreach (DataGridViewRow row in this.dgvPOSItems.Rows)
            {
                if (row != null && row.Tag is POSItemInfo)
                {
                    if (string.IsNullOrEmpty(row.Cells[3].Value as string))
                    {
                        continue;
                    }

                    int count = Convert.ToInt32(row.Cells[3].Value);
                    POSItemInfo item = row.Tag as POSItemInfo;

                    for (int i = 0; i < count; i++)
                    {
                        itemsToPrint.Add(item);
                    }
                }
            }

            

            TSCLIB_DLL.openport("TSC TTP-244 Pro");                         //Open specified printer driver

            TSCLIB_DLL.setup("107", "25", "2", "8", "0", "2.5", "0");       //Setup the media size and sensor type info

            TSCLIB_DLL.clearbuffer();                                       //Clear image buffer

            bool portOpened = true;

            for (int i = 0; i < itemsToPrint.Count; i++)
            {
                if (portOpened)
                {
                    portOpened = false;
                }
                else
                {
                    TSCLIB_DLL.openport("TSC TTP-244 Pro");
                    TSCLIB_DLL.clearbuffer();
                }
                POSItemInfo firstItem = itemsToPrint[i++];
                POSItemInfo secondItem = null;

                if (i < itemsToPrint.Count)
                {
                    secondItem = itemsToPrint[i];
                }
                else
                {
                    secondItem = firstItem;
                }

                this.AddLeftBarCode(shopName, firstItem.Barcode, firstItem.Name, "Rs. " + firstItem.SellingPrice);
                this.AddRightBarCode(shopName, secondItem.Barcode, secondItem.Name, "Rs. " + secondItem.SellingPrice);

                TSCLIB_DLL.printlabel("1", "1");
                TSCLIB_DLL.closeport();
            }
        }

        private void AddLeftBarCode(string shopName,string strBarCode, string itemName, string price)
        {
            TSCLIB_DLL.windowsfont(45, 10, 30, 0, 0, 0, "Segoe UI", shopName);
            TSCLIB_DLL.barcode("100", "55", "128", "70", "1", "0", "2", "2", strBarCode);
            TSCLIB_DLL.windowsfont(40, 155, 30, 0, 0, 0, "Segoe UI", itemName);
            TSCLIB_DLL.windowsfont(280, 155, 30, 0, 0, 0, "Segoe UI", price);
        }

        private void AddRightBarCode(string shopName, string strBarCode, string itemName, string price)
        {
            TSCLIB_DLL.windowsfont(455, 10, 30, 0, 0, 0, "Segoe UI", shopName);
            TSCLIB_DLL.barcode("520", "55", "128", "70", "1", "0", "2", "2", strBarCode);
            TSCLIB_DLL.windowsfont(450, 155, 30, 0, 0, 0, "Segoe UI", itemName);
            TSCLIB_DLL.windowsfont(710, 155, 30, 0, 0, 0, "Segoe UI", price);
        }

        private void dgvPOSItems_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 0 || e.ColumnIndex == 1 || e.ColumnIndex == 2)
            {
                e.Cancel = true;
                return;
            }
        }

        private void dgvPOSItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dgvPOSItems.Rows[e.RowIndex];
            string cellValue = Convert.ToString(row.Cells[e.ColumnIndex].Value);

            if (!POSComonUtility.IsDigitsOnly(cellValue))
            {
                this.dgvPOSItems.CancelEdit();

                MessageBox.Show(this, "Please enter only numbers.");
            }
        }

        private void btnAddItems_Click(object sender, EventArgs e)
        {
            SearchPOSItemForm form = new SearchPOSItemForm();

            form.ShowDialog(this);

            List<POSItemInfo> items = form.SelectedItems;

            if (items != null)
            {
                this.mItems.AddRange(items.FindAll(i=> !this.mItems.Exists(it=> it.Id == i.Id)));

                this.bsPOSItemInfo.DataSource = null;
                this.bsPOSItemInfo.DataSource = this.mItems;
            }
        }

        private void dgvPOSItems_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            List<POSItemInfo> items = new List<POSItemInfo>();

            foreach (DataGridViewRow row in this.dgvPOSItems.Rows)
            {
                if (row != null && row.Tag is POSItemInfo)
                {
                    POSItemInfo item = row.Tag as POSItemInfo;

                    items.Add(item);
                }
            }

            this.mItems = items;
        }

        private void dgvPOSItems_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            //List<POSItemInfo> items = new List<POSItemInfo>();

            //foreach (DataGridViewRow row in this.dgvPOSItems.Rows)
            //{
            //    if (row != null && row.Tag is POSItemInfo)
            //    {
            //        POSItemInfo item = row.Tag as POSItemInfo;

            //        items.Add(item);
            //    }
            //}
            
            //this.mItems = items;
        }
    }
}
