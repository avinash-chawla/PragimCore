using Microsoft.AspNetCore.Http;
using PragimCore.Models;

namespace PragimCore.ViewModels
{
    public class EmployeeCreateViewModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public Department? Department { get; set; }

        public IFormFile Photo { get; set; }
    }
}