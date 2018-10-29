<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ProjetoClinica.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="main-slider carousel carousel-slider center light-blue custom-lightblue">

        <div class="carousel-fixed-item center middle-indicator">
            <div class="left">
                <a class="movePrevious middle-indicator-text waves-effect waves-light content-indicator"><i class="middle-indicator-text material-icons left">chevron_left</i></a>
            </div>
     
            <div class="right">
                <a class="moveNext middle-indicator-text waves-effect waves-light content-indicator"><i class="middle-indicator-text material-icons right">chevron_right</i></a>
            </div>
        </div>

        <div class="carousel-item white-text arms-care-check">
            <h2>First Panel</h2>
            <p class="white-text">This is your first panel</p>
        </div>
        <div class="carousel-item white-text exam-checking">
            <h2>Second Panel</h2>
            <p class="white-text">This is your second panel</p>;
        </div>
        <div class="carousel-item white-text bed-clinic-empty">
            <h2>Third Panel</h2>
            <p class="white-text">This is your third panel</p>
        </div>
        <div class="carousel-item white-text adult-blood">
            <h2>Fourth Panel</h2>
            <p class="white-text">This is your fourth panel</p>
        </div>
        <div class="carousel-item white-text chart-check-up">
            <h2>Third Panel</h2>
            <p class="white-text">This is your third panel</p>
        </div>
    </div>

    <br />
    <center><h3>A Clínica perfeita para você!</h3></center>

    <br /><br />

    <div class="col s12">
        <div class="row">
            <div class="col s4">
                <div class="card topic">
                    <div class="card-image waves-effect waves-block waves-light">
                        <img class="activator" src="/images/backbone-check.jpg">
                    </div>
                    <div class="card-content">
                        <span class="card-title activator grey-text text-darken-4">Consultas<i class="material-icons right">more_vert</i></span>
                        <p>Saiba como são as consultas!</p>
                    </div>
                    <div class="card-reveal">
                        <span class="card-title grey-text text-darken-4">Consultas<i class="material-icons right">close</i></span>
                        <p>
                            Praesent ac ante et sem pretium fringilla. Duis vitae tempus quam, ut auctor turpis. Cras quis pharetra leo. 
                            Mauris bibendum metus nec commodo viverra.
                            Aliquam aliquet ornare velit vitae finibus. Suspendisse ac mollis ex, nec molestie turpis. 
                            Pellentesque tristique velit quis sapien ornare, eu semper neque blandit. Pellentesque ultrices imperdiet erat ut mattis. 
                        </p>
                    </div>
                </div>
            </div>

            <div class="col s4">
                <div class="card topic">
                    <div class="card-image waves-effect waves-block waves-light">
                        <img class="activator" src="/images/close-up-doctor-health.jpg">
                    </div>
                    <div class="card-content">
                        <span class="card-title activator grey-text text-darken-4">Equipe Médica<i class="material-icons right">more_vert</i></span>
                        <p>Conheça nossa equipe médica!</p>
                    </div>
                    <div class="card-reveal">
                        <span class="card-title grey-text text-darken-4">Equipe Médica<i class="material-icons right">close</i></span>
                        <p>
                            Nam ultricies mi ac quam tempor, sit amet sodales odio tristique. Cras ornare malesuada risus, malesuada porta tortor gravida quis. 
                            Phasellus mollis dui et nisi cursus, ut vestibulum urna elementum. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; 
                            Mauris vitae suscipit magna. Aenean at varius turpis. Proin ut auctor metus. In id maximus orci. Nulla facilisi. 
                            Nam venenatis ipsum ut lectus aliquet, in pretium tortor molestie. Curabitur tincidunt porta sapien, et volutpat urna commodo eu. 
                        </p>
                    </div>
                </div>
            </div>

            <div class="col s4">
                <div class="card topic">
                    <div class="card-image waves-effect waves-block waves-light">
                        <img class="activator" src="/images/appointment-book.jpg">
                    </div>
                    <div class="card-content">
                        <span class="card-title activator grey-text text-darken-4">Nossos Princípios<i class="material-icons right">more_vert</i></span>
                        <p>Entenda nossos princípios!</p>
                    </div>
                    <div class="card-reveal">
                        <span class="card-title grey-text text-darken-4">Nossos Princípios<i class="material-icons right">close</i></span>
                        <p>
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. In gravida magna malesuada ante viverra lacinia. 
                            Aliquam dapibus mauris malesuada ligula sodales sollicitudin. Sed eu ultricies dolor, sodales imperdiet tellus. 
                            Ut vitae ornare diam. Vestibulum vel ipsum ultricies nibh pellentesque varius eu a sapien. 
                            Aenean tempus nisi nisl, vel ornare lectus pellentesque nec. In hac habitasse platea dictumst. 
                            Ut a ornare sapien. Proin ac turpis scelerisque, eleifend arcu ut, fermentum mi. 
                            Suspendisse orci urna, cursus at posuere a, vulputate sed elit. 
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        $(document).ready(function () {
            $('.main-slider').carousel({
                duration: 300,
                fullWidth: true,
                indicators: true
            });

            setInterval(function() {
                if (!$('.main-slider').is(':hover'))
                    $('.main-slider').carousel('next');
            }, 4000);
        });

        $('.moveNext').click(function (e) {
            e.preventDefault();
            e.stopPropagation();
            $('.main-slider').carousel('next');
        });

        $('.movePrevious').click(function (e) {
            e.preventDefault();
            e.stopPropagation();
            $('.main-slider').carousel('prev');
        });
    </script>
</asp:Content>
