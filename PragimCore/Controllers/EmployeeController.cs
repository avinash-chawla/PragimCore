using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PragimCore.Models;

namespace PragimCore.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _context;

        public EmployeeController(IEmployeeRepository context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var employees = _context.GetEmployees();
            return View(employees);
        }

        public IActionResult Details(int id)
        {
            var employee = _context.GetEmployee(id);
            return View(employee);
        }
    }
}