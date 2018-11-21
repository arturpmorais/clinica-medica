using ProjetoClinica.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoClinica.secretaria.consultas
{
    public partial class agendas : System.Web.UI.Page
    {
        private int MedicoConsultaASerReagendada = -1;
        private int PacienteConsultaASerReagendada = -1;
        private int ConsultaASerReagendada = -1;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LbReagendar_Click(object sender, EventArgs e)
        {
            LinkButton link = (LinkButton)sender;
            string NomeMedico = null;
            string NomePaciente = null;

            try
            {
                ConsultaASerReagendada = int.Parse(link.Attributes["Consulta"].ToString());
                MedicoConsultaASerReagendada = int.Parse(link.Attributes["MedicoID"].ToString());
                NomeMedico = link.Attributes["Medico"].ToString();
                PacienteConsultaASerReagendada = int.Parse(link.Attributes["PacienteID"].ToString());
                NomePaciente = link.Attributes["Paciente"].ToString();

                txtMedico.Text = NomeMedico;
                txtPaciente.Text = NomePaciente;

                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "openModal('#modalReagendarConsulta')", true);
            }
            catch (Exception)
            {
                LblAviso.ForeColor = System.Drawing.ColorTranslator.FromHtml("#CC0000");
                LblAviso.Text = "Consulta inválida!";
            }
        }

        protected void LbReagendarConsulta_Click(object sender, EventArgs e)
        {
            string dataconsulta = txtDataNovaConsulta.Text.Trim();
            string horaconsulta = txtHorarioNovaConsulta.Text.Trim();
            string duracao = ddlDuracao.SelectedValue;

            BDActions bd = new BDActions();
            try
            {
                bd.ReagendarConsulta(ConsultaASerReagendada, MedicoConsultaASerReagendada, PacienteConsultaASerReagendada, dataconsulta, horaconsulta, duracao);

                // fecha o modal
                LblAvisoModal.Text = "";
                txtMedico.Text = "";
                txtPaciente.Text = "";
                txtDataNovaConsulta.Text = "";
                txtHorarioNovaConsulta.Text = "";
                ddlDuracao.SelectedIndex = 0;

                MedicoConsultaASerReagendada = -1;
                PacienteConsultaASerReagendada = -1;
                ConsultaASerReagendada = -1;

                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "closeModal('#modalReagendarConsulta')", true);

                SqlDataSourceConsultas.Update();
                SqlDataSourceConsultasPorMedico.Update();
                GridViewConsultas.DataBind();
                GridViewConsultasPorMedico.DataBind();

                LblAviso.ForeColor = System.Drawing.ColorTranslator.FromHtml("#4BB543");
                LblAviso.Text = "Consulta reagendada com sucesso!";
            }
            catch (Exception ex)
            {
                LblAvisoModal.Text = ex.Message;
            }
        }

        protected void LbCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton link = (LinkButton)sender;
                BDActions bd = new BDActions();

                int id = int.Parse(link.Attributes["Consulta"].ToString());
                bd.CancelarConsulta(id);

                SqlDataSourceConsultas.Update();
                SqlDataSourceConsultasPorMedico.Update();
                GridViewConsultas.DataBind();
                GridViewConsultasPorMedico.DataBind();

                LblAviso.ForeColor = System.Drawing.ColorTranslator.FromHtml("#4BB543");
                LblAviso.Text = "Consulta cancelada!";
            }
            catch (Exception)
            {
                LblAviso.ForeColor = System.Drawing.ColorTranslator.FromHtml("#CC0000");
                LblAviso.Text = "Não foi possível cancelar a consulta!";
            }
        }

        protected void SqlDataSourceMedicos_Selected(object sender, SqlDataSourceStatusEventArgs e)
        {
            if (e.Exception != null)
            {
                ddlMedicos.Items.Clear();
                ddlMedicos.Items.Add(new ListItem("Não foi possível carregar os médicos!", "-1"));
                ddlMedicos.Items[0].Attributes.Add("disabled", "true");
                ddlMedicos.SelectedIndex = 0;

                e.ExceptionHandled = true;
            }
        }

        protected void SqlDataSourceConsultas_Selected(object sender, SqlDataSourceStatusEventArgs e)
        {
            if (e.Exception != null)
                e.ExceptionHandled = true;
        }

        protected void SqlDataSourceConsultasPorMedico_Selected(object sender, SqlDataSourceStatusEventArgs e)
        {
            if (e.Exception != null)
                e.ExceptionHandled = true;
        }
    }
}