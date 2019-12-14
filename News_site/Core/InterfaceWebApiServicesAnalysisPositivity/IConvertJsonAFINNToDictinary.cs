using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.InterfaceWebApiServicesAnalysisPositivity
{
    public interface IConvertJsonAFINNToDictinary
    {
        Task<Dictionary<string, int>> ConvertJsonToDictionary();
    }
}
