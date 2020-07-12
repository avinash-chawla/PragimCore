using System.Collections.Generic;
using System.Linq;

namespace PragimCore.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            this._employeeList = new List<Employee>() {
                new Employee(){ Id = 1, Name="Avinash", Email="avinash@gmail.com", Department = Department.HR},
                new Employee(){ Id = 2, Name="Samu",Email="samu@gmail.com", Department = Department.IT},
                new Employee(){ Id = 3, Name="Vishal",Email="vishal@gmail.com", Department = Department.Payroll},
            };
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return this._employeeList.ToList();
        }

        public Employee GetEmployee(int id)
        {
            return this._employeeList.SingleOrDefault(x => x.Id == id);
        }

        public Employee Add(Employee employee)
        {
            employee.Id = this._employeeList.Max(e => e.Id) + 1;
            this._employeeList.Add(employee);
            return employee;
        }
    }
}