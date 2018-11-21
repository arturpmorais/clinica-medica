<%@ Page Title="" Language="C#" MasterPageFile="~/secretaria/Secretaria.Master" AutoEventWireup="true" CodeBehind="agendas.aspx.cs" Inherits="ProjetoClinica.secretaria.consultas.agendas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SecretariaContent" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server"
        EnableCdn="true"
        LoadScriptsBeforeUI="false"
        EnablePageMethods="true"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <div class="z-depth-3 container whitecontainer contentcontainer">
                <div class="col s12">
                    <center><h2>Agendas</h2></center>

                    <div class="divider"></div>
                    <br />

                    <center><asp:Label ID="LblAviso" runat="server" Font-Size="Large"></asp:Label></center>

                    <div class="row">
                        <center>
                            <label class="big-text">Consultas Gerais</label>
                        </center>
                        <asp:GridView ID="GridViewConsultas" runat="server" CssClass="highlight" AutoGenerateColumns="False" DataKeyNames="id"  ShowHeaderWhenEmpty="True" DataSourceID="SqlDataSourceConsultas" EmptyDataText="<center>Não existem consultas agendadas!</center>">
                            <Columns>
                                <asp:BoundField DataField="id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                                <asp:BoundField DataField="data" HeaderText="Data/Horário" SortExpression="data" />
                                <asp:BoundField DataField="duracao" HeaderText="Duração (em horas)" SortExpression="duracao" />
                                <asp:BoundField DataField="paciente" HeaderText="Paciente" SortExpression="paciente" />
                                <asp:BoundField DataField="medico" HeaderText="Médico" SortExpression="medico" />
                                <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
                                <asp:TemplateField HeaderText="Operações">
                                    <ItemTemplate>
                                        <center>
                                            <div class="operacoes" >
                                                <asp:LinkButton ID="LbReagendar" Consulta='<%# Eval("id")%>' runat="server" OnClick="LbReagendar_Click">Reagendar</asp:LinkButton>
                                                <br /><br />
                                                <asp:LinkButton ID="LbCancelar" Consulta='<%# Eval("id")%>' runat="server" OnClick="LbCancelar_Click">Cancelar</asp:LinkButton>
                                            </div>
                                        </center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSourceConsultas" runat="server" ConnectionString="<%$ ConnectionStrings:ConexaoBD %>" SelectCommand="SELECT c.id, c. data, c.duracao, p.id as idPaciente, p.nome_completo as paciente, m.id as idMedico, m.nome_completo as medico, c.status FROM consulta c, paciente p, medico m WHERE m.id = c.idMedico AND p.id = c.idPaciente AND c.status = 'PENDENTE' ORDER BY c.data, m.nome_completo, p.nome_completo, c.duracao" OnSelected="SqlDataSourceConsultas_Selected"></asp:SqlDataSource>
                    </div>
            
                    <!-------------------------------------------------------------------------------------------------------------------------------------------->

                    <br />

                    <div class="container">
                        <center>
                            <label class="big-text">Médicos:</label>
                        </center>
                        <div class="input-field ddl">
                            <i class="fas fa-user-md prefix"></i>
                            <asp:DropDownList ID="ddlMedicos" runat="server" AutoPostBack="True" DataSourceID="SqlDataSourceMedicos" DataTextField="nome_completo" DataValueField="id"></asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSourceMedicos" runat="server" ConnectionString="<%$ ConnectionStrings:ConexaoBD %>" SelectCommand="SELECT [id], [nome_completo] FROM [medico] ORDER BY [nome_completo]" OnSelected="SqlDataSourceMedicos_Selected"></asp:SqlDataSource>
                        </div>
                    </div>

                    <div class="row">
                        <center>
                            <label class="big-text">Consultas por Médico</label>
                        </center>
                        <asp:GridView ID="GridViewConsultasPorMedico" runat="server" CssClass="highlight" AutoGenerateColumns="False" DataKeyNames="id" ShowHeaderWhenEmpty="True" DataSourceID="SqlDataSourceConsultasPorMedico" EmptyDataText="<center>Este médico não possui consultas agendadas!</center>">
                            <Columns>
                                <asp:BoundField DataField="id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                                <asp:BoundField DataField="data" HeaderText="Data/Horário" SortExpression="data" />
                                <asp:BoundField DataField="duracao" HeaderText="Duração (em horas)" SortExpression="duracao" />
                                <asp:BoundField DataField="paciente" HeaderText="Paciente" SortExpression="paciente" />
                                <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
                                <asp:TemplateField HeaderText="Operações">
                                    <ItemTemplate>
                                        <center>
                                            <div class="operacoes" >
                                                <asp:LinkButton ID="LbReagendar" Consulta='<%# Eval("id")%>' runat="server" OnClick="LbReagendar_Click">Reagendar</asp:LinkButton>
                                                <br /><br />
                                                <asp:LinkButton ID="LbCancelar" Consulta='<%# Eval("id")%>' runat="server" OnClick="LbCancelar_Click">Cancelar</asp:LinkButton>
                                            </div>
                                        </center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSourceConsultasPorMedico" runat="server" ConnectionString="<%$ ConnectionStrings:ConexaoBD %>" SelectCommand="SELECT c.id, c. data, c.duracao, p.id as idPaciente, p.nome_completo as paciente, m.id as idMedico, m.nome_completo as medico, c.status FROM consulta c, paciente p, medico m WHERE m.id = @idMedico AND m.id = c.idMedico AND p.id = c.idPaciente AND c.status = 'PENDENTE' ORDER BY c.data, p.nome_completo, c.duracao" OnSelected="SqlDataSourceConsultasPorMedico_Selected">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlMedicos" DefaultValue="-1" Name="idMedico" PropertyName="SelectedValue" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>
                </div>
            </div>

            <script src="/Scripts/ajaxcontrols.js"></script>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
