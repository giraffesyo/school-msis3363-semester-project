<%@ Page Title="CTS - Preferences" Language="C#" MasterPageFile="~/CTS.Master" AutoEventWireup="true" CodeBehind="preferences.aspx.cs" Inherits="SemesterProject.preferences" %>

<asp:Content ContentPlaceHolderID="BodyPlaceholder" runat="server">
    <div class="Settings">
        <img src="images/logo.png" alt="CTS Logo" />

        <div class="text-center">
            <h4>Update Preferences</h4>
        </div>
        <div class="alert-container container">
            <div runat="server" id="lblStatus"></div>
        </div>
        <div class="form">
            <div class="form-group">
                <label for="lblCompanyName">Company:</label>
                <asp:Label CssClass="form-control-plaintext" ID="lblCompanyName" runat="server" Text=""></asp:Label>
            </div>

            <div class="form-group">
                <label for="tbEmail">Email: </label>
                <asp:TextBox CssClass="form-control" ID="tbEmail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="You must enter an email." ControlToValidate="tbEmail" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regexEmail" runat="server" ErrorMessage="You must enter a valid email." ControlToValidate="tbEmail" Display="Dynamic" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group">
                <label for="tbFirstName">First Name:</label>
                <asp:TextBox CssClass="form-control" ID="tbFirstName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ErrorMessage="You must enter your first name." Display="Dynamic" ControlToValidate="tbFirstName" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label for="tbLastName">Last Name: </label>
                <asp:TextBox CssClass="form-control" ID="tbLastName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ErrorMessage="You must enter your last name." ControlToValidate="tbLastName" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
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
            <div class="container">
                <label for="cblTrainingPreferences">I am interested in learning about: </label>
                <asp:CheckBoxList OnDataBound="cblTrainingPreferences_DataBound" ID="cblTrainingPreferences" runat="server" DataSourceID="videoTopics" DataTextField="name" DataValueField="id">
                </asp:CheckBoxList>
                <asp:SqlDataSource ID="videoTopics" runat="server" ConnectionString="<%$ ConnectionStrings:F18_ksmmcquadConnectionString %>" SelectCommand="SELECT * FROM [videoTopics]"></asp:SqlDataSource>
            </div>
            <div class="w-100">
                <asp:CheckBox ID="cbNewsletter" runat="server" Checked="true" CssClass="form-check-inline" />
                <label for="cbNewsleeter">I would like to receive the CTS newsletter</label>
            </div>
            <div class=" pl-2 pl-sm-0 pr-2 pr-sm-0 mt-4 mb-4 w-100 d-flex flex-row justify-content-between">
                <div>
                    <asp:Button ID="btnCancel" CssClass="btn btn-secondary-2 mr-2 p-2" runat="server" Text="Cancel" OnClick="btnCancel_Click" CausesValidation="False" />
                    <asp:Button CssClass="btn btn-primary p-2 mr-2" ID="btnSavePreferences" runat="server" Text="Save" OnClick="btnSavePreferences_Click" />
                </div>
                <div>
                    <asp:Button ID="btnDeleteAccount" CssClass="btn btn-danger p-2" runat="server" Text="Delete Account" OnClick="btnDeleteAccount_Click" CausesValidation="False" />
                </div>
            </div>
        </div>
    </div>
    <!-- Delete Acocunt Modal is hidden option is selected by user -->
    <div class="modal fade" id="deleteAccountModal" tabindex="-1" role="dialog" aria-labelledby="deleteAccountModalTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <asp:UpdatePanel ID="deleteAccountUpdatePanel" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <div class="modal-header">
                            <h5 id="deleteAccountModalTitle" class="modal-title">Delete Account</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <asp:Label runat="server" Text="Are you sure you want to delete your account?"></asp:Label>
                        </div>
                        <div class="modal-footer">
                            <div class="alert alert-danger invisible" runat="server" id="deleteAccountModalAlert">Test</div>
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancel</button>
                            <asp:Button runat="server" OnClick="confirmAccountDeletion" type="button" CssClass="btn btn-danger" Text="Delete Account"></asp:Button>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

        </div>
    </div>
</asp:Content>
<asp:Content ContentPlaceHolderID="ExtraScripts" runat="server">
    <script src="scripts/phone.js" type="text/javascript"></script>
</asp:Content>
