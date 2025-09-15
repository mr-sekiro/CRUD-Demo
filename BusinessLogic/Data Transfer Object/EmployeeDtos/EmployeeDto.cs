﻿using System.ComponentModel.DataAnnotations;
namespace BusinessLogic.Data_Transfer_Object.EmployeeDtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? Age { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string Gender { get; set; }
        [Display(Name = "Employee Type")]
        public string EmployeeType { get; set; }
        public string? Department { get; set; }
    }
}
