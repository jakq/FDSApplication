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
    public partial class RiderProfile : System.Web.UI.Page
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
                txtRUsername.Text = user.Username;

                RiderBLL riderBLL = new RiderBLL();
                Rider rider = riderBLL.DoRetrieveRiderByID(user.UserId);

                if (rider != null)
                {
                    txtRName.Text = rider.RName;
                    if (rider.IsFullTime)
                    {
                        txtJobStatus.Text = "Full-Time Staff";
                    }

                    else
                    {
                        txtJobStatus.Text = "Part-Time Staff";
                    }
                }

                else
                {
                    alertFailure.Visible = true;
                    lblAlertMsg.Text = "Unable to retrieve rider profile";
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtRName.Text.Length <= 0)
            {
                lblRNameMsg.Text = "Name cannot be blank";
            }

            if (txtRName.Text.Length > 0)
            {
                UserAccount user = (UserAccount)Session["UserAccountObj"];
                int riderId = user.UserId;

                RiderBLL riderBLL = new RiderBLL();
                int result = riderBLL.DoUpdateRider(riderId, txtRName.Text);

                if (result > 0)
                {
                    alertSuccess.Visible = true;
                }

                else
                {
                    alertFailure.Visible = true;
                    lblAlertMsg.Text = "Error in updating rider profile";
                }
            }
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