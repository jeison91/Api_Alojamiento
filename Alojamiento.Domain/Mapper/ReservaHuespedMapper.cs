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
    public static class ReservaHuespedMapper
    {
        public static ReservaHuespedModel MapModel(ReservaHuespedEntity model)
        {
            //var model = new CustomerDTO();
            if (model != null)
                return AttibutesModel(model);
            return null;
        }

        public static List<ReservaHuespedModel> MapModelList(List<ReservaHuespedEntity> entities)
        {
            List<ReservaHuespedModel> responseDTOs = new();
            if (entities != null)
            {
                foreach (ReservaHuespedEntity item in entities)
                {
                    var fl = AttibutesModel(item);
                    responseDTOs.Add(fl);
                }
            }
            return responseDTOs;
        }

        private static ReservaHuespedModel AttibutesModel(ReservaHuespedEntity entity)
        {
            if (entity != null)
            {
                return new ReservaHuespedModel()
                {
                    Id = entity.Id,
                    IdReserva = entity.IdReserva,
                    IdHuesped = entity.IdHuesped,
                    Huesped = HuespedMapper.MapModel(entity.Huesped)
                };
            }
            return new ReservaHuespedModel();
        }
    }
}
