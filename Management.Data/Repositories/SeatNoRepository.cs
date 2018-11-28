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
    public interface ISeatNoRepository : IRepository<SeatNo>
    {
        int UpdateStatus(bool status, int id);
    }
    public class SeatNoRepository : RepositoryBase<SeatNo>, ISeatNoRepository
    {
        public SeatNoRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public int UpdateStatus(bool status, int id)
        {
            var parameters = new Object[]
            {
                new SqlParameter("@Status",status),
                new SqlParameter("@ID",id),
            };
            DbContext.Database.SqlQuery<upDateSeatNoStatusViewModel>("Proc_UpdateStatus2 @Status, @ID", parameters);
            return 1;
        }
    }
}
