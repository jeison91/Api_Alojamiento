using Alojamiento.Domain.Exceptions;
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
    public class ReservaServices : IReservaServices
    {
        private readonly IReservasServicesPort _reservaServicesPort;
        private readonly IEnviarCorreoServices _enviarCorreoServices;
        private readonly IClienteServicesPort _clienteServicesPort;

        public ReservaServices(IReservasServicesPort reservaServicesPort, IEnviarCorreoServices enviarCorreoServices,
            IClienteServicesPort clienteServicesPort)
        {
            this._reservaServicesPort = reservaServicesPort;
            this._enviarCorreoServices = enviarCorreoServices;
            this._clienteServicesPort = clienteServicesPort;
        }

        public async Task CreateReserva(ReservarRequestDTO reservarRequest)
        {
            if (reservarRequest.Huespedes.Count <= 0)
                throw new DomainValidateException("Se requieren los datos de los huespedes para realizar la reserva.");

            var HabitacionModel = reservarRequest.MapToModel<ReservaModel>();
            await _reservaServicesPort.CreateReserva(HabitacionModel);

            var clienteModel = await _clienteServicesPort.GetById(reservarRequest.IdCliente);

            //TODO: Notificar por correo
            await _enviarCorreoServices.SendEmail(clienteModel.Email);
        }

        public async Task<List<ReservaResponseDTO>> GetListReserva(DateTime FechaInicial)
        {
            var reservaModels = await _reservaServicesPort.GetListReserva(FechaInicial);
            var reservaResponses = reservaModels.MapToModel<List<ReservaResponseDTO>>();
            return reservaResponses;
        }
    }
}
