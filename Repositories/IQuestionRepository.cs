using InterviewPrepApp.Models;

namespace InterviewPrepApp.Repositories
{
    public interface IQuestionRepository
    {
        Task<QuestionsModel> AddQuestion(QuestionsModel question);

        Task<QuestionsModel?> UpdateQuestion(QuestionsModel question);

        Task<IEnumerable<QuestionsModel>> GetQuestions();

        Task<QuestionsModel?> GetQuestionById(int questionId);

        Task<IEnumerable<QuestionsModel>> GetQuestionsByTopic(int topicId);

        Task<bool> DeleteQuestion(int questionId);
    }
}