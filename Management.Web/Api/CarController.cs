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
    [RoutePrefix("api/car")]
    public class CarController : ApiControllerBase
    {

        #region Initalize
        private ICarService _carService;
        private ITypeCarService _typecarService;
        private ISeatService _seatService;
        private ISeatNoService _seatnoService;

        public CarController(IErrorService errorService, ICarService carService, ITypeCarService typecarService, ISeatService seatService, ISeatNoService seatnoService)
            : base(errorService)
        {
            this._carService = carService;
            this._typecarService = typecarService;
            this._seatService = seatService;
            this._seatnoService = seatnoService;
        }
        #endregion

        #region GetCarBySearch
        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _carService.GetAllDetail();

                //var responseData = Mapper.Map<IEnumerable<Car>, IEnumerable<CarViewModel>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, model);
                return response;
            });
        }
        #endregion

        #region GetAllTypeCar
        [Route("getalltypecars")]
        [HttpGet]
        public HttpResponseMessage GetAllTypeCars(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _typecarService.GetAll();

                var responseData = Mapper.Map<IEnumerable<TypeCar>, IEnumerable<TypeCarViewModel>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
        #endregion

        #region GetCarById
        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _carService.GetById(id);

                var responseData = Mapper.Map<Car, CarViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }
        #endregion

        #region CreatNewCar
        [Route("create")]
        [HttpPost] 
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, CarViewModel carVm)
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
                    var crSeat = new Seat();
                    var crSeatNo = new SeatNo();
                    string[] seat = new string[] { "A", "B", "C", "D", "E", "G", "H", "I","K" };

                    var newCar = new Car();
                    newCar.UpdateCar(carVm);
                    newCar.CreatedDate = DateTime.Now;

                    _carService.Add(newCar);
                    _carService.Save();

                    for (int i = 0; i < 9; i++)
                    {
                        crSeat.IDCar = newCar.ID;
                        crSeat.Row = seat[i];
                        crSeat.isDel = false;
                        _seatService.Add(crSeat);
                        _seatService.Save();

                        if (seat[i] == "K") //Hàng cuối luôn 5 ghế
                        {
                            for (int j = 1; j < 6; j++)
                            {
                                crSeatNo.IDSeat = crSeat.ID;
                                crSeatNo.SeatNb = j;
                                crSeatNo.Status = false;
                                _seatnoService.Add(crSeatNo);
                                _seatnoService.Save();
                            }
                        }

                        else //Các hàng còn lại 4 ghế
                            for (int j = 1; j < 5; j++)
                            {
                                crSeatNo.IDSeat = crSeat.ID;
                                crSeatNo.SeatNb = j;
                                crSeatNo.Status = false;
                                _seatnoService.Add(crSeatNo);
                                _seatnoService.Save();
                            }
                    }



                    var responseData = Mapper.Map<Car, CarViewModel>(newCar);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }
        #endregion

        #region UpdateCar
        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, CarViewModel carVm)
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
                    var dbCar = _carService.GetById(carVm.ID);

                    dbCar.UpdateCar(carVm);
                    dbCar.UpdatedDate = DateTime.Now;

                    _carService.Update(dbCar);
                    _carService.Save();

                    var responseData = Mapper.Map<Car, CarViewModel>(dbCar);
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
                    var oldCar = _carService.Delete(id);
                    _carService.Save();

                    var responseData = Mapper.Map<Car, CarViewModel>(oldCar);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        #endregion
    }
}
