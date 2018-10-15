using ProjetoClinica.DB.DBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoClinica
{
    public partial class Paciente : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            object usuario = Session["Usuario"];

            if (Session.IsNewSession || usuario == null || usuario.GetType() != typeof(PacienteDBO))
            {
                Response.Redirect("/index.aspx");
            }
        }

        protected void LbSair_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("/index.aspx");
        }
    }
}