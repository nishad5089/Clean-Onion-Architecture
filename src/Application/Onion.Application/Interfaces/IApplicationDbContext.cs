using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Onion.Domain.Entity;

namespace Onion.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Student> Students { get; set; }
        DbSet<T> Set<T> () where T : class;
        Task<int> SaveChangesAsync ();
        EntityEntry<T> Entry<T> (T entity) where T : class;
    }
}