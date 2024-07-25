using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface IEmailService
    {
        Task SendMail(string recipientEmail,string mess,string subj);
    }
}
