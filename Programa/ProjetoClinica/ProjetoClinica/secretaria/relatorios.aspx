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
                <center>
                    <div class="relatorios">
                        <div class="col s12 m6">
                            <h4>Pacientes por médico</h4>

                            <div class="ct-chart ct-golden-section" id="ChartPacientesPorMedico"></div>
                        </div>

                        <div class="col s12 m6">
                            <h4>Consultas canceladas mensalmente por médico</h4>

                            <div class="ct-chart ct-golden-section" id="ChartConsultasCanceladasPorMedico"></div>
                        </div>

                        <div class="col s12 m6">
                            <h4>Consultas mensais por médico</h4>

                            <div class="ct-chart ct-golden-section" id="ChartConsultasMensaisPorMedico"></div>
                        </div>

                        <div class="col s12 m6">
                            <h4>Atendimento diário por especialidade</h4>

                            <div class="ct-chart ct-golden-section" id="ChartAtendimentoPorEspecialidade"></div>
                        </div>
                    </div>

                    <h5 class="lblAviso">Não foi possível carregar os relatórios!</h5>
                    <div class="loader">
                        <br /><br />

                        <div class="preloader-wrapper active">
                            <div class="spinner-layer spinner-blue-only">
                                <div class="circle-clipper left">
                                    <div class="circle"></div>
                                </div>
                                <div class="gap-patch">
                                    <div class="circle"></div>
                                </div>
                                <div class="circle-clipper right">
                                    <div class="circle"></div>
                                </div>
                            </div>
                        </div>

                        <br /><br /><br />
                    </div>
                </center>
            </div>

            <script>
                $('.relatorios').hide();
                $('.lblAviso').hide();
                $('.loader').show();

                $.ajax({
                    type : "POST",
                    url : "Query.aspx/CarregarDadosGraficos",
                    data : "{}",
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    success: carregarGraficos,
                    error: sinalizarErro
                });

                function carregarGraficos(response) {
                    var data = response.d;
                    data = $.parseJSON(data);

                    $('.loader').hide();

                    if (data.erro)
                        $('.lblAviso').show();
                    else {
                        // gráfico de barra
                        new Chartist.Bar('#ChartPacientesPorMedico', {
                            labels: data.PacientesPorMedico.labels,
                            series: data.PacientesPorMedico.series
                        });

                        // gráfico de barra
                        new Chartist.Bar('#ChartConsultasCanceladasPorMedico', {
                            labels: data.ConsultasCanceladasPorMedico.labels,
                            series: data.ConsultasCanceladasPorMedico.series
                        });

                        // gráfico de barra
                        new Chartist.Bar('#ChartConsultasMensaisPorMedico', {
                            labels: data.ConsultasCanceladasPorMedico.labels,
                            series: data.ConsultasMensaisPorMedico.series
                        });

                        // gráfico de pizza
                        var sum = function (a, b) { return a + b };
                        var labels = data.AtendimentoPorEspecialidade.labels;
                        new Chartist.Pie('#ChartAtendimentoPorEspecialidade',
                                         data = data.AtendimentoPorEspecialidade.data,
                                         {
                                             labelInterpolationFnc: function (value, i) {
                                                 var percentage = Math.round(value / data.series.reduce(sum) * 100) + '%';
                                                 return labels[i] + ' - ' + percentage;
                                             }
                                         }
                        );

                        $('.relatorios').show();
                    }
                }

                function sinalizarErro() {
                    $('.loader').hide();
                    $('.lblAviso').show();
                }
            </script>
        </div>
    </div>
</asp:Content>