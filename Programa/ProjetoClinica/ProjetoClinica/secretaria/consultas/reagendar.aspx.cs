using ProjetoClinica.DB;
using ProjetoClinica.DB.DBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoClinica.secretaria.consultas
{
    public partial class reagendar : System.Web.UI.Page
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
            BDActions bd = new BDActions();

            string query = Request.QueryString["id"];
            if (query == null || !int.TryParse(query, out int idConsulta))
                throw new Exception("Consulta não encontrada!");

            this.Consulta = bd.CarregarConsultaCompleta(idConsulta, -1, "SECRETARIA");
        }

        protected void CarregarCamposConsulta()
        {
            txtMedico.Text = this.Consulta.Medico.Nome_Completo;
            txtPaciente.Text = this.Consulta.Paciente.Nome_Completo;
            txtDataNovaConsulta.Text = this.Consulta.Data.Split(' ')[0];
            txtHorarioNovaConsulta.Text = this.Consulta.Data.Split(' ')[1];
            if (this.Consulta.Duracao == "00:30")
                ddlDuracao.SelectedIndex = 1;
            else if (this.Consulta.Duracao == "01:00")
                ddlDuracao.SelectedIndex = 2;
            else
                ddlDuracao.SelectedIndex = 0;

            PanelConsulta.Visible = true;
        }

        protected void BtnReagendarConsulta_Click(object sender, EventArgs e)
        {
            string dataconsulta = txtDataNovaConsulta.Text.Trim();
            string horaconsulta = txtHorarioNovaConsulta.Text.Trim();
            string duracao = ddlDuracao.SelectedValue;

            BDActions bd = new BDActions();
            try
            {
                bd.ReagendarConsulta(this.Consulta.Id, this.Consulta.Medico.Id, this.Consulta.Paciente.Id, dataconsulta, horaconsulta, duracao);

                CarregarConsulta();
                CarregarCamposConsulta();

                LblAviso.ForeColor = System.Drawing.ColorTranslator.FromHtml("#4BB543");
                LblAviso.Text = "Consulta reagendada com sucesso!";
            }
            catch (Exception ex)
            {
                LblAviso.ForeColor = System.Drawing.ColorTranslator.FromHtml("#CC0000");
                LblAviso.Text = ex.Message;
            }
        }
    }
}