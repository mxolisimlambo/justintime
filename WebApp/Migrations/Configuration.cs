namespace WebApp.Migrations
{
    using Data;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApp.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApp.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            addUser(context);
            addRoles(context);
            addUserToRole(context);
        }

        public void addUser(ApplicationDbContext context)
        {
            UserStore<ApplicationUser> us = new UserStore<ApplicationUser>(context);
            UserManager<ApplicationUser> um = new UserManager<ApplicationUser>(us);

            ApplicationUser user = new ApplicationUser
            {
                UserName = "admin",
                Email = "mxolisimlambo6@gmail.com",
            };

            if (um.FindByName(user.UserName) == null)
            {
                um.Create(user, "P@ssword01");
            }
        }

        public void addRoles(ApplicationDbContext context)
        {
            RoleStore<IdentityRole> rs = new RoleStore<IdentityRole>(context);
            RoleManager<IdentityRole> rm = new RoleManager<IdentityRole>(rs);
            IdentityRole role = new IdentityRole { Name = "Admin" };

            if (rm.FindByName(role.Name) == null)
            {
                rm.Create(role);
            }

            IdentityRole role2 = new IdentityRole { Name = "Principal" };

            if (rm.FindByName(role.Name) == null)
            {
                rm.Create(role);
            }
            IdentityRole role3 = new IdentityRole { Name = "Staff" };

            if (rm.FindByName(role.Name) == null)
            {
                rm.Create(role);
            }
            IdentityRole role4 = new IdentityRole { Name = "Learner" };

            if (rm.FindByName(role.Name) == null)
            {
                rm.Create(role);
            }
        }

        public void addUserToRole(ApplicationDbContext context)
        {
            UserStore<ApplicationUser> us = new UserStore<ApplicationUser>(context);
            UserManager<ApplicationUser> um = new UserManager<ApplicationUser>(us);

            ApplicationUser user = um.FindByName("admin");
            if (user != null)
            {
                if (um.IsInRole(user.Id, "Admin") == false)
                {
                    um.AddToRole(user.Id, "Admin");
                }
            }
        }
    }
}
