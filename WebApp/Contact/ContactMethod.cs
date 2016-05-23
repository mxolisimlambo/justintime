using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace WebApp.Contact
{
    public class ContactMethod
    {

        public static void SendEmail()
        {
            //emv.Message = "Dear Admin  :" + model.Parent_Email + "\n" +
            //                  "New Applicant has Submited An Application" + "\n" +
            //                   "Please Check Application ";
            //emv.Subject = "New Applicant";
            //emv.To = "21445847@dut4life.ac.za"; /*"yasinayami@gmail.com"*/;
            //email.SendMail(emv);
        }

        public static void SendEmailToUs()
        {
            //emv.Message = "Dear Admin  :" + model.Parent_Email + "\n" +
            //                  "New Applicant has Submited An Application" + "\n" +
            //                   "Please Check Application ";
            //emv.Subject = "New Applicant";
            //emv.To = "21445847@dut4life.ac.za"; 
            //email.SendMail(emv);
        }

        public static void SendSms(string to, string message)
        {
            MailMessage msg = new MailMessage { From = new MailAddress("21105037@dut4life.ac.za", "no-reply@jgzhs.co.za"), Body = message };
            msg.To.Add(new MailAddress(to + "@winsms.net"));

            SmtpClient client = new SmtpClient
            {
                Host = "pod51014.outlook.com",
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential("21105037@dut4life.ac.za", "Dut930814"),
                EnableSsl = true
            };
            client.Send(msg);
        }

        public static void SendSmsToUs(string message)
        {
            MailMessage msg = new MailMessage { From = new MailAddress("21105037@dut4life.ac.za", "no-reply@jgzhs.co.za"), Body = message };
            msg.To.Add(new MailAddress("groupmember2@example.com"));

            SmtpClient client = new SmtpClient
            {
                Host = "pod51014.outlook.com",
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential("21105037@dut4life.ac.za", "Dut930814"),
                EnableSsl = true
            };
            client.Send(msg);
        }
    }
}