using System;
using System.Collections.Generic;

namespace WebApiEntity.Models
{
    public class News
    {
        public Guid Id { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public string Img { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<Comments> Comments { get; set; }
    }
}
