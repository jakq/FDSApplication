<%@ Page Title="" Language="C#" MasterPageFile="~/RiderSite.Master" AutoEventWireup="true" CodeBehind="RiderDeliveryHistory.aspx.cs" Inherits="FDSApplication.RiderDeliveryHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-2"></div>
    <div class="col-md-8 mt-3">
        <h3>View Past Delivery History</h3>
        <p>View past delivery history over here</p>

        <div class="text-center">
             <strong><asp:Label ID="lblNotWorking" runat="server" CssClass="text-danger"></asp:Label></strong>
        </div>

        <asp:GridView ID="gv_orderlist2" runat="server" AutoGenerateColumns="False" CssClass="mt-2 table table-bordered" OnRowCommand="gv_orderlist_RowCommand" >
            <Columns>
                <asp:BoundField DataField="orderId" HeaderText="OID" />
                <asp:BoundField DataField="transactionId" HeaderText="Transaction ID" />
                <asp:BoundField DataField="orderCreated" HeaderText="Order Created" />
                <asp:ButtonField CommandName="MoreInfo" Text="More Info" ItemStyle-CssClass="text-center"/>
            </Columns>
        </asp:GridView>
    </div>
    <div class="col-md-2"></div>
</asp:Content>

