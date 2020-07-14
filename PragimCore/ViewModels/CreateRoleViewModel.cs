using System.ComponentModel.DataAnnotations;

namespace PragimCore.Models
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name = "Role")]
        public string RoleName { get; set; }
    }
}