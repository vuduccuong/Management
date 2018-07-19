﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Data.Repositories
{
    public interface IDbFactory:IDisposable
    {
        ManagementDbContext Init();
    }
}
