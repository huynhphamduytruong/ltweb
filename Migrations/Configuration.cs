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

            SeedRoles(context);
            SeedUsers(context);
            SeedCategories(context);
            SeedNews(context);
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
                //PasswordHash = new PasswordHasher().HashPassword("admin"),
            };
            if (!context.Users.Any(u => u.UserName == admin.UserName))
            {
                if ((result = userMan.Create(admin, "Mk@1234")).Succeeded)
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
                if ((result = userMan.Create(writer, "Mk@1234")).Succeeded)
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
                //PasswordHash = new PasswordHasher().HashPassword("user")
            };
            if (!context.Users.Any(u => u.UserName == user.UserName))
            {
                if ((result = userMan.Create(user, "Mk@1234")).Succeeded)
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

        private void SeedNews(ApplicationDbContext context)
        {
            // Scrape from VnExpress at 14/06/20
            News[] ns =
            {
                new News()
                {
                    Id = 1,
                    CategoryId = 1,
                    Title = "Đánh bả khiến xác chó rải khắp đường",
                    Description =
                        "Hai người tình nghi đánh bả khiến hơn 40 con chó, mèo chết trong đêm ở xã Thanh Hoà, huyện Như Xuân đã bị người dây vây bắt.",
                    CoverImage = "/images/cho-7730-1592134452.jpg"
                },
                new News()
                {
                    Id = 2,
                    CategoryId = 1,
                    Title = "Mưa lớn, máy bay trượt khỏi đường băng",
                    Description =
                        "Máy bay VJ322 hãng Vietjet từ Phú Quốc, Kiên Giang đáp xuống sân bay Tân Sơn Nhất trong cơn mưa lớn đã trượt khỏi đường băng, trưa 14/6.",


                     CoverImage = "/images/Vietjet-tru-o-t-kho-i-du-o-ng-5700-5271-1592121752.jpg"
                },
                new News()
                {
                    Id = 3,
                    CategoryId = 1,
                    Title = "Vựa phế liệu 2.000 m2 cháy rụi",
                    Description =
                        "Vựa phế liệu rộng 2.000 m2 trong khu dân cư phường Thái Hòa, thị xã Tân Uyên, bị lửa thiêu rụi hoàn toàn, sáng 14/6.",
               CoverImage = "/images/chay-2-3523-1592113869.jpg"
                },
                new News()
                {
                    Id = 4,
                    CategoryId = 3,
                    Title = "Bằng Kiều cùng vợ cũ và các con nhảy múa, đàn hát",
                    Description =
                        "Bằng Kiều cùng vợ cũ - Trizzie Phương Trinh - và ba con trai nhảy múa, đàn hát trong những ngày ở nhà tránh dịch.",
                    CoverImage = "/images/BB15sqv1.jfif"
                },
                new News()
                {
                    Id = 5,
                    CategoryId = 3,
                    Title = "Nhan sắc tuổi 20 của con gái diễn viên 'Bao Thanh Thiên'",
                    Description =
                        "Lâm Khải Linh, con gái 20 tuổi của Cung Từ Ân - diễn viên \"Bao Thanh Thiên\" - được các thương hiệu săn đón nhờ có gu thẩm mỹ.",
                    CoverImage = "/images/Khai-li-5119-1592107285.jpg"
                },
                new News()
                {
                    Id = 6,
                    CategoryId = 2,
                    Title = "Braithwaite và cuốn sổ 'Giấc mơ'",
                    Description =
                        "Vô danh trước khi đến Barca hồi tháng 2, nhưng Martin Braithwaite đang tận hưởng từng khoảnh khắc của việc đứng trong hàng ngũ CLB lớn bậc nhất thế giới. ",
                    CoverImage = "/images/martin-braithwaite-v-marcelo-1-3398-2066-1592116190.jpg"
                },
            };

            try
            {
                context.News.AddOrUpdate(ns);
                context.SaveChanges();

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
    }
}
