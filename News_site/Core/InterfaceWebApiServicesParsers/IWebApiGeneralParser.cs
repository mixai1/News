using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiEntity.Models;

namespace Core.InterfaceWebApiServicesParsers
{
    public interface IWebApiGeneralParser
    {
        Task<IEnumerable<News>> AddNewsGeneralListNews();
    }
}
