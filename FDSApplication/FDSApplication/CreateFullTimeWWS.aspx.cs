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
    public partial class CreateFullTimeWWS : System.Web.UI.Page
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

            if (rider.IsFullTime == false)
            {
                Response.Redirect("CreatePartTimeWWS.aspx");
            }

            if (ddlWorkDay.SelectedItem.Text != "Select")
            {
                if (ddlWorkDay.SelectedItem.Text == "1")
                {
                    DateTime startDay = GetNextWeekday(DateTime.Today.AddDays(1), DayOfWeek.Monday);
                    DateTime endDay = GetNextWeekday(startDay.AddDays(1), DayOfWeek.Monday);
                    endDay = GetNextWeekday(endDay.AddDays(1), DayOfWeek.Monday);
                    endDay = GetNextWeekday(endDay.AddDays(1), DayOfWeek.Monday);
                    endDay = GetNextWeekday(endDay.AddDays(1), DayOfWeek.Monday);
                    txtStartDate.Text = startDay.ToString("dd/MM/yyyy");
                    txtEndDate.Text = endDay.ToString("dd/MM/yyyy");
                }

                else if (ddlWorkDay.SelectedItem.Text == "2")
                {
                    DateTime startDay = GetNextWeekday(DateTime.Today.AddDays(1), DayOfWeek.Tuesday);
                    DateTime endDay = GetNextWeekday(startDay.AddDays(1), DayOfWeek.Tuesday);
                    endDay = GetNextWeekday(endDay.AddDays(1), DayOfWeek.Tuesday);
                    endDay = GetNextWeekday(endDay.AddDays(1), DayOfWeek.Tuesday);
                    endDay = GetNextWeekday(endDay.AddDays(1), DayOfWeek.Tuesday);
                    txtStartDate.Text = startDay.ToString("dd/MM/yyyy");
                    txtEndDate.Text = endDay.ToString("dd/MM/yyyy");
                }

                else if (ddlWorkDay.SelectedItem.Text == "3")
                {
                    DateTime startDay = GetNextWeekday(DateTime.Today.AddDays(1), DayOfWeek.Wednesday);
                    DateTime endDay = GetNextWeekday(startDay.AddDays(1), DayOfWeek.Wednesday);
                    endDay = GetNextWeekday(endDay.AddDays(1), DayOfWeek.Wednesday);
                    endDay = GetNextWeekday(endDay.AddDays(1), DayOfWeek.Wednesday);
                    endDay = GetNextWeekday(endDay.AddDays(1), DayOfWeek.Wednesday);
                    txtStartDate.Text = startDay.ToString("dd/MM/yyyy");
                    txtEndDate.Text = endDay.ToString("dd/MM/yyyy");
                }

                else if (ddlWorkDay.SelectedItem.Text == "4")
                {
                    DateTime startDay = GetNextWeekday(DateTime.Today.AddDays(1), DayOfWeek.Thursday);
                    DateTime endDay = GetNextWeekday(startDay.AddDays(1), DayOfWeek.Thursday);
                    endDay = GetNextWeekday(endDay.AddDays(1), DayOfWeek.Thursday);
                    endDay = GetNextWeekday(endDay.AddDays(1), DayOfWeek.Thursday);
                    endDay = GetNextWeekday(endDay.AddDays(1), DayOfWeek.Thursday);
                    txtStartDate.Text = startDay.ToString("dd/MM/yyyy");
                    txtEndDate.Text = endDay.ToString("dd/MM/yyyy");
                }

                else if (ddlWorkDay.SelectedItem.Text == "5")
                {
                    DateTime startDay = GetNextWeekday(DateTime.Today.AddDays(1), DayOfWeek.Friday);
                    DateTime endDay = GetNextWeekday(startDay.AddDays(1), DayOfWeek.Friday);
                    endDay = GetNextWeekday(endDay.AddDays(1), DayOfWeek.Friday);
                    endDay = GetNextWeekday(endDay.AddDays(1), DayOfWeek.Friday);
                    endDay = GetNextWeekday(endDay.AddDays(1), DayOfWeek.Friday);
                    txtStartDate.Text = startDay.ToString("dd/MM/yyyy");
                    txtEndDate.Text = endDay.ToString("dd/MM/yyyy");
                }

                else if (ddlWorkDay.SelectedItem.Text == "6")
                {

                    DateTime startDay = GetNextWeekday(DateTime.Today.AddDays(1), DayOfWeek.Saturday);
                    DateTime endDay = GetNextWeekday(startDay.AddDays(1), DayOfWeek.Saturday);
                    endDay = GetNextWeekday(endDay.AddDays(1), DayOfWeek.Saturday);
                    endDay = GetNextWeekday(endDay.AddDays(1), DayOfWeek.Saturday);
                    endDay = GetNextWeekday(endDay.AddDays(1), DayOfWeek.Saturday);
                    txtStartDate.Text = startDay.ToString("dd/MM/yyyy");
                    txtEndDate.Text = endDay.ToString("dd/MM/yyyy");
                }

                else if (ddlWorkDay.SelectedItem.Text == "7")
                {
                    DateTime startDay = GetNextWeekday(DateTime.Today.AddDays(1), DayOfWeek.Sunday);
                    DateTime endDay = GetNextWeekday(startDay.AddDays(1), DayOfWeek.Sunday);
                    endDay = GetNextWeekday(endDay.AddDays(1), DayOfWeek.Sunday);
                    endDay = GetNextWeekday(endDay.AddDays(1), DayOfWeek.Sunday);
                    endDay = GetNextWeekday(endDay.AddDays(1), DayOfWeek.Sunday);
                    txtStartDate.Text = startDay.ToString("dd/MM/yyyy");
                    txtEndDate.Text = endDay.ToString("dd/MM/yyyy");
                }
            }

            else
            {
                //lblStartDate.Text = "Start Date";
                //lblEndDate.Text = "End Date";
            }
        }

        public static DateTime GetNextWeekday(DateTime start, DayOfWeek day)
        {
            int daysToAdd = 0;
            daysToAdd = ((int)day - (int)start.DayOfWeek + 7) % 7;
            return start.AddDays(daysToAdd);
        }

        protected void btn_Confirm_WWS_Click(object sender, EventArgs e)
        {
            //create a MWS
            //perform a check such that the MWS cannot be created if there is
            //an existing wws that is within the mws
            //create individual wws

            UserAccount user = (UserAccount)Session["UserAccountObj"];
            MWSBLL mwsbll = new MWSBLL();
            WWSBLL wwsbll = new WWSBLL();

            MWS mws = mwsbll.DoRetrieveLatestMWSByRId(user.UserId);

            if (mws != null && ddlWorkDay.SelectedIndex != 0)
            {
                WWS wws = wwsbll.DoRetrieveLatestWWSByMwsId(mws.MwsId);
                if (DateTime.Parse(txtStartDate.Text) <= wws.WwsDate)
                {
                    lblNoSelection.Text = "You have a current Monthly work schedule in the system. Please retry once the monthly work schedule have been completed!";
                }
                else if (ddlShift.SelectedItem.Value == "Select" || ddlWorkDay.SelectedItem.Value == "Select")
                {
                    lblNoSelection.Text = "Please select a shift slot and work day!";
                }
                else
                {
                    createWWSBasedOnDateRange(DateTime.Parse(txtStartDate.Text), DateTime.Parse(txtEndDate.Text), Convert.ToInt32(ddlShift.SelectedValue), Convert.ToInt32(ddlWorkDay.SelectedValue));
                    lblSuccess.Text = "Successfully created a schedule.";
                }
            } else
            {
                if (ddlShift.SelectedItem.Value == "Select" || ddlWorkDay.SelectedItem.Value == "Select")
                {
                    lblNoSelection.Text = "Please select a shift slot and work day!";
                }
                else
                {
                    createWWSBasedOnDateRange(DateTime.Parse(txtStartDate.Text), DateTime.Parse(txtEndDate.Text), Convert.ToInt32(ddlShift.SelectedValue), Convert.ToInt32(ddlWorkDay.SelectedValue));
                    lblSuccess.Text = "Successfully created a schedule.";
                }
            }
        }
        
        protected void createWWSBasedOnDateRange(DateTime startDate, DateTime endDate, int shiftType, int shiftDay)
        {
            UserAccount user = (UserAccount)Session["UserAccountObj"];
            MWSBLL mwsbll = new MWSBLL();
            int result = mwsbll.DoCreateMWS(user.UserId);
            WWSBLL wwsbll = new WWSBLL();
            MWS mws = mwsbll.DoRetrieveLatestMWSByRId(user.UserId);
            DateTime workDate = DateTime.Parse(txtStartDate.Text);
            while (startDate != endDate)
            {
                if (shiftType == 1)
                {
                    wwsbll.DoCreateWWS(mws.MwsId, startDate, startDate.AddHours(10), startDate.AddHours(14), startDate.AddHours(15), startDate.AddHours(19));
                 
                }

                else if (shiftType == 2)
                {
                    wwsbll.DoCreateWWS(mws.MwsId, startDate, startDate.AddHours(11), startDate.AddHours(15), startDate.AddHours(16), startDate.AddHours(20));

                }

                else if (shiftType == 3)
                {
                    wwsbll.DoCreateWWS(mws.MwsId, startDate, startDate.AddHours(12), startDate.AddHours(16), startDate.AddHours(17), startDate.AddHours(21));

                }

                else if (shiftType == 4)
                {
                    wwsbll.DoCreateWWS(mws.MwsId, startDate, startDate.AddHours(13), startDate.AddHours(17), startDate.AddHours(18), startDate.AddHours(22));
                    
                }

                startDate = startDate.AddDays(1);

                if (shiftDay == 1)
                {
                    if (startDate.DayOfWeek == DayOfWeek.Saturday)
                    {
                        startDate = startDate.AddDays(2);
                    } 
                    
                    else if (startDate.DayOfWeek == DayOfWeek.Sunday)
                    {
                        startDate = startDate.AddDays(1);
                    }

                } 
                
                else if (shiftDay == 2)
                {
                    if (startDate.DayOfWeek == DayOfWeek.Sunday)
                    {
                        startDate = startDate.AddDays(2);
                    }

                    else if (startDate.DayOfWeek == DayOfWeek.Monday)
                    {
                        startDate = startDate.AddDays(1);
                    }

                } 
                
                else if (shiftDay == 3)
                {
                    if (startDate.DayOfWeek == DayOfWeek.Monday)
                    {
                        startDate = startDate.AddDays(2);
                    }

                    else if (startDate.DayOfWeek == DayOfWeek.Tuesday)
                    {
                        startDate = startDate.AddDays(1);
                    }

                }

                else if (shiftDay == 4)
                {
                    if (startDate.DayOfWeek == DayOfWeek.Tuesday)
                    {
                        startDate = startDate.AddDays(2);
                    }

                    else if (startDate.DayOfWeek == DayOfWeek.Wednesday)
                    {
                        startDate = startDate.AddDays(1);
                    }
                }

                else if (shiftDay == 5)
                {
                    if (startDate.DayOfWeek == DayOfWeek.Wednesday)
                    {
                        startDate = startDate.AddDays(2);
                    }

                    else if (startDate.DayOfWeek == DayOfWeek.Thursday)
                    {
                        startDate = startDate.AddDays(1);
                    }

                }

                else if (shiftDay == 6)
                {
                    if (startDate.DayOfWeek == DayOfWeek.Thursday)
                    {
                        startDate = startDate.AddDays(2);
                    }

                    else if (startDate.DayOfWeek == DayOfWeek.Friday)
                    {
                        startDate = startDate.AddDays(1);
                    }

                }

                else if (shiftDay == 7)
                {
                    if (startDate.DayOfWeek == DayOfWeek.Friday)
                    {
                        startDate = startDate.AddDays(2);
                    }

                    else if (startDate.DayOfWeek == DayOfWeek.Saturday)
                    {
                        startDate = startDate.AddDays(1);
                    }
                }
            }
        }
    }
}