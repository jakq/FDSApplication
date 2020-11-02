using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FDSApplication.BusinessLogicLayer;
using FDSApplication.Models;

namespace FDSApplication
{
    public partial class AddRestaurant : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isLogin"] == null)
            {
                Response.Redirect("Login.aspx");
            }
          
            panelAddRestaurant.Visible = false;
            alertSuccess.Visible = false;
            alertFailure.Visible = false;

            UserAccount user = (UserAccount)Session["UserAccountObj"];

            if (!user.UserRole.Equals("Manager"))
            {
                lblUserDenied.Text = "YOU DO NOT HAVE MANAGER RIGHTS TO ACCESS THIS FUNCTION";
            }

            else
            {
                panelAddRestaurant.Visible = true;
            }       
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtRName.Text.Length <= 0)
            {
                lblRNameMsg.Text = "Restaurant Name Cannot Be Blank";
            }

            if (txtRAddress.Text.Length <= 0)
            {
                lblRAddressMsg.Text = "Address Cannot Be Blank";
            }

            if (txtMinAmnt.Text.Length <= 0)
            {
                lblMinAmntMsg.Text = "Minimum Amount Cannot Be Blank";
            }

            string rArea = ddlRArea.SelectedValue;

            if (txtRName.Text.Length > 0 && txtRAddress.Text.Length > 0 && txtMinAmnt.Text.Length > 0)
            {
                RestaurantBLL rBLL = new RestaurantBLL();
                int result = rBLL.DoCreateRestaurant(txtRName.Text, txtRAddress.Text, rArea, Convert.ToDouble(txtMinAmnt.Text));

                if (result > 0)
                {
                    alertSuccess.Visible = true;
                }

                else
                {
                    alertFailure.Visible = true;
                    ClearTextFieldAndMessages();
                }
            }

        }

        public void ClearTextFieldAndMessages()
        {
            txtRName.Text = "";
            lblRNameMsg.Text = "";
            txtRAddress.Text = "";
            lblRAddressMsg.Text = "";
            txtMinAmnt.Text = "";
            lblMinAmntMsg.Text = "";
        }
    }
}