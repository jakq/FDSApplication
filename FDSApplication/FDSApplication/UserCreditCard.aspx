<%@ Page Title="" Language="C#" MasterPageFile="~/UserSite.Master" AutoEventWireup="true" CodeBehind="UserCreditCard.aspx.cs" Inherits="FDSApplication.UserCreditCard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-2"></div>
    <div class="col-md-8 mt-3">
        <h3>View Credit Card</h3>
        <p>View your credit card(s) for this application</p>

        <div class="text-center">
            <strong><asp:Label ID="lblNoCreditCard" runat="server" Text=""></asp:Label></strong>
        </div>

        <asp:GridView ID="gv_creditCard" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered">
            <Columns>
                <asp:BoundField HeaderText="ccID" Visible="False" DataField="ccid" />
                <asp:BoundField HeaderText="custId" Visible="False" DataField="cid" />
                <asp:BoundField HeaderText="Credit Card Num" DataField="ccNum" />
                <asp:BoundField HeaderText="Credit Card Expiry (MMYY)" DataField="ccExpiry" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkRemove" runat="server"  CommandArgument='<%# Eval("ccid")%>' OnClick="lnkRemove_Click">Remove</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <div class="text-center mt-2">
            <asp:Button ID="btnAddCreditCard" runat="server" Text="Add Credit Card" CssClass="btn btn-dark" OnClick="btnAddCreditCard_Click"/>
        </div>

        <asp:Panel ID="panelCreateCreditCard" runat="server">
            <h3>Add Credit Card</h3>

            <div class="form-group">
                <asp:Label ID="lblCCNum" runat="server" Text="Credit Card Number"></asp:Label>
                <asp:TextBox ID="txtCCNum" runat="server" Type="text" CssClass="form-control"></asp:TextBox>
                <asp:Label ID="lblCCNumMsg" runat="server" CssClass="text-danger" Text=""></asp:Label>
            </div>

            <div class="form-group">
                <div class="row">
                    <div class="col">
                        <asp:Label ID="lblCCV" runat="server" Text="CCV"></asp:Label>
                        <asp:TextBox ID="txtCCV" runat="server" Type="text" CssClass="form-control"></asp:TextBox>
                        <asp:Label ID="lblCCVMsg" runat="server" CssClass="text-danger"></asp:Label>
                    </div>

                    <div class="col">
                        <asp:Label ID="lblCCExpiry" runat="server" Text="Expiry(MMYY)"></asp:Label>
                        <asp:TextBox ID="txtCCExpiry" runat="server" Type="text" CssClass="form-control"></asp:TextBox>
                        <asp:Label ID="lblCCExpiryMsg" runat="server" CssClass="text-danger"></asp:Label>
                    </div>
                </div>
            </div>

            <asp:Button ID="btnAddCC" runat="server" Text="Add" OnClick="btnAddCC_Click" CssClass="btn btn-dark"/>

        </asp:Panel>

        <br />

        <asp:Panel ID="alertSuccess" runat="server" CssClass="mt-2 alert alert-success">
            <p>Credit Card record created successfully</p>
        </asp:Panel>

        <asp:Panel ID="alertFailure" runat="server" CssClass="mt-2 alert alert-danger">
            <p><asp:Label ID="lblFailure" runat="server" Text=""></asp:Label></p>
        </asp:Panel>
    </div>
    <div class="col-md-2"></div>
</asp:Content>
