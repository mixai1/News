using System.Threading.Tasks;
using WebApiEntity.Models;

namespace Core.InterfaceWebApiServicesAnalysisPositivity
{
    public interface IGetFromStringToJsonResponsFromApi
    {
        Task<string> GetJsonResponsToFromNews(string news);
    }
}
