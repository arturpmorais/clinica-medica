<%@ Page Title="" Language="C#" MasterPageFile="~/secretaria/Secretaria.Master" AutoEventWireup="true" CodeBehind="enviaremail.aspx.cs" Inherits="ProjetoClinica.secretaria.enviaremail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SecretariaContent" runat="server">

    <div class="container whitecontainer contentcontainer">
        <asp:Button ID="BtnEnviar" runat="server" Text="Enviar e-mail" />
    </div>
</asp:Content>
