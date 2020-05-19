using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace StartProject.App_Start.Identity
{
    public class EmailServico : IIdentityMessageService
    {
        public readonly string EMAIL_REMETENTE = ConfigurationManager.AppSettings["emailServico:email_remetente"];
        public readonly string EMAIL_SENHA = ConfigurationManager.AppSettings["emailServico:email_senha"];

        public async Task SendAsync(IdentityMessage message)
        {
            
        }
    }
}