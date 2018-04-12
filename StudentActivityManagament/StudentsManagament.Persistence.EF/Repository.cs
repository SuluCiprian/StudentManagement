using StudentsManagement.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace StudentsManagament.Persistence.EF
{
    public class Repository<T> : IRepository<T>
    {
        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
