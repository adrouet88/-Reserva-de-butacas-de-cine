using CinemaReservacion.Application.Interfaces;
using CinemaReservacion.Infrastructure.Repositorios;
using CinemaReservacion.Infrastructure.Repositorios.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CinemaReservacionApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IBookingQueries _bookingQueries;

        public BookingController(
            IBookingService bookingService,
            IBookingQueries bookingQueries)
        {
            _bookingService = bookingService;
            _bookingQueries = bookingQueries;
        }

        /// <summary>
        /// Cancela una reserva y habilita la butaca.
        /// </summary>
        /// 

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var all = await _bookingQueries.GetAllBookingsWithDetails();
            return Ok(all);
        }


        [HttpPut("cancelar/{bookingId}")]
        public async Task<IActionResult> CancelarReserva(int bookingId)
        {
            try
            {
                await _bookingService.CancelarReservaYButacaAsync(bookingId);
                return Ok(new { message = "Reserva cancelada y butaca habilitada." });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Ocurrió un error inesperado.", detail = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene reservas de género terror en un rango de fechas.
        /// </summary>
        [HttpGet("horror")]
        public async Task<IActionResult> GetHorrorReservations([FromQuery] DateTime start, [FromQuery] DateTime end)
        {
            var list = await _bookingQueries.GetHorrorBookingsInDateRange(start, end);
            return Ok(list);
        }

        /// <summary>
        /// Obtiene la disponibilidad de butacas por sala para la fecha de hoy.
        /// </summary>
        [HttpGet("availability/today")]
        public async Task<IActionResult> GetTodaySeatAvailability()
        {
            var list = await _bookingQueries.GetSeatAvailabilityByRoomForToday();
            return Ok(list);
        }
    }
}
