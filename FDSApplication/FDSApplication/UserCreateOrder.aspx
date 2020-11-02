<%@ Page Title="" Language="C#" MasterPageFile="~/UserSite.Master" AutoEventWireup="true" CodeBehind="UserCreateOrder.aspx.cs" Inherits="FDSApplication.UserCreateOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-2"></div>
    <div class="col-md-8 mt-3">
        <h3>New Food Order</h3>
        <p>Create a new food order over here</p>

        <div class="form-group">
            <asp:Label ID="lblRAreaCategory" runat="server" Text="Area"></asp:Label>
            <asp:DropDownList ID="ddlRArea" runat="server" CssClass="form-control">
                <asp:ListItem>North</asp:ListItem>
                <asp:ListItem>South</asp:ListItem>
                <asp:ListItem>Central</asp:ListItem>
                <asp:ListItem>East</asp:ListItem>
                <asp:ListItem>West</asp:ListItem>
            </asp:DropDownList>

            <div class="text-center mt-2">
                <asp:Button ID="btnSearch" runat="server" Text="Search Restaurant" CssClass="btn btn-dark" OnClick="btnSearch_Click" />
            </div>

            <br />

            <asp:GridView ID="gv_listofRestaurant" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" OnRowCommand="gv_listofRestaurant_RowCommand">
                <Columns>
                    <asp:BoundField DataField="restId" HeaderText="Restaurant Code" />
                    <asp:BoundField DataField="restname" HeaderText="Restaurant Name" />
                    <asp:BoundField DataField="restaddress" HeaderText="Address" />
                    <asp:ButtonField Text="Select Food" ItemStyle-HorizontalAlign="Center" CommandName="SelectFood"/>
                    <asp:ButtonField Text="View Restaurant Review" ItemStyle-HorizontalAlign="Center" CommandName="RestaurantReview"/>
                </Columns>
            </asp:GridView>

            <br />

            <asp:Panel ID="alertSuccess" runat="server" CssClass="alert alert-success">
                <p>You have successfully added an item into your order list</p>
            </asp:Panel>
            <asp:Panel ID="alertFailure" runat="server" CssClass="alert alert-danger mt-2">                
                <p><asp:Label ID="lblErrorRetrieve" runat="server" Text=""></asp:Label></p>
            </asp:Panel>

            <div class="text-center mt-3">
                <h5><asp:Label ID="lblRestName" runat="server" Text=""></asp:Label></h5>
                <p><asp:Label ID="lblRestAddress" runat="server" Text=""></asp:Label></p>
            </div>
            
            <asp:GridView ID="gv_listOfFood" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" OnRowCommand="gv_listOfFood_RowCommand" OnRowDataBound="gv_listOfFood_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="foodId" HeaderText="Food Code" />
                    <asp:BoundField DataField="restId" HeaderText="restId" Visible="false" />
                    <asp:BoundField DataField="foodcategory" HeaderText="Category" />
                    <asp:BoundField DataField="foodTitle" HeaderText="Food" />
                    <asp:BoundField DataField="price" HeaderText="Price per Unit($)" />
                    <asp:BoundField DataField="orderCounter" HeaderText="Order Count" />
                    <asp:BoundField DataField="dailyLimit" HeaderText="Daily Limit"/>
                    <asp:ButtonField Text="Select Item" ItemStyle-HorizontalAlign="Center" CommandName="SelectItem">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:ButtonField>
                </Columns>
            </asp:GridView>

            <div class="text-md-right mt-2">
                <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-dark" OnClick="btnBack_Click"/>
            </div>           
        </div>
    </div>
    <div class="col-md-2"></div>
</asp:Content>
