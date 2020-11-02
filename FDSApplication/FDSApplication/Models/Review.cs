using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDSApplication.Models
{
    public class Review
    {
        private int reviewId;
        private int orderId;
        private int cId;
        private int rId;
        private int restId;
        private int riderRating;
        private int restaurantRating;
        private string reviewTxt;


        public int ReviewId { get => reviewId; set => reviewId = value; }
        public int OrderId { get => orderId; set => orderId = value; }
        public int CId { get => cId; set => cId = value; }
        public int RId { get => rId; set => rId = value; }
        public int RestId { get => restId; set => restId = value; }
        public int RiderRating { get => riderRating; set => riderRating = value; }
        public int RestaurantRating { get => restaurantRating; set => restaurantRating = value; }
        public string ReviewTxt { get => reviewTxt; set => reviewTxt = value; }


        public Review()
        {
        }

        public Review(int reviewId, int orderId, int cId, int rId, int restId, int riderRating, int restaurantRating, string reviewTxt)
        {
            this.reviewId = reviewId;
            this.orderId = orderId;
            this.cId = cId;
            this.rId = rId;
            this.restId = restId;
            this.riderRating = riderRating;
            this.restaurantRating = restaurantRating;
            this.reviewTxt = reviewTxt;
        }

        public Review(int orderId, int cId, int rId, int restId, int riderRating, int restaurantRating, string reviewTxt)
        {
            this.orderId = orderId;
            this.cId = cId;
            this.rId = rId;
            this.restId = restId;
            this.riderRating = riderRating;
            this.restaurantRating = restaurantRating;
            this.reviewTxt = reviewTxt;
        }
    }
}