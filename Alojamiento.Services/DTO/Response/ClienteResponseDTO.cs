using Alojamiento.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alojamiento.Services.DTO.Response
{
    public class ClienteResponseDTO
    {
        public int Id { get; set; }
        public int IdTipoDocumento { get; set; }
        public string Documento { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
        public int IdGenero { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Telefono { get; set; }
        public TipoDocumentoResponseDTO TipoDocumento { get; set; }
        public GeneroResponseDTO Genero { get; set; }
    }
}
