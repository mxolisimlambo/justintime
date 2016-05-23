using System;
using System.Collections.Generic;
using WebApp.Business.IBusinessBl;
using WebApp.Models;
using WebApp.Data;
using System.Linq;
using System.Web;

namespace WebApp.Business.BusinessBL
{
    public class AssignTeacherToSubjectBL : IAssignTeacherToSubjectBL
    {
        //UnitOfWork.UnitOfWork uow = new UnitOfWork.UnitOfWork();
        //public void AddGroup(GradesViewModels model)
        //{
        //    Grade gr = new Grade
        //    {
        //        Grade_id = model.Grade_id,
        //        GradeName = model.GradeName
        //    };
        //    uow.Repository<Grade>().Insert(gr);
        //    uow.Save();
        //}
        //public List<GradesViewModels> GetAllGroup()
        //{
        //    return uow.Repository<Grade>().GetAll().Select(t => new GradesViewModels
        //    {
        //        Grade_id = t.Grade_id,
        //        GradeName = t.GradeName,

        //    }).ToList();


        //}

        //public GradesViewModels GetById(int id)
        //{
        //    //string t= 
        //    var appview = new GradesViewModels();
        //    var app = uow.Repository<Grade>().GetById(id);


        //    appview.Grade_id = app.Grade_id;
        //    appview.GradeName = app.GradeName;
        //    return appview;

        //}
        public void AssignTeacherToSubject(AssignTeacherToSubjectViewModel model)
        {

            using (UnitOfWork.UnitOfWork uow = new UnitOfWork.UnitOfWork())
            {
                var AssT = new AssignTeacherToSubject
                {
                    StaffNumber = model.StaffNumber,
                    GradeGroupId = model.GradeGroupId,
                    SubjectCode = model.SubjectCode,

                };
                uow.Repository<AssignTeacherToSubject>().Insert(AssT);
                uow.Save();
            }
        }

        public List<AssignTeacherToSubjectViewModel> GetAllAssignedTeacherToSubject()
        {
            using(UnitOfWork.UnitOfWork uow=new UnitOfWork.UnitOfWork())
            {
                return uow.Repository<AssignTeacherToSubject>().GetAll().Select(d => new AssignTeacherToSubjectViewModel
                {
                    StaffNumber=d.StaffNumber,
                    GradeGroupId=d.GradeGroupId,
                    SubjectCode=d.SubjectCode,

                }).ToList();

            }
        }

        public AssignTeacherToSubjectViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}