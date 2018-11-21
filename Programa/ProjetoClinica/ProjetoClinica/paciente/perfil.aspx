<%@ Page Title="" Language="C#" MasterPageFile="~/paciente/Paciente.Master" AutoEventWireup="true" CodeBehind="perfil.aspx.cs" Inherits="ProjetoClinica.perfil.paciente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PacienteContent" runat="server">
    <div class="z-depth-3 container whitecontainer contentcontainer">
        <div class="col s12">
            <center><h4 class="apelido"><asp:Label ID="LblApelido" runat="server" Text=""></asp:Label></h4></center>

            <div class="divider"></div>

            <div class="row">
                <center><asp:Image ID="ImgPerfil" CssClass="circle profile-pic" runat="server" /></center>
            </div>

            <div class="divider"></div>

            <br />

            <div class="profilecontent">
                <center>
                    <div class="row">
                        <label>Nome completo:&nbsp</label>
                        <asp:Label ID="LblNome" runat="server" Text=""></asp:Label>
                    </div>

                    <div class="row">
                        <label>E-mail:&nbsp</label>
                        <asp:Label ID="LblEmail" runat="server" Text=""></asp:Label>
                    </div>

                    <div class="row">
                        <label>Data de nascimento:&nbsp</label>
                        <asp:Label ID="LblDataDeNascimento" runat="server" Text=""></asp:Label>
                    </div>

                    <div class="row">
                        <label>Endereço:&nbsp</label>
                        <asp:Label ID="LblEndereco" runat="server" Text=""></asp:Label>
                    </div>

                    <div class="row">
                        <label>Celular:&nbsp</label>
                        <asp:Label ID="LblCelular" runat="server" Text=""></asp:Label>
                    </div>

                    <div class="row">
                        <label>Telefone residencial:&nbsp</label>
                        <asp:Label ID="LblTelefoneResidencial" runat="server" Text=""></asp:Label>
                    </div>
                </center>
            </div>
        </div>
    </div>
</asp:Content>