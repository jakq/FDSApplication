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
    public class WWSBLL
    {

        public int DoCreateWWS(int mwsId, DateTime wwsDate, DateTime wwsStartTime, DateTime wwsEndTime, DateTime wwsStartTimeTwo, DateTime wwsEndTimeTwo)
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
                    cmd.CommandText = "Insert into WWS(mwsId, wwsDate, wwsStartTime, wwsEndTime, wwsStartTimeTwo, wwsEndTimeTwo) values(@mwsid, @wwsdate, @wwsstarttime, @wwsendtime, @wwsstarttimetwo, @wwsendtimetwo)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@mwsid", mwsId));
                    cmd.Parameters.Add(new NpgsqlParameter("@wwsdate", wwsDate));
                    cmd.Parameters.Add(new NpgsqlParameter("@wwsstarttime", wwsStartTime));
                    cmd.Parameters.Add(new NpgsqlParameter("@wwsendtime", wwsEndTime));
                    cmd.Parameters.Add(new NpgsqlParameter("@wwsstarttimetwo", wwsStartTimeTwo));
                    cmd.Parameters.Add(new NpgsqlParameter("@wwsendtimetwo", wwsEndTimeTwo));
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

        public DataTable DoRetrieveAllWWSByMWSId(int mwsId)
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
                    cmd.CommandText = "Select * from wws where mwsid = @mwsid";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@mwsid", mwsId);
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

        public DataTable DoRetrieveUnfulfilledWWSByMWSId(int mwsId, DateTime currDate)
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
                    cmd.CommandText = "Select * from wws where mwsid = @mwsid and wwsDate >= @currDate";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@mwsid", mwsId);
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

        public WWS DoRetrieveLatestWWSByMwsId(int mwsId)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from WWS WHERE mwsid=@mwsid order by wwsDate DESC";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@mwsid", mwsId);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();

                    int wwsid = Convert.ToInt32(dt.Rows[0]["wwsid"].ToString());
                    DateTime wwsdate = DateTime.Parse(dt.Rows[0]["wwsdate"].ToString());
                    DateTime wwsstartone = DateTime.Parse(dt.Rows[0]["wwsStartTime"].ToString());
                    DateTime wwsendone = DateTime.Parse(dt.Rows[0]["wwsEndTime"].ToString());
                    DateTime wwsstarttwo = DateTime.Parse(dt.Rows[0]["wwsStartTimeTwo"].ToString());
                    DateTime wwsendtwo = DateTime.Parse(dt.Rows[0]["wwsEndTimeTwo"].ToString());


                    WWS wws = new WWS(wwsid, wwsdate, wwsstartone, wwsendone, wwsstarttwo, wwsendtwo); 

                    return wws;

                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }

        public int doIsRiderCurrentlyWorking(int mwsId, DateTime timing)
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
                    cmd.CommandText = "Select * From WWS Where @timing between wwsstarttime and wwsendtime or @timing between wwsstarttimetwo and wwsendtimetwo and mwsid=@mwsid";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@mwsId", mwsId));
                    cmd.Parameters.Add(new NpgsqlParameter("@timing", timing));
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd.Dispose();
                    connection.Close();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            if(result != 0)
            {
                return 1;
            }
            return result;
        }

    }
}