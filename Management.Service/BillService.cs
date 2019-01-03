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
    public interface IBillService
    {
        Bill Add(Bill bill);

        void Update(Bill bill);

        Bill Delete(int id);

        IEnumerable<Bill> GetAll(string keyword);
        IEnumerable<Bill> GettAllByStatus(string keyword);
        IEnumerable<Bill> GettAllByStatusTrue(string keyword);
        IEnumerable<SearchTicketViewModel> SearchTicket(string code, string phone);

        Bill GetById(int id);

        void Save();
    }
    class BillService : IBillService
    {
        private IBillRepository _billRepository;
        private IUnitOfWork _unitOfWork;

        public BillService(IBillRepository billRepository, IUnitOfWork unitOfWork)
        {
            this._billRepository = billRepository;
            this._unitOfWork = unitOfWork;
        }

        public Bill Add(Bill bill)
        {
            return _billRepository.Add(bill);
        }

        public Bill Delete(int id)
        {
            return _billRepository.Delete(id);
        }

        public IEnumerable<Bill> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _billRepository.GetMulti(x => x.CustomerName.Contains(keyword) || x.CustomerPhone.Contains(keyword));
            else
                return _billRepository.GetAll();
        }

        public Bill GetById(int id)
        {
            return _billRepository.GetSingleById(id);
        }

        public IEnumerable<Bill> GettAllByStatus(string keyword)
        {
            return _billRepository.GetAllByStatus(keyword);
        }

        public IEnumerable<Bill> GettAllByStatusTrue(string keyword)
        {
            return _billRepository.GetAllByStatusTrue(keyword);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<SearchTicketViewModel> SearchTicket(string code, string phone)
        {
            return _billRepository.SearchTicket(code, phone);
        }

        public void Update(Bill bill)
        {
            _billRepository.Update(bill);
        }
    }
}
