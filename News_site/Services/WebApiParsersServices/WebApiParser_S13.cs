using Core.InterfaceWebApiServicesAnalysisPositivity;
using Core.InterfaceWebApiServicesParsers;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Web;
using WebApiEntity.Models;

namespace Services.WebApiParsersServices
{
    public class WebApiParser_S13 : IWebApiParser_S13
    {
        private const string URL_S13 = @"http://s13.ru/";
        private readonly ILemmatization _lemmatization;
        public WebApiParser_S13(ILemmatization lemmatization)
        {
            _lemmatization = lemmatization;
        }
        public IEnumerable<News> GetNewsFromUrl()
        {
            var web = new HtmlWeb();
            var doc = web.Load(URL_S13);

            List<News> listnews = new List<News>();

            var rootNode = doc.DocumentNode.SelectNodes("//*[@class='cols news list']");
            var sortNod = rootNode.Elements("li");
            if (sortNod != null)
            {
                foreach (var item in sortNod)
                {
                    var header = HttpUtility.HtmlDecode(item.SelectSingleNode(".//*[@class='title']").InnerText);
                    var description = HttpUtility.HtmlDecode(item.SelectSingleNode(".//p").InnerText);
                    description = description.Replace("  ", " ");
                    var img = "https://unsplash.it/250/250?random&i";
                   // var img = HttpUtility.HtmlDecode(item.SelectSingleNode(".//img").Attributes["src"].Value);
                    listnews.Add(new News()
                    {
                        Header = header,
                        Body = description,
                        Img = img,
                        IndexOfPositive = null,
                        CreatedDate = DateTime.Now
                    }); ;
                }
                return listnews;
            }

            return listnews;
        }

    }
}
