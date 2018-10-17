using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Text;

namespace ProjetoClinica.email
{
    public class EmailSender
    {
        private SmtpClient client;
        private string myEmail;

        public EmailSender(string email, string senha)
        {
            if (!(isValidEmail(email)))
                    throw new Exception("E-mail inválido!");
            try
            {
                this.myEmail = email;
                this.client = new SmtpClient();

                this.client.Port = 587;
                this.client.Host = "smtp.gmail.com";
                this.client.EnableSsl = true;
                this.client.Timeout = 10000;
                this.client.DeliveryMethod = SmtpDeliveryMethod.Network;
                this.client.UseDefaultCredentials = false;
                this.client.Credentials = new System.Net.NetworkCredential(email, senha);
            }
            catch (Exception)
            {
                throw new Exception("Erro no login!");
            }
        }

        public void sendEmail(string emailTo, string subject, string body)
        {
            if (!(isValidEmail(emailTo)))
                throw new Exception("E-mail inválido!");
            try
            {
                MailMessage mm = new MailMessage(this.myEmail, emailTo, subject, body);
                mm.BodyEncoding = UTF8Encoding.UTF8;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                client.Send(mm);
            }
            catch (Exception)
            {
                throw new Exception("Erro ao enviar e-mail!");
            }
        }

        public void sendEmailClinica(string nomePaciente, string emailPaciente)
        {
            string subject = "Lembrete: " + nomePaciente + ", você tem uma consulta marcada!";
            string body = nomePaciente + ", nosso sistema diz que você tem uma consulta em nossa clínica daqui a dois dias! \n" +
                "Esperamos você aqui! Caso não puder comparecer, entre em contato conosco. \n \n" +
                "Atenciosamente, \n" +
                "Clínica Médica.";
            this.sendEmail(emailPaciente, subject, body);
        }

        private bool isValidEmail(string email)
        {
            const string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            var regex = new Regex(pattern, RegexOptions.IgnoreCase);

            return regex.IsMatch(email);
        }
    }
}