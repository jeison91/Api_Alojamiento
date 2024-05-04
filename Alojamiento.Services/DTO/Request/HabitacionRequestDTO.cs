using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alojamiento.Services.DTO.Request
{
    public class HabitacionRequestDTO
    {
        [Required(ErrorMessage = "{0} es obligatorio.")]
        [Display(Name = "CostoBase")]
        public decimal CostoBase { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio.")]
        [Display(Name = "Impuesto")]
        public decimal Impuesto { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio.")]
        [Display(Name = "NumeroPersonas")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} debe estar entre {1} y {2}.")]
        public int NumeroPersonas { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio.")]
        [Display(Name = "Tipo Habitacion")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} es obligatorio.")]
        public int IdTipoHabitacion { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio.")]
        [Display(Name = "Ubicacion")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} es obligatorio.")]
        public int IdUbicacion { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio.")]
        [Display(Name = "Hotel")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} es obligatorio.")]
        public int IdHotel { get; set; }

        [Display(Name = "Estado")]
        public bool Estado { get; set; }
    }
}
