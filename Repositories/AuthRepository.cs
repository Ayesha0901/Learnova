using InterviewPrepApp.DataContext;
using InterviewPrepApp.Models;
using Microsoft.EntityFrameworkCore;

namespace InterviewPrepApp.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDBContext _context;

        public AuthRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<UserModel?> GetUserByEmail(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(x => x.Email == email && x.IsActive);
        }

        public async Task<UserModel> Register(UserModel user)
        {
            await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();

            return user;
        }
    }
}