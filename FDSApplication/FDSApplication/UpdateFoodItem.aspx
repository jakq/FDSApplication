<%@ Page Title="" Language="C#" MasterPageFile="~/StaffSite.Master" AutoEventWireup="true" CodeBehind="UpdateFoodItem.aspx.cs" Inherits="FDSApplication.UpdateFoodItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-2"></div>
    <div class="col-md-8 mt-3">
        <h3>Select Food Item</h3>
        <p>Select the restaurant food item over here</p>

        <br />

        <div class="text-center">
            <strong><asp:Label ID="lblAccessRight" runat="server" Text="" CssClass="text-danger"></asp:Label></strong>
        </div>

        <asp:Panel ID="panelUpdateFoodItem" runat="server">
            <h4>Update Food Item</h4>

            <div class="form-group">
                <asp:Label ID="lblFoodId" runat="server" Text="Food ID"></asp:Label>
                <asp:TextBox ID="txtFId" runat="server" Type="text" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="lblFCategory" runat="server" Text="Category"></asp:Label>
                <asp:DropDownList ID="ddlFCategory" runat="server" CssClass="form-control">
                    <asp:ListItem>Chinese</asp:ListItem>
                    <asp:ListItem>Malay</asp:ListItem>
                    <asp:ListItem>Indian</asp:ListItem>
                    <asp:ListItem>Western</asp:ListItem>
                    <asp:ListItem>Japanese</asp:ListItem>
                    <asp:ListItem>Korean</asp:ListItem>
                    <asp:ListItem>Dessert</asp:ListItem>
                    <asp:ListItem>Beverage</asp:ListItem>
                    <asp:ListItem>Snack</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <asp:Label ID="lblFTitle" runat="server" Text="Food Title"></asp:Label>
                <asp:TextBox ID="txtFTitle" runat="server" Type="text" CssClass="form-control"></asp:TextBox>
                <asp:Label ID="lblFTitleMsg" runat="server" CssClass="text-danger" Text=""></asp:Label>
            </div>

            <div class="form-group">
                <div class="row">
                    <div class="col">
                        <asp:Label ID="lblPrice" runat="server" Text="Price of Food"></asp:Label>
                        <asp:TextBox ID="txtPrice" runat="server" Type="text" CssClass="form-control"></asp:TextBox>
                        <asp:Label ID="lblPriceMsg" runat="server" CssClass="text-danger"></asp:Label>
                    </div>

                    <div class="col">
                        <asp:Label ID="lblDLimit" runat="server" Text="Food Daily Limit"></asp:Label>
                        <asp:TextBox ID="txtDLimit" runat="server" Type="text" CssClass="form-control"></asp:TextBox>
                        <asp:Label ID="lblDLimitMsg" runat="server" CssClass="text-danger"></asp:Label>
                    </div>
                </div>
            </div>

            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-dark" OnClick="btnUpdate_Click"/> 
            &nbsp;
            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-dark" OnClick="btnBack_Click"/>
        </asp:Panel>

        <asp:Panel ID="alertFoodSuccess" runat="server" CssClass="mt-2 alert alert-success">
            <p>Food Item record updated successfully</p>
        </asp:Panel>

        <asp:Panel ID="alertFoodFailure" runat="server" CssClass="mt-2 alert alert-danger">
            <p><asp:Label ID="lblFoodFailure" runat="server" Text=""></asp:Label></p>
        </asp:Panel>

        <asp:Panel ID="alertOthersFailure" runat="server" CssClass="alert alert-danger">
            <p><asp:Label ID="lblErrorRetrieve" runat="server" Text=""></asp:Label></p>
        </asp:Panel>

        <asp:Panel ID="panelViewFoodItem" runat="server" CssClass="mt-2">
             <div class="form-group">
                <div class="row">
                    <div class="col">
                        <asp:Label ID="lblRestId" runat="server" Text="Restaurant ID"></asp:Label>
                        <asp:TextBox ID="txtRestId" runat="server" Type="text" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>

                    <div class="col">
                        <asp:Label ID="lblRestName" runat="server" Text="Restaurant Name"></asp:Label>
                        <asp:TextBox ID="txtRestName" runat="server" Type="text" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                
            </div>

            <div class="text-center">
                <strong><asp:Label ID="lblNoFoodItem" runat="server" Text=""></asp:Label></strong>
            </div>

            <asp:GridView ID="gv_foodItem" runat="server" CssClass="table table-bordered" AllowPaging="False" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField HeaderText="FoodId" Visible="False" DataField="foodid" />
                    <asp:BoundField HeaderText="RestId" Visible="False" DataField="restid" />
                    <asp:BoundField HeaderText="Category" DataField="foodCategory" />
                    <asp:BoundField HeaderText="Food Title" DataField="foodTitle" />
                    <asp:BoundField HeaderText="Price" DataField="price" />
                    <asp:BoundField HeaderText="Daily Limit" DataField="dailyLimit" />
                    <asp:BoundField HeaderText="Current Count" DataField="orderCounter" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="text-center">
                                <asp:LinkButton ID="lnk_Update" runat="server" CommandArgument='<%# Eval("foodid")%>' OnClick="lnk_Update_Click">Update</asp:LinkButton>
                            </div>                           
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>  
        </asp:Panel>

        

    </div>
    <div class="col-md-2"></div>
</asp:Content>
