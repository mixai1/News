using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiEntity.Models;

namespace Core
{
    public interface IExistNewsInDataBase
    {
        Task<IEnumerable<News>> ExceptNews();
    }
}
