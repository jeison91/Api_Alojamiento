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
    public class HabitacionRepository : IHabitacionRepository
    {
        private readonly AlojamientoDbContext _dbContext;
        public HabitacionRepository(AlojamientoDbContext context)
        {
            _dbContext = context;
        }

        public async Task<HabitacionEntity> Create(HabitacionEntity entity)
        {
            await _dbContext.Habitaciones.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<HabitacionEntity> Delete(HabitacionEntity entity)
        {
            _dbContext.Set<HabitacionEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Exist(int id)
        {
            return await _dbContext.Set<HabitacionEntity>().AnyAsync(e => e.Id == id);
        }

        public List<HabitacionEntity> GetAll()
        {
            var Habitaciones = _dbContext.Habitaciones
                .Include(x => x.TipoHabitacion)
                .Include(x => x.UbicacionHabitacion)
                .ToList();
            return Habitaciones;
        }

        public async Task<HabitacionEntity> GetById(int id)
        {
            var Habitacion = await _dbContext.Habitaciones.Where(x => x.Id == id).FirstAsync();
            return Habitacion;
        }

        public async Task<HabitacionEntity> Update(HabitacionEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> ValidateHotel(int IdHabitacion, int IdHotel)
        {
            return await _dbContext.Set<HabitacionEntity>().AnyAsync(x => x.Id == IdHabitacion && x.IdHotel == IdHotel);
        }
    }
}
