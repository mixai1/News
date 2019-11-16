using Entity.NewsModels;
using HtmlAgilityPack;
using Core.InterfaceParserServes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Core;

namespace Services.ParsersServices
{
    public class Parser_Onliner : IParser_Onliner
    {


        private readonly IUnitOfWork _unitOfWork;
        private const string URL_ONLINER = @"https://people.onliner.by/";

        public Parser_Onliner(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<bool> AddAsync(News news)
        {
            if (_unitOfWork.News != null)
            {
                await _unitOfWork.News.AddNewsAsync(news);

                return true;
            }
            await _unitOfWork.News.AddNewsAsync(news);

            return true;
        }


        public async Task<bool> AddRangeAsync(IEnumerable<News> news)
        {
            foreach (var item in news)
            {
                if (_unitOfWork.News != null)
                {
                    await _unitOfWork.News.AddNewsAsync(item);
                }
            }

            return true;
        }
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
                        Heading = header,
                        Content = description,
                        Img = "",  
                        DateTime = DateTime.Now
                    });
                }
                return listnews;
            }


            return listnews;
        }
    }

}
