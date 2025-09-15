using Azure;
using BusinessLogic.Data_Transfer_Object.EmployeeDtos;
using BusinessLogic.Factories;
using BusinessLogic.Services.AttachmentService;
using BusinessLogic.Services.Interfaces;
using DataAccess.Models.DepartmentModel;
using DataAccess.Models.EmployeeModel;
using DataAccess.Models.Shared.Enums;
using DataAccess.Repositories.Interfaces;
using System.Net;
using static System.Net.Mime.MediaTypeNames;


namespace BusinessLogic.Services.Classes
{
    public class EmployeeService(IUnitOfWork unitOfWork, IAttachmentService attachmentService) : IEmployeeService
    {
        public IEnumerable<EmployeeDto> GetAllEmployees(string? searchName)
        {
            IEnumerable<Employee> employees;
            if (string.IsNullOrWhiteSpace(searchName))
                employees = unitOfWork.EmployeeRepo.GetAll();
            else
                employees = unitOfWork.EmployeeRepo.GetAll(E => E.Name.ToLower().Contains(searchName.ToLower()));

            var employeesDto = employees.Select(e => e.ToEmployeeDto()).ToList();
            return employeesDto;
        }

        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var employee = unitOfWork.EmployeeRepo.GetById(id);
            return employee is null ? null : employee.ToEmployeeDetailsDto();

        }
        public int AddEmployee(CreatedEmployeeDto createdEmployeeDto)
        {
            var employee = createdEmployeeDto.ToEntity();
            if (createdEmployeeDto.Image is not null)
            {
                employee.ImageName = attachmentService.Upload(createdEmployeeDto.Image, "Images");
            }
            unitOfWork.EmployeeRepo.Add(employee);
            return unitOfWork.SaveChanges();
        }
        public int UpdateEmployee(UpdatedEmployeeDto updatedEmployeeDto)
        {
            var employee = unitOfWork.EmployeeRepo.GetById(updatedEmployeeDto.Id);
            if (employee is null) return 0;

            string? imageName = employee.ImageName;

            if (updatedEmployeeDto.Image is not null)
            {
                imageName = attachmentService.Upload(updatedEmployeeDto.Image, "Images");
                if (employee.ImageName is not null)
                {
                    attachmentService.Delete(Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot\\Files", "Images", employee.ImageName));
                }
            }

            employee.Name = updatedEmployeeDto.Name;
            employee.Salary = updatedEmployeeDto.Salary;
            employee.Address = updatedEmployeeDto.Address;
            employee.Age = updatedEmployeeDto.Age;
            employee.Email = updatedEmployeeDto.Email;
            employee.PhoneNumber = updatedEmployeeDto.PhoneNumber;
            employee.HiringDate = updatedEmployeeDto.HiringDate;
            employee.ImageName = updatedEmployeeDto.ImageName;
            employee.IsActive = updatedEmployeeDto.IsActive;
            employee.Gender = updatedEmployeeDto.Gender;
            employee.EmployeeType = updatedEmployeeDto.EmployeeType;
            employee.DepartmentId = updatedEmployeeDto.DepartmentId;
            employee.ImageName = imageName;

            unitOfWork.EmployeeRepo.Update(employee);
            return unitOfWork.SaveChanges();
        }

        public bool DeleteEmployee(int id)
        {
            //Soft delete
            var employee = unitOfWork.EmployeeRepo.GetById(id);
            if (employee is null) return false;
            else
            {
                employee.IsDeleted = true;
                unitOfWork.EmployeeRepo.Update(employee);
                return unitOfWork.SaveChanges() > 0 ? true : false;
            }
        }
    }
}
