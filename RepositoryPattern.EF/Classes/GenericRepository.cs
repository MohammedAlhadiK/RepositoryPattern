using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Core.Consts;
using RepositoryPattern.Core.Interfaces;

namespace RepositoryPattern.EF.Classes
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        ApplicationDBContext _dbContext;
        public GenericRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T Find(Expression<Func<T, bool>> match, string[] includes = null)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            foreach (var item in includes)
            {
                query = query.Include(item);
            }
            return query.SingleOrDefault(match);
        }

        public IQueryable<T> FindAll(Expression<Func<T, bool>> match, string[] includes = null)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            foreach (var item in includes)
            {
                query = query.Include(item);
            }
            return query.Where(match);
        }

        public IQueryable<T> FindAll(Expression<Func<T, bool>> match, int? skip, int? take, string[] includes = null)
        {
            return _dbContext.Set<T>().Where(match).Skip(skip.Value).Take(take.Value);
        }
        public IQueryable<T> GetOrdered(Expression<Func<T, bool>> match, int? skip, int? take, Expression<Func<T, object>> orderBy, string orderByDirection = OrderBy.Ascending, string[] includes = null)
        {
            var query = _dbContext.Set<T>().Where(match);

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }
            if (take.HasValue)
            { query = query.Take(take.Value); }

            if (orderBy != null)
            {

                if (orderByDirection == OrderBy.Descending)
                {
                    query = query.OrderByDescending(orderBy);
                }
                else
                {
                    query = query.OrderBy(orderBy);

                }
            }
            return query;
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }

        public T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            return entity;

        }

        public IQueryable<T> AddRange(IQueryable<T> entities)
        {
            _dbContext.Set<T>().AddRange(entities);
            return entities;
        }

        public void Update(T entity)
        {

            _dbContext.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Remove(entity);
        }

        public void UpdateRange(List<T> entities)
        {
            _dbContext.UpdateRange(entities);
        }

        public void DeleteRange(List<T> entities)
        {
            _dbContext.RemoveRange(entities);
        }
    }
}
