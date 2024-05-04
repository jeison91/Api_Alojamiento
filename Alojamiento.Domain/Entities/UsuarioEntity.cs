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
    public class UsuarioEntity
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "IdTipoDocumento")]
        [Column(Order = 2)]
        public int IdTipoDocumento { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Documento")]
        [Column(Order = 3)]
        public string Documento { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        [Display(Name = "Nombre")]
        [Column(Order = 4)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [Display(Name = "FechaNacimiento")]
        [Column(Order = 5)]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [Display(Name = "IdGenero")]
        [Column(Order = 6)]
        public int IdGenero { get; set; }
        [ForeignKey("IdGenero")]
        public GeneroEntity Genero { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Email")]
        [Column(Order = 8)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(13)]
        [Display(Name = "Telefono")]
        [Column(Order = 7)]
        public string Telefono { get; set; }

        [ForeignKey("IdTipoDocumento")]
        public TipoDocumentoEntity TipoDocumento { get; set; }
    }
}
