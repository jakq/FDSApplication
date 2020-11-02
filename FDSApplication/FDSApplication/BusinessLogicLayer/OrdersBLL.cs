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
    public class OrdersBLL
    {
        public int DoCreateOrder(int custId, string transactionId, string paymentType, string ccNum, string deliverAddress,
            string contactNo, double deliveryFee, double totalCost, DateTime orderCreated, string isPaid, string status)
        {
            int result = 0;
            Orders orders = new Orders(custId, transactionId, paymentType, ccNum, deliverAddress, contactNo, 
                deliveryFee, totalCost, orderCreated, isPaid, status);

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Insert into Orders(cId, transactionId, paymentType, cardNum, deliverAddress, contactNo, deliveryFee, totalCost, orderCreated, isPaid, status) " +
                        "values(@cId, @transactionId, @paymentType, @cardNum, @deliverAddress, @contactNo, @deliveryFee, @totalCost, @orderCreated, @isPaid, @status)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@cId", orders.CId));
                    cmd.Parameters.Add(new NpgsqlParameter("@transactionId", orders.TransactionId));
                    cmd.Parameters.Add(new NpgsqlParameter("@paymentType", orders.PaymentType));
                    cmd.Parameters.Add(new NpgsqlParameter("@cardNum", orders.CardNum));
                    cmd.Parameters.Add(new NpgsqlParameter("@deliverAddress", orders.DeliverAddress));
                    cmd.Parameters.Add(new NpgsqlParameter("@contactNo", orders.ContactNo));
                    cmd.Parameters.Add(new NpgsqlParameter("@deliveryFee", orders.DeliveryFee));
                    cmd.Parameters.Add(new NpgsqlParameter("@totalCost", orders.TotalCost));
                    cmd.Parameters.Add(new NpgsqlParameter("@orderCreated", orders.OrderCreated));
                    cmd.Parameters.Add(new NpgsqlParameter("@isPaid", orders.IsPaid));
                    cmd.Parameters.Add(new NpgsqlParameter("@status", orders.Status));
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

        public DataTable DoRetrieveCustomerPastOrder(int custId)
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
                    cmd.CommandText = "Select * from Orders Where status='Completed' And cid=@cid";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
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

        public DataTable DoRetrieveCustomerCurrentOrder(int custId)
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
                    cmd.CommandText = "Select * from Orders Where status <>'Completed' And cid=@cid";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
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

        public DataTable DoRetrieveCustomerCompletedOrder(int custId)
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
                    cmd.CommandText = "Select * from Orders Where status='Completed' And cid=@cid";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
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

        public DataTable DoRetrieveNoRiderAllCustomerOrder()
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
                    cmd.CommandText = "Select orderId, paymentType, deliverAddress, contactNo, orderCreated, transactionId from Orders where rid is null";
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

        public DataTable DoRetrieveRiderAllCompletedCustomerOrder(int rId)
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
                    cmd.CommandText = "Select orderId, paymentType, deliverAddress, contactNo, orderCreated, transactionId from Orders where rid=@rid";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@rid", rId);
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

        public Orders DoRetrieveOrderByTransactionId(String transId)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from Orders WHERE transactionId=@transactionId";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@transactionId", transId);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();

                    int cid = Convert.ToInt32(dt.Rows[0]["cId"].ToString());
                    string transactionId = dt.Rows[0]["transactionId"].ToString();
                    string paymentType = dt.Rows[0]["paymentType"].ToString();
                    string cardNum = dt.Rows[0]["cardNum"].ToString();
                    string deliverAddress = dt.Rows[0]["deliverAddress"].ToString();
                    string contactNo = dt.Rows[0]["contactNo"].ToString();
                    double deliveryFee = Convert.ToDouble(dt.Rows[0]["deliveryFee"].ToString());
                    double totalCost = Convert.ToDouble(dt.Rows[0]["totalCost"].ToString());
                    string isPaid = dt.Rows[0]["isPaid"].ToString();
                    string status = dt.Rows[0]["status"].ToString();
                    DateTime orderCreated = DateTime.Parse(dt.Rows[0]["orderCreated"].ToString());

                    int rId = 0;

                    DateTime arriveTime = new DateTime();
                    DateTime departTime = new DateTime();
                    DateTime deliverTime = new DateTime();

                    if (DBNull.Value != dt.Rows[0]["rId"])
                    {
                        rId = Convert.ToInt32(dt.Rows[0]["rId"].ToString());
                    }

                    if (DBNull.Value != dt.Rows[0]["arriveTime"])
                    {
                        arriveTime = DateTime.Parse(dt.Rows[0]["arriveTime"].ToString());
                    }

                    if (DBNull.Value != dt.Rows[0]["departTime"])
                    {
                        departTime = DateTime.Parse(dt.Rows[0]["departTime"].ToString());
                    }

                    if (DBNull.Value != dt.Rows[0]["deliverTime"])
                    {
                        deliverTime = DateTime.Parse(dt.Rows[0]["deliverTime"].ToString());
                    }

                    Orders od = new Orders(cid, transactionId, rId, paymentType, cardNum, deliverAddress, contactNo, deliveryFee
                        , totalCost, orderCreated, arriveTime, departTime, deliverTime, isPaid, status);

                    return od;
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }

        public String DoRetrieveRiderCurrentOrderTransactionId(int rId)
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
                    cmd.CommandText = "Select transactionId from Orders where rId = @rId AND NOT Status = 'Completed'";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@rid", rId));
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();
                }

                return dt.Rows[0]["transactionid"].ToString();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }

        public int DoUpdateOrderStatus(String transId, String status, int rId)
        {
            int result = 0;

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    if (status == "Accept")
                    {
                        connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                        connection.Open();
                        NpgsqlCommand cmd = new NpgsqlCommand();
                        cmd.Connection = connection;
                        cmd.CommandText = "Update Orders Set status=@status,rid=@rid Where transactionId=@transactionId";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new NpgsqlParameter("@transactionId", transId));
                        cmd.Parameters.Add(new NpgsqlParameter("@status", status));
                        cmd.Parameters.Add(new NpgsqlParameter("@rid", rId));
                        result = cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        connection.Close();
                    }

                    else
                    {
                        connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                        connection.Open();
                        NpgsqlCommand cmd = new NpgsqlCommand();
                        cmd.Connection = connection;
                        cmd.CommandText = "Update Orders Set status=@status Where transactionId=@transactionId";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new NpgsqlParameter("@transactionId", transId));
                        cmd.Parameters.Add(new NpgsqlParameter("@status", status));

                        result = cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        connection.Close();
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return result;
        }

        public int DoUpdatePaymentStatus(String transId)
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
                    cmd.CommandText = "Update Orders Set isPaid=@isPaid Where transactionId=@transactionId";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@transactionId", transId));
                    String isPaid = "YP";
                    cmd.Parameters.Add(new NpgsqlParameter("@isPaid", isPaid));
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

        public int DoUpdateOrderArriveTime(String transId, int rId, DateTime arrivetime)
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
                    cmd.CommandText = "Update Orders Set arriveTime=@arrivetime Where transactionId=@transactionId";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@transactionId", transId));
                    cmd.Parameters.Add(new NpgsqlParameter("@arrivetime", arrivetime));
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

        public int DoUpdateOrderDepartTime(String transId, DateTime departtime)
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
                    cmd.CommandText = "Update Orders Set departTime=@departtime Where transactionId=@transactionId";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@transactionId", transId));
                    cmd.Parameters.Add(new NpgsqlParameter("@departtime", departtime));

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

        public int DoUpdateOrderDeliverTime(String transId, DateTime delivertime)
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
                    cmd.CommandText = "Update Orders Set delivertime=@delivertime Where transactionId=@transactionId";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@transactionId", transId));
                    cmd.Parameters.Add(new NpgsqlParameter("@delivertime", delivertime));

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

        public Orders DoRetrieveUserOrderDetails(int orderId)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from Orders WHERE orderId=@orderId";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@orderId", orderId);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();

                    int cid = Convert.ToInt32(dt.Rows[0]["cId"].ToString());
                    string transactionId = dt.Rows[0]["transactionId"].ToString();
                    string paymentType = dt.Rows[0]["paymentType"].ToString();
                    string cardNum = dt.Rows[0]["cardNum"].ToString();
                    string deliverAddress = dt.Rows[0]["deliverAddress"].ToString();
                    string contactNo = dt.Rows[0]["contactNo"].ToString();
                    double deliveryFee = Convert.ToDouble(dt.Rows[0]["deliveryFee"].ToString());
                    double totalCost = Convert.ToDouble(dt.Rows[0]["totalCost"].ToString());
                    string isPaid = dt.Rows[0]["isPaid"].ToString();
                    string status = dt.Rows[0]["status"].ToString();
                    DateTime orderCreated = DateTime.Parse(dt.Rows[0]["orderCreated"].ToString());

                    int rId = 0;

                    DateTime arriveTime = new DateTime();
                    DateTime departTime = new DateTime();
                    DateTime deliverTime = new DateTime();

                    if (DBNull.Value != dt.Rows[0]["rId"])
                    {
                        rId = Convert.ToInt32(dt.Rows[0]["rId"].ToString());
                    }

                    if (DBNull.Value != dt.Rows[0]["arriveTime"])
                    {
                        arriveTime = DateTime.Parse(dt.Rows[0]["arriveTime"].ToString());
                    }

                    if (DBNull.Value != dt.Rows[0]["departTime"])
                    {
                        departTime = DateTime.Parse(dt.Rows[0]["departTime"].ToString());
                    }

                    if (DBNull.Value != dt.Rows[0]["deliverTime"])
                    {
                        deliverTime = DateTime.Parse(dt.Rows[0]["deliverTime"].ToString());
                    }

                    Orders od = new Orders(orderId, cid, transactionId, rId, paymentType, cardNum, deliverAddress, contactNo, deliveryFee
                        , totalCost, orderCreated, arriveTime, departTime, deliverTime, isPaid, status);

                    return od;
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }
    }
}