using DataAccess.Models.DepartmentModel;
using System.ComponentModel;
namespace BusinessLogic.Data_Transfer_Object.DepartmentDtos
{
    public class DepartmentDto
    {
        public DepartmentDto(){}
        public DepartmentDto(Department department)
        {
            Id = department.Id;
            Name = department.Name;
            Code = department.Code;
            Description = department.Description;
            DateOfCreation = department.DateOfCreation;
        }
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        [DisplayName("Date Of Creation")]
        public DateOnly? DateOfCreation { get; set; }
    }
}
