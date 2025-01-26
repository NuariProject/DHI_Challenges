namespace DHI_Challenges.Services.Repositories.IRepositories
{
    public interface IUnitOfWork
    {
        void Save();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
