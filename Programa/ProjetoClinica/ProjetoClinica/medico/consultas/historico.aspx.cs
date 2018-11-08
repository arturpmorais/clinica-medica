using ProjetoClinica.DB;
using ProjetoClinica.DB.DBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
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

                HtmlGenericControl collection = new HtmlGenericControl("ul");
                collection.Attributes.Add("class", "collection");

                for (int i = 0; i < this.Consultas.Length; i++)
                {
                    HtmlGenericControl item = new HtmlGenericControl("li");
                    item.Attributes.Add("class", "collection-item avatar");

                    HtmlGenericControl img = new HtmlGenericControl("i");
                    img.Attributes.Add("class", "material-icons circle cyan custom-reallydarkcyan");
                    img.InnerHtml = "access_time";

                    HtmlGenericControl title = new HtmlGenericControl("span");
                    if (this.Consultas[i].Status == "REALIZADA")
                        title.InnerHtml = "Consulta: <label class=\"green-text title-size\">" + this.Consultas[i].Status + "</label>";
                    else if (this.Consultas[i].Status == "CANCELADA")
                        title.InnerHtml = "Consulta: <label class=\"red-text title-size\">" + this.Consultas[i].Status + "</label>";
                    title.Attributes.Add("class", "title title-size");

                    HtmlGenericControl content = new HtmlGenericControl("p");
                    content.InnerHtml = "&nbsp;Paciente: " +  this.Consultas[i].Paciente.Nome_Completo +
                                        "<br/> &nbsp;Data: " + this.Consultas[i].Data.Split(' ')[0] +
                                        "<br/> &nbsp;Horário: " + this.Consultas[i].Data.Split(' ')[1] +
                                        "<br/> &nbsp;Duração: " + this.Consultas[i].Duracao + "h";


                    HtmlGenericControl arrow = new HtmlGenericControl("a");
                    arrow.Attributes.Add("href", "consulta?id=" + this.Consultas[i].Id);
                    arrow.Attributes.Add("class", "secondary-content btn-floating waves-effect waves-light btn-arrow");
                    arrow.InnerHtml = "<i class=\"material-icons\">arrow_forward</i>";

                    item.Controls.Add(img);
                    item.Controls.Add(title);
                    item.Controls.Add(content);
                    item.Controls.Add(arrow);

                    collection.Controls.Add(item);
                }

                PanelConsultas.Controls.Add(collection);
                PanelConsultas.Visible = true;
            }
            catch (Exception ex)
            {
                LblAviso.ForeColor = System.Drawing.ColorTranslator.FromHtml("#CC0000");
                LblAviso.Text = ex.Message;
            }
        }
    }
}