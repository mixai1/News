using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiEntity.Models;

namespace Core
{
    public interface IWebApiGeneralParser
    {
        List<News> AllNewsListWithoutRepetition { get; }
        Task AddNewsGeneralListNews();
    }
}
