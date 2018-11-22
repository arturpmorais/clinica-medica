<%@ Page Title="" Language="C#" MasterPageFile="~/secretaria/Secretaria.Master" AutoEventWireup="true" CodeBehind="enviaremail.aspx.cs" Inherits="ProjetoClinica.secretaria.enviaremail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SecretariaContent" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <div class="z-depth-3 container whitecontainer containerform">
                <div class="col s12">
                    <center><h2>Enviar e-mail</h2></center>

                    <div class="divider"></div>
                    <br />

                    <div class="row" runat="server" id="RowAviso" visible="false">
                        <center><asp:Label ID="LblAviso" runat="server" Font-Size="Large"></asp:Label></center>
                    </div>

                    <form>
                        <div class="title-table">
                            <center><label class="big-text">Consultas próximas</label></center>
                        </div>
                        <div class="row">
                            <asp:GridView ID="GridViewConsultasProximas" runat="server" CssClass="highlight" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSourceConsultasProximas" EmptyDataText="<center>Não há nenhuma consulta próxima a ser avisada!</center>" ShowHeaderWhenEmpty="True">
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                                    <asp:BoundField DataField="data" HeaderText="Data/Horário" SortExpression="data" />
                                    <asp:BoundField DataField="duracao" HeaderText="Duração (em horas)" SortExpression="duracao" />
                                    <asp:BoundField DataField="paciente" HeaderText="Paciente" SortExpression="paciente" />
                                    <asp:BoundField DataField="medico" HeaderText="Médico" SortExpression="medico" />
                                    <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSourceConsultasProximas" runat="server" ConnectionString="<%$ ConnectionStrings:ConexaoBD %>" SelectCommand="SELECT c.id, c. data, c.duracao, p.nome_completo as paciente, m.nome_completo as medico, c.status FROM consulta c, paciente p, medico m WHERE p.id = c.idPaciente AND m.id = c.idMedico AND c.status != 'CANCELADA' AND DATEDIFF(DAY, GETDATE(), CONVERT(DATE, c.data, 103)) &gt;= 0 AND DATEDIFF(DAY, GETDATE(), CONVERT(DATE, c.data, 103)) &lt;= 2 AND c.pacienteAvisado = 0 ORDER BY c.data, m.nome_completo, p.nome_completo, c.duracao"></asp:SqlDataSource>
                        </div>

                        <div class="row container-ddl-with-header">
                            <label>Pacientes:</label>
                            <div class="input-field ddl">
                                <i class="material-icons prefix">hourglass_empty</i>
                                <asp:ListBox ID="LbPacientes" runat="server" SelectionMode="Multiple"></asp:ListBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="input-field">
                                <i class="material-icons prefix">mode_edit</i>
                                <asp:TextBox ID="TxtAreaEmailBody" runat="server" TextMode="MultiLine" CssClass="materialize-textarea emailcontent" data-length="1024"></asp:TextBox>
                                <label for="<%= TxtAreaEmailBody.ClientID %>">Conteúdo:</label>
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