using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Business.IBusinessBl
{
    public interface IApplicationBL
    {
        void MakeApplication(MakeApplicationViewModel model);
        List<AllApplicationsViewModel> GetAllApplications();
        ViewApplicationViewModel GetApplication(string id);
        void UpdateStatus(ViewApplicationViewModel viewmodel);
        //ApplicationViewModels GetById(string id);
        //void RemoveApplicant(int id);
        //void UpdateApplicant(ApplicationViewModels model);
    }
}
