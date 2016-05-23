using System;
using System.Collections.Generic;
using WebApp.Models;
using System.Linq;
using System.Web;

namespace WebApp.Business.IBusinessBl
{
    public interface IClassGroup :IDisposable
    {

        void AddClassGroup(ClassGroupViewModels model);
        List<ClassGroupViewModels> GetAllClassGroup();
        ClassGroupViewModels GetById(int id);
        void RemoveClassGroup(int id);
        void UpdateClassGroup(ClassGroupViewModels model);

    }
}