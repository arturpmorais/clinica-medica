<%@ Page Title="" Language="C#" MasterPageFile="~/paciente/Paciente.Master" AutoEventWireup="true" CodeBehind="historico.aspx.cs" Inherits="ProjetoClinica.paciente.consultas.historico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PacienteContent" runat="server">
    <div class="z-depth-3 container whitecontainer contentcontainer">
        <div class="col s12">
            <center><h2>Histórico</h2></center>

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
