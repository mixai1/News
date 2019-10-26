using Data.Models;
using System.Collections.Generic;

namespace News_site.NewsViewModels
{
    public class IndexNewsModel
    {
        public IEnumerable<News> News { get; set; }
    }
}
