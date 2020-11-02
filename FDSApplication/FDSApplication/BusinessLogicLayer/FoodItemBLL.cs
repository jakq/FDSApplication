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
    public class FoodItemBLL
    {
        public int DoCreateFoodItem(int restId, string foodCategory, string foodTitle, double price, int dailyLimit, int orderCounter)
        {
            int result = 0;
            FoodItem foodItem = new FoodItem(restId, foodCategory, foodTitle, price, dailyLimit, orderCounter);

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Insert into FoodItem(restId, foodCategory, foodTitle, orderCounter, price, dailyLimit)" +
                        " Values(@restId, @foodCategory, @foodTitle, @orderCounter, @price, @dailyLimit)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@restId", foodItem.RestId));
                    cmd.Parameters.Add(new NpgsqlParameter("@foodCategory", foodItem.FoodCategory));
                    cmd.Parameters.Add(new NpgsqlParameter("@foodTitle", foodItem.FoodTitle));
                    cmd.Parameters.Add(new NpgsqlParameter("@orderCounter", foodItem.OrderCounter));
                    cmd.Parameters.Add(new NpgsqlParameter("@price", foodItem.Price));
                    cmd.Parameters.Add(new NpgsqlParameter("@dailyLimit", foodItem.DailyLimit));
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

        public DataTable DoRetrieveAllFoodItemByRestId(int restId)
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
                    cmd.CommandText = "Select * from FoodItem Where restId=@restId";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.Add(new NpgsqlParameter("@restId", restId));
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

        public FoodItem DoRetrieveFoodItemByFoodId(int foodId)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from FoodItem WHERE foodid=@foodid";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@foodid", foodId);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();

                    int restId = Convert.ToInt32(dt.Rows[0]["restId"].ToString());
                    string foodCategory = dt.Rows[0]["foodcategory"].ToString();
                    string foodTitle = dt.Rows[0]["foodtitle"].ToString();
                    double price = Convert.ToDouble(dt.Rows[0]["price"].ToString());
                    int dailyLimit = Convert.ToInt32(dt.Rows[0]["dailylimit"].ToString());
                    int orderCounter = Convert.ToInt32(dt.Rows[0]["ordercounter"].ToString());

                    FoodItem foodItem = new FoodItem(foodId, restId, foodCategory, foodTitle, price, dailyLimit, orderCounter);
                    return foodItem;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }

        public int DoUpdateFoodItem(int foodId, int restId, string foodCategory, string foodTitle, double price, int dailyLimit)
        {
            int result = 0;
            FoodItem updateFoodItem = new FoodItem(foodId, restId, foodCategory, foodTitle, price, dailyLimit);

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Update FoodItem Set foodcategory=@foodcategory,foodtitle=@foodtitle," +
                        "price=@price, dailylimit=@dailylimit Where foodid=@foodid";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@foodid", updateFoodItem.FoodId));                   
                    cmd.Parameters.Add(new NpgsqlParameter("@foodcategory", updateFoodItem.FoodCategory));
                    cmd.Parameters.Add(new NpgsqlParameter("@foodtitle", updateFoodItem.FoodTitle));
                    cmd.Parameters.Add(new NpgsqlParameter("@price", updateFoodItem.Price));
                    cmd.Parameters.Add(new NpgsqlParameter("@dailyLimit", updateFoodItem.DailyLimit));
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

        public int DoUpdateOrderCount(int foodId, int orderCount)
        {
            int result = 0;
            FoodItem updateFoodItem = new FoodItem(foodId, orderCount);

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Update FoodItem Set orderCounter=@orderCounter Where foodid=@foodid";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@foodid", updateFoodItem.FoodId));
                    cmd.Parameters.Add(new NpgsqlParameter("@orderCounter", updateFoodItem.OrderCounter));
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