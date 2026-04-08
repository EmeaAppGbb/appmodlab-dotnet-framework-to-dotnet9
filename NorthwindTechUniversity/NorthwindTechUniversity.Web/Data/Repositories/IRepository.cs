using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NorthwindTechUniversity.Web.Data.Repositories
{
    // Legacy: Generic repository pattern (EF6 already implements repository pattern!)
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
