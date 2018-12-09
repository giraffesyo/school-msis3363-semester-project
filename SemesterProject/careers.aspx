<%@ Page Title="" Language="C#" MasterPageFile="~/WithFooter.master" AutoEventWireup="true" CodeBehind="careers.aspx.cs" Inherits="SemesterProject.careers" %>

<asp:Content ContentPlaceHolderID="nestedBody" runat="server">
    <div class="Careers">
        <h2>Apply to work at CTS</h2>
        <div class="group">
            <div>
                <label for="tbFirstName">First Name </label>
                <asp:TextBox CssClass="form-control" ID="tbFirstName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ErrorMessage="You must enter a first name." ControlToValidate="tbFirstName" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div>
                <label for="tbLastName">Last Name </label>
                <asp:TextBox CssClass="form-control" ID="tbLastName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ErrorMessage="You must enter a last name." ControlToValidate="tbLastName" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="group">
            <div>
                <label for="tbEmail">Email Address </label>
                <asp:TextBox CssClass="form-control" ID="tbEmail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="You must enter an email." ControlToValidate="tbEmail" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regexEmail" runat="server" ErrorMessage="You must enter a valid email." ControlToValidate="tbEmail" Display="Dynamic" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </div>
            <div>
                <label for="tbPhoneNumber">Phone Number </label>
                <asp:TextBox CssClass="form-control phone" ID="tbPhoneNumber" runat="server" MaxLength="12"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPhoneNumber" runat="server" ErrorMessage="You must enter a phone number." ControlToValidate="tbPhoneNumber" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regexPhoneNumber" runat="server" ErrorMessage="You must enter a valid phone number." ControlToValidate="tbPhoneNumber" ForeColor="Red" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}" Display="Dynamic"></asp:RegularExpressionValidator>

            </div>
        </div>
        <div class="group">
            <div>
                <label for="tbResumeLink">Link to your resume</label>
                <asp:TextBox CssClass="form-control" ID="tbResumeLink" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvResumeLink" runat="server" ErrorMessage="You must provide a resume link." ControlToValidate="tbResumeLink" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div>
                <label for="tbLinkedIn">Linked <i class="fa fa-linkedin-square"></i></label>
                <asp:TextBox CssClass="form-control" ID="tbLinkedIn" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvLinkedIn" runat="server" ErrorMessage="You must provide a Linked In." ControlToValidate="tbLinkedIn" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="cbl">
            <span>Choose your job preferences:</span>
            <asp:CheckBoxList ID="cblPreferences" runat="server" DataSourceID="cblDataSource" DataTextField="name" DataValueField="id"></asp:CheckBoxList>
        </div>
        <asp:SqlDataSource ID="cblDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:F18_ksmmcquadConnectionString %>" SelectCommand="SELECT [name], [id] FROM [careerTopics]"></asp:SqlDataSource>
        <div class="buttons">
            <asp:Button runat="server" ID="btnSubmitApplication" CssClass="btn btn-dark" Text="Submit Application" />
        </div>
    </div>
</asp:Content>

<asp:Content ContentPlaceHolderID="ExtraScripts" runat="server">
    <script src="scripts/phone.js" type="text/javascript"></script>
</asp:Content>
