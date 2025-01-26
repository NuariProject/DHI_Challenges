using DHI_Challenges.Models.Entities;

namespace DHI_Challenges.Services.Repositories.IRepositories
{
    public interface IProductRepository : IGenericRepository<MasterProduct>
    {
        void Update(MasterProduct product);
    }
}
