using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoClinica.secretaria.consultas
{
    public partial class historicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SqlDataSourceConsultas_Selected(object sender, SqlDataSourceStatusEventArgs e)
        {
            if (e.Exception != null)
            {
                e.ExceptionHandled = true;
                GridViewConsultas.EmptyDataText = "Não foi possível carregar os históricos!";
            }
        }

        protected void SqlDataSourceConsultasPorMedico_Selected(object sender, SqlDataSourceStatusEventArgs e)
        {
            if (e.Exception != null)
            {
                e.ExceptionHandled = true;
                GridViewConsultasPorMedico.EmptyDataText = "Não foi possível carregar o histórico do médico!";
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
    }
}