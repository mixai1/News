using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core
{
    public interface IParser<T> where T : class
    {
        IEnumerable<T> GetFromUrl();
        Task<bool> AddAsync(T obj);
        Task<bool> AddRangeAsync(IEnumerable<T> objects);
    }
}
