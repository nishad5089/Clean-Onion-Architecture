using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Onion.Application.Interfaces;

namespace Onion.Application.Repository {
    public class QueryRepository<T> : IQueryRepository<T> where T : class {

        private readonly DbSet<T> _entities;
        private readonly IApplicationDbContext _context;
        public QueryRepository (IApplicationDbContext context) {
            _context = context;
            _entities = _context.Set<T> ();
        }
        public async Task<T> Get (Guid id) {
            return await _entities.FindAsync (id);
        }

        public async Task<IEnumerable<T>> GetAll () {
            return await _entities.ToListAsync<T> ();
        }

        public IEnumerable<T> GetAllByPredicate (Expression<Func<T, bool>> expression) {
            throw new System.NotImplementedException ();
        }
    }
}