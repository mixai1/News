using System;

namespace WebApiEntity.Models
{
    public class Comments
    {
        public Guid CommentId { get; set; }
        public Guid NewsId { get; set; }
        public string Body { get; set; }
        public string Author { get; set; }
        public DateTime CreateDate { get; set; } 
    }
}
