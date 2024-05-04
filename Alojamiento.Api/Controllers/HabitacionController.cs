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
    public class HabitacionController : ControllerBase
    {
        private readonly IHabitacionServices _habitacionServices;

        public HabitacionController(IHabitacionServices habitacionServices)
        {
            this._habitacionServices = habitacionServices;
        }

        /// <summary>
        /// Se encarga de crear las habitaciones de los hoteles.
        /// </summary>
        /// <param name="HabitacionRequest"></param>
        /// <returns></returns>
        [HttpPost("AddHabitacion")]
        public async Task<IActionResult> AddHabitacion([FromBody] HabitacionRequestDTO HabitacionRequest)
        {
            try
            {
                await _habitacionServices.CreateHabitacion(HabitacionRequest);
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
        /// Se encarga de actualizar los datos de las habitaciones.
        /// </summary>
        /// <param name="IdHabitacion"></param>
        /// <param name="HabitacionRequest"></param>
        /// <returns></returns>
        [HttpPut("UpdateHabitacion")]
        public async Task<IActionResult> UpdateHabitacion(int IdHabitacion, [FromBody] HabitacionRequestDTO HabitacionRequest)
        {
            try
            {
                await _habitacionServices.UpdateHabitacion(IdHabitacion, HabitacionRequest);
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
        /// Se encarga de habilitar o deshabilitar una habitación.
        /// </summary>
        /// <param name="IdHabitacion"></param>
        /// <param name="State"></param>
        /// <returns></returns>
        [HttpPut("ToggleEnabledHabitacion")]
        public async Task<IActionResult> ToggleEnabledHabitacion([FromQuery] int IdHabitacion, [FromQuery] bool State)
        {
            try
            {
                await _habitacionServices.EnableDisableHabitacion(IdHabitacion, State);
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
