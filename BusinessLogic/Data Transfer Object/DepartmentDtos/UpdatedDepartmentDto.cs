using System.ComponentModel.DataAnnotations;
namespace BusinessLogic.Data_Transfer_Object.DepartmentDtos
{
    public class UpdatedDepartmentDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Max length should be 50 character")]
        [MinLength(5, ErrorMessage = "Min length should be 5 characters")]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public DateOnly? DateOfCreation { get; set; }
    }
}
