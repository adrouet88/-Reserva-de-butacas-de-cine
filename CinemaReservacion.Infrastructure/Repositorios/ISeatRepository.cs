using CinemaReservacion.Domain.Entidades;
using CinemaReservacion.Infrastructure.Repositorios.Base;

namespace CinemaReservacion.Infrastructure.Repositorios
{
    public interface ISeatRepository : IGenericRepository<SeatEntity>
    {
        // Aquí puedes agregar métodos personalizados si los necesitas en el futuro
    }
}
