using System;
using System.ComponentModel.DataAnnotations;

namespace TestNewsSite.VeiwModels
{
    public class NewViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ButtonName { get; set; }
        public string RedirectUrl { get; set; }

        
        [Display(Name = "News Headilne")]
        [Required(ErrorMessage = "Heading is required")]
        public string Heading { get; set; }

    }
}
