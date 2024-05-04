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
    public class HabitacionServices : IHabitacionServices
    {
        private readonly IHabitacionServicesPort _habitacionServicesPort;

        public HabitacionServices(IHabitacionServicesPort habitacionServicesPort)
        {
            this._habitacionServicesPort = habitacionServicesPort;
        }

        public async Task CreateHabitacion(HabitacionRequestDTO HabitacionRequest)
        {
            var HabitacionModel = HabitacionRequest.MapToModel<HabitacionModel>();
            await _habitacionServicesPort.CreateHabitacion(HabitacionModel);
        }

        public async Task UpdateHabitacion(int Id, HabitacionRequestDTO HabitacionRequest)
        {
            var HabitacionModel = HabitacionRequest.MapToModel<HabitacionModel>();
            HabitacionModel.Id = Id;

            await _habitacionServicesPort.UpdateHabitacion(HabitacionModel);
        }

        public async Task EnableDisableHabitacion(int Id, bool isEnabled)
        {
            await _habitacionServicesPort.EnableDisableHabitacion(Id, isEnabled);
        }
    }
}
