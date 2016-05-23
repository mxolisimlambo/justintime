using System;
using System.Collections.Generic;
using System.Linq;
using WebApp.Models;
using System.Web;

namespace WebApp.Business.IBusinessBl
{
    public interface IClassMarkBL :IDisposable
    {
        void AppClassMark(ClassMarkViewModel model);
            List<ClassMarkViewModel> GetAllClassMark();
    }
}