using Data.Models;
using Data.UnitOfWork;
using HtmlAgilityPack;
using Services.InterfaceParserServes;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace Services.ParsersServices
{
    public class Parser_S13 : IParser_S13
    {
        private readonly IUnitOfWork _unitOfWork;
        private const string URL_S13 = @"http://s13.ru/rss";

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

        public IEnumerable<News> GetFromUrl()
        {
            var feedReader = XmlReader.Create(URL_S13);
            SyndicationFeed feed = SyndicationFeed.Load(feedReader);

            List<News> news = new List<News>();

            if (feed != null)
            {
                foreach (var article in feed.Items)
                {
                    var text = GetTextOfNews(article.Links.FirstOrDefault().Uri.ToString());
                    if (!string.IsNullOrEmpty(text))
                    {
                        news.Add(new News()
                        {
                            Heading = article.Title.Text,
                            Source = article.Links.FirstOrDefault().Uri.ToString(),
                            DateTime = article.PublishDate.UtcDateTime,
                            Positive = 0,
                            Content = text
                        });
                    }
                }
            }

            return news;
        }

        public string GetTextOfNews(string url)
        {
            var web = new HtmlWeb();
            var doc = web.Load(url);

            var node = doc.DocumentNode.SelectNodes("//html/body/div/div/div/div/ul/li/div/div");

            if (node != null)
            {
                var text = node.Skip(1).Take(1).FirstOrDefault().InnerText;
                var mas = new string[] { "&ndash; ", "&ndash;", "&mdash; ", "&mdash;", "&nbsp; ", "&nbsp; ", "&nbsp;", "&laquo; ", "&laquo;", "&raquo; ", "&raquo;", "&quot;" };

                foreach (var item in mas)
                {
                    text = text.Replace(item, "");
                }

                Regex.Replace(text, "<.*?>", string.Empty);

                return text;
            }

            return "";
        }
    }
}
