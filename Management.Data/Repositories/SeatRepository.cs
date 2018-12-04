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
        IEnumerable<SeatStatusViewModel> GetAllSeatStatus(int id, string dateBook);
        IEnumerable<SeatNoViewModel> GetAllSeatNoByIDSeat(int id, string dateBook);
    }
    public class SeatRepository : RepositoryBase<Seat>, ISeatRepository
    {
        public SeatRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<SeatNoViewModel> GetAllSeatNoByIDSeat(int id, string dateBook)
        {
            var parameters = new Object[]
            {
                new SqlParameter("@IDSeat", id),
                new SqlParameter("@DateBook", dateBook),
            };
            return DbContext.Database.SqlQuery<SeatNoViewModel>("GetSeatNoBySeat @IDSeat, @DateBook", parameters);
        }

        public IEnumerable<SeatStatusViewModel> GetAllSeatStatus(int id, string dateBook)
        {
            var parameters = new Object[]
            {
                new SqlParameter("@IDCar",id),
                new SqlParameter("@DateBook",dateBook)
            };
             return DbContext.Database.SqlQuery<SeatStatusViewModel>("Proc_Status_Seat  @IDCar, @DateBook", parameters);
        }
    }
}
