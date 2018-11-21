using ProjetoClinica.DB.DBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoClinica
{
    public partial class Secretaria : System.Web.UI.MasterPage
    {

        protected void Page_Init(object sender, EventArgs e)
        {
            Session["Usuario"] = new SecretariaDBO("17167", "Caio");

            object usuario = Session["Usuario"];

            if (Session.IsNewSession || usuario == null || usuario.GetType() != typeof(SecretariaDBO))
            {
                Response.Redirect("/index.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            SecretariaDBO s = (SecretariaDBO)Session["Usuario"];

            LblCodigo.Text = s.Codigo.ToUpper();
            LblNome.Text = s.Nome_Completo.Split(' ')[0];
        }

        protected void LbSair_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("/index.aspx");
        }
    }
}