using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{
    public interface IGenericNewsRepository<T> where T : class
    {
        Task AddAsync(T obj);

        Task AddRangeAsync(IEnumerable<T> rangeObjs);

        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetIdAsync(object id);

        Task DeleteId(object id);

        IEnumerable<T> Where(Func<T, bool> predicate);

        void Update(T obj);

        IQueryable<T> AsQueryble();
    }
}
