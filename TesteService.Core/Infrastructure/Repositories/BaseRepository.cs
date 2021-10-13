using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteService.Core.Entities;
using TesteService.Core.Infrastructure.Context;
using TesteService.Core.Interfaces;

namespace TesteService.Core.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : TBaseEntity
    {
        protected readonly TesteDb _context;

        public BaseRepository(TesteDb context)
        {
            _context = context;
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public virtual Task<List<T>> GetAllAsync(string search)
        {
            return _context.Set<T>().Where(x => x.ID.ToString().Contains(search)).AsNoTracking().ToListAsync();
        }

        public virtual Task<T> GetByIdAsync(Guid ID)
        {
            return _context.Set<T>().Where(x => x.ID == ID).AsNoTracking().FirstOrDefaultAsync();
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            entity.RegistrationDate = DateTime.Now;
            entity.ChangeDate = DateTime.Now;
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public virtual async Task<T> UpdateAsync(T entity)
        {
            entity.ChangeDate = DateTime.Now;
            _context.Set<T>().Update(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<bool> DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
