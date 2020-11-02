<%@ Page Title="" Language="C#" MasterPageFile="~/RiderSite.Master" AutoEventWireup="true" CodeBehind="CreatePartTimeWWS.aspx.cs" Inherits="FDSApplication.CreatePartTimeWWS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-1"></div>
    <div class="col-md-10 mt-3">
        <h3>Create Weekly Work Schedule - Part Time</h3>
        <p>Create your weekly work schedule(WWS) over here</p>

        <table class="table table-bordered">
            <tr>
                <td>Workday</td>
                <td></td>
                <td>Shift #1 Start</td>
                <td>Shift #1 End</td>
                <td>Shift #2 Start</td>
                <td>Shift #2 End</td>
                <td>Shift #3 Start</td>
                <td>Shift #3 End</td>
                <td>Hours Planned</td>
            </tr>

            <tr>
                <td>Monday</td>
                <td>
                    <asp:Label ID="Label1" runat="server" CssClass="text-danger"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddl1" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem>Select Shift</asp:ListItem>
                        <asp:ListItem>10:00:00</asp:ListItem>
                        <asp:ListItem>11:00:00</asp:ListItem>
                        <asp:ListItem>12:00:00</asp:ListItem>
                        <asp:ListItem>13:00:00</asp:ListItem>
                        <asp:ListItem>14:00:00</asp:ListItem>
                        <asp:ListItem>15:00:00</asp:ListItem>
                        <asp:ListItem>16:00:00</asp:ListItem>
                        <asp:ListItem>17:00:00</asp:ListItem>
                        <asp:ListItem>18:00:00</asp:ListItem>
                        <asp:ListItem>19:00:00</asp:ListItem>
                        <asp:ListItem>20:00:00</asp:ListItem>
                        <asp:ListItem>21:00:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddl2" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem>Select Shift</asp:ListItem>
                        <asp:ListItem>10:00:00</asp:ListItem>
                        <asp:ListItem>11:00:00</asp:ListItem>
                        <asp:ListItem>12:00:00</asp:ListItem>
                        <asp:ListItem>13:00:00</asp:ListItem>
                        <asp:ListItem>14:00:00</asp:ListItem>
                        <asp:ListItem>15:00:00</asp:ListItem>
                        <asp:ListItem>16:00:00</asp:ListItem>
                        <asp:ListItem>17:00:00</asp:ListItem>
                        <asp:ListItem>18:00:00</asp:ListItem>
                        <asp:ListItem>19:00:00</asp:ListItem>
                        <asp:ListItem>20:00:00</asp:ListItem>
                        <asp:ListItem>21:00:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddl3" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem>Select Shift</asp:ListItem>
                        <asp:ListItem>10:00:00</asp:ListItem>
                        <asp:ListItem>11:00:00</asp:ListItem>
                        <asp:ListItem>12:00:00</asp:ListItem>
                        <asp:ListItem>13:00:00</asp:ListItem>
                        <asp:ListItem>14:00:00</asp:ListItem>
                        <asp:ListItem>15:00:00</asp:ListItem>
                        <asp:ListItem>16:00:00</asp:ListItem>
                        <asp:ListItem>17:00:00</asp:ListItem>
                        <asp:ListItem>18:00:00</asp:ListItem>
                        <asp:ListItem>19:00:00</asp:ListItem>
                        <asp:ListItem>20:00:00</asp:ListItem>
                        <asp:ListItem>21:00:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddl4" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem>Select Shift</asp:ListItem>
                        <asp:ListItem>10:00:00</asp:ListItem>
                        <asp:ListItem>11:00:00</asp:ListItem>
                        <asp:ListItem>12:00:00</asp:ListItem>
                        <asp:ListItem>13:00:00</asp:ListItem>
                        <asp:ListItem>14:00:00</asp:ListItem>
                        <asp:ListItem>15:00:00</asp:ListItem>
                        <asp:ListItem>16:00:00</asp:ListItem>
                        <asp:ListItem>17:00:00</asp:ListItem>
                        <asp:ListItem>18:00:00</asp:ListItem>
                        <asp:ListItem>19:00:00</asp:ListItem>
                        <asp:ListItem>20:00:00</asp:ListItem>
                        <asp:ListItem>21:00:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddl5" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem>Select Shift</asp:ListItem>
                        <asp:ListItem>10:00:00</asp:ListItem>
                        <asp:ListItem>11:00:00</asp:ListItem>
                        <asp:ListItem>12:00:00</asp:ListItem>
                        <asp:ListItem>13:00:00</asp:ListItem>
                        <asp:ListItem>14:00:00</asp:ListItem>
                        <asp:ListItem>15:00:00</asp:ListItem>
                        <asp:ListItem>16:00:00</asp:ListItem>
                        <asp:ListItem>17:00:00</asp:ListItem>
                        <asp:ListItem>18:00:00</asp:ListItem>
                        <asp:ListItem>19:00:00</asp:ListItem>
                        <asp:ListItem>20:00:00</asp:ListItem>
                        <asp:ListItem>21:00:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddl6" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem>Select Shift</asp:ListItem>
                        <asp:ListItem>10:00:00</asp:ListItem>
                        <asp:ListItem>11:00:00</asp:ListItem>
                        <asp:ListItem>12:00:00</asp:ListItem>
                        <asp:ListItem>13:00:00</asp:ListItem>
                        <asp:ListItem>14:00:00</asp:ListItem>
                        <asp:ListItem>15:00:00</asp:ListItem>
                        <asp:ListItem>16:00:00</asp:ListItem>
                        <asp:ListItem>17:00:00</asp:ListItem>
                        <asp:ListItem>18:00:00</asp:ListItem>
                        <asp:ListItem>19:00:00</asp:ListItem>
                        <asp:ListItem>20:00:00</asp:ListItem>
                        <asp:ListItem>21:00:00</asp:ListItem>
                        <asp:ListItem>22:00:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="lblMonHour" runat="server"></asp:Label>
                </td>
            </tr>

            <tr>
                <td>Tuesday</td>
                <td>
                    <asp:Label ID="Label2" runat="server" CssClass="text-danger"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddl7" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem>Select Shift</asp:ListItem>
                        <asp:ListItem>10:00:00</asp:ListItem>
                        <asp:ListItem>11:00:00</asp:ListItem>
                        <asp:ListItem>12:00:00</asp:ListItem>
                        <asp:ListItem>13:00:00</asp:ListItem>
                        <asp:ListItem>14:00:00</asp:ListItem>
                        <asp:ListItem>15:00:00</asp:ListItem>
                        <asp:ListItem>16:00:00</asp:ListItem>
                        <asp:ListItem>17:00:00</asp:ListItem>
                        <asp:ListItem>18:00:00</asp:ListItem>
                        <asp:ListItem>19:00:00</asp:ListItem>
                        <asp:ListItem>20:00:00</asp:ListItem>
                        <asp:ListItem>21:00:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddl8" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem>Select Shift</asp:ListItem>
                        <asp:ListItem>10:00:00</asp:ListItem>
                        <asp:ListItem>11:00:00</asp:ListItem>
                        <asp:ListItem>12:00:00</asp:ListItem>
                        <asp:ListItem>13:00:00</asp:ListItem>
                        <asp:ListItem>14:00:00</asp:ListItem>
                        <asp:ListItem>15:00:00</asp:ListItem>
                        <asp:ListItem>16:00:00</asp:ListItem>
                        <asp:ListItem>17:00:00</asp:ListItem>
                        <asp:ListItem>18:00:00</asp:ListItem>
                        <asp:ListItem>19:00:00</asp:ListItem>
                        <asp:ListItem>20:00:00</asp:ListItem>
                        <asp:ListItem>21:00:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddl9" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem>Select Shift</asp:ListItem>
                        <asp:ListItem>10:00:00</asp:ListItem>
                        <asp:ListItem>11:00:00</asp:ListItem>
                        <asp:ListItem>12:00:00</asp:ListItem>
                        <asp:ListItem>13:00:00</asp:ListItem>
                        <asp:ListItem>14:00:00</asp:ListItem>
                        <asp:ListItem>15:00:00</asp:ListItem>
                        <asp:ListItem>16:00:00</asp:ListItem>
                        <asp:ListItem>17:00:00</asp:ListItem>
                        <asp:ListItem>18:00:00</asp:ListItem>
                        <asp:ListItem>19:00:00</asp:ListItem>
                        <asp:ListItem>20:00:00</asp:ListItem>
                        <asp:ListItem>21:00:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddl10" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem>Select Shift</asp:ListItem>
                        <asp:ListItem>10:00:00</asp:ListItem>
                        <asp:ListItem>11:00:00</asp:ListItem>
                        <asp:ListItem>12:00:00</asp:ListItem>
                        <asp:ListItem>13:00:00</asp:ListItem>
                        <asp:ListItem>14:00:00</asp:ListItem>
                        <asp:ListItem>15:00:00</asp:ListItem>
                        <asp:ListItem>16:00:00</asp:ListItem>
                        <asp:ListItem>17:00:00</asp:ListItem>
                        <asp:ListItem>18:00:00</asp:ListItem>
                        <asp:ListItem>19:00:00</asp:ListItem>
                        <asp:ListItem>20:00:00</asp:ListItem>
                        <asp:ListItem>21:00:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddl11" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem>Select Shift</asp:ListItem>
                        <asp:ListItem>10:00:00</asp:ListItem>
                        <asp:ListItem>11:00:00</asp:ListItem>
                        <asp:ListItem>12:00:00</asp:ListItem>
                        <asp:ListItem>13:00:00</asp:ListItem>
                        <asp:ListItem>14:00:00</asp:ListItem>
                        <asp:ListItem>15:00:00</asp:ListItem>
                        <asp:ListItem>16:00:00</asp:ListItem>
                        <asp:ListItem>17:00:00</asp:ListItem>
                        <asp:ListItem>18:00:00</asp:ListItem>
                        <asp:ListItem>19:00:00</asp:ListItem>
                        <asp:ListItem>20:00:00</asp:ListItem>
                        <asp:ListItem>21:00:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddl12" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem>Select Shift</asp:ListItem>
                        <asp:ListItem>10:00:00</asp:ListItem>
                        <asp:ListItem>11:00:00</asp:ListItem>
                        <asp:ListItem>12:00:00</asp:ListItem>
                        <asp:ListItem>13:00:00</asp:ListItem>
                        <asp:ListItem>14:00:00</asp:ListItem>
                        <asp:ListItem>15:00:00</asp:ListItem>
                        <asp:ListItem>16:00:00</asp:ListItem>
                        <asp:ListItem>17:00:00</asp:ListItem>
                        <asp:ListItem>18:00:00</asp:ListItem>
                        <asp:ListItem>19:00:00</asp:ListItem>
                        <asp:ListItem>20:00:00</asp:ListItem>
                        <asp:ListItem>21:00:00</asp:ListItem>
                        <asp:ListItem>22:00:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="lblTuesHour" runat="server"></asp:Label>
                </td>
            </tr>

            <tr>
                <td>Wednesday</td>
                <td>
                    <asp:Label ID="Label3" runat="server" CssClass="text-danger"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddl13" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem>Select Shift</asp:ListItem>
                        <asp:ListItem>10:00:00</asp:ListItem>
                        <asp:ListItem>11:00:00</asp:ListItem>
                        <asp:ListItem>12:00:00</asp:ListItem>
                        <asp:ListItem>13:00:00</asp:ListItem>
                        <asp:ListItem>14:00:00</asp:ListItem>
                        <asp:ListItem>15:00:00</asp:ListItem>
                        <asp:ListItem>16:00:00</asp:ListItem>
                        <asp:ListItem>17:00:00</asp:ListItem>
                        <asp:ListItem>18:00:00</asp:ListItem>
                        <asp:ListItem>19:00:00</asp:ListItem>
                        <asp:ListItem>20:00:00</asp:ListItem>
                        <asp:ListItem>21:00:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddl14" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem>Select Shift</asp:ListItem>
                        <asp:ListItem>10:00:00</asp:ListItem>
                        <asp:ListItem>11:00:00</asp:ListItem>
                        <asp:ListItem>12:00:00</asp:ListItem>
                        <asp:ListItem>13:00:00</asp:ListItem>
                        <asp:ListItem>14:00:00</asp:ListItem>
                        <asp:ListItem>15:00:00</asp:ListItem>
                        <asp:ListItem>16:00:00</asp:ListItem>
                        <asp:ListItem>17:00:00</asp:ListItem>
                        <asp:ListItem>18:00:00</asp:ListItem>
                        <asp:ListItem>19:00:00</asp:ListItem>
                        <asp:ListItem>20:00:00</asp:ListItem>
                        <asp:ListItem>21:00:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddl15" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem>Select Shift</asp:ListItem>
                        <asp:ListItem>10:00:00</asp:ListItem>
                        <asp:ListItem>11:00:00</asp:ListItem>
                        <asp:ListItem>12:00:00</asp:ListItem>
                        <asp:ListItem>13:00:00</asp:ListItem>
                        <asp:ListItem>14:00:00</asp:ListItem>
                        <asp:ListItem>15:00:00</asp:ListItem>
                        <asp:ListItem>16:00:00</asp:ListItem>
                        <asp:ListItem>17:00:00</asp:ListItem>
                        <asp:ListItem>18:00:00</asp:ListItem>
                        <asp:ListItem>19:00:00</asp:ListItem>
                        <asp:ListItem>20:00:00</asp:ListItem>
                        <asp:ListItem>21:00:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddl16" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem>Select Shift</asp:ListItem>
                        <asp:ListItem>10:00:00</asp:ListItem>
                        <asp:ListItem>11:00:00</asp:ListItem>
                        <asp:ListItem>12:00:00</asp:ListItem>
                        <asp:ListItem>13:00:00</asp:ListItem>
                        <asp:ListItem>14:00:00</asp:ListItem>
                        <asp:ListItem>15:00:00</asp:ListItem>
                        <asp:ListItem>16:00:00</asp:ListItem>
                        <asp:ListItem>17:00:00</asp:ListItem>
                        <asp:ListItem>18:00:00</asp:ListItem>
                        <asp:ListItem>19:00:00</asp:ListItem>
                        <asp:ListItem>20:00:00</asp:ListItem>
                        <asp:ListItem>21:00:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddl17" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem>Select Shift</asp:ListItem>
                        <asp:ListItem>10:00:00</asp:ListItem>
                        <asp:ListItem>11:00:00</asp:ListItem>
                        <asp:ListItem>12:00:00</asp:ListItem>
                        <asp:ListItem>13:00:00</asp:ListItem>
                        <asp:ListItem>14:00:00</asp:ListItem>
                        <asp:ListItem>15:00:00</asp:ListItem>
                        <asp:ListItem>16:00:00</asp:ListItem>
                        <asp:ListItem>17:00:00</asp:ListItem>
                        <asp:ListItem>18:00:00</asp:ListItem>
                        <asp:ListItem>19:00:00</asp:ListItem>
                        <asp:ListItem>20:00:00</asp:ListItem>
                        <asp:ListItem>21:00:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddl18" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem>Select Shift</asp:ListItem>
                        <asp:ListItem>10:00:00</asp:ListItem>
                        <asp:ListItem>11:00:00</asp:ListItem>
                        <asp:ListItem>12:00:00</asp:ListItem>
                        <asp:ListItem>13:00:00</asp:ListItem>
                        <asp:ListItem>14:00:00</asp:ListItem>
                        <asp:ListItem>15:00:00</asp:ListItem>
                        <asp:ListItem>16:00:00</asp:ListItem>
                        <asp:ListItem>17:00:00</asp:ListItem>
                        <asp:ListItem>18:00:00</asp:ListItem>
                        <asp:ListItem>19:00:00</asp:ListItem>
                        <asp:ListItem>20:00:00</asp:ListItem>
                        <asp:ListItem>21:00:00</asp:ListItem>
                        <asp:ListItem>22:00:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="lblWedHour" runat="server"></asp:Label>
                </td>
            </tr>

            <tr>
                <td>Thursday</td>
                <td>
                    <asp:Label ID="Label4" runat="server" CssClass="text-danger"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddl19" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem>Select Shift</asp:ListItem>
                        <asp:ListItem>10:00:00</asp:ListItem>
                        <asp:ListItem>11:00:00</asp:ListItem>
                        <asp:ListItem>12:00:00</asp:ListItem>
                        <asp:ListItem>13:00:00</asp:ListItem>
                        <asp:ListItem>14:00:00</asp:ListItem>
                        <asp:ListItem>15:00:00</asp:ListItem>
                        <asp:ListItem>16:00:00</asp:ListItem>
                        <asp:ListItem>17:00:00</asp:ListItem>
                        <asp:ListItem>18:00:00</asp:ListItem>
                        <asp:ListItem>19:00:00</asp:ListItem>
                        <asp:ListItem>20:00:00</asp:ListItem>
                        <asp:ListItem>21:00:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddl20" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem>Select Shift</asp:ListItem>
                        <asp:ListItem>10:00:00</asp:ListItem>
                        <asp:ListItem>11:00:00</asp:ListItem>
                        <asp:ListItem>12:00:00</asp:ListItem>
                        <asp:ListItem>13:00:00</asp:ListItem>
                        <asp:ListItem>14:00:00</asp:ListItem>
                        <asp:ListItem>15:00:00</asp:ListItem>
                        <asp:ListItem>16:00:00</asp:ListItem>
                        <asp:ListItem>17:00:00</asp:ListItem>
                        <asp:ListItem>18:00:00</asp:ListItem>
                        <asp:ListItem>19:00:00</asp:ListItem>
                        <asp:ListItem>20:00:00</asp:ListItem>
                        <asp:ListItem>21:00:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddl21" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem>Select Shift</asp:ListItem>
                        <asp:ListItem>10:00:00</asp:ListItem>
                        <asp:ListItem>11:00:00</asp:ListItem>
                        <asp:ListItem>12:00:00</asp:ListItem>
                        <asp:ListItem>13:00:00</asp:ListItem>
                        <asp:ListItem>14:00:00</asp:ListItem>
                        <asp:ListItem>15:00:00</asp:ListItem>
                        <asp:ListItem>16:00:00</asp:ListItem>
                        <asp:ListItem>17:00:00</asp:ListItem>
                        <asp:ListItem>18:00:00</asp:ListItem>
                        <asp:ListItem>19:00:00</asp:ListItem>
                        <asp:ListItem>20:00:00</asp:ListItem>
                        <asp:ListItem>21:00:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddl22" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem>Select Shift</asp:ListItem>
                        <asp:ListItem>10:00:00</asp:ListItem>
                        <asp:ListItem>11:00:00</asp:ListItem>
                        <asp:ListItem>12:00:00</asp:ListItem>
                        <asp:ListItem>13:00:00</asp:ListItem>
                        <asp:ListItem>14:00:00</asp:ListItem>
                        <asp:ListItem>15:00:00</asp:ListItem>
                        <asp:ListItem>16:00:00</asp:ListItem>
                        <asp:ListItem>17:00:00</asp:ListItem>
                        <asp:ListItem>18:00:00</asp:ListItem>
                        <asp:ListItem>19:00:00</asp:ListItem>
                        <asp:ListItem>20:00:00</asp:ListItem>
                        <asp:ListItem>21:00:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddl23" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem>Select Shift</asp:ListItem>
                        <asp:ListItem>10:00:00</asp:ListItem>
                        <asp:ListItem>11:00:00</asp:ListItem>
                        <asp:ListItem>12:00:00</asp:ListItem>
                        <asp:ListItem>13:00:00</asp:ListItem>
                        <asp:ListItem>14:00:00</asp:ListItem>
                        <asp:ListItem>15:00:00</asp:ListItem>
                        <asp:ListItem>16:00:00</asp:ListItem>
                        <asp:ListItem>17:00:00</asp:ListItem>
                        <asp:ListItem>18:00:00</asp:ListItem>
                        <asp:ListItem>19:00:00</asp:ListItem>
                        <asp:ListItem>20:00:00</asp:ListItem>
                        <asp:ListItem>21:00:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddl24" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem>Select Shift</asp:ListItem>
                        <asp:ListItem>10:00:00</asp:ListItem>
                        <asp:ListItem>11:00:00</asp:ListItem>
                        <asp:ListItem>12:00:00</asp:ListItem>
                        <asp:ListItem>13:00:00</asp:ListItem>
                        <asp:ListItem>14:00:00</asp:ListItem>
                        <asp:ListItem>15:00:00</asp:ListItem>
                        <asp:ListItem>16:00:00</asp:ListItem>
                        <asp:ListItem>17:00:00</asp:ListItem>
                        <asp:ListItem>18:00:00</asp:ListItem>
                        <asp:ListItem>19:00:00</asp:ListItem>
                        <asp:ListItem>20:00:00</asp:ListItem>
                        <asp:ListItem>21:00:00</asp:ListItem>
                        <asp:ListItem>22:00:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="lblThursHour" runat="server"></asp:Label>
                </td>
            </tr>

            <tr>
                <td>Friday</td>
                <td>
                    <asp:Label ID="Label5" runat="server" CssClass="text-danger"></asp:Label>
                </td>
                <td class="auto-style7">
                    <asp:DropDownList ID="ddl25" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem>Select Shift</asp:ListItem>
                        <asp:ListItem>10:00:00</asp:ListItem>
                        <asp:ListItem>11:00:00</asp:ListItem>
                        <asp:ListItem>12:00:00</asp:ListItem>
                        <asp:ListItem>13:00:00</asp:ListItem>
                        <asp:ListItem>14:00:00</asp:ListItem>
                        <asp:ListItem>15:00:00</asp:ListItem>
                        <asp:ListItem>16:00:00</asp:ListItem>
                        <asp:ListItem>17:00:00</asp:ListItem>
                        <asp:ListItem>18:00:00</asp:ListItem>
                        <asp:ListItem>19:00:00</asp:ListItem>
                        <asp:ListItem>20:00:00</asp:ListItem>
                        <asp:ListItem>21:00:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddl26" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem>Select Shift</asp:ListItem>
                        <asp:ListItem>10:00:00</asp:ListItem>
                        <asp:ListItem>11:00:00</asp:ListItem>
                        <asp:ListItem>12:00:00</asp:ListItem>
                        <asp:ListItem>13:00:00</asp:ListItem>
                        <asp:ListItem>14:00:00</asp:ListItem>
                        <asp:ListItem>15:00:00</asp:ListItem>
                        <asp:ListItem>16:00:00</asp:ListItem>
                        <asp:ListItem>17:00:00</asp:ListItem>
                        <asp:ListItem>18:00:00</asp:ListItem>
                        <asp:ListItem>19:00:00</asp:ListItem>
                        <asp:ListItem>20:00:00</asp:ListItem>
                        <asp:ListItem>21:00:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddl27" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem>Select Shift</asp:ListItem>
                        <asp:ListItem>10:00:00</asp:ListItem>
                        <asp:ListItem>11:00:00</asp:ListItem>
                        <asp:ListItem>12:00:00</asp:ListItem>
                        <asp:ListItem>13:00:00</asp:ListItem>
                        <asp:ListItem>14:00:00</asp:ListItem>
                        <asp:ListItem>15:00:00</asp:ListItem>
                        <asp:ListItem>16:00:00</asp:ListItem>
                        <asp:ListItem>17:00:00</asp:ListItem>
                        <asp:ListItem>18:00:00</asp:ListItem>
                        <asp:ListItem>19:00:00</asp:ListItem>
                        <asp:ListItem>20:00:00</asp:ListItem>
                        <asp:ListItem>21:00:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddl28" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem>Select Shift</asp:ListItem>
                        <asp:ListItem>10:00:00</asp:ListItem>
                        <asp:ListItem>11:00:00</asp:ListItem>
                        <asp:ListItem>12:00:00</asp:ListItem>
                        <asp:ListItem>13:00:00</asp:ListItem>
                        <asp:ListItem>14:00:00</asp:ListItem>
                        <asp:ListItem>15:00:00</asp:ListItem>
                        <asp:ListItem>16:00:00</asp:ListItem>
                        <asp:ListItem>17:00:00</asp:ListItem>
                        <asp:ListItem>18:00:00</asp:ListItem>
                        <asp:ListItem>19:00:00</asp:ListItem>
                        <asp:ListItem>20:00:00</asp:ListItem>
                        <asp:ListItem>21:00:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddl29" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem>Select Shift</asp:ListItem>
                        <asp:ListItem>10:00:00</asp:ListItem>
                        <asp:ListItem>11:00:00</asp:ListItem>
                        <asp:ListItem>12:00:00</asp:ListItem>
                        <asp:ListItem>13:00:00</asp:ListItem>
                        <asp:ListItem>14:00:00</asp:ListItem>
                        <asp:ListItem>15:00:00</asp:ListItem>
                        <asp:ListItem>16:00:00</asp:ListItem>
                        <asp:ListItem>17:00:00</asp:ListItem>
                        <asp:ListItem>18:00:00</asp:ListItem>
                        <asp:ListItem>19:00:00</asp:ListItem>
                        <asp:ListItem>20:00:00</asp:ListItem>
                        <asp:ListItem>21:00:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddl30" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem>Select Shift</asp:ListItem>
                        <asp:ListItem>10:00:00</asp:ListItem>
                        <asp:ListItem>11:00:00</asp:ListItem>
                        <asp:ListItem>12:00:00</asp:ListItem>
                        <asp:ListItem>13:00:00</asp:ListItem>
                        <asp:ListItem>14:00:00</asp:ListItem>
                        <asp:ListItem>15:00:00</asp:ListItem>
                        <asp:ListItem>16:00:00</asp:ListItem>
                        <asp:ListItem>17:00:00</asp:ListItem>
                        <asp:ListItem>18:00:00</asp:ListItem>
                        <asp:ListItem>19:00:00</asp:ListItem>
                        <asp:ListItem>20:00:00</asp:ListItem>
                        <asp:ListItem>21:00:00</asp:ListItem>
                        <asp:ListItem>22:00:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="lblFriHour" runat="server"></asp:Label>
                </td>
            </tr>

            <tr>
                <td>Saturday</td>
                <td>
                    <asp:Label ID="Label6" runat="server" CssClass="text-danger"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddl31" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem>Select Shift</asp:ListItem>
                        <asp:ListItem>10:00:00</asp:ListItem>
                        <asp:ListItem>11:00:00</asp:ListItem>
                        <asp:ListItem>12:00:00</asp:ListItem>
                        <asp:ListItem>13:00:00</asp:ListItem>
                        <asp:ListItem>14:00:00</asp:ListItem>
                        <asp:ListItem>15:00:00</asp:ListItem>
                        <asp:ListItem>16:00:00</asp:ListItem>
                        <asp:ListItem>17:00:00</asp:ListItem>
                        <asp:ListItem>18:00:00</asp:ListItem>
                        <asp:ListItem>19:00:00</asp:ListItem>
                        <asp:ListItem>20:00:00</asp:ListItem>
                        <asp:ListItem>21:00:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddl32" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem>Select Shift</asp:ListItem>
                        <asp:ListItem>10:00:00</asp:ListItem>
                        <asp:ListItem>11:00:00</asp:ListItem>
                        <asp:ListItem>12:00:00</asp:ListItem>
                        <asp:ListItem>13:00:00</asp:ListItem>
                        <asp:ListItem>14:00:00</asp:ListItem>
                        <asp:ListItem>15:00:00</asp:ListItem>
                        <asp:ListItem>16:00:00</asp:ListItem>
                        <asp:ListItem>17:00:00</asp:ListItem>
                        <asp:ListItem>18:00:00</asp:ListItem>
                        <asp:ListItem>19:00:00</asp:ListItem>
                        <asp:ListItem>20:00:00</asp:ListItem>
                        <asp:ListItem>21:00:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddl33" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem>Select Shift</asp:ListItem>
                        <asp:ListItem>10:00:00</asp:ListItem>
                        <asp:ListItem>11:00:00</asp:ListItem>
                        <asp:ListItem>12:00:00</asp:ListItem>
                        <asp:ListItem>13:00:00</asp:ListItem>
                        <asp:ListItem>14:00:00</asp:ListItem>
                        <asp:ListItem>15:00:00</asp:ListItem>
                        <asp:ListItem>16:00:00</asp:ListItem>
                        <asp:ListItem>17:00:00</asp:ListItem>
                        <asp:ListItem>18:00:00</asp:ListItem>
                        <asp:ListItem>19:00:00</asp:ListItem>
                        <asp:ListItem>20:00:00</asp:ListItem>
                        <asp:ListItem>21:00:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddl34" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem>Select Shift</asp:ListItem>
                        <asp:ListItem>10:00:00</asp:ListItem>
                        <asp:ListItem>11:00:00</asp:ListItem>
                        <asp:ListItem>12:00:00</asp:ListItem>
                        <asp:ListItem>13:00:00</asp:ListItem>
                        <asp:ListItem>14:00:00</asp:ListItem>
                        <asp:ListItem>15:00:00</asp:ListItem>
                        <asp:ListItem>16:00:00</asp:ListItem>
                        <asp:ListItem>17:00:00</asp:ListItem>
                        <asp:ListItem>18:00:00</asp:ListItem>
                        <asp:ListItem>19:00:00</asp:ListItem>
                        <asp:ListItem>20:00:00</asp:ListItem>
                        <asp:ListItem>21:00:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddl35" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem>Select Shift</asp:ListItem>
                        <asp:ListItem>10:00:00</asp:ListItem>
                        <asp:ListItem>11:00:00</asp:ListItem>
                        <asp:ListItem>12:00:00</asp:ListItem>
                        <asp:ListItem>13:00:00</asp:ListItem>
                        <asp:ListItem>14:00:00</asp:ListItem>
                        <asp:ListItem>15:00:00</asp:ListItem>
                        <asp:ListItem>16:00:00</asp:ListItem>
                        <asp:ListItem>17:00:00</asp:ListItem>
                        <asp:ListItem>18:00:00</asp:ListItem>
                        <asp:ListItem>19:00:00</asp:ListItem>
                        <asp:ListItem>20:00:00</asp:ListItem>
                        <asp:ListItem>21:00:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddl36" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem>Select Shift</asp:ListItem>
                        <asp:ListItem>10:00:00</asp:ListItem>
                        <asp:ListItem>11:00:00</asp:ListItem>
                        <asp:ListItem>12:00:00</asp:ListItem>
                        <asp:ListItem>13:00:00</asp:ListItem>
                        <asp:ListItem>14:00:00</asp:ListItem>
                        <asp:ListItem>15:00:00</asp:ListItem>
                        <asp:ListItem>16:00:00</asp:ListItem>
                        <asp:ListItem>17:00:00</asp:ListItem>
                        <asp:ListItem>18:00:00</asp:ListItem>
                        <asp:ListItem>19:00:00</asp:ListItem>
                        <asp:ListItem>20:00:00</asp:ListItem>
                        <asp:ListItem>21:00:00</asp:ListItem>
                        <asp:ListItem>22:00:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="lblSatHour" runat="server"></asp:Label>
                </td>
            </tr>

            <tr>
                <td>Sunday</td>
                <td>
                    <asp:Label ID="Label7" runat="server" CssClass="text-danger"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddl37" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem>Select Shift</asp:ListItem>
                        <asp:ListItem>10:00:00</asp:ListItem>
                        <asp:ListItem>11:00:00</asp:ListItem>
                        <asp:ListItem>12:00:00</asp:ListItem>
                        <asp:ListItem>13:00:00</asp:ListItem>
                        <asp:ListItem>14:00:00</asp:ListItem>
                        <asp:ListItem>15:00:00</asp:ListItem>
                        <asp:ListItem>16:00:00</asp:ListItem>
                        <asp:ListItem>17:00:00</asp:ListItem>
                        <asp:ListItem>18:00:00</asp:ListItem>
                        <asp:ListItem>19:00:00</asp:ListItem>
                        <asp:ListItem>20:00:00</asp:ListItem>
                        <asp:ListItem>21:00:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddl38" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem>Select Shift</asp:ListItem>
                        <asp:ListItem>10:00:00</asp:ListItem>
                        <asp:ListItem>11:00:00</asp:ListItem>
                        <asp:ListItem>12:00:00</asp:ListItem>
                        <asp:ListItem>13:00:00</asp:ListItem>
                        <asp:ListItem>14:00:00</asp:ListItem>
                        <asp:ListItem>15:00:00</asp:ListItem>
                        <asp:ListItem>16:00:00</asp:ListItem>
                        <asp:ListItem>17:00:00</asp:ListItem>
                        <asp:ListItem>18:00:00</asp:ListItem>
                        <asp:ListItem>19:00:00</asp:ListItem>
                        <asp:ListItem>20:00:00</asp:ListItem>
                        <asp:ListItem>21:00:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddl39" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem>Select Shift</asp:ListItem>
                        <asp:ListItem>10:00:00</asp:ListItem>
                        <asp:ListItem>11:00:00</asp:ListItem>
                        <asp:ListItem>12:00:00</asp:ListItem>
                        <asp:ListItem>13:00:00</asp:ListItem>
                        <asp:ListItem>14:00:00</asp:ListItem>
                        <asp:ListItem>15:00:00</asp:ListItem>
                        <asp:ListItem>16:00:00</asp:ListItem>
                        <asp:ListItem>17:00:00</asp:ListItem>
                        <asp:ListItem>18:00:00</asp:ListItem>
                        <asp:ListItem>19:00:00</asp:ListItem>
                        <asp:ListItem>20:00:00</asp:ListItem>
                        <asp:ListItem>21:00:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddl40" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem>Select Shift</asp:ListItem>
                        <asp:ListItem>10:00:00</asp:ListItem>
                        <asp:ListItem>11:00:00</asp:ListItem>
                        <asp:ListItem>12:00:00</asp:ListItem>
                        <asp:ListItem>13:00:00</asp:ListItem>
                        <asp:ListItem>14:00:00</asp:ListItem>
                        <asp:ListItem>15:00:00</asp:ListItem>
                        <asp:ListItem>16:00:00</asp:ListItem>
                        <asp:ListItem>17:00:00</asp:ListItem>
                        <asp:ListItem>18:00:00</asp:ListItem>
                        <asp:ListItem>19:00:00</asp:ListItem>
                        <asp:ListItem>20:00:00</asp:ListItem>
                        <asp:ListItem>21:00:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddl41" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem>Select Shift</asp:ListItem>
                        <asp:ListItem>10:00:00</asp:ListItem>
                        <asp:ListItem>11:00:00</asp:ListItem>
                        <asp:ListItem>12:00:00</asp:ListItem>
                        <asp:ListItem>13:00:00</asp:ListItem>
                        <asp:ListItem>14:00:00</asp:ListItem>
                        <asp:ListItem>15:00:00</asp:ListItem>
                        <asp:ListItem>16:00:00</asp:ListItem>
                        <asp:ListItem>17:00:00</asp:ListItem>
                        <asp:ListItem>18:00:00</asp:ListItem>
                        <asp:ListItem>19:00:00</asp:ListItem>
                        <asp:ListItem>20:00:00</asp:ListItem>
                        <asp:ListItem>21:00:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddl42" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem>Select Shift</asp:ListItem>
                        <asp:ListItem>10:00:00</asp:ListItem>
                        <asp:ListItem>11:00:00</asp:ListItem>
                        <asp:ListItem>12:00:00</asp:ListItem>
                        <asp:ListItem>13:00:00</asp:ListItem>
                        <asp:ListItem>14:00:00</asp:ListItem>
                        <asp:ListItem>15:00:00</asp:ListItem>
                        <asp:ListItem>16:00:00</asp:ListItem>
                        <asp:ListItem>17:00:00</asp:ListItem>
                        <asp:ListItem>18:00:00</asp:ListItem>
                        <asp:ListItem>19:00:00</asp:ListItem>
                        <asp:ListItem>20:00:00</asp:ListItem>
                        <asp:ListItem>21:00:00</asp:ListItem>
                        <asp:ListItem>22:00:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="lblSunHour" runat="server"></asp:Label>
                </td>
            </tr>
        </table>

        <div class="mt-2">
            <asp:Button ID="btn_calculateHours" runat="server" CssClass="btn btn-dark" OnClick="btn_calculateHours_Click" Text="Calculate Hours" />
        </div>

        <div class="row">
            <div class="col">
                <div class="form-group">
                    Total Hours
                    <asp:TextBox ID="txtTotalHour" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>
            </div>

            <div class="col">
                <div class="form-group">
                    Start Date
                    <asp:TextBox ID="txtStartDate" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>
            </div>

            <div class="col">
                <div class="form-group">
                    End Date
                    <asp:TextBox ID="txtEndDate" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="form-group">
            Remarks
            <asp:TextBox ID="txtStartUp" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="mt-1">
            <asp:Button ID="btn_submit" runat="server" OnClick="btn_submit_Click" CssClass="btn btn-dark" Text="Submit" />
        </div>

        <div class="mt-1">
            <strong><asp:Label ID="lblHourError" runat="server" CssClass="text-danger"></asp:Label></strong>
            <strong><asp:Label ID="lblSuccess" runat="server" CssClass="text-success"></asp:Label></strong>
        </div>       
    </div>
    <div class="col-md-1"></div>
</asp:Content>
