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
    public partial class UserIndex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isLogin"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            UserAccount user = (UserAccount)Session["UserAccountObj"];
            lblUserName.Text = user.Username.ToUpper();

            if (Session["generatedId"] == null)
            {
                OrderItemListBLL orderItemListBLL = new OrderItemListBLL();
                OrderItemList orderItemList = orderItemListBLL.DoRetrieveExisitngCustomerFoodItemListByCustId(user.UserId);

                if (orderItemList != null)
                {
                    Session["generatedId"] = orderItemList.TransactionId;
                }
            }

            StatsBLL statsBLL = new StatsBLL();
            string recentLocation = statsBLL.DoRetrieveRecentLocation(user.UserId);
            if (recentLocation == "")
            {
                lblRecentLocation.Text = "You have no recent location";
                btnClearHistory.Enabled = false;
            }

            else
            {
                lblRecentLocation.Text = recentLocation;
            }
           
            int ordersMade = statsBLL.DoCountCustomersOrder(user.UserId);
            lblOrdersMade.Text = ordersMade.ToString();

            int reviewMade = statsBLL.DoCountCustomersReviews(user.UserId);
            lblReviewsMade.Text = reviewMade.ToString();
        }

        protected void btnClearHistory_Click(object sender, EventArgs e)
        {
            UserAccount user = (UserAccount)Session["UserAccountObj"];

            CustomerBLL customerBLL = new CustomerBLL();
            int result = customerBLL.DoDeleteCustomerRecentLocation(user.UserId);

            if (result > 0)
            {
                lblRecentLocation.Text = "You have no recent location";
            }

            btnClearHistory.Enabled = false;
        }
    }
}