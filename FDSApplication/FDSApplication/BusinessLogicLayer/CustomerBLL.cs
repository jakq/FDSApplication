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
    public class CustomerBLL
    {
        //Method to Create a Customer Record
        public int DoCreateCustomer(UserAccount user, string cName)
        {
            int result = 0;
            Customer customer = new Customer(user.UserId, cName, 0);

            try 
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Insert into Customers(cId, cName, rewardpoint) values(@cId, @cName, @rewardpoint)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@cid", customer.CId));
                    cmd.Parameters.Add(new NpgsqlParameter("@cname", customer.CName));
                    cmd.Parameters.Add(new NpgsqlParameter("@rewardpoint", customer.RewardPoint));
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

        //Retrieve customer record based on customer id
        public Customer DoRetrieveCustomerByID(int custId)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from Customers WHERE cid=@cid";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@cid", custId);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();

                    string custName = dt.Rows[0]["cname"].ToString();
                    int rewardPoint = Convert.ToInt32(dt.Rows[0]["rewardpoint"].ToString());

                    Customer customer = new Customer(custId, custName, rewardPoint);
                    return customer;
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }


        public int DoUpdateCustomer(int custId, string custName)
        {
            int result = 0;
            Customer updateCustomer = new Customer(custId, custName);

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Update Customers Set cname=@cname Where cid=@cid";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@cid", custId));
                    cmd.Parameters.Add(new NpgsqlParameter("@cname", custName));
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

        public int DoUpdateCustomerRewardPointRecentLocation(int custId, int rewardPoint, string location)
        {
            int result = 0;
            Customer updateCustomer = new Customer(custId, rewardPoint, location);

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Update Customers Set rewardpoint=@rewardpoint, recentlocation=@recentlocation Where cid=@cid";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@cid", updateCustomer.CId));
                    cmd.Parameters.Add(new NpgsqlParameter("@rewardpoint", updateCustomer.RewardPoint));
                    cmd.Parameters.Add(new NpgsqlParameter("@recentlocation", updateCustomer.RecentLocation));
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

        public int DoDeleteCustomerRecentLocation(int custId)
        {
            int result = 0;
            string recentLocation = "";

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Update Customers Set recentlocation=@recentlocation Where cid=@cid";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@cid", custId));
                    cmd.Parameters.Add(new NpgsqlParameter("@recentlocation", recentLocation));
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