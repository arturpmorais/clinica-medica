using ProjetoClinica.DB;
using ProjetoClinica.DB.DBO;
using ProjetoClinica.extensions;
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
            MedicoDBO usuario = (MedicoDBO)Session["Usuario"];
            BDActions bd = new BDActions();

            string query = Request.QueryString["id"];
            if (query == null || !int.TryParse(query, out int idConsulta))
                throw new Exception("Consulta não encontrada!");

            this.Consulta = bd.CarregarConsultaCompleta(idConsulta, usuario.Id, "MEDICO");
        }

        protected void CarregarCamposConsulta()
        {
            LblPaciente.Text = this.Consulta.Paciente.Nome_Completo;
            LblData.Text = this.Consulta.Data.Split(' ')[0];
            LblHorario.Text = this.Consulta.Data.Split(' ')[1];
            LblDuracao.Text = this.Consulta.Duracao + "h";

            if (this.Consulta.Sintomas != null)
                TxtAreaSintomas.Text = this.Consulta.Sintomas;

            if (this.Consulta.Diagnostico != null)
                TxtAreaDiagnostico.Text = this.Consulta.Diagnostico;

            if (this.Consulta.Medicacao != null)
                TxtAreaMedicacao.Text = this.Consulta.Medicacao;

            if (this.Consulta.Observacoes != null)
                TxtAreaObservacoes.Text = this.Consulta.Observacoes;

            if (this.Consulta.Status == "REALIZADA")
                CheckBoxRealizada.Attributes.Add("checked", "checked");

            if (this.Consulta.Status == "PENDENTE")
            {
                BtnAtualizarConsulta.Enabled = true;

                TxtAreaSintomas.ReadOnly = false;
                TxtAreaDiagnostico.ReadOnly = false;
                TxtAreaMedicacao.ReadOnly = false;
                TxtAreaObservacoes.ReadOnly = false;
            }
            else
            {
                TxtAreaSintomas.ReadOnly = true;
                TxtAreaDiagnostico.ReadOnly = true;
                TxtAreaMedicacao.ReadOnly = true;
                TxtAreaObservacoes.ReadOnly = true;

                BtnAtualizarConsulta.Enabled = false;
                BtnAtualizarConsulta.Visible = false;

                CheckBoxRealizada.Attributes.Add("disabled", "true");
            }

            PanelConsulta.Visible = true;
        }

        protected void BtnAtualizarConsulta_Click(object sender, EventArgs e)
        {
            string sintomas = TxtAreaSintomas.Text;
            string diagnostico = TxtAreaDiagnostico.Text;
            string medicacao = TxtAreaMedicacao.Text;
            string observacoes = TxtAreaObservacoes.Text;
            bool realizada = CheckBoxRealizada.Checked;

            BDActions bd = new BDActions();
            try
            {
                bd.AtualizarConsulta(this.Consulta.Id, sintomas, diagnostico, medicacao, observacoes, realizada);

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