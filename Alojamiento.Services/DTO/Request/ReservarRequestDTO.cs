using System.ComponentModel.DataAnnotations;

namespace Alojamiento.Services.DTO.Request
{
    public class ReservarRequestDTO
    {
        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "{0} es obligatorio.")]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio.")]
        [Display(Name = "Habitación")]
        public int IdHabitacion { get; set; }

        [Required(ErrorMessage = "{0} es obligatoria.")]
        [Display(Name = "Fecha Entrada")]
        [DataType(DataType.Date)]
        public DateTime FechaEntrada { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio.")]
        [Display(Name = "Fecha Salida")]
        [DataType(DataType.Date)]
        public DateTime FechaSalida { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "{0} no puede exceder los {1} caracteres.")]
        [Display(Name = "Nombre Contacto Emergencia")]
        public string NombreContactoEmergencia { get; set; } = string.Empty;

        [Required(ErrorMessage = "{0} es obligatorio.")]
        [MaxLength(20, ErrorMessage = "{0} no puede exceder los {1} caracteres.")]
        [Display(Name = "Telefono Emergencia")]
        public string TelefonoEmergencia { get; set; } = string.Empty;

        public List<HuespedRequestDTO> Huespedes { get; set; }
    }
}
