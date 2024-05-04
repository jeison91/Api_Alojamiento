using Alojamiento.Domain.Entities;
using Alojamiento.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alojamiento.Domain.Mapper
{
    public static class HabitacionMapper
    {
        public static HabitacionModel MapModel(HabitacionEntity model)
        {
            //var model = new CustomerDTO();
            if (model != null)
                return AttibutesModel(model);
            return null;
        }

        public static List<HabitacionModel> MapModelList(List<HabitacionEntity> entities)
        {
            List<HabitacionModel> responseDTOs = new();
            if (entities != null)
            {
                foreach (HabitacionEntity item in entities)
                {
                    var fl = AttibutesModel(item);
                    responseDTOs.Add(fl);
                }
            }
            return responseDTOs;
        }

        private static HabitacionModel AttibutesModel(HabitacionEntity entity)
        {
            if (entity != null)
            {
                return new HabitacionModel()
                {
                    Id = entity.Id,
                    CostoBase = entity.CostoBase,
                    Impuesto = entity.Impuesto,
                    NumeroPersonas = entity.NumeroPersonas,
                    IdTipoHabitacion = entity.IdTipoHabitacion,
                    IdUbicacion = entity.IdUbicacion,
                    IdHotel = entity.IdHotel,
                    Estado = entity.Estado,
                    TipoHabitacion = entity.TipoHabitacion.MapToModel<TipoHabitacionModel>(),
                    UbicacionHabitacion = entity.UbicacionHabitacion.MapToModel<UbicacionHabitacionModel>(),
                    //Hotel = entity.Hotel.MapToModel<HotelModel>()
                };
            }
            return new HabitacionModel();
        }
    }
}
