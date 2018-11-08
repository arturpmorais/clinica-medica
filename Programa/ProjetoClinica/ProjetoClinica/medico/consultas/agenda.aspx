<%@ Page Title="" Language="C#" MasterPageFile="~/medico/Medico.Master" AutoEventWireup="true" CodeBehind="agenda.aspx.cs" Inherits="ProjetoClinica.medico.consultas.agenda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MedicoContent" runat="server">
    <div class="container whitecontainer contentcontainer">
        <div class="col s12">
            <center><h2>Agenda</h2></center>

            <div class="divider"></div>
            <br />

            <div class="row">
                <center><asp:Label ID="LblAviso" runat="server" Font-Size="Large"></asp:Label></center>
            </div>

            <asp:Panel ID="PanelConsultas" runat="server" Visible="False">
            </asp:Panel>
        </div>
    </div>
</asp:Content>