using System.Net;
using System.Net.Mail;

namespace LeoTodo.Dominio.InfraEstrutura
{
    public static class Email
    {
        public static void EnviarEmail(string destinatario, string assunto, string mensagem)
        {
            var dadosEmail = PreencheDadosEmail(destinatario, assunto, mensagem);

            using (var smtp = CriarSmtpClient())
            {
                smtp.Send(dadosEmail);
            }
        }

        private static MailMessage PreencheDadosEmail(string destinatario, string assunto, string mensagem)
        {
            var dadosEmail = new MailMessage();

            dadosEmail.From = new MailAddress("testemeulogin@gmail.com");
            dadosEmail.To.Add(destinatario);
            dadosEmail.Subject = assunto;
            dadosEmail.Body = mensagem;
            dadosEmail.Priority = MailPriority.High;

            return dadosEmail;
        }

        private static SmtpClient CriarSmtpClient()
        {
            return new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("testemeulogin@gmail.com", "abc@123456789")
            };
        }
    }
}