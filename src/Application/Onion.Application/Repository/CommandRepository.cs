using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Onion.Application.Interfaces;

namespace Onion.Application.Repository {
    public class CommandRepository<T> : ICommandRepository<T> where T : class {

        private readonly DbSet<T> _entities;
        private readonly IApplicationDbContext _context;
        public CommandRepository (IApplicationDbContext context) {
            _context = context;
            _entities = _context.Set<T> ();
        }
        public async Task DeleteAsync (T entity) {
            T existing = _entities.Find (entity);
            if (existing != null) {
                _entities.Remove (existing);

                await _context.SaveChangesAsync ();
            }
        }

     

        public async Task Insert (T entity) {
            await _entities.AddAsync (entity);
            await _context.SaveChangesAsync ();
        }

        public void Update (T entity) {
            _entities.Attach (entity);
            _context.Entry<T> (entity).State = EntityState.Modified;
        }

        public async Task Save(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync ();
        }
    }
}