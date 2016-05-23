using System;
using System.Collections.Generic;
using WebApp.Business.IBusinessBl;
using System.Linq;
using WebApp.Models;
using WebApp.Data;
using System.Web;


namespace WebApp.Business.BusinessBL
{
    public class AssignTeacherToClassBL : IAssignTeacherToClassBL
    {
        
        public void AssignTeacherToClass(AssignTeacherToClassViewmodel model)
        {
            using (UnitOfWork.UnitOfWork uow=new UnitOfWork.UnitOfWork())
            {

                var Ass = new AssignTeacherToClass
                {
                    StaffNumber = model.StaffNumber,
                    GradeGroupId = model.GradeGroupId,
                };
                uow.Repository<AssignTeacherToClass>().Insert(Ass);
                uow.Save();
            }
                
        }

        public List<AssignTeacherToClassViewmodel> GetAllAssignedTeacher()
        {
            using (UnitOfWork.UnitOfWork uow = new UnitOfWork.UnitOfWork())
            {
                return uow.Repository<AssignTeacherToClass>().GetAll().Select(t => new AssignTeacherToClassViewmodel
                {
                    StaffNumber = t.StaffNumber,
                    GradeGroupId=t.GradeGroupId,

                }).ToList();
            };
        }

        public AssignTeacherToClassViewmodel GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}