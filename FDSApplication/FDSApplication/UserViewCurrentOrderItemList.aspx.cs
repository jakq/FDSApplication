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
    public partial class UserViewCurrentOrderItemList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserAccount user = (UserAccount)Session["UserAccountObj"];

            if (Session["isLogin"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            alertFailure.Visible = false;

            string transactionId = "";
            if (Session["generatedId"] == null)
            {
                lblNoList.Text = "There is no order list currently. Add items into the order list";
                btnClear.Visible = false;
                btnCheckout.Visible = false;
                panelTotalAmt.Visible = false;
                panelTransactionId.Visible = false;
            }
 
            else
            {                
                transactionId = Session["generatedId"].ToString();
                lbltransactionId.Text = transactionId.ToString();

                DataTable dt = new DataTable();
                OrderItemListBLL orderItemListBLL = new OrderItemListBLL();
                dt = orderItemListBLL.DoRetrieveCustomerOrderItem(transactionId, user.UserId);

                loadOrderItemList(dt);              
            }       
        }

        public void loadOrderItemList(DataTable dt)
        {
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

                    lblTotalAmt.Text = currTotal.ToString();
                }

                else
                {
                    lblNoList.Text = "There is no order list currently. Add items into the order list";
                    btnClear.Visible = false;
                    btnCheckout.Visible = false;
                    panelTotalAmt.Visible = false;
                    panelTransactionId.Visible = false;
                }
            }

            else
            {
                lblNoList.Text = "Unable to retrieve out order item record";
            }
        }

        protected void gv_currFoodItemList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowNo = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = gv_currFoodItemList.Rows[rowNo];
            int foodId = int.Parse(row.Cells[2].Text);
            int orderQuantity = int.Parse(row.Cells[6].Text);

            UserAccount user = (UserAccount)Session["UserAccountObj"];

            if (e.CommandName == "AddQuantity")
            {
                OrderItemListBLL orderItemListBLL = new OrderItemListBLL();
                int result = orderItemListBLL.DoUpdateFoodItemQuantityByIncreaseCount(Session["generatedId"].ToString(), user.UserId, foodId, orderQuantity);
                if (result > 0)
                {
                    Response.Redirect("UserViewCurrentOrderItemList.aspx");
                }

                else
                {
                    alertFailure.Visible = true;
                    lblFailure.Text = "Unable to increase count";
                }

            }

            if (e.CommandName == "MinusQuantity")
            {
                OrderItemListBLL orderItemListBLL = new OrderItemListBLL();
                int result = orderItemListBLL.DoUpdateFoodItemQuantityByDecreaseCount(Session["generatedId"].ToString(), user.UserId, foodId, orderQuantity);
                if (result > 0)
                {
                    Response.Redirect("UserViewCurrentOrderItemList.aspx");
                }

                else
                {
                    alertFailure.Visible = true;
                    lblFailure.Text = "Unable to decrease count";
                }

            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            OrderItemListBLL orderItemListBLL = new OrderItemListBLL();
            int result = orderItemListBLL.DoClearExistingOrderItemList(Session["generatedId"].ToString());

            if (result > 0)
            {
                Response.Redirect("UserViewCurrentOrderItemList.aspx");
            }

            else
            {
                alertFailure.Visible = true;
                lblFailure.Text = "Unable to clear list";
            }
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            OrderItemListBLL orderItemListBLL = new OrderItemListBLL();
            Restaurant restaurant = orderItemListBLL.DoCheckOrderLineItemForExistingRestaurant(Session["generatedId"].ToString());

            double totalAmt = double.Parse(lblTotalAmt.Text);
            
            if (totalAmt >= restaurant.MinAmnt)
            {
                Response.Redirect("UserCheckout.aspx");
            }

            else
            {
                alertFailure.Visible = true;
                lblFailure.Text = "Your order does not exceed the minimum amount";
            }
        }
    }
}