using Data.NewsRepository;
using System;

namespace Data.Models
{
    public class Comment : DataBaseEntity
    {
        public DateTime DateTime { get; set; }
        public string Content { get; set; }




        public News news { get; set; }

    }
}
