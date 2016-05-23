using System;
using System.Collections.Generic;
using System.Linq;
using WebApp.Data;
using WebApp.Business.IBusinessBl;
using WebApp.UnitOfWork;
using System.Web;
using WebApp.Models;

namespace WebApp.Business.BusinessBL
{
    public class GradeBL : IGradeBL
    {
        UnitOfWork.UnitOfWork uow = new UnitOfWork.UnitOfWork();
        public void AddGroup(GradesViewModels model)
        {
            Grade gr = new Grade
            {
                Grade_id=model.Grade_id,
                GradeName=model.GradeName
            };
            uow.Repository<Grade>().Insert(gr);
            uow.Save();
        }
        public List<GradesViewModels> GetAllGroup()
        {
            return uow.Repository<Grade>().GetAll().Select(t => new GradesViewModels
            {
                Grade_id=t.Grade_id,
                GradeName=t.GradeName,
                
            }).ToList();


        }

        public GradesViewModels GetById(int id)
        {
            //string t= 
            var appview = new GradesViewModels();
            var app = uow.Repository<Grade>().GetById(id);


            appview.Grade_id = app.Grade_id;
            appview.GradeName= app.GradeName;
            return appview;
         
        }

        public void RemoveGroup(int id)
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void UpdateGroup(GradesViewModels model)
        {
            throw new NotImplementedException();
        }
    }
}