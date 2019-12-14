using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiEntity.Models;

namespace Core.InterfaceWebApiNewsRepository
{
    public interface IExistNewsInDataBase
    {
        Task<IEnumerable<News>> ExceptNews();
    }
}
