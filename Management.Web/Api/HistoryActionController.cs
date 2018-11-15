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
    [RoutePrefix("api/historyaction")]
    public class HistoryActionController : ApiControllerBase
    {
        #region Initalize
        private IHistoryActionService _historyActionService;

        public HistoryActionController(IErrorService errorService, IHistoryActionService historyActionService)
            : base(errorService)
        {
            this._historyActionService = historyActionService;
        }
        #endregion

        #region GetBySearch
        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _historyActionService.GetAll(keyword);

                var responseData = Mapper.Map<IEnumerable<HistoryAction>, IEnumerable<HistoryActionViewModel>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
        #endregion

        #region CreatNewHistoryAction
        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, HistoryActionViewModel historyActionVM)
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
                    var newHistoryAction = new HistoryAction();
                    newHistoryAction.UpdateHistoryAction(historyActionVM);
                    newHistoryAction.ActionDate = DateTime.Now;

                    _historyActionService.Add(newHistoryAction);
                    _historyActionService.Save();

                    var responseData = Mapper.Map<HistoryAction, HistoryActionViewModel>(newHistoryAction);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }
        #endregion
    }
}
