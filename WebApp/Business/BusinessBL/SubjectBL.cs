using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Business.IBusinessBl
{
    public class SubjectBL : ISubjectBL
    {
        public UnitOfWork.UnitOfWork uow = new UnitOfWork.UnitOfWork();
        public void AddSubject(SubjectsViewModel model)
        {
            var newsubject = new Subjects
            {

                Subject_Code = model.Subject_Code,
                DescriptiveTitle = model.DescriptiveTitle,
                Stream_Code=model.Stream_Code

            };
            uow.Repository<Subjects>().Insert(newsubject);
            uow.Save();
        }

       

        public List<SubjectsViewModel> GetAllSubject()
        {

            return uow.Repository<Subjects>().GetAll().Select(x => new SubjectsViewModel()
            {
                Subject_Code=x.Subject_Code,
                DescriptiveTitle=x.DescriptiveTitle,
                Stream_Code=x.Stream_Code

            }).ToList();
        }

        public SubjectsViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveSubject(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateSubject(SubjectsViewModel model)
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}