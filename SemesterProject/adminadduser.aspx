<%@ Page Title="" Language="C#" MasterPageFile="~/CTS.Master" AutoEventWireup="true" CodeBehind="adminadduser.aspx.cs" Inherits="SemesterProject.adminadduser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BodyPlaceholder" runat="server">
    <div class="Settings">
        <img src="images/logo.png" alt="CTS Logo" />
        <h1>Create Account</h1>
        <div id="addUserAlert" runat="server"></div>
        <div class="form">
            <div class="form-group">
                <label for="lblCompanyName">Company:</label>
                <asp:Label CssClass="form-control-plaintext" readonly="true" ID="lblCompanyName" runat="server" Text=""></asp:Label>
            </div>
            <div class="form-group">
                <label for="tbEmail">Email: </label>
                <asp:TextBox CssClass="form-control" ID="tbEmail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="You must enter an email." ControlToValidate="tbEmail" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regexEmail" runat="server" ErrorMessage="You must enter a valid email." ControlToValidate="tbEmail" Display="Dynamic" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group">
                <label for="tbPassword">Password: </label>
                <asp:TextBox ID="tbPassword" CssClass="form-control" type="password" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="You must enter a password." ControlToValidate="tbPassword" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regexPassword" runat="server" ErrorMessage="Password must contain 1 uppercase letter, 1 lowercase letter, 1 number, and be 8-15 characters long." ControlToValidate="tbPassword" Display="Dynamic" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$" ForeColor="Red"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group">
                <label for="tbFirstName">First Name:</label>
                <asp:TextBox CssClass="form-control" ID="tbFirstName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ErrorMessage="You must enter the user's first name." Display="Dynamic" ControlToValidate="tbFirstName" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label for="tbLastName">Last Name: </label>
                <asp:TextBox CssClass="form-control" ID="tbLastName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ErrorMessage="You must enter the user's last name." ControlToValidate="tbLastName" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label for="tbPhoneNumber">Phone Number:</label>
                <asp:TextBox ID="tbPhoneNumber" CssClass="form-control" runat="server" MaxLength="12"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPhoneNumber" runat="server" ErrorMessage="You must enter your phone number." ControlToValidate="tbPhoneNumber" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regexPhoneNumber" runat="server" ErrorMessage="You must enter a valid phone number." ControlToValidate="tbPhoneNumber" ForeColor="Red" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}" Display="Dynamic"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group">
                <label for="tbTitle">Job Title</label>
                <asp:TextBox ID="tbTitle" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ErrorMessage="You must enter a job title." ControlToValidate="tbTitle" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label for="tbDepartment">Department: </label>
                <asp:TextBox CssClass="form-control" ID="tbDepartment" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvDepartment" runat="server" ErrorMessage="You must enter a department." ControlToValidate="tbDepartment" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div>
                <label for="cblTrainingPreferences">User should be subscribed to these topics: </label>
                <asp:CheckBoxList ID="cblTrainingPreferences" runat="server" DataSourceID="videoTopics" DataTextField="name" DataValueField="id">
                </asp:CheckBoxList>
                <asp:SqlDataSource ID="videoTopics" runat="server" ConnectionString="<%$ ConnectionStrings:F18_ksmmcquadConnectionString %>" SelectCommand="SELECT * FROM [videoTopics]"></asp:SqlDataSource>
            </div>
            <div class="w-100">
                <asp:CheckBox ID="cbNewsletter" runat="server" Checked="false" CssClass="form-check-inline" />
                <label for="cbNewsleeter">User should receive newsletter</label>
            </div>
            <div class="w-100">
                <asp:CheckBox ID="cbAdministrator" runat="server" Checked="false" CssClass="form-check-inline" />
                <label for="cbAdministrator">System Administrator</label>
            </div>
            <div>
                <asp:Button ID="btnCancel" CssClass="btn btn-danger m-2 p-2" runat="server" Text="Cancel" OnClick="btnCancel_Click" CausesValidation="False" />
                <asp:Button CssClass="btn btn-success m-2 p-2" ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ContentPlaceHolderID="ExtraScripts" runat="server">
    <script src="scripts/phone.js" type="text/javascript"></script>
</asp:Content>
