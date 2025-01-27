using DHI_Challenges.Models.Entities;
using DHI_Challenges.Services.Infrastructures;
using DHI_Challenges.Services.Repositories.IRepositories;

namespace DHI_Challenges.Services.Repositories
{
    public class DetailRepository : GenericRepository<TransactionDetail>, IDetailRepository
    {
        private DHIContexts _context;
        public DetailRepository(DHIContexts contexts) : base(contexts)
        {
            _context = contexts;
        }
        public void Update(TransactionDetail detail)
        {
            _context.Update(detail);
        }
    }
}
