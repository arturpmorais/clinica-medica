<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="contato.aspx.cs" Inherits="ProjetoClinica.contato" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <center>
        <h2 class="page-title">Deseja nos contatar?</h2>

        <div class="container">
            <div class="col s12 m11 l10 white">
                <br />
                <div id="map"></div>
                <script>
                    var map;
                    function initMap() {
                    map = new google.maps.Map(document.getElementById('map'), {
                    center: {lat: -34.397, lng: 150.644},
                    zoom: 8
                    });
                    }
                </script>
                <script src="https://maps.googleapis.com/maps/api/js?key=YOUR_API_KEY&callback=initMap" async defer></script>
            </div>
        </div>
    </center>
</asp:Content>
