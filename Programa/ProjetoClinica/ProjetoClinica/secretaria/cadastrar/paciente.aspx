<%@ Page Title="" Language="C#" MasterPageFile="~/secretaria/Secretaria.Master" AutoEventWireup="true" CodeBehind="paciente.aspx.cs" Inherits="ProjetoClinica.secretaria.cadastrar.paciente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SecretariaContent" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel" EnableViewState="true" runat="server">
        <ContentTemplate>
            <div class="z-depth-3 container whitecontainer containerform">
                <div class="col m9 s12">
                    <center><h3>Cadastrar paciente</h3></center>

                    <div class="divider"></div>
                    <br />

                    <div class="row">
                        <center><asp:Label ID="LblAviso" runat="server" Font-Size="Large"></asp:Label></center>
                    </div>

                    <form>
                        <div class="containerpicker"></div>

                        <div class="row">
                            <div class="input-field">
                                <i class="material-icons prefix">account_circle</i>
                                <asp:TextBox ID="txtNomeCompleto" runat="server" MaxLength="100"></asp:TextBox>
                                <label for="<%= txtNomeCompleto.ClientID %>">Nome completo:</label>
                            </div>
                        </div>

                        <div class="row">
                            <div class="input-field">
                                <i class="material-icons prefix">email</i>
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

                        <div class="row">
                            <div class="input-field">
                                <i class="material-icons prefix">lock_outline</i>
                                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" MaxLength="30"></asp:TextBox>
                                <label for="<%= txtConfirmPassword.ClientID %>">Confirmar senha:</label>
                            </div>
                        </div>

                        <div class="row">
                            <div class="input-field">
                                <i class="material-icons prefix">home</i>
                                <asp:TextBox ID="txtEndereco" runat="server"></asp:TextBox>
                                <label for="<%= txtEndereco.ClientID %>">Endereço:</label>
                            </div>
                        </div>

                        <div class="row">
                                <div class="input-field col s6 numbers">
                                    <i class="material-icons prefix">smartphone</i>
                                    <asp:TextBox ID="txtCelular" runat="server" MaxLength="16" TextMode="Phone"></asp:TextBox>
                                    <label for="<%= txtCelular.ClientID %>">Celular:</label>
                                </div>

                                <div class="input-field col s6 numbers">
                                    <i class="material-icons prefix">phone</i>
                                    <asp:TextBox ID="txtTelefoneResidencial" runat="server" MaxLength="16" TextMode="Phone"></asp:TextBox>
                                    <label for="<%= txtTelefoneResidencial.ClientID %>">Telefone residencial:</label>
                                </div>
                        </div>

                        <div class="row">
                            <div class="input-field">
                                <i class="material-icons prefix">today</i>
                                <asp:TextBox ID="txtDataNascimento" runat="server" CssClass="datanascimento" MaxLength="10"></asp:TextBox>
                                <label for="<%= txtDataNascimento.ClientID %>">Data de nascimento:</label>
                            </div>
                        </div>

                        <asp:Button ID="BtnCadastrar" runat="server" Text="Cadastrar" CssClass="waves-effect waves-light btn-large btn-asp" ForeColor="White" OnClick="BtnCadastrar_Click"/>
                    </form>
                </div>
            </div>

            <script src="/Scripts/ajaxcontrols.js"></script>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>