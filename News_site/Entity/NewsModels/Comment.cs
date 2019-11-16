using System;

namespace Entity.NewsModels
{
    public class Comment : DataBaseEntity
    {
        public DateTime DateTime { get; set; }
        public string Content { get; set; }


        public News News { get; set; }

    }
}
