using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Repository.Interface
{
    public interface ICommonGenericRepository<T> where T : class
    {
        bool Add(T entity);

        bool Add(ICollection<T> entities);

        Task<bool> AddAsync(T entity);

        Task<bool> AddAsync(ICollection<T> entities);

        bool Update(T entity);

        bool Update(ICollection<T> entities);

        Task<bool> UpdateAsync(T entity);

        Task<bool> UpdateAsync(ICollection<T> entities);

        bool Delete(T entity);

        bool Delete(ICollection<T> entities);

        Task<bool> DeleteAsync(T entity);

        Task<bool> DeleteAsync(ICollection<T> entities);

        ICollection<T> GetAll(params Expression<Func<T, object>>[] include);

        Task<ICollection<T>> GetAllAsync(params Expression<Func<T, object>>[] include);

        ICollection<T> Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        Task<ICollection<T>> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        T GetFirstOrDefault(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

    }
}
