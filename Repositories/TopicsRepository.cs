using InterviewPrepApp.DataContext;
using InterviewPrepApp.Models;
using Microsoft.EntityFrameworkCore;

namespace InterviewPrepApp.Repositories
{
    public class TopicRepository : ITopicRepository
    {
        private readonly AppDBContext _context;

        public TopicRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<TopicsModel> AddTopic(TopicsModel topic)
        {
            await _context.Topics.AddAsync(topic);

            await _context.SaveChangesAsync();

            return topic;
        }

        public async Task<TopicsModel?> UpdateTopic(TopicsModel topic)
        {
            var data = await _context.Topics.FindAsync(topic.TopicId);

            if (data == null)
                return null;

            data.TopicName = topic.TopicName;
            data.CategoryId = topic.CategoryId;
            data.Description = topic.Description;
            data.OfficialWebsite = topic.OfficialWebsite;
            data.IsActive = topic.IsActive;
            data.UpdatedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return data;
        }

        public async Task<IEnumerable<TopicsModel>> GetTopics()
        {
            return await _context.Topics
                .Where(x => x.IsActive)
                .Include(x => x.Category)
                .ToListAsync();
        }

        public async Task<TopicsModel?> GetTopicById(int topicId)
        {
            return await _context.Topics
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.TopicId == topicId && x.IsActive);
        }

        public async Task<bool> DeleteTopic(int topicId)
        {
            var data = await _context.Topics.FindAsync(topicId);

            if (data == null)
                return false;

            data.IsActive = false;
            data.UpdatedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}