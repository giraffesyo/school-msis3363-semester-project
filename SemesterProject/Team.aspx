<%@ Page Title="CTS - Team" Language="C#" MasterPageFile="~/WithFooter.Master" AutoEventWireup="true" CodeBehind="Team.aspx.cs" Inherits="SemesterProject.Team" %>

<asp:Content ContentPlaceHolderID="nestedBody" runat="server">
    <div id="teamBody">
        <div class="container-fluid">
            <div class="row mt-4" data-aos="fade-up" data-aos-duration="3000">
                <div class="col-12 col-md-4 offset-md-1">
                    <h1>All hands on deck is our way of life...</h1>
                    <p>
                        At Corporate Training Solutions we take collaboration seriously.
                         Our team of course designers and training specialists is completely involved in your training solutions from start to finish.
                         We make no compromises on the quality of the courses we deliver. 
                        By bringing all of our team on board with your companies mantra's we are able to make a more integrated and custom training solution that meets your company's needs.
                    </p>
                </div>
                <div class="col-12 col-md-4 offset-md-1">
                    <img src="images/group.jpg" class="img-fluid" alt="CTS Employees working to create a custom training solution" />
                </div>
            </div>
            <div class="row mt-4 mb-4">
                <div class="col-12 col-md-4 offset-md-1 order-1 order-md-0">
                    <div class="headshot" data-name="Kim Strauss" data-title="President/CEO">
                        <asp:Image data-aos="fade-left" data-aos-duration="2000" CssClass="img-fluid" ID="imgKimStrauss" runat="server" ImageUrl="~/images/KimStraussHeadshot.jpg" />
                    </div>
                    <div class="headshot" data-name="Monica Sadler" data-title="Marketing Director">
                        <asp:Image data-aos="fade-top" data-aos-duration="2000" CssClass="img-fluid" ID="imgMonicaSadler" runat="server" ImageUrl="~/images/TatumHeadshot.jpg" />
                    </div>
                    <div class="headshot" data-name="Quinn Schaeffer" data-title="IT Director">
                        <asp:Image data-aos="fade-bottom" data-aos-duration="2000" CssClass="img-fluid" ID="imgQuinn" runat="server" ImageUrl="~/images/QuinnHeadshot.jpg" />
                    </div>
                    <div class="headshot" data-name="Taylor Crisp" data-title="Vice-President">
                        <asp:Image data-aos="fade-right" data-aos-duration="2000" CssClass="img-fluid" ID="imgTaylorCrisp" runat="server" ImageUrl="~/images/TaylorHeadshot.jpg" />
                    </div>
                </div>
                <div class="AsideHeadshots col-12 col-md-4 d-flex align-items-center order-0 order-md-1 offset-md-1">
                    <div class="d-inline-block " data-aos="fade-right" data-aos-duration="1500">
                        <h2>We bring the brightest minds from all industries together so you don't have to worry about a thing.</h2>
                    </div>
                </div>
            </div>
            <div class="row mt-4 mb-4">
                <div class="col-12 col-sm-4 offset-0 order-sm-1">
                    <img src="images/rawpixel-659501-unsplash.jpg" alt="CTS offering you only the best!" class="img-fluid" />
                </div>
                <div class="col-sm-3 col-12 offset-0 align-self-center offset-sm-2 order-sm-0">
                    <h3 data-aos="zoom-in-right">We're the missing link..</h3>
                    <p data-aos="zoom-in-left">
                        CTS is a catalyst for attaching the missing linkage between the knowledge learned, and the practical
                    work applications, with the ultimate goal of providing a long-term SOLUTION to the company. We listen
                    to understand your issues and business objectives. We work together with you to equip your people
                    with necessary skills, providing them with the right tools to achieve important skills to have the
                    competitive edge. We believe that training does not stop at preaching in front of a whiteboard. We
                    stress hands on application, real live experiences and front-end technology.
                    </p>
                </div>
            </div>
            <div class="row mt-4 mb-5 pb-5">
                <div class="col-12 col-sm-6 offset-md-1" data-aos="fade-right" data-aos-duration="3000">
                    <h1>Areas of Expertise</h1>
                    <p>
                        We offer training and learning labs tailored to provide solutions to help increase the productivity and
                    performance in your organization. We believe in customizing and developing specific solutions through a
                    collaborative process designed to identify a client’s needs, requirements and objectives. The unique
                    approach combined with the strong team of experts, competent trainers and facilitators puts our lab in
                    the position to spur the progress of establishment. 
                    </p>
                </div>
                <div class="col-12 col-sm-4 mt-3" data-aos="flip-left" data-aos-duration="3000">
                    <h3>Our business focuses on 5 key areas:</h3>
                    <ul class="stars">
                        <li>Team Building</li>
                        <li>Communication</li>
                        <li>Leadership</li>
                        <li>Management</li>
                        <li>Technology</li>
                    </ul>
                </div>
            </div>
        </div>
    </div>


</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="ExtraScripts">
    <script src="scripts/executives.js" type="text/javascript"></script>
</asp:Content>
