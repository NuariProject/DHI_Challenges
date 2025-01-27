using DHI_Challenges.Models.Entities;
using DHI_Challenges.Services.Infrastructures;
using DHI_Challenges.Services.Repositories.IRepositories;

namespace DHI_Challenges.Services.Repositories
{
    public class HeaderRepository : GenericRepository<TransactionHeader>, IHeaderRepository
    {
        private DHIContexts _context;
        public HeaderRepository(DHIContexts contexts) : base(contexts)
        {
            _context = contexts;
        }
        public void Update(TransactionHeader header)
        {
            _context.Update(header);
        }
    }
}
