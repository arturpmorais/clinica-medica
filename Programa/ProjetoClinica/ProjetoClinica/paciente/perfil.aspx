<%@ Page Title="" Language="C#" MasterPageFile="~/paciente/Paciente.Master" AutoEventWireup="true" CodeBehind="perfil.aspx.cs" Inherits="ProjetoClinica.perfil.paciente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PacienteContent" runat="server">
    <div class="col s12 whitecontainer contentcontainer">
        <div class="container">
            <center><h4 class="apelido"><asp:Label ID="LblApelido" runat="server" Text=""></asp:Label></h4></center>

            <div class="divider"></div>

            <div class="row">
                <center><asp:Image ID="ImgPerfil" CssClass="circle profile-pic" runat="server" /></center>
            </div>

            <div class="divider"></div>

            <br />

            <div class="row">
                <label>Nome completo:</label>
                <asp:Label ID="LblNome" runat="server" Text=""></asp:Label>
            </div>

            <div class="row">
                <label>E-mail:</label>
                <asp:Label ID="LblEmail" runat="server" Text=""></asp:Label>
            </div>

            <div class="row">
                <label>Data de nascimento:</label>
                <asp:Label ID="LblDataDeNascimento" runat="server" Text=""></asp:Label>
            </div>

            <div class="row">
                <label>Endereço:</label>
                <asp:Label ID="LblEndereco" runat="server" Text=""></asp:Label>
            </div>

            <div class="row">
                <label>Celular:</label>
                <asp:Label ID="LblCelular" runat="server" Text=""></asp:Label>
            </div>

            <div class="row">
                <label>Telefone residencial:</label>
                <asp:Label ID="LblTelefoneResidencial" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
