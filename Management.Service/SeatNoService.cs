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
    public interface ISeatNoService
    {
        SeatNo Add(SeatNo seatno);

        void Update(SeatNo seatno);

        SeatNo Delete(int id);

        IEnumerable<SeatNo> GetAll(string keyword);

        SeatNo GetById(int id);

        int UpdateStatus(bool status, int id);

        void Save();
    }
    class SeatNoService : ISeatNoService
    {
        private ISeatNoRepository _seatnoRepository;
        private IUnitOfWork _unitOfWork;

        public SeatNoService(ISeatNoRepository seatnoRepository, IUnitOfWork unitOfWork)
        {
            this._seatnoRepository = seatnoRepository;
            this._unitOfWork = unitOfWork;
        }

        public SeatNo Add(SeatNo seatno)
        {
            return _seatnoRepository.Add(seatno);
        }

        public SeatNo Delete(int id)
        {
            return _seatnoRepository.Delete(id);
        }

        public IEnumerable<SeatNo> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _seatnoRepository.GetMulti(x => x.IDSeat.ToString() ==(keyword) || x.SeatNb == int.Parse(keyword));
            else
                return _seatnoRepository.GetAll();
        }

        public SeatNo GetById(int id)
        {
            return _seatnoRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(SeatNo seatno)
        {
            _seatnoRepository.Update(seatno);
        }

        public int UpdateStatus(bool status, int id)
        {
             _seatnoRepository.UpdateStatus(status, id);
            return 1;
        }
    }
}
