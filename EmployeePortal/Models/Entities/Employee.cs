﻿namespace EmployeePortal.Models.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }

        public required String Name { get; set; }
        public required String Email { get; set; }
        public String? Position { get; set; }
        public String? Department { get; set; }
        public String? Phone { get; set; }
        public decimal Salary { get; set; }
    }
}
