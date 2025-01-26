using DHI_Challenges.Models.Entities;
using DHI_Challenges.Services.Infrastructures;
using DHI_Challenges.Services.Repositories.IRepositories;

namespace DHI_Challenges.Services.Repositories
{
    public class UserRepository : GenericRepository<MasterUser>, IUserRepository
    {
        private DHIContexts _context;
        public UserRepository(DHIContexts contexts) : base(contexts)
        {
            _context = contexts;
        }
        public void Update(MasterUser user)
        {
            _context.Update(user);
        }
    }
}
