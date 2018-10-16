<%@ Page Title="" Language="C#" MasterPageFile="~/CTS.Master" AutoEventWireup="true" CodeBehind="Team.aspx.cs" Inherits="SemesterProject.Team" %>

<asp:Content ContentPlaceHolderID="BodyPlaceholder" runat="server">
    <div id="teamBody">
        <div class="container-fluid">
            <div class="row mt-4">
                <div class="col-12 col-md-4 offset-md-1 order-1 order-md-0">
                    <div class="headshot">
                        <asp:Image CssClass="img-fluid" ID="imgKimStrauss" runat="server" ImageUrl="~/images/KimStraussHeadshot.jpg" />
                    </div>
                    <div class="headshot">
                        <asp:Image CssClass="img-fluid" ID="imgMonicaSadler" runat="server" ImageUrl="~/images/TatumHeadshot.jpg" />
                    </div>
                    <div class="headshot">
                        <asp:Image CssClass="img-fluid" ID="imgTaylorCrisp" runat="server" ImageUrl="~/images/QuinnHeadshot.jpg" />
                    </div>
                    <div class="headshot">
                        <asp:Image CssClass="img-fluid" ID="Image4" runat="server" ImageUrl="~/images/TaylorHeadshot.jpg" />
                    </div>
                </div>
                <div class="AsideHeadshots col-12 col-md-5 d-flex align-items-center order-0 order-md-1">
                    <div class="d-inline-block ">
                        <h2>We bring the brightest minds from all industries together so you don't have to worry about a thing.</h2>
                        <p>This is some text</p>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
