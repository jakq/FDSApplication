using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using Npgsql;
using FDSApplication.Models;

namespace FDSApplication.BusinessLogicLayer
{
    public class LastAccessBLL
    {
        public int DoCheckLastAccessExists()
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
                    cmd.CommandText = "Select * From LastAccess";
                    cmd.CommandType = CommandType.Text;
                    result = Convert.ToInt32(cmd.ExecuteScalar());
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

        public int DoCreateLastAccessRecord(DateTime currDate)
        {
            int result = 0;
            LastAccess lastAccess = new LastAccess(currDate);

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Insert into LastAccess(accessDate) values(@accessDate)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@accessDate", lastAccess.AccessDate));                
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

        public LastAccess DoRetrieveLastAccess()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from LastAccess WHERE accessid=1";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();

                    int accessId = int.Parse(dt.Rows[0]["accessid"].ToString());
                    DateTime accessDate = DateTime.Parse(dt.Rows[0]["accessDate"].ToString());


                    LastAccess lastAccess = new LastAccess(accessId, accessDate);
                    return lastAccess;
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }

        public int DoUpdateLastAccess(DateTime currDate)
        {
            int result = 0;
            int accessId = 1;

            LastAccess lastAccess = new LastAccess(accessId, currDate);

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Update LastAccess Set accessDate=@accessDate where accessid=@accessid";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@accessid", lastAccess.AccessId));
                    cmd.Parameters.Add(new NpgsqlParameter("@accessDate", lastAccess.AccessDate));                    
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

        public void DoUpdateOrderCounter()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Update FoodItem Set ordercounter=0";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}