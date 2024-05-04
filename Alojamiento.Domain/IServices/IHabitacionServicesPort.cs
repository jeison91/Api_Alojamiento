using Alojamiento.Domain.Entities;
using Alojamiento.Domain.IRepository;
using Alojamiento.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alojamiento.Domain.IServices
{
    public interface IHabitacionServicesPort
    {
        Task CreateHabitacion(HabitacionModel HabitacionModel);
        Task UpdateHabitacion(HabitacionModel HabitacionModel);
        Task EnableDisableHabitacion(int Id, bool isEnabled);
    }
}
