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
    public partial class agenda : System.Web.UI.Page
    {
        private ConsultaDBO[] Consultas;

        protected void Page_Load(object sender, EventArgs e)
        {
            MedicoDBO usuario = (MedicoDBO)Session["Usuario"];
            BDActions bd = new BDActions();

            try
            {
                this.Consultas = bd.CarregarAgenda(usuario.Id, "MEDICO");

                HtmlGenericControl button = new HtmlGenericControl("a");
                button.Attributes.Add("class", "secondary-content btn-floating btn-large waves-effect waves-light btn-arrow");
                button.Attributes.Add("href", "consulta?id=" + this.Consultas[0].Id);
                button.InnerHtml = "<i class=\"material-icons\" style=\"font-size: 48px;\">arrow_forward</i>";

                HtmlGenericControl container_button = new HtmlGenericControl("div");
                container_button.Attributes.Add("class", "col s2");
                container_button.InnerHtml = "<br/><br/><br/>";
                container_button.Controls.Add(button);

                HtmlGenericControl card_title = new HtmlGenericControl("div");
                card_title.Attributes.Add("class", "card-title col s10");
                card_title.InnerHtml = "<h4>Próxima consulta:</h4>" +
                                       "&nbsp;Paciente: " + this.Consultas[0].Paciente.Nome_Completo +
                                       "<br/> &nbsp;Data: " + this.Consultas[0].Data.Split(' ')[0] +
                                       "<br/> &nbsp;Horário: " + this.Consultas[0].Data.Split(' ')[1] +
                                       "<br/> &nbsp;Duração: " + this.Consultas[0].Duracao+"h";

                HtmlGenericControl row = new HtmlGenericControl("div");
                row.Attributes.Add("class", "row");
                row.Attributes.Add("style", "margin-bottom: 0;");
                row.Controls.Add(card_title);
                row.Controls.Add(container_button);

                HtmlGenericControl card_content = new HtmlGenericControl("div");
                card_content.Attributes.Add("class", "card-content");
                card_content.Controls.Add(row);

                HtmlGenericControl card = new HtmlGenericControl("div");
                card.Attributes.Add("class", "card prox-consulta");
                card.Controls.Add(card_content);

                HtmlGenericControl collection = new HtmlGenericControl("ul");
                collection.Attributes.Add("class", "collection");
                collection.Controls.Add(card);

                if (this.Consultas.Length <= 1)
                {
                    HtmlGenericControl aviso = new HtmlGenericControl("li");
                    aviso.Attributes.Add("class", "collection-item avatar red-text");
                    aviso.Attributes.Add("style", "padding: 12px 0;");

                    aviso.InnerHtml = "<center><h6>Você não possui mais consultas!</h6></center>";

                    collection.Controls.Add(aviso);
                } else
                {
                    for (int i = 1; i < this.Consultas.Length; i++)
                    {
                        HtmlGenericControl item = new HtmlGenericControl("li");
                        item.Attributes.Add("class", "collection-item avatar");

                        HtmlGenericControl img = new HtmlGenericControl("i");
                        img.Attributes.Add("class", "material-icons circle cyan custom-reallydarkcyan");
                        img.InnerHtml = "access_time";

                        HtmlGenericControl title = new HtmlGenericControl("span");
                        title.InnerHtml = "Consulta: " + this.Consultas[i].Data.Split(' ')[0];

                        HtmlGenericControl content = new HtmlGenericControl("p");
                        content.InnerHtml = "&nbsp;Horário: " + this.Consultas[i].Data.Split(' ')[1] +
                                            "<br/> &nbsp;Paciente: " + this.Consultas[i].Paciente.Nome_Completo +
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