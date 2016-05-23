using System;
using System.Collections.Generic;
using WebApp.Data;
using WebApp.Models;
using WebApp.UnitOfWork;
using WebApp.Business.IBusinessBl;
using System.Linq;
using System.Web;

namespace WebApp.Business.BusinessBL
{
    public class ClassGroupBL : IClassGroup
    {
        UnitOfWork.UnitOfWork uow = new UnitOfWork.UnitOfWork();
        public void AddClassGroup(ClassGroupViewModels model)
        {
            ClassGroupe grp = new ClassGroupe
            {

                ClassGroupe_id=model.ClassGroupe_id,
                GroupeName=model.GroupeName,
                Grade_id=model.Grade_id,

            };
            uow.Repository<ClassGroupe>().Insert(grp);
            uow.Save();
        }

        public List<ClassGroupViewModels> GetAllClassGroup()
        {
            return uow.Repository<ClassGroupe>().GetAll().Select(t => new ClassGroupViewModels
            {
                ClassGroupe_id=t.ClassGroupe_id,
                GroupeName=t.GroupeName,
                Grade_id=t.Grade_id,
            }).ToList();
        }
        public ClassGroupViewModels GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveClassGroup(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateClassGroup(ClassGroupViewModels model)
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}