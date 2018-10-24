<%@ Page Title="" Language="C#" MasterPageFile="~/secretaria/Secretaria.Master" AutoEventWireup="true" CodeBehind="enviaremail.aspx.cs" Inherits="ProjetoClinica.secretaria.enviaremail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SecretariaContent" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <div class="container whitecontainer containerform">
                <div class="col s12">
                    <center><h2>Enviar e-mail</h2></center>

                    <div class="divider"></div>
                    <br />

                    <div class="row">
                        <center><asp:Label ID="LblAviso" runat="server" Font-Size="Large"></asp:Label></center>
                    </div>

                    <form>
                        <div class="row">
                            <div class="input-field">
                                <i class="material-icons prefix">mode_edit</i>
                                <asp:TextBox ID="TxtAreaEmailBody" runat="server" TextMode="MultiLine" CssClass="materialize-textarea" data-length="1024"></asp:TextBox>
                                <label for="SecretariaContent_TxtAreaEmailBody">Conteúdo:</label>
                            </div>
                        </div>

                        <asp:Button ID="BtnEnviar" runat="server" CssClass="waves-effect waves-light btn-large btn-asp" Text="Enviar e-mail" OnClick="BtnEnviar_Click" />
                    </form>
                </div>
            </div>

            <script src="/Scripts/ajaxcontrols.js"></script>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>