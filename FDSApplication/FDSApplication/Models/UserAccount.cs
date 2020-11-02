using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDSApplication.Models
{
    public class UserAccount
    {
        private int userId;
        private string username;
        private string password;
        private string userRole;
        private string status;

        public int UserId { get => userId; set => userId = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string UserRole { get => userRole; set => userRole = value; }
        public string Status { get => status; set => status = value; }

        public UserAccount()
        {

        }

        public UserAccount(int userId, string username, string password, string userRole, string status)
        {
            this.userId = userId;
            this.username = username;
            this.password = password;
            this.userRole = userRole;
            this.status = status;
        }

        public UserAccount(int userId, string username, string password, string userRole)
        {
            this.userId = userId;
            this.username = username;
            this.password = password;
            this.userRole = userRole;
        }

        public UserAccount(string username, string password, string userRole, string status)
        {
            this.username = username;
            this.password = password;
            this.userRole = userRole;
            this.status = status;
        }

        public UserAccount(int userId, string username, string password)
        {
            this.userId = userId;
            this.username = username;
            this.password = password;
        }

        public void setStatusToNotActive()
        {
            status = "NA";
        }

        public void setStatusToActive()
        {
            status = "A";
        }

    }
}