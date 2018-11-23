using Management.Common.ViewModel;
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
    public interface ISeatService
    {
        Seat Add(Seat seat);

        void Update(Seat seat);

        Seat Delete(int id);

        IEnumerable<Seat> GetAll(string keyword);

        Seat GetById(int id);

        void Save();

        IEnumerable<Seat> GetSeatByCarID(int id);
        IEnumerable<SeatStatusViewModel> GetSeatStatus(int id);
    }
    class SeatService : ISeatService
    {
        private ISeatRepository _seatRepository;
        private IUnitOfWork _unitOfWork;

        public SeatService(ISeatRepository seatRepository, IUnitOfWork unitOfWork)
        {
            this._seatRepository = seatRepository;
            this._unitOfWork = unitOfWork;
        }

        public Seat Add(Seat seat)
        {
            return _seatRepository.Add(seat);
        }

        public Seat Delete(int id)
        {
            return _seatRepository.Delete(id);
        }

        public IEnumerable<Seat> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _seatRepository.GetMulti(x => x.IDCar.ToString() ==  (keyword) || x.isDel == false);
            else
                return _seatRepository.GetAll();
        }

        public Seat GetById(int id)
        {
            return _seatRepository.GetSingleById(id);
        }

        public IEnumerable<Seat> GetSeatByCarID(int id)
        {
           return _seatRepository.GetMulti(x => x.IDCar == id);
        }

        public IEnumerable<SeatStatusViewModel> GetSeatStatus(int id)
        {
            return _seatRepository.GetAllSeatStatus(id);
        }

        public void Save()
        {
             _unitOfWork.Commit();
        }

        public void Update(Seat seat)
        {
             _seatRepository.Update(seat);
        }
    }
}
