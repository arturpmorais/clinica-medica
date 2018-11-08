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
<div class="rating">
    <input type="radio" id="star5" name="rating" value="5.0" />
    <label class = "full" for="star5"></label>

    <input type="radio" id="star4half" name="rating" value="4.5" />
    <label class="half" for="star4half"></label>

    <input type="radio" id="star4" name="rating" value="4.0" />
    <label class = "full" for="star4"></label>

    <input type="radio" id="star3half" name="rating" value="3.5" />
    <label class="half" for="star3half"></label>

    <input type="radio" id="star3" name="rating" value="3.0" />
    <label class = "full" for="star3"></label>

    <input type="radio" id="star2half" name="rating" value="2.5" />
    <label class="half" for="star2half"></label>

    <input type="radio" id="star2" name="rating" value="2.0" />
    <label class = "full" for="star2"></label>

    <input type="radio" id="star1half" name="rating" value="1.5" />
    <label class="half" for="star1half"></label>

    <input type="radio" id="star1" name="rating" value="1.0" />
    <label class = "full" for="star1"></label>

    <input type="radio" id="starhalf" name="rating" value="0.5" />
    <label class="half" for="starhalf"></label>
</div>

                    <style>
                        .rating { 
  border: none;
}

.rating > input { display: none; } 
.rating > label:before { 
  margin: 5px;
  font-size: 1.25em;
  font-family: FontAwesome;
  display: inline-block;
  content: "\f005";
}

.rating > .half:before { 
  content: "\f089";
  position: absolute;
}

.rating > label { 
  color: #ddd; 
 float: right; 
}

/***** CSS Magic to Highlight Stars on Hover *****/

.rating > input:checked ~ label, /* show gold star when clicked */
.rating:not(:checked) > label:hover, /* hover current star */
.rating:not(:checked) > label:hover ~ label { color: #FFD700;  } /* hover previous stars in list */

.rating > input:checked + label:hover, /* hover current star when changing rating */
.rating > input:checked ~ label:hover,
.rating > label:hover ~ input:checked ~ label, /* lighten current selection */
.rating > input:checked ~ label:hover ~ label { color: #FFED85;  } 
                    </style>

                    <asp:Panel ID="PanelConsulta" runat="server" Visible="False">
                        <form>
                            <div class="container">
                                <div class="row">
                                    <label>Paciente: &nbsp;</label>
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