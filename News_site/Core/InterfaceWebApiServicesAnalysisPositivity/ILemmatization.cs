using System.Threading.Tasks;
using WebApiEntity.Models;

namespace Core.InterfaceWebApiServicesAnalysisPositivity
{
    public interface ILemmatization
    {
        Task<double> GetIndexOfPositivity(News news);
    }
}
