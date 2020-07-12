using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PragimCore.Models;
using PragimCore.ViewModels;

namespace PragimCore.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public EmployeeController(IEmployeeRepository context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            string uniqueFileName = null;
            if (ModelState.IsValid)
            {
                if (model.Photo != null)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");

                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                };

                Employee newEmployee = new Employee
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,
                    PhotoPath = uniqueFileName
                };

                _context.Add(newEmployee);
                return RedirectToAction(nameof(Details), new { id = newEmployee.Id });
            }
            return View();
        }
    }
}