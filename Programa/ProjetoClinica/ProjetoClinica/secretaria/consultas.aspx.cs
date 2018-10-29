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

        protected void SqlDataSourcePacientesConsulta_Selected(object sender, SqlDataSourceStatusEventArgs e)
        {
            if (e.Exception != null)
            {
                ddlPacienteConsulta.Items.Clear();
                ddlPacienteConsulta.Items.Add(new ListItem("Não foi possível carregar os pacientes!", "-1"));
                ddlPacienteConsulta.Items[0].Attributes.Add("disabled", "true");
                ddlPacienteConsulta.SelectedIndex = 0;

                e.ExceptionHandled = true;
            }
        }

        protected void SqlDataSourceMedicosConsulta_Selected(object sender, SqlDataSourceStatusEventArgs e)
        {
            if (e.Exception != null)
            {
                ddlMedicoConsulta.Items.Clear();
                ddlMedicoConsulta.Items.Add(new ListItem("Não foi possível carregar os médicos!", "-1"));
                ddlMedicoConsulta.Items[0].Attributes.Add("disabled", "true");
                ddlMedicoConsulta.SelectedIndex = 0;

                e.ExceptionHandled = true;
            }
        }
    }
}