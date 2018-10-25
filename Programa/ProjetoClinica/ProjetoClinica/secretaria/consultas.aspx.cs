using ProjetoClinica.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoClinica.secretaria
{
    public partial class consultas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnMarcarConsulta_Click(object sender, EventArgs e)
        {
            string dataconsulta = txtDataNovaConsulta.Text.Trim();
            string horaconsulta = txtHorarioNovaConsulta.Text.Trim();
            string duracao = ddlDuracao.SelectedValue;
            int idPaciente = int.Parse(ddlPacienteConsulta.SelectedValue);
            int idMedico = int.Parse(ddlMedicoConsulta.SelectedValue);

            BDActions bd = new BDActions();
            try
            {
                bd.MarcarConsulta(idMedico, idPaciente, dataconsulta, horaconsulta, duracao);

                // fecha o modal
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "closeModal('#modalNovaConsulta');", true);

                LblAvisoMarcarConsulta.Text = "";
                txtDataNovaConsulta.Text = "";
                txtHorarioNovaConsulta.Text = "";
                ddlMedicoConsulta.SelectedIndex = 0;
                ddlPacienteConsulta.SelectedIndex = 0;

                LblAviso.Text = "Consulta marcada com sucesso!";
            }
            catch (Exception ex)
            {
                LblAvisoMarcarConsulta.Text = ex.Message;
            }
        }
    }
}