using InterviewPrepApp.DTOs.Topics;
using InterviewPrepApp.Models;
using InterviewPrepApp.Repositories;

namespace InterviewPrepApp.Services
{
    public class TopicService : ITopicService
    {
        private readonly ITopicRepository _topicRepo;

        public TopicService(ITopicRepository topicRepo)
        {
            _topicRepo = topicRepo;
        }

        public async Task<TopicDTO> AddTopic(TopicDTO topic)
        {
            if (string.IsNullOrWhiteSpace(topic.TopicName))
                throw new ArgumentException("Topic Name is required.");

            var model = new TopicsModel
            {
                TopicName = topic.TopicName,
                CategoryId = topic.CategoryId,
                Description = topic.Description,
                OfficialWebsite = topic.OfficialWebsite,
                IsActive = topic.IsActive
            };

            var result = await _topicRepo.AddTopic(model);

            return new TopicDTO
            {
                TopicId = result.TopicId,
                TopicName = result.TopicName,
                CategoryId = result.CategoryId,
                Description = result.Description,
                OfficialWebsite = result.OfficialWebsite,
                IsActive = result.IsActive,
                CreatedDate = result.CreatedDate,
                UpdatedDate = result.UpdatedDate
            };
        }

        public async Task<TopicDTO?> UpdateTopic(TopicDTO topic)
        {
            var model = new TopicsModel
            {
                TopicId = topic.TopicId,
                TopicName = topic.TopicName,
                CategoryId = topic.CategoryId,
                Description = topic.Description,
                OfficialWebsite = topic.OfficialWebsite,
                IsActive = topic.IsActive
            };

            var result = await _topicRepo.UpdateTopic(model);

            if (result == null)
                return null;

            return new TopicDTO
            {
                TopicId = result.TopicId,
                TopicName = result.TopicName,
                CategoryId = result.CategoryId,
                Description = result.Description,
                OfficialWebsite = result.OfficialWebsite,
                IsActive = result.IsActive,
                CreatedDate = result.CreatedDate,
                UpdatedDate = result.UpdatedDate
            };
        }

        public async Task<IEnumerable<TopicDTO>> GetTopics()
        {
            var result = await _topicRepo.GetTopics();

            return result.Select(x => new TopicDTO
            {
                TopicId = x.TopicId,
                TopicName = x.TopicName,
                CategoryId = x.CategoryId,
                Description = x.Description,
                OfficialWebsite = x.OfficialWebsite,
                IsActive = x.IsActive,
                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate
            });
        }

        public async Task<TopicDTO?> GetTopicById(int topicId)
        {
            var result = await _topicRepo.GetTopicById(topicId);

            if (result == null)
                return null;

            return new TopicDTO
            {
                TopicId = result.TopicId,
                TopicName = result.TopicName,
                CategoryId = result.CategoryId,
                Description = result.Description,
                OfficialWebsite = result.OfficialWebsite,
                IsActive = result.IsActive,
                CreatedDate = result.CreatedDate,
                UpdatedDate = result.UpdatedDate
            };
        }

        public async Task<bool> DeleteTopic(int topicId)
        {
            return await _topicRepo.DeleteTopic(topicId);
        }
    }
}