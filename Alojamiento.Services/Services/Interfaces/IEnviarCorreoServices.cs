using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alojamiento.Services.Services.Interfaces
{
    public interface IEnviarCorreoServices
    {
        Task SendEmail(string emailCliente);
    }
}
