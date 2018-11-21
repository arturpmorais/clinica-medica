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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LbReagendar_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton link = (LinkButton)sender;
                int consulta = int.Parse(link.Attributes["Consulta"].ToString());

                Response.Redirect("reagendar?id=" + consulta);
            }
            catch (Exception)
            {
                LblAviso.ForeColor = System.Drawing.ColorTranslator.FromHtml("#CC0000");
                LblAviso.Text = "Consulta inválida!";
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
            {
                e.ExceptionHandled = true;
                GridViewConsultas.EmptyDataText = "Não foi possível carregar as agendas!";
            }
        }

        protected void SqlDataSourceConsultasPorMedico_Selected(object sender, SqlDataSourceStatusEventArgs e)
        {
            if (e.Exception != null)
            {
                e.ExceptionHandled = true;
                GridViewConsultasPorMedico.EmptyDataText = "Não foi possível carregar a agenda do médico!";
            }
        }
    }
}