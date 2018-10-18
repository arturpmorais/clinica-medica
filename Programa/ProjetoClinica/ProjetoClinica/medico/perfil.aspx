<%@ Page Title="" Language="C#" MasterPageFile="~/medico/Medico.Master" AutoEventWireup="true" CodeBehind="perfil.aspx.cs" Inherits="ProjetoClinica.perfil.medico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MedicoContent" runat="server">
    <div class="col s12 whitecontainer">
        <div class="container">
            <div class="row">
                <center><asp:Label ID="LblApelido" runat="server" Text=""></asp:Label></center>
            </div>

            <div class="row">
                <center><asp:Image ID="ImgPerfil" CssClass="circle" runat="server" /></center>
            </div>

            <div class="row">
                <asp:Label ID="LblNome" runat="server" Text=""></asp:Label>
            </div>

            <div class="row">
                <asp:Label ID="LblEmail" runat="server" Text=""></asp:Label>
            </div>

            <div class="row">
                <asp:Label ID="LblDataDeNascimento" runat="server" Text=""></asp:Label>
            </div>

            <div class="row">
                <asp:Label ID="LblEndereco" runat="server" Text=""></asp:Label>
            </div>

            <div class="row">
                <asp:Label ID="LblCelular" runat="server" Text=""></asp:Label>
            </div>

            <div class="row">
                <asp:Label ID="LblTelefoneResidencial" runat="server" Text=""></asp:Label>
            </div>

            <div class="row">
                <asp:Label ID="LblEspecialidade" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
