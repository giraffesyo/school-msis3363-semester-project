<%@ Page Title="" Language="C#" MasterPageFile="~/CTS.Master" AutoEventWireup="true" CodeBehind="clients.aspx.cs" Inherits="SemesterProject.clients" %>

<asp:Content ContentPlaceHolderID="BodyPlaceholder" runat="server">
    <div class="middleOfPage">
        <div class="login">
            <img src="images/logo.png" alt="CTS Logo" />
            <asp:TextBox CssClass="m-2 p-2" ID="tbUsername" runat="server" placeholder="User Name"></asp:TextBox>
            <asp:TextBox CssClass="m-2 p-2" ID="tbPassword" runat="server" placeholder="Password"></asp:TextBox>
            <div>

                <asp:LinkButton ID="lbRegister" runat="server" OnClick="lbRegister_Click">Not signed up? Register</asp:LinkButton>
                <asp:Button CssClass="btn btn-success m-2 p-2" ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            </div>
        </div>
    </div>
</asp:Content>
