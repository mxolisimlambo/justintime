using System;
using System.Collections.Generic;
using WebApp.Models;
using WebApp.Data;
using System.Linq;
using System.Web;

namespace WebApp.Business.IBusinessBl
{
    public interface IStudentMark :IDisposable
    {
        void  AddStudentMark(StudentMarkViewModel model);
        //List<StudentMarkViewModel> GetAllStudentMark();
        StudentMarkViewModel GetStudentMarkById(int id);

        void EditMark(List<StudentMarks> mo);

        void RemoveStudentMark(int id);
        void UpdateStudentMark(StudentMarkViewModel model);
    }
}