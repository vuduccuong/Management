using Management.Service;
using Management.Web.Infrastructure.Core;
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

        public SeatController(IErrorService errorService, ICarService carService, ITypeCarService typecarService, ISeatService seatService, ISeatNoService seatnoService)
            : base(errorService)
        {
            this._seatService = seatService;
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
    }
}
