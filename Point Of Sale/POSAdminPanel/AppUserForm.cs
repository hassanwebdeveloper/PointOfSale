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
    public partial class AppUserForm : Form
    {
        private POSAppUser mAppUser = null;

        public AppUserForm()
        {
            InitializeComponent();

            PopulateAppUser();
        }

        public AppUserForm(POSAppUser appUser)
        {
            InitializeComponent();

            this.mAppUser = appUser;
            PopulateAppUser();

        }


        private void PopulateAppUser()
        {
            

            if (this.mAppUser == null)
            {
                this.lblNewPassword.Visible = false;
                this.tbxNewPassword.Visible = false;
                this.lblConfirmPassword.Visible = false;
                this.tbxConfirmPassword.Visible = false;
                //this.btnAddAppUser.Location = new Point(469, 253);
                this.groupBox1.Size = new Size(this.groupBox1.Size.Width, this.groupBox1.Size.Height - 77);
                this.Size = new Size(this.Size.Width, this.Size.Height - 74);
                this.panel6.Location = new Point(this.panel6.Location.X, this.panel6.Location.Y - 74);
            }
            else
            {
                this.tbxName.Text = this.mAppUser.Name;
                this.tbxLastName.Text = this.mAppUser.LastName;
                this.tbxContactNumber.Text = this.mAppUser.ContactNumber;
                this.tbxAddress.Text = this.mAppUser.Address;
                this.tbxRoles.Text = this.mAppUser.Roles; //cutome need to be checked.

                this.btnAddAppUser.Text = "Update User";
            }


        }

        private void btnAddAppUser_Click(object sender, EventArgs e)
        {
            bool isValidTbxInputs = POSComonUtility.ValidateInputs(new List<TextBox>() { this.tbxName, this.tbxLastName, this.tbxContactNumber, this.tbxAddress, this.tbxRoles });

            if (isValidTbxInputs)
            {
                Cursor currentCursor = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;
               

                POSStatusCodes status = POSStatusCodes.Aborted;

                string name = this.tbxName.Text;
                string lastName = this.tbxLastName.Text;
                string contactNumber = this.tbxContactNumber.Text;
                string address = this.tbxAddress.Text;
                string role = this.tbxRoles.Text;                
                string password = this.tbxPassword.Text;
                string customData = string.Empty;
                string newPassword = this.tbxNewPassword.Text;
                string confirmPassword = this.tbxConfirmPassword.Text;

                string errorMsg = string.Empty;

                if (this.mAppUser == null)
                {
                    isValidTbxInputs = POSComonUtility.ValidateInputs(new List<TextBox>() { this.tbxPassword });

                    if (isValidTbxInputs)
                    {
                        if (string.IsNullOrEmpty(password) || password.Length < 8)
                        {
                            errorMsg = "Password should contains atleast 8 characters.";
                        }
                        else
                        {
                            POSAppUser appUser = POSFactory.CreateOrUpdatePOSAppUser(null, name, lastName, contactNumber, address, role, password, customData);

                            status = POSDbUtility.AddPOSAppUser(appUser, ref errorMsg, true);
                        }                        
                    }
                    else
                    {
                        Cursor.Current = currentCursor;
                        return;
                    }
                }
                else
                {
                    string oldPassword = this.mAppUser.Password;
                    bool isValidPassword = false;

                    if (string.IsNullOrEmpty(password) && string.IsNullOrEmpty(newPassword))
                    {
                        password = this.mAppUser.Password;
                        isValidPassword = true;
                    }
                    else
                    {
                        if (password == oldPassword)
                            {
                                if (newPassword.Length >= 8)
                                {
                                    if (newPassword == confirmPassword)
                                    {
                                        if (password == newPassword)
                                        {
                                            errorMsg = "New and old passwords are same.";
                                        }
                                        else
                                        {
                                            password = newPassword;
                                            isValidPassword = true;
                                        }

                                    }
                                    else
                                    {
                                        errorMsg = "New password and confirmed password did not match.";
                                    }
                                }
                                else
                                {
                                    errorMsg = "New Password should contains atleast 8 characters.";
                                }
                            }
                            else
                            {
                                errorMsg = "Enter correct old password.";
                            }

                    }

                    if (isValidPassword)
                    {
                        POSAppUser appUser = POSFactory.CreateOrUpdatePOSAppUser(this.mAppUser, name, lastName, contactNumber, address, role, password, customData);

                        status = POSDbUtility.UpdatePOSAppUser(appUser, ref errorMsg);
                    }

                }


                Cursor.Current = currentCursor;

                if (status == POSStatusCodes.Failed)
                {
                    MessageBox.Show(this, "Failed to add/update user.\n\n" + errorMsg);
                }
                else if (status == POSStatusCodes.Aborted)
                {
                    MessageBox.Show(this, errorMsg);
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void llSetRoles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetApplicationUserRoles form = new SetApplicationUserRoles(this.mAppUser);

            form.ShowDialog(this);

            this.tbxRoles.Text = form.Roles;

        }
    }
}
