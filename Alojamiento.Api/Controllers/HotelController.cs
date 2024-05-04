using Alojamiento.Domain.Exceptions;
using Alojamiento.Services.DTO.Request;
using Alojamiento.Services.DTO.Response;
using Alojamiento.Services.Services;
using Alojamiento.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alojamiento.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class HotelController : ControllerBase
    {
        private readonly IHotelServices _hotelServices;

        public HotelController(IHotelServices hotelServices)
        {
            this._hotelServices = hotelServices;
        }

        /// <summary>
        /// Se encarga de validar los hoteles con sus habitaciones disponibles.
        /// </summary>
        /// <param name="FechaEntrada"></param>
        /// <param name="FechaSalida"></param>
        /// <param name="NumeroHuesped"></param>
        /// <param name="Ciudad"></param>
        /// <returns></returns>
        [HttpGet("GetAvaliableHotel")]
        public async Task<IActionResult> GetAvaliableHotel([FromQuery] DateTime FechaEntrada, [FromQuery] DateTime FechaSalida, [FromQuery] int NumeroHuesped, [FromQuery] int Ciudad)
        {
            try
            {
                if (FechaEntrada.Date < DateTime.Now.Date)
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseError
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Message = "La fecha entrada debe ser igual o superior a la fecha actual."
                    });
                if (FechaEntrada.Date >= FechaSalida)
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseError
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Message = "La fecha entrada debe ser inferior a la fecha de salida."
                    });

                return Ok(await _hotelServices.GetAvaliableHotel(FechaEntrada, FechaSalida, NumeroHuesped, Ciudad));
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
                    Message = "Se presento un error en la búsqueda de disponibilidad de vehículos." + ex.Message
                });
            }
        }

        /// <summary>
        /// Se encarga de crear los hoteles.
        /// </summary>
        /// <param name="hotelRequest"></param>
        /// <returns></returns>
        [HttpPost("AddHotel")]
        public async Task<IActionResult> AddHotel([FromBody] HotelRequestDTO hotelRequest)
        {
            try
            {
                await _hotelServices.CreateHotel(hotelRequest);
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

        /// <summary>
        /// Se encarga de modificar los datos de los hoteles.
        /// </summary>
        /// <param name="IdHotel"></param>
        /// <param name="hotelRequest"></param>
        /// <returns></returns>
        [HttpPut("UpdateHotel")]
        public async Task<IActionResult> UpdateHotel([FromQuery] int IdHotel, [FromBody] HotelRequestDTO hotelRequest)
        {
            try
            {
                await _hotelServices.UpdateHotel(IdHotel, hotelRequest);
                return StatusCode(StatusCodes.Status200OK);
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
                    Message = "Algo salio mal: " + ex.Message
                });
            }
        }

        /// <summary>
        /// Se encarga de habilitar o desahilitar un hotel.
        /// </summary>
        /// <param name="IdHotel"></param>
        /// <param name="State"></param>
        /// <returns></returns>
        [HttpPut("ToggleEnabledHotel")]
        public async Task<IActionResult> ToggleEnabledHotel([FromQuery] int IdHotel, [FromQuery] bool State)
        {
            try
            {
                await _hotelServices.EnableDisableHotel(IdHotel, State);
                return StatusCode(StatusCodes.Status200OK);
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
