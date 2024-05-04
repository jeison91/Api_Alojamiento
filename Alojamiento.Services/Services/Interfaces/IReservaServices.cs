using Alojamiento.Domain.Model;
using Alojamiento.Services.DTO.Request;
using Alojamiento.Services.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alojamiento.Services.Services.Interfaces
{
    public interface IReservaServices
    {
        Task CreateReserva(ReservarRequestDTO reservarRequest);
        Task<List<ReservaResponseDTO>> GetListReserva(DateTime FechaInicial);
    }
}
