<%@ Page Title="" Language="C#" MasterPageFile="~/medico/Medico.Master" AutoEventWireup="true" CodeBehind="historico.aspx.cs" Inherits="ProjetoClinica.medico.consultas.historico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MedicoContent" runat="server">
    <div class="container whitecontainer contentcontainer">
        <div class="col s12">
            <center><h2>Histórico</h2></center>

            <div class="divider"></div>
            <br />

            <div class="row">
                <center><asp:Label ID="LblAviso" runat="server" Font-Size="Large"></asp:Label></center>
            </div>

            <div class="consultas"></div>
        </div>
    </div>
</asp:Content>
