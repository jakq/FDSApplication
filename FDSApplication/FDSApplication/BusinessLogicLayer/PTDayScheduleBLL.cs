using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FDSApplication.Models;
using System.Data;
using System.Configuration;
using Npgsql;

namespace FDSApplication.BusinessLogicLayer
{
    public class PTDayScheduleBLL
    {

        public int DoCreatePTDayScheduleThreeSlot(int ptwwsId, DateTime ptwwsDate, DateTime ptwwsStartTime, DateTime ptwwsEndTime, DateTime ptwwsStartTimeTwo, DateTime ptwwsEndTimeTwo, DateTime ptwwsStartTimeThree, DateTime ptwwsEndTimeThree)
        {
            int result = 0;
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Insert into PTDaySchedule(ptwwsid, ptwwsdate, ptwwsstarttime, ptwwsendtime, ptwwsstarttimetwo, ptwwsendtimetwo, ptwwsstarttimethree, ptwwsendtimethree) values(@ptwwsid, @ptwwsdate, @ptwwsstarttime, @ptwwsendtime, @ptwwsstarttimetwo, @ptwwsendtimetwo, @ptwwsstarttimethree, @ptwwsendtimethree)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@ptwwsid", ptwwsId));
                    cmd.Parameters.Add(new NpgsqlParameter("@ptwwsdate", ptwwsDate));
                    cmd.Parameters.Add(new NpgsqlParameter("@ptwwsstarttime", ptwwsStartTime));
                    cmd.Parameters.Add(new NpgsqlParameter("@ptwwsendtime", ptwwsEndTime));
                    cmd.Parameters.Add(new NpgsqlParameter("@ptwwsstarttimetwo", ptwwsStartTimeTwo));
                    cmd.Parameters.Add(new NpgsqlParameter("@ptwwsendtimetwo", ptwwsEndTimeTwo));
                    cmd.Parameters.Add(new NpgsqlParameter("@ptwwsstarttimethree", ptwwsStartTimeThree));
                    cmd.Parameters.Add(new NpgsqlParameter("@ptwwsendtimethree", ptwwsEndTimeThree));
                    result = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return result;
        }

        public int DoCreatePTDayScheduleTwoSlot(int ptwwsId, DateTime ptwwsDate, DateTime ptwwsStartTime, DateTime ptwwsEndTime, DateTime ptwwsStartTimeTwo, DateTime ptwwsEndTimeTwo)
        {
            int result = 0;
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Insert into PTDaySchedule(ptwwsid, ptwwsdate, ptwwsstarttime, ptwwsendtime, ptwwsstarttimetwo, ptwwsendtimetwo) values(@ptwwsid, @ptwwsdate, @ptwwsstarttime, @ptwwsendtime, @ptwwsstarttimetwo, @ptwwsendtimetwo)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@ptwwsid", ptwwsId));
                    cmd.Parameters.Add(new NpgsqlParameter("@ptwwsdate", ptwwsDate));
                    cmd.Parameters.Add(new NpgsqlParameter("@ptwwsstarttime", ptwwsStartTime));
                    cmd.Parameters.Add(new NpgsqlParameter("@ptwwsendtime", ptwwsEndTime));
                    cmd.Parameters.Add(new NpgsqlParameter("@ptwwsstarttimetwo", ptwwsStartTimeTwo));
                    cmd.Parameters.Add(new NpgsqlParameter("@ptwwsendtimetwo", ptwwsEndTimeTwo));
                    result = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return result;
        }

        public int DoCreatePTDayScheduleOneSlot(int ptwwsId, DateTime ptwwsDate, DateTime ptwwsStartTime, DateTime ptwwsEndTime)
        {
            int result = 0;
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Insert into PTDaySchedule(ptwwsid, ptwwsdate, ptwwsstarttime, ptwwsendtime) values(@ptwwsid, @ptwwsdate, @ptwwsstarttime, @ptwwsendtime)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@ptwwsid", ptwwsId));
                    cmd.Parameters.Add(new NpgsqlParameter("@ptwwsdate", ptwwsDate));
                    cmd.Parameters.Add(new NpgsqlParameter("@ptwwsstarttime", ptwwsStartTime));
                    cmd.Parameters.Add(new NpgsqlParameter("@ptwwsendtime", ptwwsEndTime));
                    result = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return result;
        }

        public DateTime DoRetrieveLatestPTDSDateByPTWWSId(int ptwwsId)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select ptwwsDate from PTDaySchedule WHERE ptwwsId=@ptwwsId order by ptwwsDate DESC";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@ptwwsId", ptwwsId);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();
                    
                    return DateTime.Parse(dt.Rows[0][0].ToString());

                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return DateTime.Now;
        }

        public DataTable DoRetrieveAllPTDSByPTWWSId(int ptwwsId)
        {
            try
            {
                DataTable dt = new DataTable();
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from ptdayschedule where ptwwsid = @ptwwsid";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@ptwwsid", ptwwsId);
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();
                }

                return dt;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }

        public DataTable DoRetrieveUnfulfilledPTWWSByPTWWSId(int ptwwsId, DateTime currDate)
        {
            try
            {
                DataTable dt = new DataTable();
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from ptdayschedule where ptwwsid = @ptwwsid and ptwwsDate >= @currDate";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@ptwwsid", ptwwsId);
                    da.SelectCommand.Parameters.AddWithValue("@currdate", currDate);
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();
                }

                return dt;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }

        public DataTable DoRetrievePTWWSByPTWWSId(int ptwwsId)
        {
            try
            {
                DataTable dt = new DataTable();
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from ptdayschedule where ptwwsid = @ptwwsid";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@ptwwsid", ptwwsId);
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();
                }

                return dt;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }

        public int doIsPartTimeRiderCurrentlyWorking(int rid, DateTime timing)
        {
            int result = 0;
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from ptwws pt inner join PTDaySchedule pd on pt.ptwwsid = pd.ptwwsid where @timing between ptwwsStartTime and ptwwsEndTime"
                        + " or @timing between ptwwsStartTimeTwo and ptwwsEndTimeTwo"
                        + " or @timing between ptwwsStartTimeThree and ptwwsEndTimeThree"
                        + " and rid=@rid";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@rid", rid);
                    da.SelectCommand.Parameters.AddWithValue("@timing", timing);
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd.Dispose();
                    connection.Close();

                    return result;

                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return result;
        }



    }
}