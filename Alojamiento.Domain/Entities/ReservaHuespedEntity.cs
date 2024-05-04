using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alojamiento.Domain.Entities
{
    public class ReservaHuespedEntity
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(Order = 2)]
        public int IdReserva { get; set; }
        [ForeignKey("IdReserva")]
        public ReservasEntity Reserva { get; set; }

        [Required]
        [Column(Order = 3)]
        public int IdHuesped { get; set; }
        [ForeignKey("IdHuesped")]
        public HuespedEntity Huesped { get; set; }
    }
}
