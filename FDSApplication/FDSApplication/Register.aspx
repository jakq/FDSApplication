<%@ Page Title="" Language="C#" MasterPageFile="~/IndexSite.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="FDSApplication.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-2"></div>
    <div class="col-md-8 mt-3">

        <h3>Register</h3>
        <p>Toggle the type of account you want to register</p>

        <div class="btn-group ">
            <asp:Button ID="btnToggleUserRegister" runat="server" CssClass="btn btn-dark" Text="User" OnClick="btnToggleUserRegister_Click" />
            <asp:Button ID="btnToggleRiderRegister" runat="server" CssClass="btn btn-dark" Text="Rider" OnClick="btnToggleRiderRegister_Click" />
        </div>

        <hr />

        <asp:Panel ID="userRegisterPanel" runat="server">
            <h3>User Register</h3>
            <p>Create a user account for FDS</p>

            <div class="form-group">
                <asp:Label ID="lblCName" runat="server" Text="Name"></asp:Label>
                <asp:TextBox ID="txtCName" runat="server" Type="text" CssClass="form-control"></asp:TextBox>
                <asp:Label ID="lblCNameMsg" runat="server" CssClass="text-danger" Text=""></asp:Label>
            </div>

            <div class="form-group">
                <asp:Label ID="lblCUserName" runat="server" Text="Username"></asp:Label>
                <asp:TextBox ID="txtCUsername" runat="server" Type="text" CssClass="form-control"></asp:TextBox>
                <asp:Label ID="lblCUsernameMsg" runat="server" CssClass="text-danger" Text=""></asp:Label>
            </div>

            <div class="form-group">
                <asp:Label ID="lblCPassword" runat="server" Text="Password"></asp:Label>
                <asp:TextBox ID="txtCPassword" runat="server" Type="password" CssClass="form-control"></asp:TextBox>
                <asp:Label ID="lblCPasswordMsg" runat="server" CssClass="text-danger"></asp:Label>
            </div>

            <asp:Button ID="btnUserRegister" runat="server" Text="Register" CssClass="btn btn-dark" OnClick="btnUserRegister_Click" />
        </asp:Panel>

        <asp:Panel ID="riderRegisterPanel" runat="server">
            <h3>Rider Register</h3>
            <p>Create a rider account for FDS</p>

            <div class="form-group">
                <asp:Label ID="lblRName" runat="server" Text="Rider Name"></asp:Label>
                <asp:TextBox ID="txtRName" runat="server" Type="text" CssClass="form-control"></asp:TextBox>
                <asp:Label ID="lblRNameMsg" runat="server" CssClass="text-danger" Text=""></asp:Label>
            </div>

            <div class="form-group">
                <asp:Label ID="lblRUsername" runat="server" Text="Username"></asp:Label>
                <asp:TextBox ID="txtRUserName" runat="server" Type="text" CssClass="form-control"></asp:TextBox>
                <asp:Label ID="lblRUsernameMsg" runat="server" CssClass="text-danger" Text=""></asp:Label>
            </div>

            <div class="form-group">
                <asp:Label ID="lblRPassword" runat="server" Text="Password"></asp:Label>
                <asp:TextBox ID="txtRPassword" runat="server" Type="password" CssClass="form-control"></asp:TextBox>
                <asp:Label ID="lblRPasswordMsg" runat="server" CssClass="text-danger"></asp:Label>
            </div>

            <div class="form-group">
                <div class="form-check">
                    <asp:CheckBox ID="chkBoxFullTime" runat="server" CssClass="form-check-input"/>
                    <asp:Label ID="lblFullTime" runat="server" Text="Apply as a Full-Time Job?" CssClass="form-check-label"></asp:Label>
                </div>
            </div>
                         
            <asp:Button ID="btnRiderRegister" runat="server" Text="Register" CssClass="btn btn-dark" OnClick="btnRiderRegister_Click"/>
        </asp:Panel>
        
       <asp:Panel ID="alertSuccess" runat="server" CssClass="alert alert-success mt-2">
            <p>You have successfully registered an account</p>
        </asp:Panel>

        <asp:Panel ID="alertFailure" runat="server" CssClass="alert alert-danger mt-2">
            <p>
                <asp:Label ID="lblAlertMsg" runat="server" Text=""></asp:Label></p>
        </asp:Panel>

    </div>
    <div class="col-md-2"></div>
</asp:Content>
