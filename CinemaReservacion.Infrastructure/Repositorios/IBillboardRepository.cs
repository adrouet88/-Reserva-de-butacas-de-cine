using CinemaReservacion.Domain.Entidades;
using CinemaReservacion.Infrastructure.Repositorios.Base;

namespace CinemaReservacion.Infrastructure.Repositorios
{
    public interface IBillboardRepository : IGenericRepository<BillboardEntity>
    {
        // Puedes agregar métodos personalizados para Billboard si lo necesitas
    }
}
