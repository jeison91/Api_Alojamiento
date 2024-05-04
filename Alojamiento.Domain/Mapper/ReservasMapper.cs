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
    public static class ReservasMapper
    {
        public static ReservaModel MapModel(ReservasEntity model)
        {
            //var model = new CustomerDTO();
            if (model != null)
                return AttibutesModel(model);
            return null;
        }

        public static List<ReservaModel> MapModelList(List<ReservasEntity> entities)
        {
            List<ReservaModel> responseDTOs = new();
            if (entities != null)
            {
                foreach (ReservasEntity item in entities)
                {
                    var fl = AttibutesModel(item);
                    responseDTOs.Add(fl);
                }
            }
            return responseDTOs;
        }

        private static ReservaModel AttibutesModel(ReservasEntity entity)
        {
            if (entity != null)
            {
                return new ReservaModel()
                {
                    Id = entity.Id,
                    IdCliente = entity.IdCliente,
                    IdHabitacion = entity.IdHabitacion,
                    FechaEntrada = entity.FechaEntrada,
                    FechaSalida = entity.FechaSalida,
                    NombreContactoEmergencia = entity.NombreContactoEmergencia,
                    TelefonoEmergencia = entity.TelefonoEmergencia,

                    Cliente = entity.Cliente.MapToModel<ClienteModel>(),
                    ReservaHuesped = ReservaHuespedMapper.MapModel(entity.ReservaHuesped),
                };
            }
            return new ReservaModel();
        }
    }
}
