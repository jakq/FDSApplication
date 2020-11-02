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
    public class StaffBLL
    {
        public int DoCreateStaff(UserAccount user, int restId, string staffName)
        {
            int result = 0;
            Staff staff = new Staff(user.UserId, restId, staffName);

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Insert into Staff(staffId, restId, staffname) values(@staffId, @restId, @staffname)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@staffId", staff.StaffId));
                    cmd.Parameters.Add(new NpgsqlParameter("@restId", staff.RestId));
                    cmd.Parameters.Add(new NpgsqlParameter("@staffname", staff.StaffName));
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

        public Staff DoRetrieveStaffByID(int staffId)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from Staff WHERE staffid=@staffid";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@staffid", staffId);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();

                    string staffName = dt.Rows[0]["staffname"].ToString();
                    int restId = Convert.ToInt32(dt.Rows[0]["restId"].ToString());

                    Staff staff = new Staff(staffId, restId, staffName);
                    return staff;
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }

        public int DoUpdateStaff(int staffId, string staffName)
        {
            int result = 0;
            Staff updateStaff = new Staff(staffId, staffName);

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Update Staff Set staffname=@staffname Where staffid=@staffid";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@staffid", updateStaff.StaffId));
                    cmd.Parameters.Add(new NpgsqlParameter("@staffname", updateStaff.StaffName));
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

        public DataTable DoRetrieveStaffByRestID(int restId)
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
                    cmd.CommandText = "Select * from Staff WHERE restid=@restid";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@restid", restId);
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
    }
}