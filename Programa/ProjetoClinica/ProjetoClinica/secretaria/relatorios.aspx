<%@ Page Title="" Language="C#" MasterPageFile="~/secretaria/Secretaria.Master" AutoEventWireup="true" CodeBehind="relatorios.aspx.cs" Inherits="ProjetoClinica.secretaria.relatorios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SecretariaContent" runat="server">
    <div class="container whitecontainer contentcontainer">
        <div class="col s12">
            <center><h2>Relatórios</h2></center>
        
            <div class="divider"></div>
            <br />

            <div class="row">
                <div class="col s12 m6">
                    <center>
                        <h4>Pacientes por médico</h4>

                        <asp:Chart ID="ChartPacientePorMedico" runat="server" DataSourceID="SqlDataSourcePacientePorMedico">
                            <Series>
                                <asp:Series Name="SeriesPacientePorMedico" XValueMember="Medico" YValueMembers="Pacientes">
                                </asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartAreaPacientePorMedico">
                                </asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                        <asp:SqlDataSource ID="SqlDataSourcePacientePorMedico" runat="server" ConnectionString="<%$ ConnectionStrings:ConexaoBD %>" SelectCommand="SELECT m.nome_completo as Medico, count(pm.idPaciente) as Pacientes
                                                                                                                                                                   FROM ( SELECT idMedico, idPaciente FROM consulta WHERE status != 'CANCELADA' GROUP BY idMedico, idPaciente ) AS pm, medico AS m
                                                                                                                                                                   WHERE pm.idMedico = m.id
                                                                                                                                                                   GROUP BY m.nome_completo">
                        </asp:SqlDataSource>
                    </center>
                </div>

                <div class="col s12 m6">
                    <center>
                        <h4>Consultas canceladas mensalmente por médico</h4>

                        <asp:Chart ID="ChartConsultasCanceladasPorMedico" runat="server" DataSourceID="SqlDataSourceConsultasCanceladasPorMedico">
                            <Series>
                                <asp:Series Name="SeriesConsultasCanceladasPorMedico" XValueMember="Medico" YValueMembers="Consultas">
                                </asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartAreaConsultasCanceladasPorMedico">
                                </asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                        <asp:SqlDataSource ID="SqlDataSourceConsultasCanceladasPorMedico" runat="server" ConnectionString="<%$ ConnectionStrings:ConexaoBD %>" SelectCommand="SELECT m.nome_completo AS Medico, count(c.id) AS Consultas
                                                                                                                                                                              FROM medico m, consulta c
                                                                                                                                                                              WHERE 
                                                                                                                                                                              m.id = c.idMedico AND
                                                                                                                                                                              c.status = 'CANCELADA' AND
                                                                                                                                                                              MONTH(CONVERT(DATE, c.data, 103)) = MONTH(GETDATE())
                                                                                                                                                                              GROUP BY m.nome_completo">
                        </asp:SqlDataSource>
                    </center>
                </div>
            </div>
            
            <div class="row">
                <div class="col s12 m6">
                    <center>
                        <h4>Consultas mensais por médico</h4>

                        <asp:Chart ID="ChartConsultasMensaisPorMedico" runat="server" DataSourceID="SqlDataSourceConsultasMensaisPorMedico">
                            <Series>
                                <asp:Series Name="SeriesConsultasMensaisPorMedico" XValueMember="Medico" YValueMembers="Consultas">
                                </asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartAreaConsultasMensaisPorMedico">
                                </asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                        <asp:SqlDataSource ID="SqlDataSourceConsultasMensaisPorMedico" runat="server" ConnectionString="<%$ ConnectionStrings:ConexaoBD %>" SelectCommand="SELECT m.nome_completo AS Medico, count(c.id) AS Consultas
                                                                                                                                                                           FROM medico m, consulta c
                                                                                                                                                                           WHERE 
                                                                                                                                                                           m.id = c.idMedico AND
                                                                                                                                                                           c.status != 'CANCELADA' AND
                                                                                                                                                                           MONTH(CONVERT(DATE, c.data, 103)) = MONTH(GETDATE())
                                                                                                                                                                           GROUP BY m.nome_completo">
                        </asp:SqlDataSource>
                    </center>
                </div>

                <div class="col s12 m6">
                    <center>
                        <h4>Atendimento diário por especialidade</h4>

                        <asp:Chart ID="ChartAtendimentoPorEspecialidade" runat="server" DataSourceID="SqlDataSourceAtendimentoPorEspecialidade">
                            <Series>
                                <asp:Series Name="SeriesAtendimentoPorEspecialidade" ChartType="Pie" XValueMember="Especialidade" YValueMembers="Consultas">
                                </asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartAreaAtendimentoPorEspecialidade">
                                </asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                        <asp:SqlDataSource ID="SqlDataSourceAtendimentoPorEspecialidade" runat="server" ConnectionString="<%$ ConnectionStrings:ConexaoBD %>" SelectCommand="SELECT e.especialidade as Especialidade, count(c.id) as Consultas
                                                                                                                                                                             FROM especialidade e, consulta c, medico m
                                                                                                                                                                             WHERE
                                                                                                                                                                             e.id = m.especialidade AND
                                                                                                                                                                             m.id = c.idMedico AND
                                                                                                                                                                             c.status != 'CANCELADA' AND
                                                                                                                                                                             DAY(CONVERT(DATE, c.data, 103)) = DAY(GETDATE())
                                                                                                                                                                             GROUP BY e.especialidade">
                        </asp:SqlDataSource>
                    </center>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
