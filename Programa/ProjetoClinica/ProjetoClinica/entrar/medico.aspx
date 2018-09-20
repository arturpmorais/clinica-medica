<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="medico.aspx.cs" Inherits="ProjetoClinica.entrar.medico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <center><h1>Médico</h1></center>

    <form>
        <div class="container">
            <div class="col m9 s12">
                <div class="row">
                    <div class="input-field">
                        <i class="material-icons prefix">account_circle</i>
                        <input id="icon_prefix" type="text" class="validate">
                        <label for="icon_prefix">E-mail:</label>
                    </div>
                </div>

                <div class="row">
                    <div class="input-field">
                        <i class="material-icons prefix">lock</i>
                        <input id="password" type="password" class="validate">
                        <label for="password">Senha:</label>
                    </div>
                </div>

                <div class="row">
                    <button class="waves-effect waves-light btn-large btn-entrar">Entrar</button>
                </div>
            </div>
        </div>
    </form>
    
</asp:Content>
