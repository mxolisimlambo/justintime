using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Business.IBusinessBl
{
    public interface IStaffBL:IDisposable
    {
        void AddNewStaffprofile(StaffViewModel model, HttpPostedFileBase image);
        List<StaffViewModel> GetAllStaff();
       
    }
}