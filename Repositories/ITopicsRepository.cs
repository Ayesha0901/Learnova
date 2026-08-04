using InterviewPrepApp.Models;

namespace InterviewPrepApp.Repositories
{
    public interface ITopicRepository
    {
        Task<TopicsModel> AddTopic(TopicsModel topic);

        Task<TopicsModel?> UpdateTopic(TopicsModel topic);

        Task<IEnumerable<TopicsModel>> GetTopics();

        Task<TopicsModel?> GetTopicById(int topicId);

        Task<bool> DeleteTopic(int topicId);
    }
}