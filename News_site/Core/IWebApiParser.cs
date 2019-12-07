using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core
{
    public interface IWebApiParser<T> where T : class
    {
        Task<IEnumerable<T>> GetNewsFromUrl();
    }
}
