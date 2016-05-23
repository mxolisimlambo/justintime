using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Business.IBusinessBl;
using WebApp.Data;
using WebApp.Models;


namespace WebApp.Business.BusinessBL
{
    public class ApplicationBL : IApplicationBL
    {
        public void MakeApplication(MakeApplicationViewModel viewmodel)
        {
            using (UnitOfWork.IUnitOfWork uow = new UnitOfWork.UnitOfWork())
            {
                byte[] reportcopy = new byte[viewmodel.ReportCopy.InputStream.Length];
                viewmodel.ReportCopy.InputStream.Read(reportcopy, 0, reportcopy.Length);

                var newaplication = new Application
                {
                    IDNumber = viewmodel.IdNumber,
                    Name = viewmodel.FirstName,
                    Surname = viewmodel.Surname,
                    DateOfBirth = viewmodel.DateOfBirth,
                    Gender = viewmodel.Gender,
                    Status = "Awaiting", Address = viewmodel.Address,
                    Phone = viewmodel.Phone,
                    ReportCopyType = viewmodel.ReportCopy.ContentType,
                    ReportCopy = reportcopy,
                };
                uow.Repository<Application>().Insert(newaplication);
                uow.Save();
            }
        }


        public List<AllApplicationsViewModel> GetAllApplications()
        {
            using (UnitOfWork.UnitOfWork uow = new UnitOfWork.UnitOfWork())
            {
                return uow.Repository<Application>().GetAll().Select(app => new AllApplicationsViewModel()
                {
                    IdNumber = app.IDNumber,
                    FirstName = app.Name,
                    Surname = app.Surname,
                    DateOfBirth = app.DateOfBirth,
                    Gender = app.Gender,
                    Status = app.Status,
                    Address = app.Address,
                    Phone = app.Phone,
                    ReportCopy = app.ReportCopy
                }).ToList();
            }
        }

        public ViewApplicationViewModel GetApplication(string id)
        {
            using (UnitOfWork.UnitOfWork uow = new UnitOfWork.UnitOfWork())
            {
                var application = uow.Repository<Application>().GetById(id);
                return new ViewApplicationViewModel { IdNumber = application.IDNumber, Phone = application.Phone, Status = application.Status, ReportCopy = application.ReportCopy };
            }
        } 

        public void UpdateStatus(ViewApplicationViewModel viewmodel)
        {
            using (UnitOfWork.UnitOfWork uow = new UnitOfWork.UnitOfWork())
            {
                var application = uow.Repository<Application>().GetById(viewmodel.IdNumber);
                if(application != null)
                {
                    application.Status = viewmodel.Status;
                    uow.Repository<Application>().Update(application);
                    uow.Save();
                }
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }


        //public ApplicationViewModels GetById(string id)
        //{

        //    var appview = new ApplicationViewModels();
        //    var app = uow.Repository<Application>().GetById(Convert.ToInt16( id)); 



        //    appview.Applicant_IDNumber = app.Applicant_IDNumber;
        //    appview.Applicant_Name = app.Applicant_Name;
        //    appview.Applicant_Surname = app.Applicant_Surname;
        //    appview.Applicant_Date_Of_Birth = app.Applicant_Date_Of_Birth;
        //    appview.Applicant_Gender = app.Applicant_Gender;
        //    appview.Application_Grade = "Grade_8";
        //    appview.Applicant_Religion = app.Applicant_Religion;
        //    appview.Applicant_Adress = app.Applicant_Adress;
        //    appview.Maths_Mark = app.Maths_Mark;
        //    appview.English_Mark = app.English_Mark;
        //    appview.ZuluHomeLanguage_Mark = app.ZuluHomeLanguage_Mark;
        //    appview.status = "Awaiting";
        //    appview.Title = app.Title;
        //    appview.Parent_Name = app.Parent_Name;
        //    appview.Parent_Surname = app.Parent_Surname;
        //    appview.Parent_Number = app.Parent_Number;
        //    appview.Parent_Adress = app.Parent_Adress;
        //    appview.Parent_Email = app.Parent_Email;
        //    return appview;
        //}

        //public void RemoveApplicant(int id)
        //{

        //    var app = uow.Repository<Application>().GetById(id);
        //    if (app != null)
        //    {
        //        uow.Repository<Application>().Delete(app);
        //    }

        //}

        //public void UpdateApplicant(ApplicationViewModels app)
        //{

        //    var appview = uow.Repository<Application>().GetById(Convert.ToInt32(app.Applicant_IDNumber));
        //    if (appview != null)
        //    {

        //        appview.Applicant_IDNumber = app.Applicant_IDNumber;
        //        appview.Applicant_Name = app.Applicant_Name;
        //        appview.Applicant_Surname = app.Applicant_Surname;
        //        appview.Applicant_Date_Of_Birth = app.Applicant_Date_Of_Birth;
        //        appview.Applicant_Gender = app.Applicant_Gender;
        //        appview.Application_Grade = "Grade_8";
        //        appview.Applicant_Religion = app.Applicant_Religion;
        //        appview.Applicant_Adress = app.Applicant_Adress;
        //        appview.Maths_Mark = app.Maths_Mark;
        //        appview.English_Mark = app.English_Mark;
        //        appview.ZuluHomeLanguage_Mark = app.ZuluHomeLanguage_Mark;
        //        appview.status = "Awaiting";
        //        appview.Title = app.Title;
        //        appview.Parent_Name = app.Parent_Name;
        //        appview.Parent_Surname = app.Parent_Surname;
        //        appview.Parent_Number = app.Parent_Number;
        //        appview.Parent_Adress = app.Parent_Adress;
        //        appview.Parent_Email = app.Parent_Email;
        //        uow.Repository<Application>().Update(appview);
        //    }

        //}
    }
}