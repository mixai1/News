using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestNewsSite.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Content { get; set; }





        public User users { get; set; }
        public int UserId { get; set; }

        public New news { get; set; }
        public int NewId { get; set; }

        public Admin admins { get; set; }
        public int AdminId { get; set; }
    }
}
