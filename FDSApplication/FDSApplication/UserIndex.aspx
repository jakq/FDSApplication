<%@ Page Title="" Language="C#" MasterPageFile="~/UserSite.Master" AutoEventWireup="true" CodeBehind="UserIndex.aspx.cs" Inherits="FDSApplication.UserIndex" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-2"></div>
    <div class="col-md-8 mt-3">
        <h3 class="text-center">Welcome to FDS Application</h3>
        <p class="text-center">YOU ARE LOGGED IN AS <asp:Label ID="lblUserName" runat="server" Text=""></asp:Label> </p>

        <hr />

        <div class="card text-white bg-dark mb-3">
            <div class="card-header">Recent Location</div>
            <div class="card-body">
                <h4>
                    <asp:Label ID="lblRecentLocation" runat="server" Text=""></asp:Label>
                </h4>
            </div>
        </div>

        <asp:Button ID="btnClearHistory" runat="server" Text="Clear Recent Location History" CssClass="btn btn-outline-dark btn-block" OnClick="btnClearHistory_Click" />

        <div class="mt-2 row">
            <div class="col">
                <div class="card text-white bg-dark mb-3">
                    <div class="card-header">Number of Orders Made</div>
                    <div class="card-body">
                        <h3>
                            <asp:Label ID="lblOrdersMade" runat="server" Text=""></asp:Label>
                        </h3>
                    </div>
                </div>
            </div>

            <div class="col">
                <div class="card text-white bg-dark mb-3">
                    <div class="card-header">Number of Reviews Made</div>
                    <div class="card-body">
                        <h3>
                            <asp:Label ID="lblReviewsMade" runat="server" Text=""></asp:Label>
                        </h3>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="col-md-2"></div>
</asp:Content>
