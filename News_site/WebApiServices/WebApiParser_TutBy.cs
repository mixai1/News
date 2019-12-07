using Core.InterfaceWebApiServicesParsers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiEntity.Models;

namespace WebApiServicesParsers
{
    public class WebApiParser_TutBy : IWebApiParser_TutBy
    {
        private const string URL_TUTBY = @"";

        public Task<IEnumerable<News>> GetNewsFromUrl()
        {
            throw new NotImplementedException();
        }
    }
}
