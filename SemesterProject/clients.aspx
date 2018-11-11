<%@ Page Title="" Language="C#" MasterPageFile="~/CTS.Master" AutoEventWireup="true" CodeBehind="clients.aspx.cs" Inherits="SemesterProject.clients" %>

<asp:Content ContentPlaceHolderID="BodyPlaceholder" runat="server">
    <div class="row">
        <div class="col">
            <h1>Welcome to the client center.</h1>
        </div>
    </div>
    <div class="row justify-content-center">
        <div class="col-6 col-md-3 m-2">
            <img src="https://via.placeholder.com/400x200" alt="placeholder" />
        </div>
        <div class="col-6 col-md-3 m-2">
            <img src="https://via.placeholder.com/400x200" alt="placeholder" />
        </div>
        <div class="col-6 col-md-3 m-2">
            <img src="https://via.placeholder.com/400x200" alt="placeholder" />
        </div>
        <div class="col-6 col-md-3 m-2">
            <img src="https://via.placeholder.com/400x200" alt="placeholder" />
        </div>
        <div class="col-6 col-md-3 m-2">
            <img src="https://via.placeholder.com/400x200" alt="placeholder" />
        </div>
        <div class="col-6 col-md-3 m-2">
            <img src="https://via.placeholder.com/400x200" alt="placeholder" />
        </div>
    </div>
</asp:Content>
<asp:Content ContentPlaceHolderID="NavPlaceholder" runat="server">
    <!-- Classless div because this is a flex space-between, and we should only have one item at the top level to maintain the styling -->
    <div>
    <asp:LinkButton ID="lbPreferences" OnClick="lbPreferences_Click" CssClass="mr-5" runat="server"><i class="fa fa-wrench" aria-hidden="true"></i><span class="sr-only">Preferences</span></asp:LinkButton>
    <asp:LinkButton ID="lbLogout" runat="server" OnClick="lbLogout_Click">Logout</asp:LinkButton></div>
</asp:Content>