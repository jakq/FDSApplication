<%@ Page Title="" Language="C#" MasterPageFile="~/StaffSite.Master" AutoEventWireup="true" CodeBehind="StaffViewRestaurantReview.aspx.cs" Inherits="FDSApplication.StaffViewRestaurantReview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-2">
    </div>

    <div class="col-md-8 mt-3">
        <h3>View Restaurant Review</h3>
        <p>View All Restaurant Review Over Here</p>
        <br />

       <div class="text-center">
            <strong><asp:Label ID="lblAccessRight" runat="server" Text="" CssClass="text-danger"></asp:Label></strong>
        </div>

        <asp:Panel ID="panelViewRestaurants" runat="server">
            <asp:GridView runat="server" CssClass="table table-bordered" ID="gv_restaurants" AutoGenerateColumns="False" AllowPaging="False">
                <Columns>
                    <asp:BoundField DataField="orderId" HeaderText="Order ID" />
                    <asp:BoundField DataField="restaurantRating" HeaderText="Rating" />
                    <asp:BoundField DataField="reviewTxt" HeaderText="Comment" />
                </Columns>
            </asp:GridView>

            <div class="text-center mt-2">
                <asp:Button ID="btn_back" runat="server" CssClass="btn btn-dark" OnClick="btn_back_Click" Text="Back" />
            </div>

        </asp:Panel>

        <div class="col-md-2">
        </div>
    </div>
</asp:Content>
