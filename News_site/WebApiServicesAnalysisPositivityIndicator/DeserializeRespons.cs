using Core.InterfaceWebApiServicesAnalysisPositivity;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiServicesAnalysisPositivity
{

    public class DeserializeRespons : IDeserializeRespons
    {
     
        public List<string> Deserialize(string respons)
        {
            try
            {
                if (!string.IsNullOrEmpty(respons))
                {
                    List<string> valueString = new List<string>();
                    var result = JsonConvert.DeserializeObject<List<ResponseDeserilizeModel>>(respons);

                    foreach (var item in result)
                    {
                        foreach (var i in item.Annotations.Lemma)
                        {
                            valueString.Add(i.Value);
                        }
                    }
                    var resultValues = valueString.Where<string>(x => x != "").ToList<string>();
                    Log.Information("Method Deserialize => completed successfully");
                    return resultValues;
                }

                return null;
            }
            catch (Exception ex)
            {
                Log.Error($"Method Deserialize => {ex.Message}");
                return null;
            }
        }
    }

    public class ResponseDeserilizeModel
    {
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("annotations")]
        public Annotations Annotations { get; set; }
    }
    public class Lemma
    {
        [JsonProperty("start")]
        public int Start { get; set; }
        [JsonProperty("end")]
        public int End { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
    }
    public class Annotations
    {
        [JsonProperty("lemma")]
        public List<Lemma> Lemma { get; set; }
    }
}
