using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Temsharp.Interfaces;
using Temsharp.Models;

namespace Temsharp.Data
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly PermissionsContext _context;

        public GenericRepository(PermissionsContext context)
        {
            _context = context;
        }

        public async Task<T> FindById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public IEnumerable<T> Get(Expression<Func<T, TypePermission>> predicate)
        {
            return _context.Set<T>().Include(predicate).ToList();
        }

        public async Task Create(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
