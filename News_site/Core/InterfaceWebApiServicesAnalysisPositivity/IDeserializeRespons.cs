using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.InterfaceWebApiServicesAnalysisPositivity
{
    public interface IDeserializeRespons
    {
       List<string> Deserialize(string respons);
    }
}
