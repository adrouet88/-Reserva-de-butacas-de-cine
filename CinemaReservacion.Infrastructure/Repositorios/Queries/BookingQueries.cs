using CinemaReservacion.Domain.Entidades;
using CinemaReservacion.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace CinemaReservacion.Infrastructure.Repositorios.Queries
{
    public class BookingQueries : IBookingQueries
    {
        private readonly CinemaDbContext _context;

        public BookingQueries(CinemaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BookingEntity>> GetAllBookingsWithDetails()
        {
            return await _context.Bookings
                .Include(b => b.Customer)
                .Include(b => b.Seat)
                .Include(b => b.Billboard)
                .ToListAsync();
        }

        public async Task<IEnumerable<BookingEntity>> GetHorrorBookingsInDateRange(DateTime startDate, DateTime endDate)
        {
            return await _context.Bookings
                .Include(b => b.Billboard)
                    .ThenInclude(bb => bb.Movie)
                .Where(b => b.Billboard.Movie.Genre == MovieGenreEnum.HORROR &&
                            b.Date >= startDate && b.Date <= endDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<SeatAvailabilityDto>> GetSeatAvailabilityByRoomForToday()
        {
            var today = DateTime.Today;

            var result = await _context.Billboards
                .Where(bb => bb.Date == today)
                .Include(bb => bb.Room)
                .Include(bb => bb.Bookings)
                .ThenInclude(bk => bk.Seat)
                .GroupBy(bb => bb.Room.Name)
                .Select(g => new SeatAvailabilityDto
                {
                    RoomName = g.Key,
                    AvailableSeats = _context.Seats.Count(s => s.RoomId == g.First().RoomId && s.Status) - g.SelectMany(bb => bb.Bookings).Count(),
                    OccupiedSeats = g.SelectMany(bb => bb.Bookings).Count()
                })
                .ToListAsync();

            return result;
        }
    }
}
