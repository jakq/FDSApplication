<%@ Page Title="" Language="C#" MasterPageFile="~/StaffSite.Master" AutoEventWireup="true" CodeBehind="CreateStaff.aspx.cs" Inherits="FDSApplication.CreateStaff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-2"></div>
    <div class="col-md-8 mt-3">
        <h3>Select Restaurant</h3>
        <p>Select a Restauarant to create staff</p>

        <br />

        <asp:Label ID="lblRAreaCategory" runat="server" Text="Search Restaurant By Area"></asp:Label>
        <asp:DropDownList ID="ddlSearchArea" runat="server" CssClass="form-control">
            <asp:ListItem>North</asp:ListItem>
            <asp:ListItem>South</asp:ListItem>
            <asp:ListItem>Central</asp:ListItem>
            <asp:ListItem>East</asp:ListItem>
            <asp:ListItem>West</asp:ListItem>
        </asp:DropDownList>

        <div class="text-center mt-2">
            <asp:Button ID="btnSearch" runat="server" Text="Search Restaurant" CssClass="btn btn-dark" OnClick="btnSearch_Click" />
        </div>

        <div class="text-center mt-3">
            <strong><asp:Label ID="lblUserDenied" runat="server" Text="" CssClass="text-danger"></asp:Label></strong>
        </div>

        <asp:Panel runat="server" ID="panelCreateStaff">
            <h3>Create Staff Record</h3>
            <p><asp:Label ID="lblCreateStaff" runat="server" Text="" CssClass="font-weight-bold"></asp:Label></p>

            <br />

            <div class="form-group">
                <asp:Label ID="lblRestId" runat="server" Text="Restaurant ID"></asp:Label>
                <asp:TextBox ID="txtRestId" runat="server" Type="text" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="lblRestName" runat="server" Text="Restaurant Name"></asp:Label>
                <asp:TextBox ID="txtRName" runat="server" Type="text" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="lblStaffName" runat="server" Text="Staff Name"></asp:Label>
                <asp:TextBox ID="txtStaffName" runat="server" Type="text" CssClass="form-control"></asp:TextBox>
                <asp:Label ID="lblStaffNameMsg" runat="server" CssClass="text-danger" Text=""></asp:Label>
            </div>

            <div class="form-group">
                <asp:Label ID="lblStaffUsername" runat="server" Text="Staff Username"></asp:Label>
                <asp:TextBox ID="txtStaffUsername" runat="server" Type="text" CssClass="form-control"></asp:TextBox>
                <asp:Label ID="lblStaffUsernameMsg" runat="server" CssClass="text-danger" Text=""></asp:Label>
            </div>

            <div class="form-group">
                <asp:Label ID="lblStaffPassword" runat="server" Text="Staff Password"></asp:Label>
                <asp:TextBox ID="txtStaffPassword" runat="server" Type="password" CssClass="form-control"></asp:TextBox>
                <asp:Label ID="lblStaffPasswordMsg" runat="server" CssClass="text-danger"></asp:Label>
            </div>

            <asp:Button ID="btn_CreateStaff" runat="server" CssClass="btn btn-dark" Text="Create Staff" OnClick="btn_CreateStaff_Click"/>
        </asp:Panel>

        <asp:Panel ID="alertSuccess" runat="server" CssClass="mt-3 alert alert-success">
            <p>You have successfully created a staff account</p>
        </asp:Panel>

        <asp:Panel ID="alertFailure" runat="server" CssClass="mt-3 alert alert-danger">
            <p><asp:Label ID="lblAlertMsg" runat="server" Text=""></asp:Label></p>
        </asp:Panel>

        <asp:Panel ID="panelViewRestaurants" runat="server" CssClass="mt-2">
            <asp:GridView runat="server" CssClass="table table-bordered" ID="gv_restaurants" AutoGenerateColumns="False" AllowPaging="False">
                <Columns>
                    <asp:BoundField DataField="restid" HeaderText="ID" />
                    <asp:BoundField DataField="restname" HeaderText="Restaurant Name" />
                    <asp:BoundField DataField="restaddress" HeaderText="Address" />
                    <asp:BoundField DataField="restarea" HeaderText="Area" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="text-center">
                                <asp:LinkButton ID="lnk_AddStaff" runat="server" CommandArgument='<%# Eval("restid")%>' OnClick="lnk_AddStaff_Click">Add Staff</asp:LinkButton>
                            </div>                          
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:Panel>
    </div>
    <div class="col-md-2"></div>
</asp:Content>
