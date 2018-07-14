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
    public partial class SearchPOSItemInfoForm : Form
    {
        public SearchPOSItemInfoForm(string itemName)
        {
            InitializeComponent();

            this.tbxItemName.Text = itemName;
            Search(true);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search(bool firstOpen = false)
        {
            string itemName = this.tbxItemName.Text;

            if (string.IsNullOrEmpty(itemName))
            {
                if (!firstOpen)
                {
                    MessageBox.Show(this, "Please enter any item name or barcode.");
                }
                
            }
            else
            {
                List<POSGridItemInfo> items = POSComonUtility.SearchItem(itemName, this);

                this.bsPOSGridItemInfo.DataSource = null;
                this.bsPOSGridItemInfo.DataSource = items;
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (this.dgvPOSItems.Rows == null ||
                this.dgvPOSItems.Rows.Count == 0 ||
                this.dgvPOSItems.SelectedRows == null || 
                this.dgvPOSItems.SelectedRows.Count == 0 ||
                this.dgvPOSItems.SelectedRows[0] == null || 
                this.dgvPOSItems.SelectedRows[0].Tag == null)
            {
                MessageBox.Show(this, "Please select any item to add.");
                return;
            }

            POSGridItemInfo itemInfo = this.dgvPOSItems.SelectedRows[0].Tag as POSGridItemInfo;


            this.SelectedItem = itemInfo;
            this.Close();
        }

        private void dgvPOSItems_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (this.dgvPOSItems.Rows.Count == 0)
            {
                return;
            }

            string itemName = this.tbxItemName.Text;

            List<POSGridItemInfo> items = POSComonUtility.SearchItem(itemName, this);

            for (int i = 0; i < items.Count; i++)
            {
                DataGridViewRow row = this.dgvPOSItems.Rows[i];

                row.Tag = items[i];
            }
        }
        

        public POSGridItemInfo SelectedItem { get; set; }
    }
}
