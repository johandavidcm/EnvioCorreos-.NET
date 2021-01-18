using System;
using System.Net.Mail;
using System.Text;

namespace Prac
{
    class Program
    {
        static void Main(string[] args)
        {
            var smtpUser = "CorreoDesde";
            var smtpPassword = "contraseñaCorreo";
            var smtpServer = "smtp.gmail.com";
            int smtpPort = 587;

            using( var smtp = new SmtpClient(smtpServer))
            {
                smtp.Port = smtpPort;
                smtp.UseDefaultCredentials = false;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new System.Net.NetworkCredential(smtpUser, smtpPassword);
                smtp.EnableSsl = true;
                SendEmail("CorreoDesde", smtp, "CorreoDirigidoA", "");
                Console.WriteLine("Correo enviado correctamente");
            }

            System.Net.NetworkCredential creds = new System.Net.NetworkCredential(smtpUser, smtpPassword);
            Console.ReadKey();
        }

        private static void SendEmail(string correo, SmtpClient smtp, string correoOrigen, string nombreCorreo)
        {
            try
            {
                MailMessage msg = new MailMessage();
                msg.Subject = "Prueba";
                msg.From = new MailAddress(correoOrigen, "Johan David", Encoding.UTF8);
                msg.To.Add(new MailAddress(correo));
                msg.Body = "Probando el cuerpo";
                msg.IsBodyHtml = true;
                smtp.Send(msg);
            }
            catch (Exception EX)
            {
                Console.WriteLine(EX.Message + EX.StackTrace + (EX.InnerException != null ? EX.InnerException.ToString() : ""));
            }
        }
    }
}
