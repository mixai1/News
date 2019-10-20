using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{
    public interface IGenericNewsRepository<T> where T : class
    {
        Task AddNewsAsync(T obj);

        Task AddNewsRangeAsync(IEnumerable<T> rangeObjs);

        Task<IEnumerable<T>> GetAllNewsAsync();

        Task<T> GetNewsIdAsync(object id);

        void DeleteNewsId(object id);

        Task UpdateNewsAsunc(T obj);

        IQueryable<T> AsQueryble();
    }
}
