using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management.Common.Exceptions;
using Management.Data.Infrastructure;
using Management.Data.Repositories;
using Management.Model.Models;

namespace Management.Service
{
    public interface IApplicationRoleService
    {
        ApplicationRole GetDetail(string id);

        IEnumerable<ApplicationRole> GetAll(string keyword);

        ApplicationRole Add(ApplicationRole appRole);

        void Update(ApplicationRole AppRole);

        void Delete(string id);

        //Add roles to a sepcify group
        bool AddRolesToGroup(IEnumerable<ApplicationRoleGroup> roleGroups, int groupId);

        //Get list role by group id
        IEnumerable<ApplicationRole> GetListRoleByGroupId(int groupId);

        void Save();
    }

    public class ApplicationRoleService : IApplicationRoleService
    {
        private IApplicationRoleRepository _appRoleRepository;
        private IApplicationRoleGroupRepository _appRoleGroupRepository;
        private IUnitOfWork _unitOfWork;

        public ApplicationRoleService(IUnitOfWork unitOfWork,
            IApplicationRoleRepository appRoleRepository, IApplicationRoleGroupRepository appRoleGroupRepository)
        {
            this._appRoleRepository = appRoleRepository;
            this._appRoleGroupRepository = appRoleGroupRepository;
            this._unitOfWork = unitOfWork;
        }

        public ApplicationRole Add(ApplicationRole appRole)
        {
            if (_appRoleRepository.CheckContains(x => x.Description == appRole.Description))
                throw new NameDuplicatedException("Tên không được trùng");
            return _appRoleRepository.Add(appRole);
        }

        public bool AddRolesToGroup(IEnumerable<ApplicationRoleGroup> roleGroups, int groupId)
        {
            _appRoleGroupRepository.DeleteMulti(x => x.GroupId == groupId);
            foreach (var roleGroup in roleGroups)
            {
                _appRoleGroupRepository.Add(roleGroup);
            }
            return true;
        }

        

        public IEnumerable<ApplicationRole> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _appRoleRepository.GetMulti(x => x.Name.Contains(keyword));
            else
                return _appRoleRepository.GetAll();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ApplicationRole AppRole)
        {
            if (_appRoleRepository.CheckContains(x => x.Description == AppRole.Description))
                throw new NameDuplicatedException("Tên không được trùng");
            _appRoleRepository.Update(AppRole);
        }

        public IEnumerable<ApplicationRole> GetListRoleByGroupId(int groupId)
        {
            return _appRoleRepository.GetListRoleByGroupId(groupId);
        }

        public ApplicationRole GetDetail(string id)
        {
            return _appRoleRepository.GetSingleByCondition(x => x.Id == id);

        }

        public void Delete(string id)
        {
            _appRoleRepository.DeleteMulti(x => x.Id == id);

        }
    }
}
