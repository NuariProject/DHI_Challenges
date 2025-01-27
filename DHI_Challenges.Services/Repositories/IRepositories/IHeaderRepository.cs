using DHI_Challenges.Models.Entities;

namespace DHI_Challenges.Services.Repositories.IRepositories
{
    public interface IHeaderRepository : IGenericRepository<TransactionHeader>
    {
        void Update(TransactionHeader header);
    }
}
