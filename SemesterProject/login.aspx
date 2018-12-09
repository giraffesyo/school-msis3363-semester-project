<%@ Page Title="CTS - Login" Language="C#" MasterPageFile="~/CTS.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="SemesterProject.login" %>

<asp:Content ContentPlaceHolderID="BodyPlaceholder" runat="server">
    <div class="middleOfPage">
        <div class="login">
            <img src="images/logo.png" alt="CTS Logo" />
            <div class="alert alert-danger" visible="false" id="loginAlert" runat="server"></div>
            <asp:Label CssClass="w-100" ID="loginMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
            <asp:TextBox CssClass="m-2 p-2" ID="tbUsername" runat="server" placeholder="hi@cts.net"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ErrorMessage="You must enter your email address." ControlToValidate="tbUsername" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:TextBox CssClass="m-2 p-2" type="password" ID="tbPassword" runat="server" placeholder="SecureP4SS"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="You must enter a password." Display="Dynamic" ControlToValidate="tbPassword" ForeColor="Red"></asp:RequiredFieldValidator>
            <div>

                <asp:LinkButton ID="lbRegister" runat="server" OnClick="lbRegister_Click" CausesValidation="False">Not signed up? Register</asp:LinkButton>
                <asp:Button CssClass="btn btn-success m-2 p-2" ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CausesValidation="False" />
            </div>
        </div>
    </div>
</asp:Content>
