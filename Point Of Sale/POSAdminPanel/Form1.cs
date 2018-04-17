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

namespace POSAdminPanel
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddAppUser_Click(object sender, EventArgs e)
        {
            AppUserListForm form = new AppUserListForm();

            form.ShowDialog(this);
        }

        private void btnAddSalesMan_Click(object sender, EventArgs e)
        {
            SalesManListForm form = new SalesManListForm();

            form.ShowDialog(this);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoginForm.mMainForm.Close();
        }

        private void btnSystemSettings_Click(object sender, EventArgs e)
        {
            SetSystemSettingsForm form = new SetSystemSettingsForm();

            form.ShowDialog(this);
        }
    }
}
