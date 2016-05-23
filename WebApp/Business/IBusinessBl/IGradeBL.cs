using System;
using System.Collections.Generic;
using WebApp.Models;
using System.Linq;
using System.Web;

namespace WebApp.Business.IBusinessBl
{
    public interface IGradeBL:IDisposable
    {

        void AddGroup(GradesViewModels model);
        List<GradesViewModels> GetAllGroup();
        //GradesViewModels GetById(string id);
        GradesViewModels GetById(int id);
        void RemoveGroup(int id);
        void UpdateGroup(GradesViewModels model);
    }
}