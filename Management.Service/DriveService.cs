using Management.Data.Infrastructure;
using Management.Data.Repositories;
using Management.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Service
{
    public interface IDriverService
    {
        Driver Add(Driver driver);

        void Update(Driver driver);

        Driver Delete(int id);

        IEnumerable<Driver> GetAll(string keyword);

        Driver GetById(int id);

        void Save();
    }
    class DriverService : IDriverService
    {
        private IDriverRepository _driverRepository;
        private IUnitOfWork _unitOfWork;

        public DriverService(IDriverRepository driverRepository, IUnitOfWork unitOfWork)
        {
            this._driverRepository = driverRepository;
            this._unitOfWork = unitOfWork;
        }

        public Driver Add(Driver driver)
        {
            return _driverRepository.Add(driver);
        }

        public Driver Delete(int id)
        {
            return _driverRepository.Delete(id);
        }

        public IEnumerable<Driver> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _driverRepository.GetMulti(x => x.Name.Contains(keyword) || x.Address.Contains(keyword));
            else
                return _driverRepository.GetAll();
        }

        public Driver GetById(int id)
        {
            return _driverRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Driver driver)
        {
            _driverRepository.Update(driver);
        }
    }
}
