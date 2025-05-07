using CinemaReservacion.Domain.Entidades;
using CinemaReservacion.Infrastructure.Repositorios.Base;

namespace CinemaReservacion.Infrastructure.Repositorios
{
    public interface IBookingRepository : IGenericRepository<BookingEntity>
    {
        // Aquí puedes definir métodos específicos si necesitas, por ahora puede quedar vacío.
    }
}