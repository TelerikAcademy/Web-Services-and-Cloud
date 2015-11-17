using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Data.Repositories;

namespace Tests.Data.UnitsOfWork
{
    public interface IUnitOfWork
    {
        IRepository<T> Get<T>()
            where T : class;

        int SaveChanges();
    }
}
