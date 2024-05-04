using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alojamiento.Domain.Entities
{
    public class ReservasEntity
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(Order = 2)]
        public int IdCliente { get; set; }
        [ForeignKey("IdCliente")]
        public ClienteEntity Cliente { get; set; }

        [Required]
        [Column(Order = 3)]
        public int IdHabitacion { get; set; }
        [ForeignKey("IdHabitacion")]
        public HabitacionEntity Habitacion { get; set; }

        [Required]
        [Column(Order = 4)]
        [DataType(DataType.Date)]
        public DateTime FechaEntrada { get; set; }

        [Required]
        [Column(Order = 5)]
        [DataType(DataType.Date)]
        public DateTime FechaSalida { get; set; }

        [MaxLength(50)]
        [Display(Name = "NombreContactoEmergencia")]
        [Column(Order = 6)]
        public string NombreContactoEmergencia { get; set; } = string.Empty;

        [MaxLength(20)]
        [Display(Name = "TelefonoEmergencia")]
        [Column(Order = 7)]
        public string TelefonoEmergencia { get; set; } = string.Empty;

        public ReservaHuespedEntity ReservaHuesped { get; set; }
    }
}
