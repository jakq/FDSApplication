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
    public partial class RiderViewStats : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isLogin"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            panelViewStats.Visible = false;
        }

        protected void btnRetrieve_Click(object sender, EventArgs e)
        {
            UserAccount user = (UserAccount)Session["UserAccountObj"];
            int rid = user.UserId;
            int year = int.Parse(ddlYear.SelectedValue);
            int month = int.Parse(ddlMonth.SelectedValue);

            StatsBLL sbll = new StatsBLL();
            RiderBLL rbll = new RiderBLL();
            Rider rider = rbll.DoRetrieveRiderByID(rid);

            panelViewStats.Visible = true;

            if (rider.IsFullTime)
            {
                lblOrders.Text = sbll.DoCountOrderForRiderMonth(rid, year, month).ToString();
                lblHours.Text = sbll.DoCountHoursWorkedForFTRiderMonth(rid, year, month).ToString();
                lblDeliverTime.Text = sbll.DoCountRiderAverageDeliverTimeByMonth(rid, year, month).ToString("HH:mm:ss");

                if (lblOrders.Text.Equals("0"))
                {
                    lblDeliverTime.Text = "-";
                }

                lblReviewNum.Text = sbll.DoCountRatingsForRiderMonth(rid, year, month).ToString();
                lblRating.Text = Math.Round(sbll.DoCountAverageRiderRatingMonth(rid, year, month), 2).ToString();
                lblSalary.Text = sbll.DoCountFTRiderSalaryMonth(rid, year, month).ToString();
            }

            else
            {
                lblOrders.Text = sbll.DoCountOrderForRiderMonth(rid, year, month).ToString();
                lblHours.Text = sbll.DoCountHoursWorkedForPTRiderMonth(rid, year, month).ToString();
                lblDeliverTime.Text = sbll.DoCountRiderAverageDeliverTimeByMonth(rid, year, month).ToString("HH:mm:ss");

                if (lblOrders.Text.Equals("0"))
                {
                    lblDeliverTime.Text = "-";
                }

                lblReviewNum.Text = sbll.DoCountRatingsForRiderMonth(rid, year, month).ToString();
                lblRating.Text = Math.Round(sbll.DoCountAverageRiderRatingMonth(rid, year, month), 2).ToString();
                lblSalary.Text = sbll.DoCountPTRiderSalaryMonth(rid, year, month).ToString();
            }
        }

        protected void Close_Click(object sender, EventArgs e)
        {
            Response.Redirect("RiderViewStats.aspx");
        }
    }
}