using Alojamiento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Alojamiento.Domain.Model
{
    public class ReservaModel
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdHabitacion { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public string NombreContactoEmergencia { get; set; } = string.Empty;
        public string TelefonoEmergencia { get; set; } = string.Empty;

        public ClienteModel Cliente { get; set; }
        public ReservaHuespedModel ReservaHuesped { get; set; }
        public List<HuespedModel> Huespedes { get; set; }
    }
}
