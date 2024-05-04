using Alojamiento.Services.DTO.Request;
using Alojamiento.Services.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alojamiento.Services.Services.Interfaces
{
    public interface IHotelServices
    {
        Task CreateHotel(HotelRequestDTO hotelRequest);
        Task UpdateHotel(int Id, HotelRequestDTO hotelRequest);
        Task EnableDisableHotel(int Id, bool isEnabled);
        Task<List<HotelResponseDTO>> GetAvaliableHotel(DateTime FechaEntrada, DateTime FechaSalida, int NumeroPersonas, int IdCiudad);
    }
}
