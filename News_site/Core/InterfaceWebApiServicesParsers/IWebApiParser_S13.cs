using System.Collections.Generic;
using WebApiEntity.Models;

namespace Core.InterfaceWebApiServicesParsers
{
    public interface IWebApiParser_S13 
    {
        IEnumerable<News> GetNewsFromUrl();
    }
}
