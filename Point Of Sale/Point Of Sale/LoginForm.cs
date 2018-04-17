using POSRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Point_Of_Sale
{
    public partial class LoginForm : Form
    {
        public static LoginForm mMainForm = null;
        public static POSAppUser mLoggedInUser = null;

        private List<POSAppUser> mUsers = null;

        public LoginForm()
        {
            InitializeComponent();

            this.mUsers = POSDbUtility.GetAllPOSAppuser();

            if (this.mUsers.Count == 0)
            {
                this.btnLogin.Enabled = false;
            }

            this.lblVersion.Text = "Version: " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            this.tbxUserName.Select();
            mMainForm = this;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = this.tbxUserName.Text;
            string password = this.tbxPassword.Text;

            POSAppUser loggedInUser = (from user in mUsers
                                    where user != null && user.Name == userName && user.Password == password
                                    select user).FirstOrDefault();

            if (loggedInUser == null)
            {
                MessageBox.Show(this, "Either username or password is incorrect.");
            }
            else
            {
                mLoggedInUser = loggedInUser;

                mLoggedInUser.PopulatesRolesBoolean();

                Form1 form = new Form1();

                form.Show();

                this.Hide();
            }

        }
    }
}
