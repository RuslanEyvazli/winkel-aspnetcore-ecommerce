using NuGet.Common;
using System.Net;
using System.Net.Mail;
using WINKEL_ECOMMERCE.Models;

namespace WINKEL_ECOMMERCE.Extensions
{
    public static partial class ISendEmail
    {
        public static bool SendEmail(this IConfiguration configuration,string to, string subject, string body, bool appendCC = false)
        {
            try
            {

                string fromMail = configuration["emailAccount:userName"];
                string displayName = configuration["emailAccount:displayName"];
                string smtpServer = configuration["emailAccount:smtpServer"];
                int smtpPort = Convert.ToInt32(configuration["emailAccount:smtpPort"]);
                string password = configuration["emailAccount:password"];
                string cc = configuration["emailAccount:cc"];
                MailAddress fromMailAddress = new MailAddress(fromMail, displayName);
                MailAddress toMailAddress = new MailAddress(to);
                using (MailMessage message = new MailMessage(fromMailAddress, toMailAddress))
                {
                    message.Subject = subject;
                    message.Body = body;
                    message.IsBodyHtml = true;

                    if (!string.IsNullOrWhiteSpace(cc))
                        message.CC.Add(cc);

                    SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);
                    smtpClient.Credentials = new NetworkCredential(fromMail, password);
                    smtpClient.EnableSsl = true;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Send(message);
                }


                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
