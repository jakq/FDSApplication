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
    public partial class RetrieveLatestPTWWS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isLogin"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            UserAccount user = (UserAccount)Session["UserAccountObj"];
            RiderBLL riderbll = new RiderBLL();
            Rider rider = riderbll.DoRetrieveRiderByID(user.UserId);

            if (rider.IsFullTime == true)
            {
                Response.Redirect("RetrieveLatestMWSWWS.aspx");
            }

            if (!IsPostBack)
            {
                PTWWSBLL ptwwsbll = new PTWWSBLL();
                DataTable ptwwsdt = new DataTable();
                ptwwsdt = ptwwsbll.DoRetrieveAllPTWWSByRId(user.UserId);

                for (int i = 0; i < ptwwsdt.Rows.Count; i++)
                {
                    string theValue = ptwwsdt.Rows[i].ItemArray[0].ToString();
                    ddlOption.Items.Add(theValue);
                }
            }

            if (ddlOption.SelectedItem.Text == "Remaining Schedule")
            {
                DataTable dt = new DataTable();
                PTDayScheduleBLL ptdsbll = new PTDayScheduleBLL();
                PTWWSBLL ptwwsbll = new PTWWSBLL();

                PTWWS latestptwws = ptwwsbll.DoRetrieveLatestPTWWSByRId(user.UserId);
                //currently it is based on today's date. If I want to perform testing, I have to manually change the Datetime to some other dates instead
                //DateTime datetest = new DateTime(2020, 4, 26);
                if (latestptwws != null)
                {
                    dt = ptdsbll.DoRetrieveUnfulfilledPTWWSByPTWWSId(latestptwws.PtwwsId, DateTime.Now);
                }

                if (dt != null)
                {
                    gv_schedule.DataSource = dt;
                    gv_schedule.DataBind();
                }

                else
                {
                    lblNotWorking.Text = "Unable to retrieve list of schedule";
                }
            }

            else if (ddlOption.SelectedItem.Text != "Select Schedule to View")
            {

                DataTable dt = new DataTable();
                PTDayScheduleBLL ptdsbll = new PTDayScheduleBLL();
                //dt = wwsbll.DoRetrieveAllWWSByMWSId(latestmws.MwsId);
                //string value = "4/26/2020";
                //DateTime datetest = DateTime.Parse(value);
                DateTime datetest = new DateTime(2020, 4, 26);
                dt = ptdsbll.DoRetrievePTWWSByPTWWSId(Convert.ToInt32(ddlOption.SelectedValue.ToString()));

                if (dt != null)
                {
                    gv_schedule.DataSource = dt;
                    gv_schedule.DataBind();
                }

                else
                {
                    lblNotWorking.Text = "Unable to retrieve list of scheudle";
                }
            }
        }
    }
}