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
    public class UserAccountBLL
    {
        //Retrieve username in UserAccount records to check if it exists 
        public int DoCheckUserNameExists(String userName)
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
                    cmd.CommandText = "Select * From UserAccount Where username=@username";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@username", userName));
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

        //Create a useraccount record
        public int DoCreateNewUser(string cName, string userName, string password)
        {
            UserAccount user = new UserAccount(userName, password, "Customer", "A");
            int newUserResult = 0;

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Insert into UserAccount(username, password, userrole, status) values(@username, @password, @userrole, @status)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@username", user.Username));
                    cmd.Parameters.Add(new NpgsqlParameter("@password", user.Password));
                    cmd.Parameters.Add(new NpgsqlParameter("@userrole", user.UserRole));
                    cmd.Parameters.Add(new NpgsqlParameter("@status", user.Status));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    connection.Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            UserAccount getUser = new UserAccount();
            getUser = DoGetUserByUsername(user.Username);

            if (getUser == null)
            {
                return 0;
            }

            else
            {
                CustomerBLL cBLL = new CustomerBLL();
                newUserResult = cBLL.DoCreateCustomer(getUser, cName);
            }

            return newUserResult;
        }

        //Retrieve user by username
        public UserAccount DoGetUserByUsername(string userName)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from UserAccount WHERE username=@username AND status='A'";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@username", userName);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();

                    string userId = dt.Rows[0]["usersid"].ToString();
                    string password = dt.Rows[0]["password"].ToString();
                    string userRole = dt.Rows[0]["userrole"].ToString();
                    string status = dt.Rows[0]["status"].ToString();

                    UserAccount user = new UserAccount(Convert.ToInt32(userId), userName, password, userRole, status);
                    return user;
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }

        //Create a New Rider Method
        public int DoCreateNewRider(string rName, string rUserName, string rPassword, Boolean isFullTime)
        {
            UserAccount user = new UserAccount(rUserName, rPassword, "Rider", "A");
            int newRiderResult = 0;

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Insert into UserAccount(username, password, userrole, status) values(@username, @password, @userrole, @status)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@username", user.Username));
                    cmd.Parameters.Add(new NpgsqlParameter("@password", user.Password));
                    cmd.Parameters.Add(new NpgsqlParameter("@userrole", user.UserRole));
                    cmd.Parameters.Add(new NpgsqlParameter("@status", user.Status));
                    int success = cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    if (success > 0)
                    {
                        UserAccount getUser = new UserAccount();
                        getUser = DoGetUserByUsername(user.Username);

                        if (getUser == null)
                        {
                            connection.Close();
                            return 0;
                        }

                        else
                        {
                            connection.Close(); //Close connection first
                            RiderBLL rideBLL = new RiderBLL();
                            newRiderResult = rideBLL.DoCreateRider(getUser, rName, isFullTime);
                        }
                    }

                    else
                    {
                        connection.Close();
                        return 0;
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return newRiderResult;
        }

        //Create a New Staff Method
        public int DoCreateNewStaff(string staffName, string sUserName, string sPwd, int restId)
        {
            UserAccount user = new UserAccount(sUserName, sPwd, "Staff", "A");
            int newStaffResult = 0;

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Insert into UserAccount(username, password, userrole, status) values(@username, @password, @userrole, @status)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@username", user.Username));
                    cmd.Parameters.Add(new NpgsqlParameter("@password", user.Password));
                    cmd.Parameters.Add(new NpgsqlParameter("@userrole", user.UserRole));
                    cmd.Parameters.Add(new NpgsqlParameter("@status", user.Status));
                    int success = cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    if (success > 0)
                    {
                        UserAccount getUser = new UserAccount();
                        getUser = DoGetUserByUsername(user.Username);

                        if (getUser == null)
                        {
                            connection.Close();
                            return 0;
                        }

                        else
                        {
                            connection.Close(); //Close connection first
                            StaffBLL staffBLL = new StaffBLL();
                            newStaffResult = staffBLL.DoCreateStaff(getUser, restId, staffName);
                        }
                    }

                    else
                    {
                        connection.Close();
                        return 0;
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return newStaffResult;
        }

        public int DoUpdatePassword(int userId, string userName, string newPwd)
        {
            int result = 0;
            UserAccount updateUserAccount = new UserAccount(userId, userName, newPwd);

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Update UserAccount Set password=@password Where usersid=@usersid";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@usersid", updateUserAccount.UserId));
                    cmd.Parameters.Add(new NpgsqlParameter("@password", updateUserAccount.Password));
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

        public void DoDeactivateAccount(int userId, string userName, string pwd, string userRole, string status)
        {
            UserAccount updateUserAccount = new UserAccount(userId, userName, pwd, userRole, status);

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Update UserAccount Set status='NA' Where usersId=@usersId";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@cid", updateUserAccount.UserId));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}