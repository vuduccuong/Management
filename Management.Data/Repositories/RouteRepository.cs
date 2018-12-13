using Management.Common.ViewModel;
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
        List<RouteViewModel> GetAllRoute();
    }
    public class RouteRepository : RepositoryBase<Router>, IRouteRepository
    {
        public RouteRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public List<RouteViewModel> GetAllRoute()
        {
            var query =
    from c in DbContext.Routers
    group c by new
    {
        c.StartPoint,
        c.EndPoint,
    } into gcs
    select new RouteViewModel()
    {
        StartPoint = gcs.Key.StartPoint,
        EndPoint = gcs.Key.EndPoint,
    };

            return query.ToList();
        }
    }
}
