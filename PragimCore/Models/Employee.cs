using System.ComponentModel.DataAnnotations;

namespace PragimCore.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Display(Name = "Official Email")]
        [Required, RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid Email format")]
        public string Email { get; set; }

        [Required]
        public Department? Department { get; set; }

        public string PhotoPath { get; set; }
    }
}