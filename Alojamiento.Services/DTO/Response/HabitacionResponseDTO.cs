using Alojamiento.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alojamiento.Services.DTO.Response
{
    public class HabitacionResponseDTO
    {
        public int Id { get; set; }
        public decimal CostoBase { get; set; }
        public decimal Impuesto { get; set; }
        public int NumeroPersonas { get; set; }
        public int IdTipoHabitacion { get; set; }
        public int IdUbicacion { get; set; }
        public int IdHotel { get; set; }
        public bool Estado { get; set; }

        public TipoHabitacionResponseDTO TipoHabitacion { get; set; }
        public UbicacionHabitacionResponseDTO UbicacionHabitacion { get; set; }
        //public HotelResponseDTO Hotel { get; set; }
    }
}
