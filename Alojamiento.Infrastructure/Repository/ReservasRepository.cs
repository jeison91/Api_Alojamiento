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
    public class ReservasRepository : IReservasRepository
    {
        private readonly AlojamientoDbContext _dbContext;
        public ReservasRepository(AlojamientoDbContext context)
        {
            _dbContext = context;
        }

        public async Task<ReservasEntity> CreateReserva(ReservasEntity entity)
        {
            _dbContext.Set<ReservasEntity>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<ReservasEntity>> GetReserva(DateTime FechaInicial)
        {
            var reservasTotales = await _dbContext.Reservas
                .Include(r => r.Habitacion)
                .Include(r => r.ReservaHuesped)
                .Include(r => r.Cliente).ThenInclude(c=> c.TipoDocumento)
                .Include(r => r.Cliente).ThenInclude(c => c.Genero)
                .Where(r => FechaInicial >= r.FechaEntrada)
                .ToListAsync();
            return reservasTotales;
        }
    }
}
