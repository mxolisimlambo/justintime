using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Business.IBusinessBl
{
    public interface IAssignTeacherToSubjectBL
    {
        void AssignTeacherToSubject(AssignTeacherToSubjectViewModel model);
        List<AssignTeacherToSubjectViewModel> GetAllAssignedTeacherToSubject();
        //GradesViewModels GetById(string id);
        AssignTeacherToSubjectViewModel GetById(int id);
    }
}