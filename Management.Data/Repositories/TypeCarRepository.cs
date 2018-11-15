using Management.Data.Infrastructure;
using Management.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Data.Repositories
{
    public interface ITypeCarRepository : IRepository<TypeCar>
    {
    }
    public class TypeCarRepository : RepositoryBase<TypeCar>, ITypeCarRepository
    {
        public TypeCarRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
