using ProjetoClinica.DB.DBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoClinica
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            object usuario = Session["Usuario"];

            if (!Session.IsNewSession && usuario != null)
            {
                if (usuario.GetType() == typeof(PacienteDBO))
                    Response.Redirect("/paciente/index.aspx");

                if (usuario.GetType() == typeof(MedicoDBO))
                    Response.Redirect("/medico/index.aspx");

                if (usuario.GetType() == typeof(SecretariaDBO))
                    Response.Redirect("/secretaria/index.aspx");
            }
        }
    }
}