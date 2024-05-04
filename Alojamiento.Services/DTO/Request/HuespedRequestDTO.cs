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
    public class HuespedRequestDTO
    {
        [Required(ErrorMessage = "{0} es obligatorio.")]
        [Display(Name = "Tipo Documento")]
        public int IdTipoDocumento { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio.")]
        [MaxLength(20, ErrorMessage = "{0} no puede exceder los {1} caracteres.")]
        [Display(Name = "Documento")]
        public string Documento { get; set; } = string.Empty;

        [Required(ErrorMessage = "{0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "{0} no puede exceder los {1} caracteres.")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "{0} es obligatorio.")]
        [Display(Name = "Fecha Nacimiento")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio.")]
        [Display(Name = "Genero")]
        public int IdGenero { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio.")]
        [MaxLength(100, ErrorMessage = "{0} no puede exceder los {1} caracteres.")]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "{0} es obligatorio.")]
        [MaxLength(13, ErrorMessage = "{0} no puede exceder los {1} caracteres.")]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; } = string.Empty;
    }
}
