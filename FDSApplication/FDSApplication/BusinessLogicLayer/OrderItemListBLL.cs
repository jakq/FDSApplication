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
    public class OrderItemListBLL
    {
        public int DoCheckIfTransactionIDExists(string transactionId)
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
                    cmd.CommandText = "Select * From OrderItemList Where transactionId=@transactionId";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@transactionId", transactionId));
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

        public int DoCheckIfFoodIDExists(string transactionId, int foodId)
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
                    cmd.CommandText = "Select * From OrderItemList Where transactionId=@transactionId And foodId=@foodId";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@transactionId", transactionId));
                    cmd.Parameters.Add(new NpgsqlParameter("@foodId", foodId));
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

        public int DoCreateFoodItemRecord(string transactionId, int custId, int foodId, int orderQuantity)
        {
            string checkOutStatus = "N";
            OrderItemList newOrderItemList = new OrderItemList(transactionId, custId, foodId, orderQuantity, checkOutStatus);
            int result = 0;

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Insert into OrderItemList(transactionId, cId, foodId, orderquantity, checkout) values(@transactionId, @cId, @foodId, @orderquantity, @checkout)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@transactionId", newOrderItemList.TransactionId));
                    cmd.Parameters.Add(new NpgsqlParameter("@cId", newOrderItemList.CustId));
                    cmd.Parameters.Add(new NpgsqlParameter("@foodId", newOrderItemList.FoodId));
                    cmd.Parameters.Add(new NpgsqlParameter("@orderquantity", newOrderItemList.OrderQuantity));
                    cmd.Parameters.Add(new NpgsqlParameter("@checkout", newOrderItemList.Checkout));
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

        public DataTable DoRetrieveCustomerOrderItem(string transactionId, int custId)
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
                    cmd.CommandText = "Select * from OrderItemList ol Inner Join FoodItem fi ON ol.foodId = fi.foodId " +
                        "Inner Join Restaurant r ON fi.restId = r.restId Where checkout='N' And transactionId=@transactionId And cid=@cid";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@transactionId", transactionId);
                    da.SelectCommand.Parameters.AddWithValue("@cId", custId);
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

        public int DoUpdateFoodItemQuantityByIncreaseCount(string transactionId, int custId, int foodId, int orderQuantity)
        {
            int newOrderQuantity = orderQuantity + 1; //Increase by One

            OrderItemList newOrderItemList = new OrderItemList(transactionId, custId, foodId, newOrderQuantity);
            int result = 0;

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Update OrderItemList Set orderquantity=@orderquantity Where foodId=@foodId And transactionId=@transactionId";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@foodId", newOrderItemList.FoodId));
                    cmd.Parameters.Add(new NpgsqlParameter("@transactionId", newOrderItemList.TransactionId));
                    cmd.Parameters.Add(new NpgsqlParameter("@orderquantity", newOrderItemList.OrderQuantity));
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

        public int DoUpdateFoodItemQuantityByDecreaseCount(string transactionId, int custId, int foodId, int orderQuantity)
        {
            int newOrderQuantity = orderQuantity - 1; //Decrease by One

            OrderItemList newOrderItemList = new OrderItemList(transactionId, custId, foodId, newOrderQuantity);
            int result = 0;

            if (newOrderItemList.OrderQuantity <= 0)
            {
                try
                {
                    using (NpgsqlConnection connection = new NpgsqlConnection())
                    {
                        connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                        connection.Open();
                        NpgsqlCommand cmd = new NpgsqlCommand();
                        cmd.Connection = connection;
                        cmd.CommandText = "Delete From OrderItemList Where foodId=@foodId And transactionId=@transactionId";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new NpgsqlParameter("@foodId", newOrderItemList.FoodId));
                        cmd.Parameters.Add(new NpgsqlParameter("@transactionId", newOrderItemList.TransactionId));
                        result = cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        connection.Close();
                    }

                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            else
            {
                try
                {
                    using (NpgsqlConnection connection = new NpgsqlConnection())
                    {
                        connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                        connection.Open();
                        NpgsqlCommand cmd = new NpgsqlCommand();
                        cmd.Connection = connection;
                        cmd.CommandText = "Update OrderItemList Set orderquantity=@orderquantity Where foodId=@foodId And transactionId=@transactionId";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new NpgsqlParameter("@foodId", newOrderItemList.FoodId));
                        cmd.Parameters.Add(new NpgsqlParameter("@transactionId", newOrderItemList.TransactionId));
                        cmd.Parameters.Add(new NpgsqlParameter("@orderquantity", newOrderItemList.OrderQuantity));
                        result = cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        connection.Close();
                    }

                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            return result;
        }

        public OrderItemList DoRetrieveExisitngCustomerFoodItemListByCustId(int custId)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from OrderItemList WHERE cId=@cid And checkout='N' ";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@cId", custId);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();

                    int lineId = Convert.ToInt32(dt.Rows[0]["lineId"].ToString());
                    string transactionId = dt.Rows[0]["transactionId"].ToString();
                    int foodId = Convert.ToInt32(dt.Rows[0]["foodId"].ToString());
                    int orderQuantity = Convert.ToInt32(dt.Rows[0]["orderquantity"].ToString());
                    string checkOut = dt.Rows[0]["checkout"].ToString();

                    OrderItemList orderItemList = new OrderItemList(lineId, transactionId, custId, foodId, orderQuantity, checkOut);
                    return orderItemList;
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }

        public int DoClearExistingOrderItemList(string transactionId)
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
                    cmd.CommandText = "Delete From OrderItemList Where transactionId=@transactionId";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@transactionId", transactionId));
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

        public Restaurant DoCheckOrderLineItemForExistingRestaurant(string transactionId)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from OrderItemList ol Inner Join FoodItem fi ON ol.foodId = fi.foodId " +
                        "Inner Join Restaurant r ON fi.restId = r.restId Where checkout='N' And transactionId=@transactionId";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@transactionId", transactionId);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();

                    int restId = Convert.ToInt32(dt.Rows[0]["restId"].ToString());
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

        public int DoUpdateFoodItemListCheckOut(string transactionId)
        {
            string checkout = "Y";

            OrderItemList orderItemList = new OrderItemList(transactionId, checkout);
            int result = 0;

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Update OrderItemList Set checkout=@checkout Where transactionId=@transactionId";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@transactionId", orderItemList.TransactionId));
                    cmd.Parameters.Add(new NpgsqlParameter("@checkout", orderItemList.Checkout));
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

        public DataTable DoRetrieveCustomerOrderItemByTransactionId(string transactionId)
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
                    cmd.CommandText = "Select * from OrderItemList ol Inner Join FoodItem fi ON ol.foodId = fi.foodId " +
                        "Inner Join Restaurant r ON fi.restId = r.restId Where checkout='Y' And transactionId=@transactionId";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@transactionId", transactionId);
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

        public int DoRetrieveRestaurantID(string transactionId)
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
                    cmd.CommandText = "Select restId from OrderItemList ol Inner Join FoodItem fi ON ol.foodId = fi.foodId " +
                        " Where transactionId=@transactionId";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@transactionId", transactionId);
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();

                    int restId = Convert.ToInt32(dt.Rows[0]["restId"].ToString());
                    return restId;
                }
                
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return 0;
        }
    }
}