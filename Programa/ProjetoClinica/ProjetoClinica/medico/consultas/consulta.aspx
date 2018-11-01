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
                            <div class="row">
                                <div class="input-field">
                                    <i class="material-icons prefix">mode_edit</i>
                                    <asp:TextBox ID="TxtAreaEmailBody" runat="server" TextMode="MultiLine" CssClass="materialize-textarea emailcontent" data-length="1024"></asp:TextBox>
                                    <label for="<%= TxtAreaEmailBody.ClientID %>">Sintomas:</label>
                                </div>
                            </div>

                            <div class="row">
                                <div class="input-field">
                                    <i class="material-icons prefix">mode_edit</i>
                                    <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" CssClass="materialize-textarea emailcontent" data-length="1024"></asp:TextBox>
                                    <label for="<%= TxtAreaEmailBody.ClientID %>">Diagnóstico:</label>
                                </div>
                            </div>

                            <div class="row">
                                <div class="input-field">
                                    <i class="material-icons prefix">mode_edit</i>
                                    <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" CssClass="materialize-textarea emailcontent" data-length="1024"></asp:TextBox>
                                    <label for="<%= TxtAreaEmailBody.ClientID %>">Medicação:</label>
                                </div>
                            </div>

                            <div class="row">
                                <div class="input-field">
                                    <i class="material-icons prefix">mode_edit</i>
                                    <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine" CssClass="materialize-textarea emailcontent" data-length="1024"></asp:TextBox>
                                    <label for="<%= TxtAreaEmailBody.ClientID %>">Observa:</label>
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