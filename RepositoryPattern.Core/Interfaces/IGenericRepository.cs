using RepositoryPattern.Core.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        IQueryable<T> GetAll();
        T Find(Expression<Func<T, bool>> match, string[] includes = null);
        IQueryable<T> FindAll(Expression<Func<T, bool>> match, string[] includes = null);
        IQueryable<T> FindAll(Expression<Func<T, bool>> match, int? skip, int? take, string[] includes = null);
        IQueryable<T> GetOrdered(Expression<Func<T, bool>> match, int? skip, int? take, Expression<Func<T, object>> orderBy, string orderByDirection = OrderBy.Ascending, string[] includes = null);
        T Add(T entity);
        IQueryable<T> AddRange(IQueryable<T> entities);

        void Update(T entity);
        void UpdateRange(List<T> entities);
        void Delete(T entity);
        void DeleteRange(List<T> entities);

    }
}
