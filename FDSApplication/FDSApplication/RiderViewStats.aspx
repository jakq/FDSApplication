<%@ Page Title="" Language="C#" MasterPageFile="~/RiderSite.Master" AutoEventWireup="true" CodeBehind="RiderViewStats.aspx.cs" Inherits="FDSApplication.RiderViewStats" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-2"></div>
    <div class="col-md-8 mt-3">
        <h3>Rider Statistics</h3>

        <p>You can view your monthly statistics over here</p>

        <div class="row">
            <div class="col">
                <div class="form-group">
                    Select Month:
                    <asp:DropDownList ID="ddlMonth" runat="server" CssClass="form-control">
                        <asp:ListItem Value="1">Jan</asp:ListItem>
                        <asp:ListItem Value="2">Feb</asp:ListItem>
                        <asp:ListItem Value="3">Mar</asp:ListItem>
                        <asp:ListItem Value="4">Apr</asp:ListItem>
                        <asp:ListItem Value="5">May</asp:ListItem>
                        <asp:ListItem Value="6">Jun</asp:ListItem>
                        <asp:ListItem Value="7">Jul</asp:ListItem>
                        <asp:ListItem Value="8">Aug</asp:ListItem>
                        <asp:ListItem Value="9">Sep</asp:ListItem>
                        <asp:ListItem Value="10">Oct</asp:ListItem>
                        <asp:ListItem Value="11">Nov</asp:ListItem>
                        <asp:ListItem Value="12">Dec</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <div class="col">
                <div class="form-group">
                    Select Year:
                    <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control">
                        <asp:ListItem>2019</asp:ListItem>
                        <asp:ListItem>2020</asp:ListItem>
                        <asp:ListItem>2021</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>

        <asp:Button ID="btnRetrieve" runat="server" Text="Retrieve" CssClass="btn btn-dark btn-block" OnClick="btnRetrieve_Click"/>

        <asp:Panel ID="panelViewStats" runat="server" CssClass="mt-2">
            <div class="row">
                <div class="col">
                    <div class="card text-white bg-dark mb-3">
                        <div class="card-header">Orders Delivered</div>
                        <div class="card-body">
                            <h4>
                                <asp:Label ID="lblOrders" runat="server" Text=""></asp:Label>
                            </h4>
                        </div>
                    </div>
                </div>

                <div class="col">
                    <div class="card text-white bg-dark mb-3">
                        <div class="card-header">Hours Worked</div>
                        <div class="card-body">
                            <h4>
                                <asp:Label ID="lblHours" runat="server" Text=""></asp:Label>
                            </h4>
                        </div>
                    </div>
                </div>
            </div>

            <div class="card text-white bg-dark mb-3">
                <div class="card-header">Average Delivery Time (hh:mm:ss)</div>
                <div class="card-body">
                    <h4>
                        <asp:Label ID="lblDeliverTime" runat="server" Text=""></asp:Label>
                    </h4>
                </div>
            </div>

            <div class="card text-white bg-dark mb-3">
                <div class="card-header">Salary Earning</div>
                <div class="card-body">
                    <h4>
                        <asp:Label ID="lblSalary" runat="server" Text=""></asp:Label>
                    </h4>
                </div>
            </div>

            <div class="row">
                <div class="col">
                    <div class="card text-white bg-dark mb-3">
                        <div class="card-header">Number of Ratings</div>
                        <div class="card-body">
                            <h4>
                                <asp:Label ID="lblReviewNum" runat="server" Text=""></asp:Label>
                            </h4>
                        </div>
                    </div>
                </div>

                <div class="col">
                    <div class="card text-white bg-dark mb-3">
                        <div class="card-header">Average Rating</div>
                        <div class="card-body">
                            <h4>
                                <asp:Label ID="lblRating" runat="server" Text=""></asp:Label>
                            </h4>
                        </div>
                    </div>
                </div>
            </div>

            <div class="mt-1">
                <asp:Button ID="Close" runat="server" Text="Close"  CssClass="btn btn-dark btn-block" OnClick="Close_Click"/>
            </div>
        </asp:Panel>
    </div>
    <div class="col-md-2"></div>
</asp:Content>
