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
    public class HotelModel
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

        public TipoDocumentoModel TipoDocumento { get; set; }
        public CiudadModel Ciudad { get; set; }
        public virtual List<HabitacionModel>? Habitaciones { get; set; }
    }
}
