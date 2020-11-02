<%@ Page Title="" Language="C#" MasterPageFile="~/StaffSite.Master" AutoEventWireup="true" CodeBehind="StaffPromo.aspx.cs" Inherits="FDSApplication.StaffPromo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-2"></div>
    <div class="col-md-8 mt-3">
        <h3>View Promo</h3>
        <p>View the restaurant promo over here</p>
       
        <br />

        <div class="text-center">
            <strong><asp:Label ID="lblAccessRight" runat="server" Text="" CssClass="text-danger"></asp:Label></strong>
        </div>

        <asp:Panel ID="panelAddPromo" runat="server">
            <h4>Add Promo</h4>

            <div class="form-group">
                <asp:Label ID="lblPType" runat="server" Text="Type"></asp:Label>
                <asp:DropDownList ID="ddlPType" runat="server" CssClass="form-control">
                    <asp:ListItem>Flat</asp:ListItem>
                    <asp:ListItem>Percentage</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <asp:Label ID="lblPDesc" runat="server" Text="Description"></asp:Label>
                <asp:TextBox ID="txtPDesc" runat="server" Type="text" CssClass="form-control"></asp:TextBox>
                <asp:Label ID="lblPDescMsg" runat="server" CssClass="text-danger" Text=""></asp:Label>
            </div>

            <div class="form-group">
                <div class="row">
                    <div class="col">
                        <asp:Label ID="lblPValue" runat="server" Text="Promo Value"></asp:Label>
                        <asp:TextBox ID="txtPValue" runat="server" Type="text" CssClass="form-control"></asp:TextBox>
                        <asp:Label ID="lblPValueMsg" runat="server" CssClass="text-danger"></asp:Label>
                    </div>

                    <div class="col">
                        <asp:Label ID="lblPCode" runat="server" Text="Promo Code"></asp:Label>
                        <asp:TextBox ID="txtPCode" runat="server" Type="text" CssClass="form-control"></asp:TextBox>
                        <asp:Label ID="lblPCodeMsg" runat="server" CssClass="text-danger"></asp:Label>
                    </div>
                </div>
            </div>

            <div class="form-group">
                <div class="row">
                    <div class="col">
                        <asp:Label ID="lblPStartDate" runat="server" Text="Start Date (DD/MM/YYYY)"></asp:Label>
                        <asp:TextBox ID="txtPStartDate" runat="server" Type="Text" CssClass="form-control"></asp:TextBox>
                        <asp:Label ID="lblPStartDateMsg" runat="server" CssClass="text-danger"></asp:Label>
                    </div>

                    <div class="col">
                        <asp:Label ID="lblPEndDate" runat="server" Text="End Date (DD/MM/YYYY)"></asp:Label>
                        <asp:TextBox ID="txtPEndDate" runat="server" Type="text" CssClass="form-control"></asp:TextBox>
                        <asp:Label ID="lblPEndDateMsg" runat="server" CssClass="text-danger"></asp:Label>
                    </div>
                </div>
            </div>

            <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-dark" OnClick="btnAdd_Click"/>
            &nbsp;
            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-dark" OnClick="btnBack_Click"/>
        </asp:Panel>

        <asp:Panel ID="alertPromoSuccess" runat="server" CssClass="mt-2 alert alert-success">
            <p>Food Item record created successfully</p>
        </asp:Panel>

        <asp:Panel ID="alertPromoFailure" runat="server" CssClass="mt-2 alert alert-danger">
            <p><asp:Label ID="lblPromoFailure" runat="server" Text=""></asp:Label></p>
        </asp:Panel>

        <asp:Panel ID="alertOthersFailure" runat="server" CssClass="mt-2 alert alert-danger">
            <p><asp:Label ID="lblErrorRetrieve" runat="server" Text=""></asp:Label></p>
        </asp:Panel>

        <asp:Panel ID="panelViewPromo" runat="server" CssClass="mt-2">
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

            <div class="mt-2 text-center">
                <strong><asp:Label ID="lblNoPromo" runat="server" Text=""></asp:Label></strong>
            </div>

            <asp:GridView ID="gv_promo" runat="server" CssClass="mt-2 table table-bordered" AllowPaging="False" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField HeaderText="PromoId" Visible="False" DataField="promoid" />
                    <asp:BoundField HeaderText="RestId" Visible="False" DataField="restid" />
                    <asp:BoundField HeaderText="Promo Description" DataField="promoDesc" />
                    <asp:BoundField HeaderText="Promo Type" DataField="promoType" />
                    <asp:BoundField HeaderText="Promo Value" DataField="promoValue" />
                    <asp:BoundField HeaderText="Promo Start Date" DataField="promoStartDate" />
                    <asp:BoundField HeaderText="Promo End Date" DataField="promoEndDate" />
                    <asp:BoundField HeaderText="Promo Code" DataField="promoCode" />
                </Columns>
            </asp:GridView>

            <div class="text-center mt-2">
                <asp:Button ID="btnAddPromo" runat="server" Text="Add Promo" CssClass="btn btn-dark" OnClick="btnAddPromo_Click" />
            </div>         
        </asp:Panel>
        
    </div>
    <div class="col-md-2"></div>
</asp:Content>
