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
    public partial class RiderDeliveryHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isLogin"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            UserAccount user = (UserAccount)Session["UserAccountObj"];

            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                OrdersBLL obll = new OrdersBLL();
                dt = obll.DoRetrieveRiderAllCompletedCustomerOrder(user.UserId);

                if (dt != null)
                {
                    gv_orderlist2.DataSource = dt;
                    gv_orderlist2.DataBind();
                }

                else
                {
                    lblNotWorking.Text = "Unable to retrieve past deliveries";
                }
            }
        }

        protected void gv_orderlist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowNo = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = gv_orderlist2.Rows[rowNo];

            if (e.CommandName == "MoreInfo")
            {
                string transId = row.Cells[1].Text.ToString();
                Response.Redirect("RiderDeliveryHistoryMoreInfo.aspx?transactionid=" + transId);
            }
        }
    }
}