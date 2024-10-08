using System.ComponentModel.DataAnnotations;

namespace Rajan_Project.Models
{
    public class Employee_Reg
    {
        [Key]
        public int Emp_id { get; set; }
        [Required(ErrorMessage ="Please Enetr Your Name")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Please Enetr Your Age ")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Please Enetr Your Gender")]
        public string? Gender { get; set; }
        [Required(ErrorMessage = "Please Enetr Your Email")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Please Enetr Your Password")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Please Enetr Your Dpt")]
        public string? Department { get; set; }
        [Required(ErrorMessage = "Please Enetr Your City")]
        public string? City { get; set; }
    }

    public class LoginClass
    {
        [Required(ErrorMessage = "Please Enetr Your Name")]
        public string? Name { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please Enetr Your Password")]
        public string? Password { get; set; }
    }
}
