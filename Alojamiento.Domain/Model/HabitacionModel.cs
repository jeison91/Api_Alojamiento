using Alojamiento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Alojamiento.Domain.Model
{
    public class HabitacionModel
    {
        public int Id { get; set; }
        public decimal CostoBase { get; set; }
        public decimal Impuesto { get; set; }
        public int NumeroPersonas { get; set; }
        public int IdTipoHabitacion { get; set; }
        public int IdUbicacion { get; set; }
        public int IdHotel { get; set; }
        public bool Estado { get; set; }


        public TipoHabitacionModel TipoHabitacion { get; set; }
        public UbicacionHabitacionModel UbicacionHabitacion { get; set; }
        //public HotelModel Hotel{ get; set; }
        //public virtual List<ReservasEntity> Reservas { get; set; }
    }
}
