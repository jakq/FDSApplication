using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FDSApplication.BusinessLogicLayer;
using FDSApplication.Models;

namespace FDSApplication
{
    public partial class ViewAllStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isLogin"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            panelViewStaff.Visible = false;
            alertFailure.Visible = false;

            UserAccount user = (UserAccount)Session["UserAccountObj"];

            if (user.UserRole.Equals("Staff"))
            {
                gv_restaurants.Visible = false;
                btnSearch.Enabled = false;
                lblAccessRight.Text = "YOU DO NOT HAVE MANAGER RIGHTS TO ACCESS THIS FUNCTION";
            }

            else
            {
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
                        lblErrorRetrieve.Text = "Error in retrieving list";
                    }
                }
            }
        }

        protected void lnk_ViewStaff_Click(object sender, EventArgs e)
        {
            int restId = Convert.ToInt32((sender as LinkButton).CommandArgument);
            RestaurantBLL rBLL = new RestaurantBLL();
            Restaurant restaurant = rBLL.DoRetrieveRestaurantByRestID(restId);

            StaffBLL staffBLL = new StaffBLL();
            DataTable dt = new DataTable();
            panelViewStaff.Visible = true;

            lblRestName.Text = restaurant.RestName;
            dt = staffBLL.DoRetrieveStaffByRestID(restId);

            if (dt != null)
            {
                gv_viewStaff.DataSource = dt;
                gv_viewStaff.DataBind();
            }

            else
            {
                alertFailure.Visible = true;
                lblErrorRetrieve.Text = "Error in retrieving staff list";
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewAllStaff.aspx");
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
                gv_restaurants.Visible = true;
            }

            else
            {
                alertFailure.Visible = true;
                lblErrorRetrieve.Text = "Error in retrieving list";
            }
        }
    }
}