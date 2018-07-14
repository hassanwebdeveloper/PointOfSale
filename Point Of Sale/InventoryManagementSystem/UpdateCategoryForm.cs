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
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            InitializeComponent();

            try
            {
                this.mCategories = POSDbUtility.GetAllPOSItemCategories();
            }
            catch (Exception e)
            {
                string errorMsg = POSComonUtility.GetInnerExceptionMessage(e);
                Cursor.Current = currentCursor;
                MessageBox.Show(this, "Some error occured in fetching categories.\n\n" + errorMsg);
            }

            this.bsPOSItemCategory.DataSource = this.mCategories;

            Cursor.Current = currentCursor;
        }

        private void dgvCadres_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                this.mCategories = POSDbUtility.GetAllPOSItemCategories();
            }
            catch (Exception ex)
            {
                string errorMsg = POSComonUtility.GetInnerExceptionMessage(ex);
                Cursor.Current = currentCursor;
                MessageBox.Show(this, "Some error occured in fetching categories.\n\n" + errorMsg);
            }

            if (this.mCategories != null)
            {
                for (int i = 0; i < this.mCategories.Count; i++)
                {
                    DataGridViewRow row = this.dgvCategories.Rows[i];

                    row.Tag = this.mCategories[i];
                }
            }
            

            Cursor.Current = currentCursor;
        }

        private void dgvCadres_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            POSItemCategory category = e.Row.Tag as POSItemCategory;

            string errorMsg = string.Empty;

            bool itemsExits = (category.Items != null && category.Items.Count > 0);

            if (itemsExits)
            {
                MessageBox.Show(this, "Some items are associated with this category, so this category can not be deleted.");
                e.Cancel = true;
                return;
            }

            DialogResult result = MessageBox.Show(this, "Are you sure you want to delete this category?", "Confirmation Dialog", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Cursor currentCursor = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;

                
                POSStatusCodes status = POSDbUtility.DeletePOSItemCategory(category, ref errorMsg, true);

                if (status != POSStatusCodes.Success)
                {
                    Cursor.Current = currentCursor;
                    MessageBox.Show(this, "Some error occurred in deleting Category.\n\n" + errorMsg);
                    e.Cancel = true;
                }

                Cursor.Current = currentCursor;
            }
            else
            {
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

            if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(shortName))
            {
                MessageBox.Show(this, "Enter any name or short name.");
                
                return;
            }

            if (row.Tag == null)
            {
                Cursor currentCursor = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;

                category = POSFactory.CreateOrUpdatePOSItemCategory(null, name, shortName);

                POSStatusCodes status = POSDbUtility.AddPOSItemCategory(category, ref errorMsg, true);

                if (status == POSStatusCodes.Failed)
                {
                    Cursor.Current = currentCursor;
                    MessageBox.Show(this, "Some error occurred in adding Category.\n\n" + errorMsg);
                }

                Cursor.Current = currentCursor;
            }
            else
            {
                Cursor currentCursor = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;                

                category = row.Tag as POSItemCategory;

                POSFactory.CreateOrUpdatePOSItemCategory(category, name, shortName);

                POSStatusCodes status = POSDbUtility.UpdatePOSItemCategory(category, ref errorMsg);

                if (status == POSStatusCodes.Failed)
                {
                    Cursor.Current = currentCursor;
                    MessageBox.Show(this, "Some error occurred in updating Category.\n\n" + errorMsg);
                }

                Cursor.Current = currentCursor;
            }
        }

        private void dgvCategories_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(NumericColumn_KeyPress);
            if (this.dgvCategories.CurrentCell.ColumnIndex == 2) //Desired Column
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
            TextBox textBox = sender as TextBox;
            string completeText = textBox.Text;

            if (!char.IsControl(e.KeyChar) && completeText.Length >= 3)
            {
                e.Handled = true;
            }
        }
    }
}
