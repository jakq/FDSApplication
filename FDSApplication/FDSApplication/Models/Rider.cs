using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDSApplication.Models
{
    public class Rider
    {
        private int rId;
        private string rName;
        private Boolean isFullTime;
        private double salary;

        public int RId { get => rId; set => rId = value; }
        public string RName { get => rName; set => rName = value; }
        public bool IsFullTime { get => isFullTime; set => isFullTime = value; }
        public double Salary { get => salary; set => salary = value; }

        public Rider()
        {

        }

        public Rider(int rId, string rName)
        {
            this.rId = rId;
            this.rName = rName;
        }

        public Rider(int rId, string rName, bool isFullTime, double salary)
        {
            this.rId = rId;
            this.rName = rName;
            this.isFullTime = isFullTime;
            this.salary = salary;
        }

        public Rider(string rName, bool isFullTime, double salary)
        {
            this.rName = rName;
            this.isFullTime = isFullTime;
            this.salary = salary;
        }

        public void setFullTimeToPartTime()
        {
            isFullTime = false;
        }

        public void setPartTimeToFullTime()
        {
            isFullTime = true;
        }


    }
}