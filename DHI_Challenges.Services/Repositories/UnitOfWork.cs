using DHI_Challenges.Services.Infrastructures;
using DHI_Challenges.Services.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace DHI_Challenges.Services.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository User { get; private set; }
        public IProductRepository Product { get; private set; }

        private DHIContexts _context;
        private IDbContextTransaction _transaction;

        public UnitOfWork(DHIContexts context)
        {
            _context = context;
            User = new UserRepository(_context);
            Product = new ProductRepository(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _transaction.Commit();
        }

        public void RollbackTransaction()
        {
            _transaction.Rollback();
        }
    }
}
