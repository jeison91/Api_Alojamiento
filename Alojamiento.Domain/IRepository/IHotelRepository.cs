using Alojamiento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alojamiento.Domain.IRepository
{
    public interface IHotelRepository : IGenericRepository<HotelEntity>
    {
        Task<List<HotelEntity>> AvailableHoteles(DateTime FechaEntrada, DateTime FechaSalida, int CantidadPersonas, int CiudadDestino);
        Task<List<HotelEntity>> GetListHotelesReservas(DateTime FechaInicial);
    }
}
