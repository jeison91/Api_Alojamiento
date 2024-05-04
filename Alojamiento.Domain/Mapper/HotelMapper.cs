using Alojamiento.Domain.Entities;
using Alojamiento.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Alojamiento.Domain.Mapper
{
    public static class HotelMapper
    {
        public static HotelModel MapModel(HotelEntity model)
        {
            //var model = new CustomerDTO();
            if (model != null)
                return AttibutesModel(model);
            return null;
        }

        public static List<HotelModel> MapModelList(List<HotelEntity> entities)
        {
            List<HotelModel> responseDTOs = new();
            if (entities != null)
            {
                foreach (HotelEntity item in entities)
                {
                    var fl = AttibutesModel(item);
                    responseDTOs.Add(fl);
                }
            }
            return responseDTOs;
        }

        private static HotelModel AttibutesModel(HotelEntity entity)
        {
            if (entity != null)
            {
                return new HotelModel()
                {
                    Id = entity.Id,
                    IdTipoDocumento = entity.IdTipoDocumento,
                    Identificacion = entity.Identificacion,
                    Nombre = entity.Nombre,
                    Direccion = entity.Direccion,
                    Telefono = entity.Telefono,
                    Calificacion = entity.Calificacion,
                    IdCiudad = entity.IdCiudad,
                    Estado = entity.Estado,
                    TipoDocumento = entity.TipoDocumento.MapToModel<TipoDocumentoModel>(),
                    Ciudad = entity.Ciudad.MapToModel<CiudadModel>(),
                    Habitaciones = HabitacionMapper.MapModelList(entity.Habitaciones),
                };
            }
            return new HotelModel();
        }
    }
}
