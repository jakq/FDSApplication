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
    public class PromoBLL
    {
        public int DoCreatePromo(int restId, double promoValue, string promoDesc, string promoType, DateTime promoStartDate, DateTime promoEndDate,
            string promoCode)
        {
            int result = 0;
            Promo promo = new Promo(restId, promoValue, promoDesc, promoType, promoStartDate, promoEndDate, promoCode);

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Insert into Promo(restId, promoValue, promoDesc, promoType, promoStartDate, promoEndDate, promoCode)" +
                        " Values(@restId, @promoValue, @promoDesc, @promoType, @promoStartDate, @promoEndDate, @promoCode)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@restId", promo.RestId));
                    cmd.Parameters.Add(new NpgsqlParameter("@promoValue", promo.PromoValue));
                    cmd.Parameters.Add(new NpgsqlParameter("@promoDesc", promo.PromoDesc));
                    cmd.Parameters.Add(new NpgsqlParameter("@promoType", promo.PromoType));
                    cmd.Parameters.Add(new NpgsqlParameter("@promoStartDate", promo.PromoStartDate));
                    cmd.Parameters.Add(new NpgsqlParameter("@promoEndDate", promo.PromoEndDate));
                    cmd.Parameters.Add(new NpgsqlParameter("@promoCode", promo.PromoCode));
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

        public DataTable DoRetrieveAllPromoByRestId(int restId)
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
                    cmd.CommandText = "Select * from Promo Where restId=@restId Order By promoenddate desc";
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

        public Promo DoRetrievePromoByPromoId(int promoId)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from Promo WHERE promoId=@promoId";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@promoId", promoId);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();

                    int restId = Convert.ToInt32(dt.Rows[0]["restId"].ToString());
                    double promoValue = Convert.ToDouble(dt.Rows[0]["promoValue"].ToString());
                    string promoDesc = dt.Rows[0]["promoDesc"].ToString();
                    string promoType = dt.Rows[0]["promoType"].ToString();
                    DateTime promoStartDate = Convert.ToDateTime(dt.Rows[0]["promoStartDate"].ToString());
                    DateTime promoEndDate = Convert.ToDateTime(dt.Rows[0]["promoEndDate"].ToString());
                    string promoCode = dt.Rows[0]["promoCode"].ToString();

                    Promo promo = new Promo(promoId, restId, promoValue, promoDesc, promoType, promoStartDate, promoEndDate, promoCode);
                    return promo;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }

        public int DoUpdatePromo(int promoId, double promoValue, string promoDesc, string promoType, DateTime promoStartDate, DateTime promoEndDate,
            string promoCode)
        {
            int result = 0;
            Promo updatePromo = new Promo(promoValue, promoDesc, promoType, promoStartDate, promoEndDate, promoCode, promoId);

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Update Promo Set promoValue=@promoValue, promoDesc=@promoDesc, promoType=@promoType, " +
                        "promoStartDate=@promoStartDate, promoEndDate=@promoEndDate, promoCode=@promoCode Where promoId=@promoId";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@promoId", updatePromo.PromoId));
                    cmd.Parameters.Add(new NpgsqlParameter("@promoValue", updatePromo.PromoValue));
                    cmd.Parameters.Add(new NpgsqlParameter("@promoDesc", updatePromo.PromoDesc));
                    cmd.Parameters.Add(new NpgsqlParameter("@promoType", updatePromo.PromoType));
                    cmd.Parameters.Add(new NpgsqlParameter("@promoStartDate", updatePromo.PromoStartDate));
                    cmd.Parameters.Add(new NpgsqlParameter("@promoEndDate", updatePromo.PromoEndDate));
                    cmd.Parameters.Add(new NpgsqlParameter("@promoCode", updatePromo.PromoCode));
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

        public DataTable DoRetrieveValidPromoByRestId(int restId, DateTime currDate)
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
                    cmd.CommandText = "Select * from Promo Where restId=@restId And (@promostartdate > promostartdate And promoenddate > @promoenddate)";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.Add(new NpgsqlParameter("@restId", restId));
                    da.SelectCommand.Parameters.Add(new NpgsqlParameter("@promostartdate", currDate));
                    da.SelectCommand.Parameters.Add(new NpgsqlParameter("@promoenddate", currDate));
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();
                    int num = dt.Rows.Count;
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