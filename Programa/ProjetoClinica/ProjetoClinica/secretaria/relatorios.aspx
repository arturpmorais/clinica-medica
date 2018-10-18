<%@ Page Title="" Language="C#" MasterPageFile="~/secretaria/Secretaria.Master" AutoEventWireup="true" CodeBehind="relatorios.aspx.cs" Inherits="ProjetoClinica.secretaria.relatorios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SecretariaContent" runat="server">
    <center><h2>Relatórios</h2></center>

    <div class="col s12 whitecontainer">
        <div class="container">
            <div class="row">
                <center><h4>Pacientes por médico (barra/coluna)</h4></center>

                <asp:Chart ID="Chart1" runat="server">
                    <Series>
                        <asp:Series Name="Series1">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            </div>

            <div class="divider"></div>

            <div class="row">
                <center><h4>Consultas canceladas mensalmente por médico (barra/coluna)</h4></center>
            </div>

            <div class="divider"></div>
            
            <div class="row">
                <center><h4>Consultas mensais por médico (barra/coluna)</h4></center>
            </div>

            <div class="divider"></div>

            <div class="row">
                <center><h4>Atendimento diário por especialidade (pizza)</h4></center>
            </div>
        </div>
    </div>
</asp:Content>
