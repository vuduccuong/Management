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
    public interface ICarRepository : IRepository<Car>
    {
        IEnumerable<CarDetailVewModel> GetAllDetail();
    }
    public class CarRepository : RepositoryBase<Car>, ICarRepository
    {
        public CarRepository(IDbFactory dbFactory) : base(dbFactory)
        {
            
        }
        public IEnumerable<CarDetailVewModel> GetAllDetail()
        {
            return DbContext.Database.SqlQuery<CarDetailVewModel>("Proc_CarDetal");
        }
    }
}
