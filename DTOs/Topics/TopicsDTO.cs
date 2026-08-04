using System.ComponentModel.DataAnnotations;

namespace InterviewPrepApp.DTOs.Topics
{
    public class TopicDTO
    {
        public int TopicId { get; set; }

        [Required]
        [MaxLength(100)]
        public string TopicName { get; set; } = string.Empty;

        [Required]
        public int CategoryId { get; set; }

        public string? Description { get; set; }

        [Url]
        public string? OfficialWebsite { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
