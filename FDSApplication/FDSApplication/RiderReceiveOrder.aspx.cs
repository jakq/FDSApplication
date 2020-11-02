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
    public partial class RiderReceiveOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["isLogin"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            UserAccount user = (UserAccount)Session["UserAccountObj"];
            OrdersBLL obll = new OrdersBLL();
            String riderCurrentTrans;
            riderCurrentTrans = obll.DoRetrieveRiderCurrentOrderTransactionId(user.UserId);
            RiderBLL riderbll = new RiderBLL();
            Rider rider = riderbll.DoRetrieveRiderByID(user.UserId);

            if (riderCurrentTrans != null)
            {
                lblNotWorking.Text = "You have a current delivery ongoing!";
                gv_orderlist.Visible = false;
            }

            else if(rider.IsFullTime == true)
            {
                WWSBLL wwsbll = new WWSBLL();
                MWSBLL mwsbll = new MWSBLL();
                MWS mws = mwsbll.DoRetrieveLatestMWSByRId(user.UserId);
                DateTime timetest = new DateTime(2020, 4, 13, 16, 30, 00);
                int isWorking = 0;

                if (mws != null)
                {
                    //replace with timetest to test. Modify timetest according to the schedule time.
                    isWorking = wwsbll.doIsRiderCurrentlyWorking(mws.MwsId, DateTime.Now);
                    //isWorking = wwsbll.doIsRiderCurrentlyWorking(mws.MwsId, timetest);
                }

                if(isWorking == 0) 
                {
                    lblNotWorking.Text = "Please refer to your schedule again!";
                    gv_orderlist.Visible = false;
                }                
            }

            else if (rider.IsFullTime == false)
            {
                PTWWSBLL ptwwsbll = new PTWWSBLL();
                PTDayScheduleBLL ptdsbll = new PTDayScheduleBLL();

                DateTime timetest = new DateTime(2020, 4, 13, 11, 00, 00);
                int isWorking = 0;

                //replace with timetest to test. Modify timetest according to the schedule time.
                isWorking = ptdsbll.doIsPartTimeRiderCurrentlyWorking(user.UserId, DateTime.Now);

                if(isWorking == 0)
                {
                    lblNotWorking.Text = "Please refer to your schedule again!";
                    gv_orderlist.Visible = false;
                }
            }

            if(!IsPostBack)
            {
                DataTable dt = new DataTable();
                dt = obll.DoRetrieveNoRiderAllCustomerOrder();

                if (dt != null)
                {
                    gv_orderlist.DataSource = dt;
                    gv_orderlist.DataBind();
                }
            }
        }

        protected void gv_orderlist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowNo = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = gv_orderlist.Rows[rowNo];
            
            if (e.CommandName == "MoreInfo")
            {
                string transId = row.Cells[1].Text.ToString();
                Response.Redirect("RiderCheckOrderDetails.aspx?transactionid="+transId);
            }
        }
    }
}