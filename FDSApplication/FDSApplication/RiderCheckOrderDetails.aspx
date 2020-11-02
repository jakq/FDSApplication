<%@ Page Title="" Language="C#" MasterPageFile="~/RiderSite.Master" AutoEventWireup="true" CodeBehind="RiderCheckOrderDetails.aspx.cs" Inherits="FDSApplication.RiderCheckOrderDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-2"></div>
    <div class="col-md-8 mt-2">
        <h3>Check Order Details</h3>

        <div class="row">
            <div class="col">
                <div class="form-group">
                    <asp:Label ID="lblTransactionId" runat="server" Text="Transaction ID"></asp:Label>
                    <asp:TextBox ID="txtTransactionID" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>
            </div>

            <div class="col">
                <asp:Label ID="lblOrderStatus" runat="server" Text="Order Status"></asp:Label>
                <asp:TextBox ID="txtOrderStatus" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col">
                <asp:Label ID="lblRestArea" runat="server" Text="Restaurant Area"></asp:Label>
                <asp:TextBox ID="txtRestArea" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>

            <div class="col">
                <asp:Label ID="lblRestName" runat="server" Text="Restaurant Name"></asp:Label>
                <asp:TextBox ID="txtRestName" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>         
        </div>

        <div class="mt-1 form-group">
                <asp:Label ID="lblRestAddress" runat="server" Text="Restaurant Address"></asp:Label>
                <asp:TextBox ID="txtRestAddress" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>

        <asp:GridView ID="gv_orderlist" runat="server" AutoGenerateColumns="False" CssClass="mt-3 table table-bordered">
            <Columns>
                <asp:BoundField DataField="restarea" HeaderText="Restaurant Area" Visible="false"/>
                <asp:BoundField DataField="restname" HeaderText="Restaurant Name" Visible="false" />
                <asp:BoundField DataField="restaddress" HeaderText="Restaurant Address" Visible="false" />
                <asp:BoundField DataField="foodcategory" HeaderText="Food Category" />
                <asp:BoundField DataField="foodtitle" HeaderText="Food Title" />
                <asp:BoundField DataField="orderquantity" HeaderText="Order Quantity" />
            </Columns>
        </asp:GridView>
        
        <h4>Customer Details</h4>

        <div class="row">
            <div class="col">
                <asp:Label ID="lblCustName" runat="server" Text="Customer Name"></asp:Label>
                <asp:TextBox ID="txtCustName" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>                
            </div>

            <div class="col">
                <div class="form-group">
                    <asp:Label ID="lblCustContact" runat="server" Text="Customer Contact Number"></asp:Label>
                    <asp:TextBox ID="txtCustContact" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>                   
                </div>
            </div>
        </div>

        <div class="form-group">
            <asp:Label ID="lblDeliverAddress" runat="server" Text="Delivery Address"></asp:Label>
            <asp:TextBox ID="txtDeliverAddress" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblTotalPayment" runat="server" Text="Total Payment($)"></asp:Label>
            <asp:TextBox ID="txtTotalPayment" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="mt-3 text-center">
            <asp:Button ID="btn_function" runat="server" CssClass="btn btn-dark" OnClick="btn_function_Click" Text="Status Dependent" />
            &nbsp;
            <asp:Button ID="btn_cashPaid" runat="server" CssClass="btn btn-outline-dark" OnClick="btn_cashPaid_Click" Text="Cash Paid" Visible="False" />
        </div>

        <div class="mt-1 text-center">
            <strong><asp:Label ID="lblError" runat="server" CssClass="text-danger"></asp:Label></strong>
            <strong><asp:Label ID="lblSuccess" runat="server" CssClass="text-success"></asp:Label></strong>
        </div> 
    </div>
    <div class="col-md-2"></div>
</asp:Content>
