﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Script.Serialization;
using Management.Common.Exceptions;
using Management.Data.Infrastructure;
using Management.Model.Models;
using Management.Service;
using Management.Web.App_Start;
using Management.Web.Infrastructure.Core;
using Management.Web.Infrastructure.Extensions;
using Management.Web.Models;

namespace Management.Web.Api
{
    [RoutePrefix("api/applicationGroup")]
    
    public class ApplicationGroupController : ApiControllerBase
    {
        private IApplicationGroupService _appGroupService;
        private IApplicationRoleService _appRoleService;
        private ApplicationUserManager _userManager;

        public ApplicationGroupController(IErrorService errorService,
            IApplicationRoleService appRoleService,
            ApplicationUserManager userManager,
            IApplicationGroupService appGroupService) : base(errorService)
        {
            _appGroupService = appGroupService;
            _appRoleService = appRoleService;
            _userManager = userManager;
        }


        #region GetBySearch
        [Route("getlistall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _appGroupService.GetAll(keyword);

                IEnumerable<ApplicationGroupViewModel> modelVm = Mapper.Map<IEnumerable<ApplicationGroup>, IEnumerable<ApplicationGroupViewModel>>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, modelVm);
                return response;
            });
        }
        #endregion

        [Route("detail/{id:int}")]
        [HttpGet]
        public HttpResponseMessage Details(HttpRequestMessage request, int id)
        {
            if (id == 0)
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, nameof(id) + " is required.");
            }
            ApplicationGroup appGroup = _appGroupService.GetDetail(id);
            var appGroupViewModel = Mapper.Map<ApplicationGroup, ApplicationGroupViewModel>(appGroup);
            if (appGroup == null)
            {
                return request.CreateErrorResponse(HttpStatusCode.NoContent, "No group");
            }
            var listRole = _appRoleService.GetListRoleByGroupId(appGroupViewModel.ID);
            appGroupViewModel.Roles = Mapper.Map<IEnumerable<ApplicationRole>,IEnumerable<ApplicationRoleViewModel>>(listRole);
            return request.CreateResponse(HttpStatusCode.OK, appGroupViewModel);
        }

        [HttpPost]
        [Route("add")]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, ApplicationGroupViewModel appGroupViewModel)
        {
            if (ModelState.IsValid)
            {
                var newAppGroup = new ApplicationGroup();
                newAppGroup.Name = appGroupViewModel.Name;
                try
                {
                    var appGroup = _appGroupService.Add(newAppGroup);
                    _appGroupService.Save();

                    //save group
                    var listRoleGroup = new List<ApplicationRoleGroup>();
                    foreach (var role in appGroupViewModel.Roles)
                    {
                        listRoleGroup.Add(new ApplicationRoleGroup()
                        {
                            GroupId = appGroup.ID,
                            RoleId = role.Id
                        });
                    }
                    _appRoleService.AddRolesToGroup(listRoleGroup, appGroup.ID);
                    _appRoleService.Save();


                    return request.CreateResponse(HttpStatusCode.OK, appGroupViewModel);


                }
                catch (NameDuplicatedException dex)
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, dex.Message);
                }

            }
            else
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<HttpResponseMessage> Update(HttpRequestMessage request, ApplicationGroupViewModel appGroupViewModel)
        {
            if (ModelState.IsValid)
            {
                var appGroup = _appGroupService.GetDetail(appGroupViewModel.ID);
                try
                {
                    appGroup.UpdateApplicationGroup(appGroupViewModel);
                    _appGroupService.Update(appGroup);
                    //_appGroupService.Save();

                    //save group
                    var listRoleGroup = new List<ApplicationRoleGroup>();
                    foreach (var role in appGroupViewModel.Roles)
                    {
                        listRoleGroup.Add(new ApplicationRoleGroup()
                        {
                            GroupId = appGroup.ID,
                            RoleId = role.Id
                        });
                    }
                    _appRoleService.AddRolesToGroup(listRoleGroup, appGroup.ID);
                    _appRoleService.Save();

                    //add role to user
                    var listRole = _appRoleService.GetListRoleByGroupId(appGroup.ID);
                    var listUserInGroup = _appGroupService.GetListUserByGroupId(appGroup.ID);
                    foreach (var user in listUserInGroup)
                    {
                        var listRoleName = listRole.Select(x => x.Name).ToArray();
                        foreach (var roleName in listRoleName)
                        {
                            await _userManager.RemoveFromRoleAsync(user.Id, roleName);
                            await _userManager.AddToRoleAsync(user.Id, roleName);
                        }
                    }
                    return request.CreateResponse(HttpStatusCode.OK, appGroupViewModel);
                }
                catch (NameDuplicatedException dex)
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, dex.Message);
                }

            }
            else
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            var appGroup = _appGroupService.Delete(id);
            _appGroupService.Save();
            return request.CreateResponse(HttpStatusCode.OK, appGroup);
        }

        [Route("deletemulti")]
        [HttpDelete]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedList)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var listItem = new JavaScriptSerializer().Deserialize<List<int>>(checkedList);
                    foreach (var item in listItem)
                    {
                        _appGroupService.Delete(item);
                    }

                    _appGroupService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK, listItem.Count);
                }

                return response;
            });
        }
    }
}
