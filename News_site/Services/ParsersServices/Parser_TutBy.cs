using Data.Models;
using Services.InterfaceParserServes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.ParsersServices
{
    class Parser_TutBy : IParser_TutBy
    {
        public bool Add(News obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddAsync(News obj)
        {
            throw new NotImplementedException();
        }

        public bool AddRange(IEnumerable<News> objects)
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
