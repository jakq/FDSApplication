<%@ Page Title="" Language="C#" MasterPageFile="~/StaffSite.Master" AutoEventWireup="true" CodeBehind="UpdatePromo.aspx.cs" Inherits="FDSApplication.UpdatePromo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-2"></div>
    <div class="col-md-8 mt-3">
        <h3>Select Promo</h3>
        <p>Select the restaurant promo over here</p>

        <br />

        <div class="text-center">
            <strong><asp:Label ID="lblAccessRight" runat="server" Text="" CssClass="text-danger"></asp:Label></strong>
        </div>

        <asp:Panel ID="panelUpdatePromo" runat="server">
            <h4>Update Food Item</h4>

            <div class="form-group">
                <asp:Label ID="lblPromoId" runat="server" Text="Promo ID"></asp:Label>
                <asp:TextBox ID="txtPromoId" runat="server" Type="text" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="lblPType" runat="server" Text="Type"></asp:Label>
                <asp:DropDownList ID="ddlPType" runat="server" CssClass="form-control">
                    <asp:ListItem>Flat</asp:ListItem>
                    <asp:ListItem>Percentage</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <asp:Label ID="lblPDesc" runat="server" Text="Promo Description"></asp:Label>
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

            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-dark" OnClick="btnUpdate_Click"/> 
            &nbsp;
            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-dark" OnClick="btnBack_Click"/>
        </asp:Panel>

        <asp:Panel ID="alertPromoSuccess" runat="server" CssClass="alert alert-success">
            <p>Food Item record updated successfully</p>
        </asp:Panel>

        <asp:Panel ID="alertPromoFailure" runat="server" CssClass="alert alert-danger">
            <p><asp:Label ID="lblPromoFailure" runat="server" Text=""></asp:Label></p>
        </asp:Panel>

        <asp:Panel ID="alertOthersFailure" runat="server" CssClass="alert alert-danger">
            <p><asp:Label ID="lblErrorRetrieve" runat="server" Text=""></asp:Label></p>
        </asp:Panel>

        <asp:Panel ID="panelViewFoodItem" runat="server" CssClass="mt-3">
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
                <strong><asp:Label ID="lblNoPromo" runat="server" Text=""></asp:Label></strong>
            </div>

           <asp:GridView ID="gv_promo" runat="server" CssClass="table table-bordered" AllowPaging="False" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField HeaderText="PromoId" Visible="False" DataField="promoid" />
                    <asp:BoundField HeaderText="RestId" Visible="False" DataField="restid" />
                    <asp:BoundField HeaderText="Promo Description" DataField="promoDesc" />
                    <asp:BoundField HeaderText="Promo Type" DataField="promoType" />
                    <asp:BoundField HeaderText="Promo Value" DataField="promoValue" />
                    <asp:BoundField HeaderText="Promo Start Date" DataField="promoStartDate" />
                    <asp:BoundField HeaderText="Promo End Date" DataField="promoEndDate" />
                    <asp:BoundField HeaderText="Promo Code" DataField="promoCode" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="text-center">
                                <asp:LinkButton ID="lnk_Update" runat="server" CommandArgument='<%# Eval("promoid")%>' OnClick="lnk_Update_Click">Update</asp:LinkButton>
                            </div>                           
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>  
        </asp:Panel>
    </div>
    <div class="col-md-2"></div>
</asp:Content>
