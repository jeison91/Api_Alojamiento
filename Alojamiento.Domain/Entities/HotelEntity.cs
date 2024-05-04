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
    public class HotelEntity
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "IdTipoDocumento")]
        [Column(Order = 2)]
        public int IdTipoDocumento { get; set; }
        [ForeignKey("IdTipoDocumento")]
        public TipoDocumentoEntity TipoDocumento { get; set; }

        [Display(Name = "Identificacion")]
        [Column(Order = 3)]
        [MaxLength(20)]
        public string Identificacion { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        [Display(Name = "Nombre")]
        [Column(Order = 4)]
        public string Nombre { get; set; } = string.Empty;

        [MaxLength(100)]
        [Display(Name = "Direccion")]
        [Column(Order = 5)]
        public string Direccion { get; set; } = string.Empty;

        [MaxLength(20)]
        [Display(Name = "Telefono")]
        [Column(Order = 6)]
        public string Telefono { get; set; } = string.Empty;

        [Display(Name = "Calificacion")]
        [Column(Order = 7)]
        public int Calificacion { get; set; } = 1;

        [Required]
        [Display(Name = "IdCiudad")]
        [Column(Order = 8)]
        public int IdCiudad { get; set; }
        [ForeignKey("IdCiudad")]
        public CiudadEntity Ciudad { get; set; }

        [Display(Name = "Estado")]
        [Column(Order = 9)]
        public bool Estado { get; set; } = true;

        public virtual List<HabitacionEntity> Habitaciones { get; set; }
    }
}
