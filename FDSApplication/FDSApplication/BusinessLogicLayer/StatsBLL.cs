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
    public class StatsBLL
    {
        public int DoCountTotalCustomers()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select Count(*) As Number from Customers";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();

                    int custNum = int.Parse(dt.Rows[0]["Number"].ToString());       
                    return custNum;
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return 0;
        }

        public int DoCountTotalRiders()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select Count(*) As Number from Rider";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();

                    int riderNum = int.Parse(dt.Rows[0]["Number"].ToString());
                    return riderNum;
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return 0;
        }

        public int DoCountTotalStaffs()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select Count(*) As Number from Staff";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();

                    int staffNum = int.Parse(dt.Rows[0]["Number"].ToString());
                    return staffNum;
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return 0;
        }

        public DataTable DoCountFoodItemsByCategory()
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
                    cmd.CommandText = "Select foodcategory, count(*) As number from FoodItem Group By foodcategory";
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

        public int DoCountTotalFoodItems(int restId)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select Count(*) As Number from FoodItem Where restId=@restId";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@restid", restId);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();

                    int foodItemNum = int.Parse(dt.Rows[0]["Number"].ToString());
                    return foodItemNum;
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return 0;
        }

        public int DoCountTotalReviews(int restId)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select Count(*) As Number from Review Where restId=@restId";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@restid", restId);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();

                    int reviewNum = int.Parse(dt.Rows[0]["Number"].ToString());
                    return reviewNum;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return 0;
        }

        public DataTable DoFindPopularFoodItem(int restId)
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
                    cmd.CommandText = "Select foodtitle, ordercounter from FoodItem Where restId=@restId Order By ordercounter Desc LIMIT 5";
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

        public int DoCountTotalAvailableOrders()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select Count(*) As Number from Orders Where status='Pending Rider'";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();

                    int totalAvailOrders = int.Parse(dt.Rows[0]["Number"].ToString());
                    return totalAvailOrders;
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return 0;
        }

        public int DoCountOrdersDoneByRider(int rId)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select Count(*) As Number from Orders Where rid=@rid";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@rid", rId);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();

                    int ordersDone = int.Parse(dt.Rows[0]["Number"].ToString());
                    return ordersDone;
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return 0;
        }

        public int DoCountTotalOrders()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select Count(*) As Number from Orders";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();

                    int totalOrders = int.Parse(dt.Rows[0]["Number"].ToString());
                    return totalOrders;
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return 0;
        }

        public double DoCountTotalOrderAmount()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select Sum(totalcost) As OrderSum from Orders";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();

                    double totalOrderAmt = double.Parse(dt.Rows[0]["OrderSum"].ToString());
                    return totalOrderAmt;
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return 0;
        }

        public string DoRetrieveRecentLocation(int custId)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select recentlocation from Customers Where cId=@cId";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@cId", custId);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();

                    string recentLocation = dt.Rows[0]["recentlocation"].ToString();
                    return recentLocation;
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return "";
        }

        public int DoCountCustomersOrder(int custId)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select Count(*) As Number from Orders Where cid=@cid";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@cid", custId);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();

                    int custOrders = int.Parse(dt.Rows[0]["Number"].ToString());
                    return custOrders;
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return 0;
        }

        public int DoCountCustomersReviews(int custId)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select Count(*) As Number from Review Where cid=@cid";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@cid", custId);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();

                    int custOrders = int.Parse(dt.Rows[0]["Number"].ToString());
                    return custOrders;
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return 0;
        }

        public DataTable DoFindCustomersMostOrders()
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
                    cmd.CommandText = "Select cname, count(*) As number from Orders o Inner Join Customers c On o.cid = c.cid Group By cname " +
                        "Order By number Desc Limit 5";
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

        public int DoCountOrderForRiderMonth(int rid, int year, int month)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "select count(*) as Number from orders o1 where o1.rid = @rid and extract(month from arrivetime) = @month and extract(year from arrivetime) = @year";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@rid", rid);
                    da.SelectCommand.Parameters.AddWithValue("@year", year);
                    da.SelectCommand.Parameters.AddWithValue("@month", month);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();

                    int custOrders = int.Parse(dt.Rows[0]["Number"].ToString());
                    return custOrders;
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return 0;
        }

        public double DoCountHoursWorkedForFTRiderMonth(int rid, int year, int month)
        {
            double result = 0;
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "select Cast(extract(Hour from sum(w1.wwsendtime - w1.wwsstarttime) + sum(w1.wwsendtimetwo - w1.wwsstarttimetwo)) as double precision) as Number from MWS m1 inner join WWS w1 on m1.mwsid = w1.mwsid where m1.rid = @rid and extract(month from wwsdate) = @month and extract(year from wwsdate) = @year";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@rid", rid);
                    da.SelectCommand.Parameters.AddWithValue("@year", year);
                    da.SelectCommand.Parameters.AddWithValue("@month", month);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();
                    result = double.Parse(dt.Rows[0]["Number"].ToString());
                    return result;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return result;
        }

        public double DoCountHoursWorkedForPTRiderMonth(int rid, int year, int month)
        {
            double result = 0;
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "select Cast(extract(Hour from sum(pt1.ptwwsEndTime - pt1.ptwwsStartTime) + sum(pt1.ptwwsEndTimeTwo - pt1.ptwwsStartTimeTwo) + sum(pt1.ptwwsEndTimeThree - pt1.ptwwsStartTimeThree)) as double precision) as Number from ptwws pw1 inner join ptdayschedule pt1 on pw1.ptwwsid = pt1.ptwwsid where pw1.rid = @rid and extract(month from ptwwsdate) = @month and extract(year from ptwwsdate) = @year";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@rid", rid);
                    da.SelectCommand.Parameters.AddWithValue("@year", year);
                    da.SelectCommand.Parameters.AddWithValue("@month", month);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();
                    result = double.Parse(dt.Rows[0]["Number"].ToString());
                    return result;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return result;
        }

        public DateTime DoCountRiderAverageDeliverTimeByMonth(int rid, int year, int month)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "select sum(o1.delivertime - o1.arrivetime)/count(*) from orders o1 where o1.rid = @rid and extract(month from arrivetime) = @month and extract(year from arrivetime) = @year";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@rid", rid);
                    da.SelectCommand.Parameters.AddWithValue("@year", year);
                    da.SelectCommand.Parameters.AddWithValue("@month", month);
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
            return DateTime.MaxValue;
        }

        public int DoCountRatingsForRiderMonth(int rid, int year, int month)
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
                    cmd.CommandText = "select count(*) as Number from orders o1 inner join review r1 on o1.orderid = r1.orderid where r1.rid = @rid and extract (month from arrivetime) = @month and extract (year from arrivetime) = @year";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@rid", rid);
                    da.SelectCommand.Parameters.AddWithValue("@year", year);
                    da.SelectCommand.Parameters.AddWithValue("@month", month);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();
                    result = int.Parse(dt.Rows[0]["Number"].ToString());
                    return result;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return result;
        }

        public double DoCountAverageRiderRatingMonth(int rid, int year, int month)
        {
            double result = 0;
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "select sum(r1.riderrating)*1.0/count(*) as Number from orders o1 inner join review r1 on o1.orderid = r1.orderid where r1.rid = @rid and extract (month from arrivetime) = @month and extract (year from arrivetime) = @year";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@rid", rid);
                    da.SelectCommand.Parameters.AddWithValue("@year", year);
                    da.SelectCommand.Parameters.AddWithValue("@month", month);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();
                    result = double.Parse(dt.Rows[0]["Number"].ToString());
                    return result;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return result;
        }

        public double DoCountFTRiderSalaryMonth(int rid, int year, int month)
        {
            double result = 0;
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "WITH ordercount As (Select sum(deliveryFee) As orderfilled From orders o1 Where o1.rid = @rid And extract(month from arrivetime) = @month and extract(year from arrivetime) = @year) , " +
                        "daycount As (Select count(*) As daysworked From  MWS m1 Inner Join WWS w1 On m1.mwsid = w1.mwsid Where m1.rid = @rid And extract(month from wwsdate) = @month and extract(year from wwsdate) = @year) " +
                        "Select orderfilled + daysworked * r1.salary as Number from rider r1, ordercount o1, daycount d1 where r1.rid = @rid";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@rid", rid);
                    da.SelectCommand.Parameters.AddWithValue("@year", year);
                    da.SelectCommand.Parameters.AddWithValue("@month", month);
                    //da.SelectCommand.Parameters.AddWithValue("@fee", fee);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();
                    result = double.Parse(dt.Rows[0]["Number"].ToString());
                    return result;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return result;
        }

        public double DoCountPTRiderSalaryMonth(int rid, int year, int month)
        {
            double result = 0;
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "WITH ordercount As(Select sum(deliveryFee) As orderfilled From orders o1 Where o1.rid = @rid And extract(month from arrivetime) = @month and extract(year from arrivetime) = @year) , " +
                        "daycount As (Select count(*) as daysworked From ptwws pw1 Inner Join ptdayschedule pt1 On pw1.ptwwsid = pt1.ptwwsid Where pw1.rid = @rid And extract(month from ptwwsdate) = @month and extract(year from ptwwsdate) = @year ) " +
                        "Select orderfilled + daysworked * r1.salary as Number from rider r1, ordercount o1, daycount d1 where r1.rid = @rid";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@rid", rid);
                    da.SelectCommand.Parameters.AddWithValue("@year", year);
                    da.SelectCommand.Parameters.AddWithValue("@month", month);
                    //da.SelectCommand.Parameters.AddWithValue("@fee", fee);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();
                    result = double.Parse(dt.Rows[0]["Number"].ToString());
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