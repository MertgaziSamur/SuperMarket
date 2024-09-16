using Microsoft.EntityFrameworkCore;
using SupermarketApp.Entities.Contracts;
using SupermarketApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketApp.Repositories.EfCore
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity, new()
    {

        protected readonly RepositoryContext _context;

        public RepositoryBase(RepositoryContext context)
        {
            _context = context;
        }
        public void Create(T entity) => _context.Set<T>().Add(entity);

        public void Delete(T entity) => _context?.Set<T>().Remove(entity);

        public async Task<List<T>> FindAllAsync(bool trackChanges) =>
            !trackChanges ?
            await _context.Set<T>().AsNoTracking().ToListAsync() :
            await _context.Set<T>().ToListAsync();

        public async Task<List<T>> FindByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ?
            await _context.Set<T>().Where(expression).AsNoTracking().ToListAsync() :
            await _context.Set<T>().Where(expression).ToListAsync();

        public async Task<T> FindByIdAsync(int id, bool trackChanges) =>
        !trackChanges ?
            await _context.Set<T>().Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync() :
            await _context.Set<T>().Where(x => x.Id == id).FirstOrDefaultAsync();

        public void Update(T entity) => _context.Set<T>().Update(entity);
    }
}
