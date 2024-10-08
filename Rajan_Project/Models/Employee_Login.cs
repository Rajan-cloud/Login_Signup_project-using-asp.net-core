using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations;

namespace Rajan_Project.Models
{
    public class Employee_Login
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter User Name")]
        public string User_Id { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
