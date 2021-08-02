using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IList<T>> GetAllAsync();
        
        Task<IList<T>> GetPagedReponseAsync(int pageNumber, int pageSize,
                                                  Expression<Func<T, bool>> filter,
                                                  Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                  string includeProperties = "");
        Task<IList<T>> GetAsync(Expression<Func<T, bool>> filter = null,
                                      Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                      string includeProperties = "");
        Task<T> FirstAsync(Expression<Func<T, bool>> filter, string includeProperties = "");
        Task<T> GetByIdAsync(object id);
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(List<T> entities);
        void UpdateAsync(T entity);
        void Delete(T entity);
        void DeleteAllAsync(IList<T> entities);
    }
}
