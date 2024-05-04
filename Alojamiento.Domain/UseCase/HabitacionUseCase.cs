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
    public class HabitacionUseCase : IHabitacionServicesPort
    {
        private readonly IHabitacionRepository _habitacionRepository;

        public HabitacionUseCase(IHabitacionRepository habitacionRepository)
        {
            this._habitacionRepository = habitacionRepository;
        }

        public async Task CreateHabitacion(HabitacionModel HabitacionModel)
        {
            var HabitacionEntity = HabitacionModel.MapToModel<HabitacionEntity>();
            await _habitacionRepository.Create(HabitacionEntity);
        }

        public async Task UpdateHabitacion(HabitacionModel HabitacionModel)
        {
            await HabitacionExist(HabitacionModel.Id);

            if (!await _habitacionRepository.ValidateHotel(HabitacionModel.Id, HabitacionModel.IdHotel))
                throw new DomainValidateException("La Habitación no pertenece al hotel.");

            var HabitacionEntity = HabitacionModel.MapToModel<HabitacionEntity>();
            await _habitacionRepository.Update(HabitacionEntity);
        }

        public async Task EnableDisableHabitacion(int Id, bool isEnabled)
        {
            await HabitacionExist(Id);

            var HabitacionEntity = await _habitacionRepository.GetById(Id);
            HabitacionEntity.Estado = isEnabled;
            await _habitacionRepository.Update(HabitacionEntity);
        }

        private async Task HabitacionExist(int Id)
        {
            if (!await _habitacionRepository.Exist(Id))
                throw new DomainValidateException("El Habitación no existe.");
        }
    }
}
