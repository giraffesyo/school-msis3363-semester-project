<%@ Page Title="Manage Employees" Language="C#" MasterPageFile="~/CTS.Master" AutoEventWireup="true" CodeBehind="adminEmployees.aspx.cs" Inherits="SemesterProject.adminEmployees" %>

<asp:Content ContentPlaceHolderID="BodyPlaceholder" runat="server">
    <div class="administration container">
        <img class="logo" src="images/logo.png" alt="CTS logo" />
        <div class="row">
            <div class="col text-center">
                <h3>
                    <asp:Label ID="lblHeader" runat="server" Text=""></asp:Label>
                </h3>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <div runat="server" visible="false" class="alert alert-warning" id="adminEmployeesAlert"></div>
                <asp:UpdatePanel ID="tableUpdatePanel" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:Table CssClass="table mt-3 table-responsive-sm" ID="employeesTable" runat="server">
                            <asp:TableHeaderRow>
                                <asp:TableHeaderCell>Email</asp:TableHeaderCell>
                                <asp:TableHeaderCell>First Name</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Last Name</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Edit</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Delete</asp:TableHeaderCell>
                            </asp:TableHeaderRow>
                        </asp:Table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <!-- Delete Employees Modal is hidden until opened from the table -->
    <div class="modal fade" id="deleteEmployeeModal" tabindex="-1" role="dialog" aria-labelledby="modalTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <asp:UpdatePanel ID="deleteEmployeeUpdatePanel" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <div class="modal-header">
                            <h5 class="modal-title">
                                <asp:Label runat="server" Text="" ID="deleteEmployeeTitle"></asp:Label>
                            </h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body" id="deleteEmployeeBody">
                            <asp:HiddenField ID="hiddenEmployeeIndex" runat="server" />
                            <div class="row">
                                <div class="col">
                                    <asp:Label ID="lblDeleteEmployeeBody" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <div class="alert alert-danger" visible="false" runat="server" id="deleteEmployeeModalAlert"></div>
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancel</button>
                                <asp:Button runat="server" OnClick="deleteEmployeeConfirmed" type="button" CssClass="btn btn-danger" Text="Delete account"></asp:Button>
                            </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

        </div>
    </div>
</asp:Content>

