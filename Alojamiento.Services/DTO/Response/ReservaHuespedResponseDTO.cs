using Alojamiento.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alojamiento.Services.DTO.Response
{
    public class ReservaHuespedResponseDTO
    {
        public int Id { get; set; }
        public int IdReserva { get; set; }
        public int IdHuesped { get; set; }

        //public ReservasEntity Reserva { get; set; }
        public HuespedModel Huesped { get; set; }
    }
}
