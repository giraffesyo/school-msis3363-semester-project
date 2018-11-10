<%@ Page Title="" Language="C#" MasterPageFile="~/CTS.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="SemesterProject.Register" %>

<asp:Content ContentPlaceHolderID="BodyPlaceholder" runat="server">
    <div>
        <div class="register">
            <h1>Registration</h1>

            <img src="images/logo.png" alt="CTS Logo" />
            <div class="form">
                <div class="form-group">
                    <label for="lblCompanyName">Company:</label>
                    <asp:Label CssClass="form-control-plaintext" readonly="true" ID="lblCompanyName" runat="server" Text=""></asp:Label>
                </div>
                <div class="form-group">
                    <label for="lblEmployeeCount">Number of Employees:</label>
                    <asp:Label CssClass="form-control-plaintext" readonly="true" ID="lblEmployeeCount" runat="server" Text=""></asp:Label>
                </div>

                <div class="form-group">
                    <label for="tbEmail">Email: </label>
                    <asp:TextBox CssClass="form-control" ID="tbEmail" runat="server" placeholder="Email"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="tbPassword">Password: </label>
                    <asp:TextBox ID="tbPassword" CssClass="form-control" type="password" runat="server" placeholder="Password"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="tbFirstName">First Name:</label>
                    <asp:TextBox CssClass="form-control" ID="tbFirstName" runat="server" placeholder="First Name"></asp:TextBox>
                    <label for="tbLastName">Last Name: </label>
                    <asp:TextBox CssClass="form-control" ID="tbLastName" runat="server" placeholder="Last Name"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="tbPhoneNumber">Phone Number:</label>
                    <asp:TextBox ID="tbPhoneNumber" CssClass="form-control" runat="server" placeholder="Phone Number"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="tbTitle">Job Title</label>
                    <asp:TextBox ID="tbTitle" runat="server" placeholder="Job Title" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="tbDepartment">Department: </label>
                    <asp:TextBox CssClass="form-control" ID="tbDepartment" runat="server" placeholder="Department"></asp:TextBox>

                </div>
                <div>
                    <label for="cblTrainingPreferences">I am interested in learning about: </label>
                    <asp:CheckBoxList ID="cblTrainingPreferences" runat="server" DataSourceID="videoTopics" DataTextField="name" DataValueField="id">
                    </asp:CheckBoxList>
                    <asp:SqlDataSource ID="videoTopics" runat="server" ConnectionString="<%$ ConnectionStrings:F18_ksmmcquadConnectionString %>" SelectCommand="SELECT * FROM [videoTopics]"></asp:SqlDataSource>
                </div>
                <div class="form-group">
                    <label for="ddlNumberOfEmployees">Number Of Employees</label>
                    <asp:DropDownList ID="ddlNumberOfEmployees" runat="server"></asp:DropDownList>
                </div>

                <div>
                    <asp:CheckBox ID="cbNewsletter" runat="server" Checked="true" CssClass="form-check-inline" />
                    <label for="cbNewsleeter">I would like to receive the CTS newsletter</label>
                </div>
                <div>
                    <asp:Button ID="btnCancel" CssClass="btn btn-danger m-2 p-2" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                    <asp:Button CssClass="btn btn-success m-2 p-2" ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
