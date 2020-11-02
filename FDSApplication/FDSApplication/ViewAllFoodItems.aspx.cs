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
    public partial class ViewAllFoodItems : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isLogin"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            gv_restaurants.Visible = false;
            panelViewFoodItems.Visible = false;
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
                    lblErrorRetrieve.Text = "Error in retrieving list";
                }
            }

            if (!user.UserRole.Equals("Manager"))
            {
                btnSearch.Enabled = false;
                lblUserDenied.Text = "YOU DO NOT HAVE MANAGER RIGHTS TO ACCESS THIS FUNCTION";
            }

            else
            {
                gv_restaurants.Visible = true;
            }
        }

        protected void lnk_View_Click(object sender, EventArgs e)
        {
            int restId = Convert.ToInt32((sender as LinkButton).CommandArgument);
            RestaurantBLL rBLL = new RestaurantBLL();
            Restaurant restaurant = rBLL.DoRetrieveRestaurantByRestID(restId);

            FoodItemBLL foodItemBLL = new FoodItemBLL();
            DataTable dt = new DataTable();
            dt = foodItemBLL.DoRetrieveAllFoodItemByRestId(restId);

            panelViewFoodItems.Visible = true;
            txtRName.Text = restaurant.RestName;

            if (dt != null)
            {
                gv_foodItem.DataSource = dt;
                gv_foodItem.DataBind();
            }

            else
            {
                alertFailure.Visible = true;
                lblErrorRetrieve.Text = "Error in retrieving food item list";
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewAllFoodItems.aspx");
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