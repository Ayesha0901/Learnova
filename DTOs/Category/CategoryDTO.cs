using System.ComponentModel.DataAnnotations;

namespace InterviewPrepApp.DTOs.Category
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Category Name is required.")]
      
        public string CategoryName { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; }
    }
}
