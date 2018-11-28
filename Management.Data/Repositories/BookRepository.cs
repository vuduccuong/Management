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
    public interface IBookRepository : IRepository<Booking>
    {
        IEnumerable<GetBookViewModel> GetBookByIDCustomer(int idCustomer);
    }
    public class BookRepository : RepositoryBase<Booking>, IBookRepository
    {
        public BookRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<GetBookViewModel> GetBookByIDCustomer(int idCustomer)
        {
            var paramester = new Object[]
            {
                new SqlParameter("@IDCustomer", idCustomer),
            };
            return DbContext.Database.SqlQuery<GetBookViewModel>("Proc_GetByIDCus @IDCustomer", paramester);
        }
    }
}
