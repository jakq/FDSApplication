<%@ Page Title="" Language="C#" MasterPageFile="~/RiderSite.Master" AutoEventWireup="true" CodeBehind="CreateFullTimeWWS.aspx.cs" Inherits="FDSApplication.CreateFullTimeWWS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-1"></div>
    <div class="col-md-10 mt-3">
        <h3>Create Monthly Work Schedule</h3>
        <p>Create your monthly work schedule (WWS) over here</p>

        <table class="table table-bordered">
            <tr>
                <td><strong>Day Option</strong></td>
                <td><strong>Start Day</strong></td>
                <td><strong>End Day</strong></td>
            </tr>
            <tr>
                <td>1</td>
                <td>Monday</td>
                <td>Friday</td>
            </tr>
            <tr>
                <td>2</td>
                <td>Tuesday</td>
                <td>Saturday</td>
            </tr>
            <tr>
                <td>3</td>
                <td>Wednesday</td>
                <td>Sunday</td>
            </tr>
            <tr>
                <td>4</td>
                <td>Thurday</td>
                <td>Monday</td>
            </tr>
            <tr>
                <td>5</td>
                <td>Friday</td>
                <td>Tuesday</td>
            </tr>
            <tr>
                <td>6</td>
                <td>Saturday</td>
                <td>Wednesday</td>
            </tr>
            <tr>
                <td>7</td>
                <td>Sunday</td>
                <td>Thursday</td>
            </tr>
        </table>

        <br />

        <table class="table table-bordered">
            <tr>
                <td><strong>Shift</strong></td>
                <td><strong>Shift One Start</strong></td>
                <td><strong>Shift One End</strong></td>
                <td><strong>Shift Two Start</strong></td>
                <td><strong>Shift Two End</strong></td>
            </tr>
            <tr>
                <td>1</td>
                <td>10:00:00</td>
                <td>14:00:00</td>
                <td>15:00:00</td>
                <td>19:00:00</td>
            </tr>
            <tr>
                <td>2</td>
                <td>11:00:00</td>
                <td>15:00:00</td>
                <td>16:00:00</td>
                <td>20:00:00</td>
            </tr>
            <tr>
                <td>3</td>
                <td>12:00:00</td>
                <td>16:00:00</td>
                <td>17:00:00</td>
                <td>21:00:00</td>
            </tr>
            <tr>
                <td>4</td>
                <td>13:00:00</td>
                <td>17:00:00</td>
                <td>18:00:00</td>
                <td>22:00:00</td>
            </tr>
        </table>

        <div class="row">
            <div class="col">
                <div class="form-group">
                    <asp:Label ID="lblStartDate" runat="server" Text="Start Date"></asp:Label>
                    <asp:TextBox ID="txtStartDate" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>
            </div>

            <div class="col">
                <div class="form-group">
                    <asp:Label ID="lblEndDate" runat="server" Text="End Date"></asp:Label>
                    <asp:TextBox ID="txtEndDate" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col">
                <div class="form-group">
                    <asp:Label ID="lblWorkDay" runat="server" Text="Select Work Day"></asp:Label>
                    <asp:DropDownList ID="ddlWorkDay" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <div class="col">
                <div class="form-group">
                    <asp:Label ID="lbl" runat="server" Text="Select Shift"></asp:Label>
                    <asp:DropDownList ID="ddlShift" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>

        <asp:Button ID="btn_Confirm_WWS" runat="server" Text="Confirm" CssClass="btn btn-dark" OnClick="btn_Confirm_WWS_Click" />
        <strong class="ml-2">
            <asp:Label ID="lblNoSelection" runat="server" CssClass="text-danger"></asp:Label>
            <asp:Label ID="lblSuccess" runat="server" CssClass="text-success"></asp:Label>
        </strong>      
    </div>
    <div class="col-md-1"></div>
</asp:Content>
