namespace DHI_Challenges.Services.Repositories.IRepositories
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }
        void Save();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
