using Management.Data.Infrastructure;
using Management.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Data.Repositories
{
    public interface IRouteRepository : IRepository<Router>
    {
    }
    public class RouteRepository : RepositoryBase<Router>, IRouteRepository
    {
        public RouteRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
