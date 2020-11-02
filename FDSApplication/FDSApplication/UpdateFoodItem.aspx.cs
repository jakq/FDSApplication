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
    public partial class UpdateFoodItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isLogin"] == null)
            {
                Response.Redirect("Login.aspx");
            }
           
            panelViewFoodItem.Visible = false;
            panelUpdateFoodItem.Visible = false;
            alertFoodSuccess.Visible = false;
            alertFoodFailure.Visible = false;
            alertOthersFailure.Visible = false;

            UserAccount user = (UserAccount)Session["UserAccountObj"];

            if (user.UserRole.Equals("Manager"))
            {
                lblAccessRight.Text = "YOU DO NOT HAVE STAFF RIGHTS TO ACCESS THIS FUNCTION";
            }

            else
            {
                if (!IsPostBack)
                {
                    StaffBLL staffBLL = new StaffBLL();
                    Staff staff = staffBLL.DoRetrieveStaffByID(user.UserId);

                    if (staff != null)
                    {
                        RestaurantBLL restaurantBLL = new RestaurantBLL();
                        Restaurant restaurant = restaurantBLL.DoRetrieveRestaurantByRestID(staff.RestId);

                        panelViewFoodItem.Visible = true;

                        if (restaurant != null)
                        {
                            txtRestId.Text = restaurant.RestId.ToString();
                            txtRestName.Text = restaurant.RestName;

                            DataTable dt = new DataTable();
                            FoodItemBLL foodItemBLL = new FoodItemBLL();
                            dt = foodItemBLL.DoRetrieveAllFoodItemByRestId(restaurant.RestId);

                            if (dt != null)
                            {
                                if (dt.Rows.Count > 0)
                                {
                                    gv_foodItem.DataSource = dt;
                                    gv_foodItem.DataBind();
                                }

                                else
                                {
                                    lblNoFoodItem.Text = "There is currently no food item, you will need to add a new food item";
                                }

                            }

                            else
                            {
                                alertOthersFailure.Visible = true;
                                lblErrorRetrieve.Text = "Unable to retrieve food item records";
                            }
                        }

                        else
                        {
                            alertOthersFailure.Visible = true;
                            lblErrorRetrieve.Text = "Unable to retrieve restaurant record";
                        }
                    }

                    else
                    {
                        alertOthersFailure.Visible = true;
                        lblErrorRetrieve.Text = "Unable to retrieve staff account";
                    }
                }
            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtFTitle.Text.Length <= 0)
            {
                lblFTitleMsg.Text = "Food Title cannot be blank";
            }

            if (txtPrice.Text.Length <= 0)
            {
                lblPriceMsg.Text = "Price cannot be blank";
            }

            if (txtDLimit.Text.Length <= 0)
            {
                lblDLimitMsg.Text = "Daily Limit cannot be blank";
            }

            string category = ddlFCategory.SelectedValue;

            if (txtFTitle.Text.Length > 0 && txtPrice.Text.Length > 0 && txtDLimit.Text.Length > 0)
            {
                FoodItemBLL foodItemBLL = new FoodItemBLL();
                int result = foodItemBLL.DoUpdateFoodItem(Convert.ToInt32(txtFId.Text), Convert.ToInt32(txtRestId.Text), category, 
                    txtFTitle.Text, Convert.ToDouble(txtPrice.Text), Convert.ToInt32(txtDLimit.Text));

                if (result > 0)
                {
                    alertFoodSuccess.Visible = true;
                }

                else
                {
                    alertFoodFailure.Visible = true;
                    lblFoodFailure.Text = "Unable to update food item record";
                }

                //Refresh the table
                panelViewFoodItem.Visible = true;
                DataTable dt = new DataTable();
                dt = foodItemBLL.DoRetrieveAllFoodItemByRestId(Convert.ToInt32(txtRestId.Text));
                gv_foodItem.DataSource = dt;
                gv_foodItem.DataBind();
            }

        }

        protected void lnk_Update_Click(object sender, EventArgs e)
        {
            panelViewFoodItem.Visible = true;

            int foodId = Convert.ToInt32((sender as LinkButton).CommandArgument);
            FoodItemBLL foodItemBLL = new FoodItemBLL();
            FoodItem foodItem = foodItemBLL.DoRetrieveFoodItemByFoodId(foodId);

            panelUpdateFoodItem.Visible = true;

            txtFId.Text = foodId.ToString();
            ddlFCategory.SelectedValue = foodItem.FoodCategory;
            txtFTitle.Text = foodItem.FoodTitle;
            txtPrice.Text = foodItem.Price.ToString();
            txtDLimit.Text = foodItem.DailyLimit.ToString();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateFoodItem.aspx");
        }
    }
}