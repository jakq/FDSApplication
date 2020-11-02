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
    public partial class RiderDeliveryHistoryMoreInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isLogin"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            UserAccount user = (UserAccount)Session["UserAccountObj"];
            OrdersBLL odbll = new OrdersBLL();
            txtTransactionID.Text = Request.QueryString["transactionid"].ToString();

            Orders od = new Orders();
            od = odbll.DoRetrieveOrderByTransactionId(txtTransactionID.Text);
            CustomerBLL cbll = new CustomerBLL();
            Customer cust = cbll.DoRetrieveCustomerByID(od.CId);

            txtCustName.Text = cust.CName;
            txtDeliverAddress.Text = od.DeliverAddress;
            txtOrderStatus.Text = od.Status;
            txtCustContact.Text = od.ContactNo;
            txtTotalPayment.Text = (od.TotalCost + od.DeliveryFee).ToString();

            DataTable dt = new DataTable();
            OrderItemListBLL obll = new OrderItemListBLL();
            dt = obll.DoRetrieveCustomerOrderItemByTransactionId(txtTransactionID.Text);

            if (dt != null)
            {
                gv_orderlist.DataSource = dt;
                gv_orderlist.DataBind();
            }

        }

        protected void btn_function_Click(object sender, EventArgs e)
        {
            Response.Redirect("RiderDeliveryHistory.aspx");
        }
    }
}