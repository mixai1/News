using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestNewsSite.VeiwModels
{
    public class NewViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string RedirectUrl { get; set; }

        
        [Display(Name = "News Headilne")]
        [Required(ErrorMessage = "Heading is required")]
        public string Heading { get; set; }

    }
}
