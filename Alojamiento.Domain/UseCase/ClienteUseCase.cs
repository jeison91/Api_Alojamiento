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
    public class ClienteUseCase : IClienteServicesPort
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteUseCase(IClienteRepository clienteRepository)
        {
            this._clienteRepository = clienteRepository;
        }

        public async Task<ClienteModel> GetById(int Id)
        {
            var entity = await _clienteRepository.GetById(Id);
            var clienteModel = entity.MapToModel<ClienteModel>();
            return clienteModel;
        }
    }
}
