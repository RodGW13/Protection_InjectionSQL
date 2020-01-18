using System;
using System.Net.Mail;

namespace Common
{
    public class EnvioMail
    {
      
        /// <summary>
        /// Envia un correo electronico con los datos entregados
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="email"></param>
        /// <param name="body"></param>
        public void Send(string subject, string email, string body)
        {
            try
            {
                System.Net.IPHostEntry ipop;
                string strHostName = System.Net.Dns.GetHostName();

                ipop = System.Net.Dns.GetHostEntry(strHostName);
                var IP = ipop.AddressList[0].ToString();


                System.Net.IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);
                var IPp = Convert.ToString(ipEntry.AddressList[ipEntry.AddressList.Length - 1]);
                var Host = Convert.ToString(ipEntry.HostName);


                // Command line argument must the the SMTP host.
                //SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["SMTP"]);
                SmtpClient client = new SmtpClient("", 22);
                client.Credentials = new System.Net.NetworkCredential();
                // Specify the e-mail sender.

                //MailAddress from = new MailAddress(ConfigurationManager.AppSettings["CUENTA_CORREO"], "", System.Text.Encoding.UTF8);
                MailAddress from = new MailAddress("", "", System.Text.Encoding.UTF8);


                // Set destinations for the e-mail message.
                MailAddress to = new MailAddress(email);
                // Specify the message content.
                MailMessage message = new MailMessage(from, to);
                //message.IsBodyHtml = true;
                message.Body = body + " " + " Servidor: " + Host  + " ip Cliente: " + IP;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.Subject = subject;
                message.SubjectEncoding = System.Text.Encoding.UTF8;
            
                client.Send(message);

            }
            catch (SmtpException ez)
            {

                throw ez;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            
        }

      
    }
}
