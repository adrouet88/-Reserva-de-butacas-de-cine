using Microsoft.AspNetCore.Mvc;
using CinemaReservacion.Application.Interfaces;
using System;
using System.Threading.Tasks;
using CinemaReservacion.Application.Services;

namespace CinemaReservacionApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BillboardController : ControllerBase
    {
        private readonly IBillboardService _billboardService;

        public BillboardController(IBillboardService billboardService)
        {
            _billboardService = billboardService;
        }

        [HttpPut("cancelar-cartelera/{billboardId}")]
        public async Task<IActionResult> CancelarCarteleraYReservasAsync(int billboardId)
        {
            try
            {
                await _billboardService.CancelarCarteleraYReservasAsync(billboardId);
                return Ok(new { message = "Cartelera cancelada exitosamente." });
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
    }
}
