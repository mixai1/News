using Data.Models;
using Data.UnitOfWork;
using HtmlAgilityPack;
using Services.InterfaceParserServes;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System;
using System.Linq;

namespace Services.ParsersServices
{
    public class Parser_S13 : IParser_S13
    {
        private readonly IUnitOfWork _unitOfWork;
        private const string URL_S13 = @"http://s13.ru/";

        public Parser_S13(IUnitOfWork unitOfWork)
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
            var doc = await web.LoadFromWebAsync(URL_S13);

            List<News> listnews = new List<News>();

            var rootNode = doc.DocumentNode.SelectNodes("//*[@class='cols news list']");
            var sortNod = rootNode.Elements("li");
            if(sortNod != null)
            {
                foreach (var item in sortNod.Take(3))
                {
                    var header = HttpUtility.HtmlDecode(item.SelectSingleNode(".//*[@class='title']").InnerText);
                    var description = HttpUtility.HtmlDecode(item.SelectSingleNode(".//p").InnerText);
                    var img = HttpUtility.HtmlDecode(item.SelectSingleNode(".//img").Attributes["src"].Value);
                    listnews.Add(new News() 
                    {
                        Heading = header,
                        Content = description, 
                        Img = img,
                        DateTime = DateTime.Now
                    });
                }
                return listnews;
            }
            

            return listnews;
        }

        
        
    }
}
