<%@ Page Title="" Language="C#" MasterPageFile="~/UserSite.Master" AutoEventWireup="true" CodeBehind="UserViewOrderDetails.aspx.cs" Inherits="FDSApplication.UserViewOrderDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-2"></div>
    <div class="col-md-8 mt-2">
        <h3>Order Details</h3>

        <div class="row">
            <div class="auto-style1">
                <div class="form-group">
                    <asp:Label ID="lblOrderId" runat="server" Text="Order ID"></asp:Label>
                    <asp:TextBox ID="txtOrderId" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>
            </div>

            <div class="col">
                <div class="form-group">
                    <asp:Label ID="lblTransactionId" runat="server" Text="Transaction ID"></asp:Label>
                    <asp:TextBox ID="txtTransactionID" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>
            </div>

            <div class="col">
                <div class="form-group">
                    <asp:Label ID="lblOrderStatus" runat="server" Text="Order Status"></asp:Label>
                    <asp:TextBox ID="txtOrderStatus" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col">
                <div class="form-group">
                    <asp:Label ID="lblOrderCreate" runat="server" Text="Order Created"></asp:Label>
                    <asp:TextBox ID="txtOrderCreate" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>
            </div>


            <div class="col">
                <div class="form-group">
                    <asp:Label ID="lblCustContact" runat="server" Text="Contact Number"></asp:Label>
                    <asp:TextBox ID="txtCustContact" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>                   
                </div>
            </div>         
        </div>

        <div class="form-group">
            <asp:Label ID="lblDeliverAddress" runat="server" Text="Delivery Address"></asp:Label>
            <asp:TextBox ID="txtDeliverAddress" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="row">
            <div class="col">
                <div class="form-group">
                    <asp:Label ID="lblTotalPayment" runat="server" Text="Total Food Item Cost($)"></asp:Label>
                    <asp:TextBox ID="txtTotalPayment" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>
            </div>

            <div class="col">
                <div class="form-group">
                    <asp:Label ID="lblDeliverFee" runat="server" Text="Delivery Fee($)"></asp:Label>
                    <asp:TextBox ID="txtDeliverFee" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>
            </div>

            <div class="col">
                <div class="form-group">
                    <asp:Label ID="lblPaymentType" runat="server" Text="Payment Type"></asp:Label>
                    <asp:TextBox ID="txtPaymentType" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="mt-1 text-center">
            <strong><asp:Label ID="lblRetrieveError" runat="server" Text="" CssClass="text-danger"></asp:Label></strong>
        </div>

        <asp:GridView ID="gv_orderlist" runat="server" AutoGenerateColumns="False" CssClass="mt-2 table table-bordered">
            <Columns>
                <asp:BoundField DataField="restname" HeaderText="Restaurant Name" />
                <asp:BoundField DataField="foodcategory" HeaderText="Food Category" />
                <asp:BoundField DataField="foodtitle" HeaderText="Food Title" />
                <asp:BoundField DataField="orderquantity" HeaderText="Order Quantity" />
            </Columns>
        </asp:GridView>

        <asp:Panel ID="panelRiderDetails" runat="server" CssClass="mt-1">
            <h4>Rider Details</h4>

            <div class="row">
                <div class="col">
                    <div class="form-group">
                        <asp:Label ID="lblRiderID" runat="server" Text="Rider ID"></asp:Label>
                        <asp:TextBox ID="txtRiderID" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>

                <div class="col">
                    <div class="form-group">
                        <asp:Label ID="lblRiderName" runat="server" Text="Rider Name"></asp:Label>
                        <asp:TextBox ID="txtRiderName" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col">
                    <div class="form-group">
                        <asp:Label ID="lblTimeArrive" runat="server" Text="Time Arrived at Restaurant"></asp:Label>
                        <asp:TextBox ID="txtTimeArrive" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>

                <div class="col">
                    <div class="form-group">
                        <asp:Label ID="lblTimeDepart" runat="server" Text="Time Depart from Restaurant"></asp:Label>
                        <asp:TextBox ID="txtTimeDepart" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>

                <div class="col">
                    <div class="form-group">
                        <asp:Label ID="lblTimeDeliver" runat="server" Text="Time to Receive Delivery"></asp:Label>
                        <asp:TextBox ID="txtTimeDeliver" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
            </div>
        </asp:Panel>

        <div class="mt-2 text-center">
            <asp:Button ID="btn_Back" runat="server" Text="Back" CssClass="btn btn-dark" OnClick="btn_Back_Click"/>
            &nbsp;
            <asp:Button ID="btn_Review" runat="server" Text="Review" CssClass="btn btn-dark" OnClick="btn_Review_Click"/>
        </div>
  
    </div>
    <div class="col-md-2"></div>
</asp:Content>
