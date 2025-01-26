using DHI_Challenges.Services.Infrastructures;
using DHI_Challenges.Services.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace DHI_Challanges.Services.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private DHIContexts _context;
        private IDbContextTransaction _transaction;

        public UnitOfWork(DHIContexts context)
        {
            _context = context;
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
