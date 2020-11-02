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
    public partial class RetrieveLatestMWSWWS : System.Web.UI.Page
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

            alertFailure.Visible = false;
            gv_schedule.Visible = false;

            if (rider.IsFullTime == false)
            {
                Response.Redirect("RetrieveLatestPTWWS.aspx");
            }

            if (!IsPostBack)
            {
                MWSBLL mwsbll2 = new MWSBLL();
                DataTable mwsdt = new DataTable();
                mwsdt = mwsbll2.DoRetrieveAllMWSByRId(user.UserId);
                for (int i = 0; i < mwsdt.Rows.Count; i++)
                {
                    string theValue = mwsdt.Rows[i].ItemArray[0].ToString();
                    ddlOption.Items.Add(theValue);
                }
            }

            if (ddlOption.SelectedItem.Text == "Remaining Schedule")
            {
                DataTable dt = new DataTable();

                WWSBLL wwsbll = new WWSBLL();
                MWSBLL mwsbll = new MWSBLL();
                MWS latestmws = mwsbll.DoRetrieveLatestMWSByRId(user.UserId);
                //dt = wwsbll.DoRetrieveAllWWSByMWSId(latestmws.MwsId);
                //string value = "4/26/2020";
                //DateTime datetest = DateTime.Parse(value);
                //DateTime datetest = new DateTime(2020, 4, 26);

                //currently it is based on today's date. If I want to perform testing, I have to manually change the Datetime to some other dates instead
                if (latestmws != null)
                {
                    dt = wwsbll.DoRetrieveUnfulfilledWWSByMWSId(latestmws.MwsId, DateTime.Now);

                    if (dt != null)
                    {
                        gv_schedule.DataSource = dt;
                        gv_schedule.DataBind();
                        gv_schedule.Visible = true;
                    }


                    else
                    {
                        alertFailure.Visible = true;
                        lblAlertMsg.Text = "Error in retrieving current schedule list";
                    }
                }

                else
                {
                    alertFailure.Visible = true;
                    lblAlertMsg.Text = "Error in retrieving schedule list";
                }
            }

            else if (ddlOption.SelectedItem.Text != "Select Schedule to View")
            {
                DataTable dt = new DataTable();
                WWSBLL wwsbll = new WWSBLL();
                //dt = wwsbll.DoRetrieveAllWWSByMWSId(latestmws.MwsId);
                //string value = "4/26/2020";
                //DateTime datetest = DateTime.Parse(value);

                DateTime datetest = new DateTime(2020, 4, 26);
                dt = wwsbll.DoRetrieveAllWWSByMWSId(Convert.ToInt32(ddlOption.SelectedValue));
                if (dt != null)
                {
                    gv_schedule.DataSource = dt;
                    gv_schedule.DataBind();
                    gv_schedule.Visible = true;
                }
                
                else
                {
                    alertFailure.Visible = true;
                    lblAlertMsg.Text = "Error in retrieving list";
                }
            }
        }
    }
}