using AutoMapper;
using Management.Model.Models;
using Management.Service;
using Management.Web.Infrastructure.Core;
using Management.Web.Infrastructure.Extensions;
using Management.Web.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Management.Web.Api
{
    [RoutePrefix("api/booking")]
    public class BookController : ApiControllerBase
    {
        #region Initalize
        private ICustomerService _customerService;
        private IBookService _bookService;
        private ISeatNoService _seatnoService;
        private IBillService _billService;

        public BookController(IErrorService errorService, ICustomerService customerService, IBookService bookService, ISeatNoService seatnoService, IBillService billService)
            : base(errorService)
        {
            this._customerService = customerService;
            this._bookService = bookService;
            this._seatnoService = seatnoService;
            this._billService = billService;
        }
        #endregion


        #region GetBookBySearch
        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _bookService.GetAll(id);

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
                    //AddCustommer
                    _customerService.Add(newCustomer);
                    _customerService.Save();



                    //Thêm mới book
                    var newBook = new Booking();
                    newBook.IDCar = bookVm.IDCar;
                    newBook.IDCustomer = newCustomer.ID;
                    newBook.IDSeat = bookVm.IDSeat;
                    newBook.IDSeatNo = bookVm.IDSeatNo;
                    newBook.DateBook = DateTime.Now;
                    newBook.CreatedBy = bookVm.CreatedBy;
                    newBook.CreatedDate = DateTime.Now;
                    newBook.MetaDescription = bookVm.MetaDescription;
                    newBook.Status = true;
                    //AddBoook
                    _bookService.Add(newBook);
                    _bookService.Save();


                    //NewBill
                    var newBill = new Bill();
                    newBill.CustomerName = bookVm.NameCustomer;
                    newBill.CustomerPhone = bookVm.PhoneCustomer;
                    newBill.dateBook = bookVm.Date;
                    newBill.DatedBill = DateTime.Now;
                    newBill.IDCar = bookVm.IDCar;
                    newBill.SeatName = bookVm.SeatNoName;
                    newBill.CountMoney = "210000";
                    newBill.CustomerMail = bookVm.MailCustomer;
                    newBill.Status = false;

                    //AddBill
                    _billService.Add(newBill);
                    _billService.Save();


                    //update SeatNo
                    var dbSeatNo = _seatnoService.GetById(bookVm.IDSeatNo);
                    dbSeatNo.Status = true;
                    _seatnoService.Update(dbSeatNo);
                    _seatnoService.Save();

                    var responseData = Mapper.Map<Customer, CustomerViewModel>(newCustomer);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }
        #endregion

        #region CreatNewBookFront
        [Route("createfront")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage CreateFront(HttpRequestMessage request, [FromBody] BookViewModel bookVm)
        {

            //Thêm mới khách hàng
            //var newCustomer = new Customer();
            //newCustomer.Name = bookVm.NameCustomer;
            //newCustomer.PhoneNumber = bookVm.PhoneCustomer;
            //newCustomer.Email = bookVm.MailCustomer;
            //newCustomer.Address = bookVm.AddressCustomer;
            //newCustomer.isDel = false;
            //AddCustommer
            //_customerService.Add(newCustomer);
            //_customerService.Save();



            //Thêm mới book
            var newBook = new Booking();
            newBook.IDCar = bookVm.IDCar;
            //newBook.IDCustomer = newCustomer.ID;
            newBook.IDSeat = bookVm.IDSeat;
            newBook.IDSeatNo = bookVm.IDSeatNo;
            newBook.DateBook = DateTime.Now;
            newBook.CreatedBy = bookVm.CreatedBy;
            newBook.CreatedDate = DateTime.Now;
            newBook.MetaDescription = bookVm.MetaDescription;
            newBook.Status = true;
            //AddBoook
            _bookService.Add(newBook);
            _bookService.Save();

            ////NewBill
            //var newBill = new Bill();
            //newBill.CustomerName = bookVm.NameCustomer;
            //newBill.CustomerPhone = bookVm.PhoneCustomer;
            //newBill.dateBook = bookVm.Date;
            //newBill.DatedBill = DateTime.Now;
            //newBill.IDCar = bookVm.IDCar;
            //newBill.SeatName = bookVm.SeatNoName;

            ////AddBill
            //_billService.Add(newBill);
            //_billService.Save();

            //update SeatNo
            var dbSeatNo = _seatnoService.GetById(bookVm.IDSeatNo);
            dbSeatNo.Status = true;
            _seatnoService.Update(dbSeatNo);
            _seatnoService.Save();

            //var responseData = Mapper.Map<Customer, CustomerViewModel>(newCustomer);
            return request.CreateResponse(HttpStatusCode.Created, "OK");

        }
        #endregion


        #region CreatNewBill
        [Route("createbill")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Createbill(HttpRequestMessage request, [FromBody] BookViewModel bookVm)
        {
            //NewBill
            var newBill = new Bill();
            newBill.CustomerName = bookVm.NameCustomer;
            newBill.CustomerPhone = bookVm.PhoneCustomer;
            newBill.dateBook = bookVm.Date;
            newBill.DatedBill = DateTime.Now;
            newBill.IDCar = bookVm.IDCar;
            newBill.CustomerMail = bookVm.MailCustomer;
            newBill.SeatName = bookVm.SeatNoName;
            string[] str = bookVm.SeatNoName.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            int mouney = 210000 * (int.Parse(str.Length.ToString()));
            newBill.CountMoney = mouney.ToString();
            newBill.Status = false;

            //AddBill
            _billService.Add(newBill);
            _billService.Save();



            //var responseData = Mapper.Map<Customer, CustomerViewModel>(newCustomer);
            return request.CreateResponse(HttpStatusCode.Created, newBill);

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
                    var oldBook = _bookService.Delete(id);
                    _bookService.Save();

                    response = request.CreateResponse(HttpStatusCode.Created, oldBook);
                }

                return response;
            });
        }

        #endregion

        #region GetBillBySearch
        [Route("getallbill")]
        [HttpGet]
        public HttpResponseMessage GetAllBill(HttpRequestMessage request, string keyword)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _billService.GettAllByStatus(keyword);

                var responseData = Mapper.Map<IEnumerable<Bill>, IEnumerable<BillViewModel>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
        #endregion

        #region GetBillTrue
        [Route("getallbilltrue")]
        [HttpGet]
        public HttpResponseMessage GetAllBillTrue(HttpRequestMessage request, string keyword)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _billService.GettAllByStatusTrue(keyword);

                var responseData = Mapper.Map<IEnumerable<Bill>, IEnumerable<BillViewModel>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
        #endregion

        #region SentMail
        [Route("sentmail")]
        [HttpPost]
        public bool SentMail([FromBody] BillViewModel billVm)
        {
            try
            {


                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress(billVm.CustomerMail);
                mail.To.Add(billVm.CustomerMail);
                mail.Subject = "Xác nhận đặt vé xe ngày" + billVm.dateBook;

                RandomGenerator generator = new RandomGenerator();
                string str = generator.RandomString(10, false);

                mail.Body = "Cảm ơn <strong>" + billVm.CustomerName + "</strong> đã sử dụng dịch vụ của nhà xe HAPA <br /><hr /> Đây là mã chuyến đi của bạn, vui lòng mang mã để xác nhận trên chuyến đi của bạn : <strong>" + str + "</strong> <br /><hr />" +
                    "Bạn vui lòng <a href='http://localhost:19968/Home/Confirm?id=" + billVm.ID + "&confirm=" + str + "'>click vào đây</a> để xác nhận chuyến đi";

                mail.IsBodyHtml = true;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("noreply.hapa@gmail.com", "*#*#0000#*#*");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);

                //   //Send SMS

                //   const string accountSid = "ACef01e35217a812ef7e2b100d74fdd4cf";
                //   const string authToken = "33d3081567b3aa95f4165483247f2e28";
                //   TwilioClient.Init(accountSid, authToken);

                //   var message = MessageResource.Create(
                //to: new PhoneNumber("+84976472341"),
                //from: new PhoneNumber("+84343382777"),
                //body: "Hello from C#");

                return true;
                // phải làm cái này ở mail dùng để gửi phải bật lên
                // https://www.google.com/settings/u/1/security/lesssecureapps
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region UpdateConfirmMail
        [Route("confirmmail")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage ConfirmMail(HttpRequestMessage request, int id, string confirmcode)
        {
            var oldBill = _billService.GetById(id);
            oldBill.ConfirmCode = confirmcode;
            oldBill.Status = true;

            _billService.Update(oldBill);
            _billService.Save();



            //var responseData = Mapper.Map<Customer, CustomerViewModel>(newCustomer);
            return request.CreateResponse(HttpStatusCode.Created, oldBill);

        }
        #endregion

        #region SearchTicket
        [Route("searchticket")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage SearchTicket(HttpRequestMessage request, string code, string phone)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _billService.SearchTicket(code, phone);
                //var responseData = Mapper.Map<IEnumerable<Bill>, IEnumerable<BillViewModel>>(model);
                return request.CreateResponse(HttpStatusCode.Created, model);

            });
        }
        #endregion


        #region Get Count
        [Route("getcount")]
        [HttpGet]
        public HttpResponseMessage GetCount(HttpRequestMessage request, string keyword)
        {
            return CreateHttpResponse(request, () =>
            {
                var lstData = _billService.GetAll(keyword);
                
                var count = lstData.Count(); //count all
                var counttrue = lstData.Where(x => x.Status == true).Count(); //count where true
                var countfalse = lstData.Where(x => x.Status != true).Count(); //count where != true
                var datares = new
                {
                    CountAll = count,
                    CountWhereTrue = counttrue,
                    CountNotTrue = countfalse,
                    data = lstData,
                };
                var response = request.CreateResponse(HttpStatusCode.OK, datares);
                return response;
            });
        }
        #endregion
    }
}
