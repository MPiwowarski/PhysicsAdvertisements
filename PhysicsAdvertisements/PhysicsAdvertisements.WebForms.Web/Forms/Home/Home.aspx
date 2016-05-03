<%@ Page Language="C#" MasterPageFile="../Shared/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="PhysicsAdvertisements.WebForms.Web.Forms.Home.Home" %>

<%@ Register Src="~/UserControls/AdvertisementsSearch/ControlTemplates/AdvertisementsSearch.ascx" TagPrefix="uc1" TagName="AdvertisementsSearch" %>


<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
    <link href="../../App_Styles/Home/Home.css" rel="stylesheet" />
    <link href="../../UserControls/AdvertisementsSearch/Layouts/AdvertisementsSearch.css" rel="stylesheet" />

    <title>Home</title>
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="mainContent" runat="server">
    <br />
    <div class="container">

        <div class="jumbotron">
            <h1>Welcome in our service!</h1>

            <p class="description">
                Need help in physics? You came to the right place! Here you can find a teacher or create your own advertisement with full description about your problem and publicate it.
                All you have to do is just register! Don't wait and try it now for free!

            </p>

            <p class="register-link">
                <a class="btn btn-lg btn-success" role="button" href="/Account/Register">Sign up today</a>
            </p>
        </div>


    </div>
    <div class="container">
        <div class="col-xs-12 col-sm-9 col-md-9 col-lg-9">
            <div class="col-xs-12 col-sm-4 col-md-4 col-lg-4 extra-money">
                <h2>Extra money!
                    
                </h2>
                <p>
                    Maybe you are the person who knows phycis very well and want to help others, earning extra money, solving exercises or teaching others in your spare time? 
                    Of course you can help others for free if you want, too.
                    Create a free account and create your own advertisements of physics.
                </p>                               
              
                
            </div>
            <div class="search-container col-xs-12 col-sm-8 col-md-8 col-lg-8">
                <div class="jumbotron">
                    <uc1:AdvertisementsSearch runat="server" ID="AdvertisementsSearch" OnSearchBtn_Click_Event="SearchBtn_Click_Event" />
                </div>
                <div class="comments-container">
                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                        <img class="img-circle" width="140" height="140" alt="Generic placeholder image" src="../../ecommerce-icon-set-freepik/New/avatar girl.png" />
                        <h2>Jennifer Moss</h2>
                        <p>I love to cooperate with Physics Advertisements service. Everyday I help almost ten people with theirs homework. I'm happy because I always wanted to earn money helping people.
                            Everyday I'm working as a teacher in high school and in free time I'm helping people with physics. During teaching others you can also learned a lot. Trust me. I recommend this service for everyone.
                        </p>
                  
                    </div>
                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                        <img class="img-circle" width="140" height="140" alt="Generic placeholder image" src="../../ecommerce-icon-set-freepik/PNG/avatar.png" />
                      
                        <h2>Tom Smith</h2>
                        <p> 
                            Thanks to Physics Advertisements service I won Europe 2016 high school championships in physics. I met here professional teachers which prepared me very well to that competition.
                            I recommend this service for all people who want to take a part in physics competitions and want to be prepared well by professionals. 
                        </p>
                      
                    </div>

                </div>
            </div>
        </div>
        <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
            <h4>Recommended books</h4>
            <hr />
            <%--  http://www.bootply.com/61730--%>
            <!-- Slider -->
            <div class="row-fluid">

                <div id="myCarousel" class="carousel slide">
                    <!-- Carousel items -->
                    <div class="carousel-inner">
                        <div class="active item" data-slide-number="0">
                          <img class="img-rounded img-responsive" src="../../App_Images/Home/MichioKaku.jpg" style="height:400px;"/>
                        </div>
                        <div class="item" data-slide-number="1">  
                            <img class="img-rounded img-responsive" src="../../App_Images/Home/Particle%20Physics.jpg" style="height:400px;" />
                        </div>
                        <div class="item" data-slide-number="2">
                            <img class="img-rounded img-responsive" src="../../App_Images/Home/AnMechanics.jpg" style="height:400px;"/>
                        </div>
                        <div class="item" data-slide-number="3">
                            <img class="img-rounded img-responsive" src="../../App_Images/Home/Physics.jpg" style="height:400px;"/>
                        </div>                     
                    </div>

                </div>
                <!-- Carousel nav -->
                <div class="carousel-controls-mini">
                    <a id="tmp" href="#myCarousel" data-slide="prev" class="next-slide">‹</a>
                    <a href="#myCarousel" data-slide="next">›</a>
                </div>



            </div>
        </div>
    </div>
    <br />
    <div class="container">

         <div class="col-xs-12 col-sm-10 col-md-10 col-lg-9" style=" margin:0; padding:0">
            
             </div>
        <div class="feedback-form col-xs-12 col-sm-2 col-md-2 col-lg-3">
            <ul>
                <li>Send us your feedback. Write about what you like or don't in our web application.
                </li>
                <li>
                    <asp:TextBox runat="server" ID="FeedbackContentControl" Height="90px" TextMode="MultiLine" CssClass="FeedbackContentControl"></asp:TextBox>
                </li>
                <li>
                    <asp:Button runat="server" ID="SendFeedbackControl" Text="Send Feedback" OnClick="SendFeedbackControl_Click" CssClass="btn btn-default"></asp:Button>
                </li>
            </ul>
        </div>
    </div>



</asp:Content>


<asp:Content ID="ScriptsContent" ContentPlaceHolderID="ScriptsContent" runat="server">
    <script type="text/javascript">

        //$(document).ready(function () {
        //    $("#tmp").click();
        //    $("#tmp").click();
        //    $("#tmp").click();
        //});

        $('.carousel').carousel({
            pause: "false"
        });
    </script>
</asp:Content>
