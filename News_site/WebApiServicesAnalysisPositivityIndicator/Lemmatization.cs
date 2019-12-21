using Core.InterfaceWebApiServicesAnalysisPositivity;
using Serilog;
using System;
using System.Threading.Tasks;
using WebApiEntity.Models;

namespace WebApiServicesAnalysisPositivity
{
    public class Lemmatization : ILemmatization
    {
        private readonly IConvertJsonAFINNToDictinary _convertJson;
        private readonly IGetFromStringToJsonResponsFromApi _getFromStringToJson;
        private readonly IDeserializeRespons _deserialize;
        public Lemmatization(
            IConvertJsonAFINNToDictinary convertJson,
            IGetFromStringToJsonResponsFromApi getFromStringToJson,
            IDeserializeRespons deserialize)
        {
            _convertJson = convertJson;
            _deserialize = deserialize;
            _getFromStringToJson = getFromStringToJson;
        }

        public async Task<double> GetIndexOfPositivity(News news)
        {
            try
            {
                string textBody = news.Body.ToString();
                int summPositivity = 0;
                double numberOfmaches = 0;
                var result = await _getFromStringToJson.GetJsonResponsToFromNews(textBody);
                if (!String.IsNullOrEmpty(result))
                {
                    var resultText = _deserialize.Deserialize(result);
                    var resultAfinnDictionary = await _convertJson.ConvertJsonToDictionary();
                    foreach (var item in resultText)
                    {
                        foreach (var i in resultAfinnDictionary)
                        {
                            if (item.Equals(i.Key))
                            {
                                summPositivity += i.Value;
                                numberOfmaches += 1;
                            }
                        }
                    }

                    numberOfmaches = numberOfmaches == 0 ? 1 : numberOfmaches;
                    double number = summPositivity / numberOfmaches;
                    const int accuracy = 4;
                    double index = Math.Round(number, accuracy);
                    Log.Information($"GetIndexOfPositivity News Positivity => completed successfully");

                    return index;
                }
                return 0;
            }
            catch (Exception ex)
            {
                Log.Error($"GetIndexOfPositivity =>{ex.Message}");
                return 0;

            }
        }
    }
}
