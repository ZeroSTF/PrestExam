using ProdStore.Data.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Service.Pattern
{
    public class Service<T> : IService<T> where T : class
    {
       // static IDataBaseFactory factory = new DataBaseFactory();
        //static IUnitOfWork utk = new UnitOfWork(factory);
        private readonly IUnitOfWork utk;

        public Service(IUnitOfWork utk)
        {
            this.utk = utk;
        }

        public virtual void Add(T entity)
        {
            utk.getRepository<T>().Add(entity);
        }

        public virtual void Commit()
        {
            utk.commit();
        }

        public virtual void Delete(T entity)
        {
            utk.getRepository<T>().Delete(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            utk.getRepository<T>().Delete(where);
        }

        public void Dispose()
        {
            utk.Dispose();
        }

        public virtual T Get(Expression<Func<T, bool>> where)
        {
            return utk.getRepository<T>().Get(where);
        }

        public IEnumerable<T> GetAll()
        {
            return utk.getRepository<T>().GetAll();
        }

        public virtual T GetById(Object id)
        {
            return utk.getRepository<T>().GetById(id);
        }

        public virtual T GetById(string id)
        {
            return utk.getRepository<T>().GetById(id);
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where = null)
        {
            return utk.getRepository<T>().GetMany(where);
        }

        public virtual void Update(T entity)
        {
            utk.getRepository<T>().Update(entity);
        }
    }
}
