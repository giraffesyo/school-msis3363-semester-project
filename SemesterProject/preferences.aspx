<%@ Page Title="" Language="C#" MasterPageFile="~/CTS.Master" AutoEventWireup="true" CodeBehind="preferences.aspx.cs" Inherits="SemesterProject.preferences" %>

<asp:Content ContentPlaceHolderID="BodyPlaceholder" runat="server">
    <div class="d-flex flex-column justify-content-center ml-auto mr-auto w-25 vh-100">
        <h4>Update Preferences</h4>
        <asp:TextBox CssClass="m-2 p-2" ID="tbEmail" runat="server" placeholder="Email"></asp:TextBox>
        <asp:TextBox CssClass="m-2 p-2" ID="tbPassword" runat="server" placeholder="Password"></asp:TextBox>
        <asp:TextBox CssClass="m-2 p-2" ID="tbFullName" runat="server" placeholder="Full Name"></asp:TextBox>
        <div>
            <asp:Button ID="btnCancel" CssClass="btn btn-danger m-2 p-2" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
            <asp:Button CssClass="btn btn-success m-2 p-2" ID="btnSavePreferences" runat="server" Text="Save" OnClick="btnSavePreferences_Click" />
        </div>
    </div>
</asp:Content>
