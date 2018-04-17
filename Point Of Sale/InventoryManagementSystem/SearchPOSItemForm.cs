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
    public partial class SearchPOSItemForm : Form
    {
        List<POSItemInfo> mItems = null;

        public SearchPOSItemForm()
        {
            InitializeComponent();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            this.ShowAll();
        }

        private void btnItemSearch_Click(object sender, EventArgs e)
        {
            this.SearchItems();
        }

        private void ShowAll()
        {
            Cursor current = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            this.tbxItemName.Text = string.Empty;

            this.mItems = POSDbUtility.GetAllPOSItems();

            this.bsPOSItemInfo.DataSource = null;
            this.bsPOSItemInfo.DataSource = this.mItems;

            Cursor.Current = current;
        }

        private void SearchItems()
        {
            string itemName = this.tbxItemName.Text;

            if (string.IsNullOrEmpty(itemName))
            {
                MessageBox.Show(this, "Please enter any item name or barcode.");
            }
            else
            {
                Cursor current = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;

                this.mItems = POSDbUtility.GetAllPOSItems();
                List<POSItemInfo> items = new List<POSItemInfo>();
                POSItemInfo item = this.mItems.Find(posItem => posItem.Barcode == itemName);

                if (item == null)
                {
                    items = this.mItems.FindAll(posItem => posItem.Name.ToLower().Contains(itemName.ToLower()));
                }
                else
                {
                    items.Add(item);
                }

                this.bsPOSItemInfo.DataSource = null;
                this.bsPOSItemInfo.DataSource = items;

                Cursor.Current = current;
            }
        }

        private void btnAddItems_Click(object sender, EventArgs e)
        {
            if (this.dgvPOSItems.Rows == null || this.dgvPOSItems.Rows.Count == 0 || this.dgvPOSItems.SelectedRows.Count == 0)
            {
                MessageBox.Show(this, "Please select any item to add.");
            }

            List<POSItemInfo> items = new List<POSItemInfo>();

            foreach (DataGridViewRow row in this.dgvPOSItems.SelectedRows)
            {
                if (row == null)
                {
                    continue;
                }

                if (row.Tag is POSItemInfo)
                {
                    items.Add(row.Tag as POSItemInfo);
                }
            }

            this.SelectedItems = items;

            this.Close();
        }

        private void dgvPOSItems_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (this.dgvPOSItems.Rows.Count == 0)
            {
                return;
            }

            string itemName = this.tbxItemName.Text;

            List<POSItemInfo> items = this.mItems;

            if (!string.IsNullOrEmpty(itemName))
            {
                POSItemInfo item = this.mItems.Find(posItem => posItem.Barcode == itemName);

                if (item == null)
                {
                    items = this.mItems.FindAll(posItem => posItem.Name.Contains(itemName));
                }
                else
                {
                    items.Add(item);
                }
            }

            for (int i = 0; i < items.Count; i++)
            {
                DataGridViewRow row = this.dgvPOSItems.Rows[i];

                row.Tag = items[i];
            }
        }

        public List<POSItemInfo> SelectedItems { get; set; }
    }
}
