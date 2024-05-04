using Alojamiento.Domain.Entities;
using Alojamiento.Domain.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Alojamiento.Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {
        private readonly AlojamientoDbContext _context;

        public GenericRepository(AlojamientoDbContext context)
        {
            this._context = context;
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking().ToList();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .FirstAsync(e => e.Id == id);
        }

        public async Task<T> Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await SaveAll();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await SaveAll();
            return entity;
        }

        public async Task<T> Delete(T entity)
        {
            this._context.Set<T>().Remove(entity);
            await SaveAll();
            return entity;
        }

        public async Task<bool> Exist(int id)
        {
            return await _context.Set<T>().AnyAsync(e => e.Id == id);
        }

        public async Task<bool> SaveAll()
        {
            return await this._context.SaveChangesAsync() > 0;
        }
    }
}
