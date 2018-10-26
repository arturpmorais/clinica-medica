using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoClinica.DB.DBO;

namespace ProjetoClinica
{
    public partial class Medico : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            Session["Usuario"] = new MedicoDBO(1, "Caio Petrucci dos Santos Rosa", "caiopetruccirosa@gmail.com", "24/09/2002", "Rua Manoel Soares da Rocha, 63", "(19) 99302-1717", "(19) 99302-1717", null, new EspecialidadeDBO(1, "Cardiologista"));

            object usuario = Session["Usuario"];

            if (Session.IsNewSession || usuario == null || usuario.GetType() != typeof(MedicoDBO))
                Response.Redirect("/index.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MedicoDBO m = (MedicoDBO)Session["Usuario"];

            if (m.Imagem == null)
                ImgPerfil.ImageUrl = "/images/default_profile_picture.png";

            LblNome.Text = m.Nome_Completo.Split(' ')[0];
        }

        protected void LbSair_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("/index.aspx");
        }
    }
}