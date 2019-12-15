using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Onion.Application.Interfaces
{
     public interface ICommandRepository<T> where T : class {

        Task Insert (T entity);
        void Update (T entity);
        Task Save(CancellationToken cancellationToken);
        Task DeleteAsync (T entity);
    }
}