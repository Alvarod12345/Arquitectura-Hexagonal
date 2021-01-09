using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace CrossCutting.Services.OxiServi.SmtpServices
{
    public class MailParameters
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string ContentHtml { get; set; }
        public bool FlagAttachemnt { get; set; }
    }
    public class SmtpServices : ISmtpServices
    {
        public IConfiguration _configuration;
        public IHostingEnvironment _env;
        public SmtpServices(IConfiguration configuration, IHostingEnvironment env)
        {
            _env = env;
            _configuration = configuration;
        }
        public async Task SendMailAsync(MailParameters mailParameters)
        {
            try
            {
                if (!string.IsNullOrEmpty(mailParameters.To))
                {
                    var count = mailParameters.To.Split(',');

                    bool mock = false;
                    using (var sendMail = new MailMessage())
                    {
                        sendMail.From = new MailAddress(_configuration["SMTP_CORREO_EMISOR"]);
                        sendMail.Subject = mailParameters.Subject;
                        sendMail.SubjectEncoding = Encoding.UTF8;
                        sendMail.BodyEncoding = Encoding.UTF8;
                        sendMail.IsBodyHtml = true;
                        sendMail.Body = mailParameters.ContentHtml;

                        if (!mock)
                        {
                            sendMail.Priority = MailPriority.Normal;
                            sendMail.To.Add(mailParameters.To);

                            using (var client = new SmtpClient())
                            {
                                client.Credentials = new NetworkCredential(_configuration["SMTP_CREDENTIAL_EMAIL"], _configuration["SMTP_CREDENTIAL_PASSWORD"]);
                                client.Host = _configuration["SMTP_HOST"];
                                client.Port = int.Parse(_configuration["SMTP_PORT"]);
                                client.EnableSsl = true;
                                await client.SendMailAsync(sendMail);
                            }
                        }
                        else
                        {
                            sendMail.Priority = MailPriority.Low;
                            foreach (var toMail in mailParameters.To.Split(','))
                            {
                                sendMail.To.Add(toMail);
                            }

                            using (var client = new SmtpClient())
                            {
                                client.Credentials = new NetworkCredential(_configuration["SMTP_CREDENTIAL_EMAIL"], _configuration["SMTP_CREDENTIAL_PASSWORD"]);
                                client.Host = _configuration["SMTP_HOST"];
                                client.Port = int.Parse(_configuration["SMTP_PORT"]);
                                client.EnableSsl = true;
                                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                                client.DeliveryFormat = SmtpDeliveryFormat.International;
                                client.EnableSsl = true;
                                await client.SendMailAsync(sendMail);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task SendMailSendGridAsync(MailParameters mailParameters)
        {
            var client = new SendGridClient("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");
            var from = new EmailAddress("samuelomarparionarojas@gmail.com", "Samuel Pariona");
            var subject = mailParameters.Subject;
            var to = new EmailAddress(mailParameters.To, "Harold Portillo");
            var htmlContent = mailParameters.ContentHtml;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, "asdasd", htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
