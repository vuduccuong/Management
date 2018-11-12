using Management.Data.Infrastructure;
using Management.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Data.Repositories
{
    public interface ICarRepository : IRepository<Route>
    {
    }
    public class CarRepository : RepositoryBase<Route>, ICarRepository
    {
        public CarRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
