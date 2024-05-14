using System;
using System.Collections.Generic;
using System.Text;

namespace ProdStore.Data.Infrastructures
{
    public interface IUnitOfWork :IDisposable
    {
        void commit();
        IRepositoryBase<T> getRepository<T>() where T : class;
    }
}
