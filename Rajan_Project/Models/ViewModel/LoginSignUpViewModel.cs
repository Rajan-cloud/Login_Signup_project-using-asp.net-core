using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Rajan_Project.Models.ViewModel
{
    public class LoginSignUpViewModel
    {
        
        [Display(Name = "User Name")]
        [Required]
        public string? Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Display(Name="Remember Me")]
        public bool IsRemember { get; set; }
    }
}
