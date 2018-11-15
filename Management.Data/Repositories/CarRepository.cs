using Management.Data.Infrastructure;
using Management.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Data.Repositories
{
    public interface ICarRepository : IRepository<Car>
    {
    }
    public class CarRepository : RepositoryBase<Car>, ICarRepository
    {
        public CarRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
        public IEnumerable<Car> GetAllDetail()
        {
            var query = from c in DbContext.Cars
                        join dr in DbContext.Drivers
                        on c.IDDriver equals dr.ID
                        join rot in DbContext.Routers
                        on c.IDRouter equals rot.ID
                        where c.Status
                        orderby c.CreatedDate descending
                        select c;
            return query;
        }
    }
}
