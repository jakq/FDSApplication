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
    public partial class UserViewAllOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isLogin"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            gv_currentOrders.Visible = false;
            gv_pastOrders.Visible = false;

        }

        protected void btnCurrentOrder_Click(object sender, EventArgs e)
        {
            UserAccount user = (UserAccount)Session["UserAccountObj"];
            OrdersBLL ordersBLL = new OrdersBLL();

            DataTable dt = new DataTable();
            dt = ordersBLL.DoRetrieveCustomerCurrentOrder(user.UserId);
            gv_currentOrders.DataSource = dt;
            gv_currentOrders.DataBind();
            gv_currentOrders.Visible = true;
        }

        protected void gv_currentOrders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowNo = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = gv_currentOrders.Rows[rowNo];
            row.Cells[2].Text = Convert.ToDateTime(row.Cells[2].Text).ToString("dd/MM/yyyy HH:mm");

            if (e.CommandName == "Details")
            {
                int orderId = int.Parse(row.Cells[0].Text);
                Response.Redirect("UserViewOrderDetails.aspx?orderid=" + orderId);
            }
        }

        protected void btnPastOrders_Click(object sender, EventArgs e)
        {
            UserAccount user = (UserAccount)Session["UserAccountObj"];
            OrdersBLL ordersBLL = new OrdersBLL();

            DataTable dt = new DataTable();
            dt = ordersBLL.DoRetrieveCustomerCompletedOrder(user.UserId);
            gv_pastOrders.DataSource = dt;
            gv_pastOrders.DataBind();
            gv_pastOrders.Visible = true;
        }

        protected void gv_pastOrders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowNo = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = gv_pastOrders.Rows[rowNo];
            row.Cells[2].Text = Convert.ToDateTime(row.Cells[2].Text).ToString("dd/MM/yyyy HH:mm");

            if (e.CommandName == "Details")
            {
                int orderId = int.Parse(row.Cells[0].Text);
                Response.Redirect("UserViewOrderDetails.aspx?orderid=" + orderId);
            }
            if (e.CommandName == "Review")
            {
                ReviewBLL reviewBLL = new ReviewBLL();
                int orderId = int.Parse(row.Cells[0].Text);
                if (reviewBLL.DoCheckReviewExists(orderId) == 0)
                {
                    Response.Redirect("UserCreateReview.aspx?orderid=" + orderId);
                }
                else
                {
                    Response.Redirect("UserRetrieveReview.aspx?orderid=" + orderId);
                }

            }
        }
    }
}