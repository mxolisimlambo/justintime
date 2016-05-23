using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using WebApp.Models;

namespace WebApp.Business.BusinessBL
{
    public class EmailBL
    {

        public void SendMail(EmailViewmodel model)
        {
            try
            {
                var m = new MailMessage
                {
                    Subject = "Login Credentials",
                    Body = model.Message,
                    IsBodyHtml = true,
                    From = new MailAddress("21217040@dut4life.ac.za", "JG-Administrator")
                };
                m.To.Add(model.To);

                var smtp = new SmtpClient
                {
                    Host = "pod51014.outlook.com",
                    Credentials = new NetworkCredential("21217040@dut4life.ac.za", "Dut921208"),
                    EnableSsl = true,
                    Port = 587
                };

                smtp.Send(m);
            }
            catch
            {
                //send sms instead
            }
        }

        public void RecieveMail(EmailViewmodel model)
        {
            MakeApplicationViewModel mo = new MakeApplicationViewModel();

            try
            {
                var m = new MailMessage
                {
                    Subject = "New Applicant",
                    Body = model.Message,
                    IsBodyHtml = true,
                    From = new MailAddress(mo.Phone, "Applicant")
                };
                m.To.Add(model.To);

                var smtp = new SmtpClient
                {
                    Host = "pod51014.outlook.com",
                    Credentials = new NetworkCredential("21217040@dut4life.ac.za", "Dut921208"),
                    EnableSsl = true,
                    Port = 587
                };

                smtp.Send(m);
            }
            catch
            {
                //send sms instead
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}