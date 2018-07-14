using POSRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace POSReports
{
    public partial class LoginForm : Form
    {
        public static LoginForm mMainForm = null;
        public static POSAppUser mLoggedInUser = null;

        private List<POSAppUser> mUsers = null;

        public LoginForm()
        {
            InitializeComponent();

            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                this.mUsers = POSDbUtility.GetAllPOSAppuser();

                if (this.mUsers == null)
                {
                    this.btnLogin.Enabled = false;
                }
                else
                {
                    if (this.mUsers.Count == 0)
                    {
                        this.btnLogin.Enabled = false;
                    }
                }
            }
            catch (Exception e)
            {
                string errorMsg = POSComonUtility.GetInnerExceptionMessage(e);
                Cursor.Current = currentCursor;
                MessageBox.Show(this, "Some error occured in fetching users.\n\n" + errorMsg);
            }

            Cursor.Current = currentCursor;            

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

                MainForm lsf = new MainForm();

                lsf.Show();

                this.Hide();
            }

        }
    }
}
