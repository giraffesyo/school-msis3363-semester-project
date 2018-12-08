<%@ Page Title="Administration" Language="C#" MasterPageFile="~/CTS.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="SemesterProject.admin" %>

<asp:Content ID="Administration" ContentPlaceHolderID="BodyPlaceholder" runat="server">
    <div class="administration container">
        <img class="logo" src="images/logo.png" alt="CTS logo" />
        <div class="row">
            <div class="col text-center">
                <h3>Manage Companies</h3>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <asp:Table CssClass="table mt-3" ID="companiesTable" runat="server">
                    <asp:TableHeaderRow>
                        <asp:TableHeaderCell>Company Name</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Employee Count</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Employees</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Edit</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                </asp:Table>
            </div>
        </div>
    </div>
</asp:Content>
