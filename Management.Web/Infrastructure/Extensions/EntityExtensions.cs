using Management.Model.Models;
using Management.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Management.Web.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdatePostCategory(this PostCategory postCategory, PostCategoryViewModel postCategoryVm)
        {
            postCategory.ID = postCategoryVm.ID;
            postCategory.Name = postCategoryVm.Name;
            postCategory.Description = postCategoryVm.Description;
            postCategory.Alias = postCategoryVm.Alias;
            postCategory.ParentID = postCategoryVm.ParentID;
            postCategory.DisplayOrder = postCategoryVm.DisplayOrder;
            postCategory.Image = postCategoryVm.Image;
            postCategory.HomeFlag = postCategoryVm.HomeFlag;

            postCategory.CreatedDate = postCategoryVm.CreatedDate;
            postCategory.CreatedBy = postCategoryVm.CreatedBy;
            postCategory.UpdatedDate = postCategoryVm.UpdatedDate;
            postCategory.UpdatedBy = postCategoryVm.UpdatedBy;
            postCategory.MetaKeyword = postCategoryVm.MetaKeyword;
            postCategory.MetaDescription = postCategoryVm.MetaDescription;
            postCategory.Status = postCategoryVm.Status;

        }

        public static void UpdateProductCategory(this ProductCategory productCategory, ProductCategoryViewModel productCategoryVm)
        {
            productCategory.ID = productCategoryVm.ID;
            productCategory.Name = productCategoryVm.Name;
            productCategory.Description = productCategoryVm.Description;
            productCategory.Alias = productCategoryVm.Alias;
            productCategory.ParentID = productCategoryVm.ParentID;
            productCategory.DisplayOrder = productCategoryVm.DisplayOrder;
            productCategory.Image = productCategoryVm.Image;
            productCategory.HomeFlag = productCategoryVm.HomeFlag;

            productCategory.CreatedDate = productCategoryVm.CreatedDate;
            productCategory.CreatedBy = productCategoryVm.CreatedBy;
            productCategory.UpdatedDate = productCategoryVm.UpdatedDate;
            productCategory.UpdatedBy = productCategoryVm.UpdatedBy;
            productCategory.MetaKeyword = productCategoryVm.MetaKeyword;
            productCategory.MetaDescription = productCategoryVm.MetaDescription;
            productCategory.Status = productCategoryVm.Status;

        }

        public static void UpdatePost(this Post post, PostViewModel postVm)
        {
            post.ID = postVm.ID;
            post.Name = postVm.Name;
            post.Description = postVm.Description;
            post.Alias = postVm.Alias;
            post.CategoryID = postVm.CategoryID;
            post.Content = postVm.Content;
            post.Image = postVm.Image;
            post.HomeFlag = postVm.HomeFlag;
            post.ViewCount = postVm.ViewCount;

            post.CreatedDate = postVm.CreatedDate;
            post.CreatedBy = postVm.CreatedBy;
            post.UpdatedDate = postVm.UpdatedDate;
            post.UpdatedBy = postVm.UpdatedBy;
            post.MetaKeyword = postVm.MetaKeyword;
            post.MetaDescription = postVm.MetaDescription;
            post.Status = postVm.Status;
        }

        public static void UpdateDriver(this Driver driver, DriverViewModel driverVm)
        {
            driver.ID = driverVm.ID;
            driver.Name = driverVm.Name;
            driver.Description = driverVm.Description;
            driver.Address = driverVm.Address;
            driver.PhoneNumber = driverVm.PhoneNumber;
            driver.isDel = driverVm.isDel;


            driver.CreatedDate = driverVm.CreatedDate;
            driver.CreatedBy = driverVm.CreatedBy;
            driver.UpdatedDate = driverVm.UpdatedDate;
            driver.UpdatedBy = driverVm.UpdatedBy;
            driver.MetaKeyword = driverVm.MetaKeyword;
            driver.MetaDescription = driverVm.MetaDescription;
            driver.Status = driverVm.Status;
        }

        public static void UpdateCar(this Car car, CarViewModel carVm)
        {
            car.ID = carVm.ID;
            car.Name = carVm.Name;
            car.Code = carVm.Code;
            car.IDtype = carVm.IDtype;
            car.IDRouter = carVm.IDRouter;
            car.IDDriver = carVm.IDDriver;
            car.isDel = carVm.isDel;


            car.CreatedDate = carVm.CreatedDate;
            car.CreatedBy = carVm.CreatedBy;
            car.UpdatedDate = carVm.UpdatedDate;
            car.UpdatedBy = carVm.UpdatedBy;
            car.MetaKeyword = carVm.MetaKeyword;
            car.MetaDescription = carVm.MetaDescription;
            car.Status = carVm.Status;
        }

        public static void UpdateRoute(this Router route, RouterViewModel routeVm)
        {
            route.ID = routeVm.ID;
            route.StartPoint = routeVm.StartPoint;
            route.Description = routeVm.Description;
            route.EndPoint = routeVm.EndPoint;
            route.TimeStart = routeVm.TimeStart;
            route.isDel = routeVm.isDel;


            route.CreatedDate = routeVm.CreatedDate;
            route.CreatedBy = routeVm.CreatedBy;
            route.UpdatedDate = routeVm.UpdatedDate;
            route.UpdatedBy = routeVm.UpdatedBy;
            route.MetaKeyword = routeVm.MetaKeyword;
            route.MetaDescription = routeVm.MetaDescription;
            route.Status = routeVm.Status;
        }

        public static void UpdateHistoryAction(this HistoryAction historyAction, HistoryActionViewModel historyActionVM)
        {
            historyAction.ID = historyActionVM.ID;
            historyAction.UserName = historyActionVM.UserName;
            historyAction.ActionName = historyActionVM.ActionName;
            historyAction.ActionDate = historyActionVM.ActionDate;
            historyAction.Status = historyActionVM.Status;
        }


        public static void UpdateStatusSeatNo(this SeatNo seatno, SeatNoViewModel seatnoVM)
        {
            seatno.ID = seatnoVM.ID;
            seatno.Status = seatnoVM.Status;
        }

        public static void UpdateApplicationGroup(this ApplicationGroup appGroup, ApplicationGroupViewModel appGroupViewModel)
        {
            appGroup.ID = appGroupViewModel.ID;
            appGroup.Name = appGroupViewModel.Name;
        }

        public static void UpdateApplicationRole(this ApplicationRole appRole, ApplicationRoleViewModel appRoleViewModel, string action = "add")
        {
            if (action == "update")
                appRole.Id = appRoleViewModel.Id;
            else
                appRole.Id = Guid.NewGuid().ToString();
            appRole.Name = appRoleViewModel.Name;
            appRole.Description = appRoleViewModel.Description;
        }
        public static void UpdateUser(this ApplicationUser appUser, ApplicationUserViewModel appUserViewModel, string action = "add")
        {

            appUser.Id = appUserViewModel.Id;
            appUser.FullName = appUserViewModel.FullName;
            appUser.BirthDay = appUserViewModel.BirthDay;
            appUser.Email = appUserViewModel.Email;
            appUser.UserName = appUserViewModel.UserName;
            appUser.PhoneNumber = appUserViewModel.PhoneNumber;
        }

    }
}