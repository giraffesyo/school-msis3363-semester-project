<%@ Page Title="CTS - Team" Language="C#" MasterPageFile="~/WithFooter.Master" AutoEventWireup="true" CodeBehind="Team.aspx.cs" Inherits="SemesterProject.Team" %>

<asp:Content ContentPlaceHolderID="nestedBody" runat="server">
    <div id="teamBody">
        <div class="container-fluid">
            <div class="row mt-4">
                <div class="col-12 col-md-4 offset-md-1">
                    <h1>All hands on deck is our way of life...</h1>
                    <p>At Corporate Training Solutions we take collaboration seriously.
                         Our team of course designers and training specialists is completely involved in your training solutions from start to finish.
                         We make no compromises on the quality of the courses we deliver. 
                        By bringing all of our team on board with your companies mantra's we are able to make a more integrated and custom training solution that meets your company's needs. </p>
                </div>
                <div class="col-12 col-md-4 offset-md-1">
                    <img src="images/group.jpg" class="img-fluid" alt="CTS Employees working to create a custom training solution" />
                </div>
            </div>
            <div class="row mt-4 mb-4">
                <div class="col-12 col-md-4 offset-md-1 order-1 order-md-0">
                    <div class="headshot">
                        <asp:Image CssClass="img-fluid" ID="imgKimStrauss" runat="server" ImageUrl="~/images/KimStraussHeadshot.jpg" />
                    </div>
                    <div class="headshot">
                        <asp:Image CssClass="img-fluid" ID="imgMonicaSadler" runat="server" ImageUrl="~/images/TatumHeadshot.jpg" />
                    </div>
                    <div class="headshot">
                        <asp:Image CssClass="img-fluid" ID="imgQuinn" runat="server" ImageUrl="~/images/QuinnHeadshot.jpg" />
                    </div>
                    <div class="headshot">
                        <asp:Image CssClass="img-fluid" ID="imgTaylorCrisp" runat="server" ImageUrl="~/images/TaylorHeadshot.jpg" />
                    </div>
                </div>
                <div class="AsideHeadshots col-12 col-md-4 d-flex align-items-center order-0 order-md-1 offset-md-1">
                    <div class="d-inline-block ">
                        <h2>We bring the brightest minds from all industries together so you don't have to worry about a thing.</h2>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
