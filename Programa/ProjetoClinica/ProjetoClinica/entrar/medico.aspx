<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="medico.aspx.cs" Inherits="ProjetoClinica.entrar.medico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <center><h1>Médico</h1></center>

    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <form>
                <div class="container">
                    <div class="col m9 s12">
                        <div class="row">
                            <asp:Label ID="LblAviso" runat="server" Text=""></asp:Label>
                        </div>

                        <div class="row">
                            <div class="input-field">
                                <i class="material-icons prefix">account_circle</i>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="validate"></asp:TextBox>
                                <label for="MainContent_txtEmail">E-mail:</label>
                            </div>
                        </div>

                        <div class="row">
                            <div class="input-field">
                                <i class="material-icons prefix">lock</i>
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="validate" TextMode="Password"></asp:TextBox>
                                <label for="MainContent_txtPassword">Senha:</label>
                            </div>
                        </div>

                        <div class="row">
                            <asp:Button ID="BtnEntrar" runat="server" Text="Entrar" CssClass="waves-effect waves-light btn-large btn-entrar" ForeColor="White" OnClick="BtnEntrar_Click" UseSubmitBehavior="false"/>
                        </div>
                    </div>
                </div>
            </form>
        </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>
