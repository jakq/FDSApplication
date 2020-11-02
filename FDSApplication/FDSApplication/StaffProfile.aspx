<%@ Page Title="" Language="C#" MasterPageFile="~/StaffSite.Master" AutoEventWireup="true" CodeBehind="StaffProfile.aspx.cs" Inherits="FDSApplication.StaffProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-3"></div>
    <div class="col-md-6 mt-3">
        <h3>Staff Profile</h3>
        <p>You can edit your profile in this page</p>

        <br />

        <div class="form-group">
            <asp:Label ID="lblSUserName" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="txtSUsername" runat="server" Type="text" CssClass="form-control" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblSName" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="txtSName" runat="server" Type="text" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="lblSNameMsg" runat="server" CssClass="text-danger" Text=""></asp:Label>
        </div>

        <asp:Panel ID="panelWorkplace" runat="server">
            <br />

            <h4>Staff Workplace Details</h4>

            <div class="form-group">
                <asp:Label ID="lblRName" runat="server" Text="Restaurant Name"></asp:Label>
                <asp:TextBox ID="txtRName" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="lblRAddress" runat="server" Text="Restaurant Address"></asp:Label>
                <asp:TextBox ID="txtRAddress" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="lblRArea" runat="server" Text="Restaurant Area"></asp:Label>
                <asp:TextBox ID="txtRArea" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>
        </asp:Panel>

        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-dark" OnClick="btnUpdate_Click" />

        <br />

        <asp:Panel ID="alertSuccess" runat="server" CssClass="alert alert-success mt-2">
            <p>You have successfully updated your profile</p>
        </asp:Panel>

        <asp:Panel ID="alertFailure" runat="server" CssClass="alert alert-danger mt-2">
            <p>
                <asp:Label ID="lblAlertMsg" runat="server" Text=""></asp:Label>
            </p>
        </asp:Panel>

        <br />

        <div class="text-center">
            <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" CssClass="btn btn-dark" OnClick="btnChangePassword_Click" />
            &nbsp;
            <asp:Button ID="btnDeactivate" runat="server" Text="Deactivate Account" CssClass="btn btn-danger" OnClick="btnDeactivate_Click" />
        </div>

        <br />
        <div class="text-center">
            <strong>
                <asp:Label ID="lblChangeSuccess" runat="server" Text="" CssClass="text-success"></asp:Label></strong>
            <strong>
                <asp:Label ID="lblChangeFailure" runat="server" Text="" CssClass="text-danger"></asp:Label></strong>
        </div>

        <asp:Panel ID="panelChangePassword" runat="server">
            <div class="form-group mt-2">
                <asp:Label ID="lblNewPassword" runat="server" Text="Enter New Password"></asp:Label>
                <asp:TextBox ID="txtNewPassword" runat="server" CssClass="form-control" type="password"></asp:TextBox>
            </div>

            <asp:Button ID="btnChange" runat="server" Text="Change" CssClass="btn btn-dark" OnClick="btnChange_Click" />
        </asp:Panel>

    </div>
    <div class="col-md-3"></div>
</asp:Content>
