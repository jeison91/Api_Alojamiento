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
    public static class HuespedMapper
    {
        public static HuespedModel MapModel(HuespedEntity model)
        {
            //var model = new CustomerDTO();
            if (model != null)
                return AttibutesModel(model);
            return null;
        }

        public static List<HuespedModel> MapModelList(List<HuespedEntity> entities)
        {
            List<HuespedModel> responseDTOs = new();
            if (entities != null)
            {
                foreach (HuespedEntity item in entities)
                {
                    var fl = AttibutesModel(item);
                    responseDTOs.Add(fl);
                }
            }
            return responseDTOs;
        }

        private static HuespedModel AttibutesModel(HuespedEntity entity)
        {
            if (entity != null)
            {
                return new HuespedModel()
                {
                    Id = entity.Id,
                    IdTipoDocumento = entity.IdTipoDocumento,
                    Documento = entity.Documento,
                    Nombre = entity.Nombre,
                    FechaNacimiento = entity.FechaNacimiento,
                    Telefono = entity.Telefono,
                    IdGenero = entity.IdGenero,
                    Email = entity.Email
                };
            }
            return new HuespedModel();
        }
    }
}
