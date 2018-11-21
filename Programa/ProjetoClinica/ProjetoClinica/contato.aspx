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
                <p></p>
            </div>

            <div class="col m6 s12">
                <div id="map"></div>
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
