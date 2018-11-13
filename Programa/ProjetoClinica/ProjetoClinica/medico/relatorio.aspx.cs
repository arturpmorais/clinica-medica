using ProjetoClinica.DB.DBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoClinica.medico
{
    public partial class relatorio : System.Web.UI.Page
    {
        private MedicoDBO Medico;

        protected void Page_Init(object sender, EventArgs e)
        {
            this.Medico = (MedicoDBO)Session["Usuario"];

            SqlDataSourcePacientes.SelectParameters["idMedico"].DefaultValue = this.Medico.Id.ToString();
            SqlDataSourceConsultasPorPaciente.SelectParameters["idMedico"].DefaultValue = this.Medico.Id.ToString();

            SqlDataSourcePacientes.DataBind();
            SqlDataSourceConsultasPorPaciente.DataBind();
        }
        protected void SqlDataSourcePacientes_Selected(object sender, SqlDataSourceStatusEventArgs e)
        {
            if (e.Exception != null)
            {
                ddlPacientes.Items.Clear();
                ddlPacientes.Items.Add(new ListItem("Não foi possível carregar os pacientes!", "-1"));
                ddlPacientes.Items[0].Attributes.Add("disabled", "true");
                ddlPacientes.SelectedIndex = 0;

                e.ExceptionHandled = true;
            }
        }
    }
}