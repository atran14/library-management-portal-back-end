using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back_end.DatabaseContexts;
using back_end.Models;
using Microsoft.EntityFrameworkCore;

namespace back_end.Services.DALs
{
    public abstract class AsyncDbContextRepository<TEntity> : IAsyncGenericRepository<TEntity>, IDisposable
        where TEntity : class, IEntity
    {
        private readonly LibraryContext _context;
        public AsyncDbContextRepository(LibraryContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await GetAll().FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task Create(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null) {
                throw new ArgumentException($"Object with ID {id} does not exist in the database");
            }
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, TEntity entity)
        {
            if (entity.Id != id)
            {
                throw new ArgumentException($"Old object with ID {id} does not match the new object of ID {entity.Id}");
            }

            _context.Set<TEntity>().Update(entity);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                var objectExists = await _context.Set<TEntity>().AnyAsync(t => t.Id == id);
                if (!objectExists)
                {
                    throw new ArgumentException($"Old object with ID {id} does not exist in the database due to concurrency issues", e);
                }
                else
                {
                    throw;
                }
            }

        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}