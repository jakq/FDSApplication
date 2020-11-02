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
    public partial class StaffIndex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isLogin"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            panelResetLimit.Visible = false;
            adminViewStats.Visible = false;
            staffViewStats.Visible = false;
            gv_FoodItemStats.Visible = false;
            gv_CustMostOrder.Visible = false;

            UserAccount user = (UserAccount)Session["UserAccountObj"];
            lblUserName.Text = user.Username.ToUpper();
            lblUserRole.Text = user.UserRole.ToUpper();

            if (user.UserRole.Equals("Manager"))
            {
                panelResetLimit.Visible = true;

                LastAccessBLL lastAccessBLL = new LastAccessBLL();
                int result = lastAccessBLL.DoCheckLastAccessExists();

                if (result <= 0)
                {
                    int createResult = lastAccessBLL.DoCreateLastAccessRecord(DateTime.Now);
                    txtLastUpdate.Text = "-";
                    btnResetLimit.Enabled = false;
                }

                else
                {
                    LastAccess lastAccess = lastAccessBLL.DoRetrieveLastAccess();
                    txtLastUpdate.Text = lastAccess.AccessDate.ToString("dd-MM-yyyy");
                }
            }
            
        }

        protected void btnResetLimit_Click(object sender, EventArgs e)
        {
            DateTime currDate = DateTime.Now;
            LastAccessBLL lastAccessBLL = new LastAccessBLL();
            LastAccess lastAccess = lastAccessBLL.DoRetrieveLastAccess();

            if (currDate.ToString("yyyy-MM-dd").Equals(lastAccess.AccessDate.ToString("yyyy-MM-dd")))
            {
                lblResetFailed.Text = "Reset is unsuccessful. Last reset date is the same as current date";
            }

            else
            {
                int result = lastAccessBLL.DoUpdateLastAccess(currDate);
                if (result > 0)
                {
                    lastAccessBLL.DoUpdateOrderCounter();
                }

                else
                {
                    lblResetFailed.Text = "Reset is unsuccessful";
                }
                lblResetSuccess.Text = "Reset is successful";
                txtLastUpdate.Text = currDate.ToString("dd-MM-yyyy");
            }

            panelResetLimit.Visible = true;
        }

        protected void btnViewStats_Click(object sender, EventArgs e)
        {
            UserAccount user = (UserAccount)Session["UserAccountObj"];

            if (user.UserRole.Equals("Manager"))
            {
                adminViewStats.Visible = true;

                StatsBLL statsBLL = new StatsBLL();
                int custNum = statsBLL.DoCountTotalCustomers();
                lblTotalCustomers.Text = custNum.ToString();

                int riderNum = statsBLL.DoCountTotalRiders();
                lblTotalRiders.Text = riderNum.ToString();

                int staffNum = statsBLL.DoCountTotalStaffs();
                lblTotalStaff.Text = staffNum.ToString();

                DataTable dt = new DataTable();
                dt = statsBLL.DoCountFoodItemsByCategory();
                if (dt != null)
                {
                    gv_FoodItemStats.DataSource = dt;
                    gv_FoodItemStats.DataBind();
                    gv_FoodItemStats.Visible = true;
                }

                int totalOrders = statsBLL.DoCountTotalOrders();
                lbltotalOrders.Text = totalOrders.ToString();

                double totalOrderAmt = statsBLL.DoCountTotalOrderAmount();
                lbltotalOrderAmt.Text = "$" + totalOrderAmt.ToString();

                DataTable dt2 = new DataTable();
                dt2 = statsBLL.DoFindCustomersMostOrders();
                if (dt2 != null)
                {
                    gv_CustMostOrder.DataSource = dt2;
                    gv_CustMostOrder.DataBind();
                    gv_CustMostOrder.Visible = true;
                }
            }

            else
            {
                StaffBLL staffBLL = new StaffBLL();
                Staff staff = staffBLL.DoRetrieveStaffByID(user.UserId);

                staffViewStats.Visible = true;

                StatsBLL statsBLL = new StatsBLL();
                int foodItemNum = statsBLL.DoCountTotalFoodItems(staff.RestId);
                lblFoodItemNum.Text = foodItemNum.ToString();

                int reviewNum = statsBLL.DoCountTotalReviews(staff.RestId);
                lblTotalReview.Text = reviewNum.ToString();

                DataTable dt = new DataTable();
                dt = statsBLL.DoFindPopularFoodItem(staff.RestId);
                if (dt != null)
                {
                    gv_popularFoodItems.DataSource = dt;
                    gv_popularFoodItems.DataBind();
                    gv_popularFoodItems.Visible = true;
                }
            }
        }
    }
}