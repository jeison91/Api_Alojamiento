﻿using Alojamiento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alojamiento.Domain.IRepository
{
    public interface IHabitacionRepository : IGenericRepository<HabitacionEntity>
    {
        Task<bool> ValidateHotel(int IdHabitacion, int IdHotel);
    }
}
