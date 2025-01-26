namespace DHI_Challenges.Services.Repositories.IRepositories
{
    public interface IUnitOfWork
    {
        #region Register Other Repository
        IUserRepository User { get; }
        IProductRepository Product{ get; }
        #endregion

        void Save();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
