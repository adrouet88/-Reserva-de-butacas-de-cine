using Microsoft.EntityFrameworkCore;
using CinemaReservacion.Domain.Entidades;

namespace CinemaReservacion.Infrastructure.Data
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options)
            : base(options)
        {
        }

        public DbSet<MovieEntity> Movies { get; set; }
        public DbSet<RoomEntity> Rooms { get; set; }
        public DbSet<SeatEntity> Seats { get; set; }
        public DbSet<BillboardEntity> Billboards { get; set; }
        public DbSet<BookingEntity> Bookings { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // BookingEntity
            modelBuilder.Entity<BookingEntity>()
                .HasOne(b => b.Seat)
                .WithMany()
                .HasForeignKey(b => b.SeatId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BookingEntity>()
                .HasOne(b => b.Billboard)
                .WithMany()
                .HasForeignKey(b => b.BillboardId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BookingEntity>()
                .HasOne(b => b.Customer)
                .WithMany()
                .HasForeignKey(b => b.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            // BillboardEntity
            modelBuilder.Entity<BillboardEntity>()
                .HasOne(b => b.Movie)
                .WithMany()
                .HasForeignKey(b => b.MovieId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BillboardEntity>()
                .HasOne(b => b.Room)
                .WithMany()
                .HasForeignKey(b => b.RoomId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BillboardEntity>()
                .HasMany(b => b.Bookings)
                .WithOne(bk => bk.Billboard)
                .HasForeignKey(bk => bk.BillboardId)
                .OnDelete(DeleteBehavior.Restrict);

            // SeatEntity
            modelBuilder.Entity<SeatEntity>()
                .HasOne(s => s.Room)
                .WithMany()
                .HasForeignKey(s => s.RoomId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}