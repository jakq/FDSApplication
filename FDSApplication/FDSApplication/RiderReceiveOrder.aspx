<%@ Page Title="" Language="C#" MasterPageFile="~/RiderSite.Master" AutoEventWireup="true" CodeBehind="RiderReceiveOrder.aspx.cs" Inherits="FDSApplication.RiderReceiveOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-2"></div>
    <div class="col-md-8 mt-3">
        <h3>View List of Available Order</h3>
        <p>View the availalble list of orders over here</p>

        <br />

        <div class="text-center">
            <strong><asp:Label ID="lblNotWorking" runat="server" Text="" CssClass="text-danger"></asp:Label></strong>
        </div>

        <asp:GridView ID="gv_orderlist" runat="server" CssClass="mt-3 table table-bordered" AutoGenerateColumns="False" OnRowCommand="gv_orderlist_RowCommand">
            <Columns>
                <asp:BoundField DataField="orderId" HeaderText="Order Code" />
                <asp:BoundField DataField="transactionId" HeaderText="Transaction ID" />
                <asp:BoundField DataField="orderCreated" HeaderText="Order Created" />
                <asp:BoundField DataField="deliverAddress" HeaderText="Delivery Address" />
                <asp:BoundField DataField="contactNo" HeaderText="Contact Number" />
                <asp:BoundField DataField="paymentType" HeaderText="Payment Type" Visible="false"/>
                <asp:ButtonField CommandName="MoreInfo" Text="More Info" ItemStyle-CssClass="text-center" />
            </Columns>
        </asp:GridView>

    </div>
    <div class="col-md-2"></div>
</asp:Content>
