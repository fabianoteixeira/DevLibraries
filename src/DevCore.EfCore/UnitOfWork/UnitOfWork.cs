using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DevCore.EfCore.UnitOfWork
{
    public sealed class UnitOfWork<TDbContext> : IUnitOfWork where TDbContext : DbContext
    {
        private readonly TDbContext _context;

        public UnitOfWork(TDbContext context)
        {
            _context = context;
        }

        public Task<int> Commit()
        {  
           return _context.SaveChangesAsync();
           
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void BeginTransaction()
        {
            if (!TransactionOpened())
                _context.Database.BeginTransaction();
        }

        public void  CommitTransaction()
        {
            _context.Database.CommitTransaction();
        }

        public void RollBack()
        {
            try
            {
                _context.Database.RollbackTransaction();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool TransactionOpened()
        {
            return _context.Database.CurrentTransaction != null;
        }

        public void DetachAllEntities()
        {
            var changedEntriesCopy = _context.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted)
                .ToList();

            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }
    }
}
