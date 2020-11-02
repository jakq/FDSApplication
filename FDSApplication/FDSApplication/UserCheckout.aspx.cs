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
    public partial class UserCheckout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isLogin"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (Session["generatedId"] == null)
            {
                Response.Redirect("UserIndex.aspx");
            }

            panelCard.Visible = false;
            alertSuccess.Visible = false;
            alertFailure.Visible = false;
            txtPromoCode.Text = "";

            lblTransactionId.Text = Session["generatedId"].ToString();

            LoadFoodOrderList();
            LoadPromoList();
            
        }

        public void LoadFoodOrderList()
        {
            UserAccount user = (UserAccount)Session["UserAccountObj"];

            DataTable dt = new DataTable();
            OrderItemListBLL orderItemListBLL = new OrderItemListBLL();
            dt = orderItemListBLL.DoRetrieveCustomerOrderItem(Session["generatedId"].ToString(), user.UserId);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    gv_currFoodItemList.DataSource = dt;
                    gv_currFoodItemList.DataBind();

                    double currTotal = 0.0;
                    for (int i = 0; i < gv_currFoodItemList.Rows.Count; i++)
                    {
                        currTotal += double.Parse(gv_currFoodItemList.Rows[i].Cells[5].Text.ToString()) *
                            int.Parse(gv_currFoodItemList.Rows[i].Cells[6].Text.ToString());
                    }

                    lblOrderTotalAmt.Text = currTotal.ToString();

                    if (gv_currFoodItemList.Rows.Count > 5)
                    {
                        lblDeliveryFee.Text = "10.00";
                    }

                    else
                    {
                        lblDeliveryFee.Text = "5.00";
                    }
                }

                else
                {
                    btnCheckout.Visible = false;             
                }
            }

            else
            {
                btnCheckout.Visible = false;
                alertFailure.Visible = true;
                lblErrorRetrieve.Text = "Unable to retrieve list";
            }
        }

        public void LoadPromoList()
        {
            OrderItemListBLL orderItemListBLL = new OrderItemListBLL();
            int restId = orderItemListBLL.DoRetrieveRestaurantID(lblTransactionId.Text);

            DataTable dt = new DataTable();
            PromoBLL promoBLL = new PromoBLL();
            dt = promoBLL.DoRetrieveValidPromoByRestId(restId, DateTime.Now);

            gv_promo.DataSource = dt;
            gv_promo.DataBind();
            gv_promo.Visible = false;
        }


        protected void ddlPaymentMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPaymentMode.SelectedValue == "Card")
            {
                panelCard.Visible = true;

                UserAccount user = (UserAccount)Session["UserAccountObj"];

                DataTable dt = new DataTable();
                CreditCardBLL creditCardBLL = new CreditCardBLL();
                dt = creditCardBLL.DoRetrieveAllCustomerCreditCard(user.UserId);

                ddlCardNum.DataSource = dt;
                ddlCardNum.DataTextField = "ccNum";
                ddlCardNum.DataValueField = "ccNum";
                ddlCardNum.DataBind();
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserViewCurrentOrderItemList.aspx");
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            string paymentMode;
            string cardNum;
            string hasPaid;

            DateTime orderCreated = DateTime.Now;

            if (txtDeliverAddress.Text.Length <= 0)
            {
                lblDeliverAddressMsg.Text = "Delivery Address cannot be blank";
            }

            if (txtContactNo.Text.Length <= 0)
            {
                lblContactNoMsg.Text = "Contact Number cannot be blank";
            }

            if (ddlPaymentMode.SelectedValue == "Cash")
            {
                paymentMode = ddlPaymentMode.SelectedValue;
                cardNum = "0";
                hasPaid = "NP";
            }

            else
            {
                paymentMode = ddlPaymentMode.SelectedValue;
                cardNum = ddlCardNum.SelectedValue;
                hasPaid = "P";
            }

            if (txtDeliverAddress.Text.Length > 0 && txtContactNo.Text.Length > 0)
            {
                DoCheckOutOperation(); //Change OrderItemList checkout status
                DoUpdateOrderCountOperation(); //Increase the ordercounter in FoodItem

                UserAccount user = (UserAccount)Session["UserAccountObj"];

                OrdersBLL ordersBLL = new OrdersBLL();
                int result = ordersBLL.DoCreateOrder(user.UserId, Session["generatedId"].ToString(), paymentMode, cardNum, txtDeliverAddress.Text, 
                    txtContactNo.Text, double.Parse(lblDeliveryFee.Text), double.Parse(lblOrderTotalAmt.Text), orderCreated, hasPaid, "Pending Rider");

                if (result > 0)
                {
                    alertSuccess.Visible = true;
                    btnCheckout.Enabled = false;
                    btnBack.Enabled = false;
                    UpdateRewardPointRecentLocation(user);
                }

                else
                {
                    alertFailure.Visible = true;
                    lblErrorRetrieve.Text = "Unable to create new order record";
                }
            }
        }

        public void DoCheckOutOperation()
        {
            OrderItemListBLL orderItemListBLL = new OrderItemListBLL();
            int result = orderItemListBLL.DoUpdateFoodItemListCheckOut(Session["generatedId"].ToString());

            if (result < 0)
            {
                alertFailure.Visible = true;
                lblErrorRetrieve.Text = "Unable to update checkout status";
            }
        }

        public void DoUpdateOrderCountOperation()
        {
            FoodItemBLL foodItemBLL = new FoodItemBLL();
            for (int i = 0; i < gv_currFoodItemList.Rows.Count; i++)
            {
                int foodId = int.Parse(gv_currFoodItemList.Rows[i].Cells[2].Text.ToString());
                FoodItem foodItem = foodItemBLL.DoRetrieveFoodItemByFoodId(foodId);

                foodItem.OrderCounter += int.Parse(gv_currFoodItemList.Rows[i].Cells[6].Text.ToString());
                int result = foodItemBLL.DoUpdateOrderCount(foodId, foodItem.OrderCounter);

                if (result < 0)
                {
                    alertFailure.Visible = true;
                    lblErrorRetrieve.Text = "Unable to update order count for food item code " + foodId;
                    break;
                }
            }
        }

        public void UpdateRewardPointRecentLocation(UserAccount user)
        {
            
            CustomerBLL customerBLL = new CustomerBLL();
            Customer customer = customerBLL.DoRetrieveCustomerByID(user.UserId);
            
            int setRewardPts = Convert.ToInt32(double.Parse(lblOrderTotalAmt.Text) / 2);
            int newRewardPts = customer.RewardPoint + setRewardPts;

            string recentLocation = txtDeliverAddress.Text;

            int result = customerBLL.DoUpdateCustomerRewardPointRecentLocation(user.UserId, newRewardPts, recentLocation);

            if (result < 0)
            {
                alertFailure.Visible = true;
                lblErrorRetrieve.Text = "Unable to update reward point and recent location";
            }
        }

        protected void btnPromoCode_Click(object sender, EventArgs e)
        {        
            if (ddlPaymentMode.SelectedValue == "Card")
            {
                panelCard.Visible = true;

                UserAccount user = (UserAccount)Session["UserAccountObj"];

                DataTable dt = new DataTable();
                CreditCardBLL creditCardBLL = new CreditCardBLL();
                dt = creditCardBLL.DoRetrieveAllCustomerCreditCard(user.UserId);

                ddlCardNum.DataSource = dt;
                ddlCardNum.DataTextField = "ccNum";
                ddlCardNum.DataValueField = "ccNum";
                ddlCardNum.DataBind();
            }

            gv_promo.Visible = true;

        }

        protected void gv_promo_DataBound(object sender, EventArgs e)
        {
            gv_promo.Columns[4].Visible = false;
            gv_promo.Columns[5].Visible = false;
        }

        protected void gv_promo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowNo = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = gv_promo.Rows[rowNo];
            int promoId = int.Parse(row.Cells[0].Text);

            if (e.CommandName == "Select")
            {
                txtPromoCode.Text = row.Cells[6].Text;
                double totalAmt = double.Parse(lblOrderTotalAmt.Text);

                if (row.Cells[2].Text.Equals("Flat"))
                {
                    totalAmt = totalAmt - double.Parse(row.Cells[3].Text);
                }

                else
                {
                    totalAmt = totalAmt * (100.0 - double.Parse(row.Cells[3].Text)) / 100.0;
                }

                lblOrderTotalAmt.Text = totalAmt.ToString();

                if (ddlPaymentMode.SelectedValue == "Card")
                {
                    panelCard.Visible = true;

                    UserAccount user = (UserAccount)Session["UserAccountObj"];

                    DataTable dt = new DataTable();
                    CreditCardBLL creditCardBLL = new CreditCardBLL();
                    dt = creditCardBLL.DoRetrieveAllCustomerCreditCard(user.UserId);

                    ddlCardNum.DataSource = dt;
                    ddlCardNum.DataTextField = "ccNum";
                    ddlCardNum.DataValueField = "ccNum";
                    ddlCardNum.DataBind();
                }
            }
        }


        protected void grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_promo.PageIndex = e.NewPageIndex;
            gv_promo.DataBind();
        }

    }
}