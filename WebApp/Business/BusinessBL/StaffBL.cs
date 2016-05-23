using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Business.IBusinessBl;
using WebApp.Data;
using WebApp.Models;



namespace WebApp.Business.BusinessBL
{
    public class StaffBL : IStaffBL
    {
        private UnitOfWork.UnitOfWork uow = new UnitOfWork.UnitOfWork();

        private readonly ApplicationDbContext db = new ApplicationDbContext();
        public UserManager<ApplicationUser> UserManager { get; set; }
        public RoleManager<IdentityRole> RoleManager { get; set; }

        public StaffBL()
            : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())),
                new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext())),
                new UnitOfWork.UnitOfWork())
        {

        }

        private StaffBL(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, UnitOfWork.UnitOfWork unitofwork)
        {
            UserManager = userManager;
            RoleManager = roleManager;

        }

        public void AddNewStaffprofile(StaffViewModel model, HttpPostedFileBase image)
        {
            var password = "Mxolisi87!@";
            string gen;
            string seven = model.IdentityNumber.Substring(6, 1);
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
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,


            };


            var st = new Staff
            {

                Stuff_Number = model.Stuff_Number,
                Registration_Date=model.Registration_Date,
                FirstName = model.FirstName,
                LastName = model.LastName,
                ContactNumber = model.ContactNumber,
                Email = model.Email,
                Password = password,
                IdentityNumber = model.IdentityNumber,
                AddPhoto = model.AddPhoto,
                Role = model.Role,
                Gender = gen

            };
            uow.Repository<Staff>().Insert(st);
            uow.Save();


            EmailViewmodel emv = new EmailViewmodel();
            EmailBL email = new EmailBL();



            emv.Message = "Dear Parent  :" + model.Email + "\n" +
                          "Your Child has Registered to JG Zuma High School" + "\n" +
                           "Please make sure you attend meeting  " +
                           "Out Standing School Fee:R 150.00" + "\n" +
                           "LogIn Creaditials are: password:" + password + "UserName :" + user;
            emv.Subject = "JG-Zuma Registration Feedback";
            emv.To = model.Email; 
            email.SendMail(emv);




            var result = UserManager.Create(user, password);
            if (result.Succeeded)
            {
                if (!RoleManager.RoleExists(model.Role))
                {
                    RoleManager.Create(new IdentityRole() { Name = model.Role });
                }
                UserManager.AddToRole(user.Id, model.Role);
            }
          

        }
       

        public List<StaffViewModel> SearchByName(string FName)
        {
            {
                var result = GetAllStaff().Where(x => x.FirstName.ToUpper().Contains(FName.ToUpper()));

                return result.ToList();
            }
        }

        public List<StaffViewModel> GetAllStaff()
        {
            using (var uow = new UnitOfWork.UnitOfWork ())
            {
                return
                    uow.Repository<Staff>().GetAll()
                        .Select(
                            x =>
                                new StaffViewModel()
                                {
                                    Stuff_Number = x.Stuff_Number,
                                    FirstName = x.FirstName,
                                    LastName = x.LastName,
                                    Registration_Date =x.Registration_Date,
                                    Gender = x.Gender,
                                    ContactNumber = x.ContactNumber,
                                    Email = x.Email,
                                    Password = x.Password,
                                    AddPhoto = x.AddPhoto,
                                    IdentityNumber = x.IdentityNumber,
                                    Role = x.Role,
                                    
                                })
                        .ToList();

            }

        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

       
    }
}