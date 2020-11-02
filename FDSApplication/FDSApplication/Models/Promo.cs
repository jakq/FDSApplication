using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDSApplication.Models
{
    public class Promo
    {
        private int promoId;
        private int restId;
        private double promoValue;
        private string promoDesc;
        private string promoType;
        private DateTime promoStartDate;
        private DateTime promoEndDate;
        private string promoCode;

        public Promo()
        {
        }

        public Promo(int promoId, int restId, double promoValue, string promoDesc, string promoType, DateTime promoStartDate, DateTime promoEndDate,
            string promoCode) 
        {
            this.promoId = promoId;
            this.restId = restId;
            this.promoValue = promoValue;
            this.promoDesc = promoDesc;
            this.promoType = promoType;
            this.promoStartDate = promoStartDate;
            this.promoEndDate = promoEndDate;
            this.promoCode = promoCode;
        }

        public Promo(int restId, double promoValue, string promoDesc, string promoType, DateTime promoStartDate, DateTime promoEndDate, string promoCode)
        {
            this.restId = restId;
            this.promoValue = promoValue;
            this.promoDesc = promoDesc;
            this.promoType = promoType;
            this.promoStartDate = promoStartDate;
            this.promoEndDate = promoEndDate;
            this.promoCode = promoCode;
        }

        public Promo(double promoValue, string promoDesc, string promoType, DateTime promoStartDate, DateTime promoEndDate, string promoCode,
            int promoId)
        {
            this.promoValue = promoValue;
            this.promoDesc = promoDesc;
            this.promoType = promoType;
            this.promoStartDate = promoStartDate;
            this.promoEndDate = promoEndDate;
            this.promoCode = promoCode;
            this.promoId = promoId;
        }

        public int PromoId { get => promoId; set => promoId = value; }
        public int RestId { get => restId; set => restId = value; }
        public double PromoValue { get => promoValue; set => promoValue = value; }
        public string PromoDesc { get => promoDesc; set => promoDesc = value; }
        public string PromoType { get => promoType; set => promoType = value; }
        public DateTime PromoStartDate { get => promoStartDate; set => promoStartDate = value; }
        public DateTime PromoEndDate { get => promoEndDate; set => promoEndDate = value; }
        public string PromoCode { get => promoCode; set => promoCode = value; }

    }
}