using System.ComponentModel.DataAnnotations;

namespace News_site.Areas.IdentityViewModel
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Pasword is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
        public string Url { get; set; }
    }
}
