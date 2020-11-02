using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDSApplication.Models
{
    public class Restaurant
    {
        private int restId;
        private string restName;
        private string restAddress;
        private string restArea;
        private double minAmnt;
     
        public int RestId { get => restId; set => restId = value; }
        public string RestName { get => restName; set => restName = value; }
        public string RestArea { get => restArea; set => restArea = value; }
        public double MinAmnt { get => minAmnt; set => minAmnt = value; }
        public string RestAddress { get => restAddress; set => restAddress = value; }

        public Restaurant()
        {

        }

        public Restaurant(int restId, string restName, string restAddress, string restArea, double minAmnt)
        {
            this.restId = restId;
            this.restName = restName;
            this.restAddress = restAddress;
            this.restArea = restArea;
            this.minAmnt = minAmnt;
        }

        public Restaurant(string restName, string restAddress, string restArea, double minAmnt)
        {
            this.restName = restName;
            this.restAddress = restAddress;
            this.restArea = restArea;
            this.minAmnt = minAmnt;
        }
    }
}