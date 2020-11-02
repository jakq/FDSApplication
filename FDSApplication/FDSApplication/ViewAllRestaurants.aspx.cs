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
    public partial class ViewAllRestaurants : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isLogin"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            panelViewRestaurants.Visible = false;
            alertSuccess.Visible = false;
            alertFailure.Visible = false;
            panelUpdateRestaurant.Visible = false;

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
                    lblErrorRetrieve.Text = "Error in retrieving list";
                }
            }

            if (!user.UserRole.Equals("Manager"))
            {              
                lblUserDenied.Text = "YOU DO NOT HAVE MANAGER RIGHTS TO ACCESS THIS FUNCTION";
                btnSearch.Enabled = false;
            }

            else
            {
                panelViewRestaurants.Visible = true;
            }
        }

        protected void lnk_Update_Click(object sender, EventArgs e)
        {
            int restId = Convert.ToInt32((sender as LinkButton).CommandArgument);
            RestaurantBLL rBLL = new RestaurantBLL();
            Restaurant restaurant = rBLL.DoRetrieveRestaurantByRestID(restId);

            panelUpdateRestaurant.Visible = true;
            lblUpdateRestaurant.Text = "Updating Record for Restaurant ID: " + restaurant.RestId;
            txtRestId.Text = restaurant.RestId.ToString();
            txtRName.Text = restaurant.RestName;
            txtRAddress.Text = restaurant.RestAddress;
            ddlRArea.SelectedValue = restaurant.RestArea;
            txtMinAmnt.Text = restaurant.MinAmnt.ToString();
        }

        protected void btnUpdateRecord_Click(object sender, EventArgs e)
        {

            if (txtRName.Text.Length <= 0)
            {
                lblRNameMsg.Text = "Restaurant Name Cannot Be Blank";
            }

            if (txtRAddress.Text.Length <= 0)
            {
                lblRAddressMsg.Text = "Address Cannot Be Blank";
            }

            if (txtMinAmnt.Text.Length <= 0)
            {
                lblMinAmntMsg.Text = "Minimum Amount Cannot Be Blank";
            }

            string rArea = ddlRArea.SelectedValue;

            if (txtRName.Text.Length > 0 && txtRAddress.Text.Length > 0 && txtMinAmnt.Text.Length > 0)
            {
                RestaurantBLL rBLL = new RestaurantBLL();
                int result = rBLL.DoUpdateRestaurant(Convert.ToInt32(txtRestId.Text), txtRName.Text, txtRAddress.Text, rArea, Convert.ToDouble(txtMinAmnt.Text));

                if (result > 0)
                {
                    alertSuccess.Visible = true;
                }

                else
                {
                    alertFailure.Visible = false;
                }

                //Refresh the Table
                DataTable dt = new DataTable();
                dt = rBLL.DoRetrieveAllRestaurants();
                gv_restaurants.DataSource = dt;
                gv_restaurants.DataBind();              
            }        
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
                lblErrorRetrieve.Text = "Error in retrieving list";
            }
        }
    }
}