using ProjetoClinica.DB;
using ProjetoClinica.DB.DBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoClinica.medico.consultas
{
    public partial class consulta : System.Web.UI.Page
    {
        private ConsultaDBO Consulta;

        protected void Page_Load(object sender, EventArgs e)
        {
            MedicoDBO usuario = (MedicoDBO)Session["Usuario"];
            BDActions bd = new BDActions();

            try
            {
                int idConsulta;
                string query = Request.QueryString["id"];
                if (query == null || !int.TryParse(query, out idConsulta))
                    throw new Exception("Consulta não encontrada!");

                this.Consulta = bd.CarregarConsultaCompleta(idConsulta, usuario.Id, "MEDICO");

                LblPaciente.Text = this.Consulta.Paciente.Nome_Completo;
                LblData.Text = this.Consulta.Data.Split(' ')[0];
                LblHorario.Text = this.Consulta.Data.Split(' ')[1];
                LblDuracao.Text = this.Consulta.Duracao + "h";

                if (this.Consulta.Diagnostico != null)
                    TxtAreaDiagnostico.Text = this.Consulta.Diagnostico;
                if (this.Consulta.Medicacao != null)
                    TxtAreaMedicacao.Text = this.Consulta.Medicacao;
                if (this.Consulta.Observacoes != null)
                    TxtAreaObservacoes.Text = this.Consulta.Observacoes;
                if (this.Consulta.Sintomas != null)
                    TxtAreaSintomas.Text = this.Consulta.Sintomas;

                if (this.Consulta.Status == "PENDENTE")
                {
                    TxtAreaDiagnostico.ReadOnly = false;
                    TxtAreaMedicacao.ReadOnly = false;
                    TxtAreaObservacoes.ReadOnly = false;
                    TxtAreaSintomas.ReadOnly = false;
                }

                PanelConsulta.Visible = true;
            }
            catch (Exception ex)
            {
                LblAviso.ForeColor = System.Drawing.ColorTranslator.FromHtml("#CC0000");
                LblAviso.Text = ex.Message;
            }
        }
    }
}