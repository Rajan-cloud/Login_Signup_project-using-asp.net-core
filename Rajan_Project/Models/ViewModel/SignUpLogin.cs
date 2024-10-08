using System.ComponentModel.DataAnnotations;

namespace Rajan_Project.Models.ViewModel
{
    public class SignUpLogin
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter Name")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Please Enter Email")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage ="Please Enter valid Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please Enter Mobile")]
        [Display(Name ="Mobile Number")]
        [RegularExpression(@"^\+?[1-9]\d{1,10}$", ErrorMessage ="Mobile No Not Valid")]
        public long? Mobile { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage ="Enter password between 1to9& special char")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter Confirm Password")]
        [Display(Name ="Confirm Password")]
        [Compare("Password",ErrorMessage ="Confirm Password can't Match")]
        public  string ConfirmPassword { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }
    }
}
