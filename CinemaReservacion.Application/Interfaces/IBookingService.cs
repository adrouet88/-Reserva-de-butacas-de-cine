using CinemaReservacion.Application.DTOs;
using System.Threading.Tasks;

namespace CinemaReservacion.Application.Interfaces
{
    public interface IBookingService
    {
        
        /// <summary>
        /// Cancela una reserva específica y deshabilita la butaca correspondiente.
        /// </summary>
        /// <param name="bookingId">ID de la reserva a cancelar.</param>
        Task CancelarReservaYButacaAsync(int bookingId);
    }
}
