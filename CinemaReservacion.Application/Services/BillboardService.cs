using CinemaReservacion.Application.DTOs;
using CinemaReservacion.Application.Interfaces;
using CinemaReservacion.Domain.Entidades;
using CinemaReservacion.Infrastructure.Data;
using CinemaReservacion.Infrastructure.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace CinemaReservacion.Application.Services
{
    public class BillboardService : IBillboardService
    {
        private readonly IBillboardRepository _billboardRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly ISeatRepository _seatRepository;
        private readonly CinemaDbContext _context;
        private readonly ILogger<BillboardService> _logger;

        public BillboardService(
            IBillboardRepository billboardRepository,
            IBookingRepository bookingRepository,
            ISeatRepository seatRepository,
            CinemaDbContext context,
            ILogger<BillboardService> logger)
        {
            _billboardRepository = billboardRepository;
            _bookingRepository = bookingRepository;
            _seatRepository = seatRepository;
            _context = context;
            _logger = logger;
        }

        public async Task CancelarCarteleraYReservasAsync(int billboardId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            var billboard = await _billboardRepository.GetByIdAsync(billboardId);

            if (billboard == null)
                throw new Exception("Cartelera no encontrada.");

            if (billboard.Date.Date < DateTime.Now.Date)
                throw new InvalidOperationException("No se puede cancelar funciones de la cartelera con fecha anterior a la actual");

            var bookings = await _bookingRepository
                .FindAsync(b => b.BillboardId == billboardId && b.Status == true);

            foreach (var booking in bookings)
            {
                booking.Status = false;
                await _bookingRepository.UpdateAsync(booking);

                var seat = await _seatRepository.GetByIdAsync(booking.SeatId);
                if (seat != null)
                {
                    seat.Status = true; // habilitar butaca
                    await _seatRepository.UpdateAsync(seat);
                }

                var customer = booking.Customer;
                if (customer != null)
                {
                    _logger.LogInformation($"Cliente afectado: {customer.Name} {customer.Lastname} ({customer.Email})");
                }
            }

            billboard.Status = false;
            await _billboardRepository.UpdateAsync(billboard);

            await transaction.CommitAsync();
        }
    }
}
