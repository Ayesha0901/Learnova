using InterviewPrepApp.DTOs.Question;
using InterviewPrepApp.Models;
using InterviewPrepApp.Repositories;

namespace InterviewPrepApp.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepo;

        public QuestionService(IQuestionRepository questionRepo)
        {
            _questionRepo = questionRepo;
        }

        public async Task<QuestionDTO> AddQuestion(QuestionDTO question)
        {
            if (string.IsNullOrWhiteSpace(question.Question))
                throw new ArgumentException("Question is required.");

            if (string.IsNullOrWhiteSpace(question.Answer))
                throw new ArgumentException("Answer is required.");

            var data = new QuestionsModel
            {
                TopicId = question.TopicId,
                Question = question.Question,
                Answer = question.Answer,
                Explanation = question.Explanation
            };

            var result = await _questionRepo.AddQuestion(data);

            return new QuestionDTO
            {
                QuestionId = result.QuestionId,
                TopicId = result.TopicId,
                Question = result.Question,
                Answer = result.Answer,
                Explanation = result.Explanation,
                CreatedDate = result.CreatedDate,
                UpdatedDate = result.UpdatedDate
            };
        }

        public async Task<QuestionDTO?> UpdateQuestion(QuestionDTO question)
        {
            if (string.IsNullOrWhiteSpace(question.Question))
                throw new ArgumentException("Question is required.");

            if (string.IsNullOrWhiteSpace(question.Answer))
                throw new ArgumentException("Answer is required.");

            var data = new QuestionsModel
            {
                QuestionId = question.QuestionId,
                TopicId = question.TopicId,
                Question = question.Question,
                Answer = question.Answer,
                Explanation = question.Explanation
            };

            var result = await _questionRepo.UpdateQuestion(data);

            if (result == null)
                return null;

            return new QuestionDTO
            {
                QuestionId = result.QuestionId,
                TopicId = result.TopicId,
                Question = result.Question,
                Answer = result.Answer,
                Explanation = result.Explanation,
                CreatedDate = result.CreatedDate,
                UpdatedDate = result.UpdatedDate
            };
        }

        public async Task<IEnumerable<QuestionDTO>> GetQuestions()
        {
            var result = await _questionRepo.GetQuestions();

            return result.Select(q => new QuestionDTO
            {
                QuestionId = q.QuestionId,
                TopicId = q.TopicId,
                Question = q.Question,
                Answer = q.Answer,
                Explanation = q.Explanation,
                CreatedDate = q.CreatedDate,
                UpdatedDate = q.UpdatedDate
            });
        }

        public async Task<QuestionDTO?> GetQuestionById(int questionId)
        {
            var result = await _questionRepo.GetQuestionById(questionId);

            if (result == null)
                return null;

            return new QuestionDTO
            {
                QuestionId = result.QuestionId,
                TopicId = result.TopicId,
                Question = result.Question,
                Answer = result.Answer,
                Explanation = result.Explanation,
                CreatedDate = result.CreatedDate,
                UpdatedDate = result.UpdatedDate
            };
        }

        public async Task<IEnumerable<QuestionDTO>> GetQuestionsByTopic(int topicId)
        {
            var result = await _questionRepo.GetQuestionsByTopic(topicId);

            return result.Select(q => new QuestionDTO
            {
                QuestionId = q.QuestionId,
                TopicId = q.TopicId,
                Question = q.Question,
                Answer = q.Answer,
                Explanation = q.Explanation,
                CreatedDate = q.CreatedDate,
                UpdatedDate = q.UpdatedDate
            });
        }

        public async Task<bool> DeleteQuestion(int questionId)
        {
            return await _questionRepo.DeleteQuestion(questionId);
        }
    }
}