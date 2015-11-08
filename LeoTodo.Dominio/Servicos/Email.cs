using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LeoTodo.Dominio.Servicos
{
    public static class Email
    {
        public static void EnviarEmail(string destinatario, string assunto, string mensagem)
        {
            MailMessage msg = new MailMessage();

            msg.From = new MailAddress("testemeulogin@gmail.com");
            msg.To.Add(destinatario);
            msg.Subject = assunto;
            msg.Body = mensagem;
            msg.Priority = MailPriority.High;

            using (System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient())
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("testemeulogin@gmail.com", "abc@123456789");
                smtp.Send(msg);
            }
        }
    }
}
