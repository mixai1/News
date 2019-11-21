using Core.InterfaceParserServes;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebApiEntity;
using WebApiEntity.Models;

namespace WebApiCQRS.Commands.NewsCommands
{
    public class AddListNewsHandler : IRequestHandler<AddListNews, bool>
    {
        private readonly IParser_S13 _parser_S13;
        private readonly WebApiDbContext _dbContext;
        public AddListNewsHandler(IParser_S13 parser_S13, WebApiDbContext dbContext)
        {
            _parser_S13 = parser_S13;
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(AddListNews request, CancellationToken cancellationToken)
        {
            var newsParserList = await _parser_S13.GetNewsFromUrl();

            if(newsParserList == null)
            {
                return false;
            }

            try
            {
              // await AddRangeAsync(newsParserList);
            }
            catch (System.Exception)
            {

                throw;
            }
           
            

            return true;
        }
        private async Task<bool> AddRangeAsync(List<News> news)
        {
            foreach (var item in news)
            {
                //if (.News != null)
                //{
                //    await .News.AddNewsAsync(item);
                //}
            }

            return true;
        }
    }
}
