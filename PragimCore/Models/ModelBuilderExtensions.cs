using Microsoft.EntityFrameworkCore;

namespace PragimCore.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Name = "Mark",
                    Department = Department.HR,
                    Email = "mark@gmail.com"
                }, new Employee
                {
                    Id = 1,
                    Name = "John",
                    Department = Department.Payroll,
                    Email = "john@gmail.com"
                }, new Employee
                {
                    Id = 1,
                    Name = "Mary",
                    Department = Department.IT,
                    Email = "mary@gmail.com"
                }
            );
        }
    }
}