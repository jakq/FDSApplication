using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDSApplication.Models
{
    public class Orders
    {
        private int orderId;
        private int cId;
        private string transactionId;
        private int rId;
        private string paymentType;
        private string cardNum;
        private string deliverAddress;
        private string contactNo;
        private double deliveryFee;
        private double totalCost;
        private DateTime orderCreated;
        private DateTime arriveTime;
        private DateTime departTime;
        private DateTime deliverTime;
        private string isPaid;
        private string status;

        public int OrderId { get => orderId; set => orderId = value; }
        public int CId { get => cId; set => cId = value; }
        public string TransactionId { get => transactionId; set => transactionId = value; }
        public int RId { get => rId; set => rId = value; }
        public string PaymentType { get => paymentType; set => paymentType = value; }
        public string CardNum { get => cardNum; set => cardNum = value; }
        public string DeliverAddress { get => deliverAddress; set => deliverAddress = value; }
        public string ContactNo { get => contactNo; set => contactNo = value; }
        public double DeliveryFee { get => deliveryFee; set => deliveryFee = value; }
        public double TotalCost { get => totalCost; set => totalCost = value; }
        public DateTime OrderCreated { get => orderCreated; set => orderCreated = value; }
        public DateTime ArriveTime { get => arriveTime; set => arriveTime = value; }
        public DateTime DepartTime { get => departTime; set => departTime = value; }
        public DateTime DeliverTime { get => deliverTime; set => deliverTime = value; }
        public string IsPaid { get => isPaid; set => isPaid = value; }
        public string Status { get => status; set => status = value; }

        public Orders()
        {
        }

        public Orders(int cId, string transactionId, string paymentType, string cardNum, string deliverAddress, 
            string contactNo, double deliveryFee, double totalCost, DateTime orderCreated, string isPaid, string status)
        {
            this.cId = cId;
            this.transactionId = transactionId;
            this.paymentType = paymentType;
            this.cardNum = cardNum;
            this.deliverAddress = deliverAddress;
            this.contactNo = contactNo;
            this.deliveryFee = deliveryFee;
            this.totalCost = totalCost;
            this.orderCreated = orderCreated;
            this.isPaid = isPaid;
            this.status = status;
        }

        public Orders(int orderId, int cId, string transactionId, int rId, string paymentType, string cardNum, string deliverAddress, string contactNo, double deliveryFee, double totalCost,
            DateTime orderCreated, DateTime arriveTime, DateTime departTime, DateTime deliverTime, string isPaid, string status)
        {
            this.orderId = orderId;
            this.cId = cId;
            this.transactionId = transactionId;
            this.rId = rId;
            this.paymentType = paymentType;
            this.cardNum = cardNum;
            this.deliverAddress = deliverAddress;
            this.contactNo = contactNo;
            this.deliveryFee = deliveryFee;
            this.totalCost = totalCost;
            this.orderCreated = orderCreated;
            this.arriveTime = arriveTime;
            this.departTime = departTime;
            this.deliverTime = deliverTime;
            this.isPaid = isPaid;
            this.status = status;
        }

        public Orders(int cId, string transactionId, int rId, string paymentType, string cardNum, string deliverAddress, 
            string contactNo, double deliveryFee, double totalCost, DateTime orderCreated, DateTime arriveTime, DateTime departTime, DateTime deliverTime, string isPaid, string status)
        {
            this.cId = cId;
            this.transactionId = transactionId;
            this.rId = rId;
            this.paymentType = paymentType;
            this.cardNum = cardNum;
            this.deliverAddress = deliverAddress;
            this.contactNo = contactNo;
            this.deliveryFee = deliveryFee;
            this.totalCost = totalCost;
            this.orderCreated = orderCreated;
            this.arriveTime = arriveTime;
            this.departTime = departTime;
            this.deliverTime = deliverTime;
            this.isPaid = isPaid;
            this.status = status;
        }

        
    }
}