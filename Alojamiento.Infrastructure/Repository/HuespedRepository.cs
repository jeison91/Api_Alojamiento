using Alojamiento.Domain.Entities;
using Alojamiento.Domain.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alojamiento.Infrastructure.Repository
{
    public class HuespedRepository : IHuespedRepository
    {
        private readonly AlojamientoDbContext _dbContext;
        public HuespedRepository(AlojamientoDbContext context)
        {
            _dbContext = context;
        }
        public async Task<HuespedEntity> Create(HuespedEntity entity)
        {
            await _dbContext.Huespedes.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<HuespedEntity> Delete(HuespedEntity entity)
        {
            _dbContext.Set<HuespedEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Exist(int id)
        {
            return await _dbContext.Set<HuespedEntity>().AnyAsync(e => e.Id == id);
        }

        public List<HuespedEntity> GetAll()
        {
            var Huespedes = _dbContext.Huespedes
                .Include(x => x.TipoDocumento)
                .Include(x => x.Genero)
                .OrderBy(x => x.Id)
                .ToList();
            return Huespedes;
        }

        public async Task<HuespedEntity> GetById(int id)
        {
            var Huesped = await _dbContext.Huespedes
                .Include(x => x.TipoDocumento)
                .Include(x => x.Genero)
                .Where(x => x.Id == id).FirstAsync();
            return Huesped;
        }

        public async Task<HuespedEntity> Update(HuespedEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<HuespedEntity> GetByDocument(string Documento)
        {
            var Huesped = await _dbContext.Huespedes.Where(x => x.Documento == Documento).FirstOrDefaultAsync();
            return Huesped;
        }
    }
}
