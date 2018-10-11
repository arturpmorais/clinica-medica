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
        protected void Page_Load(object sender, EventArgs e)
        {
            object usuario = Session["Usuario"];
            Type medico = Type.GetType("MedicoDBO");

            if (Session.IsNewSession || usuario == null || !usuario.GetType().Equals(medico))
            {
                Response.Redirect("/index.aspx");
            }
        }
    }
}