using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Data.Infrastructure
{
    public class DbFactory:Disposable,IDbFactory
    {
        private ManagementDbContext dbContext;

        public ManagementDbContext Init()
        {
            return dbContext ?? (dbContext = new ManagementDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }

    }
}
