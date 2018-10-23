<%@ Page Title="" Language="C#" MasterPageFile="~/secretaria/Secretaria.Master" AutoEventWireup="true" CodeBehind="especialidade.aspx.cs" Inherits="ProjetoClinica.secretaria.cadastrar.especialidade" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SecretariaContent" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <form>
                <div class="container whitecontainer containerform">
                    <div class="col m9 s12">
                        <center><h3>Cadastrar especialidade</h3></center>

                        <div class="divider"></div>
                        <br />

                        <div class="row">
                            <center><asp:Label ID="LblAviso" runat="server" Text=""></asp:Label></center>
                        </div>

                        <div class="row">
                            <div class="input-field">
                                <i class="material-icons prefix">account_circle</i>
                                <asp:TextBox ID="txtEspecialidade" runat="server"></asp:TextBox>
                                <label for="SecretariaContent_txtEspecialidade">Nova especialidade:</label>
                            </div>
                        </div>

                        <asp:Button ID="BtnCadastrar" runat="server" Text="Cadastrar" CssClass="waves-effect waves-light btn-large btn-entrar" ForeColor="White" UseSubmitBehavior="false" OnClick="BtnCadastrar_Click"/>
                    </div>
                </div>
            </form>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
