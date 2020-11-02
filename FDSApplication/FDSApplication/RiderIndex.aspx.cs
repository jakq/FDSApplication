using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FDSApplication.BusinessLogicLayer;
using FDSApplication.Models;

namespace FDSApplication
{
    public partial class RiderIndex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isLogin"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            UserAccount user = (UserAccount)Session["UserAccountObj"];
            lblUserName.Text = user.Username.ToUpper();
            lblUserRole.Text = user.UserRole.ToUpper();

            ReviewBLL reviewBLL = new ReviewBLL();
            double rating = reviewBLL.DoRetrieveRiderAvgRating(user.UserId);

            if (rating == 0)
            {
                lblRating.Text = "NIL";
            } 
            
            else
            {
                lblRating.Text = rating.ToString();
            }

            StatsBLL statsBLL = new StatsBLL();
            int totalAvailOrders = statsBLL.DoCountTotalAvailableOrders();
            lblTotalAvailOrders.Text = totalAvailOrders.ToString();

            int totalOrdersDone = statsBLL.DoCountOrdersDoneByRider(user.UserId);
            lblOrdersDone.Text = totalOrdersDone.ToString();

            int totalOrders = statsBLL.DoCountTotalOrders();
            lbltotalOrders.Text = totalOrders.ToString();

            double totalOrderAmt = statsBLL.DoCountTotalOrderAmount();
            lbltotalOrderAmt.Text = "$" + totalOrderAmt.ToString();
        }

        protected void btnViewMthStats_Click(object sender, EventArgs e)
        {
            Response.Redirect("RiderViewStats.aspx");
        }
    }
}