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
    [RoutePrefix("api/driver")]
    public class DriverController : ApiControllerBase
    {
        #region Initalize
        private IDriverService _driverService;

        public DriverController(IErrorService errorService, IDriverService driverService)
            : base(errorService)
        {
            this._driverService = driverService;
        }
        #endregion

        #region GetDriverBySearch
        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _driverService.GetAll(keyword);

                var responseData = Mapper.Map<IEnumerable<Driver>, IEnumerable<DriverViewModel>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
        #endregion

        #region GetDriverById
        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _driverService.GetById(id);

                var responseData = Mapper.Map<Driver, DriverViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }
        #endregion

        #region CreatNewDriver
        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, DriverViewModel driverVm)
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
                    var newDriver = new Driver();
                    newDriver.UpdateDriver(driverVm);
                    newDriver.CreatedDate = DateTime.Now;

                    _driverService.Add(newDriver);
                    _driverService.Save();

                    var responseData = Mapper.Map<Driver, DriverViewModel>(newDriver);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }
        #endregion

        #region UpdateProductCategory
        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, DriverViewModel driverVm)
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
                    var dbDriver= _driverService.GetById(driverVm.ID);

                    dbDriver.UpdateDriver(driverVm);
                    dbDriver.UpdatedDate = DateTime.Now;

                    _driverService.Update(dbDriver);
                    _driverService.Save();

                    var responseData = Mapper.Map<Driver, DriverViewModel>(dbDriver);
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
                    var oldDriver = _driverService.Delete(id);
                    _driverService.Save();

                    var responseData = Mapper.Map<Driver, DriverViewModel>(oldDriver);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        #endregion
    }
}
