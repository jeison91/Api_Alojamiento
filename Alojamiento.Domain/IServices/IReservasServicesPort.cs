using Alojamiento.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alojamiento.Domain.IServices
{
    public interface IReservasServicesPort
    {
        Task<ReservaModel> CreateReserva(ReservaModel reservaModel);
        Task<List<ReservaModel>> GetListReserva(DateTime FechaInicial);
    }
}
