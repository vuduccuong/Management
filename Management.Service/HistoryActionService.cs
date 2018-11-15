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
    public interface IHistoryActionService
    {
        HistoryAction Add(HistoryAction historyAction);

        IEnumerable<HistoryAction> GetAll(string keyword);

        void Save();
    }
    class HistoryActionService : IHistoryActionService
    {
        private IHistoryActionRepository _historyActionRepository;
        private IUnitOfWork _unitOfWork;

        public HistoryActionService(IHistoryActionRepository historyActionRepository, IUnitOfWork unitOfWork)
        {
            this._historyActionRepository = historyActionRepository;
            this._unitOfWork = unitOfWork;
        }

        public HistoryAction Add(HistoryAction historyAction)
        {
            return _historyActionRepository.Add(historyAction);
        }

        public IEnumerable<HistoryAction> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _historyActionRepository.GetMulti(x => x.UserName.Contains(keyword) || x.ActionName.Contains(keyword));
            else
                return _historyActionRepository.GetAll();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
