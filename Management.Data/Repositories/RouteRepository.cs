using Management.Data.Infrastructure;
using Management.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Data.Repositories
{
    public interface IRouteRepository : IRepository<Route>
    {
    }
    public class RouteRepository : RepositoryBase<Route>, IRouteRepository
    {
        public RouteRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
