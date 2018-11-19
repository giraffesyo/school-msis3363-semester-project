<%@ Page Title="CTS - Choose Company" Language="C#" MasterPageFile="~/CTS.Master" AutoEventWireup="true" CodeBehind="ChooseCompany.aspx.cs" Inherits="SemesterProject.ChooseCompany" %>

<asp:Content ContentPlaceHolderID="BodyPlaceholder" runat="server">
    <div>
        <div class="Settings">
            <h1>Select your company</h1>

            <img src="images/logo.png" alt="CTS Logo" />
            <div class="form">
                <div class="form-group">
                    <label for="ddlCompanyName">Company Name: </label>
                    <asp:DropDownList OnDataBound="ddlCompanyName_DataBound" ID="ddlCompanyName" runat="server" DataSourceID="Companies" DataTextField="name" DataValueField="id"></asp:DropDownList>
                    <asp:SqlDataSource ID="Companies" runat="server" ConnectionString="<%$ ConnectionStrings:F18_ksmmcquadConnectionString %>" SelectCommand="SELECT [id], [name] FROM [companies]"></asp:SqlDataSource>
                </div>
                <div>
                    <asp:Button ID="btnCancel" CssClass="btn btn-danger m-2 p-2" runat="server" Text="Cancel" OnClick="btnCancel_Click" CausesValidation="False" />
                    <asp:Button CssClass="btn btn-success m-2 p-2" ID="btnChoose" runat="server" Text="Continue" OnClick="btnChoose_Click" />
                </div>
                <div class="w-100">
                    <asp:hyperlink runat="server" NavigateUrl="~/RegisterCompany.aspx">Don't see your company? Add it</asp:hyperlink>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
