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
    public partial class StaffProfile : System.Web.UI.Page
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
            panelWorkplace.Visible = false;

            if (!IsPostBack)
            {
                UserAccount user = (UserAccount)Session["UserAccountObj"];
                txtSUsername.Text = user.Username;

                StaffBLL staffBLL = new StaffBLL();
                Staff staff = staffBLL.DoRetrieveStaffByID(user.UserId);

                if (staff != null)
                {
                    txtSName.Text = staff.StaffName;
                    if (user.UserRole.Equals("Staff"))
                    {
                        RestaurantBLL restaurantBLL = new RestaurantBLL();
                        Restaurant restaurant = restaurantBLL.DoRetrieveRestaurantByRestID(staff.RestId);
                        panelWorkplace.Visible = true;

                        if (restaurant != null)
                        {
                            txtRName.Text = restaurant.RestName;
                            txtRAddress.Text = restaurant.RestAddress;
                            txtRArea.Text = restaurant.RestArea;
                        }

                        else
                        {
                            alertFailure.Visible = true;
                            lblAlertMsg.Text = "Unable to retrieve staff profile";
                        }
                    }                 
                }

                else
                {
                    txtSName.Text = "admin";
                    txtSName.Enabled = false;
                    btnChangePassword.Enabled = false;
                    btnDeactivate.Enabled = false;
                    btnUpdate.Enabled = false;
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtSName.Text.Length <= 0)
            {
                lblSNameMsg.Text = "Name cannot be blank";
            }

            if (txtSName.Text.Length > 0)
            {
                UserAccount user = (UserAccount)Session["UserAccountObj"];
                int staffId = user.UserId;

                StaffBLL staffBLL = new StaffBLL();
                int result = staffBLL.DoUpdateStaff(staffId, txtSName.Text);

                if (result > 0)
                {
                    alertSuccess.Visible = true;
                }

                else
                {
                    alertFailure.Visible = true;
                    lblAlertMsg.Text = "Error in updating staff profile";
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