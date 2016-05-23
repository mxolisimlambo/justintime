using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Business.IBusinessBl
{
    public interface IStreamTableBL:IDisposable
    { 

         void AddStream(StreamTableViewModel model);
        List<StreamTableViewModel> GetAllStreams();
        StreamTableViewModel GetById(int id);
        void RemoveStream(int id);
        void UpdateStream(StreamTableViewModel model);
    }
}