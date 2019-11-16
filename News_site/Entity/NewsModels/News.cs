using System;

namespace Entity.NewsModels
{
    public class News : DataBaseEntity
    {
        public string Heading { get; set; }
        public DateTime DateTime { get; set; }
        public string Source { get; set; }
        public string Content { get; set; }
        public string Img { get; set; }
        public decimal Positive { get; set; }
    }
}
