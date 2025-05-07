using System.Threading.Tasks;

namespace CinemaReservacion.Application.Services
{
    public interface IBillboardService
    {
        Task CancelarCarteleraYReservasAsync(int billboardId);
    }
}
