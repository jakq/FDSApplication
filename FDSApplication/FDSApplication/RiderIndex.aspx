<%@ Page Title="" Language="C#" MasterPageFile="~/RiderSite.Master" AutoEventWireup="true" CodeBehind="RiderIndex.aspx.cs" Inherits="FDSApplication.RiderIndex" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-2"></div>
    <div class="col-md-8 mt-3">
        <h3 class="text-center">Welcome to FDS Application</h3>
        <p class="text-center">YOU ARE LOGGED IN AS
            <asp:Label ID="lblUserName" runat="server" Text=""></asp:Label>
        </p>
        <p class="text-center">WITH <asp:Label ID="lblUserRole" runat="server" Text=""></asp:Label> RIGHTS</p>
                
        <hr />

        <div class="card text-white bg-dark mb-3">
            <div class="card-header">Your Current Rating</div>
            <div class="card-body">
                <h3>
                    <asp:Label ID="lblRating" runat="server" Text=""></asp:Label>
                </h3>
            </div>
        </div>


        <div class="row">
            <div class="col">
                <div class="card text-white bg-dark mb-3">
                    <div class="card-header">Number of Available Orders</div>
                    <div class="card-body">
                        <h3>
                            <asp:Label ID="lblTotalAvailOrders" runat="server" Text=""></asp:Label>
                        </h3>
                    </div>
                </div>
            </div>

            <div class="col">
                <div class="card text-white bg-dark mb-3">
                    <div class="card-header">Number of Orders You Did</div>
                    <div class="card-body">
                        <h3>
                            <asp:Label ID="lblOrdersDone" runat="server" Text=""></asp:Label>
                        </h3>
                    </div>
                </div>
            </div>
        </div>

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

        <div class="mt-1">
            <asp:Button ID="btnViewMthStats" runat="server" Text="View Monthly Statistics" CssClass="btn btn-dark btn-block" OnClick="btnViewMthStats_Click"/>
        </div>
    </div>
    <div class="col-md-2"></div>
</asp:Content>
