<%@ Page Title="" Language="C#" MasterPageFile="~/UserSite.Master" AutoEventWireup="true" CodeBehind="UserRetrieveReview.aspx.cs" Inherits="FDSApplication.UserRetrieveReview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-2">
    </div>
    <div class="col-md-8 mt-2">
        <h3>View Review</h3>
        <div class="row">
            <div class="col">
                <div class="form-group">
                    <asp:Label ID="lblOrderId" runat="server" Text="Order ID"></asp:Label>
                    <asp:TextBox ID="txtOrderId" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>
            </div>

            <div class="col">
                <div class="form-group">
                    <asp:Label ID="lblTransactionId" runat="server" Text="Transaction ID"></asp:Label>
                    <asp:TextBox ID="txtTransactionID" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
        </div>

        <asp:Panel ID="panelRiderDetails" runat="server" CssClass="mt-1">
            <h4>Rider Details</h4>
            <div class="row">
                <div class="col">
                    <div class="form-group">
                        <asp:Label ID="lblRiderID" runat="server" Text="Rider ID"></asp:Label>
                        <asp:TextBox ID="txtRiderID" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="col">
                    <div class="form-group">
                        <asp:Label ID="lblRiderName" runat="server" Text="Rider Name"></asp:Label>
                        <asp:TextBox ID="txtRiderName" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <div class="form-group">
                        <asp:Label ID="lblRestaurantReview" runat="server" Text="Restaurant Review"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtReview" runat="server" Height="150px" MaxLength="500" TextMode="MultiLine" ReadOnly="True" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col">
                    <div class="form-group">
                        <asp:Label ID="lblRestaurantRating" runat="server" Text="Restaurant Rating"></asp:Label>
                        <br />
                        <asp:DropDownList ID="ddlRestaurantRating" runat="server" Enabled="False" CssClass="form-control">
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>1</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblRiderRating" runat="server" Text="Rider Rating"></asp:Label>
                        <br />
                        <asp:DropDownList ID="ddlRiderRating" runat="server" Enabled="False" CssClass="form-control">
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>1</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <div class="mt-2 text-center">
            <asp:Button ID="btn_Back" runat="server" Text="Back" CssClass="btn btn-dark" OnClick="btn_Back_Click"/>
            &nbsp;
            </div>
    </div>
    <div class="col-md-2">
    </div>
</asp:Content>
