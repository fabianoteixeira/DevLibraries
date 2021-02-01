using System.Threading.Tasks;

namespace DevCore.EfCore.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<int> Commit();
        void BeginTransaction();
        void CommitTransaction();
        void RollBack();
        bool TransactionOpened();
        void DetachAllEntities();
    }
}
