using Alojamiento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Alojamiento.Services.DTO.Request
{
    public class HotelRequestDTO
    {
        [Display(Name = "Tipo Documento")]
        [Required(ErrorMessage = "{0} es obligatorio.")]
        [Range(11, 42, ErrorMessage = "{0} es obligatorio.")]
        public int IdTipoDocumento { get; set; }

        [Display(Name = "Identificacion")]
        [Required(ErrorMessage = "{0} es obligatorio.")]
        [MaxLength(20, ErrorMessage = "{0} no puede exceder los {1} caracteres.")]
        public string Identificacion { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio.")]
        [MaxLength(100, ErrorMessage = "{0} no puede exceder los {1} caracteres.")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [MaxLength(100, ErrorMessage = "{0} no puede exceder los {1} caracteres.")]
        [Display(Name = "Direccion")]
        public string Direccion { get; set; }

        [MaxLength(20, ErrorMessage = "{0} no puede exceder los {1} caracteres.")]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Display(Name = "Calificación")]
        [Range(1, 5, ErrorMessage = "{0} debe estar entre {1} y {2}.")]
        public int Calificacion { get; set; } = 1;

        [Required(ErrorMessage = "{0} es obligatoria.")]
        [Display(Name = "Ciudad")]
        public int IdCiudad { get; set; }

        [Display(Name = "Estado")]
        public bool Estado { get; set; }

        //public virtual Habitacion? HabitacionEntity { get; set; }
    }
}
