using InterviewPrepApp.DTOs.Question;

namespace InterviewPrepApp.Services
{
    public interface IQuestionService
    {
        Task<QuestionDTO> AddQuestion(QuestionDTO question);

        Task<QuestionDTO?> UpdateQuestion(QuestionDTO question);

        Task<IEnumerable<QuestionDTO>> GetQuestions();

        Task<QuestionDTO?> GetQuestionById(int id);

        Task<IEnumerable<QuestionDTO>> GetQuestionsByTopic(int topicId);

        Task<bool> DeleteQuestion(int id);
    }
}