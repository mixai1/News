using Core.InterfaceWebApiServicesAnalysisPositivity;
using Core.InterfaceWebApiServicesParsers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiEntity.Models;

namespace Services.WebApiParsersServices
{
    public class WebApiGeneralParser : IWebApiGeneralParser
    {
        // private readonly IWebApiParser_TutBy _parser_TutBy;
        private readonly IWebApiParser_Onliner _parser_Onliner;
        private readonly IWebApiParser_S13 _parser_S13;
        private readonly ILemmatization _lemmatization;
        
        public WebApiGeneralParser(IWebApiParser_Onliner parser_Onliner, 
            IWebApiParser_S13 parser_S13, IWebApiParser_TutBy parser_TutBy,
            ILemmatization lemmatization)
        {
            // _parser_TutBy = parser_TutBy;
            _parser_Onliner = parser_Onliner;
            _parser_S13 = parser_S13;
            _lemmatization = lemmatization;
        }


        public async Task<IEnumerable<News>> AddNewsGeneralListNews()
        {
            List<News> AllNewsList = new List<News>();
            Parallel.Invoke(
                () => {
                    var result_onliner =  _parser_Onliner.GetNewsFromUrl();

                    if (result_onliner != null)
                    {
                        foreach (var news in result_onliner)
                        {
                            if (AllNewsList.Count(n => n.Header.Equals(news.Header)) == 0 && news != null)
                            {
                                AllNewsList.Add(news);
                            }
                        }
                    }
                },
                //()=>AddNewsTytBy(),
                () => {
                    var resultNews_S13 = _parser_S13.GetNewsFromUrl();

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
                });

            return AllNewsList;
        }
            
    }
}
