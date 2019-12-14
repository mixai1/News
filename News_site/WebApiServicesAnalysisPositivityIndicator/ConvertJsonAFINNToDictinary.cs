using Core.InterfaceWebApiServicesAnalysisPositivity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace WebApiServicesAnalysisPositivity
{
    public class ConvertJsonAFINNToDictinary : IConvertJsonAFINNToDictinary
    {
        public async Task<Dictionary<string, int>> ConvertJsonToDictionary()
        {
            Dictionary<string, int> AfinnJsonDictionary = new Dictionary<string, int>();
            const string path = @"C:\Users\пк\Desktop\JsonObj.json";

            using (StreamReader sr = new StreamReader(path, UTF8Encoding.UTF8,true))
            {
                var text = await sr.ReadToEndAsync();
                AfinnJsonDictionary = JsonConvert.DeserializeObject<Dictionary<string, int>>(text);

            }
            return AfinnJsonDictionary;
        }
    }
}
