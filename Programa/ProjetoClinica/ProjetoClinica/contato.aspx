<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="contato.aspx.cs" Inherits="ProjetoClinica.contato" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="whitecontainer contentcontainer">
        <center>
            <h2 class="page-title">Deseja nos contatar?</h2>

            <div class="divider"></div>

            <div class="row">
                <div class="col s12 m6">
                    <p></p>
                </div>

                <div class="col s12 m6">
                    <div id="map"></div>
                </div>
            </div>
        </center>
    </div>

    <script>
        var map;

        function initMap() {
            map = new google.maps.Map(document.getElementById('map'),
            {
                center: { lat: -22.864352239618317, lng: -47.049325704574585 },
                zoom: 10
            });
        }
    </script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCnUKWLK8ul6LsUfFolITAAE0sY5lznaHI&callback=initMap" async defer></script>
</asp:Content>
