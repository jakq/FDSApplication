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
    public partial class UserCreditCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isLogin"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            panelCreateCreditCard.Visible = false;
            alertSuccess.Visible = false;
            alertFailure.Visible = false;

            UserAccount user = (UserAccount)Session["UserAccountObj"];
            
            if (!IsPostBack)
            {
                CustomerBLL customerBLL = new CustomerBLL();
                Customer customer = customerBLL.DoRetrieveCustomerByID(user.UserId);

                if (customer != null)
                {
                    DataTable dt = new DataTable();
                    CreditCardBLL creditCardBLL = new CreditCardBLL();
                    dt = creditCardBLL.DoRetrieveAllCustomerCreditCard(customer.CId);

                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            gv_creditCard.DataSource = dt;
                            gv_creditCard.DataBind();
                        }

                        else
                        {
                            lblNoCreditCard.Text = "There is currently no credit card, you can add a credit card";
                        }
                    }

                    else
                    {
                        alertFailure.Visible = true;
                        lblFailure.Text = "Unable to retrieve credit card records";
                    }
                }

                else
                {
                    alertFailure.Visible = true;
                    lblFailure.Text = "Unable to retrieve customer account";
                }
            }
        }

        protected void btnAddCreditCard_Click(object sender, EventArgs e)
        {
            panelCreateCreditCard.Visible = true;
        }

        protected void btnAddCC_Click(object sender, EventArgs e)
        {
            if (txtCCNum.Text.Length != 16)
            {
                lblCCNumMsg.Text = "Credit Card Number must be 16 characters long ";
            }

            if (txtCCV.Text.Length != 3)
            {
                lblCCVMsg.Text = "CCV must be 3 characters long";
            }

            if (txtCCExpiry.Text.Length != 4)
            {
                lblCCNumMsg.Text = "Credit Card Expiry must be  4 characters long";
            }

           if (txtCCNum.Text.Length == 16 && txtCCV.Text.Length == 3 && txtCCExpiry.Text.Length == 4)
            {
                CreditCardBLL creditCardBLL = new CreditCardBLL();
                int checkCCard = creditCardBLL.DoCheckCreditCardExists(txtCCNum.Text);

                if (checkCCard > 0)
                {
                    alertFailure.Visible = true;
                    lblFailure.Text = "Credit Card Number exists. Please use another credit card";
                }

                else
                {
                    UserAccount user = (UserAccount)Session["UserAccountObj"];
                    CustomerBLL customerBLL = new CustomerBLL();
                    Customer customer = customerBLL.DoRetrieveCustomerByID(user.UserId);

                    int result = creditCardBLL.DoCreateCreditCard(customer.CId, txtCCNum.Text, txtCCV.Text, txtCCExpiry.Text);

                    if (result > 0)
                    {
                        alertSuccess.Visible = true;

                        if (lblNoCreditCard.Text.Length > 0)
                        {
                            lblNoCreditCard.Text = "";
                        }
                    }

                    else
                    {
                        alertFailure.Visible = true;
                        lblFailure.Text = "Unable to create credit card record";
                    }

                    //Refresh page
                    DataTable dt = new DataTable();
                    dt = creditCardBLL.DoRetrieveAllCustomerCreditCard(customer.CId);
                    gv_creditCard.DataSource = dt;
                    gv_creditCard.DataBind();
                }
            }
        }

        protected void lnkRemove_Click(object sender, EventArgs e)
        {
            int ccId = Convert.ToInt32((sender as LinkButton).CommandArgument);
            CreditCardBLL creditCardBLL = new CreditCardBLL();
            int result = creditCardBLL.DoDeleteCreditCard(ccId);
            
            if (result > 0)
            {
                Response.Redirect("UserCreditCard.aspx");
            }

            else
            {
                alertFailure.Visible = true;
                lblFailure.Text = "Unable to delete credit card record";
            }
        }
    }
}