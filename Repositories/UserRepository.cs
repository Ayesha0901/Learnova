using InterviewPrepApp.DataContext;

namespace InterviewPrepApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDBContext _context;
        public UserRepository(AppDBContext context)
        {
            _context = context;
        }
    }
}
