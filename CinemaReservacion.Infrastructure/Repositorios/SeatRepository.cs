using CinemaReservacion.Domain.Entidades;
using CinemaReservacion.Infrastructure.Data;
using CinemaReservacion.Infrastructure.Repositorios.Base;

namespace CinemaReservacion.Infrastructure.Repositorios
{
    public class SeatRepository : GenericRepository<SeatEntity>, ISeatRepository
    {
        public SeatRepository(CinemaDbContext context) : base(context)
        {
        }
    }
}
