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
    public partial class UpdateCategoryForm : Form
    {
        List<POSItemCategory> mCategories = null;

        public UpdateCategoryForm()
        {
            InitializeComponent();

            this.mCategories = POSDbUtility.GetAllPOSItemCategories();

            this.bsPOSItemCategory.DataSource = this.mCategories;
        }

        private void dgvCadres_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.mCategories = POSDbUtility.GetAllPOSItemCategories();

            for (int i = 0; i < this.mCategories.Count; i++)
            {
                DataGridViewRow row = this.dgvCategories.Rows[i];

                row.Tag = this.mCategories[i];
            }
        }

        private void dgvCadres_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            POSItemCategory category = e.Row.Tag as POSItemCategory;

            string errorMsg = string.Empty;

            POSStatusCodes status = POSDbUtility.DeletePOSItemCategory(category, ref errorMsg, true);

            if (status != POSStatusCodes.Success)
            {
                MessageBox.Show(this, "Some error occurred in deleting Category.\n\n" + errorMsg);
                e.Cancel = true;
            }
        }

        private void dgvCadres_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dgvCategories.Rows[e.RowIndex];
            POSItemCategory category = null;
            string name = row.Cells[1].Value as String;
            string shortName = row.Cells[2].Value as String;
            string errorMsg = string.Empty;

            if (row.Tag == null)
            {
                category = POSFactory.CreateOrUpdatePOSItemCategory(null, name, shortName);

                POSStatusCodes status = POSDbUtility.AddPOSItemCategory(category, ref errorMsg, true);

                if (status == POSStatusCodes.Failed)
                {
                    MessageBox.Show(this, "Some error occurred in deleting Category.\n\n" + errorMsg);
                    return;
                }

            }
            else
            {
                category = row.Tag as POSItemCategory;

                POSFactory.CreateOrUpdatePOSItemCategory(category, name, shortName);

                POSStatusCodes status = POSDbUtility.UpdatePOSItemCategory(category, ref errorMsg);

                if (status == POSStatusCodes.Failed)
                {
                    MessageBox.Show(this, "Some error occurred in deleting Category.\n\n" + errorMsg);
                    return;
                }
            }
        }
    }
}
