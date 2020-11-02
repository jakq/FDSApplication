<%@ Page Title="" Language="C#" MasterPageFile="~/StaffSite.Master" AutoEventWireup="true" CodeBehind="ViewAllRestaurants.aspx.cs" Inherits="FDSApplication.ViewAllRestaurants" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-2"></div>
    <div class="col-md-8 mt-3">
        <h3>View All Restaurant</h3>
        <p>View All Restaurant Records Over Here</p>

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

        <asp:Panel ID="panelUpdateRestaurant" runat="server">
            <h3>Update Restaurant Record</h3>
            <p><asp:Label ID="lblUpdateRestaurant" runat="server" Text="" CssClass="font-weight-bold"></asp:Label></p>

            <div class="mt-1"></div>

            <div class="form-group">
                <asp:Label ID="lblRestId" runat="server" Text="Restaurant ID"></asp:Label>
                <asp:TextBox ID="txtRestId" runat="server" Type="text" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>

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

            <asp:Button ID="btnUpdateRecord" runat="server" Text="Update Record" CssClass="btn btn-dark" OnClick="btnUpdateRecord_Click"/>
        </asp:Panel>

        <asp:Panel ID="alertSuccess" runat="server" CssClass="mt-2 alert alert-success">
            <p>Restaurant record created successfully</p>
        </asp:Panel>

        <asp:Panel ID="alertFailure" runat="server" CssClass="mt-2 alert alert-danger">
            <p>There was an error in creating a restaurant record</p>
            <p><asp:Label ID="lblErrorRetrieve" runat="server" Text=""></asp:Label></p>
        </asp:Panel>
            
        <asp:Panel ID="panelViewRestaurants" runat="server" CssClass="mt-2">
            <asp:GridView runat="server" CssClass="table table-bordered" ID="gv_restaurants" AutoGenerateColumns="False" AllowPaging="False" >
                <Columns>
                    <asp:BoundField DataField="restid" HeaderText="ID" Visible="false" />
                    <asp:BoundField DataField="restname" HeaderText="Restaurant Name" />
                    <asp:BoundField DataField="restaddress" HeaderText="Address" />
                    <asp:BoundField DataField="restarea" HeaderText="Area" />
                    <asp:BoundField DataField="minamnt" HeaderText="Minimum Amount" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="text-center">
                                <asp:LinkButton ID="lnk_Update" runat="server" CommandArgument='<%# Eval("restid")%>' OnClick="lnk_Update_Click">Update</asp:LinkButton>
                            </div>                           
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:Panel>
    </div>
    <div class="col-md-2"></div>
</asp:Content>
