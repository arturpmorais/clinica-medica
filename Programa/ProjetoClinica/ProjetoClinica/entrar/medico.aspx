<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="medico.aspx.cs" Inherits="ProjetoClinica.entrar.medico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <div class="z-depth-3 container whitecontainer containerform">
                <div class="col m9 s12">
                    <center><h2>Médico</h2></center>

                    <div class="divider"></div>
                    <br />

                    <div class="row">
                        <center><asp:Label ID="LblAviso" runat="server" Font-Size="Large" ForeColor="#CC0000"></asp:Label></center>
                    </div>

                    <form>
                        <div class="row">
                            <div class="input-field">
                                <i class="material-icons prefix">account_circle</i>
                                <asp:TextBox ID="txtEmail" runat="server" MaxLength="50" TextMode="Email"></asp:TextBox>
                                <label for="<%= txtEmail.ClientID %>">E-mail:</label>
                            </div>
                        </div>

                        <div class="row">
                            <div class="input-field">
                                <i class="material-icons prefix">lock</i>
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" MaxLength="30"></asp:TextBox>
                                <label for="<%= txtPassword.ClientID %>">Senha:</label>
                            </div>
                        </div>

                        <asp:Button ID="BtnEntrar" runat="server" Text="Entrar" CssClass="waves-effect waves-light btn-large btn-asp" ForeColor="White" OnClick="BtnEntrar_Click"/>
                    </form>
                </div>
            </div>

            <script src="/Scripts/ajaxcontrols.js"></script>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>