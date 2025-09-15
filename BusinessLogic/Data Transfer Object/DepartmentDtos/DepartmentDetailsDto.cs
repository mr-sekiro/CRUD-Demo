using System.ComponentModel;

namespace BusinessLogic.Data_Transfer_Object.DepartmentDtos
{
    public class DepartmentDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        [DisplayName("Date Of Creation")]
        public DateOnly? DateOfCreation { get; set; }
        [DisplayName("Created On")]
        public DateOnly? CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public int LastModifiedBy { get; set; }
        [DisplayName("Last Modified")]
        public DateOnly? LastModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
