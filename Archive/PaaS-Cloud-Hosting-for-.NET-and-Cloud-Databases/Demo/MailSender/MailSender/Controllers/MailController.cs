using MailSender.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Typesafe.Mailgun;

namespace MailSender.Controllers
{
    public class MailController : ApiController
    {
        public void Post([FromBody] MailModel mail)
        {
            if (ConfigurationManager.AppSettings["MAIL_SENDER_ENABLED"] == "true")
            {
                var mailClient = new MailgunClient("app14337.mailgun.org", ConfigurationManager.AppSettings["MAILGUN_API_KEY"]);
                mailClient.SendMail(new System.Net.Mail.MailMessage(mail.From, mail.To)
                {
                    Subject = mail.Subject,
                    Body = mail.Body
                });
            }
            else
            {
                throw new InvalidOperationException("MailSender is disabled");
            }
        }
    }
}
