 <%@ Page Title="" Language="C#" MasterPageFile="~/secretaria/Secretaria.Master" AutoEventWireup="true" CodeBehind="medico.aspx.cs" Inherits="ProjetoClinica.secretaria.cadastrar.medico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SecretariaContent" runat="server">
    <center><h2>Cadastrar médico</h2></center>

    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <form>
                <div class="container">
                    <div class="col m9 s12">
                        <div class="col m9 s12">
                        <div class="row">
                            <asp:Label ID="LblAviso" runat="server" Text=""></asp:Label>
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

                        <div class="row">
                            <div class="input-field">
                                <i class="material-icons prefix">star</i>
                                <asp:DropDownList ID="DropdownEspecialidades" runat="server" DataSourceID="SqlDataSourceEspecialidade" DataTextField="especialidade" DataValueField="id" AppendDataBoundItems="True">
                                    <asp:ListItem Text="Especialidade:" Value ="-1"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <asp:SqlDataSource ID="SqlDataSourceEspecialidade" runat="server" ConnectionString="<%$ ConnectionStrings:ConexaoBD %>" SelectCommand="SELECT * FROM [especialidade]"></asp:SqlDataSource>
                        </div>

                        <asp:Button ID="BtnCadastrar" runat="server" Text="Cadastrar" CssClass="waves-effect waves-light btn-large btn-entrar" ForeColor="White" UseSubmitBehavior="false" OnClick="BtnCadastrar_Click"/>
                    </div>
                </div>
            </form>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
