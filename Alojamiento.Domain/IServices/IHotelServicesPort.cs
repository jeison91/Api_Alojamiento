using Alojamiento.Domain.Entities;
using Alojamiento.Domain.IRepository;
using Alojamiento.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alojamiento.Domain.IServices
{
    public interface IHotelServicesPort
    {
        Task CreateHotel(HotelModel hotelModel);
        Task UpdateHotel(HotelModel hotelModel);
        Task EnableDisableHotel(int Id, bool isEnabled);
        Task<List<HotelModel>> GetAvailable(DateTime FechaEntrada, DateTime FechaSalida, int numPersonas, int IdCiudad);
    }
}
