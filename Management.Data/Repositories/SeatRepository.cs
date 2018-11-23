using Management.Common.ViewModel;
using Management.Data.Infrastructure;
using Management.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Data.Repositories
{
    public interface ISeatRepository : IRepository<Seat>
    {
        IEnumerable<SeatStatusViewModel> GetAllSeatStatus(int id);
    }
    public class SeatRepository : RepositoryBase<Seat>, ISeatRepository
    {
        public SeatRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<SeatStatusViewModel> GetAllSeatStatus(int id)
        {
            var parameters = new Object[]
            {
                new SqlParameter("@IDCar",id)
            };
             return DbContext.Database.SqlQuery<SeatStatusViewModel>("Proc_Status_Seat1  @IDCar", parameters);
        }
    }
}
