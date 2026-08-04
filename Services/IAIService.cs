using InterviewPrepApp.DTOs.AI;

namespace InterviewPrepApp.Services
{
    public interface IAIService
    {
        Task<AIResponseDTO> AskAsync(AIRequestDTO request);
    }
}