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
    public partial class UpdatePromo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isLogin"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            panelViewFoodItem.Visible = false;
            panelUpdatePromo.Visible = false;
            alertPromoSuccess.Visible = false;
            alertPromoFailure.Visible = false;
            alertOthersFailure.Visible = false;

            UserAccount user = (UserAccount)Session["UserAccountObj"];

            if (user.UserRole.Equals("Manager"))
            {
                lblAccessRight.Text = "YOU DO NOT HAVE STAFF RIGHTS TO ACCESS THIS FUNCTION";
            }

            else
            {
                if (!IsPostBack)
                {
                    StaffBLL staffBLL = new StaffBLL();
                    Staff staff = staffBLL.DoRetrieveStaffByID(user.UserId);

                    if (staff != null)
                    {
                        RestaurantBLL restaurantBLL = new RestaurantBLL();
                        Restaurant restaurant = restaurantBLL.DoRetrieveRestaurantByRestID(staff.RestId);

                        panelViewFoodItem.Visible = true;

                        if (restaurant != null)
                        {
                            txtRestId.Text = restaurant.RestId.ToString();
                            txtRestName.Text = restaurant.RestName;

                            DataTable dt = new DataTable();
                            PromoBLL promoBLL = new PromoBLL();
                            dt = promoBLL.DoRetrieveAllPromoByRestId(restaurant.RestId);

                            if (dt != null)
                            {
                                if (dt.Rows.Count > 0)
                                {
                                    gv_promo.DataSource = dt;
                                    gv_promo.DataBind();
                                }

                                else
                                {
                                    lblNoPromo.Text = "There is currently no promo, you will need to add a new promo";
                                }

                            }

                            else
                            {
                                alertOthersFailure.Visible = true;
                                lblErrorRetrieve.Text = "Unable to retrieve promo records";
                            }
                        }

                        else
                        {
                            alertOthersFailure.Visible = true;
                            lblErrorRetrieve.Text = "Unable to retrieve restaurant record";
                        }
                    }

                    else
                    {
                        alertOthersFailure.Visible = true;
                        lblErrorRetrieve.Text = "Unable to retrieve staff account";
                    }
                }
            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtPDesc.Text.Length <= 0)
            {
                lblPDescMsg.Text = "Promo Description cannot be blank";
            }

            if (txtPValue.Text.Length <= 0)
            {
                lblPValueMsg.Text = "Promo Value cannot be blank";
            }

            if (txtPCode.Text.Length <= 0)
            {
                lblPCodeMsg.Text = "Promo Code cannot be blank";
            }

            if (txtPStartDate.Text.Length <= 0)
            {
                lblPStartDate.Text = "Promo Start Date cannot be blank";
            }

            if (txtPEndDate.Text.Length <= 0)
            {
                lblPEndDate.Text = "Promo End Date cannot be blank";
            }

            string type = ddlPType.SelectedValue;

            if (txtPDesc.Text.Length > 0 && txtPValue.Text.Length > 0 && txtPCode.Text.Length > 0 && txtPStartDate.Text.Length > 0
                && txtPEndDate.Text.Length > 0)
            {
                PromoBLL promoBLL = new PromoBLL();
                int result = promoBLL.DoUpdatePromo(Convert.ToInt32(txtPromoId.Text), Convert.ToDouble(txtPValue.Text), txtPDesc.Text,
                    type, Convert.ToDateTime(txtPStartDate.Text), Convert.ToDateTime(txtPEndDate.Text), txtPCode.Text.ToUpper());

                if (result > 0)
                {
                    alertPromoSuccess.Visible = true;
                }

                else
                {
                    alertPromoFailure.Visible = true;
                    lblPromoFailure.Text = "Unable to update food item record";
                }

                //Refresh the table
                panelViewFoodItem.Visible = true;
                DataTable dt = new DataTable();
                dt = promoBLL.DoRetrieveAllPromoByRestId(Convert.ToInt32(txtRestId.Text));
                gv_promo.DataSource = dt;
                gv_promo.DataBind();
            }

        }

        protected void lnk_Update_Click(object sender, EventArgs e)
        {
            panelViewFoodItem.Visible = true;

            int promoId = Convert.ToInt32((sender as LinkButton).CommandArgument);
            PromoBLL promoBLL = new PromoBLL();
            Promo promo = promoBLL.DoRetrievePromoByPromoId(promoId);

            panelUpdatePromo.Visible = true;

            txtPromoId.Text = promoId.ToString();
            ddlPType.SelectedValue = promo.PromoType;
            txtPDesc.Text = promo.PromoDesc;
            txtPValue.Text = promo.PromoValue.ToString();
            txtPStartDate.Text = promo.PromoStartDate.ToString();
            txtPEndDate.Text = promo.PromoEndDate.ToString();
            txtPCode.Text = promo.PromoCode;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdatePromo.aspx");
        }
    }
}