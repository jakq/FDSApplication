<%@ Page Title="" Language="C#" MasterPageFile="~/RiderSite.Master" AutoEventWireup="true" CodeBehind="RetrieveLatestMWSWWS.aspx.cs" Inherits="FDSApplication.RetrieveLatestMWSWWS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-2"></div>
    <div class="col-md-8 mt-3">       
        <h3>View Schedule - Full Time</h3>
        <p>View your Monthly Work Schedule (MWS) over here</p>
            
        <br />

        <div class="form-group">
            <asp:Label ID="lblOption" runat="server" Text="Choose Option"></asp:Label>
            <asp:DropDownList ID="ddlOption" runat="server" AutoPostBack="True" CssClass="form-control">
                <asp:ListItem>Select Schedule to View</asp:ListItem>
                <asp:ListItem>Remaining Schedule</asp:ListItem>
            </asp:DropDownList>
        </div>

        <asp:GridView ID="gv_schedule" runat="server" AutoGenerateColumns="False" CssClass="mt-2 table table-bordered">
            <Columns>
                <asp:BoundField DataField="mwsId" HeaderText="MWS ID" />
                <asp:BoundField DataField="wwsStartTime" HeaderText="Shift One Start" />
                <asp:BoundField DataField="wwsEndTime" HeaderText="Shift One End" />
                <asp:BoundField DataField="wwsStartTimeTwo" HeaderText="Shift Two Start" />
                <asp:BoundField DataField="wwsEndTimeTwo" HeaderText="Shift Two End" />
            </Columns>
        </asp:GridView> 

        <asp:Panel ID="alertFailure" runat="server" CssClass="mt-2 alert alert-danger mt-2">
            <p><asp:Label ID="lblAlertMsg" runat="server" Text=""></asp:Label></p>
        </asp:Panel>
    </div>

    <div class="col-md-2"></div>   
</asp:Content>
