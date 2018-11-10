using Management.Data.Infrastructure;
using Management.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Data.Repositories
{
    public interface ISeatRepository : IRepository<Seat>
    {
    }
    public class SeatRepository : RepositoryBase<Seat>, ISeatRepository
    {
        public SeatRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
