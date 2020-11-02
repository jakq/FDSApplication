<%@ Page Title="" Language="C#" MasterPageFile="~/UserSite.Master" AutoEventWireup="true" CodeBehind="UserCheckout.aspx.cs" Inherits="FDSApplication.UserCheckout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-2"></div>
    <div class="col-md-8 mt-3">
        <h3>Checkout</h3>
        <strong>Transaction ID: <asp:Label ID="lblTransactionId" runat="server" Text=""></asp:Label></strong>
       
        <asp:GridView ID="gv_currFoodItemList" runat="server" CssClass="mt-2 table table-bordered" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="transactionId" HeaderText="TransactionID" Visible="False" />
                <asp:BoundField DataField="cId" HeaderText="custId" Visible="False" />
                <asp:BoundField DataField="foodId" HeaderText="S/N"/>
                <asp:BoundField DataField="restName" HeaderText="Restaurant Name" />
                <asp:BoundField DataField="foodTitle" HeaderText="Food Ordered" />
                <asp:BoundField DataField="price" HeaderText="Price for 1 Unit($)" />
                <asp:BoundField DataField="orderquantity" HeaderText="Quantity" />
                <asp:TemplateField HeaderText="Total Price($)">
                    <ItemTemplate>
                        <asp:Label ID="lblTotalAmt" runat="server" Text='<%# Convert.ToInt32(Eval("orderquantity")) * Convert.ToDouble(Eval("price")) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <div class="form-group">
            <asp:Label ID="lblPaymentMode" runat="server" Text="Payment Mode"></asp:Label>
            <asp:DropDownList ID="ddlPaymentMode" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlPaymentMode_SelectedIndexChanged">
                <asp:ListItem>Cash</asp:ListItem>
                <asp:ListItem>Card</asp:ListItem>
            </asp:DropDownList>
        </div>

        <asp:Panel ID="panelCard" runat="server" CssClass="form-group">
            <asp:Label ID="lblCardNum" runat="server" Text="Select Card"></asp:Label>
            <asp:DropDownList ID="ddlCardNum" runat="server" CssClass="form-control"></asp:DropDownList>
        </asp:Panel>
        
        <div class="form-group">
            <asp:Label ID="lblDeliverAddress" runat="server" Text="Delivery Address"></asp:Label>
            <asp:TextBox ID="txtDeliverAddress" runat="server" Type="text" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="lblDeliverAddressMsg" runat="server" Text="" CssClass="text-danger"></asp:Label>
        </div>

        <div class="form-group">
            <asp:Label ID="lblContactNo" runat="server" Text="Contact Number"></asp:Label>
            <asp:TextBox ID="txtContactNo" runat="server" Type="text" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="lblContactNoMsg" runat="server" Text="" CssClass="text-danger"></asp:Label>
        </div>

        <asp:Button ID="btnPromoCode" runat="server" Text="Select Promo Code" OnClick="btnPromoCode_Click" CssClass="btn btn-dark" />

        <asp:GridView ID="gv_promo" runat="server" CssClass="mt-2 table table-bordered" AllowPaging="False" AutoGenerateColumns="False" OnDataBound="gv_promo_DataBound" OnRowCommand="gv_promo_RowCommand" OnPageIndexChanging="grid_PageIndexChanging">
            <Columns>
                <asp:BoundField HeaderText="PromoId" DataField="promoid" />                
                <asp:BoundField HeaderText="Promo Description" DataField="promoDesc" />
                <asp:BoundField HeaderText="Promo Type" DataField="promoType" />
                <asp:BoundField HeaderText="Promo Value" DataField="promoValue" />
                <asp:BoundField HeaderText="Promo Start Date" DataField="promoStartDate" />
                <asp:BoundField HeaderText="Promo End Date" DataField="promoEndDate" />
                <asp:BoundField HeaderText="Promo Code" DataField="promoCode" />
                <asp:ButtonField Text="Select" CommandName="Select" ItemStyle-CssClass="text-center" />
            </Columns>
        </asp:GridView>

        <div class="form-group">
            <asp:Label ID="lblPromoCode" runat="server" Text="Promo Code"></asp:Label>
            <asp:TextBox ID="txtPromoCode" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="mt-2">
            <strong>Order Total Amount($):
            <asp:Label ID="lblOrderTotalAmt" runat="server" Text=""></asp:Label>
            </strong>
        </div>

        <div class="mt-1">
            <strong>Delivery Fee($): <asp:Label ID="lblDeliveryFee" runat="server" Text=""></asp:Label></strong>
        </div>

        <div class="mt-2 text-md-right">
            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-dark" OnClick="btnBack_Click" />
            &nbsp;
            <asp:Button ID="btnCheckout" runat="server" Text="Check Out" CssClass="btn btn-dark" OnClick="btnCheckout_Click" />
        </div>
        
        <asp:Panel ID="alertSuccess" runat="server" CssClass="alert alert-success mt-2">
            <p>Your order has been created. A rider will deliver you order soon!</p>
        </asp:Panel>

        <asp:Panel ID="alertFailure" runat="server" CssClass="alert alert-danger mt-2">
            <p><asp:Label ID="lblErrorRetrieve" runat="server" Text=""></asp:Label></p>
        </asp:Panel>     
    </div>
    <div class="col-md-2"></div>
</asp:Content>
