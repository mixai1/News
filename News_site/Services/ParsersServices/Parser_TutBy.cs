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
    public class Parser_TutBy : IParser_TutBy
    {
        private readonly IUnitOfWork _unitOfWork;
        private const string URL_TUTBY = @"";

        public Parser_TutBy(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<bool> AddAsync(News news)
        {
            if (_unitOfWork.News != null)
            {
                await _unitOfWork.News.AddAsync(news);

                return true;
            }
            await _unitOfWork.News.AddAsync(news);

            return true;
        }


        public async Task<bool> AddRangeAsync(IEnumerable<News> news)
        {
            foreach (var item in news)
            {
                if (_unitOfWork.News != null)
                {
                    await _unitOfWork.News.AddAsync(item);
                }
            }

            return true;
        }

        public async Task<IEnumerable<News>> GetNewsFromUrl()
        {
            var web = new HtmlWeb();
            var doc = await web.LoadFromWebAsync(URL_TUTBY);

            List<News> listnews = new List<News>();

            var rootNode = doc.DocumentNode.SelectNodes("//*[@class='cols news list']");
            var sortNod = rootNode.Elements("li");
            if (sortNod != null)
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
