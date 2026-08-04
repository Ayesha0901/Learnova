using InterviewPrepApp.Enums;
using System.ComponentModel.DataAnnotations;

namespace InterviewPrepApp.Models
{
    public class UserModel
    {
        [Key]
        public Guid UserId { get; set; }
        [Required]
        [MaxLength(100)]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; }
        [Required]
        [MaxLength(255)]
        public string PasswordHash { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; }
        public UserRole Role { get; set; } = UserRole.User;
    }
}
