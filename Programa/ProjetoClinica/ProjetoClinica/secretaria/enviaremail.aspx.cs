using ProjetoClinica.email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoClinica.secretaria
{
	public partial class enviaremail : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void BtnEnviar_Click(object sender, EventArgs e)
        {
            string emailTo = "nicholaspruiz@gmail.com";
            string subject = "Lembrete: você tem uma consulta marcada!";
            string body = TxtAreaEmailBody.Text.Trim();

            try
            {
                EmailSender mailer = new EmailSender("clinicamedica@gmail.com", "ClinicaMedicaPR3");
                mailer.sendEmail(emailTo, subject, body);

                //

                LblAviso.ForeColor = System.Drawing.ColorTranslator.FromHtml("#4BB543");
                LblAviso.Text = "E-mail enviado com sucesso!";

                TxtAreaEmailBody.Text = "";
            }
            catch (Exception ex)
            {
                LblAviso.ForeColor = System.Drawing.ColorTranslator.FromHtml("#CC0000");
                LblAviso.Text = ex.Message;
            }
        }
    }
}