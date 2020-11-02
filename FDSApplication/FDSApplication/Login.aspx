<%@ Page Title="" Language="C#" MasterPageFile="~/IndexSite.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FDSApplication.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-3"></div>

    <div class="col-md-6 mt-3">
        <h3 class="text-center">Welcome to FDS Application</h3>
        
        <br />

        <div class="form-group">
            <asp:Label ID="lblUsername" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="txtUsername" Type="text" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="lblUsernameMsg" runat="server" CssClass="text-danger" Text=""></asp:Label>
        </div>
       
        <div class="form-group">
            <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="txtPassword" Type="password" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="lblPasswordMsg" runat="server" CssClass="text-danger" Text=""></asp:Label>
        </div>

        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-dark btn-lg btn-block" OnClick="btnLogin_Click" />

        <asp:Panel ID="alertFailure" runat="server" CssClass="mt-2 alert alert-danger">
            <p><asp:Label ID="lblAlertMsg" runat="server" Text=""></asp:Label></p>
        </asp:Panel>
    </div>

    <div class="col-md-3"></div>
</asp:Content>
