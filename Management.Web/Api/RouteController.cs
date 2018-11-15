using AutoMapper;
using Management.Model.Models;
using Management.Service;
using Management.Web.Infrastructure.Core;
using Management.Web.Infrastructure.Extensions;
using Management.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Management.Web.Api
{
    [RoutePrefix("api/route")]
    public class RouteController : ApiControllerBase
    {
        #region Initalize
        private IRouteService _routeService;

        public RouteController(IErrorService errorService, IRouteService routeService)
            : base(errorService)
        {
            this._routeService = routeService;
        }
        #endregion

        #region GetRouteBySearch
        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _routeService.GetAll(keyword);

                var responseData = Mapper.Map<IEnumerable<Router>, IEnumerable<RouterViewModel>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
        #endregion

        #region GetRouteById
        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _routeService.GetById(id);

                var responseData = Mapper.Map<Router, RouterViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }
        #endregion

        #region CreatNewRoute
        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, RouterViewModel routeVm)
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
                    var newRoute = new Router();
                    newRoute.UpdateRoute(routeVm);
                    newRoute.CreatedDate = DateTime.Now;

                    _routeService.Add(newRoute);
                    _routeService.Save();

                    var responseData = Mapper.Map<Router, RouterViewModel>(newRoute);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }
        #endregion

        #region UpdateRoute
        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, RouterViewModel routeVm)
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
                    var dbRoute = _routeService.GetById(routeVm.ID);

                    dbRoute.UpdateRoute(routeVm);
                    dbRoute.UpdatedDate = DateTime.Now;

                    _routeService.Update(dbRoute);
                    _routeService.Save();

                    var responseData = Mapper.Map<Router, RouterViewModel>(dbRoute);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }
        #endregion

        #region Delete
        [Route("delete")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
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
                    var oldRoute = _routeService.Delete(id);
                    _routeService.Save();

                    var responseData = Mapper.Map<Router, RouterViewModel>(oldRoute);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        #endregion
    }
}
