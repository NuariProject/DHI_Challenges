using DHI_Challenges.Models.Entities;

namespace DHI_Challenges.Services.Repositories.IRepositories
{
    public interface IUserRepository : IGenericRepository<MasterUser>
    {
        void Update(MasterUser user);
    }
}
