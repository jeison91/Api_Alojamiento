using Alojamiento.Services.DTO.Request;
using Alojamiento.Services.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alojamiento.Services.Services.Interfaces
{
    public interface IHabitacionServices
    {
        Task CreateHabitacion(HabitacionRequestDTO HabitacionRequest);
        Task UpdateHabitacion(int Id, HabitacionRequestDTO HabitacionRequest);
        Task EnableDisableHabitacion(int Id, bool isEnabled);
    }
}
