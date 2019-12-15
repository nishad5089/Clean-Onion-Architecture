using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Onion.Application.Interfaces
{
    public interface IQueryRepository<T> where T : class
    {
        Task<T> Get (Guid id);
        Task<IEnumerable<T>> GetAll ();
        IEnumerable<T> GetAllByPredicate (Expression<Func<T, bool>> expression);
    }
}