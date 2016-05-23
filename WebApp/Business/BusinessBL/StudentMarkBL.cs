using System;
using System.Collections.Generic;
using System.Linq;
using WebApp.Business.IBusinessBl;
using WebApp.UnitOfWork;
using WebApp.Data;
using System.Web;
using WebApp.Models;

namespace WebApp.Business.BusinessBL
{
    public class StudentMarkBL : IStudentMark
    {

        UnitOfWork.UnitOfWork uow = new UnitOfWork.UnitOfWork();

        public void AddStudentMark(StudentMarkViewModel model)
        {
            int? m = model.mark;
            string res = "";
            if (m >= 50)
            {
                res = model.result = "Pass";
            }
            else if (m < 50)
            {
                res = model.result = "Fail";
            }
            else if (m == 0)
            {
                res = "";
            }
            var tb = new StudentMarks
            {

                Student_Number = model.Student_Number,
                Student_Name = model.Student_Name,
                Subject_Code = model.Subject_Code,
                GroupeName = model.GroupeName,
                ClassGroupe_id = model.ClassGroupe_id,
                mark = model.mark,
                result = res
            };
              
            uow.Repository<StudentMarks>().Insert(tb);
            uow.Save();
        }

        //public List<StudentMarkViewModel> GetAllStudentMark()
        //{

        //    return uow.Repository<StudentMarks>().GetAll().Select(t => new StudentMarkViewModel
        //    {
        //        Id = t.Id,
        //        Student_Number = t.Student_Number,
        //        Student_Name = t.Student_Name,
        //        Subject_Code = t.Subject_Code,
        //        GroupeName = t.GroupeName,
        //        ClassGroupe_id = t.ClassGroupe_id,
        //        mark = t.mark,
        //        result = t.result
        //    }).ToList();
        //}

        public StudentMarkViewModel GetStudentMarkById(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveStudentMark(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateStudentMark(StudentMarkViewModel model)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void EditMark(List<StudentMarks> list)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                
                    foreach (var i in list)
                    {
                        var c = db.Studentmark.Where(a => a.Id.Equals(i.Id)).FirstOrDefault();
                        if (c != null)
                        {
                            c.Student_Number = i.Student_Number;
                            c.Student_Name = i.Student_Name;
                            c.ClassGroupe_id = i.ClassGroupe_id;
                            c.GroupeName = i.GroupeName;
                            c.Subject_Code = i.Subject_Code;
                            c.mark = i.mark;

                        }
                    }
                    uow.Save();
             
            }
        }
    }
}