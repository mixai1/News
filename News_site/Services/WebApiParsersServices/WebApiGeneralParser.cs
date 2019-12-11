using Core;
using Core.InterfaceWebApiServicesParsers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiEntity.Models;

namespace Services.WebApiParsersServices
{
    public class WebApiGeneralParser : IWebApiGeneralParser
    {
        private readonly IWebApiParser_TutBy _parser_TutBy;
        private readonly IWebApiParser_Onliner _parser_Onliner;
        private readonly IWebApiParser_S13 _parser_S13;
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
            Parallel.Invoke(
                ()=>AddNewsOnliner(),
                //()=>AddNewsTytBy(),
                ()=>AddNewsS13());  
        }

        private  async Task AddNewsOnliner()
        {
            var result_onliner = await _parser_Onliner.GetNewsFromUrl();

            if (result_onliner != null)
            {
                foreach (var news in result_onliner)
                {
                    if (AllNewsList.Count(n => n.Header.Equals(news.Header)) == 0 && news!=null)
                    {
                        AllNewsList.Add(news);
                    }
                }
            }
        }

        private async Task AddNewsS13()
        {
            var resultNews_S13 = await _parser_S13.GetNewsFromUrl();

            if (resultNews_S13 != null)
            {
                foreach (var news in resultNews_S13)
                {
                    if (AllNewsList.Count(n => n.Header.Equals(news.Header)) == 0 && news != null)
                    {
                        AllNewsList.Add(news);
                    }
                }
            }

        }

        private async Task AddNewsTytBy()
        {
            var result_TutBy = await _parser_TutBy.GetNewsFromUrl();
            if (result_TutBy != null)
            {
                foreach (var news in result_TutBy)
                {
                    if (AllNewsList.Count(n => n.Header.Equals(news.Header)) == 0 && news != null)
                    {
                        AllNewsList.Add(news);
                    }
                }
            }
        }
    }
}
