using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDSApplication.Models
{
    public class OrderItemList
    {
        private int lineId;
        private string transactionId;
        private int custId;
        private int foodId;
        private int orderQuantity;
        private string checkout;

        public OrderItemList()
        {
        }

        public OrderItemList(int lineId, string transactionId, int custId, int foodId, int orderQuantity, string checkout)
        {
            this.lineId = lineId;
            this.transactionId = transactionId;
            this.custId = custId;
            this.foodId = foodId;
            this.orderQuantity = orderQuantity;
            this.checkout = checkout;
        }

        public OrderItemList(string transactionId, int custId, int foodId, int orderQuantity, string checkout)
        {
            this.transactionId = transactionId;
            this.custId = custId;
            this.foodId = foodId;
            this.orderQuantity = orderQuantity;
            this.checkout = checkout;
        }

        public OrderItemList(string transactionId, int custId, int foodId, int orderQuantity)
        {
            this.transactionId = transactionId;
            this.custId = custId;
            this.foodId = foodId;
            this.orderQuantity = orderQuantity;
        }

        public OrderItemList(string transactionId, string checkout)
        {
            this.transactionId = transactionId;
            this.checkout = checkout;
        }

        public string TransactionId { get => transactionId; set => transactionId = value; }
        public int CustId { get => custId; set => custId = value; }
        public int FoodId { get => foodId; set => foodId = value; }
        public int OrderQuantity { get => orderQuantity; set => orderQuantity = value; }
        public int LineId { get => lineId; set => lineId = value; }
        public string Checkout { get => checkout; set => checkout = value; }
    }
}