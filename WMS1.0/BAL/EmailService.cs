using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Web;

namespace WMS1._0.BAL
{
    public class EmailService
    {
        public bool sendMail(string to, string from, string subject, string body)
        {

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("djayholepatil@gmail.com", "Djayraje321djay"),
                EnableSsl = false
            };
            client.Send(from,to,subject,body);     

            return true;
        }
        public static Boolean SendingMail(string From, string To, string Subject, string Body)
        {

            try
            {
                MailMessage m = new MailMessage("djayholepatil@gmail.com", To);
                m.Subject = Subject;
                m.Body = Body;
                m.IsBodyHtml = true;
                m.From = new MailAddress(From);

                m.To.Add(new MailAddress(To));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                NetworkCredential authinfo = new NetworkCredential("djayholepatil@gmail.com", "Djayraje321djay");
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = authinfo;
                smtp.Send(m);
                return true;




            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}