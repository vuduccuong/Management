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
    public interface IBookService
    {
        Booking Add(Booking book);

        void Update(Booking book);

        Booking Delete(int id);

        IEnumerable<Booking> GetAll(int id);


        IEnumerable<GetBookViewModel> GetBookByIDCustomer(int id);

        Booking GetById(int id);

        void Save();
    }
    class BookService : IBookService
    {
        private IBookRepository _bookRepository;
        private IUnitOfWork _unitOfWork;

        public BookService(IBookRepository bookRepository, IUnitOfWork unitOfWork)
        {
            this._bookRepository = bookRepository;
            this._unitOfWork = unitOfWork;
        }
        public Booking Add(Booking book)
        {
            return _bookRepository.Add(book);
        }

        public Booking Delete(int id)
        {
            return _bookRepository.Delete(id);
        }

        public IEnumerable<Booking> GetAll(int id)
        {
            if (!string.IsNullOrEmpty(id.ToString()))
                return _bookRepository.GetMulti(x => x.IDCustomer == id);
            else
                return _bookRepository.GetAll();
        }

        public IEnumerable<GetBookViewModel> GetBookByIDCustomer(int id)
        {
            return _bookRepository.GetBookByIDCustomer(id);
        }

        public Booking GetById(int id)
        {
            return _bookRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Booking book)
        {
            _bookRepository.Update(book);
        }
    }
}
