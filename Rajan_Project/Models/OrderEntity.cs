using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rajan_Project.Models
{
    public class OrderEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter Name")]
        [Display(Name ="Name")]
        public string Customer_Name  {get; set; }

        [Required(ErrorMessage = "Please Enter Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Mobile Number")]
        [Display(Name = "Mobile Number")]
        public long Mobile { get; set; }

        [Required(ErrorMessage = "Please Enter Amount")]
        [Display(Name = "Amount")]
        public double TotalAmmount { get; set; }      
    }

    public class PaymentData
    {
        [NotMapped]
        public string Transaction_Id { get; set; }
        [NotMapped]
        public string Order_ID { get; set; }
    }
}
