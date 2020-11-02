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
    public partial class UserCreateReview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isLogin"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            UserAccount user = (UserAccount)Session["UserAccountObj"];
            txtOrderId.Text = Request.QueryString["orderid"].ToString();

            Orders od = new Orders();
            OrdersBLL odbll = new OrdersBLL();
            od = odbll.DoRetrieveUserOrderDetails(int.Parse(txtOrderId.Text));

            Rider rider = new Rider();
            RiderBLL riderBLL = new RiderBLL();
            rider = riderBLL.DoRetrieveRiderByID(od.RId);

            txtTransactionID.Text = od.TransactionId;
            txtRiderID.Text = od.RId.ToString();
            txtRiderName.Text = rider.RName;

        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserViewAllOrders.aspx");
        }

        protected void btn_Review_Click(object sender, EventArgs e)
        {
            Orders od = new Orders();
            OrdersBLL odbll = new OrdersBLL();
            RestaurantBLL rbll = new RestaurantBLL();
            od = odbll.DoRetrieveUserOrderDetails(int.Parse(txtOrderId.Text));
            ReviewBLL reviewBLL = new ReviewBLL();
            reviewBLL.DoCreateReview(od.OrderId, od.CId, od.RId, rbll.DoRetrieveRestIdByTransactionId(od.TransactionId), Convert.ToInt32(ddlRiderRating.SelectedValue) , Convert.ToInt32(ddlRestaurantRating.SelectedValue), txtReview.Text);
            Response.Redirect("UserRetrieveReview.aspx?orderid=" + od.OrderId);
        }


    }
}