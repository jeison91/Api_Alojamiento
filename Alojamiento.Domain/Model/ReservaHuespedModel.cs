using Alojamiento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alojamiento.Domain.Model
{
    public class ReservaHuespedModel
    {
        public int Id { get; set; }
        public int IdReserva { get; set; }
        public int IdHuesped { get; set; }

        //public ReservasEntity Reserva { get; set; }
        public HuespedModel Huesped { get; set; }
    }
}
