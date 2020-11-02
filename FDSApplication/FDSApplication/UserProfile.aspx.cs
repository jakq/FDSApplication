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
    public partial class UserProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isLogin"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            alertSuccess.Visible = false;
            alertFailure.Visible = false;
            panelChangePassword.Visible = false;

            if (!IsPostBack)
            {
                UserAccount user = (UserAccount)Session["UserAccountObj"];
                txtCUsername.Text = user.Username;

                CustomerBLL cBLL = new CustomerBLL();
                Customer customer = cBLL.DoRetrieveCustomerByID(user.UserId);

                if (customer != null)
                {
                    txtCName.Text = customer.CName;
                    txtRewardPoint.Text = customer.RewardPoint.ToString();
                }

                else
                {
                    alertFailure.Visible = true;
                    lblAlertMsg.Text = "Unable to retrieve user profile";
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtCName.Text.Length <= 0)
            {
                lblCNameMsg.Text = "Name cannot be blank";
            }

            if (txtCName.Text.Length > 0)
            {
                UserAccount user = (UserAccount)Session["UserAccountObj"];
                int custId = user.UserId;

                CustomerBLL cBLL = new CustomerBLL();
                int result = cBLL.DoUpdateCustomer(custId, txtCName.Text);

                if (result > 0)
                {
                    alertSuccess.Visible = true;
                }

                else
                {
                    alertFailure.Visible = true;
                    lblAlertMsg.Text = "Error in updating user profile";
                }
            }
        }

        public void ClearTextFieldAndMessages()
        {
            lblCNameMsg.Text = "";
            txtNewPassword.Text = "";
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            panelChangePassword.Visible = true;
        }

        protected void btnDeactivate_Click(object sender, EventArgs e)
        {
            UserAccount user = (UserAccount)Session["UserAccountObj"];
            UserAccountBLL uBLL = new UserAccountBLL();
            uBLL.DoDeactivateAccount(user.UserId, user.Username, user.Password, user.UserRole, user.Status);
            Response.Redirect("Login.aspx");
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.Text.Length <= 0)
            {
                lblChangeFailure.Text = "There was an error in your new password, current password remains";
            }

            else
            {
                UserAccount user = (UserAccount)Session["UserAccountObj"];
                UserAccountBLL uBLL = new UserAccountBLL();
                int result = uBLL.DoUpdatePassword(user.UserId, user.Username, txtNewPassword.Text);

                if (result > 0)
                {
                    lblChangeSuccess.Text = "Successfully changed password";
                }

                else
                {
                    lblChangeFailure.Text = "There has been an error in changing password";
                }

            }
        }
    }
}