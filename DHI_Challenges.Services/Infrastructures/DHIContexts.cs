using DHI_Challenges.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DHI_Challenges.Services.Infrastructures
{
    public class DHIContexts : DbContext
    {
        public DHIContexts(DbContextOptions<DHIContexts> options) : base(options)
        {
        }
        public DbSet<MasterUser> User { get; set; }
        public DbSet<MasterProduct> Products { get; set; }
        public DbSet<TransactionHeader> Headers { get; set; }
        public DbSet<TransactionDetail> Details { get; set; }
    }
}
