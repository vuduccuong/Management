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
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiControllerBase
    {
        #region Initalize
        private ICustomerService _customerService;
        private IBookService _bookService;
        private ISeatNoService _seatnoService;

        public CustomerController(IErrorService errorService, ICustomerService customerService, IBookService bookService, ISeatNoService seatnoService)
            : base(errorService)
        {
            this._customerService = customerService;
            this._bookService = bookService;
            this._seatnoService = seatnoService;
        }
        #endregion

        #region GetCustomerBySearch
        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _customerService.GetAll(keyword);

                var responseData = Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerViewModel>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, model);
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
                    var oldCustomer = _customerService.Delete(id);
                    _customerService.Save();

                    var responseData = Mapper.Map<Customer, CustomerViewModel>(oldCustomer);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        #endregion

        #region GetCustomerById
        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _customerService.GetCustDetail(id);


                var response = request.CreateResponse(HttpStatusCode.OK, model);

                return response;
            });
        }
        #endregion

        #region UpdateCustomer
        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, EditCustomerViewModel customerVm)
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

                   //Cập nhật thông tin khách hàng
                    var dbCust = _customerService.GetById(customerVm.IDCustomer);
                    dbCust.Name = customerVm.NameCustomer;
                    dbCust.PhoneNumber = customerVm.PhoneNumber;
                    dbCust.Email = customerVm.Email;
                    dbCust.Address = customerVm.Address;
                    

                    _customerService.Update(dbCust);
                    _customerService.Save();

                    //Cập nhật lại Book
                    var dbBook = _bookService.GetById(customerVm.IDBook);
                    dbBook.IDCar = customerVm.IDCar;
                    dbBook.IDSeat = customerVm.IDSeat;
                    dbBook.IDSeatNo = customerVm.IDSeatNo;
                    dbBook.UpdatedBy = customerVm.UpdatedBy;
                    dbBook.UpdatedDate = DateTime.Now;
                    dbBook.MetaDescription = customerVm.MetaDescription;

                    _bookService.Update(dbBook);
                    _bookService.Save();

                    //Update lại status
                    var dbSeatNo = _seatnoService.GetById(customerVm.oldIDSeatNo);
                    dbSeatNo.Status = false;
                    _seatnoService.Update(dbSeatNo);
                    _seatnoService.Save();

                    var dbNewSeatNo = _seatnoService.GetById(customerVm.IDSeatNo);
                    dbNewSeatNo.Status = true;
                    _seatnoService.Update(dbNewSeatNo);
                    _seatnoService.Save();

                    var responseData = Mapper.Map<Customer, CustomerViewModel>(dbCust);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }
        #endregion

        #region AddCustomer
        [Route("add")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, CustomerViewModel customerVM)
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
                    var newCus = new Customer();
                    newCus.UpdateCustomer(customerVM);
                    newCus.isDel = false;

                    _customerService.Add(newCus);
                    _customerService.Save();

                    response = request.CreateResponse(HttpStatusCode.Created, newCus);
                }
                return response;
            });
        }
        #endregion
    }
}
