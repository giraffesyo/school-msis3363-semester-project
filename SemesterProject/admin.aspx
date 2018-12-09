<%@ Page Title="Administration" Language="C#" MasterPageFile="~/CTS.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="SemesterProject.admin" %>

<asp:Content ContentPlaceHolderID="ExtraScripts" runat="server">
</asp:Content>

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
                <asp:UpdatePanel ID="tableUpdatePanel" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:Table CssClass="table mt-3 table-responsive-sm" ID="companiesTable" runat="server">
                            <asp:TableHeaderRow>
                                <asp:TableHeaderCell>Company Name</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Employee Count</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Users</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Edit</asp:TableHeaderCell>
                            </asp:TableHeaderRow>
                        </asp:Table>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>

        <!-- Edit companies Modal is hidden until opened from the table -->
        <div class="modal fade" id="editCompanyModal" tabindex="-1" role="dialog" aria-labelledby="modalTitle" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <asp:UpdatePanel ID="editCompanyUpdatePanel" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <div class="modal-header">
                                <h5 class="modal-title">
                                    <asp:Label runat="server" Text="" ID="editCompanyTitle"></asp:Label>
                                </h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body" id="editCompanyBody">
                                <asp:HiddenField ID="hiddenCompanyIndex" runat="server" />
                                <div class="row">
                                    <div class="form-group col">
                                        <label class="mb-1" for="tbCompanyName">Company Name: </label>
                                        <asp:TextBox ID="tbCompanyName" runat="server" CssClass="form-control" CausesValidation="True"></asp:TextBox>
                                    </div>
                                    <div class="form-group col">
                                        <label for="tbEmployeeCount" class="mb-1">Employee Count: </label>
                                        <asp:TextBox ID="tbEmployeeCount" runat="server" CssClass="form-control" CausesValidation="True" TextMode="Number"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <div class="alert alert-danger invisible" runat="server" id="editCompanyModalAlert">Test</div>
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                <asp:Button runat="server" ID="editCompanySave" OnClick="editCompanySave_Click" type="button" CssClass="btn btn-primary" Text="Save changes"></asp:Button>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
