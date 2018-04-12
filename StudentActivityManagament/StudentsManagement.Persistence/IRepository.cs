using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StudentsManagement.Persistence
{
    public interface IRepository<T>
    {
        void Insert(T entity);
        void Delete(T entity);
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> SearchFor(Expression<Func<T, bool>> predicate);
    }
}
