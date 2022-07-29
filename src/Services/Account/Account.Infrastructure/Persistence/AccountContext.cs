using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Account.Domain.Common;
using Account.Domain.Entities;

namespace Account.Infrastructure.Persistence
{
    public class AccountContext : DbContext
    {
        public AccountContext(DbContextOptions<AccountContext> options) : base(options) 
        {
        }
        public DbSet<AccountActivity> AccountActivity { get; set; }
        public DbSet<Users> Users { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.Now;
                    entry.Entity.CreatedBy = "saiful";
                    break;
                    case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.Now;
                    entry.Entity.LastModifiedBy = "saiful";
                    break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
