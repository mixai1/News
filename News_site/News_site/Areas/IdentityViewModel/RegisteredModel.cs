using System.ComponentModel.DataAnnotations;

namespace News_site.Areas.IdentityViewModel
{
    public class RegisteredModels
    {

        public string UserName { get; set; }


        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Pasword is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "ComfirmPasword != Pasword")]
        public string PasswordConfirm { get; set; }





    }
}
