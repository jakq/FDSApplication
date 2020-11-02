<%@ Page Title="" Language="C#" MasterPageFile="~/UserSite.Master" AutoEventWireup="true" CodeBehind="UserViewAllOrders.aspx.cs" Inherits="FDSApplication.UserViewAllOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-1"></div>
    <div class="col-md-10 mt-3">
        <h3>View All Orders</h3>
        <p>View yout current orders or past orders over here</p>

        <div class="row">
            <div class="col-md-6">
                <asp:Button ID="btnCurrentOrder" runat="server" Text="Current Order(s)" CssClass="btn btn-dark btn-lg btn-block" OnClick="btnCurrentOrder_Click" />
            </div>

            <div class="col-md-6">
                <asp:Button ID="btnPastOrders" runat="server" Text="Past Order(s)" CssClass="btn btn-dark btn-lg btn-block" OnClick="btnPastOrders_Click" />
            </div>
        </div>

        <asp:GridView ID="gv_currentOrders" runat="server" CssClass="mt-2 table table-bordered" AutoGenerateColumns="False" OnRowCommand="gv_currentOrders_RowCommand">
            <Columns>
                <asp:BoundField DataField="orderid" HeaderText="Order ID" />
                <asp:BoundField DataField="deliveraddress" HeaderText="Delivery Address" />
                <asp:BoundField DataField="orderCreated" HeaderText="Order Date" />
                <asp:BoundField DataField="totalCost" HeaderText="Total Cost($)" />
                <asp:BoundField DataField="status" HeaderText="Status" />
                <asp:ButtonField Text="Details" CommandName="Details" ItemStyle-CssClass="text-center" />
            </Columns>
        </asp:GridView>

        <asp:GridView ID="gv_pastOrders" runat="server" CssClass="mt-2 table table-bordered" AutoGenerateColumns="False" OnRowCommand="gv_pastOrders_RowCommand">
            <Columns>
                <asp:BoundField DataField="orderid" HeaderText="Order ID" />
                <asp:BoundField DataField="deliveraddress" HeaderText="Delivery Address" />
                <asp:BoundField DataField="orderCreated" HeaderText="Order Date" />
                <asp:BoundField DataField="totalCost" HeaderText="Total Cost($)" />
                <asp:BoundField DataField="status" HeaderText="Status" />
                <asp:ButtonField Text="Details" CommandName="Details" ItemStyle-CssClass="text-center"/>
                <asp:ButtonField Text="Review" CommandName="Review" ItemStyle-CssClass="text-center"/>
            </Columns>
        </asp:GridView>
    </div>
    <div class="col-md-1"></div>
</asp:Content>
