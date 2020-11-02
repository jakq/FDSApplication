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
    public class RestaurantBLL
    {
        //Method to create Restaurant record
        public int DoCreateRestaurant(string restName, string restAddress, string restArea, double minAmnt)
        {
            int result = 0;
            Restaurant restaurant = new Restaurant(restName, restAddress, restArea, minAmnt);

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Insert into Restaurant(restName, restAddress, restArea, minAmnt) values(@restName, @restAddress, @restArea, @minAmnt)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@restName", restName));
                    cmd.Parameters.Add(new NpgsqlParameter("@restAddress", restAddress));
                    cmd.Parameters.Add(new NpgsqlParameter("@restArea", restArea));
                    cmd.Parameters.Add(new NpgsqlParameter("@minAmnt", minAmnt));
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

        //Retrieve all Restaurant records
        public DataTable DoRetrieveAllRestaurants()
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
                    cmd.CommandText = "Select * from Restaurant";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
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

        //Retrieve Restaurant by restaurant ID
        public Restaurant DoRetrieveRestaurantByRestID(int restId)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from Restaurant WHERE restid=@restid";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@restid", restId);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();

                    string restName = dt.Rows[0]["restname"].ToString();
                    string restAddress = dt.Rows[0]["restAddress"].ToString();
                    string restArea = dt.Rows[0]["restarea"].ToString();
                    string minAmnt = dt.Rows[0]["minamnt"].ToString();

                    Restaurant restaurant = new Restaurant(restId, restName, restAddress, restArea, Convert.ToDouble(minAmnt));
                    return restaurant;
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }

        //Update restaurant record
        public int DoUpdateRestaurant(int restId, string restName, string restAddress, string restArea, double minAmnt)
        {
            int result = 0;
            Restaurant updateRestaurant = new Restaurant(restName, restAddress, restArea, minAmnt);

            try 
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Update Restaurant Set restname=@restname,restaddress=@restaddress, restarea=@restarea,minamnt=@minamnt where restid=@restid";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@restid", restId));
                    cmd.Parameters.Add(new NpgsqlParameter("@restname", restName));
                    cmd.Parameters.Add(new NpgsqlParameter("@restaddress", restAddress));
                    cmd.Parameters.Add(new NpgsqlParameter("@restarea", restArea));
                    cmd.Parameters.Add(new NpgsqlParameter("@minamnt", minAmnt));
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

        public DataTable DoRetrieveRestaurantByArea(string rArea)
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
                    cmd.CommandText = "Select * from Restaurant Where restArea=@restArea";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@restArea", rArea);
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

        public int DoRetrieveRestIdByTransactionId(string transactionId)
        {
            int result = 0;
            try
            {
                DataTable dt = new DataTable();
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from OrderItemList ol Inner Join FoodItem fi ON ol.foodId = fi.foodId " +
                        "Inner Join Restaurant r ON fi.restId = r.restId Where checkout='Y' And transactionId=@transactionId";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@transactionId", transactionId);
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();

                    result = Convert.ToInt32(dt.Rows[0]["restId"].ToString());
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