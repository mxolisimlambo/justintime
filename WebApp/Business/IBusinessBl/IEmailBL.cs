using System;
using System.Collections.Generic;
using WebApp.Models;
using System.Linq;
using System.Web;

namespace WebApp.Business.IBusinessBl
{
    public interface IEmailBL :IDisposable

    {
        void SendMail(EmailViewmodel model);

      
    }
}