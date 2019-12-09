using Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebApiServicesAnalysisPositivity
{
    public class SendTextToApiLemmatization
    {
        private readonly IWebApiGeneralParser _generalParser;
        public SendTextToApiLemmatization(IWebApiGeneralParser generalParser)
        {
            _generalParser = generalParser;
        }

        public async Task SendMessege()
        {
           using( var client = new HttpClient())
           {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "http://api.ispras.ru/texterra/v1/nlp?targetType=lemma&apikey=");
                request.Content = new StringContent("[{\"text\":\" 123 \"}]", Encoding.UTF8, "application/json");//CONTENT-TYPE header

                var x =  client.SendAsync(request).Result;
           }
            
        }

        public async Task<Dictionary<string, int>> ConvertJsonToDictionary()
        {

            Dictionary<string, int> AfinnJsonDictionary = new Dictionary<string, int>();
            const string path = @"C:\Users\пк\Documents\GitHub\News\News\News\News_site\WebApiServicesAnalysisPositivityIndicator\AFINN - ru.json";

            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.UTF8))
            {
                var text = await sr.ReadToEndAsync();
                AfinnJsonDictionary = JsonConvert.DeserializeObject<Dictionary<string, int>>(text);

            }
            return AfinnJsonDictionary;
        }
    }
}
