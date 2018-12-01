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
    public interface ICustomerRepository : IRepository<Customer>
    {
        IEnumerable<Booking> GetIDSeatNo(int id);
        IEnumerable<CustomerDetailViewModel> GetCustDetail(int id);
    }
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<CustomerDetailViewModel> GetCustDetail(int id)
        {
            var parameters = new Object[]
            {
                new SqlParameter("@ID",id)
            };
            return DbContext.Database.SqlQuery<CustomerDetailViewModel>("Proc_GetCustDetail @ID", parameters);
        }

        public IEnumerable<Booking> GetIDSeatNo(int id)
        {
            var parameters = new Object[]
            {
                new SqlParameter("@IDCustomer",id)
            };
            return this.DbContext.Database.SqlQuery<Booking>("GetBookWhereIDCus @IDCustomer", parameters);
        }
    }
}
