using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Business.IBusinessBl
{
    public interface IApplicationTableBL : IDisposable
    {
        void AddApplicant(ApplicationViewModel model);
        List<ApplicationViewModel> GetAllApplicants();
        ApplicationViewModel GetById(string id);
        void RemoveApplicant(int id);
        void UpdateApplicant(ApplicationViewModel model);
    }
}
