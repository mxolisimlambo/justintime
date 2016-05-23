using System;
using System.Collections.Generic;
using WebApp.Business.IBusinessBl;
using WebApp.UnitOfWork;
using WebApp.Data;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Business.BusinessBL
{
    public class ClassMarkBL : IClassMarkBL
    {
        public void AppClassMark(ClassMarkViewModel model)
        {

            using (UnitOfWork.UnitOfWork uow = new UnitOfWork.UnitOfWork())
            {

                var mark = new ClassMark
                {
                    Student_No = model.Student_No,
                    Student_name = model.Student_name,
                    ClassGroupe_id = model.ClassGroupe_id,
                    Subject1 = model.Subject1,
                    Subject2 = model.Subject2,
                    mark = model.mark,
                    mark12 = model.mark12,
                    mark21 = model.mark21,
                    mark23 = model.mark32,
                    mark32 = model.mark32,

                    Subject3 = model.Subject3,
                    Subject4 = model.Subject4,
                    Subject5 = model.Subject5,
                };
                uow.Repository<ClassMark>().Insert(mark);
                uow.Save();
            }
        }

        public List<ClassMarkViewModel> GetAllClassMark()
        {
            using (UnitOfWork.UnitOfWork uow = new UnitOfWork.UnitOfWork())
            {

                return uow.Repository<ClassMark>().GetAll().Select(t => new ClassMarkViewModel
                {

                    Student_No=t.Student_No,
                    Student_name=t.Student_name,
                    ClassGroupe_id=t.ClassGroupe_id,
                    Subject1=t.Subject1,
                    mark=t.mark,
                    Subject2=t.Subject2,
                    mark12=t.mark12,
                    Subject3=t.Subject3,
                    mark21=t.mark21,
                    Subject4=t.Subject4,
                    mark23=t.mark23,
                    Subject5=t.Subject5,
                    mark32=t.mark32,

                }).ToList();

            }
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

     
    }
}