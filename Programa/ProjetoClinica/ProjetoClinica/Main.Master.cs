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
        protected void Page_Load(object sender, EventArgs e)
        {
            object usuario = Session["Usuario"];

            if (!Session.IsNewSession && usuario != null)
            {
                Type paciente = Type.GetType("PacienteDBO");
                Type medico = Type.GetType("MedicoDBO");
                Type secretaria = Type.GetType("SecretariaDBO");

                if (usuario.GetType().Equals(paciente))
                    Response.Redirect("/paciente/index.aspx");

                if (usuario.GetType().Equals(medico))
                    Response.Redirect("/medico/index.aspx");

                if (usuario.GetType().Equals(secretaria))
                    Response.Redirect("/secretaria/index.aspx");
            }
        }
    }
}