using AutoMapper;
using Management.Common.ViewModel;
using Management.Model.Models;
using Management.Service;
using Management.Web.Infrastructure.Core;
using Management.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Management.Web.Api
{
    [RoutePrefix("api/seat")]
    public class SeatController : ApiControllerBase
    {
        #region Initalize
        private ISeatService _seatService;
        private ISeatNoService _seatnoService;
        private IBookService _bookService;

        public SeatController(IErrorService errorService, ICarService carService, IBookService bookService, ISeatService seatService, ISeatNoService seatnoService)
            : base(errorService)
        {
            this._seatService = seatService;
            this._seatnoService = seatnoService;
            this._bookService = bookService;
        }
        #endregion

        #region GetSeatStatus
        [Route("getseatstatus")]
        [HttpGet]
        public HttpResponseMessage GetSeatStatus(HttpRequestMessage request, int id, string dateBook)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _seatService.GetSeatStatus(id, dateBook);

                //var responseData = Mapper.Map<IEnumerable<Car>, IEnumerable<CarViewModel>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, model);
                return response;
            });
        }
        #endregion


        #region UpdateStatusWhenDelCustomer
        [Route("updatestatus")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, int idCustomer)
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
                    
                    //Lấy IDSeatNo từ bảng Book theo IDCustomer Sau đó update status SeatNo theo IDSeat

                    var dbCar = _seatnoService.GetById(idCustomer);
                    dbCar.Status = false;

                    _seatnoService.Update(dbCar);
                    _seatnoService.Save();

                    var responseData = Mapper.Map<SeatNo, SeatNoViewModel>(dbCar);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }
        #endregion
    }
}
