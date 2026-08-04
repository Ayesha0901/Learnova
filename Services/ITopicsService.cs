using InterviewPrepApp.DTOs.Topics;

namespace InterviewPrepApp.Services
{
    public interface ITopicService
    {
        Task<TopicDTO> AddTopic(TopicDTO topic);

        Task<TopicDTO?> UpdateTopic(TopicDTO topic);

        Task<IEnumerable<TopicDTO>> GetTopics();

        Task<TopicDTO?> GetTopicById(int topicId);

        Task<bool> DeleteTopic(int topicId);
    }
}