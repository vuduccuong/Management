namespace Management.Data.Migrations
{
    using Management.Model.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Management.Data.ManagementDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Management.Data.ManagementDbContext context)
        {
            CreateProductCategorySample(context);
            //  This method will be called after migrating to the latest version.

            CreateAccount(context);
            CreatTypeCar(context);

        }

        private void CreatTypeCar(ManagementDbContext context)
        {
            if (context.TypeCars.Count() == 0)
            {
                List<TypeCar> listTypeCars = new List<TypeCar>()
            {
                new TypeCar() { Name="Xe khách"},
                 new TypeCar() { Name="Xe hợp đồng"},
            };
                context.TypeCars.AddRange(listTypeCars);
                context.SaveChanges();
            }
            if (context.PostCategories.Count()==0)
            {
                List<PostCategory> lstPostCate = new List<PostCategory>()
                {
                    new PostCategory(){Name="Tổng hợp",Status=true,Alias="Tonghop"}
                };
                context.PostCategories.AddRange(lstPostCate);
                context.SaveChanges();
            }
        }

        private void CreateAccount(ManagementDbContext context)
        {
            if (context.Users.Count() == 0)
            {
                var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ManagementDbContext()));

                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ManagementDbContext()));

                string birtday = "June 18, 1996";
                var user = new ApplicationUser()
                {
                    UserName = "cuongvd",
                    Email = "vuduccuong.ck48@gmail.com",
                    EmailConfirmed = true,
                    BirthDay = DateTime.Parse(birtday),
                    FullName = "Vu Duc Cuong"

                };

                manager.Create(user, "123@123a");

                if (!roleManager.Roles.Any())
                {
                    roleManager.Create(new IdentityRole { Name = "Admin" });
                    roleManager.Create(new IdentityRole { Name = "User" });
                    roleManager.Create(new IdentityRole { Name = "Management" });
                }

                var adminUser = manager.FindByEmail("vuduccuong.ck48@gmail.com");

                manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User", "Management" });
            }

        }

        private void CreateProductCategorySample(Management.Data.ManagementDbContext context)
        {
            if (context.ProductCategories.Count() == 0)
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>()
            {
                new ProductCategory() { Name="Điện lạnh",Alias="dien-lanh",Status=true },
                 new ProductCategory() { Name="Viễn thông",Alias="vien-thong",Status=true },
                  new ProductCategory() { Name="Đồ gia dụng",Alias="do-gia-dung",Status=true },
                   new ProductCategory() { Name="Mỹ phẩm",Alias="my-pham",Status=true }
            };
                context.ProductCategories.AddRange(listProductCategory);
                context.SaveChanges();
            }

        }
    }

}
