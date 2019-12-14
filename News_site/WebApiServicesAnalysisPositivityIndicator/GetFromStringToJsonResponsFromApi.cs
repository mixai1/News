using Core.InterfaceWebApiServicesAnalysisPositivity;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebApiEntity.Models;

namespace WebApiServicesAnalysisPositivity
{
    public class GetFromStringToJsonResponsFromApi : IGetFromStringToJsonResponsFromApi
    {
        public async Task<string> GetJsonResponsToFromNews(string newsText)
        {
            try
            {
                if (newsText.Length > 1500 && !newsText.Equals(null))
                {
                    string resultString = "";
                    var listDividerString = Divider(newsText, 1500);
                    foreach (var item in listDividerString)
                    {
                        List<string> blocString = new List<string>();

                        blocString.Add(await SendMessegeToApi(item));

                        resultString = String.Join(" ", blocString);

                    }
                    Log.Information("GetTextFromNews text>1500 =>completed successfully");
                    return resultString;
                }
                else
                {
                    Log.Information("GetTextFromNews text<1500 => completed successfully");
                    return await SendMessegeToApi(newsText);
                }

            }
            catch (Exception ex)
            {
                Log.Error($" GetTextFromNews =>{ex.Message}");
                return null;
            }
        }

        private async Task<string> SendMessegeToApi(string requestText)
        {
            try
            {
                if (requestText !=null)
                {
                    string responseResult = null;
                    using (var client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "http://api.ispras.ru/texterra/v1/nlp?targetType=lemma&apikey=758447434e9fef75525bfd699759fa0bcce15b2c");
                        request.Content = new StringContent("[{\"text\":\"" + requestText + "\"}]", Encoding.UTF8, "application/json");

                        var response = client.SendAsync(request).Result;
                        responseResult = await response.Content.ReadAsStringAsync();
                    }
                    Log.Information("SendMessegeToApi => completed successfully");
                    return responseResult;
                }
                Log.Information("SendMessegeToApi => requestText = null");
                return null;
            }
            catch (Exception ex)
            {
                Log.Error($"SendMessegeToApi => {ex.Message}");
                return null;
            }
        }
        private List<string> Divider(string str, int blockLength)
        {
            List<string> Blocks = new List<string>(str.Length / blockLength + 1);
            for (int i = 0; i < str.Length; i += blockLength)
            {
                Blocks.Add(str.Substring(i, str.Length - i > blockLength ? blockLength : str.Length - i));
            }
            return Blocks;
        }
    }
}
