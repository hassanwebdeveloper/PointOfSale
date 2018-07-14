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
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            InitializeComponent();

            try
            {
                this.mItemTypes = POSDbUtility.GetAllPOSItemTypes();
            }
            catch (Exception e)
            {
                string errorMsg = POSComonUtility.GetInnerExceptionMessage(e);
                Cursor.Current = currentCursor;
                MessageBox.Show(this, "Some error occured in fetching types.\n\n" + errorMsg);
            }
            
            this.bsPOSItemType.DataSource = this.mItemTypes;

            Cursor.Current = currentCursor;
        }

        private void dgvItemTypes_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                this.mItemTypes = POSDbUtility.GetAllPOSItemTypes();
            }
            catch (Exception ex)
            {
                string errorMsg = POSComonUtility.GetInnerExceptionMessage(ex);
                Cursor.Current = currentCursor;
                MessageBox.Show(this, "Some error occured in fetching types.\n\n" + errorMsg);
            }                       

            if (this.mItemTypes != null)
            {
                for (int i = 0; i < this.mItemTypes.Count; i++)
                {
                    DataGridViewRow row = this.dgvItemTypes.Rows[i];

                    row.Tag = this.mItemTypes[i];
                }
            }

            Cursor.Current = currentCursor;
        }

        private void dgvItemTypes_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            POSItemType itemType = e.Row.Tag as POSItemType;

            string errorMsg = string.Empty;

            bool itemsExits = (itemType.Items != null && itemType.Items.Count > 0);

            if (itemsExits)
            {
                MessageBox.Show(this, "Some items are associated with this type, so this type can not be deleted.");
                e.Cancel = true;
                return;
            }

            DialogResult result = MessageBox.Show(this, "Are you sure you want to delete this type?", "Confirmation Dialog", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Cursor currentCursor = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;
            
                POSStatusCodes status = POSDbUtility.DeletePOSItemType(itemType, ref errorMsg, true);

                if (status == POSStatusCodes.Failed)
                {
                    Cursor.Current = currentCursor;
                    MessageBox.Show(this, "Some error occurred in deleting Item Type.\n\n" + errorMsg);
                    e.Cancel = true;
                }

                Cursor.Current = currentCursor;
            }
            else
            {
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

            if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(shortName))
            {
                MessageBox.Show(this, "Enter any name or short name.");

                return;
            }

            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
           

            if (row.Tag == null)
            {
                itemType = POSFactory.CreateOrUpdatePOSItemType(null, name, shortName);

                POSStatusCodes status = POSDbUtility.AddPOSItemType(itemType, ref errorMsg, true);

                if (status == POSStatusCodes.Failed)
                {
                    Cursor.Current = currentCursor;
                    MessageBox.Show(this, "Some error occurred in adding type.\n\n" + errorMsg);
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
                    Cursor.Current = currentCursor;
                    MessageBox.Show(this, "Some error occurred in updating type.\n\n" + errorMsg);
                    return;
                }
            }

            Cursor.Current = currentCursor;
        }

        private void dgvItemTypes_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(NumericColumn_KeyPress);
            if (this.dgvItemTypes.CurrentCell.ColumnIndex == 2) //Desired Column
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
