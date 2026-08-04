using System.ComponentModel.DataAnnotations;

namespace InterviewPrepApp.DTOs.Question
{
    public class QuestionDTO
    {
        public int QuestionId { get; set; }

        [Required]
        public int TopicId { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Question { get; set; } = string.Empty;

        [Required]
        public string Answer { get; set; } = string.Empty;

        public string? Explanation { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}