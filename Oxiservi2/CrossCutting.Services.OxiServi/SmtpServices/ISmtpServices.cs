using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.Services.OxiServi.SmtpServices
{
    public interface ISmtpServices
    {
        Task SendMailAsync(MailParameters mailParameters);
        Task SendMailSendGridAsync(MailParameters mailParameters);
    }
}
