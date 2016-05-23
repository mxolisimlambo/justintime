using System;
using System.Collections.Generic;
using System.Linq;
using WebApp.Models;
using System.Web;

namespace WebApp.Business.IBusinessBl
{

    public interface IRegistrationBL :IDisposable
    {

        void Register(RegistrationViewModel model, HttpPostedFileBase image);
      

    }
}