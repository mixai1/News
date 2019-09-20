using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestNewsSite.Models
{
    public class UserCategory
    {
        [Key]
        public int Id { get; set; }
        public User user { get; set; }
        public int UserId { get; set; }


        public Admin admin { get; set; }
        public int AdminId { get; set; }
    }
}
