<%@ Page Title="" Language="C#" MasterPageFile="~/StaffSite.Master" AutoEventWireup="true" CodeBehind="ViewAllFoodItems.aspx.cs" Inherits="FDSApplication.ViewAllFoodItems" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-2"></div>
    <div class="col-md-8 mt-2">
        <h3>Select Restuarant</h3>
        <p>Select a restaurant to view the food items in the restaurant</p>

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

        <asp:Panel ID="panelViewFoodItems" runat="server" CssClass="mt-2">
            <div class="form-group">
                Restaurant Name
                <asp:TextBox ID="txtRName" runat="server" Type="text" CssClass="form-control" ReadOnly="true"></asp:TextBox>                
            </div>

            <asp:GridView ID="gv_foodItem" runat="server" CssClass="mt-1 table table-bordered" AllowPaging="False" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField HeaderText="FoodId" Visible="False" DataField="foodid" />
                    <asp:BoundField HeaderText="RestId" Visible="False" DataField="restid" />
                    <asp:BoundField HeaderText="Category" DataField="foodCategory" />
                    <asp:BoundField HeaderText="Food Title" DataField="foodTitle" />
                    <asp:BoundField HeaderText="Price" DataField="price" />
                    <asp:BoundField HeaderText="Daily Limit" DataField="dailyLimit" />
                    <asp:BoundField HeaderText="Current Count" DataField="orderCounter" />
                </Columns>
            </asp:GridView>

            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-dark" OnClick="btnBack_Click" />
        </asp:Panel>

        <asp:Panel ID="alertFailure" runat="server" CssClass="mt-2 alert alert-danger">
            <p><asp:Label ID="lblErrorRetrieve" runat="server" Text=""></asp:Label></p>
        </asp:Panel>

        <asp:GridView runat="server" CssClass="mt-2 table table-bordered" ID="gv_restaurants" AutoGenerateColumns="False" AllowPaging="False">
            <Columns>
                    <asp:BoundField DataField="restid" HeaderText="ID" Visible="false" />
                    <asp:BoundField DataField="restname" HeaderText="Restaurant Name" />
                    <asp:BoundField DataField="restaddress" HeaderText="Address" />
                    <asp:BoundField DataField="restarea" HeaderText="Area" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="text-center">
                                <asp:LinkButton ID="lnk_View" runat="server" CssClass="text-center" CommandArgument='<%# Eval("restid")%>' OnClick="lnk_View_Click">View</asp:LinkButton>
                            </div>                   
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
        </asp:GridView>    
    </div>
    <div class="col-md-2"></div>
</asp:Content>
