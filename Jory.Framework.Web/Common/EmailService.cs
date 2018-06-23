using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Jory.Framework.Web.Common
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            var credentialUserName = "邮箱登录名";
            var sentFrom = "你的邮箱地址";
            var pwd = "邮箱登录密码";

            System.Net.Mail.SmtpClient client =
                new System.Net.Mail.SmtpClient("smtp服务器地址");

            client.Port = 25;//smtp邮件服务器端口
            client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;

            System.Net.NetworkCredential credentials =
                new System.Net.NetworkCredential(credentialUserName, pwd);

            client.EnableSsl = true;
            client.Credentials = credentials;

            var mail =
                new System.Net.Mail.MailMessage(sentFrom, message.Destination);

            mail.Subject = message.Subject;
            mail.Body = message.Body;
            return client.SendMailAsync(mail);
        }
    }
}