using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Business.IBusinessBl
{
    public interface ISubjectBL:IDisposable
    {
        void AddSubject(SubjectsViewModel model);
        List<SubjectsViewModel> GetAllSubject();
        SubjectsViewModel GetById(int id);
        void RemoveSubject(int id);
        void UpdateSubject(SubjectsViewModel model);
    }
}