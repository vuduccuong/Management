using Management.Common.Exceptions;
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
    public interface IApplicationGroupService
    {
        ApplicationGroup GetDetail(int id);
        IEnumerable<ApplicationGroup> GetAll(string keyword);
        ApplicationGroup Add(ApplicationGroup applicationgroup);
        ApplicationGroup Delete(int id);
        void Update(ApplicationGroup applicationgroup);
        bool AddUserToGroup(IEnumerable<ApplicationUserGroup> userGroups, string userId);
        IEnumerable<ApplicationGroup> GetListGroupByUserId(string userId);
        IEnumerable<ApplicationUser> GetListUserByGroupId(int groupId);
        void Save();
    }
    class ApplicationGroupService : IApplicationGroupService
    {
        private IApplicationGroupRepository _appGroupRepository;
        private IUnitOfWork _unitOfWork;
        private IApplicationUserGroupRepository _appUserGropRepository;

        public ApplicationGroupService(IApplicationGroupRepository appGroupRepository,
            IUnitOfWork unitOfWork,
            IApplicationUserGroupRepository appUserGropRepository
            )
        {
            this._appGroupRepository = appGroupRepository;
            this._unitOfWork = unitOfWork;
            this._appUserGropRepository = appUserGropRepository;
        }

        public ApplicationGroup Add(ApplicationGroup applicationgroup)
        {
            if (_appGroupRepository.CheckContains(x=>x.Name == applicationgroup.Name))
            {
                throw new NameDuplicatedException("Tên không được trùng");
            }
            return _appGroupRepository.Add(applicationgroup); 
        }

        public bool AddUserToGroup(IEnumerable<ApplicationUserGroup> userGroups, string userId)
        {
            _appUserGropRepository.DeleteMulti(x => x.UserId == userId);
            foreach (var userGroup in userGroups)
            {
                _appUserGropRepository.Add(userGroup);
            }
            return true;
        }

        public ApplicationGroup Delete(int id)
        {
            var AppGroup = this._appGroupRepository.GetSingleById(id);
            return _appGroupRepository.Delete(AppGroup);
        }

        public IEnumerable<ApplicationGroup> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _appGroupRepository.GetMulti(x => x.Name.Contains(keyword));
            else
                return _appGroupRepository.GetAll();
        }

        public ApplicationGroup GetDetail(int id)
        {
            return _appGroupRepository.GetSingleById(id);
        }

        public IEnumerable<ApplicationGroup> GetListGroupByUserId(string userId)
        {
            return _appGroupRepository.GetListGroupByUserId(userId);
        }

        public IEnumerable<ApplicationUser> GetListUserByGroupId(int groupId)
        {
            return _appGroupRepository.GetListUserByGroupId(groupId);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ApplicationGroup applicationgroup)
        {
            if (_appGroupRepository.CheckContains(x => x.Name == applicationgroup.Name && x.ID!= applicationgroup.ID))
            {
                throw new NameDuplicatedException("Tên không được trùng");
            }
             _appGroupRepository.Update(applicationgroup);
        }
    }
}
