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
        protected void Page_Init(object sender, EventArgs e)
        {
            Session["Usuario"] = new PacienteDBO(1, "Caio Petrucci dos Santos Rosa", "caiopetruccirosa@gmail.com", "24/09/2002", "Rua Manoel Soares da Rocha, 63", "(19) 99302-1717", "(19) 99302-1717", "/images/default_profile_picture.png");

            object usuario = Session["Usuario"];

            if (Session.IsNewSession || usuario == null || usuario.GetType() != typeof(PacienteDBO))
                Response.Redirect("/index.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            PacienteDBO p = (PacienteDBO)Session["Usuario"];

            ImgPerfil.ImageUrl = p.Imagem;
            LblNome.Text = p.Nome_Completo.Split(' ')[0];
        }

        protected void LbSair_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("/index.aspx");
        }
    }
}