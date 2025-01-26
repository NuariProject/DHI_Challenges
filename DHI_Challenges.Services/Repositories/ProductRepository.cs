using DHI_Challenges.Models.Entities;
using DHI_Challenges.Services.Infrastructures;
using DHI_Challenges.Services.Repositories.IRepositories;

namespace DHI_Challenges.Services.Repositories
{
    public class ProductRepository : GenericRepository<MasterProduct>, IProductRepository
    {
        private DHIContexts _context;

        public ProductRepository(DHIContexts contexts) : base(contexts)
        {
            _context = contexts;
        }
        public void Update(MasterProduct product)
        {
            _context.Update(product);
        }
    }
}
