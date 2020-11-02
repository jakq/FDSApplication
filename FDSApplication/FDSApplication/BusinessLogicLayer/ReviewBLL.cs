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
    public class ReviewBLL
    {

        public int DoCheckReviewExists(int orderId)
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
                    cmd.CommandText = "Select * From Review Where orderId=@orderId";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@orderId", orderId));
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

        public int DoCreateReview(int orderId, int cId, int rId, int restId, int riderRating, int restaurantRating, string reviewTxt)
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
                    cmd.CommandText = "Insert into Review(orderId, cId, rId, restId, riderRating, restaurantRating, reviewTxt) values(@orderId, @cId, @rId, @restId, @riderRating, @restaurantRating, @reviewTxt)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@orderId", orderId));
                    cmd.Parameters.Add(new NpgsqlParameter("@cId", cId));
                    cmd.Parameters.Add(new NpgsqlParameter("@rId", rId));
                    cmd.Parameters.Add(new NpgsqlParameter("@restId", restId));
                    cmd.Parameters.Add(new NpgsqlParameter("@riderRating", riderRating));
                    cmd.Parameters.Add(new NpgsqlParameter("@restaurantRating", restaurantRating));
                    cmd.Parameters.Add(new NpgsqlParameter("@reviewTxt", reviewTxt));
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

        public Review DoRetrieveReviewByOrderID(int orderId)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from Review WHERE orderId=@orderId";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@orderId", orderId);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();

                    int ReviewId = Convert.ToInt32(dt.Rows[0]["reviewId"].ToString());
                    int OrderId = Convert.ToInt32(dt.Rows[0]["orderId"].ToString());
                    int CID = Convert.ToInt32(dt.Rows[0]["cId"].ToString());
                    int RID = Convert.ToInt32(dt.Rows[0]["rId"].ToString());
                    int RestID = Convert.ToInt32(dt.Rows[0]["restId"].ToString());
                    int RiderRating = Convert.ToInt32(dt.Rows[0]["riderRating"].ToString());
                    int RestaurantRating = Convert.ToInt32(dt.Rows[0]["restaurantRating"].ToString());
                    string ReviewTxt = dt.Rows[0]["reviewTxt"].ToString();

                    Review review = new Review(ReviewId, OrderId, CID, RID, RestID, RiderRating, RestaurantRating, ReviewTxt);
                    return review;
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }

        public Double DoRetrieveRiderAvgRating(int rId)
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
                    cmd.CommandText = "Select AVG(RiderRating) From Review Where rId=@rId";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@rId", rId));
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

        public DataTable DoRetrieveRestaurantRating(int restId)
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
                    cmd.CommandText = "Select * from Review where restId = @restId";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@restId", restId));
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

    }
}