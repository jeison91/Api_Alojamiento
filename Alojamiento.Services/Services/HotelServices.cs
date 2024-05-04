using Alojamiento.Domain.IRepository;
using Alojamiento.Domain.IServices;
using Alojamiento.Domain.Mapper;
using Alojamiento.Domain.Model;
using Alojamiento.Services.DTO.Request;
using Alojamiento.Services.DTO.Response;
using Alojamiento.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alojamiento.Services.Services
{
    public class HotelServices : IHotelServices
    {
        private readonly IHotelServicesPort _hotelServicesPort;

        public HotelServices(IHotelServicesPort hotelServicesPort)
        {
            this._hotelServicesPort = hotelServicesPort;
        }

        public async Task CreateHotel(HotelRequestDTO hotelRequest)
        {
            var hotelModel = hotelRequest.MapToModel<HotelModel>();
            await _hotelServicesPort.CreateHotel(hotelModel);
        }

        public async Task UpdateHotel(int Id, HotelRequestDTO hotelRequest)
        {
            var hotelModel = hotelRequest.MapToModel<HotelModel>();
            hotelModel.Id = Id;

            await _hotelServicesPort.UpdateHotel(hotelModel);
        }

        public async Task EnableDisableHotel(int Id, bool isEnabled)
        {
            await _hotelServicesPort.EnableDisableHotel(Id, isEnabled);
        }

        public async Task<List<HotelResponseDTO>> GetAvaliableHotel(DateTime FechaEntrada, DateTime FechaSalida, int NumeroPersonas, int IdCiudad)
        {
            var habitacionModels = await _hotelServicesPort.GetAvailable(FechaEntrada, FechaSalida, NumeroPersonas, IdCiudad);
            var responseDTOs = habitacionModels.MapToModel<List<HotelResponseDTO>>(); //MapDTOList(vehiculoModel);
            return responseDTOs;
        }
    }
}
