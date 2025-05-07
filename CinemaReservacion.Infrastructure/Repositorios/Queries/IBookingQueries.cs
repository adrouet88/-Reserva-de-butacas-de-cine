using System.Collections.Generic;
using CinemaReservacion.Domain.Entidades;

namespace CinemaReservacion.Infrastructure.Repositorios.Queries
{
    public interface IBookingQueries
    {
        Task<IEnumerable<BookingEntity>> GetHorrorBookingsInDateRange(DateTime startDate, DateTime endDate);
        Task<IEnumerable<SeatAvailabilityDto>> GetSeatAvailabilityByRoomForToday();
        Task<IEnumerable<BookingEntity>> GetAllBookingsWithDetails();
    }

    public class SeatAvailabilityDto
    {
        public string RoomName { get; set; }
        public int AvailableSeats { get; set; }
        public int OccupiedSeats { get; set; }
    }
}
