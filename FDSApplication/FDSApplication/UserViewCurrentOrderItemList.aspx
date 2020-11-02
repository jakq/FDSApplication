<%@ Page Title="" Language="C#" MasterPageFile="~/UserSite.Master" AutoEventWireup="true" CodeBehind="UserViewCurrentOrderItemList.aspx.cs" Inherits="FDSApplication.UserViewCurrentOrderItemList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-2"></div>
    <div class="col-md-8 mt-3">
        <h3>View Current Food Order List</h3>
        <p>View current food order list over here</p>

        <br />

        <div class="text-center">
            <strong><asp:Label ID="lblNoList" runat="server" Text="" CssClass="text-danger"></asp:Label></strong>
        </div>

        <br />

        <asp:Panel ID="panelTransactionId" runat="server" CssClass="card text-center">
            <h5 class="card-header">Transaction ID:</h5>
            <div class="card-body">
                <p class="card-text"><asp:Label ID="lbltransactionId" runat="server" Text=""></asp:Label></p>
            </div>        
        </asp:Panel>
        
        <br />

        <asp:GridView ID="gv_currFoodItemList" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False" OnRowCommand="gv_currFoodItemList_RowCommand">
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
                <asp:ButtonField Text="Add" CommandName="AddQuantity" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:ButtonField>
                <asp:ButtonField Text="Remove" CommandName="MinusQuantity" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:ButtonField>
            </Columns>
        </asp:GridView>

        <br />

        <asp:Panel ID="panelTotalAmt" runat="server" CssClass="card text-center">
            <h5 class="card-header">Total Amount($):</h5>
            <div class="card-body">
                <p class="card-text"><asp:Label ID="lblTotalAmt" runat="server" Text=""></asp:Label></p>
            </div>        
        </asp:Panel>

        <div class="text-md-right mt-3">
            <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-dark" OnClick="btnClear_Click"/>
            &nbsp;
            <asp:Button ID="btnCheckout" runat="server" Text="Check Out" CssClass="btn btn-dark" OnClick="btnCheckout_Click"/>
        </div>
        
        <asp:Panel ID="alertFailure" runat="server" CssClass="alert alert-danger mt-3">
            <p><asp:Label ID="lblFailure" runat="server" Text=""></asp:Label></p>
        </asp:Panel>

    </div>
    <div class="col-md-2"></div>
</asp:Content>
