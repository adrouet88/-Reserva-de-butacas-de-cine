
namespace CinemaReservacion.Application.DTOs
{
    public class BookingDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public int SeatId { get; set; }
        public int BillboardId { get; set; }
    }
}
