using Microsoft.EntityFrameworkCore;
using MovieManagement.Data.Context;
using MovieManagement.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Repository.Repository
{
    public class CommonGenericRepository<T> : ICommonGenericRepository<T>  where T : class
    {
        private DbContext db;
        protected DbSet<T> Table;
        public CommonGenericRepository(DbContext dbContext)
        {
            db = dbContext;
            Table = db.Set<T>();
        }
        public bool Add(T entity)
        {
            Table.Add(entity);
            return db.SaveChanges() > 0;
        }

        public bool Add(ICollection<T> entities)
        {
            Table.AddRange(entities);
            return db.SaveChanges() > 0;
        }

        public async Task<bool> AddAsync(T entity)
        {
            Table.Add(entity);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddAsync(ICollection<T> entities)
        {
            Table.AddRange(entities);
            return await db.SaveChangesAsync() > 0;
        }

        public bool Update(T entity)
        {
            Table.Update(entity);
            return db.SaveChanges() > 0;
        }

        public bool Update(ICollection<T> entities)
        {
            Table.UpdateRange(entities.ToArray());
            return db.SaveChanges() > 0;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            Table.Update(entity);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(ICollection<T> entities)
        {
            Table.UpdateRange(entities);
            return await db.SaveChangesAsync() > 0;
        }

        public bool Delete(T entity)
        {
            Table.Remove(entity);
            return db.SaveChanges() > 0;
        }

        public bool Delete(ICollection<T> entities)
        {
            Table.RemoveRange(entities);
            return db.SaveChanges() > 0;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            Table.Remove(entity);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(ICollection<T> entities)
        {
            Table.RemoveRange(entities);
            return await db.SaveChangesAsync() > 0;
        }

        public ICollection<T> Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            return includes.Aggregate(Table.AsNoTracking().AsQueryable(), (IQueryable<T> current, Expression<Func<T, object>> include) => current.Include(include), (IQueryable<T> c) => c.Where(predicate)).ToList();
        }

        public async Task<ICollection<T>> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            return await includes.Aggregate(Table.AsNoTracking().AsQueryable(), (IQueryable<T> current, Expression<Func<T, object>> include) => current.Include(include), (IQueryable<T> c) => c.Where(predicate)).ToListAsync();
        }

        public ICollection<T> GetAll(params Expression<Func<T, object>>[] include)
        {
            return include.Aggregate(Table.AsNoTracking().AsQueryable(), (IQueryable<T> current, Expression<Func<T, object>> includes) => current.Include(includes)).ToList();
        }

        public async Task<ICollection<T>> GetAllAsync(params Expression<Func<T, object>>[] include)
        {
            return await include.Aggregate(Table.AsNoTracking().AsQueryable(), (IQueryable<T> current, Expression<Func<T, object>> includes) => current.Include(includes)).ToListAsync();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            return includes.Aggregate(Table.AsNoTracking().AsQueryable(), (IQueryable<T> current, Expression<Func<T, object>> include) => current.Include(include), (IQueryable<T> c) => c.FirstOrDefault(predicate));
        }

        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            return await includes.Aggregate(Table.AsNoTracking().AsQueryable(), (IQueryable<T> current, Expression<Func<T, object>> include) => current.Include(include), (IQueryable<T> c) => c.FirstOrDefaultAsync(predicate));
        }
    }
}