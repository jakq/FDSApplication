using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FDSApplication.BusinessLogicLayer;
using FDSApplication.Models;

namespace FDSApplication
{
    public partial class RiderCheckOrderDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["isLogin"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            UserAccount user = (UserAccount)Session["UserAccountObj"];
            OrdersBLL odbll = new OrdersBLL();

            if (Request.QueryString["transactionid"] != null)
            {
                txtTransactionID.Text = Request.QueryString["transactionid"].ToString();
            } 
            
            else
            {
                //get transactionId that is accepted by riders that is not "Completed"
                if(odbll.DoRetrieveRiderCurrentOrderTransactionId(user.UserId) == null)
                {
                    Response.Redirect("RiderReceiveOrder.aspx");
                } 
                
                else
                {
                    txtTransactionID.Text = odbll.DoRetrieveRiderCurrentOrderTransactionId(user.UserId);
                }
            }

            Orders od = new Orders();
            od = odbll.DoRetrieveOrderByTransactionId(txtTransactionID.Text);
            CustomerBLL cbll = new CustomerBLL();
            Customer cust = cbll.DoRetrieveCustomerByID(od.CId);

            txtCustName.Text = cust.CName;
            txtDeliverAddress.Text = od.DeliverAddress;
            txtOrderStatus.Text = od.Status;
            txtCustContact.Text = od.ContactNo;
            txtTotalPayment.Text = (od.TotalCost + od.DeliveryFee).ToString();

            if (od.Status == "Pending Rider")
            {
                btn_function.Text = "Accept";
            } 
            
            else if (od.Status == "Accept")
            {
                btn_function.Text = "Arrived";
            } 
            
            else if (od.Status == "Arrived")
            {
                btn_function.Text = "Delivering";
            } 
            
            else if (od.Status == "Delivering")
            {
                btn_function.Text = "Completed";
            } 
            
            else if (od.Status == "Completed")
            {
                btn_function.Text = "Back";
            }

            DataTable dt = new DataTable();
            OrderItemListBLL obll = new OrderItemListBLL();
            dt = obll.DoRetrieveCustomerOrderItemByTransactionId(txtTransactionID.Text);

            string restName;
            string restArea;
            string restAddress;

            if (dt != null)
            {
                gv_orderlist.DataSource = dt;
                gv_orderlist.DataBind();
                
                restArea = dt.Rows[0]["restarea"].ToString();
                restName = dt.Rows[0]["restname"].ToString();
                restAddress = dt.Rows[0]["restaddress"].ToString();

                txtRestArea.Text = restArea;
                txtRestName.Text = restName;
                txtRestAddress.Text = restAddress;
                
            }
        }

        protected void btn_function_Click(object sender, EventArgs e)
        {
            UserAccount user = (UserAccount)Session["UserAccountObj"];
            OrdersBLL odbll = new OrdersBLL();
            if (btn_function.Text == "Accept")
            {
                odbll.DoUpdateOrderStatus(txtTransactionID.Text, "Accept", user.UserId);
                txtOrderStatus.Text = "Arrived";
                btn_function.Text = "Arrived";
            } 
            
            else if (btn_function.Text == "Arrived")
            {
                odbll.DoUpdateOrderStatus(txtTransactionID.Text, "Arrived", user.UserId);
                odbll.DoUpdateOrderArriveTime(txtTransactionID.Text, user.UserId, DateTime.Now);
                btn_function.Text = "Delivering";
                txtOrderStatus.Text = "Delivering";
            } 
            
            else if(btn_function.Text == "Delivering")
            {
                odbll.DoUpdateOrderStatus(txtTransactionID.Text, "Delivering", user.UserId);
                odbll.DoUpdateOrderDepartTime(txtTransactionID.Text, DateTime.Now);
                btn_function.Text = "Completed";
                txtOrderStatus.Text = "Completed";
            } 
            
            else if (btn_function.Text == "Completed")
            {
                odbll.DoUpdateOrderStatus(txtTransactionID.Text, "Completed", user.UserId);
                odbll.DoUpdateOrderDeliverTime(txtTransactionID.Text, DateTime.Now);
                Orders od = odbll.DoRetrieveOrderByTransactionId(txtTransactionID.Text);
                
                if(od.IsPaid == "NP")
                {
                    btn_cashPaid.Visible = true;
                }

                btn_function.Text = "Back";
            }
            
            else if (btn_function.Text == "Back")
            {
                Response.Redirect("RiderReceiveOrder.aspx");
            }
        }

        protected void btn_cashPaid_Click(object sender, EventArgs e)
        {
            OrdersBLL odbll = new OrdersBLL();
            if(odbll.DoUpdatePaymentStatus(txtTransactionID.Text) != 0)
            {
                txtOrderStatus.Text = "Payment Is Made";
                btn_cashPaid.Enabled = false;
                lblSuccess.Text = "Order has been completed!";
                lblError.Text = "";
            }
            else
            {
                txtOrderStatus.Text = "Issues With Payment";
                lblError.Text = "There has been a problem with payment";
                lblSuccess.Text = "";
            }
            
        }
    }
}