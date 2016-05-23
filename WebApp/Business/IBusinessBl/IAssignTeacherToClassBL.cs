using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Business.IBusinessBl
{
    public interface IAssignTeacherToClassBL
    {
        void AssignTeacherToClass(AssignTeacherToClassViewmodel model);
        List<AssignTeacherToClassViewmodel> GetAllAssignedTeacher();
        //GradesViewModels GetById(string id);
        AssignTeacherToClassViewmodel GetById(int id);
    }
}