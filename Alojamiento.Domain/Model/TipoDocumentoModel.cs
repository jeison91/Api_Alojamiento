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
    public class TipoDocumentoModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
    }
}
