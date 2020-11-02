<%@ Page Title="" Language="C#" MasterPageFile="~/RiderSite.Master" AutoEventWireup="true" CodeBehind="RetrieveLatestPTWWS.aspx.cs" Inherits="FDSApplication.RetrieveLatestPTWWS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-2"></div>
    <div class="col-md-8 mt-3">
        <h3>View Schedule - Part Time</h3>
        <p>View your remaining weekly work schedule(WWS) over here.</p>

        <div class="form-group">
            <asp:Label ID="lblOption" runat="server" Text="Select Option"></asp:Label>
            <asp:DropDownList ID="ddlOption" runat="server" CssClass="form-control" AutoPostBack="True">
                <asp:ListItem>Select Schedule to View</asp:ListItem>
                <asp:ListItem>Remaining Schedule</asp:ListItem>
            </asp:DropDownList>
        </div>

         <div class="mt-3 text-center">
             <strong><asp:Label ID="lblNotWorking" runat="server" CssClass="text-danger"></asp:Label></strong>
        </div>

        <asp:GridView ID="gv_schedule" runat="server" CssClass="mt-3 table table-bordered" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="ptwwsId" HeaderText="WWS ID" />
                <asp:BoundField DataField="ptwwsStartTime" HeaderText="WWS Start Time #1" />
                <asp:BoundField DataField="ptwwsEndTime" HeaderText="WWS End Time #1" />
                <asp:BoundField DataField="ptwwsStartTimeTwo" HeaderText="WWS Start Time #2" />
                <asp:BoundField DataField="ptwwsEndTimeTwo" HeaderText="WWS End Time #2" />
                <asp:BoundField DataField="ptwwsStartTimeThree" HeaderText="WWS Start Time #3" />
                <asp:BoundField DataField="ptwwsEndTimeThree" HeaderText="WWS End Time #3" />
            </Columns>
        </asp:GridView>
    </div>
    <div class="col-md-2"></div>
</asp:Content>
