using Core;
using Core.InterfaceWebApiServicesParsers;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiEntity.Models;

namespace WebApiServicesParsers
{
    public class WebApiGeneralParser : IWebApiGeneralParser
    {
        IWebApiParser_TutBy _parser_TutBy;
        IWebApiParser_Onliner _parser_Onliner;
        IWebApiParser_S13 _parser_S13;
        public WebApiGeneralParser(IWebApiParser_Onliner parser_Onliner, IWebApiParser_S13 parser_S13, IWebApiParser_TutBy parser_TutBy)
        {
            _parser_TutBy = parser_TutBy;
            _parser_Onliner = parser_Onliner;
            _parser_S13 = parser_S13;

        }

        public List<News> AllNewsListWithoutRepetition => AllNewsList;

        private List<News> AllNewsList { get; }

        public async Task AddNewsGeneralListNews()
        {
            try
            {
                var resultNews_S13 = await _parser_S13.GetNewsFromUrl();

                if (resultNews_S13 != null)
                {
                    foreach (var news in resultNews_S13)
                    {
                        if (await DoesThisNewsAlreadyExistOnTheList(news) != null)
                        {
                            AllNewsList.Add(news);
                        }
                    }
                }
                var result_onliner = await _parser_Onliner.GetNewsFromUrl();
                if (result_onliner != null)
                {
                    foreach (var news in result_onliner)
                    {
                        if (await DoesThisNewsAlreadyExistOnTheList(news) != null)
                        {
                            AllNewsList.Add(news);
                        }
                    }
                }

                var result_TutBy = await _parser_TutBy.GetNewsFromUrl();
                if (result_TutBy != null)
                {
                    foreach (var news in result_TutBy)
                    {
                        if (await DoesThisNewsAlreadyExistOnTheList(news) != null)
                        {
                            AllNewsList.Add(news);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Log.Error($"AddNewsGeneralListNews => {ex.Message}");
            }

        }

        private async Task<News> DoesThisNewsAlreadyExistOnTheList(News news)
        {
            if (AllNewsList.Count(n => n.Equals(news)) == 0 && news != null)
            {
                return news;
            }
            return null;
        }
    }
}
