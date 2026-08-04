using System.ComponentModel.DataAnnotations;

namespace InterviewPrepApp.Models
{
    public class TopicsModel
    {
        [Key]
        public int TopicId { get; set; }
        [Required]
        public string TopicName { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        [Url]
        public string OfficialWebsite { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; }

        //NavigationProperty
        public CategoryModel Category { get; set; } = null!;
    }
}
