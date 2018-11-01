using ProjetoClinica.DB;
using ProjetoClinica.DB.DBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoClinica.medico.consultas
{
    public partial class agenda : System.Web.UI.Page
    {
        private ConsultaDBO[] Consultas;

        protected void Page_Load(object sender, EventArgs e)
        {
            MedicoDBO usuario = (MedicoDBO)Session["Usuario"];
            BDActions bd = new BDActions();

            try
            {
                this.Consultas = bd.CarregarConsultas(usuario.Id, "MEDICO");
            }
            catch (Exception ex)
            {
                LblAviso.ForeColor = System.Drawing.ColorTranslator.FromHtml("#CC0000");
                LblAviso.Text = ex.Message;
            }
        }
    }
}