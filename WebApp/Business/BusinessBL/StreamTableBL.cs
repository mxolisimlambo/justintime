using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Business.IBusinessBl;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Business.BusinessBL
{
    public class StreamTableBL : IStreamTableBL
    {
        public UnitOfWork.UnitOfWork uow = new UnitOfWork.UnitOfWork();
        public void AddStream(StreamTableViewModel model)
        {
            var newstream = new StreamTable
            {

              Stream_Code=model.Stream_Code,
              Description=model.Description
              
            };
            uow.Repository<StreamTable>().Insert(newstream);
            uow.Save();
        }

       

        public List<StreamTableViewModel> GetAllStreams()
        {
            return uow.Repository<StreamTable>().GetAll().Select(x => new StreamTableViewModel()
            {
            
                Stream_Code = x.Stream_Code,
                Description=x.Description
                

            }).ToList();
        }

        public StreamTableViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveStream(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateStream(StreamTableViewModel model)
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}