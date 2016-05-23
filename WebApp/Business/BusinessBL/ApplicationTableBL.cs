using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Business.IBusinessBl;
using WebApp.Data;
using WebApp.Models;


namespace WebApp.Business.BusinessBL
{
    public class ApplicationTableBL : IApplicationTableBL
    {
        public UnitOfWork.UnitOfWork uow = new UnitOfWork.UnitOfWork();
        public void AddApplicant(ApplicationViewModel app)
        {

            var newdaplicant = new ApplicationTable
            {

                Applicant_IDNumber = app.Applicant_IDNumber,
                Applicant_Name = app.Applicant_Name,
                Applicant_Surname = app.Applicant_Surname,
                Applicant_Date_Of_Birth = app.Applicant_Date_Of_Birth,
                Applicant_Gender = app.Applicant_Gender,
                Application_Grade = "Grade_8",
                Applicant_Religion = app.Applicant_Religion,
                Applicant_Adress = app.Applicant_Adress,
                Maths_Mark = app.Maths_Mark,
                English_Mark = app.English_Mark,
                ZuluHomeLanguage_Mark = app.ZuluHomeLanguage_Mark,
                status = "Awaiting",
                Title = app.Title,
                Parent_Name = app.Parent_Name,
                Parent_Surname = app.Parent_Surname,
                Parent_Number = app.Parent_Number,
                Parent_Adress = app.Parent_Adress,
                Parent_Email = app.Parent_Email,
            };
            uow.Repository<ApplicationTable>().Insert(newdaplicant);
            uow.Save();

            EmailViewmodel emv = new EmailViewmodel();
            EmailBL email = new EmailBL();



            emv.Message = "Dear Admin  :" + app.Parent_Email + "\n" +
                          "New Applicant has Submited An Application" + "\n" +
                           "Please Check Application ";
            emv.Subject = "New Applicant";
            emv.To = "21445847@dut4life.ac.za"; /*"yasinayami@gmail.com"*/;
            email.SendMail(emv);

        }



        public List<ApplicationViewModel> GetAllApplicants()
        {

            return uow.Repository<ApplicationTable>().GetAll().Select(app => new ApplicationViewModel()
            {

                Applicant_IDNumber = app.Applicant_IDNumber,
                Applicant_Name = app.Applicant_Name,
                Applicant_Surname = app.Applicant_Surname,
                Applicant_Date_Of_Birth = app.Applicant_Date_Of_Birth,
                Applicant_Gender = app.Applicant_Gender,
                Application_Grade = "Grade_8",
                Applicant_Religion = app.Applicant_Religion,
                Applicant_Adress = app.Applicant_Adress,
                Maths_Mark = app.Maths_Mark,
                English_Mark = app.English_Mark,
                ZuluHomeLanguage_Mark = app.ZuluHomeLanguage_Mark,
                status = "Awaiting",
                Title = app.Title,
                Parent_Name = app.Parent_Name,
                Parent_Surname = app.Parent_Surname,
                Parent_Number = app.Parent_Number,
                Parent_Adress = app.Parent_Adress,
                Parent_Email = app.Parent_Email,

            }).ToList();
        }


        public ApplicationViewModel GetById(string id)
        {
            
            var appview = new ApplicationViewModel();
            var app = uow.Repository<ApplicationTable>().GetById(Convert.ToInt16( id)); 



            appview.Applicant_IDNumber = app.Applicant_IDNumber;
            appview.Applicant_Name = app.Applicant_Name;
            appview.Applicant_Surname = app.Applicant_Surname;
            appview.Applicant_Date_Of_Birth = app.Applicant_Date_Of_Birth;
            appview.Applicant_Gender = app.Applicant_Gender;
            appview.Application_Grade = "Grade_8";
            appview.Applicant_Religion = app.Applicant_Religion;
            appview.Applicant_Adress = app.Applicant_Adress;
            appview.Maths_Mark = app.Maths_Mark;
            appview.English_Mark = app.English_Mark;
            appview.ZuluHomeLanguage_Mark = app.ZuluHomeLanguage_Mark;
            appview.status = "Awaiting";
            appview.Title = app.Title;
            appview.Parent_Name = app.Parent_Name;
            appview.Parent_Surname = app.Parent_Surname;
            appview.Parent_Number = app.Parent_Number;
            appview.Parent_Adress = app.Parent_Adress;
            appview.Parent_Email = app.Parent_Email;
            return appview;
        }

        public void RemoveApplicant(int id)
        {

            var app = uow.Repository<ApplicationTable>().GetById(id);
            if (app != null)
            {
                uow.Repository<ApplicationTable>().Delete(app);
            }

        }

        public void UpdateApplicant(ApplicationViewModel app)
        {

            var appview = uow.Repository<ApplicationTable>().GetById(Convert.ToInt32(app.Applicant_IDNumber));
            if (appview != null)
            {

                appview.Applicant_IDNumber = app.Applicant_IDNumber;
                appview.Applicant_Name = app.Applicant_Name;
                appview.Applicant_Surname = app.Applicant_Surname;
                appview.Applicant_Date_Of_Birth = app.Applicant_Date_Of_Birth;
                appview.Applicant_Gender = app.Applicant_Gender;
                appview.Application_Grade = "Grade_8";
                appview.Applicant_Religion = app.Applicant_Religion;
                appview.Applicant_Adress = app.Applicant_Adress;
                appview.Maths_Mark = app.Maths_Mark;
                appview.English_Mark = app.English_Mark;
                appview.ZuluHomeLanguage_Mark = app.ZuluHomeLanguage_Mark;
                appview.status = "Awaiting";
                appview.Title = app.Title;
                appview.Parent_Name = app.Parent_Name;
                appview.Parent_Surname = app.Parent_Surname;
                appview.Parent_Number = app.Parent_Number;
                appview.Parent_Adress = app.Parent_Adress;
                appview.Parent_Email = app.Parent_Email;
                uow.Repository<ApplicationTable>().Update(appview);
            }

        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }



    }
}