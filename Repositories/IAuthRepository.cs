using InterviewPrepApp.Models;

namespace InterviewPrepApp.Repositories
{
    public interface IAuthRepository
    {
        Task<UserModel?> GetUserByEmail(string email);

        Task<UserModel> Register(UserModel user);
    }
}