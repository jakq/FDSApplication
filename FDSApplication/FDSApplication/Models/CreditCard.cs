using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDSApplication.Models
{
    public class CreditCard
    {
        private int ccId;
        private int cId;
        private string ccNum;
        private string ccv;
        private string ccExpiry;

        public int CcId { get => ccId; set => ccId = value; }
        public int CId { get => cId; set => cId = value; }
        public string CcNum { get => ccNum; set => ccNum = value; }
        public string Ccv { get => ccv; set => ccv = value; }
        public string CcExpiry { get => ccExpiry; set => ccExpiry = value; }

        public CreditCard()
        {
        }

        public CreditCard(int ccId, int cId, string ccNum, string ccv, string ccExpiry)
        {
            this.ccId = ccId;
            this.cId = cId;
            this.ccNum = ccNum;
            this.ccv = ccv;
            this.ccExpiry = ccExpiry;
        }

        public CreditCard(int cId, string ccNum, string ccv, string ccExpiry)
        {
            this.cId = cId;
            this.ccNum = ccNum;
            this.ccv = ccv;
            this.ccExpiry = ccExpiry;
        }
    }
}