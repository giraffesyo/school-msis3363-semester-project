<%@ Page Title="Company Registration" Language="C#" MasterPageFile="~/CTS.Master" AutoEventWireup="true" CodeBehind="RegisterCompany.aspx.cs" Inherits="SemesterProject.RegisterCompany" %>

<asp:Content ContentPlaceHolderID="BodyPlaceholder" runat="server">
    <div>
        <div class="register">
            <h1>Company Registration</h1>

            <img src="images/logo.png" alt="CTS Logo" />
            <div class="form">
                <div class="form-group">
                    <label for="tbCompanyName">Company Name: </label>
                    <asp:TextBox CssClass="form-control" ID="tbCompanyName" runat="server" placeholder="Company Name"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCompanyName" runat="server" ErrorMessage="You must enter a company name." ControlToValidate="tbCompanyName" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="tbNumberOfEmployees">Employee Count:</label>
                    <asp:TextBox CssClass="form-control" ID="tbNumberOfEmployees" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNumberOfEmployees" runat="server" ErrorMessage="You must enter the number of employees." Display="Dynamic" ControlToValidate="tbNumberOfEmployees" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regexNumberOfEmployees" runat="server" ErrorMessage="You must enter a valid number." Display="Dynamic" ControlToValidate="tbNumberOfEmployees" ForeColor="Red" ValidationExpression="[0-9]*"></asp:RegularExpressionValidator>
                </div>
                <div>
                    <asp:Button ID="btnCancel" CssClass="btn btn-danger m-2 p-2" runat="server" Text="Cancel" OnClick="btnCancel_Click" CausesValidation="False" />
                    <asp:Button CssClass="btn btn-success m-2 p-2" ID="btnRegister" runat="server" Text="Create Company" OnClick="btnRegister_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
