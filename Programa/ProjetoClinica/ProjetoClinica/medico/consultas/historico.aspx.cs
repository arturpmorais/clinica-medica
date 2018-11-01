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
    public partial class historico : System.Web.UI.Page
    {
        private ConsultaDBO[] Consultas;

        protected void Page_Load(object sender, EventArgs e)
        {
            MedicoDBO usuario = (MedicoDBO)Session["Usuario"];
            BDActions bd = new BDActions();

            try
            {
                this.Consultas = bd.CarregarHistorico(usuario.Id, "MEDICO");

                for (int i = 0; i < this.Consultas.Length; i++)
                {
                    this.Consultas[i] = null;
                }
            }
            catch (Exception ex)
            {
                LblAviso.ForeColor = System.Drawing.ColorTranslator.FromHtml("#CC0000");
                LblAviso.Text = ex.Message;
            }
        }
    }
}