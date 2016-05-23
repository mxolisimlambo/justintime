using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Application> ApplicationTables { get; set; }

        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<ClassMark> ClassMarks { get; set; }
        public DbSet<Subjects> Subjects { get; set;}
        public DbSet<StudentTable> StudentTables { get; set; }
        
        public DbSet<StreamTable> StreamTables { get; set; }
        public DbSet<AssignTeacherToClass> AssignTeacherToClasss { get; set; }
        public DbSet<AssignTeacherToSubject> AssignTeacherToSubjects { get; set; }
        public DbSet<ProgressReport> ProgressReports { get; set; }
        public DbSet<StudentMarks> Studentmark { get; set; }
        public DbSet<Attend> Attends { get; set; }
        public DbSet<AttendReccord> AttendReccords { get; set; }

        public System.Data.Entity.DbSet<WebApp.Data.Parent> Parents { get; set; }
        public DbSet<Mark> Marks { get; set; }
        //public System.Data.Entity.DbSet<WebApp.Models.StudentMarkViewModel> StudentMarkViewModels { get; set; }

        public System.Data.Entity.DbSet<WebApp.Data.ClassGroupe> ClassGroupes { get; set; }

        public System.Data.Entity.DbSet<WebApp.Models.StudentMarkViewModel> StudentMarkViewModels { get; set; }

        public System.Data.Entity.DbSet<WebApp.Models.AttendViewModel> AttendViewModels { get; set; }

        public System.Data.Entity.DbSet<WebApp.Models.AssignTeacherToClassViewmodel> AssignTeacherToClassViewmodels { get; set; }






        //public System.Data.Entity.DbSet<WebApp.Models.ClassMarkViewModel> ClassMarkViewModels { get; set; }

        //public System.Data.Entity.DbSet<WebApp.Models.StudentMarkViewModel> StudentMarkViewModels { get; set; }

        //public System.Data.Entity.DbSet<WebApp.Models.StaffViewModel> StaffViewModels { get; set; }

        //public System.Data.Entity.DbSet<WebApp.Models.RegistrationViewModel> RegistrationViewModels { get; set; }



        //public System.Data.Entity.DbSet<WebApp.Models.GradesViewModels> GradesViewModels { get; set; }

        //public System.Data.Entity.DbSet<WebApp.Models.ClassGroupViewModels> ClassGroupViewModels { get; set; }
    }
}