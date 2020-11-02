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
    public class RiderBLL
    {
        public int DoCreateRider(UserAccount user, string rName, Boolean isFullTime)
        {
            double salary = 0.0;
            //Full Timer default monthly salary
            if (isFullTime)
            {
                salary = 100;
            }

            //Part Timer default monthly salary
            else
            {
                salary = 50;
            }

            int result = 0;
            Rider rider = new Rider(user.UserId, rName, isFullTime, salary);

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Insert into Rider(rId, rName, isfulltime, salary) values(@rId, @rName, @isfulltime, @salary)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@rid", rider.RId));
                    cmd.Parameters.Add(new NpgsqlParameter("@rname", rider.RName));
                    cmd.Parameters.Add(new NpgsqlParameter("@isfulltime", rider.IsFullTime));
                    cmd.Parameters.Add(new NpgsqlParameter("@salary", rider.Salary));
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

        public Rider DoRetrieveRiderByID(int riderId)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from Rider WHERE rid=@rid";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@rid", riderId);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();

                    string riderName = dt.Rows[0]["rname"].ToString();
                    Boolean isFullTime = Convert.ToBoolean(dt.Rows[0]["isfulltime"].ToString());
                    double salary = Convert.ToDouble(dt.Rows[0]["salary"].ToString());

                    Rider rider = new Rider(riderId, riderName, isFullTime, salary);
                    return rider;
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }

        public int DoUpdateRider(int riderId, string riderName)
        {
            int result = 0;
            Rider updateRider = new Rider(riderId, riderName);

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Update Rider Set rname=@rname Where rid=@rid";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@rid", updateRider.RId));
                    cmd.Parameters.Add(new NpgsqlParameter("@rname", updateRider.RName));
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
    }
}