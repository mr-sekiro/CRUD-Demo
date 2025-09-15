using BusinessLogic.Data_Transfer_Object.EmployeeDtos;

namespace BusinessLogic.Services.Interfaces
{
    public interface IEmployeeService
    {
        int AddEmployee(CreatedEmployeeDto createdEmployeeDto);
        bool DeleteEmployee(int id);
        IEnumerable<EmployeeDto> GetAllEmployees(string? searchName);
        EmployeeDetailsDto? GetEmployeeById(int id);
        int UpdateEmployee(UpdatedEmployeeDto updatedEmployeeDto);
    }
}
