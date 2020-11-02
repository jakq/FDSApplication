using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FDSApplication.BusinessLogicLayer;
using FDSApplication.Models;

namespace FDSApplication
{
    public partial class CreateStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isLogin"] == null)
            {
                Response.Redirect("Login.aspx");
            }
          
            panelViewRestaurants.Visible = false;
            panelCreateStaff.Visible = false;
            alertSuccess.Visible = false;
            alertFailure.Visible = false;

            UserAccount user = (UserAccount)Session["UserAccountObj"];

            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                RestaurantBLL rBLL = new RestaurantBLL();
                dt = rBLL.DoRetrieveAllRestaurants();

                if (dt != null)
                {
                    gv_restaurants.DataSource = dt;
                    gv_restaurants.DataBind();
                }

                else
                {
                    alertFailure.Visible = true;
                    lblAlertMsg.Text = "Error in retrieving list";
                }
            }

            if (!user.UserRole.Equals("Manager"))
            {                
                lblUserDenied.Text = "YOU DO NOT HAVE MANAGER RIGHTS TO ACCESS THIS FUNCTION";
            }

            else
            {
                panelViewRestaurants.Visible = true;
            }
        }

        protected void lnk_AddStaff_Click(object sender, EventArgs e)
        {
            int restId = Convert.ToInt32((sender as LinkButton).CommandArgument);
            RestaurantBLL rBLL = new RestaurantBLL();
            Restaurant restaurant = rBLL.DoRetrieveRestaurantByRestID(restId);

            panelCreateStaff.Visible = true;
            lblCreateStaff.Text = "CREATING STAFF FOR RESTAURANT ID " + restId;
            txtRestId.Text = restId.ToString();
            txtRName.Text = restaurant.RestName;
        }

        protected void btn_CreateStaff_Click(object sender, EventArgs e)
        {
            if (txtStaffName.Text.Length <= 0)
            {
                lblStaffNameMsg.Text = "Staff Name Cannot Be Blank";
            }

            if (txtStaffUsername.Text.Length <= 0)
            {
                lblStaffUsernameMsg.Text = "Staff Username Cannot Be Blank";
            }

            if (txtStaffPassword.Text.Length <= 0)
            {
                lblStaffPasswordMsg.Text = "Staff Password Cannot Be Blank";
            } 

            if (txtStaffName.Text.Length > 0 && txtStaffUsername.Text.Length > 0 && txtStaffPassword.Text.Length > 0)
            {
                UserAccountBLL uBLL = new UserAccountBLL();
                int checkUserName = uBLL.DoCheckUserNameExists(txtStaffUsername.Text);

                if (checkUserName > 0)
                {
                    alertFailure.Visible = true;
                    lblAlertMsg.Text = "Staff Username has already existed";
                }

                else
                {
                    int result = uBLL.DoCreateNewStaff(txtStaffName.Text, txtStaffUsername.Text, txtStaffPassword.Text, Convert.ToInt32(txtRestId.Text));
                    if (result > 0)
                    {
                        alertSuccess.Visible = true;
                    }

                    else
                    {
                        alertFailure.Visible = true;
                        lblAlertMsg.Text = "Unable to create a new staff account";
                        ClearTextFieldAndMessages();
                    }         
                }
            }
        }

        public void ClearTextFieldAndMessages()
        {
            txtStaffName.Text = "";
            lblStaffNameMsg.Text = "";
            txtStaffUsername.Text = "";
            lblStaffUsernameMsg.Text = "";
            txtStaffPassword.Text = "";
            lblStaffPasswordMsg.Text = "";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string area = ddlSearchArea.SelectedValue;
            DataTable dt = new DataTable();
            RestaurantBLL restaurantBLL = new RestaurantBLL();
            dt = restaurantBLL.DoRetrieveRestaurantByArea(area);

            if (dt != null)
            {
                gv_restaurants.DataSource = dt;
                gv_restaurants.DataBind();
                panelViewRestaurants.Visible = true;
                gv_restaurants.Visible = true;
            }

            else
            {
                alertFailure.Visible = true;
                lblAlertMsg.Text = "Error in retrieving list";
            }
        }
    }
}