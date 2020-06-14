using ltweb.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ltweb.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ltweb.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ltweb.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            SeedCategories(context);
            SeedRoles(context);
            SeedUsers(context);
        }

        private void SeedRoles(ApplicationDbContext context)
        {
            var roleMan = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            IdentityRole[] roles =
            {
                new IdentityRole("Admin"),
                new IdentityRole("Writer"),
                new IdentityRole("User"),
            };

            foreach (IdentityRole role in roles)
            {
                if (!context.Roles.Any(r => r.Name == role.Name))
                    roleMan.Create(role);
            }
        }

        private void SeedUsers(ApplicationDbContext context)
        {
            var userMan = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            IdentityResult result;

            ApplicationUser admin = new ApplicationUser()
            {
                //Id = "4C1D99EE-931F-4E57-B84D-763EE3451475",
                Email = "admin@badauhoi.com",
                EmailConfirmed = true,
                UserName = "admin",
                PasswordHash = new PasswordHasher().HashPassword("admin"),
            };
            if (!context.Users.Any(u => u.UserName == admin.UserName))
            {
                if ((result = userMan.Create(admin)).Succeeded)
                    userMan.AddToRole(admin.Id, "Admin");
                else
                    throw new Exception("[CREATE \"admin\"] " + string.Join("\n", result.Errors));
            }

            ApplicationUser writer = new ApplicationUser()
            {
                //Id = "8EF0DD97-206F-43F1-B34B-4A4ADB651DFB",
                Email = "writer1@badauhoi.com",
                EmailConfirmed = true,
                UserName = "writer1",
                //PasswordHash = new PasswordHasher().HashPassword("writer1")
            };
            if (!context.Users.Any(u => u.UserName == writer.UserName))
            {
                if ((result = userMan.Create(writer, "writer1")).Succeeded)
                    userMan.AddToRole(writer.Id, "Writer");
                else
                    throw new Exception("[CREATE \"writer1\"] " + string.Join("\n", result.Errors));
            }
            context.SaveChanges();

            ApplicationUser user = new ApplicationUser()
            {
                //Id = "2F437318-FEDC-4A7B-AD6F-51E7411EA828",
                Email = "user@email.com",
                UserName = "user",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher().HashPassword("user")
            };
            if (!context.Users.Any(u => u.UserName == user.UserName))
            {
                if ((result = userMan.Create(user)).Succeeded)
                    userMan.AddToRole(user.Id, "User");
                else
                    throw new Exception("[CREATE \"user\"] " + string.Join("\n", result.Errors));
            }
            context.SaveChanges();
        }

        private void SeedCategories(ApplicationDbContext context)
        {
            Category[] cats =
            {
                new Category(1, "Thời sự"), 
                new Category(2, "Thể thao"), 
                new Category(3, "Giải trí"), 
            };

            context.Categories.AddOrUpdate(cats);
            context.SaveChanges();
        }
    }
}
