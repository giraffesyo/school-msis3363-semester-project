<%@ Page Title="CTS - Client Portal" Language="C#" MasterPageFile="~/CTS.Master" AutoEventWireup="true" CodeBehind="clients.aspx.cs" Inherits="SemesterProject.clients" %>

<asp:Content ContentPlaceHolderID="BodyPlaceholder" runat="server">
    <div>
        <div class="row">
            <div class="text-center col-10 col-sm-12">
                <h2>Welcome to the client center.</h2>
            </div>
        </div>
        <div class="row justify-content-center videos d-flex flex-row flex-wrap" runat="server" id="VideoContainer">
        </div>
    </div>
</asp:Content>
