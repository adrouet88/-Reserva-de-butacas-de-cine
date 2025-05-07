using CinemaReservacion.Domain.Entidades;
using CinemaReservacion.Infrastructure.Data;
using CinemaReservacion.Infrastructure.Repositorios.Base;
using Microsoft.EntityFrameworkCore;

namespace CinemaReservacion.Infrastructure.Repositorios
{
    public class BookingRepository : GenericRepository<BookingEntity>, IBookingRepository
    {
        public BookingRepository(CinemaDbContext context) : base(context)
        {
        }

        // Aquí puedes agregar métodos personalizados para Booking si lo deseas.
    }
}
