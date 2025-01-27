using DHI_Challenges.Models.Entities;

namespace DHI_Challenges.Services.Repositories.IRepositories
{
    public interface IDetailRepository : IGenericRepository<TransactionDetail>
    {
        void Update(TransactionDetail detail);
    }
}
