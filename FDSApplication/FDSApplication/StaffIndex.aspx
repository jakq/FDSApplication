<%@ Page Title="" Language="C#" MasterPageFile="~/StaffSite.Master" AutoEventWireup="true" CodeBehind="StaffIndex.aspx.cs" Inherits="FDSApplication.StaffIndex" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-2"></div>
    <div class="col-md-8 mt-3">
        <h3 class="text-center">Welcome to FDS Staff Application</h3>
        <p class="text-center">YOU ARE LOGGED IN AS <asp:Label ID="lblUserName" runat="server" Text=""></asp:Label> </p>
        <p class="text-center">WITH <asp:Label ID="lblUserRole" runat="server" Text=""></asp:Label> RIGHTS</p>

        <hr />

        <asp:Panel ID="panelResetLimit" runat="server" CssClass="mt-2">
            <asp:Label ID="lblResetSuccess" runat="server" Text="" CssClass="mt-1 font-weight-bold text-success"></asp:Label>
            <asp:Label ID="lblResetFailed" runat="server" Text="" CssClass="mt-1 font-weight-bold text-danger"></asp:Label>

            <div class="form-group mt-1">
                Last Reset:
                <asp:TextBox ID="txtLastUpdate" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>

            <asp:Button ID="btnResetLimit" runat="server" Text="Reset Daily Limit" CssClass="btn btn-outline-dark btn-block" OnClick="btnResetLimit_Click" />     
        </asp:Panel>

        <div class="mt-3">
            <asp:Button ID="btnViewStats" runat="server" Text="View Statistics" CssClass="btn btn-dark btn-block" OnClick="btnViewStats_Click" />   
        </div>

        <asp:Panel ID="adminViewStats" runat="server" CssClass="mt-2">
            <div class="row">
                <div class="col">
                    <div class="card text-white bg-dark mb-3">
                        <div class="card-header">Number of Customers</div>
                        <div class="card-body">
                            <h3>
                                <asp:Label ID="lblTotalCustomers" runat="server" Text=""></asp:Label>
                            </h3>
                        </div>
                    </div>
                </div>

                <div class="col">
                    <div class="card text-white bg-dark mb-3">
                        <div class="card-header">Number of Riders</div>
                        <div class="card-body">
                            <h3>
                                <asp:Label ID="lblTotalRiders" runat="server" Text=""></asp:Label>
                            </h3>
                        </div>
                    </div>
                </div>

                <div class="col">
                    <div class="card text-white bg-dark mb-3">
                        <div class="card-header">Number of Staff</div>
                        <div class="card-body">
                            <h3>
                                <asp:Label ID="lblTotalStaff" runat="server" Text=""></asp:Label>
                            </h3>
                        </div>
                    </div>
                </div>
            </div>

            <div class="mt-2">
                <h5>Number of Food Items By Category</h5>
            </div>

            <asp:GridView ID="gv_FoodItemStats" runat="server" CssClass="mt-1 table table-bordered table-dark" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="foodcategory" HeaderText="Category" />
                    <asp:BoundField DataField="number" HeaderText="Total" />
                </Columns>
            </asp:GridView>

            <div class="mt-1 row">
                <div class="col">
                    <div class="card text-white bg-dark mb-3">
                        <div class="card-header">Total Number of Orders</div>
                        <div class="card-body">
                            <h3>
                                <asp:Label ID="lbltotalOrders" runat="server" Text=""></asp:Label>
                            </h3>
                        </div>
                    </div>
                </div>

                <div class="col">
                    <div class="card text-white bg-dark mb-3">
                        <div class="card-header">Total Amount from All Orders</div>
                        <div class="card-body">
                            <h3>
                                <asp:Label ID="lbltotalOrderAmt" runat="server" Text=""></asp:Label>
                            </h3>
                        </div>
                    </div>
                </div>
            </div>

            <div class="mt-2">
                <h5>Top 5 Customers with the Most Orders</h5>
            </div>

            <asp:GridView ID="gv_CustMostOrder" runat="server" CssClass="mt-1 table table-bordered table-dark" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="cname" HeaderText="Customer Name" />
                    <asp:BoundField DataField="number" HeaderText="Total" />
                </Columns>
            </asp:GridView>
        </asp:Panel>

        <asp:Panel ID="staffViewStats" runat="server" CssClass="mt-2">
            <div class="row">
                <div class="col">
                    <div class="card text-white bg-dark mb-3">
                        <div class="card-header">Number of Food Items</div>
                        <div class="card-body">
                            <h3>
                                <asp:Label ID="lblFoodItemNum" runat="server" Text=""></asp:Label>
                            </h3>
                        </div>
                    </div>
                </div>

                <div class="col">
                    <div class="card text-white bg-dark mb-3">
                        <div class="card-header">Number of Reviews</div>
                        <div class="card-body">
                            <h3>
                                <asp:Label ID="lblTotalReview" runat="server" Text=""></asp:Label>
                            </h3>
                        </div>
                    </div>
                </div>
            </div>

            <div class="mt-2">
                <h5>Top 5 Popular Food Items Today</h5>
            </div>

            <asp:GridView ID="gv_popularFoodItems" runat="server" CssClass="mt-1 table table-bordered table-dark" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="foodtitle" HeaderText="Food Item" />
                    <asp:BoundField DataField="ordercounter" HeaderText="Total" />
                </Columns>
            </asp:GridView>
        </asp:Panel>
    </div>

    <div class="col-md-2"></div>
</asp:Content>
