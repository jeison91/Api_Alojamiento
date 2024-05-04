using Alojamiento.Domain.Exceptions;
using Alojamiento.Services.DTO.Request;
using Alojamiento.Services.DTO.Response;
using Alojamiento.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alojamiento.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaServices _reservaServices;

        public ReservaController(IReservaServices reservaServices)
        {
            this._reservaServices = reservaServices;
        }

        /// <summary>
        /// Se encarga de mostrar todas la reservas que se tiene apartir de una fecha.
        /// </summary>
        /// <param name="FechaIncial"></param>
        /// <returns></returns>
        [HttpGet("GetListReserva")]
        public async Task<IActionResult> GetListReserva([FromQuery] DateTime FechaIncial)
        {
            try
            {
                return Ok(await _reservaServices.GetListReserva(FechaIncial));
            }
            catch (DomainValidateException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseError
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseError
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Algo salio mal: {ex.Message}"
                });
            }
        }

        /// <summary>
        /// Se encarga de realizar la reserva de la habitación del hotel.
        /// </summary>
        /// <param name="reservarRequest"></param>
        /// <returns></returns>
        [HttpPost("AddReserva")]
        public async Task<IActionResult> AddReserva([FromBody] ReservarRequestDTO reservarRequest)
        {
            try
            {
                await _reservaServices.CreateReserva(reservarRequest);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (DomainValidateException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseError
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseError
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Algo salio mal: {ex.Message}"
                });
            }
        }
    }
}
