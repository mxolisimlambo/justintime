using System;
using System.Collections.Generic;
using System.Linq;
using WebApp.Data;
using WebApp.Business.IBusinessBl;
using WebApp.UnitOfWork;
using System.Web;
using WebApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApp.Business.BusinessBL
{
    public class RegistrationBL : IRegistrationBL
    {
        UnitOfWork.UnitOfWork uow = new UnitOfWork.UnitOfWork();

        private RoleManager<IdentityRole> roleManager;
        public UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        public RegistrationBL():this(new UserManager <ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())),new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()))
           )
        {
            userManager.UserValidator = new UserValidator<ApplicationUser>(userManager)
            {
                AllowOnlyAlphanumericUserNames = false
            };
        }

        public RegistrationBL(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;

        }




        public void Register(RegistrationViewModel model, HttpPostedFileBase image)
        {


            var password = "Password01";
            var user = new ApplicationUser()
            {
               UserName = model.Parent_Email,
               Email = model.Parent_Email
            };
            string gen;
            string seven = model.Student_IDNumber.Substring(6, 1);
            int seventh = Convert.ToInt16(seven);

            if (seventh == 0 || seventh <= 4)
                gen = "Female";
            else
                gen = "Male";

            if (image != null)
            {
                model.AddPhoto = new byte[image.ContentLength];
                image.InputStream.Read(model.AddPhoto, 0, image.ContentLength);
            }

            StudentTable stud = new StudentTable
            {
                Student_Number = model.Student_Number,
                Student_Name = model.Student_Name,
                Student_Surname = model.Student_Surname,
                Student_Gender = gen,
                Student_Religion = model.Student_Religion,
                Student_Adress = model.Student_Adress,
                Student_Date_Of_Birth = model.Student_Date_Of_Birth,
                Student_IDNumber = model.Student_IDNumber,
                Enrolment_Date = model.Enrolment_Date,
                Role = model.Role,
                //AddPhoto=model.AddPhoto,
                Stream_Code = model.Stream_Code,     
                ClassGroupe_id = model.ClassGroupe_id,
                Grade_id = model.Grade_id,
                status = model.status,
                Parent_Identity = model.Parent_Identity,

            };
            uow.Repository<StudentTable>().Insert(stud);
            var result = userManager.Create(user, password);
            if (result.Succeeded)
            {
                if (!roleManager.RoleExists(model.Role))
                {
                    roleManager.Create(new IdentityRole() { Name = model.Role });
               }
               userManager.AddToRole(user.Id, model.Role);
            }

            Parent ppar = new Parent
            {
                Parent_Identity = model.Parent_Identity,
                Title = model.Title,
                Parent_Name = model.Parent_Name,
                Parent_Surname = model.Parent_Surname,
                Parent_Number = model.Parent_Number,
                Parent_Adress = model.Parent_Adress,
                Parent_Email = model.Parent_Email,
            };
            uow.Repository<Parent>().Insert(ppar);
            uow.Save();

            EmailViewmodel emv = new EmailViewmodel();
            EmailBL email = new EmailBL();



            emv.Message = "Dear Parent  :" + model.Parent_Email + "\n" +
                          "Your Child has Registered to JG Zuma High School" + "\n" +
                           "Please make sure you attend meeting  " +
                           "Out Standing School Fee:R 150.00"+"\n"+
                           "LogIn Creaditials are: password:"+password +"UserName :"+user;
            emv.Subject = "JG-Zuma Registration Feedback";
            emv.To = model.Parent_Email ;
            email.SendMail(emv);
            

        }



        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}