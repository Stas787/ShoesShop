using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace ShoesShop.Models
{
    public class Order
    {

        [BindNever]
        public int Id { get; set; }

        [Display(Name = "Enter your name")]
        [StringLength(40)]
        [Required(ErrorMessage = "Enter your name, please")]
        public string Name { get; set; }

        [Display(Name = "Enter your surname")]
        [StringLength(50)]
        [Required(ErrorMessage = "Enter your surname, please")]        
        public string SurName { get; set; }

        [Display(Name = "Adress")]
        [StringLength(50)]
        [Required(ErrorMessage = "Enter your adress, please")]
        public string Adress { get; set; }

        [Display(Name = "Enter your phone number")]
        [StringLength(50)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Enter your phone number, please")]
        public string Phone { get; set; }

        [Display(Name = "Enter your Email")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Enter your Email, please")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)] //to hide this field from source code
        public DateTime OrderTime { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
