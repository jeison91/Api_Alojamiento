using Alojamiento.Domain.Entities;
using Alojamiento.Domain.Exceptions;
using Alojamiento.Domain.IRepository;
using Alojamiento.Domain.IServices;
using Alojamiento.Domain.Mapper;
using Alojamiento.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alojamiento.Domain.UseCase
{
    public class HotelUseCase : IHotelServicesPort
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelUseCase(IHotelRepository hotelRepository)
        {
            this._hotelRepository = hotelRepository;
        }

        public async Task CreateHotel(HotelModel hotelModel)
        {
            var hotelEntity = hotelModel.MapToModel<HotelEntity>();
            await _hotelRepository.Create(hotelEntity);
        }

        public async Task UpdateHotel(HotelModel hotelModel)
        {
            await HotelExist(hotelModel.Id);

            var hotelEntity = hotelModel.MapToModel<HotelEntity>();
            await _hotelRepository.Update(hotelEntity);
        }

        public async Task EnableDisableHotel(int Id, bool isEnabled)
        {
            await HotelExist(Id);

            var hotelEntity = await _hotelRepository.GetById(Id);
            hotelEntity.Estado = isEnabled;
            await _hotelRepository.Update(hotelEntity);
        }

        private async Task HotelExist(int Id)
        {
            if (!await _hotelRepository.Exist(Id))
                throw new DomainValidateException("El Hotel no existe.");
        }

        public async Task<List<HotelModel>> GetAvailable(DateTime FechaEntrada, DateTime FechaSalida, int numPersonas, int IdCiudad)
        {
            var entities = await _hotelRepository.AvailableHoteles(FechaEntrada, FechaSalida, numPersonas, IdCiudad);
            var hoteles = HotelMapper.MapModelList(entities);
            return hoteles;
        }
    }
}
