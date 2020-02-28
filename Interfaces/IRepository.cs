using Temsharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Temsharp.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        IEnumerable<T> Get(Expression<Func<T, TypePermission>> predicate);

        Task<T> FindById(int id);

        Task Create(T entity);

        Task Delete(T entity);
    }
}
