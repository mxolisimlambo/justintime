using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace WebApp.Business.IBusinessBl
{
    public class EmailBusiness
    {
        public MailAddress to { get; set; }
        public MailAddress from { get; set; }
        public string sub { get; set; }
        public string body { get; set; }
        public string ToAdmin()
        {
            string feedback = "";
            EmailBusiness me = new EmailBusiness();

            var m = new System.Net.Mail.MailMessage()
            {

                Subject = sub,
                Body = body,
                IsBodyHtml = true
            };
            to = new MailAddress("21445847@dut4life.ac.za", "Administrator");
            m.To.Add(to);
            m.From = new MailAddress(from.ToString());
            m.Sender = to;


            SmtpClient smtp = new SmtpClient
            {
                Host = "pod51014.outlook.com",
                Port = 587,
                Credentials = new System.Net.NetworkCredential("21445848@dut4life.ac.za", "Dut871003"),
                EnableSsl = true
            };

            try
            {
                smtp.Send(m);
                feedback = "Message sent to JGZuma";
            }
            catch (Exception e)
            {
                feedback = "Message not sent retry" + e.Message;
            }
            return feedback;
        }

    }
}