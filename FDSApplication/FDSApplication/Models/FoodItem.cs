using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDSApplication.Models
{
    public class FoodItem
    {
        private int foodId;
        private int restId;
        private string foodCategory;
        private string foodTitle;
        private double price;
        private int dailyLimit;
        private int orderCounter;

        public FoodItem()
        {
        }

        public FoodItem(int foodId, int restId, string foodCategory, string foodTitle, double price, int dailyLimit, int orderCounter)
        {
            this.foodId = foodId;
            this.restId = restId;
            this.foodCategory = foodCategory;
            this.foodTitle = foodTitle;
            this.price = price;
            this.dailyLimit = dailyLimit;
            this.orderCounter = orderCounter;
        }

        public FoodItem(int restId, string foodCategory, string foodTitle, double price, int dailyLimit, int orderCounter)
        {
            this.restId = restId;
            this.foodCategory = foodCategory;
            this.foodTitle = foodTitle;
            this.price = price;
            this.dailyLimit = dailyLimit;
            this.orderCounter = orderCounter;
        }

        public FoodItem(int foodId, int restId, string foodCategory, string foodTitle, double price, int dailyLimit)
        {
            this.foodId = foodId;
            this.restId = restId;
            this.foodCategory = foodCategory;
            this.foodTitle = foodTitle;
            this.price = price;
            this.dailyLimit = dailyLimit;
        }

        public FoodItem(int foodId, int orderCounter)
        {
            this.foodId = foodId;
            this.orderCounter = orderCounter;
        }

        public int FoodId { get => foodId; set => foodId = value; }
        public int RestId { get => restId; set => restId = value; }
        public string FoodCategory { get => foodCategory; set => foodCategory = value; }
        public string FoodTitle { get => foodTitle; set => foodTitle = value; }
        public double Price { get => price; set => price = value; }
        public int DailyLimit { get => dailyLimit; set => dailyLimit = value; }
        public int OrderCounter { get => orderCounter; set => orderCounter = value; }
    }
}