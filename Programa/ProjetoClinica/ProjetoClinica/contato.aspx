<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="contato.aspx.cs" Inherits="ProjetoClinica.contato" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="z-depth-3 container whitecontainer contentcontainer">
        <center><h2 class="page-title">Deseja nos contatar?</h2></center>

        <div class="divider"></div>
        <br />

        <div class="row">
            <div class="col m6 s12">
                <p>
                    <h5>Por telefone:</h5>
                    219478239 (Telefone fixo)
                    <br />
                    989238592 (Celular - Operadora Claro)
                    <br />
                    984128352 (Whatsapp)

                    <br /><br />

                    <h5>Por e-mail:</h5>
                    atendimento@clinica.br (Agendamento de consultas)
                    <br />
                    reclameaqui@clinica.br (Dúvidas e reclamações)
                    <br />
                    admin@clinica.br (Parcerias e negociações)
                </p>
            </div>

            <div class="col m6 s12">
                <div id="map" class="z-depth-3"></div>
            </div>
        </div>
    </div>

    <script>
        var map;

        function initMap()
        {
            map = new google.maps.Map(document.getElementById('map'),
            {
                center: { lat: -22.864352239618317, lng: -47.049325704574585 },
                zoom: 10
            });
        }
    </script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCnUKWLK8ul6LsUfFolITAAE0sY5lznaHI&callback=initMap" async defer></script>
</asp:Content>
