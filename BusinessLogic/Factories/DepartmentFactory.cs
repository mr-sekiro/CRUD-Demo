using BusinessLogic.Data_Transfer_Object.DepartmentDtos;
using DataAccess.Models.DepartmentModel;

namespace BusinessLogic.Factories
{
    public static class DepartmentFactory
    {
        public static DepartmentDto ToDepartmentDto(this Department department)
        {
            return new DepartmentDto()
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                DateOfCreation = department.DateOfCreation
            };
        }

        public static DepartmentDetailsDto ToDepartmentDetailsDto(this Department department)
        {
            return new DepartmentDetailsDto()
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                DateOfCreation = department.DateOfCreation,
                CreatedOn = department.CreatedOn != null
                ? DateOnly.FromDateTime(department.CreatedOn.Value)
                : null,
                CreatedBy = department.CreatedBy,
                LastModifiedBy = department.LastModifiedBy,
                LastModifiedOn = department.LastModifiedOn != null
                ? DateOnly.FromDateTime(department.LastModifiedOn.Value)
                : null,
                IsDeleted = department.IsDeleted,
            };
        }

        public static Department ToEntity(this CreatedDepartmentDto createdDepartmentDto)
        {
            return new Department()
            {
                Name = createdDepartmentDto.Name,
                Code = createdDepartmentDto.Code,
                Description = createdDepartmentDto.Description,
                DateOfCreation = createdDepartmentDto.DateOfCreation,
            };
        }
    }
}
