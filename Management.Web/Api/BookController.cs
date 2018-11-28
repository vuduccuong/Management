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
    [RoutePrefix("api/booking")]
    public class BookController : ApiControllerBase
    {
        #region Initalize
        private ICustomerService _customerService;
        private IBookService _bookService;
        private ISeatNoService _seatnoService;

        public BookController(IErrorService errorService, ICustomerService customerService, IBookService bookService, ISeatNoService seatnoService)
            : base(errorService)
        {
            this._customerService = customerService;
            this._bookService = bookService;
            this._seatnoService = seatnoService;
        }
        #endregion


        #region GetBookBySearch
        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _bookService.GetAll(keyword);

                //var responseData = Mapper.Map<IEnumerable<Car>, IEnumerable<CarViewModel>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, model);
                return response;
            });
        }
        #endregion

        #region CreatNewBook
        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, BookViewModel bookVm)
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
                    //Thêm mới khách hàng
                    var newCustomer = new Customer();
                    newCustomer.Name = bookVm.NameCustomer;
                    newCustomer.PhoneNumber = bookVm.PhoneCustomer;
                    newCustomer.Email = bookVm.MailCustomer;
                    newCustomer.Address = bookVm.AddressCustomer;
                    newCustomer.isDel = false;




                    //Thêm mới book
                    var newBook = new Booking();
                    newBook.IDCar = bookVm.IDCar;
                    newBook.IDCustomer = newCustomer.ID;
                    newBook.IDSeat = bookVm.IDSeat;
                    newBook.IDSeatNo = bookVm.IDSeatNo;
                    newBook.DateBook = DateTime.Now;
                    newBook.CreatedBy = bookVm.CreatedBy;
                    newBook.CreatedDate = DateTime.Now;
                    newBook.Status = true;

                    //update SeatNo
                    var dbSeatNo = _seatnoService.GetById(bookVm.IDSeatNo);
                    dbSeatNo.Status = true;

                    _seatnoService.Update(dbSeatNo);
                    _seatnoService.Save();



                    //AddCustommer
                    _customerService.Add(newCustomer);
                    _customerService.Save();

                    //AddBoook
                    _bookService.Add(newBook);
                    _bookService.Save();

                var responseData = Mapper.Map<Customer, CustomerViewModel>(newCustomer);
                response = request.CreateResponse(HttpStatusCode.Created, responseData);
            }

                return response;
        });
        }
    #endregion
}
}
