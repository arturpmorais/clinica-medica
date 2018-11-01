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
    public partial class consulta : System.Web.UI.Page
    {
        private ConsultaDBO Consulta;

        protected void Page_Load(object sender, EventArgs e)
        {
            MedicoDBO usuario = (MedicoDBO)Session["Usuario"];
            BDActions bd = new BDActions();

            try
            {
                int idConsulta = int.Parse(Request.QueryString["id"]);
                this.Consulta = bd.CarregarConsulta(idConsulta, usuario.Id, "MEDICO");
                PanelConsulta.Visible = true;
            }
            catch (Exception ex)
            {
                LblAviso.ForeColor = System.Drawing.ColorTranslator.FromHtml("#CC0000");
                LblAviso.Text = ex.Message;
            }
        }
    }
}