<%@ Page Title="" Language="C#" MasterPageFile="~/secretaria/Secretaria.Master" AutoEventWireup="true" CodeBehind="marcarconsulta.aspx.cs" Inherits="ProjetoClinica.secretaria.consultas.marcarconsulta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SecretariaContent" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <div class="z-depth-3 container whitecontainer containerform">
                <div class="col s12">
                    <center><h2>Marcar nova consulta</h2></center>

                    <div class="divider"></div>
                    <br />

                    <center><asp:Label ID="LblAviso" runat="server" Font-Size="Large" ForeColor="#CC0000"></asp:Label></center>

                    <center><label class="big-text">Escolha os dados da consulta:</label></center>
                    
                    <div class="containerpicker"></div>
                    
                    <div class="row">
                        <div class="input-field ddl">
                            <i class="material-icons prefix">person</i>
                            <asp:DropDownList ID="ddlPacienteConsulta" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSourcePacientesConsulta" DataTextField="nome_completo" DataValueField="id">
                                <asp:ListItem Text="Paciente:" Value ="-1"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSourcePacientesConsulta" runat="server" ConnectionString="<%$ ConnectionStrings:ConexaoBD %>" SelectCommand="SELECT [id], [nome_completo] FROM [paciente] ORDER BY [nome_completo]" OnSelected="SqlDataSourcePacientesConsulta_Selected"></asp:SqlDataSource>
                        </div>
                    </div>

                    <div class="row">
                        <div class="input-field ddl">
                            <i class="fas fa-user-md prefix"></i>
                            <asp:DropDownList ID="ddlMedicoConsulta" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSourceMedicosConsulta" DataTextField="nome_completo" DataValueField="id">
                                <asp:ListItem Text="Médico:" Value ="-1"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSourceMedicosConsulta" runat="server" ConnectionString="<%$ ConnectionStrings:ConexaoBD %>" SelectCommand="SELECT [id], [nome_completo] FROM [medico] ORDER BY [nome_completo]" OnSelected="SqlDataSourceMedicosConsulta_Selected"></asp:SqlDataSource>
                        </div>
                    </div>

                    <div class="row">
                        <div class="input-field">
                            <i class="material-icons prefix">today</i>
                            <asp:TextBox ID="txtDataNovaConsulta" runat="server" CssClass="datanovaconsulta"></asp:TextBox>
                            <label for="<%= txtDataNovaConsulta.ClientID %>">Data:</label>
                        </div>
                    </div>

                    <div class="row">
                        <div class="input-field">
                            <i class="material-icons prefix">access_time</i>
                            <asp:TextBox ID="txtHorarioNovaConsulta" runat="server" CssClass="horarionovaconsulta"></asp:TextBox>
                            <label for="<%= txtHorarioNovaConsulta.ClientID %>">Horário:</label>
                        </div>
                    </div>

                    <div class="row">
                        <div class="input-field ddl">
                            <i class="material-icons prefix">hourglass_empty</i>
                            <asp:DropDownList ID="ddlDuracao" runat="server" AppendDataBoundItems="True">
                                <asp:ListItem Text="Escolha a duração:" Value =""></asp:ListItem>
                                <asp:ListItem Text="30 minutos" Value="00:30"></asp:ListItem>
                                <asp:ListItem Text="1 hora" Value="01:00"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <asp:Button ID="BtnMarcarConsulta" runat="server" Text="Marcar Consulta" CssClass="waves-effect waves-light btn-large btn-asp" OnClick="BtnMarcarConsulta_Click" />
                </div>
            </div>

            <script src="/Scripts/ajaxcontrols.js"></script>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>