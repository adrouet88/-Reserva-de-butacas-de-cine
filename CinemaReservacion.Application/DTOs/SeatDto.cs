
namespace CinemaReservacion.Application.DTOs
{
    public class SeatDto
    {
        public int Id { get; set; }
        public short Number { get; set; }
        public short RowNumber { get; set; }
        public int RoomId { get; set; }
        public bool Status { get; set; }
    }
}
