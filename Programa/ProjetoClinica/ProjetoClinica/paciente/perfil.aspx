<%@ Page Title="" Language="C#" MasterPageFile="~/paciente/Paciente.Master" AutoEventWireup="true" CodeBehind="perfil.aspx.cs" Inherits="ProjetoClinica.perfil.paciente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PacienteContent" runat="server">

    <asp:Image ID="ImgPerfil" CssClass="circle" runat="server" />

    <asp:Label ID="LblNome" runat="server" Text=""></asp:Label>
    <asp:Label ID="LblEmail" runat="server" Text=""></asp:Label>
    <asp:Label ID="LblDataDeNascimento" runat="server" Text=""></asp:Label>
    <asp:Label ID="LblEndereco" runat="server" Text=""></asp:Label>
    <asp:Label ID="LblCelular" runat="server" Text=""></asp:Label>
    <asp:Label ID="LblTelefoneResidencial" runat="server" Text=""></asp:Label>

</asp:Content>
