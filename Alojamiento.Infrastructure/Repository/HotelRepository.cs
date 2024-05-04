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
    public class HotelRepository : IHotelRepository
    {
        private readonly AlojamientoDbContext _dbContext;
        public HotelRepository(AlojamientoDbContext context)
        {
            _dbContext = context;
        }
        public async Task<HotelEntity> Create(HotelEntity entity)
        {
            await _dbContext.Hoteles.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<HotelEntity> Delete(HotelEntity entity)
        {
            _dbContext.Set<HotelEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Exist(int id)
        {
            return await _dbContext.Set<HotelEntity>().AnyAsync(e => e.Id == id);
        }

        public List<HotelEntity> GetAll()
        {
            var Hoteles = _dbContext.Hoteles
                .Include(x => x.Ciudad)
                .Include(x => x.Habitaciones)
                .OrderBy(x => x.Nombre)
                .ToList();
            return Hoteles;
        }

        public async Task<HotelEntity> GetById(int id)
        {
            var Hotel = await _dbContext.Hoteles.Where(x => x.Id == id).FirstAsync();
            return Hotel;
        }

        public async Task<HotelEntity> Update(HotelEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<HotelEntity>> AvailableHoteles(DateTime FechaEntrada, DateTime FechaSalida, int CantidadPersonas, int CiudadDestino)
        {
            var habitacionesDisponibles = await _dbContext.Hoteles
                .Include(x => x.Habitaciones
                    .Where(v => v.Estado == true && !_dbContext.Reservas
                    .Any(x => x.IdHabitacion == v.Id &&
                            (FechaEntrada >= x.FechaEntrada && FechaEntrada <= x.FechaSalida) ||
                            (FechaSalida >= x.FechaEntrada && FechaSalida <= x.FechaSalida) ||
                            (FechaEntrada <= x.FechaEntrada && FechaSalida >= x.FechaSalida)) &&
                            v.Hotel.IdCiudad == CiudadDestino &&
                            v.NumeroPersonas >= CantidadPersonas))
                .Where(x => x.Estado == true)
                .ToListAsync();
            habitacionesDisponibles = habitacionesDisponibles.Where(x => x.Habitaciones.Count > 0).ToList();

            return habitacionesDisponibles;
        }

        public async Task<List<HotelEntity>> GetListHotelesReservas(DateTime FechaInicial)
        {
            var habitacionesDisponibles = await _dbContext.Hoteles
                .Include(x => x.Habitaciones).ThenInclude(h => h.Reservas.Where(r => FechaInicial >= r.FechaEntrada)).ThenInclude(r => r.ReservaHuesped)
                .ToListAsync();
            habitacionesDisponibles = habitacionesDisponibles.Where(x => x.Habitaciones.Any(h => h.Reservas.Count > 0)).ToList();
            return habitacionesDisponibles;
        }
    }
}
