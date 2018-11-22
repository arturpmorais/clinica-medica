using ProjetoClinica.DB;
using ProjetoClinica.DB.DBO;
using ProjetoClinica.extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoClinica.paciente.consultas
{
    public partial class consulta : System.Web.UI.Page
    {
        private ConsultaDBO Consulta;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                CarregarConsulta();

                if (!IsPostBack)
                    CarregarCamposConsulta();
            }
            catch (Exception ex)
            {
                LblAviso.ForeColor = System.Drawing.ColorTranslator.FromHtml("#CC0000");
                LblAviso.Text = ex.Message;
            }
        }

        protected void CarregarConsulta()
        {
            PacienteDBO usuario = (PacienteDBO)Session["Usuario"];
            BDActions bd = new BDActions();

            string query = Request.QueryString["id"];
            if (query == null || !int.TryParse(query, out int idConsulta))
                throw new Exception("Consulta não encontrada!");

            this.Consulta = bd.CarregarConsultaCompleta(idConsulta, usuario.Id, "PACIENTE");
        }

        protected void CarregarCamposConsulta()
        {
            LblPaciente.Text = this.Consulta.Paciente.Nome_Completo;
            LblData.Text = this.Consulta.Data.Split(' ')[0];
            LblHorario.Text = this.Consulta.Data.Split(' ')[1];
            LblDuracao.Text = this.Consulta.Duracao + "h";
            LblStatus.Text = this.Consulta.Status;

            if (this.Consulta.Sintomas != null)
                TxtAreaSintomas.Text = this.Consulta.Sintomas;

            if (this.Consulta.Diagnostico != null)
                TxtAreaDiagnostico.Text = this.Consulta.Diagnostico;

            if (this.Consulta.Medicacao != null)
                TxtAreaMedicacao.Text = this.Consulta.Medicacao;

            if (this.Consulta.Observacoes != null)
                TxtAreaObservacoes.Text = this.Consulta.Observacoes;

            if (this.Consulta.Avaliacao != null)
                TxtAreaAvaliacao.Text = this.Consulta.Avaliacao;

            if (this.Consulta.Status == "REALIZADA")
            {
                LblStatus.CssClass = "green-text";

                if (this.Consulta.Avaliacao == null)
                {
                    TxtAreaAvaliacao.ReadOnly = false;
                    BtnConfirmar.Visible = true;
                    BtnConfirmar.Enabled = true;
                }
            }
            else if (this.Consulta.Status == "CANCELADA")
                LblStatus.CssClass = "red-text";

            if (this.Consulta.Status != "CANCELADA")
                PanelDadosConsulta.Visible = true;
            else
                PanelDadosConsulta.Visible = false;

            PanelConsulta.Visible = true;
        }

        protected void BtnConfirmar_Click(object sender, EventArgs e)
        {
            string avaliacao = TxtAreaAvaliacao.Text.Trim();

            BDActions bd = new BDActions();
            try
            {
                bd.AtualizarAvaliacao(this.Consulta.Id, avaliacao);

                CarregarConsulta();
                CarregarCamposConsulta();

                LblAviso.ForeColor = System.Drawing.ColorTranslator.FromHtml("#4BB543");
                LblAviso.Text = "Consulta atualizada com sucesso!";
            }
            catch (Exception ex)
            {
                LblAviso.ForeColor = System.Drawing.ColorTranslator.FromHtml("#CC0000");
                LblAviso.Text = ex.Message;
            }
        }
    }
}