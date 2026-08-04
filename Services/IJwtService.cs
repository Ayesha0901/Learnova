using InterviewPrepApp.Models;

namespace InterviewPrepApp.Services
{
    public interface IJwtService
    {
        string GenerateToken(UserModel user);
    }
}