using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Alojamiento.Domain.Entities
{
    public class HabitacionEntity
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "CostoBase")]
        [Column(Order = 2, TypeName = "decimal(12, 2)")]
        public decimal CostoBase { get; set; }

        [Required]
        [Display(Name = "Impuesto")]
        [Column(Order = 3, TypeName = "decimal(12, 2)")]
        public decimal Impuesto { get; set; }

        [Required]
        [Display(Name = "NumeroPersonas")]
        [Column(Order = 4)]
        public int NumeroPersonas { get; set; }

        [Required]
        [Display(Name = "IdTipoHabitacion")]
        [Column(Order = 5)]
        public int IdTipoHabitacion { get; set; }
        [ForeignKey("IdTipoHabitacion")]
        public TipoHabitacionEntity TipoHabitacion { get; set; }

        [Required]
        [Display(Name = "IdUbicacion")]
        [Column(Order = 6)]
        public int IdUbicacion { get; set; }
        [ForeignKey("IdUbicacion")]
        public UbicacionHabitacionEntity UbicacionHabitacion { get; set; }

        [Required]
        [Display(Name = "IdHotel")]
        [Column(Order = 7)]
        public int IdHotel { get; set; }
        [ForeignKey("IdHotel")]
        public HotelEntity Hotel { get; set; }

        [Display(Name = "Estado")]
        [Column(Order = 8)]
        public bool Estado { get; set; }

        public virtual List<ReservasEntity> Reservas { get; set; }
    }
}
