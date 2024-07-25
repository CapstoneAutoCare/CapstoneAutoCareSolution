using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.ISecurity;
using Infrastructure.IUnitofWork;
using Infrastructure.Common;

namespace Infrastructure.IService.Imp
{
    public class EmailServiceImp : IEmailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SendEmail _email;

        public EmailServiceImp(IUnitOfWork unitOfWork, SendEmail email)
        {
            _unitOfWork = unitOfWork;
            _email = email;
        }

        public async Task SendMail(string recipientEmail, string mess,string subj)
        {

            var fromAddress = new MailAddress(_email.From);
            var toAddress = new MailAddress(recipientEmail);

            var smtpClient = new SmtpClient(_email.Host, _email.Port)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_email.UserName, _email.Password),
                EnableSsl = true
            };

            var message = new MailMessage(fromAddress, toAddress)
            {
                
                Subject = subj,
                Body = mess,

            };

            await smtpClient.SendMailAsync(message);
        }
    }
}
