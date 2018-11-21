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
            <h2>Atendimento especializado</h2>
            <p class="white-text">Os melhores especialistas de São Paulo estão aqui</p>
        </div>
        <div class="carousel-item white-text exam-checking">
            <h2>Exames precisos</h2>
            <p class="white-text">Realizamos diversos exames de ótimas precisão</p>;
        </div>
        <div class="carousel-item white-text bed-clinic-empty">
            <h2>Hospitalidade máxima</h2>
            <p class="white-text">Oferecemos a acomodidade e o conforto de casa</p>
        </div>
        <div class="carousel-item white-text adult-blood">
            <h2>Consultas cuidadosas</h2>
            <p class="white-text">Nossas consultas são de extremo cuidado e atenção</p>
        </div>
        <div class="carousel-item white-text chart-check-up">
            <h2>Ánalise de dados</h2>
            <p class="white-text">Os dados dos usuários são analisados para otimização do funcionamento da clínica</p>
        </div>
    </div>

    <br />
    <center><h3 class="white-text">A Clínica perfeita para você!</h3></center>

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
                            Nossas consultas são pré-agendadas para que nós possamos lhe oferecer o melhor atendimento médico.
                            <br />
                            <br />
                            Trabalhamos com o conceito de atendimento personalizado para cada paciente, analisando as diferenças e necessidades de cada um e
                            fornecendo assim os cuidados necessários. Isso nos leva a ser a melhor clínica da região e justifica os prêmios que conquistamos.
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
                            Nós temos os melhores profissionais. 
                            <br />
                            <br />
                            Após anos de pesquisas, descobrimos a sua real necessidade. Reunimos em um só lugar o que há de melhor em 
                            serviços médicos, clínicos e laboratórios. Neste momento, somos todos parceiros para lhe proporcionar um atendimento 
                            perfeito!
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
                            Acreditamos no valor humano como o mais importante investimento, por isso a política de nossa clínica foca no bem 
                            estar de nossos clientes. Mais que pacientes, os vemos como parceiros diante dos desafios colocados a cada novo 
                            projeto.
                            <br /> 
                            <br /> 
                            A responsabilidade, a ética e a transparência na execução de todos os procedimentos desenvolvidos bem como em qualquer 
                            ação que empreendemos, são os pilares para o nosso sucesso. Entendemos que uma boa comunicação gera 
                            resultados positivos e rápidos, por isso valorizamos o diálogo claro e estamos sempre 
                            prontos a ouvir nossos pacientes para podermos corresponder às suas necessidades e expectativas.
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
