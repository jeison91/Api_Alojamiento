using Alojamiento.Domain.Entities;
using Alojamiento.Domain.Exceptions;
using Alojamiento.Domain.IRepository;
using Alojamiento.Domain.IServices;
using Alojamiento.Domain.Mapper;
using Alojamiento.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alojamiento.Domain.UseCase
{
    public class ReservasUseCase : IReservasServicesPort
    {
        private readonly IReservasRepository _reservasRepository;
        private readonly IHabitacionRepository _habitacionRepository;
        private readonly IHuespedRepository _huespedRepository;
        private readonly IReservaHuespedRepository _reservaHuespedRepository;

        public ReservasUseCase(IReservasRepository reservasRepository, IHabitacionRepository habitacionRepository,
            IHuespedRepository huespedRepository, IReservaHuespedRepository reservaHuespedRepository)
        {
            this._reservasRepository = reservasRepository;
            this._habitacionRepository = habitacionRepository;
            this._huespedRepository = huespedRepository;
            this._reservaHuespedRepository = reservaHuespedRepository;
        }

        public async Task<ReservaModel> CreateReserva(ReservaModel reservaModel)
        {
            var habitacionEntity = await _habitacionRepository.GetById(reservaModel.IdHabitacion);
            if (habitacionEntity.NumeroPersonas < reservaModel.Huespedes.Count)
                throw new DomainValidateException("La habitación no esta acondicionada para recibir este número de huespedes.");

            var reservaEntity = reservaModel.MapToModel<ReservasEntity>();
            var entity = await _reservasRepository.CreateReserva(reservaEntity);

            //Crear Relacion Reserva Huesped
            foreach (var item in reservaModel.Huespedes)
            {
                //Validar Huesped con documento y/o crearlo
                var huespedEntity = await _huespedRepository.GetByDocument(item.Documento);
                huespedEntity ??= await _huespedRepository.Create(item.MapToModel<HuespedEntity>());

                ReservaHuespedEntity reservaHuespedEntity = new()
                {
                    IdHuesped = huespedEntity.Id,
                    IdReserva = entity.Id
                };

                await _reservaHuespedRepository.Create(reservaHuespedEntity);
            }

            return reservaModel;
        }

        public async Task<List<ReservaModel>> GetListReserva(DateTime FechaInicial)
        {
            var entity = await _reservasRepository.GetReserva(FechaInicial);
            var reservaModels = ReservasMapper.MapModelList(entity);

            foreach (var reserva in reservaModels)
            {
                reserva.ReservaHuesped.Huesped = (await _huespedRepository.GetById(reserva.ReservaHuesped.IdHuesped)).MapToModel<HuespedModel>();
            }
            
            return reservaModels;
        }
    }
}
