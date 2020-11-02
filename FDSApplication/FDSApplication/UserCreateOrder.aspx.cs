using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FDSApplication.BusinessLogicLayer;
using FDSApplication.Models;
using System.Data;

namespace FDSApplication
{
    public partial class UserCreateOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isLogin"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            gv_listofRestaurant.Visible = false;
            gv_listOfFood.Visible = false;
            btnBack.Visible = false;
            alertFailure.Visible = false;
            alertSuccess.Visible = false;

            OrderItemListBLL orderItemListBLL = new OrderItemListBLL();

            if (Session["generatedId"] == null)
            {
                string transactionId = GenerateRandomString();
                int result = orderItemListBLL.DoCheckIfTransactionIDExists(transactionId);

                while (result > 0)
                {
                    transactionId = GenerateRandomString();
                    result = orderItemListBLL.DoCheckIfTransactionIDExists(transactionId);
                }

                Session["generatedId"] = transactionId;
            }

            else
            {
                Restaurant restaurant = orderItemListBLL.DoCheckOrderLineItemForExistingRestaurant((Session["generatedId"].ToString()));
                if (restaurant != null)
                {
                    btnSearch.Enabled = false;
                    btnBack.Enabled = false;

                    FoodItemBLL foodItemBLL = new FoodItemBLL();
                    DataTable dt = new DataTable();
                    dt = foodItemBLL.DoRetrieveAllFoodItemByRestId(restaurant.RestId);

                    if (dt != null)
                    {
                        lblRestName.Text = restaurant.RestName;
                        lblRestAddress.Text = restaurant.RestAddress;
                        gv_listOfFood.DataSource = dt;
                        gv_listOfFood.DataBind();
                        gv_listOfFood.Visible = true;
                    }

                    else
                    {
                        alertFailure.Visible = true;
                        lblErrorRetrieve.Text = "Error in retrieving food item list";
                    }
                }
            }
        }

        public string GenerateRandomString()
        {
            Random random = new Random();
            string alphabet = "abcdefghijklmnopqrstuvwxyz";

            int strLength = 10;

            string strRandom = "";

            for (int i = 0; i < strLength; i++)
            {
                int a = random.Next(26);
                strRandom = strRandom + alphabet.ElementAt(a);
            }

            return strRandom;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string area = ddlRArea.SelectedValue;
            DataTable dt = new DataTable();
            RestaurantBLL restaurantBLL = new RestaurantBLL();
            dt = restaurantBLL.DoRetrieveRestaurantByArea(area);

            if (dt != null)
            {
                gv_listofRestaurant.DataSource = dt;
                gv_listofRestaurant.DataBind();
                gv_listofRestaurant.Visible = true;
            }

            else
            {
                alertFailure.Visible = true;
                lblErrorRetrieve.Text = "Error in retrieving list";
            }
        }

        protected void gv_listofRestaurant_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowNo = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = gv_listofRestaurant.Rows[rowNo];
            int restId = int.Parse(row.Cells[0].Text);

            if (e.CommandName == "SelectFood")
            {
                lblRestName.Text = row.Cells[1].Text.ToString();
                lblRestAddress.Text = row.Cells[2].Text.ToString();

                FoodItemBLL foodItemBLL = new FoodItemBLL();
                DataTable dt = new DataTable();
                dt = foodItemBLL.DoRetrieveAllFoodItemByRestId(restId);

                if (dt != null)
                {
                    gv_listOfFood.DataSource = dt;
                    gv_listOfFood.DataBind();
                    gv_listOfFood.Visible = true;
                    btnSearch.Enabled = false;
                    btnBack.Visible = true;
                }

                else
                {
                    alertFailure.Visible = true;
                    lblErrorRetrieve.Text = "Error in retrieving food item list";
                }
            }   
            
            if(e.CommandName == "RestaurantReview")
            {
                int restIds = int.Parse(row.Cells[0].Text);
                Response.Redirect("UserViewRestaurantReview.aspx?restId=" + restIds);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserCreateOrder.aspx");
        }

        protected void gv_listOfFood_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowNo = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = gv_listOfFood.Rows[rowNo];
            int foodId = int.Parse(row.Cells[0].Text);

            if (e.CommandName =="SelectItem")
            {
                UserAccount user = (UserAccount)Session["UserAccountObj"];
                OrderItemListBLL orderItemListBLL = new OrderItemListBLL();
                int checkExist = orderItemListBLL.DoCheckIfFoodIDExists(Session["generatedId"].ToString(), foodId);

                if (checkExist > 0)
                {
                    alertFailure.Visible = true;
                    lblErrorRetrieve.Text = "Food item record has already exist in order list";
                }

                else
                {
                    int orderCount = int.Parse(row.Cells[5].Text);
                    int dailyLimit = int.Parse(row.Cells[6].Text);

                    if (orderCount > dailyLimit)
                    {
                        alertFailure.Visible = true;
                        lblErrorRetrieve.Text = "This food item is curretly no longer available";
                    }

                    else
                    {
                        int result = orderItemListBLL.DoCreateFoodItemRecord(Session["generatedId"].ToString(), user.UserId, foodId, 1);

                        if (result > 0)
                        {
                            alertSuccess.Visible = true;
                        }

                        else
                        {
                            alertFailure.Visible = true;
                            lblErrorRetrieve.Text = "Unable to add new food item record";
                        }
                    }                  
                }

                gv_listOfFood.Visible = true;
                btnBack.Enabled = false;
            }
        }

        protected void gv_listOfFood_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[6].Visible = false;
        }
    }
}