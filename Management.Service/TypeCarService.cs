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
    public interface ITypeCarService
    {
        IEnumerable<TypeCar> GetAll();

        TypeCar GetById(int id);
    }
    class TypeCarService : ITypeCarService
    {
        private ITypeCarRepository _typecarRepository;
        private IUnitOfWork _unitOfWork;

        public TypeCarService(ITypeCarRepository typecarRepository, IUnitOfWork unitOfWork)
        {
            this._typecarRepository = typecarRepository;
            this._unitOfWork = unitOfWork;
        }
        public IEnumerable<TypeCar> GetAll()
        {
                return _typecarRepository.GetAll();
        }

        public TypeCar GetById(int id)
        {
            return _typecarRepository.GetSingleById(id);
        }
    }
}
