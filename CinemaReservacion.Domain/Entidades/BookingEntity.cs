using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaReservacion.Domain.Entidades
{
    public class BookingEntity : BaseEntity
    {
        [Required]
        public DateTime Date { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public CustomerEntity Customer { get; set; }

        [ForeignKey("Seat")]
        public int SeatId { get; set; }
        public SeatEntity Seat { get; set; }

        [ForeignKey("Billboard")]
        public int BillboardId { get; set; }
        public BillboardEntity Billboard { get; set; }
    }
}
