using System.Collections.Generic;
using WebApiEntity.Models;

namespace Core.InterfaceWebApiServicesParsers
{
    public interface IWebApiParser_Onliner 
    {
        IEnumerable<News> GetNewsFromUrl();
    }
}
