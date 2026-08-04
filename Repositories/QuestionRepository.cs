using InterviewPrepApp.DataContext;
using InterviewPrepApp.Models;
using Microsoft.EntityFrameworkCore;

namespace InterviewPrepApp.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly AppDBContext _context;

        public QuestionRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<QuestionsModel> AddQuestion(QuestionsModel question)
        {
            await _context.Questions.AddAsync(question);

            await _context.SaveChangesAsync();

            return question;
        }

        public async Task<QuestionsModel?> UpdateQuestion(QuestionsModel question)
        {
            var data = await _context.Questions.FindAsync(question.QuestionId);

            if (data == null)
                return null;

            data.Question = question.Question;
            data.Answer = question.Answer;
            data.Explanation = question.Explanation;
            data.TopicId = question.TopicId;
            data.UpdatedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return data;
        }

        public async Task<IEnumerable<QuestionsModel>> GetQuestions()
        {
            return await _context.Questions
                .Include(x => x.Topic)
                .Where(x => x.Topic.IsActive)
                .ToListAsync();
        }

        public async Task<QuestionsModel?> GetQuestionById(int questionId)
        {
            return await _context.Questions
                .Include(x => x.Topic)
                .FirstOrDefaultAsync(x => x.QuestionId == questionId);
        }

        public async Task<IEnumerable<QuestionsModel>> GetQuestionsByTopic(int topicId)
        {
            return await _context.Questions
                .Include(x => x.Topic)
                .Where(x => x.TopicId == topicId)
                .ToListAsync();
        }

        public async Task<bool> DeleteQuestion(int questionId)
        {
            var data = await _context.Questions.FindAsync(questionId);

            if (data == null)
                return false;

            _context.Questions.Remove(data);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}