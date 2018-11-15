using Management.Data.Infrastructure;
using Management.Data.Repositories;
using Management.Model.Models;
using System;
using System.Collections.Generic;

namespace Management.Service
{
    public interface IRouteService
    {
        Router Add(Router router);

        void Update(Router router);

        Router Delete(int id);

        IEnumerable<Router> GetAll(string keyword);

        Router GetById(int id);

        void Save();
    }
    class RouteService : IRouteService
    {

        private IRouteRepository _routeRepository;
        private IUnitOfWork _unitOfWork;

        public RouteService(IRouteRepository routeRepository, IUnitOfWork unitOfWork)
        {
            this._routeRepository = routeRepository;
            this._unitOfWork = unitOfWork;
        }

        public Router Add(Router route)
        {
            return _routeRepository.Add(route);
        }

        public Router Delete(int id)
        {
            return _routeRepository.Delete(id);
        }

        public IEnumerable<Router> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _routeRepository.GetMulti(x => x.StartPoint.Contains(keyword) || x.EndPoint.Contains(keyword));
            else
                return _routeRepository.GetAll();
        }

        public Router GetById(int id)
        {
            return _routeRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Router route)
        {
            _routeRepository.Update(route);
        }
    }
}
