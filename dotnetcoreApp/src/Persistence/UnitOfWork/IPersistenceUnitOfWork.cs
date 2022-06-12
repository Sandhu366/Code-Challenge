using System;
using System.Threading.Tasks;

namespace Persistence.UnitOfWork
{
    public interface IPersistenceUnitOfWork : IDisposable
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}

