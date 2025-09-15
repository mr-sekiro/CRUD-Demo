using BusinessLogic.Data_Transfer_Object.EmployeeDtos;
using DataAccess.Models.EmployeeModel;

namespace BusinessLogic.Factories
{
    static public class EmployeeFactory
    {
        public static EmployeeDto ToEmployeeDto(this Employee employee)
        {
            return new EmployeeDto()
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Salary = employee.Salary,
                Email = employee.Email,
                EmployeeType = employee.EmployeeType.ToString(),
                Gender = employee.Gender.ToString(),
                IsActive = employee.IsActive,
                Department = employee.Department?.Name,
            };
        }

        public static EmployeeDetailsDto ToEmployeeDetailsDto(this Employee employee)
        {
            return new EmployeeDetailsDto()
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Salary = employee.Salary,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                Address = employee.Address,
                EmployeeType = employee.EmployeeType.ToString(),
                Gender = employee.Gender.ToString(),
                IsActive = employee.IsActive,
                Department = employee.Department?.Name,
                DepartmentId = employee.DepartmentId,
                HiringDate = employee.HiringDate,
                ImageName = employee.ImageName,
                CreatedBy = employee.CreatedBy,
                CreatedOn = employee.CreatedOn,
                LastModifiedBy = employee.LastModifiedBy,
                LastModifiedOn = employee.LastModifiedOn
            };
        }

        public static Employee ToEntity(this CreatedEmployeeDto createdEmployeeDto)
        {
            return new Employee()
            {
                Name = createdEmployeeDto.Name,
                Age = createdEmployeeDto.Age,
                Salary = createdEmployeeDto.Salary,
                Email = createdEmployeeDto.Email,
                PhoneNumber = createdEmployeeDto.PhoneNumber,
                Address = createdEmployeeDto.Address,
                EmployeeType = createdEmployeeDto.EmployeeType,
                Gender = createdEmployeeDto.Gender,
                IsActive = createdEmployeeDto.IsActive,
                DepartmentId = createdEmployeeDto.DepartmentId,
                HiringDate = createdEmployeeDto.HiringDate,
            };
        }
    }
}
