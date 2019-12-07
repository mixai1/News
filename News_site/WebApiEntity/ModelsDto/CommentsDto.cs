using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WebApiEntity.Models;

namespace WebApiEntity.ModelsDto
{
   public class CommentsDto
    {
        [Required (ErrorMessage = "The comment cannot be empty ")]
        [StringLength(100000,MinimumLength =1, ErrorMessage = "The comment must contain min one character")]
        public string Body { get; set; }
        public string Author { get; set; }
        public DateTime CreateDate { get; set; }

        public News News { get; set; }
    }
}
