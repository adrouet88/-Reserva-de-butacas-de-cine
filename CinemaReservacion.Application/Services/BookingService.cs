using CinemaReservacion.Application.DTOs;
using CinemaReservacion.Application.Interfaces;
using CinemaReservacion.Domain.Entidades;
using CinemaReservacion.Infrastructure.Data;
using CinemaReservacion.Infrastructure.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CinemaReservacion.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly ISeatRepository _seatRepository;
        private readonly CinemaDbContext _context;
        private readonly ILogger<BookingService> _logger;

        public BookingService(
            IBookingRepository bookingRepository,
            ISeatRepository seatRepository,
            CinemaDbContext context,
            ILogger<BookingService> logger)
        {
            _bookingRepository = bookingRepository;
            _seatRepository = seatRepository;
            _context = context;
            _logger = logger;
        }

        public async Task CancelarReservaYButacaAsync(int bookingId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var booking = await _bookingRepository.GetByIdAsync(bookingId);

                if (booking == null)
                    throw new Exception("Reserva no encontrada");

                booking.Status = false;

                var seat = await _seatRepository.GetByIdAsync(booking.SeatId);
                seat.Status = true;

                await _bookingRepository.UpdateAsync(booking);
                await _seatRepository.UpdateAsync(seat);

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, "Error al cancelar la reserva.");
                throw;
            }
        }
    }
}
