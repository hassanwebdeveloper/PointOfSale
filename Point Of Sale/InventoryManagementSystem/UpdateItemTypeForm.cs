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
    public partial class UpdateItemTypeForm : Form
    {
        List<POSItemType> mItemTypes = null;

        public UpdateItemTypeForm()
        {
            InitializeComponent();

            this.mItemTypes = POSDbUtility.GetAllPOSItemTypes();

            this.bsPOSItemType.DataSource = this.mItemTypes;
        }

        private void dgvItemTypes_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.mItemTypes = POSDbUtility.GetAllPOSItemTypes();
            for (int i = 0; i < this.mItemTypes.Count; i++)
            {
                DataGridViewRow row = this.dgvItemTypes.Rows[i];

                row.Tag = this.mItemTypes[i];
            }
        }

        private void dgvItemTypes_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            POSItemType itemType = e.Row.Tag as POSItemType;

            string errorMsg = string.Empty;

            POSStatusCodes status = POSDbUtility.DeletePOSItemType(itemType, ref errorMsg, true);

            if (status == POSStatusCodes.Failed)
            {
                MessageBox.Show(this, "Some error occurred in deleting Item Type.\n\n" + errorMsg);
                e.Cancel = true;
            }
        }

        private void dgvItemTypes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dgvItemTypes.Rows[e.RowIndex];
            POSItemType itemType = null;
            string name = row.Cells[1].Value as String;
            string shortName = row.Cells[2].Value as String;
            string errorMsg = string.Empty;

            if (row.Tag == null)
            {
                itemType = POSFactory.CreateOrUpdatePOSItemType(null, name, shortName);

                POSStatusCodes status = POSDbUtility.AddPOSItemType(itemType, ref errorMsg, true);

                if (status == POSStatusCodes.Failed)
                {
                    MessageBox.Show(this, "Some error occurred in deleting Category.\n\n" + errorMsg);
                    return;
                }

            }
            else
            {
                itemType = row.Tag as POSItemType;

                POSFactory.CreateOrUpdatePOSItemType(itemType, name, shortName);

                POSStatusCodes status = POSDbUtility.UpdatePOSItemType(itemType, ref errorMsg);

                if (status == POSStatusCodes.Failed)
                {
                    MessageBox.Show(this, "Some error occurred in deleting Category.\n\n" + errorMsg);
                    return;
                }
            }
        }
    }
}
