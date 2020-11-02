using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FDSApplication.BusinessLogicLayer;
using FDSApplication.Models;

namespace FDSApplication
{
    public partial class UserViewOrderDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isLogin"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            UserAccount user = (UserAccount)Session["UserAccountObj"];
            txtOrderId.Text = Request.QueryString["orderid"].ToString();

            Orders od = new Orders();
            OrdersBLL odbll = new OrdersBLL();
            od = odbll.DoRetrieveUserOrderDetails(int.Parse(txtOrderId.Text));

            btn_Review.Enabled = false;

            txtTransactionID.Text = od.TransactionId;
            txtOrderStatus.Text = od.Status;
            txtOrderCreate.Text = od.OrderCreated.ToString("dd/MM/yyyy HH:mm");
            txtCustContact.Text = od.ContactNo;
            txtDeliverAddress.Text = od.DeliverAddress;
            txtTotalPayment.Text = od.TotalCost.ToString();
            txtDeliverFee.Text = od.DeliveryFee.ToString();
            txtPaymentType.Text = od.PaymentType;

            if (od.Status == "Completed")
            {
                btn_Review.Enabled = true;
            }

            if (od.RId == 0)
            {
                panelRiderDetails.Visible = false;
            }

            else
            {
                panelRiderDetails.Visible = true;
                Rider rider = new Rider();
                RiderBLL riderBLL = new RiderBLL();
                rider = riderBLL.DoRetrieveRiderByID(od.RId);

                txtRiderID.Text = od.RId.ToString();
                txtRiderName.Text = rider.RName;

                if (od.ArriveTime == null)
                {
                    txtTimeArrive.Text = "-";
                }

                else
                {
                    txtTimeArrive.Text = od.ArriveTime.ToString("dd/MM/yyyy HH:mm");
                }

                if (od.DepartTime == null)
                {
                    txtTimeDepart.Text = "-";
                }

                else
                {
                    txtTimeDepart.Text = od.DepartTime.ToString("dd/MM/yyyy HH:mm");
                }

                if (od.DeliverTime == null)
                {
                    txtTimeDeliver.Text = "-";
                }

                else
                {
                    txtTimeDeliver.Text = od.DeliverTime.ToString("dd/MM/yyyy HH:mm");
                }
            }

            DataTable dt = new DataTable();
            OrderItemListBLL obll = new OrderItemListBLL();
            dt = obll.DoRetrieveCustomerOrderItemByTransactionId(txtTransactionID.Text);

            if (dt != null)
            {
                gv_orderlist.DataSource = dt;
                gv_orderlist.DataBind();
            }

            else
            {
                lblRetrieveError.Text = "Unable to retrive food item list";
            }
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserViewAllOrders.aspx");
        }

        protected void btn_Review_Click(object sender, EventArgs e)
        {
            ReviewBLL reviewBLL = new ReviewBLL();
            int orderId = Convert.ToInt32(txtOrderId.Text);
            if (reviewBLL.DoCheckReviewExists(orderId) == 0)
            {
                Response.Redirect("UserCreateReview.aspx?orderid=" + orderId);
            }
            else
            {
                Response.Redirect("UserRetrieveReview.aspx?orderid=" + orderId);
            }
        }
    }
}