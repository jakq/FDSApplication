using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FDSApplication.BusinessLogicLayer;
using FDSApplication.Models;

namespace FDSApplication
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            alertFailure.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Length <= 0)
            {
                lblUsernameMsg.Text = "Username cannot be blank";
            }

            if (txtPassword.Text.Length <= 0)
            {
                lblPasswordMsg.Text = "Password cannot be blank";
            }

            if (txtUsername.Text.Length > 0 && txtPassword.Text.Length > 0)
            {
                UserAccountBLL uBLL = new UserAccountBLL();
                UserAccount user = new UserAccount();
                user = uBLL.DoGetUserByUsername(txtUsername.Text);

                if (user != null)
                {
                    if (!txtPassword.Text.Equals(user.Password))
                    {
                        alertFailure.Visible = true;
                        lblAlertMsg.Text = "Invalid Username or Password";
                        ClearTextFieldAndMessages();
                    }

                    else
                    {
                        //Save the details in a session so can be accessed by all pages
                        Session["isLogin"] = true;
                        Session["UserAccountObj"] = user;

                        if (user.UserRole.Equals("Customer"))
                        {
                            Response.Redirect("UserIndex.aspx");
                        }

                        if (user.UserRole.Equals("Rider"))
                        {
                            Response.Redirect("RiderIndex.aspx");
                        }

                        if (user.UserRole.Equals("Staff") || user.UserRole.Equals("Manager"))
                        {
                            Response.Redirect("StaffIndex.aspx");
                        }
                    }
                }

                else
                {
                    alertFailure.Visible = true;
                    lblAlertMsg.Text = "Invalid Username or Password";
                    ClearTextFieldAndMessages();
                }

            }
        }

        public void ClearTextFieldAndMessages()
        {
            txtUsername.Text = "";
            lblUsernameMsg.Text = "";
            txtPassword.Text = "";
            lblPasswordMsg.Text = "";
        }
    }
}