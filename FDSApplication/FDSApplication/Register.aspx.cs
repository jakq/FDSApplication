using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FDSApplication.BusinessLogicLayer;

namespace FDSApplication
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //By default all the panels and checkbox should be set to false 
            userRegisterPanel.Visible = false;
            riderRegisterPanel.Visible = false;
            alertSuccess.Visible = false;
            alertFailure.Visible = false;
        }

        protected void btnToggleUserRegister_Click(object sender, EventArgs e)
        {
            userRegisterPanel.Visible = true;
        }

        protected void btnToggleRiderRegister_Click(object sender, EventArgs e)
        {
            riderRegisterPanel.Visible = true;
        }

        protected void btnUserRegister_Click(object sender, EventArgs e)
        {
            if (txtCName.Text.Length <= 0)
            {
                lblCNameMsg.Text = "Name cannot be blank";
            }

            if (txtCUsername.Text.Length <= 0)
            {
                lblCUsernameMsg.Text = "Username cannot be blank";
            }

            if (txtCPassword.Text.Length <= 0)
            {
                lblCPasswordMsg.Text = "Password cannot be blank";
            }

            if (txtCName.Text.Length > 0 && txtCUsername.Text.Length > 0 && txtCPassword.Text.Length > 0)
            {
                UserAccountBLL uBLL = new UserAccountBLL();
                int checkUserName = uBLL.DoCheckUserNameExists(txtCUsername.Text);

                //If username exists 
                if (checkUserName > 0)
                {
                    alertFailure.Visible = true;
                    lblAlertMsg.Text = "Username Exists in Database. Please use another username";
                    ClearTextFieldAndMessages();
                }

                else
                {
                    int result = uBLL.DoCreateNewUser(txtCName.Text, txtCUsername.Text, txtCPassword.Text);

                    if (result > 0)
                    {
                        alertSuccess.Visible = true;
                    }

                    else
                    {
                        alertFailure.Visible = true;
                        lblAlertMsg.Text = "Unable to create a new user account";
                        ClearTextFieldAndMessages();
                    }
                }
            }
        }

        protected void btnRiderRegister_Click(object sender, EventArgs e)
        {
            Boolean isFullTime; 

            if (txtRName.Text.Length <= 0)
            {
                lblRNameMsg.Text = "Name cannot be blank";
            }

            if (txtRUserName.Text.Length <= 0)
            {
                lblRUsernameMsg.Text = "Username cannot be blank";
            }

            if (txtRPassword.Text.Length <= 0)
            {
                lblRPasswordMsg.Text = "Password cannot be blank";
            }

            if (chkBoxFullTime.Checked == true)
            {
                isFullTime = true;
            }

            else
            {
                isFullTime = false;
            }

            if (txtRName.Text.Length > 0 && txtRUserName.Text.Length > 0 && txtRPassword.Text.Length > 0)
            {
                UserAccountBLL uBLL = new UserAccountBLL();
                int checkUserName = uBLL.DoCheckUserNameExists(txtRUserName.Text);

                //If username exists 
                if (checkUserName > 0)
                {
                    alertFailure.Visible = true;
                    lblAlertMsg.Text = "Username Exists in Database. Please use another username";
                    ClearTextFieldAndMessages();
                }

                else
                {
                    int result = uBLL.DoCreateNewRider(txtRName.Text, txtRUserName.Text, txtRPassword.Text, isFullTime);

                    if (result > 0)
                    {
                        alertSuccess.Visible = true;
                    }

                    else
                    {
                        alertFailure.Visible = true;
                        lblAlertMsg.Text = "Unable to create a new rider account";
                        ClearTextFieldAndMessages();
                    }
                }
            }
        }

        public void ClearTextFieldAndMessages()
        {
            txtCName.Text = "";
            lblCNameMsg.Text = "";
            txtCUsername.Text = "";
            lblCUsernameMsg.Text = "";
            txtCPassword.Text = "";
            lblCPasswordMsg.Text = "";
            txtRName.Text = "";
            lblRNameMsg.Text = "";
            txtRUserName.Text = "";
            lblRUsernameMsg.Text = "";
            txtRPassword.Text = "";
            lblRPasswordMsg.Text = "";
            chkBoxFullTime.Checked = false;
        }


    }
}