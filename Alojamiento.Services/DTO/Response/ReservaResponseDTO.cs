using Alojamiento.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alojamiento.Services.DTO.Response
{
    public class ReservaResponseDTO
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdHabitacion { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public string NombreContactoEmergencia { get; set; } = string.Empty;
        public string TelefonoEmergencia { get; set; } = string.Empty;

        public ClienteResponseDTO Cliente { get; set; }
        public ReservaHuespedResponseDTO ReservaHuesped { get; set; }
        public List<HuespedResponseDTO> Huespedes { get; set; }
    }
}
