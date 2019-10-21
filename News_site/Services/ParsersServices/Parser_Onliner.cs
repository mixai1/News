using Data.Models;
using Services.InterfaceParserServes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.ParsersServices
{
    public class Parser_Onliner : IParser_Onliner
    {


        public Task<bool> AddAsync(News obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddRangeAsync(IEnumerable<News> objects)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<News> GetFromUrl()
        {
            throw new NotImplementedException();
        }
    }

}
