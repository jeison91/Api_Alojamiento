﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Alojamiento.Domain.Entities
{
    public class CiudadEntity
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Descripcion")]
        [Column(Order = 2)]
        public string Descripcion { get; set; } = string.Empty;

        [Required]
        [MaxLength(6)]
        [Display(Name = "Codigo")]
        [Column(Order = 3)]
        public string Codigo { get; set; } = string.Empty;
    }
}
