using Alojamiento.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alojamiento.Services.DTO.Response
{
    public class HotelResponseDTO
    {
        public int Id { get; set; }
        public int IdTipoDocumento { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int Calificacion { get; set; } = 1;
        public int IdCiudad { get; set; }
        public bool Estado { get; set; }

        public TipoDocumentoResponseDTO TipoDocumento { get; set; }
        public CiudadResponseDTO Ciudad { get; set; }
        public virtual List<HabitacionResponseDTO>? Habitaciones { get; set; }
    }
}
