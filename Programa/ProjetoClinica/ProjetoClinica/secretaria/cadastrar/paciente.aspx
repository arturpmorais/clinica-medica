<%@ Page Title="" Language="C#" MasterPageFile="~/secretaria/Secretaria.Master" AutoEventWireup="true" CodeBehind="paciente.aspx.cs" Inherits="ProjetoClinica.secretaria.cadastrar.paciente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SecretariaContent" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <form>
                <div class="container whitecontainer containerform">
                    <div class="col m9 s12">
                        <center><h3>Cadastrar paciente</h3></center>

                        <div class="row">
                            <center><asp:Label ID="LblAviso" runat="server" Text=""></asp:Label></center>
                        </div>

                        <div class="row">
                            <div class="input-field">
                                <i class="material-icons prefix">account_circle</i>
                                <asp:TextBox ID="txtNomeCompleto" runat="server"></asp:TextBox>
                                <label for="SecretariaContent_txtNomeCompleto">Nome completo:</label>
                            </div>
                        </div>

                        <div class="row">
                            <div class="input-field">
                                <i class="material-icons prefix">email</i>
                                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                                <label for="SecretariaContent_txtEmail">E-mail:</label>
                            </div>
                        </div>

                        <div class="row">
                            <div class="input-field">
                                <i class="material-icons prefix">lock</i>
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                                <label for="SecretariaContent_txtPassword">Senha:</label>
                            </div>
                        </div>

                        <div class="row">
                            <div class="input-field">
                                <i class="material-icons prefix">lock_outline</i>
                                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                                <label for="SecretariaContent_txtConfirmPassword">Confirmar senha:</label>
                            </div>
                        </div>

                        <div class="row">
                            <div class="input-field">
                                <i class="material-icons prefix">home</i>
                                <asp:TextBox ID="txtEndereco" runat="server" CssClass="validate"></asp:TextBox>
                                <label for="SecretariaContent_txtEmail">Endereço:</label>
                            </div>
                        </div>

                        <div class="row">
                            <div class="input-field">
                                <i class="material-icons prefix">smartphone</i>
                                <asp:TextBox ID="txtCelular" runat="server"></asp:TextBox>
                                <label for="SecretariaContent_txtCelular">Celular:</label>
                            </div>
                        </div>

                        <div class="row">
                            <div class="input-field">
                                <i class="material-icons prefix">phone</i>
                                <asp:TextBox ID="txtTelefoneResidencial" runat="server"></asp:TextBox>
                                <label for="SecretariaContent_txtTelefoneResidencial">Telefone residencial:</label>
                            </div>
                        </div>

                        <div class="row">
                            <div class="input-field">
                                <i class="material-icons prefix">today</i>
                                <label for="SecretariaContent_txtDataNascimento">Data de nascimento:</label>
                                <asp:TextBox ID="txtDataNascimento" runat="server" CssClass="datanascimento"></asp:TextBox>
                            </div>
                        </div>

                        <asp:Button ID="BtnCadastrar" runat="server" Text="Cadastrar" CssClass="waves-effect waves-light btn-large btn-entrar" ForeColor="White" UseSubmitBehavior="false" OnClick="BtnCadastrar_Click"/>
                    </div>
                </div>
            </form>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
