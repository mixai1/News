using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core
{
    public interface IParser<T> where T : class
    {
        Task<IEnumerable<T>> GetNewsFromUrl();
        Task<bool> AddAsync(T obj);
        Task<bool> AddRangeAsync(IEnumerable<T> objects);
    }
}
