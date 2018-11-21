<%@ Page Title="" Language="C#" MasterPageFile="~/medico/Medico.Master" AutoEventWireup="true" CodeBehind="relatorio.aspx.cs" Inherits="ProjetoClinica.medico.relatorio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MedicoContent" runat="server">
    <div class="z-depth-3 container whitecontainer contentcontainer">
        <div class="col s12">
            <center><h2 class="title-table">Relatório</h2></center>
            <center><label class="big-text">Consultas por Paciente</label></center>
            
            <br />
            <div class="divider"></div>

            <div class="contentcontainer">
                <div class="container">
                    <div class="input-field ddl">
                        <i class="material-icons prefix">person</i>
                        <asp:DropDownList ID="ddlPacientes" runat="server" AppendDataBoundItems="True" AutoPostBack="true" DataSourceID="SqlDataSourcePacientes" DataTextField="nome_completo" DataValueField="id">
                            <asp:ListItem Text="Paciente:" Value ="-1"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSourcePacientes" runat="server" ConnectionString="<%$ ConnectionStrings:ConexaoBD %>" SelectCommand="SELECT DISTINCT p.id as ID, p.nome_completo FROM paciente p, consulta c, medico m WHERE p.id = c.idPaciente AND c.idMedico = @idMedico ORDER BY p.nome_completo" OnSelected="SqlDataSourcePacientes_Selected">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="-1" Name="idMedico" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>
                </div>
            
                <div class="row">
                    <asp:GridView ID="GridViewConsultasPorPaciente" runat="server" CssClass="highlight" DataSourceID="SqlDataSourceConsultasPorPaciente" AutoGenerateColumns="False" DataKeyNames="id" EmptyDataText="<center>Paciente não teve consultas com você!</center>" ShowHeaderWhenEmpty="True">
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                            <asp:BoundField DataField="data" HeaderText="Data/Horário" SortExpression="data" />
                            <asp:BoundField DataField="duracao" HeaderText="Duração (em horas)" SortExpression="duracao" />
                            <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSourceConsultasPorPaciente" runat="server" ConnectionString="<%$ ConnectionStrings:ConexaoBD %>" SelectCommand="SELECT id, data, duracao, status FROM consulta WHERE idPaciente = @idPaciente AND idMedico = @idMedico ORDER BY data DESC, duracao DESC">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlPacientes" DefaultValue="-1" Name="idPaciente" PropertyName="SelectedValue" Type="Int32" />
                            <asp:Parameter DefaultValue="-1" Name="idMedico" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
            </div>
        </div>
    </div>
</asp:Content>