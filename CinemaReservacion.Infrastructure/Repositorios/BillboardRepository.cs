using CinemaReservacion.Domain.Entidades;
using CinemaReservacion.Infrastructure.Data;
using CinemaReservacion.Infrastructure.Repositorios.Base;

namespace CinemaReservacion.Infrastructure.Repositorios
{
    public class BillboardRepository : GenericRepository<BillboardEntity>, IBillboardRepository
    {
        public BillboardRepository(CinemaDbContext context) : base(context)
        {
        }

        // Aquí van los métodos específicos para Billboard
    }
}