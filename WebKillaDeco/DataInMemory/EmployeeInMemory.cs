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
                    Cuil = "20123456789",
                    Name = "John",
                    LastName = "Doe",
                    Phone = "123-456-789",
                    Email = "employee1@killa.com.ar",
                    Occupation = "Manager",
                    Salary = 50000,
                    DateAdded = DateTime.Now
                },
                new Employee
                {
                    Dni = "87654321",
                    Cuil = "20876543219",
                    Name = "Jane",
                    LastName = "Doe",
                    Phone = "987-654-321",
                    Email = "employee2@killa.com.ar",
                    Occupation = "Developer",
                    Salary = 60000,
                    DateAdded = DateTime.Now
                },
                new Employee
                {
                    Dni = "13579246",
                    Cuil = "20135792468",
                    Name = "Alice",
                    LastName = "Smith",
                    Phone = "111-222-333",
                    Email = "employee3@killa.com.ar",
                    Occupation = "Designer",
                    Salary = 55000,
                    DateAdded = DateTime.Now
                }
            };

            return employees;
        }
    }
}

