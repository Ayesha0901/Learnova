using System.ComponentModel.DataAnnotations;

namespace InterviewPrepApp.Models
{
    public class QuestionsModel
    {
        [Key]
        public int QuestionId { get; set; }
        public int TopicId { get; set; }
        [Required]
        public string Question { get; set; }
        [Required]
        public string Answer { get; set; }
        public string Explanation { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; }

        // Navigation Property
        public TopicsModel Topic { get; set; } = null!;
    }
}
