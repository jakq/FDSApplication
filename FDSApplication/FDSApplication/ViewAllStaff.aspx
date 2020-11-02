<%@ Page Title="" Language="C#" MasterPageFile="~/StaffSite.Master" AutoEventWireup="true" CodeBehind="ViewAllStaff.aspx.cs" Inherits="FDSApplication.ViewAllStaff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-2"></div>
    <div class="col-md-8 mt-3">
        <h3>Select a Restaurant</h3>
        <p>Select a restaurant record to view the staff in restaurant</p>

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
            <strong><asp:Label ID="lblAccessRight" runat="server" Text="" CssClass="text-danger"></asp:Label></strong>
        </div>

        <asp:Panel ID="panelViewStaff" runat="server">
            <h4><asp:Label ID="lblRestName" runat="server" Text=""></asp:Label></h4>

            <asp:GridView ID="gv_viewStaff" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="staffId" HeaderText="staffId" Visible="False" />
                    <asp:BoundField DataField="restId" HeaderText="restId" Visible="False" />
                    <asp:BoundField DataField="staffname" HeaderText="Staff Name" />
                </Columns>
            </asp:GridView>

             <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-dark" OnClick="btnBack_Click"/>
        </asp:Panel>

        <asp:Panel ID="alertFailure" runat="server" CssClass="mt-2 alert alert-danger">
            <p>There was an error in creating a restaurant record</p>
            <p><asp:Label ID="lblErrorRetrieve" runat="server" Text=""></asp:Label></p>
        </asp:Panel>
        
        <asp:GridView runat="server" CssClass="mt-2 table table-bordered" ID="gv_restaurants" AutoGenerateColumns="False" AllowPaging="False">
            <Columns>
                <asp:BoundField DataField="restid" HeaderText="ID" Visible="false" />
                <asp:BoundField DataField="restname" HeaderText="Restaurant Name" />
                <asp:BoundField DataField="restaddress" HeaderText="Address" />
                <asp:BoundField DataField="restarea" HeaderText="Area" />
                <asp:BoundField DataField="minamnt" HeaderText="Minimum Amount" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <div class="text-center">
                            <asp:LinkButton ID="lnk_ViewStaff" runat="server" CommandArgument='<%# Eval("restid")%>' OnClick="lnk_ViewStaff_Click">View Staff</asp:LinkButton>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>      
    </div>
    <div class="col-md-2"></div>
</asp:Content>
