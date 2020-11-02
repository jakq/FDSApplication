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
    public partial class StaffPromo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isLogin"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            panelViewPromo.Visible = false;
            panelAddPromo.Visible = false;
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

                        panelViewPromo.Visible = true;

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
                                    lblNoPromo.Text = "There is currently no promo, you can add a new promo";
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

        protected void btnAddPromo_Click(object sender, EventArgs e)
        {
            panelViewPromo.Visible = true;
            panelAddPromo.Visible = true;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
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
                if (Convert.ToDateTime(txtPStartDate.Text) > Convert.ToDateTime(txtPEndDate.Text))
                {
                    lblPStartDate.Text = "Promo start date cannot be later then end date";
                }

                if (Convert.ToDateTime(txtPEndDate.Text) < Convert.ToDateTime(txtPStartDate.Text))
                {
                    lblPStartDate.Text = "Promo end date cannot be earlier then start date";
                }

                else
                {
                    PromoBLL promoBLL = new PromoBLL();
                    int result = promoBLL.DoCreatePromo(Convert.ToInt32(txtRestId.Text), Convert.ToDouble(txtPValue.Text), txtPDesc.Text,
                        type, Convert.ToDateTime(txtPStartDate.Text), Convert.ToDateTime(txtPEndDate.Text), txtPCode.Text.ToUpper());

                    if (result > 0)
                    {
                        alertPromoSuccess.Visible = true;
                    }

                    else
                    {
                        alertPromoFailure.Visible = true;
                        lblPromoFailure.Text = "Error in creating promo record";
                    }

                    //Refresh the table
                    panelViewPromo.Visible = true;
                    DataTable dt = new DataTable();
                    dt = promoBLL.DoRetrieveAllPromoByRestId(Convert.ToInt32(txtRestId.Text));
                    gv_promo.DataSource = dt;
                    gv_promo.DataBind();
                }               
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("StaffPromo.aspx");
        }
    }
}