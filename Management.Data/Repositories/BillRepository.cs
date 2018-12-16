using Management.Data.Infrastructure;
using Management.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Data.Repositories
{
    public interface IBillRepository : IRepository<Bill>
    {
        IEnumerable<Bill> GetAllByStatus(string keyword);
        IEnumerable<Bill> GetAllByStatusTrue(string keyword);

        IEnumerable<Bill> SearchTicket(string code, string phone);
    }
    public class BillRepository : RepositoryBase<Bill>, IBillRepository
    {
        public BillRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Bill> GetAllByStatus(string keyword)
        {
            var query = from b in DbContext.Bills
                        where b.Status == false
                        select b;

            return query;
        }

        public IEnumerable<Bill> GetAllByStatusTrue(string keyword)
        {
            var query = from b in DbContext.Bills
                        where b.Status == true
                        select b;

            return query;
        }

        public IEnumerable<Bill> SearchTicket(string code, string phone)
        {
            var query = from b in DbContext.Bills
                        where b.Status==true && b.ConfirmCode.Contains(code) && b.CustomerPhone.Contains(phone)
                        select b;

            return query;
        }
    }
}
