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
    public partial class StaffViewRestaurantReview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isLogin"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            UserAccount user = (UserAccount)Session["UserAccountObj"];
            if (!user.UserRole.Equals("Staff"))
            {
                lblAccessRight.Text = "YOU DO NOT HAVE STAFF RIGHTS TO ACCESS THIS FUNCTION";
                btn_back.Visible = false;
            }

            else
            {
                StaffBLL staffbll = new StaffBLL();
                Staff staff = staffbll.DoRetrieveStaffByID(user.UserId);

                DataTable dt = new DataTable();
                ReviewBLL reviewBLL = new ReviewBLL();
                int restId = Convert.ToInt32(staff.RestId);
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
            Response.Redirect("StaffIndex.aspx");
        }
    }
}