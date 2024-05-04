using Alojamiento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Alojamiento.Domain.Model
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public int IdTipoDocumento { get; set; }
        public string Documento { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
        public int IdGenero { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Telefono { get; set; }
        public TipoDocumentoModel TipoDocumento { get; set; }
        public GeneroModel Genero { get; set; }
    }
}
