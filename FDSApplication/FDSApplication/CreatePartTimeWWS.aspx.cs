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
    public partial class CreatePartTimeWWS : System.Web.UI.Page
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
                Response.Redirect("CreateFullTimeWWS.aspx");
            }


            PTWWSBLL ptwsbll = new PTWWSBLL();
            PTDayScheduleBLL ptdsbll = new PTDayScheduleBLL();
            PTDaySchedule ptds = new PTDaySchedule();
            PTWWS ptws = new PTWWS();

            DateTime startDay = GetNextWeekday(DateTime.Today.AddDays(1), DayOfWeek.Monday);
            DateTime endDay = GetNextWeekday(startDay, DayOfWeek.Sunday);

            if (ptwsbll.DoRetrieveLatestPTWWSByRId(user.UserId) != null)
            {
                ptws = ptwsbll.DoRetrieveLatestPTWWSByRId(user.UserId);
                DateTime lastDay = ptdsbll.DoRetrieveLatestPTDSDateByPTWWSId(ptws.PtwwsId);
                startDay = GetNextWeekday(lastDay.AddDays(1), DayOfWeek.Monday);
                endDay = GetNextWeekday(startDay, DayOfWeek.Sunday);
                txtStartUp.Text = "The Start Date will be the next monday of your last WWS";
            }

            else
            {
                txtStartUp.Text = "The Start Date will be the next monday excluding today";
            }

            txtStartDate.Text = startDay.ToString("dd/MM/yyyy");
            txtEndDate.Text = endDay.ToString("dd/MM/yyyy");

            //MONDAY
            //shift1  start          
            if (ddl1.SelectedItem.Text == "Select Shift")
            {
                ddl2.Visible = false;
                ddl2.SelectedIndex = 0;
            }
            
            else
            {
                ddl2.Visible = true;
                //DateTime t1 = DateTime.Parse(ddl1.SelectedValue);
            }
            //shift 1 end
            if(ddl2.SelectedItem.Text == "Select Shift")
            {
                ddl3.Visible = false;
                ddl3.SelectedIndex = 0;
            }

            else
            {
                if (DateTime.Parse(ddl2.SelectedValue) <= DateTime.Parse(ddl1.SelectedValue) || (DateTime.Parse(ddl2.SelectedValue) - DateTime.Parse(ddl1.SelectedValue)).TotalHours > 4)
                {
                    Label1.Text = "Invalid selection. End Shift must be after start shift and within 4 hours max!";
                    ddl2.SelectedIndex = 0;
                    ddl3.SelectedIndex = 0;
                }

                else
                {
                    Label1.Text = "";
                    ddl3.Visible = true;
                }
            }

            //shift2 start
            if (ddl3.SelectedItem.Text == "Select Shift")
            {
                ddl4.Visible = false;
                ddl4.SelectedIndex = 0;
            }

            else
            {
                if (DateTime.Parse(ddl3.SelectedValue) <= DateTime.Parse(ddl2.SelectedValue) || (DateTime.Parse(ddl3.SelectedValue) - DateTime.Parse(ddl2.SelectedValue)).TotalHours < 1)
                {
                    Label1.Text = "Ensure there is an hour break between shift!";
                    ddl3.SelectedIndex = 0;
                    ddl4.SelectedIndex = 0;
                }

                else
                {
                    Label1.Text = "";
                    ddl4.Visible = true;
                }
            }
            //shift2 end
            if(ddl4.SelectedItem.Text == "Select Shift")
            {
                ddl5.Visible = false;
                ddl5.SelectedIndex = 0;
            }

            else
            {
                if (DateTime.Parse(ddl4.SelectedValue) <= DateTime.Parse(ddl3.SelectedValue) || (DateTime.Parse(ddl4.SelectedValue) - DateTime.Parse(ddl3.SelectedValue)).TotalHours > 4)
                {
                    Label1.Text = "Invalid selection. End Shift must be after start shift and within 4 hours max!";
                    ddl4.SelectedIndex = 0;
                    ddl5.SelectedIndex = 0;
                }

                else
                {
                    Label1.Text = "";
                    ddl5.Visible = true;
                }
            }
            //shift3 start
            if(ddl5.SelectedItem.Text == "Select Shift")
            {
                ddl6.Visible = false;
                ddl6.SelectedIndex = 0;
            }

            else
            {
                if (DateTime.Parse(ddl5.SelectedValue) <= DateTime.Parse(ddl4.SelectedValue) || (DateTime.Parse(ddl5.SelectedValue) - DateTime.Parse(ddl4.SelectedValue)).TotalHours < 1)
                {
                    Label1.Text = "Ensure there is an hour break between shift!";
                    ddl5.SelectedIndex = 0;
                    ddl6.SelectedIndex = 0;
                }

                else
                {
                    Label1.Text = "";
                    ddl6.Visible = true;
                }
            }
            //shift3 end
            if (ddl6.SelectedItem.Text == "Select Shift")
            {
            }

            else
            {
                if (DateTime.Parse(ddl6.SelectedValue) <= DateTime.Parse(ddl5.SelectedValue) || (DateTime.Parse(ddl6.SelectedValue) - DateTime.Parse(ddl5.SelectedValue)).TotalHours > 4)
                {
                    Label1.Text = "Invalid selection. End Shift must be after start shift and within 4 hours max!";
                    ddl6.SelectedIndex = 0;
                }
                
                else
                {
                    Label1.Text = "";
                }
            }

            //TUESDAY
            //shift1  start          
            if (ddl7.SelectedItem.Text == "Select Shift")
            {
                ddl8.Visible = false;
                ddl8.SelectedIndex = 0;
            }

            else
            {
                ddl8.Visible = true;
                //DateTime t1 = DateTime.Parse(ddl1.SelectedValue);
            }

            //shift 1 end
            if (ddl8.SelectedItem.Text == "Select Shift")
            {
                ddl9.Visible = false;
                ddl9.SelectedIndex = 0;
            }

            else
            {
                if (DateTime.Parse(ddl8.SelectedValue) <= DateTime.Parse(ddl7.SelectedValue) || (DateTime.Parse(ddl8.SelectedValue) - DateTime.Parse(ddl7.SelectedValue)).TotalHours > 4)
                {
                    Label2.Text = "Invalid selection. End Shift must be after start shift and within 4 hours max!";
                    ddl8.SelectedIndex = 0;
                    ddl9.SelectedIndex = 0;
                }

                else
                {
                    Label2.Text = "";
                    ddl9.Visible = true;
                }
            }

            //shift2 start
            if (ddl9.SelectedItem.Text == "Select Shift")
            {
                ddl10.Visible = false;
                ddl10.SelectedIndex = 0;
            }

            else
            {
                if (DateTime.Parse(ddl9.SelectedValue) <= DateTime.Parse(ddl8.SelectedValue) || (DateTime.Parse(ddl9.SelectedValue) - DateTime.Parse(ddl8.SelectedValue)).TotalHours < 1)
                {
                    Label2.Text = "Ensure there is an hour break between shift!";
                    ddl9.SelectedIndex = 0;
                    ddl10.SelectedIndex = 0;
                }

                else
                {
                    Label2.Text = "";
                    ddl10.Visible = true;
                }
            }
            //shift2 end
            if (ddl10.SelectedItem.Text == "Select Shift")
            {
                ddl11.Visible = false;
                ddl11.SelectedIndex = 0;
            }

            else
            {
                if (DateTime.Parse(ddl10.SelectedValue) <= DateTime.Parse(ddl9.SelectedValue) || (DateTime.Parse(ddl10.SelectedValue) - DateTime.Parse(ddl9.SelectedValue)).TotalHours > 4)
                {
                    Label2.Text = "Invalid selection. End Shift must be after start shift and within 4 hours max!";
                    ddl10.SelectedIndex = 0;
                    ddl11.SelectedIndex = 0;
                }

                else
                {
                    Label2.Text = "";
                    ddl11.Visible = true;
                }
            }
            //shift3 start
            if (ddl11.SelectedItem.Text == "Select Shift")
            {
                ddl12.Visible = false;
                ddl12.SelectedIndex = 0;
            }

            else
            {
                if (DateTime.Parse(ddl11.SelectedValue) <= DateTime.Parse(ddl10.SelectedValue) || (DateTime.Parse(ddl11.SelectedValue) - DateTime.Parse(ddl10.SelectedValue)).TotalHours < 1)
                {
                    Label2.Text = "Ensure there is an hour break between shift!";
                    ddl11.SelectedIndex = 0;
                    ddl12.SelectedIndex = 0;
                }

                else
                {
                    Label2.Text = "";
                    ddl12.Visible = true;
                }
            }
            //shift3 end
            if (ddl12.SelectedItem.Text == "Select Shift")
            {
            }

            else
            {
                if (DateTime.Parse(ddl12.SelectedValue) <= DateTime.Parse(ddl11.SelectedValue) || (DateTime.Parse(ddl12.SelectedValue) - DateTime.Parse(ddl11.SelectedValue)).TotalHours > 4)
                {
                    Label2.Text = "Invalid selection. End Shift must be after start shift and within 4 hours max!";
                    ddl12.SelectedIndex = 0;
                }

                else
                {
                    Label2.Text = "";
                }
            }

            //Wednesday
            //shift1  start          
            if (ddl13.SelectedItem.Text == "Select Shift")
            {
                ddl14.Visible = false;
                ddl14.SelectedIndex = 0;
            }

            else
            {
                ddl14.Visible = true;
                //DateTime t1 = DateTime.Parse(ddl1.SelectedValue);
            }

            //shift 1 end
            if (ddl14.SelectedItem.Text == "Select Shift")
            {
                ddl15.Visible = false;
                ddl15.SelectedIndex = 0;
            }

            else
            {
                if (DateTime.Parse(ddl14.SelectedValue) <= DateTime.Parse(ddl13.SelectedValue) || (DateTime.Parse(ddl14.SelectedValue) - DateTime.Parse(ddl13.SelectedValue)).TotalHours > 4)
                {
                    Label3.Text = "Invalid selection. End Shift must be after start shift and within 4 hours max!";
                    ddl14.SelectedIndex = 0;
                    ddl15.SelectedIndex = 0;
                }

                else
                {
                    Label3.Text = "";
                    ddl15.Visible = true;
                }
            }
            //shift2 start
            if (ddl15.SelectedItem.Text == "Select Shift")
            {
                ddl16.Visible = false;
                ddl16.SelectedIndex = 0;
            }

            else
            {
                if (DateTime.Parse(ddl15.SelectedValue) <= DateTime.Parse(ddl14.SelectedValue) || (DateTime.Parse(ddl15.SelectedValue) - DateTime.Parse(ddl14.SelectedValue)).TotalHours < 1)
                {
                    Label3.Text = "Ensure there is an hour break between shift!";
                    ddl15.SelectedIndex = 0;
                    ddl16.SelectedIndex = 0;
                }

                else
                {
                    Label3.Text = "";
                    ddl16.Visible = true;
                }
            }
            //shift2 end
            if (ddl16.SelectedItem.Text == "Select Shift")
            {
                ddl17.Visible = false;
                ddl17.SelectedIndex = 0;
            }

            else
            {
                if (DateTime.Parse(ddl16.SelectedValue) <= DateTime.Parse(ddl15.SelectedValue) || (DateTime.Parse(ddl16.SelectedValue) - DateTime.Parse(ddl15.SelectedValue)).TotalHours > 4)
                {
                    Label3.Text = "Invalid selection. End Shift must be after start shift and within 4 hours max!";
                    ddl16.SelectedIndex = 0;
                    ddl17.SelectedIndex = 0;
                }

                else
                {
                    Label3.Text = "";
                    ddl17.Visible = true;
                }
            }
            //shift3 start
            if (ddl17.SelectedItem.Text == "Select Shift")
            {
                ddl18.Visible = false;
                ddl18.SelectedIndex = 0;
            }
            else
            {
                if (DateTime.Parse(ddl17.SelectedValue) <= DateTime.Parse(ddl16.SelectedValue) || (DateTime.Parse(ddl17.SelectedValue) - DateTime.Parse(ddl16.SelectedValue)).TotalHours < 1)
                {
                    Label3.Text = "Ensure there is an hour break between shift!";
                    ddl17.SelectedIndex = 0;
                    ddl18.SelectedIndex = 0;
                }

                else
                {
                    Label3.Text = "";
                    ddl18.Visible = true;
                }
            }
            //shift3 end
            if (ddl18.SelectedItem.Text == "Select Shift")
            {
            }

            else
            {
                if (DateTime.Parse(ddl18.SelectedValue) <= DateTime.Parse(ddl17.SelectedValue) || (DateTime.Parse(ddl18.SelectedValue) - DateTime.Parse(ddl17.SelectedValue)).TotalHours > 4)
                {
                    Label3.Text = "Invalid selection. End Shift must be after start shift and within 4 hours max!";
                    ddl18.SelectedIndex = 0;
                }

                else
                {
                    Label3.Text = "";
                }
            }

            //Thursday
            //shift1  start          
            if (ddl19.SelectedItem.Text == "Select Shift")
            {
                ddl20.Visible = false;
                ddl20.SelectedIndex = 0;
            }

            else
            {
                ddl20.Visible = true;
                //DateTime t1 = DateTime.Parse(ddl1.SelectedValue);
            }
            //shift 1 end
            if (ddl20.SelectedItem.Text == "Select Shift")
            {
                ddl21.Visible = false;
                ddl21.SelectedIndex = 0;
            }

            else
            {
                if (DateTime.Parse(ddl20.SelectedValue) <= DateTime.Parse(ddl19.SelectedValue) || (DateTime.Parse(ddl20.SelectedValue) - DateTime.Parse(ddl19.SelectedValue)).TotalHours > 4)
                {
                    Label4.Text = "Invalid selection. End Shift must be after start shift and within 4 hours max!";
                    ddl20.SelectedIndex = 0;
                    ddl21.SelectedIndex = 0;
                }

                else
                {
                    Label4.Text = "";
                    ddl21.Visible = true;
                }
            }
            //shift2 start
            if (ddl21.SelectedItem.Text == "Select Shift")
            {
                ddl22.Visible = false;
                ddl22.SelectedIndex = 0;
            }

            else
            {
                if (DateTime.Parse(ddl21.SelectedValue) <= DateTime.Parse(ddl20.SelectedValue) || (DateTime.Parse(ddl21.SelectedValue) - DateTime.Parse(ddl20.SelectedValue)).TotalHours < 1)
                {
                    Label4.Text = "Ensure there is an hour break between shift!";
                    ddl21.SelectedIndex = 0;
                    ddl22.SelectedIndex = 0;
                }

                else
                {
                    Label4.Text = "";
                    ddl22.Visible = true;
                }
            }
            //shift2 end
            if (ddl22.SelectedItem.Text == "Select Shift")
            {
                ddl23.Visible = false;
                ddl23.SelectedIndex = 0;
            }

            else
            {
                if (DateTime.Parse(ddl22.SelectedValue) <= DateTime.Parse(ddl21.SelectedValue) || (DateTime.Parse(ddl22.SelectedValue) - DateTime.Parse(ddl21.SelectedValue)).TotalHours > 4)
                {
                    Label4.Text = "Invalid selection. End Shift must be after start shift and within 4 hours max!";
                    ddl22.SelectedIndex = 0;
                    ddl23.SelectedIndex = 0;
                }

                else
                {
                    Label4.Text = "";
                    ddl23.Visible = true;
                }
            }

            //shift3 start
            if (ddl23.SelectedItem.Text == "Select Shift")
            {
                ddl24.Visible = false;
                ddl24.SelectedIndex = 0;
            }

            else
            {
                if (DateTime.Parse(ddl23.SelectedValue) <= DateTime.Parse(ddl22.SelectedValue) || (DateTime.Parse(ddl23.SelectedValue) - DateTime.Parse(ddl22.SelectedValue)).TotalHours < 1)
                {
                    Label4.Text = "Ensure there is an hour break between shift!";
                    ddl23.SelectedIndex = 0;
                    ddl24.SelectedIndex = 0;
                }

                else
                {
                    Label4.Text = "";
                    ddl24.Visible = true;
                }
            }
            //shift3 end
            if (ddl24.SelectedItem.Text == "Select Shift")
            {
            }

            else
            {
                if (DateTime.Parse(ddl24.SelectedValue) <= DateTime.Parse(ddl23.SelectedValue) || (DateTime.Parse(ddl24.SelectedValue) - DateTime.Parse(ddl23.SelectedValue)).TotalHours > 4)
                {
                    Label4.Text = "Invalid selection. End Shift must be after start shift and within 4 hours max!";
                    ddl24.SelectedIndex = 0;
                }

                else
                {
                    Label4.Text = "";
                }
            }

            //Friday
            //shift1  start          
            if (ddl25.SelectedItem.Text == "Select Shift")
            {
                ddl26.Visible = false;
                ddl26.SelectedIndex = 0;
            }

            else
            {
                ddl26.Visible = true;
                //DateTime t1 = DateTime.Parse(ddl1.SelectedValue);
            }

            //shift 1 end
            if (ddl26.SelectedItem.Text == "Select Shift")
            {
                ddl27.Visible = false;
                ddl27.SelectedIndex = 0;
            }

            else
            {
                if (DateTime.Parse(ddl26.SelectedValue) <= DateTime.Parse(ddl25.SelectedValue) || (DateTime.Parse(ddl26.SelectedValue) - DateTime.Parse(ddl25.SelectedValue)).TotalHours > 4)
                {
                    Label5.Text = "Invalid selection. End Shift must be after start shift and within 4 hours max!";
                    ddl26.SelectedIndex = 0;
                    ddl27.SelectedIndex = 0;
                }

                else
                {
                    Label5.Text = "";
                    ddl27.Visible = true;
                }
            }

            //shift2 start
            if (ddl27.SelectedItem.Text == "Select Shift")
            {
                ddl28.Visible = false;
                ddl28.SelectedIndex = 0;
            }

            else
            {
                if (DateTime.Parse(ddl27.SelectedValue) <= DateTime.Parse(ddl26.SelectedValue) || (DateTime.Parse(ddl27.SelectedValue) - DateTime.Parse(ddl26.SelectedValue)).TotalHours < 1)
                {
                    Label5.Text = "Ensure there is an hour break between shift!";
                    ddl27.SelectedIndex = 0;
                    ddl28.SelectedIndex = 0;
                }

                else
                {
                    Label5.Text = "";
                    ddl28.Visible = true;
                }
            }
            //shift2 end
            if (ddl28.SelectedItem.Text == "Select Shift")
            {
                ddl29.Visible = false;
                ddl29.SelectedIndex = 0;
            }

            else
            {
                if (DateTime.Parse(ddl28.SelectedValue) <= DateTime.Parse(ddl27.SelectedValue) || (DateTime.Parse(ddl28.SelectedValue) - DateTime.Parse(ddl27.SelectedValue)).TotalHours > 4)
                {
                    Label5.Text = "Invalid selection. End Shift must be after start shift and within 4 hours max!";
                    ddl28.SelectedIndex = 0;
                    ddl29.SelectedIndex = 0;
                }

                else
                {
                    Label5.Text = "";
                    ddl29.Visible = true;
                }
            }
            //shift3 start
            if (ddl29.SelectedItem.Text == "Select Shift")
            {
                ddl30.Visible = false;
                ddl30.SelectedIndex = 0;
            }

            else
            {
                if (DateTime.Parse(ddl29.SelectedValue) <= DateTime.Parse(ddl28.SelectedValue) || (DateTime.Parse(ddl29.SelectedValue) - DateTime.Parse(ddl28.SelectedValue)).TotalHours < 1)
                {
                    Label5.Text = "Ensure there is an hour break between shift!";
                    ddl29.SelectedIndex = 0;
                    ddl30.SelectedIndex = 0;
                }

                else
                {
                    Label5.Text = "";
                    ddl30.Visible = true;
                }
            }
            //shift3 end
            if (ddl30.SelectedItem.Text == "Select Shift")
            {
            }

            else
            {
                if (DateTime.Parse(ddl30.SelectedValue) <= DateTime.Parse(ddl29.SelectedValue) || (DateTime.Parse(ddl30.SelectedValue) - DateTime.Parse(ddl29.SelectedValue)).TotalHours > 4)
                {
                    Label5.Text = "Invalid selection. End Shift must be after start shift and within 4 hours max!";
                    ddl30.SelectedIndex = 0;
                }

                else
                {
                    Label5.Text = "";
                }
            }

            //Saturday
            //shift1  start          
            if (ddl31.SelectedItem.Text == "Select Shift")
            {
                ddl32.Visible = false;
                ddl32.SelectedIndex = 0;
            }

            else
            {
                ddl32.Visible = true;
                //DateTime t1 = DateTime.Parse(ddl1.SelectedValue);
            }

            //shift 1 end
            if (ddl32.SelectedItem.Text == "Select Shift")
            {
                ddl33.Visible = false;
                ddl33.SelectedIndex = 0;
            }
            else
            {
                if (DateTime.Parse(ddl32.SelectedValue) <= DateTime.Parse(ddl31.SelectedValue) || (DateTime.Parse(ddl32.SelectedValue) - DateTime.Parse(ddl31.SelectedValue)).TotalHours > 4)
                {
                    Label6.Text = "Invalid selection. End Shift must be after start shift and within 4 hours max!";
                    ddl32.SelectedIndex = 0;
                    ddl33.SelectedIndex = 0;
                }

                else
                {
                    Label6.Text = "";
                    ddl33.Visible = true;
                }
            }
            //shift2 start
            if (ddl33.SelectedItem.Text == "Select Shift")
            {
                ddl34.Visible = false;
                ddl34.SelectedIndex = 0;
            }

            else
            {
                if (DateTime.Parse(ddl33.SelectedValue) <= DateTime.Parse(ddl32.SelectedValue) || (DateTime.Parse(ddl33.SelectedValue) - DateTime.Parse(ddl32.SelectedValue)).TotalHours < 1)
                {
                    Label6.Text = "Ensure there is an hour break between shift!";
                    ddl33.SelectedIndex = 0;
                    ddl34.SelectedIndex = 0;
                }

                else
                {
                    Label6.Text = "";
                    ddl34.Visible = true;
                }
            }
            //shift2 end
            if (ddl34.SelectedItem.Text == "Select Shift")
            {
                ddl35.Visible = false;
                ddl35.SelectedIndex = 0;
            }

            else
            {
                if (DateTime.Parse(ddl34.SelectedValue) <= DateTime.Parse(ddl33.SelectedValue) || (DateTime.Parse(ddl34.SelectedValue) - DateTime.Parse(ddl33.SelectedValue)).TotalHours > 4)
                {
                    Label6.Text = "Invalid selection. End Shift must be after start shift and within 4 hours max!";
                    ddl34.SelectedIndex = 0;
                    ddl35.SelectedIndex = 0;
                }

                else
                {
                    Label6.Text = "";
                    ddl35.Visible = true;
                }
            }
            //shift3 start
            if (ddl35.SelectedItem.Text == "Select Shift")
            {
                ddl36.Visible = false;
                ddl36.SelectedIndex = 0;
            }

            else
            {
                if (DateTime.Parse(ddl35.SelectedValue) <= DateTime.Parse(ddl34.SelectedValue) || (DateTime.Parse(ddl35.SelectedValue) - DateTime.Parse(ddl34.SelectedValue)).TotalHours < 1)
                {
                    Label6.Text = "Ensure there is an hour break between shift!";
                    ddl35.SelectedIndex = 0;
                    ddl36.SelectedIndex = 0;
                }

                else
                {
                    Label6.Text = "";
                    ddl36.Visible = true;
                }
            }
            //shift3 end
            if (ddl36.SelectedItem.Text == "Select Shift")
            {

            }

            else
            {
                if (DateTime.Parse(ddl36.SelectedValue) <= DateTime.Parse(ddl35.SelectedValue) || (DateTime.Parse(ddl36.SelectedValue) - DateTime.Parse(ddl35.SelectedValue)).TotalHours > 4)
                {
                    Label6.Text = "Invalid selection. End Shift must be after start shift and within 4 hours max!";
                    ddl36.SelectedIndex = 0;
                }

                else
                {
                    Label6.Text = "";
                }
            }

            //Sunday
            //shift1  start          
            if (ddl37.SelectedItem.Text == "Select Shift")
            {
                ddl38.Visible = false;
                ddl38.SelectedIndex = 0;
            }

            else
            {
                ddl38.Visible = true;
                //DateTime t1 = DateTime.Parse(ddl1.SelectedValue);
            }

            //shift 1 end
            if (ddl38.SelectedItem.Text == "Select Shift")
            {
                ddl39.Visible = false;
                ddl39.SelectedIndex = 0;
            }

            else
            {
                if (DateTime.Parse(ddl38.SelectedValue) <= DateTime.Parse(ddl37.SelectedValue) || (DateTime.Parse(ddl38.SelectedValue) - DateTime.Parse(ddl37.SelectedValue)).TotalHours > 4)
                {
                    Label7.Text = "Invalid selection. End Shift must be after start shift and within 4 hours max!";
                    ddl38.SelectedIndex = 0;
                    ddl39.SelectedIndex = 0;
                }

                else
                {
                    Label7.Text = "";
                    ddl39.Visible = true;
                }
            }

            //shift2 start
            if (ddl39.SelectedItem.Text == "Select Shift")
            {
                ddl40.Visible = false;
                ddl40.SelectedIndex = 0;
            }

            else
            {
                if (DateTime.Parse(ddl39.SelectedValue) <= DateTime.Parse(ddl38.SelectedValue) || (DateTime.Parse(ddl39.SelectedValue) - DateTime.Parse(ddl38.SelectedValue)).TotalHours < 1)
                {
                    Label7.Text = "Ensure there is an hour break between shift!";
                    ddl39.SelectedIndex = 0;
                    ddl40.SelectedIndex = 0;
                }

                else
                {
                    Label7.Text = "";
                    ddl40.Visible = true;
                }
            }
            //shift2 end
            if (ddl40.SelectedItem.Text == "Select Shift")
            {
                ddl41.Visible = false;
                ddl41.SelectedIndex = 0;
            }

            else
            {
                if (DateTime.Parse(ddl40.SelectedValue) <= DateTime.Parse(ddl39.SelectedValue) || (DateTime.Parse(ddl40.SelectedValue) - DateTime.Parse(ddl39.SelectedValue)).TotalHours > 4)
                {
                    Label7.Text = "Invalid selection. End Shift must be after start shift and within 4 hours max!";
                    ddl40.SelectedIndex = 0;
                    ddl41.SelectedIndex = 0;
                }

                else
                {
                    Label7.Text = "";
                    ddl41.Visible = true;
                }
            }

            //shift3 start
            if (ddl41.SelectedItem.Text == "Select Shift")
            {
                ddl42.Visible = false;
                ddl42.SelectedIndex = 0;
            }
            else
            {
                if (DateTime.Parse(ddl41.SelectedValue) <= DateTime.Parse(ddl40.SelectedValue) || (DateTime.Parse(ddl41.SelectedValue) - DateTime.Parse(ddl40.SelectedValue)).TotalHours < 1)
                {
                    Label7.Text = "Ensure there is an hour break between shift!";
                    ddl41.SelectedIndex = 0;
                    ddl42.SelectedIndex = 0;
                }

                else
                {
                    Label7.Text = "";
                    ddl42.Visible = true;
                }
            }
            //shift3 end
            if (ddl42.SelectedItem.Text == "Select Shift")
            {
            }

            else
            {
                if (DateTime.Parse(ddl42.SelectedValue) <= DateTime.Parse(ddl41.SelectedValue) || (DateTime.Parse(ddl42.SelectedValue) - DateTime.Parse(ddl41.SelectedValue)).TotalHours > 4)
                {
                    Label7.Text = "Invalid selection. End Shift must be after start shift and within 4 hours max!";
                    ddl42.SelectedIndex = 0;
                }

                else
                {
                    Label7.Text = "";
                }
            }

        }
        public static DateTime GetNextWeekday(DateTime start, DayOfWeek day)
        {
            int daysToAdd = 0;
            daysToAdd = ((int)day - (int)start.DayOfWeek + 7) % 7;
            return start.AddDays(daysToAdd);
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {

            //calculate the final hours to perform check
            btn_calculateHours_Click(sender, e);
            if (Convert.ToInt32(txtTotalHour.Text) < 10)
            {
                lblHourError.Text = "You did not meet the minimum hour of 10!";
            }

            else if (Convert.ToInt32(txtTotalHour.Text) > 48)
            {
                lblHourError.Text = "You exceeded the maximum hour of 48!";
            }

            else
            {
                lblHourError.Text = "";

                UserAccount user = (UserAccount)Session["UserAccountObj"];
                PTWWSBLL ptwwsbll = new PTWWSBLL();
                PTDayScheduleBLL ptschd = new PTDayScheduleBLL();
                ptwwsbll.DoCreatePTWWS(user.UserId);
                DateTime startDate = DateTime.Now;
                PTWWS ptwws = ptwwsbll.DoRetrieveLatestPTWWSByRId(user.UserId);
                int latestPTWWSId = ptwws.PtwwsId;

                DateTime day = DateTime.Parse(txtStartDate.Text);             

                //monday
                if (ddl3.SelectedItem.ToString() == "Select Shift" && ddl2.SelectedItem.ToString() != "Select Shift")
                {

                    ptschd.DoCreatePTDayScheduleOneSlot(latestPTWWSId, day, day.AddHours(DateTime.Parse(ddl1.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl2.SelectedValue).Hour));
                    day = day.AddDays(1);
                    //docreateslot1
                }

                else if (ddl5.SelectedItem.ToString() == "Select Shift" && ddl4.SelectedItem.ToString() != "Select Shift")
                {
                    ptschd.DoCreatePTDayScheduleTwoSlot(latestPTWWSId, day, day.AddHours(DateTime.Parse(ddl1.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl2.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl3.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl4.SelectedValue).Hour));
                    day = day.AddDays(1);
                    //do create slot 2
                }

                else if (ddl6.SelectedItem.ToString() != "Select Shift")
                {
                    ptschd.DoCreatePTDayScheduleThreeSlot(latestPTWWSId, day, day.AddHours(DateTime.Parse(ddl1.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl2.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl3.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl4.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl5.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl6.SelectedValue).Hour));
                    day = day.AddDays(1);
                    //do create slot 3
                }

                else
                {
                    day = day.AddDays(1);
                }

                //Tuesday
                if (ddl9.SelectedItem.ToString() == "Select Shift" && ddl8.SelectedItem.ToString() != "Select Shift")
                {

                    ptschd.DoCreatePTDayScheduleOneSlot(latestPTWWSId, day, day.AddHours(DateTime.Parse(ddl7.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl8.SelectedValue).Hour));
                    day = day.AddDays(1);
                    //docreateslot1
                }

                else if (ddl11.SelectedItem.ToString() == "Select Shift" && ddl10.SelectedItem.ToString() != "Select Shift")
                {
                    ptschd.DoCreatePTDayScheduleTwoSlot(latestPTWWSId, day, day.AddHours(DateTime.Parse(ddl7.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl8.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl9.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl10.SelectedValue).Hour));
                    day = day.AddDays(1);
                    //do create slot 2
                }

                else if (ddl12.SelectedItem.ToString() != "Select Shift")
                {
                    ptschd.DoCreatePTDayScheduleThreeSlot(latestPTWWSId, day, day.AddHours(DateTime.Parse(ddl7.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl8.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl9.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl10.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl11.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl12.SelectedValue).Hour));
                    day = day.AddDays(1);
                    //do create slot 3
                }

                else
                {
                    day = day.AddDays(1);
                }

                //Wednesday
                if (ddl15.SelectedItem.ToString() == "Select Shift" && ddl14.SelectedItem.ToString() != "Select Shift")
                {

                    ptschd.DoCreatePTDayScheduleOneSlot(latestPTWWSId, day, day.AddHours(DateTime.Parse(ddl13.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl14.SelectedValue).Hour));
                    day = day.AddDays(1);
                    //docreateslot1
                }

                else if (ddl17.SelectedItem.ToString() == "Select Shift" && ddl16.SelectedItem.ToString() != "Select Shift")
                {
                    ptschd.DoCreatePTDayScheduleTwoSlot(latestPTWWSId, day, day.AddHours(DateTime.Parse(ddl13.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl14.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl15.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl16.SelectedValue).Hour));
                    day = day.AddDays(1);
                    //do create slot 2
                }

                else if (ddl18.SelectedItem.ToString() != "Select Shift")
                {
                    ptschd.DoCreatePTDayScheduleThreeSlot(latestPTWWSId, day, day.AddHours(DateTime.Parse(ddl13.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl14.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl15.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl16.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl17.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl18.SelectedValue).Hour));
                    day = day.AddDays(1);
                    //do create slot 3
                }

                else
                {
                    day = day.AddDays(1);
                }

                //Thursday
                if (ddl21.SelectedItem.ToString() == "Select Shift" && ddl20.SelectedItem.ToString() != "Select Shift")
                {

                    ptschd.DoCreatePTDayScheduleOneSlot(latestPTWWSId, day, day.AddHours(DateTime.Parse(ddl19.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl20.SelectedValue).Hour));
                    day = day.AddDays(1);
                    //docreateslot1
                }

                else if (ddl23.SelectedItem.ToString() == "Select Shift" && ddl22.SelectedItem.ToString() != "Select Shift")
                {
                    ptschd.DoCreatePTDayScheduleTwoSlot(latestPTWWSId, day, day.AddHours(DateTime.Parse(ddl19.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl20.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl21.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl22.SelectedValue).Hour));
                    day = day.AddDays(1);
                    //do create slot 2
                }

                else if (ddl24.SelectedItem.ToString() != "Select Shift")
                {
                    ptschd.DoCreatePTDayScheduleThreeSlot(latestPTWWSId, day, day.AddHours(DateTime.Parse(ddl19.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl20.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl21.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl22.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl23.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl24.SelectedValue).Hour));
                    day = day.AddDays(1);
                    //do create slot 3
                }

                else
                {
                    day = day.AddDays(1);
                }

                //Friday
                if (ddl27.SelectedItem.ToString() == "Select Shift" && ddl26.SelectedItem.ToString() != "Select Shift")
                {

                    ptschd.DoCreatePTDayScheduleOneSlot(latestPTWWSId, day, day.AddHours(DateTime.Parse(ddl25.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl26.SelectedValue).Hour));
                    day = day.AddDays(1);
                    //docreateslot1
                }

                else if (ddl29.SelectedItem.ToString() == "Select Shift" && ddl28.SelectedItem.ToString() != "Select Shift")
                {
                    ptschd.DoCreatePTDayScheduleTwoSlot(latestPTWWSId, day, day.AddHours(DateTime.Parse(ddl25.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl26.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl27.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl28.SelectedValue).Hour));
                    day = day.AddDays(1);
                    //do create slot 2
                }

                else if (ddl30.SelectedItem.ToString() != "Select Shift")
                {
                    ptschd.DoCreatePTDayScheduleThreeSlot(latestPTWWSId, day, day.AddHours(DateTime.Parse(ddl25.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl26.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl27.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl28.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl29.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl30.SelectedValue).Hour));
                    day = day.AddDays(1);
                    //do create slot 3
                }

                else
                {
                    day = day.AddDays(1);
                }

                //Saturday
                if (ddl33.SelectedItem.ToString() == "Select Shift" && ddl32.SelectedItem.ToString() != "Select Shift")
                {

                    ptschd.DoCreatePTDayScheduleOneSlot(latestPTWWSId, day, day.AddHours(DateTime.Parse(ddl31.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl32.SelectedValue).Hour));
                    day = day.AddDays(1);
                    //docreateslot1
                }

                else if (ddl35.SelectedItem.ToString() == "Select Shift" && ddl34.SelectedItem.ToString() != "Select Shift")
                {
                    ptschd.DoCreatePTDayScheduleTwoSlot(latestPTWWSId, day, day.AddHours(DateTime.Parse(ddl31.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl32.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl33.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl34.SelectedValue).Hour));
                    day = day.AddDays(1);
                    //do create slot 2
                }

                else if (ddl36.SelectedItem.ToString() != "Select Shift")
                {
                    ptschd.DoCreatePTDayScheduleThreeSlot(latestPTWWSId, day, day.AddHours(DateTime.Parse(ddl31.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl32.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl33.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl34.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl35.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl36.SelectedValue).Hour));
                    day = day.AddDays(1);
                    //do create slot 3
                }

                else
                {
                    day = day.AddDays(1);
                }

                //Sunday
                if (ddl39.SelectedItem.ToString() == "Select Shift" && ddl38.SelectedItem.ToString() != "Select Shift")
                {

                    ptschd.DoCreatePTDayScheduleOneSlot(latestPTWWSId, day, day.AddHours(DateTime.Parse(ddl37.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl38.SelectedValue).Hour));
                    day = day.AddDays(1);
                    //docreateslot1
                }

                else if (ddl41.SelectedItem.ToString() == "Select Shift" && ddl40.SelectedItem.ToString() != "Select Shift")
                {
                    ptschd.DoCreatePTDayScheduleTwoSlot(latestPTWWSId, day, day.AddHours(DateTime.Parse(ddl37.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl38.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl39.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl40.SelectedValue).Hour));
                    day = day.AddDays(1);
                    //do create slot 2
                }

                else if (ddl42.SelectedItem.ToString() != "Select Shift")
                {
                    ptschd.DoCreatePTDayScheduleThreeSlot(latestPTWWSId, day, day.AddHours(DateTime.Parse(ddl37.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl38.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl39.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl40.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl41.SelectedValue).Hour), day.AddHours(DateTime.Parse(ddl42.SelectedValue).Hour));
                    day = day.AddDays(1);
                    //do create slot 3
                }

                else
                {
                    day = day.AddDays(1);
                }

                lblSuccess.Text = "Schedule successfully created";
            }
        }

        protected void btn_calculateHours_Click(object sender, EventArgs e)
        {
            int monHours = 0;
            int tuesHours = 0;
            int wedHours = 0;
            int thursHours = 0;
            int friHours = 0;
            int satHours = 0;
            int sunHours = 0;
            int totalHours = 0;

            //Monday
            if (ddl2.SelectedIndex != 0)
            {
                monHours = monHours + Convert.ToInt32(DateTime.Parse(ddl2.SelectedValue).Hour - DateTime.Parse(ddl1.SelectedValue).Hour);
            }

            if (ddl4.SelectedIndex != 0)
            {
                monHours = monHours + Convert.ToInt32(DateTime.Parse(ddl4.SelectedValue).Hour - DateTime.Parse(ddl3.SelectedValue).Hour);
            }

            if (ddl6.SelectedIndex != 0)
            {
                monHours = monHours + Convert.ToInt32(DateTime.Parse(ddl6.SelectedValue).Hour - DateTime.Parse(ddl5.SelectedValue).Hour);
            }

            //Tuesday
            if (ddl8.SelectedIndex != 0)
            {
                tuesHours = tuesHours + Convert.ToInt32(DateTime.Parse(ddl8.SelectedValue).Hour - DateTime.Parse(ddl7.SelectedValue).Hour);
            }

            if (ddl10.SelectedIndex != 0)
            {
                tuesHours = tuesHours + Convert.ToInt32(DateTime.Parse(ddl10.SelectedValue).Hour - DateTime.Parse(ddl9.SelectedValue).Hour);

            }

            if (ddl12.SelectedIndex != 0)
            {
                tuesHours = tuesHours + Convert.ToInt32(DateTime.Parse(ddl12.SelectedValue).Hour - DateTime.Parse(ddl11.SelectedValue).Hour);
            }

            //Wednesday
            if (ddl14.SelectedIndex != 0)
            {
                wedHours = wedHours + Convert.ToInt32(DateTime.Parse(ddl14.SelectedValue).Hour - DateTime.Parse(ddl13.SelectedValue).Hour);
            }

            if (ddl16.SelectedIndex != 0)
            {
                wedHours = wedHours + Convert.ToInt32(DateTime.Parse(ddl16.SelectedValue).Hour - DateTime.Parse(ddl15.SelectedValue).Hour);
            }

            if (ddl18.SelectedIndex != 0)
            {
                wedHours = wedHours + Convert.ToInt32(DateTime.Parse(ddl18.SelectedValue).Hour - DateTime.Parse(ddl17.SelectedValue).Hour);
            }

            //Thursday
            if (ddl20.SelectedIndex != 0)
            {
                thursHours = thursHours + Convert.ToInt32(DateTime.Parse(ddl20.SelectedValue).Hour - DateTime.Parse(ddl19.SelectedValue).Hour);
            }

            if (ddl22.SelectedIndex != 0)
            {
                thursHours = thursHours + Convert.ToInt32(DateTime.Parse(ddl22.SelectedValue).Hour - DateTime.Parse(ddl21.SelectedValue).Hour);

            }

            if (ddl24.SelectedIndex != 0)
            {
                thursHours = thursHours + Convert.ToInt32(DateTime.Parse(ddl24.SelectedValue).Hour - DateTime.Parse(ddl23.SelectedValue).Hour);
            }

            //Friday
            if (ddl26.SelectedIndex != 0)
            {
                friHours = friHours + Convert.ToInt32(DateTime.Parse(ddl26.SelectedValue).Hour - DateTime.Parse(ddl25.SelectedValue).Hour);
            }

            if (ddl28.SelectedIndex != 0)
            {
                friHours = friHours + Convert.ToInt32(DateTime.Parse(ddl28.SelectedValue).Hour - DateTime.Parse(ddl27.SelectedValue).Hour);
            }

            if (ddl30.SelectedIndex != 0)
            {
                friHours = friHours + Convert.ToInt32(DateTime.Parse(ddl30.SelectedValue).Hour - DateTime.Parse(ddl29.SelectedValue).Hour);
            }

            //Saturday
            if (ddl32.SelectedIndex != 0)
            {
                satHours = satHours + Convert.ToInt32(DateTime.Parse(ddl32.SelectedValue).Hour - DateTime.Parse(ddl31.SelectedValue).Hour);
            }

            if (ddl34.SelectedIndex != 0)
            {
                satHours = satHours + Convert.ToInt32(DateTime.Parse(ddl34.SelectedValue).Hour - DateTime.Parse(ddl33.SelectedValue).Hour);
            }

            if (ddl36.SelectedIndex != 0)
            {
                satHours = satHours + Convert.ToInt32(DateTime.Parse(ddl36.SelectedValue).Hour - DateTime.Parse(ddl35.SelectedValue).Hour);
            }

            //Sunday
            if (ddl38.SelectedIndex != 0)
            {
                sunHours = sunHours + Convert.ToInt32(DateTime.Parse(ddl38.SelectedValue).Hour - DateTime.Parse(ddl37.SelectedValue).Hour);
            }

            if (ddl40.SelectedIndex != 0)
            {
                sunHours = sunHours + Convert.ToInt32(DateTime.Parse(ddl40.SelectedValue).Hour - DateTime.Parse(ddl39.SelectedValue).Hour);
            }

            if (ddl42.SelectedIndex != 0)
            {
                sunHours = sunHours + Convert.ToInt32(DateTime.Parse(ddl42.SelectedValue).Hour - DateTime.Parse(ddl41.SelectedValue).Hour);
            }

            totalHours = monHours + tuesHours + wedHours + thursHours + friHours + satHours + sunHours;

            lblMonHour.Text = monHours.ToString();
            lblTuesHour.Text = tuesHours.ToString();
            lblWedHour.Text = wedHours.ToString();
            lblThursHour.Text = thursHours.ToString();
            lblFriHour.Text = friHours.ToString();
            lblSatHour.Text = satHours.ToString();
            lblSunHour.Text = sunHours.ToString();
            txtTotalHour.Text = totalHours.ToString();
        }
    }
}