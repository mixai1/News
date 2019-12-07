using Core.InterfaceWebApiServicesParsers;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApiEntity.Models;

namespace WebApiServicesParsers
{
    public class WebApiParser_Onliner : IWebApiParser_Onliner
    {
        private const string URL_ONLINER = @"https://people.onliner.by/";

        public async Task<IEnumerable<News>> GetNewsFromUrl()
        {
            var web = new HtmlWeb();
            var doc = await web.LoadFromWebAsync(URL_ONLINER);

            var listnews = new List<News>();

            var rootNodes = doc.DocumentNode.SelectNodes(".//*[@class='news-tidings__clamping']");

            if (rootNodes != null)
            {
                foreach (var item in rootNodes.Take(3))
                {
                    var header = HttpUtility.HtmlDecode(item.SelectSingleNode(".//*[@class='news-helpers_hide_mobile-small']").InnerText);
                    var description = HttpUtility.HtmlDecode(item.SelectSingleNode(".//*[@class='news-tidings__speech news-helpers_hide_mobile-small']").InnerText);
                    // var img = HttpUtility.HtmlDecode(item.SelectSingleNode(".//*[news-tidings__image news-helpers_hide_mobile-small]").Attributes["style"].Value);
                    listnews.Add(new News()
                    {
                        Header = header,
                        Body = description,
                        Img = "",
                        CreatedDate = DateTime.Now
                    });
                }
                return listnews;
            }

            return listnews;
        }
    }
}
