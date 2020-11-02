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
    public class CreditCardBLL
    {
        public int DoCheckCreditCardExists(String ccNum)
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
                    cmd.CommandText = "Select * From CreditCard Where ccNum=@ccNum";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@ccNum", ccNum));
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

        public int DoCreateCreditCard(int custId, string ccNum, string ccv, string ccExpiry)
        {
            int result = 0;
            CreditCard creditCard = new CreditCard(custId, ccNum, ccv, ccExpiry);

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Insert into CreditCard(cId, ccNum, ccv, ccExpiry) values(@cid, @ccNum, @ccv, @ccExpiry)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@cId", creditCard.CId));
                    cmd.Parameters.Add(new NpgsqlParameter("@ccNum", creditCard.CcNum));
                    cmd.Parameters.Add(new NpgsqlParameter("@ccv", creditCard.Ccv));
                    cmd.Parameters.Add(new NpgsqlParameter("@ccExpiry", creditCard.CcExpiry));
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

        public DataTable DoRetrieveAllCustomerCreditCard(int custId)
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
                    cmd.CommandText = "Select * from CreditCard Where cId=@cId";
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

        public int DoDeleteCreditCard(int ccId)
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
                    cmd.CommandText = "Delete From CreditCard Where ccId=@ccId";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@ccId", ccId));
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