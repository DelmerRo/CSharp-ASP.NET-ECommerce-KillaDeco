using System;
using System.Collections.Generic;

namespace WebKillaDeco.Models
{
    public static class EmployeeInMemory
    {
        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new()
            {
                new Employee
                {
                    Dni = "12345678",
                    Cuil = "20-12345678-9",
                    Name = "John",
                    LastName = "Doe",
                    Phone = "123-456-789",
                    Email = "john@example.com",
                    Occupation = "Manager",
                    Salary = 50000,
                    DateAdded = DateTime.Now
                },
                new Employee
                {
                    Dni = "87654321",
                    Cuil = "20-87654321-9",
                    Name = "Jane",
                    LastName = "Doe",
                    Phone = "987-654-321",
                    Email = "jane@example.com",
                    Occupation = "Developer",
                    Salary = 60000,
                    DateAdded = DateTime.Now
                },
                new Employee
                {
                    Dni = "13579246",
                    Cuil = "20-13579246-8",
                    Name = "Alice",
                    LastName = "Smith",
                    Phone = "111-222-333",
                    Email = "alice@example.com",
                    Occupation = "Designer",
                    Salary = 55000,
                    DateAdded = DateTime.Now
                }
            };

            return employees;
        }
    }
}

