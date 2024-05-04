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
    public class ReservaHuespedRepository : IReservaHuespedRepository
    {
        private readonly AlojamientoDbContext _dbContext;
        public ReservaHuespedRepository(AlojamientoDbContext context)
        {
            _dbContext = context;
        }
        public async Task<ReservaHuespedEntity> Create(ReservaHuespedEntity entity)
        {
            await _dbContext.ReservaHuespedes.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<ReservaHuespedEntity> Delete(ReservaHuespedEntity entity)
        {
            _dbContext.Set<ReservaHuespedEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Exist(int id)
        {
            return await _dbContext.Set<ReservaHuespedEntity>().AnyAsync(e => e.Id == id);
        }

        public List<ReservaHuespedEntity> GetAll()
        {
            var ReservaHuespedes = _dbContext.ReservaHuespedes
                .OrderBy(x => x.Id)
                .ToList();
            return ReservaHuespedes;
        }

        public async Task<ReservaHuespedEntity> GetById(int id)
        {
            var ReservaHuesped = await _dbContext.ReservaHuespedes.Where(x => x.Id == id).FirstAsync();
            return ReservaHuesped;
        }

        public async Task<ReservaHuespedEntity> Update(ReservaHuespedEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
