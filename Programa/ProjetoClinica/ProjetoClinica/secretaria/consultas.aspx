<%@ Page Title="" Language="C#" MasterPageFile="~/secretaria/Secretaria.Master" AutoEventWireup="true" CodeBehind="consultas.aspx.cs" Inherits="ProjetoClinica.secretaria.consultas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SecretariaContent" runat="server">
    <div class="container whitecontainer contentcontainer">
        <div class="col s12">
            <center><h2>Consultas</h2></center>

            <div class="divider"></div>
            <br />

            <a class="waves-effect waves-light btn modal-trigger" href="#modalNovaConsulta">Nova consulta</a>

            <div class="containerpicker"></div>

            <div id="modalNovaConsulta" class="modal modal-fixed-footer">
                <div class="modal-content">
                    <h4>Marcar nova consulta</h4>
                    <div class="divider"></div>
                    <br />

                    <center><asp:Label ID="LblAviso" runat="server" Text="Avisos!!" Font-Size="Large" ForeColor="#CC0000"></asp:Label></center>

                    <p>Escolha os dados da consulta:</p>

                    <div class="col s12 modalform">
                        <div class="row">
                            <div class="input-field ddl">
                                <i class="material-icons prefix">person</i>
                                <asp:DropDownList ID="ddlPacienteConsulta" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSourcePacientesConsulta" DataTextField="nome_completo" DataValueField="id">
                                    <asp:ListItem Text="Paciente:" Value ="-1"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSourcePacientesConsulta" runat="server" ConnectionString="<%$ ConnectionStrings:ConexaoBD %>" SelectCommand="SELECT [id], [nome_completo] FROM [paciente]"></asp:SqlDataSource>
                            </div>
                        </div>

                        <div class="row">
                            <div class="input-field ddl">
                                <i class="material-icons prefix">local_hospital</i>
                                <asp:DropDownList ID="ddlMedicoConsulta" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSourceMedicosConsulta" DataTextField="nome_completo" DataValueField="id">
                                    <asp:ListItem Text="Médico:" Value ="-1"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSourceMedicosConsulta" runat="server" ConnectionString="<%$ ConnectionStrings:ConexaoBD %>" SelectCommand="SELECT [id], [nome_completo] FROM [medico]"></asp:SqlDataSource>
                            </div>
                        </div>

                        <div class="row">
                            <div class="input-field">
                                <i class="material-icons prefix">today</i>
                                <label for="SecretariaContent_txtDataNovaConsulta">Data:</label>
                                <asp:TextBox ID="txtDataNovaConsulta" runat="server" CssClass="datanovaconsulta"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row last-item">
                            <div class="input-field">
                                <i class="material-icons prefix">access_time</i>
                                <label for="SecretariaContent_txtHorarioNovaConsulta">Horário:</label>
                                <asp:TextBox ID="txtHorarioNovaConsulta" runat="server" CssClass="horarionovaconsulta"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="modal-footer">
                    <a href="#!" class="modal-close waves-effect btn-flat">CANCELAR</a>
                    <asp:LinkButton ID="BtnMarcarConsulta" runat="server" href="#!" CssClass="waves-effect btn-flat">MARCAR CONSULTA</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
