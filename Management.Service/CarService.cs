using Management.Data.Infrastructure;
using Management.Data.Repositories;
using Management.Model.Models;
using System;
using System.Collections.Generic;

namespace Management.Service
{
    public interface ICarService
    {
        Car Add(Car car);

        void Update(Car car);

        Car Delete(int id);

        IEnumerable<Car> GetAll(string keyword);

        Car GetById(int id);

        void Save();
    }
    class CarService : ICarService
    {
        private ICarRepository _carRepository;
        private IUnitOfWork _unitOfWork;

        public CarService(ICarRepository carRepository, IUnitOfWork unitOfWork)
        {
            this._carRepository = carRepository;
            this._unitOfWork = unitOfWork;
        }

        public Car Add(Car car)
        {
            return _carRepository.Add(car);
        }

        public Car Delete(int id)
        {
            return _carRepository.Delete(id);
        }

        public IEnumerable<Car> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _carRepository.GetMulti(x => x.Name.Contains(keyword) || x.Code.Contains(keyword));
            else
                return _carRepository.GetAll();
        }

        public Car GetById(int id)
        {
            return _carRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Car car)
        {
            _carRepository.Update(car);
        }
    }
}
