<%@ Page Title="" Language="C#" MasterPageFile="~/medico/Medico.Master" AutoEventWireup="true" CodeBehind="consulta.aspx.cs" Inherits="ProjetoClinica.medico.consultas.consulta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MedicoContent" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <div class="container whitecontainer containerform">
                <div class="col s12">
                    <center><h2>Consulta</h2></center>

                    <div class="divider"></div>
                    <br />

                    <div class="row">
                        <center><asp:Label ID="LblAviso" runat="server" Font-Size="Large"></asp:Label></center>
                    </div>

                    <asp:Panel ID="PanelConsulta" runat="server" Visible="False">
                        <form>
                            <div class="consultainfo">
                                <div class="row">
                                    <label><i class="material-icons">arrow_forward</i>Paciente: &nbsp;</label>
                                    <asp:Label ID="LblPaciente" runat="server" Text="Label"></asp:Label>
                                </div>

                                <div class="row">
                                    <label>Data: &nbsp;</label>
                                    <asp:Label ID="LblData" runat="server" Text="Label"></asp:Label>
                                </div>

                                <div class="row">
                                    <label>Horário: &nbsp;</label>
                                    <asp:Label ID="LblHorario" runat="server" Text="Label"></asp:Label>
                                </div>

                                <div class="row">
                                    <label>Duração: &nbsp;</label>
                                    <asp:Label ID="LblDuracao" runat="server" Text="Label"></asp:Label>
                                </div>
                            </div>

                            <div class="row">
                                <div class="input-field">
                                    <i class="material-icons prefix">mode_edit</i>
                                    <asp:TextBox ID="TxtAreaSintomas" runat="server" TextMode="MultiLine" CssClass="materialize-textarea" ReadOnly="True"></asp:TextBox>
                                    <label for="<%= TxtAreaSintomas.ClientID %>">Sintomas:</label>
                                </div>
                            </div>

                            <div class="row">
                                <div class="input-field">
                                    <i class="material-icons prefix">mode_edit</i>
                                    <asp:TextBox ID="TxtAreaDiagnostico" runat="server" TextMode="MultiLine" CssClass="materialize-textarea" ReadOnly="True"></asp:TextBox>
                                    <label for="<%= TxtAreaDiagnostico.ClientID %>">Diagnóstico:</label>
                                </div>
                            </div>

                            <div class="row">
                                <div class="input-field">
                                    <i class="fas fa-prescription-bottle prefix"></i>
                                    <asp:TextBox ID="TxtAreaMedicacao" runat="server" TextMode="MultiLine" CssClass="materialize-textarea" ReadOnly="True"></asp:TextBox>
                                    <label for="<%= TxtAreaMedicacao.ClientID %>">Medicação:</label>
                                </div>
                            </div>

                            <div class="row">
                                <div class="input-field">
                                    <i class="fas fa-notes-medical prefix"></i>
                                    <asp:TextBox ID="TxtAreaObservacoes" runat="server" TextMode="MultiLine" CssClass="materialize-textarea" ReadOnly="True"></asp:TextBox>
                                    <label for="<%= TxtAreaObservacoes.ClientID %>">Observações:</label>
                                </div>
                            </div>
                        </form>
                    </asp:Panel>
                </div>
            </div>

            <script src="/Scripts/ajaxcontrols.js"></script>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>