using Core.InterfaceWebApiServicesAnalysisPositivity;
using Core.InterfaceWebApiServicesParsers;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Web;
using WebApiEntity.Models;

namespace Services.WebApiParsersServices
{
    public class WebApiParser_Onliner : IWebApiParser_Onliner
    {
        private const string URL_ONLINER = @"https://people.onliner.by/";
        private readonly ILemmatization _lemmatization;
        public WebApiParser_Onliner(ILemmatization lemmatization)
        {
            _lemmatization = lemmatization;
        }

        public  IEnumerable<News> GetNewsFromUrl()
        {
            var web = new HtmlWeb();
            var doc =  web.Load(URL_ONLINER);

            var listnews = new List<News>();

            var rootNodes = doc.DocumentNode.SelectNodes(".//*[@class='news-tidings__clamping']");

            if (rootNodes != null)
            {
                foreach (var item in rootNodes)
                {
                    var header = HttpUtility.HtmlDecode(item.SelectSingleNode(".//*[@class='news-helpers_hide_mobile-small']").InnerText);
                    var description = HttpUtility.HtmlDecode(item.SelectSingleNode(".//*[@class='news-tidings__speech news-helpers_hide_mobile-small']").InnerText);
                    // var img = HttpUtility.HtmlDecode(item.SelectSingleNode(".//*[news-tidings__image news-helpers_hide_mobile-small]").Attributes["style"].Value);
                    description = description.Replace("  ", " ");
                    listnews.Add(new News()
                    {
                        Header = header,
                        Body = description,
                        Img = "",
                       IndexOfPositive= 0.0000,
                    CreatedDate = DateTime.Now
                    }); ;
                }
                return listnews;
            }

            return listnews;
        }
    }
}
