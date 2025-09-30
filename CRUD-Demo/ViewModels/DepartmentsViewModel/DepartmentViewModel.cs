using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRUD_Demo.ViewModels.DepartmentsViewModel
{
    public class DepartmentViewModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Max length should be 50 character")]
        [MinLength(5, ErrorMessage = "Min length should be 5 characters")]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        [DisplayName("Date Of Creation")]
        public DateOnly? DateOfCreation { get; set; }
    }
}
