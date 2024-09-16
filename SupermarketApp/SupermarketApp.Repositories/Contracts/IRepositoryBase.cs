using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketApp.Repositories.Contracts
{
    public interface IRepositoryBase<T>
    {
        Task<List<T>> FindAllAsync(bool trackChanges);
        Task<List<T>> FindByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges);
        Task<T> FindByIdAsync(int id, bool trackChanges);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
