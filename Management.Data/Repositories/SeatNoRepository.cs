using Management.Data.Infrastructure;
using Management.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Data.Repositories
{
    public interface ISeatNoRepository : IRepository<SeatNo>
    {
    }
    public class SeatNoRepository : RepositoryBase<SeatNo>, ISeatNoRepository
    {
        public SeatNoRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
