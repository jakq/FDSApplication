using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDSApplication.Models
{
    public class Customer
    {
        private int cId;
        private string cName;
        private int rewardPoint;
        private string recentLocation;

        public int CId { get => cId; set => cId = value; }
        public string CName { get => cName; set => cName = value; }
        public int RewardPoint { get => rewardPoint; set => rewardPoint = value; }
        public string RecentLocation { get => recentLocation; set => recentLocation = value; }

        public Customer()
        {

        }

        public Customer(int cId, string cName)
        {
            this.cId = cId;
            this.cName = cName;
        }

        public Customer(int cId, string cName, int rewardPoint)
        {
            this.cId = cId;
            this.cName = cName;
            this.rewardPoint = rewardPoint;
        }

        public Customer(int cId, int rewardPoint, string recentLocation)
        {
            this.cId = cId;
            this.rewardPoint = rewardPoint;
            this.recentLocation = recentLocation;
        }

        public Customer(int cId, string cName, int rewardPoint, string recentLocation)
        {
            this.cId = cId;
            this.cName = cName;
            this.rewardPoint = rewardPoint;
            this.recentLocation = recentLocation;
        }
    }
}