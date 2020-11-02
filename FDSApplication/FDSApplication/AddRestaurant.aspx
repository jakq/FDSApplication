<%@ Page Title="" Language="C#" MasterPageFile="~/StaffSite.Master" AutoEventWireup="true" CodeBehind="AddRestaurant.aspx.cs" Inherits="FDSApplication.AddRestaurant" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-2"></div>
    <div class="col-md-8 mt-3">
        <h3>Add Restaurant</h3>
        <p>Add a New Restaurant Record Over Here</p>

        <div class="text-center">
            <strong><asp:Label ID="lblUserDenied" runat="server" Text="" CssClass="text-danger"></asp:Label></strong>
        </div>

        <asp:Panel ID="panelAddRestaurant" runat="server">
            <div class="form-group">
                <asp:Label ID="lblRName" runat="server" Text="Restaurant Name"></asp:Label>
                <asp:TextBox ID="txtRName" runat="server" Type="text" CssClass="form-control"></asp:TextBox>
                <asp:Label ID="lblRNameMsg" runat="server" CssClass="text-danger" Text=""></asp:Label>
            </div>

            <div class="form-group">
                <asp:Label ID="lblRAddress" runat="server" Text="Address"></asp:Label>
                <asp:TextBox ID="txtRAddress" runat="server" Type="text" CssClass="form-control"></asp:TextBox>
                <asp:Label ID="lblRAddressMsg" runat="server" CssClass="text-danger" Text=""></asp:Label>
            </div>

            <div class="form-group">
                 <asp:Label ID="lblRArea" runat="server" Text="Area"></asp:Label>
                <asp:DropDownList ID="ddlRArea" runat="server" CssClass="form-control">
                    <asp:ListItem>North</asp:ListItem>
                    <asp:ListItem>South</asp:ListItem>
                    <asp:ListItem>Central</asp:ListItem>
                    <asp:ListItem>East</asp:ListItem>
                    <asp:ListItem>West</asp:ListItem>
                 </asp:DropDownList>
            </div>

            <div class="form-group">
                <asp:Label ID="lblMinAmnt" runat="server" Text="Mininum Amount - Minimum Amount of Orders Made for the Restaurant"></asp:Label>
                <asp:TextBox ID="txtMinAmnt" runat="server" Type="text" CssClass="form-control"></asp:TextBox>
                <asp:Label ID="lblMinAmntMsg" runat="server" CssClass="text-danger"></asp:Label>
            </div>

            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-dark" OnClick="btnSubmit_Click" />
        </asp:Panel>

        <asp:Panel ID="alertSuccess" runat="server" CssClass="mt-3 alert alert-success">
            <p>Restaurant record created successfully</p>
        </asp:Panel>

        <asp:Panel ID="alertFailure" runat="server" CssClass="mt-3 alert alert-danger">
            <p>There was an error in creating a restaurant record</p>
        </asp:Panel>
    </div>
    <div class="col-md-2"></div>
</asp:Content>
