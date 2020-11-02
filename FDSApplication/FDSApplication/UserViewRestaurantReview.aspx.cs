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
    public partial class UserViewRestaurantReview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isLogin"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                ReviewBLL reviewBLL = new ReviewBLL();
                int restId = Convert.ToInt32(Request.QueryString["restId"]);
                dt = reviewBLL.DoRetrieveRestaurantRating(restId);

                if (dt != null)
                {
                    gv_restaurants.DataSource = dt;
                    gv_restaurants.DataBind();
                }
            }
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserCreateOrder.aspx");
        }
    }
}